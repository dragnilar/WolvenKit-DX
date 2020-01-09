using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using WolvenKit.Interfaces;
using WolvenKit.Models;

namespace WolvenKit.Views
{
    public partial class AssetExplorer : XtraForm
    {
        private string _currentPath;
        public List<IWitcherArchive> Archives;
        public List<AssetBrowserItem> AvailableDirectories = new List<AssetBrowserItem>();
        public List<AssetBrowserItem> AvailableFiles = new List<AssetBrowserItem>();
        public BindingList<AssetBrowserItem> ExplorerDataSource = new BindingList<AssetBrowserItem>();
        public BindingList<AssetBrowserItem> MarkedFiles = new BindingList<AssetBrowserItem>();

        public AssetExplorer(List<IWitcherArchive> witcherArchives)
        {
            InitializeComponent();
            SetImageCollections();
            if (Process.GetCurrentProcess().ProcessName == "devenv") return;
            if (witcherArchives != null)
            {
                Archives = witcherArchives;
                CreateRootFileList();
                AvailableDirectories = GetRootItemDirectories().ToList();
                GetFilesFromArchives(witcherArchives);
                ExplorerDataSource = GetGridDataSource();
                gridControlAssetExplorer.DataSource = ExplorerDataSource;
            }
            gridControlMarkedFiles.DataSource = MarkedFiles;
            FileSystemImageCache.Cache.EnableFileIconCaching = false;
            Load += OnLoad;
        }

        private void GetFilesFromArchives(List<IWitcherArchive> witcherArchives)
        {
            foreach (var archive in witcherArchives)
            {
                archive.FileList.ForEach(x =>
                {
                    AvailableFiles.Add(new AssetBrowserItem(Path.GetFileName(x.Name),
                        x.Name, x.Size.ToString(), x.CompressionType, x.Bundle.TypeName,
                        GetImageIndex(Path.GetExtension(x.Name)), x));
                });
            }
        }

        public AssetBrowserItem SelectedItem { get; set; }
        public AssetBrowserItem RootItem { get; set; }
        public BreadCrumbEdit BreadCrumb => BreadCrumbControlAssetExplorer;

        private void SetImageCollections()
        {
            winExplorerView.ExtraLargeImages = svgImageCollectionLargeAssetBrowser;
            winExplorerView.Images = svgImageCollectionAssetBrowser;
            winExplorerView.LargeImages = svgImageCollectionLargeAssetBrowser;
            winExplorerView.MediumImages = svgImageCollectionAssetBrowser;
            winExplorerView.SmallImages = svgImageCollectionAssetBrowser;
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
                rootNode.Directories[archive.RootNode.Name] = archive.RootNode;
                archive.RootNode.Parent = rootNode;
            }

            RootItem = new AssetBrowserItem(rootNode.Name, rootNode.FullPath,
                rootNode.Files.Values.SelectMany(x => x).ToList(), rootNode.Directories.Values.ToList(), 1);
        }


