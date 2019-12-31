using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.WinExplorer;
using WolvenKit.Common;
using WolvenKit.Interfaces;
using WolvenKit.Models;

namespace WolvenKit.Views
{
    public partial class AssetExplorer : XtraForm
    {
        public List<IWitcherArchive> Archives;
        public List<AssetBrowserItem> ExplorerDataSource = new List<AssetBrowserItem>();
        public List<IWitcherFile> FileList = new List<IWitcherFile>();
        public AssetBrowserItem ActiveItem { get; set; }
        public AssetBrowserItem SelectedItem { get; set; }
        public AssetBrowserItem RootItem { get; set; }
        public BreadCrumbEdit BreadCrumb => editBreadCrumb;

        public AssetExplorer(List<IWitcherArchive> witcherArchives = null)
        {
            InitializeComponent();
            if (witcherArchives != null)
            {
                Archives = witcherArchives;
                CreateRootFileList();
                ActiveItem = ExplorerDataSource.First();
                gridControl.DataSource = ExplorerDataSource;
            }

            FileSystemImageCache.Cache.EnableFileIconCaching = false;
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime) Load += OnLoad;
        }

        public AssetExplorer()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeBreadCrumb();
            InitializeAppearance();
        }

        private void CreateRootFileList()
        {
            var rootNode = new WitcherTreeNode {Name = "Root"};
            foreach (var archive in Archives)
            {
                FileList.AddRange(archive.FileList);
                rootNode.Directories[archive.RootNode.Name] = archive.RootNode;
                archive.RootNode.Parent = rootNode;
            }

            RootItem = new AssetBrowserItem
            {
                Directories = rootNode.Directories.Values.ToList(), Name = rootNode.Name, FullPath = rootNode.FullPath,
                ImageIndex = GetImageIndex(Path.GetExtension(rootNode.FullPath)),
                Files = rootNode.Files.Values.SelectMany(x => x).ToList(), IsDirectory = true
            };
            ExplorerDataSource.Add(RootItem);
        }

        private void InitializeBreadCrumb()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            BreadCrumb.Path = RootItem.FullPath;
            BreadCrumb.Properties.History.Add(new BreadCrumbHistoryItem(RootItem.FullPath));
        }

        private void InitializeAppearance()
        {
            var item = rgbiViewStyle.Gallery.GetCheckedItem();
            if (item != null)
                winExplorerView.OptionsView.Style = (WinExplorerViewStyle) item.Tag;
        }

        private void OnBreadCrumbPathChanged(object sender, BreadCrumbPathChangedEventArgs e)
        {
            BreadCrumb.Path = !string.IsNullOrWhiteSpace(ActiveItem?.FullPath)
                ? ActiveItem.FullPath
                : RootItem.FullPath;
            UpdateButtons();
        }

        private void OnBreadCrumbNewNodeAdding(object sender, BreadCrumbNewNodeAddingEventArgs e)
        {
            e.Node.PopulateOnDemand = true;
        }

        private void OnBreadCrumbQueryChildNodes(object sender, BreadCrumbQueryChildNodesEventArgs e)
        {
            if (e.Node.Path == "Root")
            {
                e.Node.ChildNodes.Add(new BreadCrumbNode{Caption = RootItem.FullPath, Value = RootItem, PopulateOnDemand = true});
                return;
            }
            if (ActiveItem == null) return;
            foreach (var directory in ActiveItem.Directories)
                e.Node.ChildNodes.Add(new BreadCrumbNode(directory.FullPath, directory.FullPath, true));


        }

        private void OnBreadCrumbValidatePath(object sender, BreadCrumbValidatePathEventArgs e)
        {
            e.ValidationResult = BreadCrumbValidatePathResult.CreateNodes;
        }

        private void OnBreadCrumbRootGlyphClick(object sender, EventArgs e)
        {
            BreadCrumb.Properties.BreadCrumbMode = BreadCrumbMode.Edit;
            BreadCrumb.SelectAll();
        }

        private void UpdateView()
        {
            var oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                gridControl.DataSource = GetGridDataSource();
                winExplorerView.RefreshData();
                EnsureSearchEdit();
                BeginInvoke(new MethodInvoker(winExplorerView.ClearSelection));
            }
            finally
            {
                Cursor.Current = oldCursor;
                BreadCrumb.Path = ActiveItem.FullPath;
            }
        }

        private List<AssetBrowserItem> GetGridDataSource()
        {
            var currentDataSource = gridControl.DataSource as List<AssetBrowserItem>;
            if (ActiveItem == null || !SelectedItem.IsDirectory) return currentDataSource;
            var previousPath = ActiveItem.FullPath;
            ActiveItem = SelectedItem;
            var newDataSource = ActiveItem.Directories.Select(directory =>
                new AssetBrowserItem
                {
                    IsDirectory = true, Name = directory.Name, FullPath = directory.FullPath,
                    Directories = directory.Directories.Values.ToList(),
                    ImageIndex = GetImageIndex(Path.GetExtension(directory.FullPath)),
                    Files = directory.Files.Values.SelectMany(x => x).ToList()
                }).ToList();
            newDataSource.AddRange(ActiveItem.Files.Select(file => new AssetBrowserItem
            {
                FullPath = $"{previousPath}\\{file.Name}",
                Name = file.Name,
                IsDirectory = false,
                Files = null,
                Directories = null,
                ImageIndex = GetImageIndex(Path.GetExtension(file.Name)),
                Size = file.Size.ToString(),
                BundleType = file.Bundle.TypeName,
                CompressionType = file.CompressionType
            }));

            return newDataSource;
        }

        private void EnsureSearchEdit()
        {
            var nullPromptValue = !string.IsNullOrWhiteSpace(ActiveItem?.FullPath)
                ? ActiveItem.FullPath
                : RootItem.FullPath;
            EditSearch.Properties.NullValuePrompt = "Search " + nullPromptValue;
            EditSearch.EditValue = null;
            winExplorerView.FindFilterText = string.Empty;
        }


        private void OnShowCheckBoxesItemClick(object sender, ItemClickEventArgs e)
        {
            winExplorerView.OptionsView.ShowCheckBoxes = ((BarCheckItem) e.Item).Checked;
        }

        private void OnViewStyleGalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            var item = e.Item;
            if (!item.Checked) return;
            var viewStyle = (WinExplorerViewStyle) Enum.Parse(typeof(WinExplorerViewStyle), item.Tag.ToString());
            winExplorerView.OptionsView.Style = viewStyle;
            FileSystemImageCache.Cache.ClearCache();
            UpdateView();
        }

        private void OnRgbiViewStyleInitDropDown(object sender, InplaceGalleryEventArgs e)
        {
            e.PopupGallery.SynchWithInRibbonGallery = true;
        }

        private void OnEditSearchTextChanged(object sender, EventArgs e)
        {
            winExplorerView.FindFilterText = EditSearch.Text;
        }


        private void OnSelectNoneItemClick(object sender, ItemClickEventArgs e)
        {
            winExplorerView.ClearSelection();
        }


        private void OnShowFileNameExtensionsCheckItemClick(object sender, ItemClickEventArgs e)
        {
            //TODO - Needs to be rewritten to work with witcher tree nodes; probably will need to add extension property to tree nodes...
            //var col = gridControl.DataSource as FileSystemEntryCollection;
            //if (col == null) return;
            //col.ShowExtensions = ((BarCheckItem) e.Item).Checked;
            //gridControl.RefreshDataSource();
        }

        private void OnCopyPathItemClick(object sender, ItemClickEventArgs e)
        {
            var builder = new StringBuilder();
            foreach (var entry in GetSelectedEntries()) builder.AppendLine(entry.Name);
            if (!string.IsNullOrEmpty(builder.ToString())) Clipboard.SetText(builder.ToString());
        }

        private void OnOpenItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelectedItem.IsDirectory)
                UpdateView();
        }

        private void OnWinExplorerViewKeyDown(object sender, KeyEventArgs e)
        {
            //TODO - Do nothing for now, not sure if we will be keeping this.
            //if (e.KeyCode != Keys.Enter) return;
            //var entry = GetSelectedEntries().LastOrDefault();
            //entry?.DoAction(this);
        }

        private void OnWinExplorerViewItemClick(object sender, WinExplorerViewItemClickEventArgs e)
        {
            if (e.MouseInfo.Button == MouseButtons.Right) itemPopupMenu.ShowPopup(Cursor.Position);
        }

        private void OnWinExplorerViewItemDoubleClick(object sender, WinExplorerViewItemDoubleClickEventArgs e)
        {
            if (e.MouseInfo.Button != MouseButtons.Left) return;
            if (SelectedItem.IsDirectory)
                UpdateView();
        }

        private void UpdateButtons()
        {
            btnUpTo.Enabled = BreadCrumb.CanGoUp;
            btnBack.Enabled = BreadCrumb.CanGoBack;
            btnForward.Enabled = BreadCrumb.CanGoForward;
            btnOpen.Enabled = SelectedItem != null && SelectedItem.IsDirectory;
        }

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            BreadCrumb.GoBack();
        }

        private void OnNextButtonClick(object sender, EventArgs e)
        {
            BreadCrumb.GoForward();
        }

        private void OnUpButtonClick(object sender, EventArgs e)
        {
            BreadCrumb.GoUp();
        }

        private void OnNavigationMenuButtonClick(object sender, EventArgs e)
        {
            navigationMenu.ItemLinks.Clear();
            navigationMenu.ItemLinks.AddRange(GetNavigationHistoryItems().ToArray());
            navigationMenu.ShowPopup(PointToScreen(new Point(0, navigationPanel.Bottom)));
        }

        private IEnumerable<BarItem> GetNavigationHistoryItems()
        {
            var history = BreadCrumb.GetNavigationHistory();
            for (var i = history.Count - 1; i >= 0; i--)
            {
                var item = history[i];
                var menuItem = new BarCheckItem {Tag = i, Caption = item.Path};
                menuItem.ItemClick += OnNavigationMenuItemClick;
                menuItem.Checked = BreadCrumb.GetNavigationHistoryCurrentItemIndex() == i;
                yield return menuItem;
            }
        }

        private void OnNavigationMenuItemClick(object sender, ItemClickEventArgs e)
        {
            BreadCrumb.SetNavigationHistoryCurrentItemIndex(Convert.ToInt32(e.Item.Tag));
            UpdateButtons();
        }

        private List<AssetBrowserItem> GetSelectedEntries(bool sort = false)
        {
            var list = winExplorerView.GetSelectedRows().Select(t => (AssetBrowserItem) winExplorerView.GetRow(t))
                .ToList();
            return sort ? list.OrderBy(x => x.Name).ToList() : list;
        }

        private void winExplorerView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            if (e.Row == null)
                return;
            SelectedItem = e.Row as AssetBrowserItem;
            if (SelectedItem != null) UpdateButtons();
        }

        private int GetImageIndex(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case SupportedFileType.Csv:
                    return 3;
                case SupportedFileType.RedSwf:
                    return 4;
                case SupportedFileType.Env:
                    return 5;
                case SupportedFileType.Journal:
                    return 6;
                case SupportedFileType.Beh:
                    return 7;
                case SupportedFileType.Xml:
                    return 8;
                case SupportedFileType.BehTree:
                    return 9;
                case SupportedFileType.W2Scene:
                    return 10;
                case SupportedFileType.W2P:
                    return 11;
                case SupportedFileType.Rig:
                    return 12;
                case SupportedFileType.WitcherScript:
                    return 13;
                case SupportedFileType.Ent:
                    return 14;
                default:
                    return 0;
            }
        }
    }
}