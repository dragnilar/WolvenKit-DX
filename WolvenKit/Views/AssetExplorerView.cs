using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
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
    public partial class AssetExplorerView : XtraForm
    {
        private static readonly HashSet<char> _invalidCharacters = new HashSet<char>(Path.GetInvalidPathChars());
        private string _currentPath;
        private List<IWitcherArchive> Archives;
        private List<AssetExplorerItem> AvailableDirectories = new List<AssetExplorerItem>();
        private List<AssetExplorerItem> AvailableFiles = new List<AssetExplorerItem>();
        private BindingList<AssetExplorerItem> ExplorerDataSource = new BindingList<AssetExplorerItem>();
        private BindingList<AssetExplorerItem> MarkedFiles = new BindingList<AssetExplorerItem>();
        private AssetExplorerItem SelectedItem { get; set; }
        private AssetExplorerItem RootItem { get; set; }
        private BreadCrumbEdit BreadCrumb => BreadCrumbControlAssetExplorer;
        public event EventHandler<Tuple<List<IWitcherArchive>, List<AssetExplorerItem>, bool>> RequestFileAdd;

        public AssetExplorerView(List<IWitcherArchive> witcherArchives)
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

        public void OpenPath(string pathToNavigate)
        {
            BreadCrumb.Path = pathToNavigate;
        }


        private void GetFilesFromArchives(List<IWitcherArchive> witcherArchives)
        {
            foreach (var archive in witcherArchives)
                if (archive.TypeName == "SoundCache")
                    archive.Items.ForEach(x =>
                    {
                        if (!x.Key.Any(y => _invalidCharacters.Contains(y)))
                            AvailableFiles.Add(new AssetExplorerItem(x.Key,
                                Path.Combine(archive.RootNode.FullPath, x.Key), x.Value.First().ToString(),
                                x.Value.First().CompressionType, x.Value.First().Bundle.TypeName,
                                GetImageIndex(Path.GetExtension(x.Key)), x.Value.First()));
                    });
                else
                    archive.Items.ForEach(x =>
                    {
                        if (!x.Key.Any(y => _invalidCharacters.Contains(y)))
                            AvailableFiles.Add(new AssetExplorerItem(Path.GetFileName(x.Key),
                                x.Key, x.Value.First().ToString(), x.Value.First().CompressionType,
                                x.Value.First().Bundle.TypeName,
                                GetImageIndex(Path.GetExtension(x.Key)), x.Value.First()));
                    });
        }

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

            RootItem = new AssetExplorerItem(rootNode.Name, rootNode.FullPath,
                rootNode.Files.Values.SelectMany(x => x).ToList(), rootNode.Directories.Values.ToList(), 1);
        }


        /// <summary>
        ///     Uses a stack to flatten the tree embedded in the root to get all of the directories within the tree.
        ///     Based off of Eric Lippert's idea for using a stack to squash the tree:
        ///     https://stackoverflow.com/questions/11830174/how-to-flatten-tree-via-linq
        /// </summary>
        /// <returns>
        ///     An IEnumerable of Asset Browser items that can be converted to a list or anything else you wish to run
        ///     LINQ queries on to find stuff within the directory structure of all the Witcher 3 packed files.
        /// </returns>
        private IEnumerable<AssetExplorerItem> GetRootItemDirectories()
        {
            var stack = new Stack<AssetExplorerItem>();
            stack.Push(RootItem);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;
                foreach (var currentDirectory in current.Directories)
                    stack.Push(new AssetExplorerItem(currentDirectory.Name, currentDirectory.FullPath,
                        currentDirectory.Files.Values.SelectMany(x => x).ToList(),
                        currentDirectory.Directories.Values.ToList(),
                        1));
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

        private BindingList<AssetExplorerItem> GetGridDataSource()
        {
            var activeItem = AvailableDirectories.FirstOrDefault(x => x.FullPath == _currentPath) ?? RootItem;
            var newDataSource = new List<AssetExplorerItem>();
            foreach (var directory in activeItem.Directories)
                newDataSource.AddRange(AvailableDirectories.Where(x => x.FullPath == directory.FullPath));
            newDataSource.AddRange(AvailableFiles.Where(x => x.DirectoryPath == activeItem.FullPath));
            return new BindingList<AssetExplorerItem>(newDataSource);
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

        private void OnViewStyleGalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            var item = e.Item;
            if (!item.Checked) return;
            winExplorerView.OptionsView.Style =
                (WinExplorerViewStyle) Enum.Parse(typeof(WinExplorerViewStyle), item.Tag.ToString());
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
                    new BindingList<AssetExplorerItem>(AvailableFiles.Where(x => x.Name.Contains(searchString))
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
            for (var i = 0; i <= winExplorerView.RowCount; i++)
                winExplorerView.SetRowCellValue(i, gridColumnIsChecked, false);
        }

        private void barButtonItemSelectAll_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            winExplorerView.ClearSelection();
            for (var i = 0; i <= winExplorerView.RowCount; i++)
                winExplorerView.SetRowCellValue(i, gridColumnIsChecked, true);
        }


        private void OnOpenItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelectedItem.IsDirectory)
                BreadCrumb.Path = SelectedItem.FullPath;
        }

        private void OnWinExplorerViewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MarkOrOpenSelectedItem();
            }
        }

        private void OnWinExplorerViewItemClick(object sender, WinExplorerViewItemClickEventArgs e)
        {
            if (e.MouseInfo.Button == MouseButtons.Right) itemPopupMenu.ShowPopup(Cursor.Position);
        }

        private void OnWinExplorerViewItemDoubleClick(object sender, WinExplorerViewItemDoubleClickEventArgs e)
        {
            if (e.MouseInfo.Button != MouseButtons.Left) return;
            MarkOrOpenSelectedItem();
        }

        private void MarkOrOpenSelectedItem()
        {
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

        private void winExplorerView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            if (e.Row == null)
                return;
            SelectedItem = e.Row as AssetExplorerItem;
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
            if (MarkedFiles.Count > 0)
            {
                RequestFileAdd?.Invoke(this,
                    new Tuple<List<IWitcherArchive>, List<AssetExplorerItem>, bool>(Archives, MarkedFiles.ToList(),
                        false));
                MarkedFiles.Clear();
            }
        }

        private void barButtonItemAddMarkedToDLC_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MarkedFiles.Count > 0)
            {
                RequestFileAdd?.Invoke(this,
                    new Tuple<List<IWitcherArchive>, List<AssetExplorerItem>, bool>(Archives, MarkedFiles.ToList(),
                        true));
                MarkedFiles.Clear();
            }
        }

        private void barButtonItemClearMarks_ItemClick(object sender, ItemClickEventArgs e)
        {
            MarkedFiles.Clear();
        }

        private void barButtonItemUnMarkSelected_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ExplorerDataSource == null) return;
            foreach (var item in ExplorerDataSource.Where(item => item.IsChecked))
                if (MarkedFiles.Contains(item))
                    MarkedFiles.Remove(item);
        }

        private void barButtonItemMarkSelected_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ExplorerDataSource == null) return;
            foreach (var item in ExplorerDataSource.Where(item => item.IsChecked)) MarkedFiles.Add(item);
        }
    }
}