        /// <summary>
        /// Uses a stack to flatten the tree embedded in the root to get all of the directories within the tree.
        ///Based off of Eric Lippert's idea for using a stack to squash the tree:
        ///https://stackoverflow.com/questions/11830174/how-to-flatten-tree-via-linq
        /// </summary>
        /// <returns>An IEnumerable of Asset Browser items that can be converted to a list or anything else you wish to run
        /// LINQ queries on to find stuff within the directory structure of all the Witcher 3 packed files.</returns>
        private IEnumerable<AssetBrowserItem> GetRootItemDirectories()
        {
            var stack = new Stack<AssetBrowserItem>();
            stack.Push(RootItem);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;
                foreach (var currentDirectory in current.Directories)
                {
                    stack.Push(new AssetBrowserItem(currentDirectory.Name, currentDirectory.FullPath, currentDirectory.Files.Values.SelectMany(x=>x).ToList(), currentDirectory.Directories.Values.ToList(),
                        1));
                }
            }
        }

        private void InitializeBreadCrumb()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            _currentPath = RootItem.FullPath;
            BreadCrumb.Path = _currentPath;
            BreadCrumb.Properties.History.Add(new BreadCrumbHistoryItem(BreadCrumb.Path));
        }

        private void InitializeAppearance()
        {
            var item = rgbiViewStyle.Gallery.GetCheckedItem();
            if (item != null)
                winExplorerView.OptionsView.Style = (WinExplorerViewStyle) item.Tag;
        }

        private void OnBreadCrumbPathChanged(object sender, BreadCrumbPathChangedEventArgs e)
        {
            _currentPath = e.Path;
            UpdateView();
            UpdateButtons();
        }

        private void OnBreadCrumbNewNodeAdding(object sender, BreadCrumbNewNodeAddingEventArgs e)
        {
            e.Node.PopulateOnDemand = true;
        }

        private void OnBreadCrumbQueryChildNodes(object sender, BreadCrumbQueryChildNodesEventArgs e)
        {
            if (e.Node.Caption == "Root")
            {
                e.Node.ChildNodes.Add(new BreadCrumbNode
                    {Caption = RootItem.Name, Value = RootItem.FullPath, PopulateOnDemand = true});
                return;
            }

            if (SelectedItem?.Directories == null) return;
            foreach (var directory in SelectedItem.Directories)
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
                ExplorerDataSource = !string.IsNullOrWhiteSpace(_currentPath) ? GetGridDataSource() : null;
                gridControlAssetExplorer.DataSource = ExplorerDataSource;
                winExplorerView.RefreshData();
                EnsureSearchEdit();
                BeginInvoke(new MethodInvoker(winExplorerView.ClearSelection));
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private BindingList<AssetBrowserItem> GetGridDataSource()
        {
            var activeItem = AvailableDirectories.FirstOrDefault(x => x.FullPath == _currentPath) ?? RootItem;
            List<AssetBrowserItem> newDataSource = new List<AssetBrowserItem>();
            foreach (var directory in activeItem.Directories)
                newDataSource.AddRange(AvailableDirectories.Where(x => x.FullPath == directory.FullPath));
            newDataSource.AddRange(AvailableFiles.Where(x=>x.DirectoryPath == activeItem.FullPath));
            return new BindingList<AssetBrowserItem>(newDataSource);
        }

        private void EnsureSearchEdit()
        {
            var nullPromptValue = !string.IsNullOrWhiteSpace(_currentPath)
                ? _currentPath
                : RootItem.FullPath;
            EditSearch.Properties.NullValuePrompt = "Search All Files...";
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
            winExplorerView.OptionsView.Style = (WinExplorerViewStyle) Enum.Parse(typeof(WinExplorerViewStyle), item.Tag.ToString());
            FileSystemImageCache.Cache.ClearCache();
            UpdateView();
        }

        private void OnRgbiViewStyleInitDropDown(object sender, InplaceGalleryEventArgs e)
        {
            e.PopupGallery.SynchWithInRibbonGallery = true;
        }

        private void OnEditSearchTextChanged(object sender, EventArgs e)
        {
            var searchString = EditSearch.EditValue?.ToString();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                ExplorerDataSource =
                    new BindingList<AssetBrowserItem>(AvailableFiles.Where(x => x.Name.Contains(searchString))
                        .ToList());
                gridControlAssetExplorer.DataSource = ExplorerDataSource;
                winExplorerView.RefreshData();
                BeginInvoke(new MethodInvoker(winExplorerView.ClearSelection));
            }
            else
            {
                UpdateView();
            }
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
                BreadCrumb.Path = SelectedItem.FullPath;
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
            {
                BreadCrumb.Path = SelectedItem.FullPath;
            }
            else if (!SelectedItem.IsDirectory)
            {
                var isChecked = !SelectedItem.IsChecked;
                winExplorerView.SetFocusedRowCellValue(gridColumnIsChecked, isChecked);
            }
        }

        private void UpdateButtons()
        {
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
            _currentPath = e.Item.Caption;
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

        private void barButtonItemAddMarkedToMod_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItemAddMarkedToDLC_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItemClearMarks_ItemClick(object sender, ItemClickEventArgs e)
        {
            MarkedFiles.Clear();
        }

        private void barButtonItemUnmarkSelected_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ExplorerDataSource == null) return;
            foreach (var item in ExplorerDataSource.Where(item => item.IsChecked))
            {
                if (MarkedFiles.Contains(item))
                {
                    MarkedFiles.Remove(item);
                }
            }
        }

        private void barButtonItemMarkSelected_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ExplorerDataSource == null) return;
            foreach (var item in ExplorerDataSource.Where(item => item.IsChecked))
            {
                MarkedFiles.Add(item);
            }
        }
    }
}