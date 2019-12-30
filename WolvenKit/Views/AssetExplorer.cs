using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.WinExplorer;
using WolvenKit.Common;

namespace WolvenKit.Views
{
    public partial class AssetExplorer : XtraForm, IFileSystemNavigationSupports
    {
        private string _currentPath;

        public List<IWitcherArchive> Archives;
        public List<IWitcherFile> WitcherFiles = new List<IWitcherFile>();
        public WitcherTreeNode ActiveNode { get; set; }
        public WitcherTreeNode RootNode { get; set; }


        public AssetExplorer(List<IWitcherArchive> witcherArchives = null)
        {
            InitializeComponent();
            if (witcherArchives != null)
            {
                Archives = witcherArchives;
                CreateFileList();
            }
            FileSystemImageCache.Cache.EnableFileIconCaching = false;
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Load += OnLoad;
            }

        }



        public AssetExplorer()
        {
            InitializeComponent();
        }

        protected string StartupPath => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public BreadCrumbEdit BreadCrumb => editBreadCrumb;
        public WinExplorerViewStyle ViewStyle => winExplorerView.OptionsView.Style;
        
        private void OnLoad(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeBreadCrumb();
            InitializeAppearance();
            UpdateView();
        }

        private void CreateFileList()
        {
            foreach (var archive in Archives)
            {
                WitcherFiles.AddRange(archive.FileList);
                //RootNode.Directories[archive.RootNode.Name] = archive.RootNode;
                //archive.RootNode.Parent = RootNode;
            }
            
        }

        private void InitializeBreadCrumb()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            _currentPath = StartupPath;
            BreadCrumb.Path = _currentPath;
            foreach (var archive in Archives)
                BreadCrumb.Properties.History.Add(new BreadCrumbHistoryItem(archive.RootNode.FullPath));
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
                InitBreadCrumbRootNode(e.Node);
                return;
            }

            if (e.Node.Caption == "Computer")
            {
                InitBreadCrumbComputerNode(e.Node);
                return;
            }

            var dir = e.Node.Path;
            if (!FileSystemHelper.IsDirExists(dir))
                return;
            var subDirs = FileSystemHelper.GetSubFolders(dir);
            for (var i = 0; i < subDirs.Length; i++) e.Node.ChildNodes.Add(CreateNode(subDirs[i]));
        }

        private void InitBreadCrumbRootNode(BreadCrumbNode node)
        {
            node.ChildNodes.Add(new BreadCrumbNode("Desktop",
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            node.ChildNodes.Add(new BreadCrumbNode("Documents",
                Environment.GetFolderPath(Environment.SpecialFolder.Recent)));
            node.ChildNodes.Add(new BreadCrumbNode("Music",
                Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)));
            node.ChildNodes.Add(new BreadCrumbNode("Pictures",
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)));
            node.ChildNodes.Add(new BreadCrumbNode("Video",
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)));
            node.ChildNodes.Add(new BreadCrumbNode("Program Files",
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)));
            node.ChildNodes.Add(new BreadCrumbNode("Windows",
                Environment.GetFolderPath(Environment.SpecialFolder.Windows)));
        }

        private void InitBreadCrumbComputerNode(BreadCrumbNode node)
        {
            foreach (var driveInfo in FileSystemHelper.GetFixedDrives())
                node.ChildNodes.Add(new BreadCrumbNode(driveInfo.Name, driveInfo.RootDirectory));
        }

        private void OnBreadCrumbValidatePath(object sender, BreadCrumbValidatePathEventArgs e)
        {
            if (!FileSystemHelper.IsDirExists(e.Path))
            {
                e.ValidationResult = BreadCrumbValidatePathResult.Cancel;
                return;
            }

            e.ValidationResult = BreadCrumbValidatePathResult.CreateNodes;
        }

        private void OnBreadCrumbRootGlyphClick(object sender, EventArgs e)
        {
            BreadCrumb.Properties.BreadCrumbMode = BreadCrumbMode.Edit;
            BreadCrumb.SelectAll();
        }

        private BreadCrumbNode CreateNode(string path)
        {
            var folderName = FileSystemHelper.GetDirName(path);
            return new BreadCrumbNode(folderName, folderName, true);
        }

        private void UpdateView()
        {
            var oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (!string.IsNullOrEmpty(_currentPath))
                    gridControl.DataSource = WitcherFiles;
                else
                    gridControl.DataSource = null;
                winExplorerView.RefreshData();
                EnsureSearchEdit();
                BeginInvoke(new MethodInvoker(winExplorerView.ClearSelection));
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private void EnsureSearchEdit()
        {
            EditSearch.Properties.NullValuePrompt = "Search " + FileSystemHelper.GetDirName(_currentPath);
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

        private void OnSelectAllItemClick(object sender, ItemClickEventArgs e)
        {
            winExplorerView.SelectAll();
        }

        private void OnSelectNoneItemClick(object sender, ItemClickEventArgs e)
        {
            winExplorerView.ClearSelection();
        }

        private void OnInvertSelectionItemClick(object sender, ItemClickEventArgs e)
        {
            for (var i = 0; i < winExplorerView.RowCount; i++) winExplorerView.InvertRowSelection(i);
        }

        private void OnShowFileNameExtensionsCheckItemClick(object sender, ItemClickEventArgs e)
        {
            var col = gridControl.DataSource as FileSystemEntryCollection;
            if (col == null) return;
            col.ShowExtensions = ((BarCheckItem) e.Item).Checked;
            gridControl.RefreshDataSource();
        }

        private void OnShowHiddenItemsCheckItemClick(object sender, ItemClickEventArgs e)
        {
            btnHideSelectedItems.Enabled = !((BarCheckItem) e.Item).Checked;
        }

        private void OnHelpButtonItemClick(object sender, ItemClickEventArgs e)
        {
            // StartApplicationHelper.ShowHelp();
        }

        private void OnOptionsItemClick(object sender, ItemClickEventArgs e)
        {
            IEnumerable<FileSystemEntry> entries = GetSelectedEntries();
            if (!entries.Any())
            {
                FileSystemHelper.ShellExecuteFileInfo(_currentPath, ShellExecuteInfoFileType.Properties);
                return;
            }

            foreach (var entry in entries) entry.ShowProperties();
        }

        private void OnWinExplorerViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtons();
        }

        private void OnCopyPathItemClick(object sender, ItemClickEventArgs e)
        {
            var builder = new StringBuilder();
            foreach (var entry in GetSelectedEntries()) builder.AppendLine(entry.Path);
            if (!string.IsNullOrEmpty(builder.ToString())) Clipboard.SetText(builder.ToString());
        }

        private void OnOpenItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var entry in GetSelectedEntries(true)) entry.DoAction(this);
        }

        private void OnWinExplorerViewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var entry = GetSelectedEntries().LastOrDefault();
            entry?.DoAction(this);
        }

        private void OnWinExplorerViewItemClick(object sender, WinExplorerViewItemClickEventArgs e)
        {
            if (e.MouseInfo.Button == MouseButtons.Right) itemPopupMenu.ShowPopup(Cursor.Position);
        }

        private void OnWinExplorerViewItemDoubleClick(object sender, WinExplorerViewItemDoubleClickEventArgs e)
        {
            if (e.MouseInfo.Button != MouseButtons.Left) return;
            winExplorerView.ClearSelection();
            ((FileSystemEntry) e.ItemInfo.Row.RowKey).DoAction(this);
        }

        private void UpdateButtons()
        {
            var selEntriesCount = GetSelectedEntries().Count();
            btnOpen.Enabled = btnCopyItem.Enabled = selEntriesCount > 0;
            btnUpTo.Enabled = BreadCrumb.CanGoUp;
            btnBack.Enabled = BreadCrumb.CanGoBack;
            btnForward.Enabled = BreadCrumb.CanGoForward;
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
            navigationMenu.ItemLinks.AddRange(GetNavigationHistroryItems().ToArray());
            navigationMenu.ShowPopup(PointToScreen(new Point(0, navigationPanel.Bottom)));
        }

        private IEnumerable<BarItem> GetNavigationHistroryItems()
        {
            var history = BreadCrumb.GetNavigationHistory();
            for (var i = history.Count - 1; i >= 0; i--)
            {
                var item = history[i];
                var menuItem = new BarCheckItem();
                menuItem.Tag = i;
                menuItem.Caption = FileSystemHelper.GetDirName(item.Path);
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

        private List<FileSystemEntry> GetSelectedEntries()
        {
            return GetSelectedEntries(false);
        }

        private List<FileSystemEntry> GetSelectedEntries(bool sort)
        {
            var list = new List<FileSystemEntry>();
            var rows = winExplorerView.GetSelectedRows();
            for (var i = 0; i < rows.Length; i++) list.Add((FileSystemEntry) winExplorerView.GetRow(rows[i]));
            if (sort) list.Sort(new FileSytemEntryComparer());
            return list;
        }

        private Size GetItemSize(WinExplorerViewStyle viewStyle)
        {
            switch (viewStyle)
            {
                case WinExplorerViewStyle.ExtraLarge: return new Size(256, 256);
                case WinExplorerViewStyle.Large: return new Size(96, 96);
                case WinExplorerViewStyle.Content: return new Size(32, 32);
                case WinExplorerViewStyle.Small: return new Size(16, 16);
                default: return new Size(96, 96);
            }
        }

        private IconSizeType GetItemSizeType(WinExplorerViewStyle viewStyle)
        {
            switch (viewStyle)
            {
                case WinExplorerViewStyle.Large:
                case WinExplorerViewStyle.ExtraLarge: return IconSizeType.ExtraLarge;
                case WinExplorerViewStyle.List:
                case WinExplorerViewStyle.Small: return IconSizeType.Small;
                case WinExplorerViewStyle.Tiles:
                case WinExplorerViewStyle.Medium:
                case WinExplorerViewStyle.Content: return IconSizeType.Large;
                default: return IconSizeType.ExtraLarge;
            }
        }

        #region IFileSystemNavigationSupports

        string IFileSystemNavigationSupports.CurrentPath => _currentPath;

        void IFileSystemNavigationSupports.UpdatePath(string path)
        {
            BreadCrumb.Path = path;
        }

        #endregion
    }
}