using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace WolvenKit
{
    partial class ModExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModExplorer));
            this.treeListModFiles = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnFullName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnFileType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.barManagerModExplorer = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItemAddFile = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRename = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCopy = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPaste = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCopyPath = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMarkAs = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemShowInExplorer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExpandAll = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCollapseAll = new DevExpress.XtraBars.BarButtonItem();
            this.svgImageCollectionModExplorer = new DevExpress.Utils.SvgImageCollection(this.components);
            this.fileWatcherModExplorer = new System.IO.FileSystemWatcher();
            this.popupMenuModExplorer = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeListModFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerModExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollectionModExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcherModExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuModExplorer)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListModFiles
            // 
            this.treeListModFiles.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnFullName,
            this.treeListColumnDisplayName,
            this.treeListColumnFileType});
            this.treeListModFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListModFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListModFiles.Location = new System.Drawing.Point(0, 0);
            this.treeListModFiles.Margin = new System.Windows.Forms.Padding(2);
            this.treeListModFiles.MenuManager = this.barManagerModExplorer;
            this.treeListModFiles.Name = "treeListModFiles";
            this.treeListModFiles.OptionsBehavior.AllowExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.treeListModFiles.OptionsBehavior.Editable = false;
            this.treeListModFiles.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.treeListModFiles.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraTreeList.ColumnFilterPopupMode.Excel;
            this.treeListModFiles.OptionsFind.AlwaysVisible = true;
            this.treeListModFiles.OptionsMenu.ShowConditionalFormattingItem = true;
            this.treeListModFiles.OptionsMenu.ShowFooterItem = true;
            this.treeListModFiles.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            this.treeListModFiles.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways;
            this.treeListModFiles.OptionsView.ShowIndicator = false;
            this.treeListModFiles.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeListModFiles.Size = new System.Drawing.Size(363, 445);
            this.treeListModFiles.StateImageList = this.svgImageCollectionModExplorer;
            this.treeListModFiles.TabIndex = 0;
            this.treeListModFiles.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.modFileList_BeforeExpand);
            this.treeListModFiles.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.modFileList_AfterExpand);
            this.treeListModFiles.AfterCollapse += new DevExpress.XtraTreeList.NodeEventHandler(this.modFileList_AfterCollapse);
            this.treeListModFiles.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.treeListModFiles_PopupMenuShowing);
            this.treeListModFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.modFileList_KeyDown);
            this.treeListModFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.modFileList_MouseDown);
            // 
            // treeListColumnFullName
            // 
            this.treeListColumnFullName.Caption = "FullName";
            this.treeListColumnFullName.FieldName = "FullName";
            this.treeListColumnFullName.Name = "treeListColumnFullName";
            // 
            // treeListColumnDisplayName
            // 
            this.treeListColumnDisplayName.Caption = "File Name";
            this.treeListColumnDisplayName.FieldName = "FileName";
            this.treeListColumnDisplayName.Name = "treeListColumnDisplayName";
            this.treeListColumnDisplayName.Visible = true;
            this.treeListColumnDisplayName.VisibleIndex = 0;
            this.treeListColumnDisplayName.Width = 282;
            // 
            // treeListColumnFileType
            // 
            this.treeListColumnFileType.Caption = "Type";
            this.treeListColumnFileType.FieldName = "FileTYpe";
            this.treeListColumnFileType.Name = "treeListColumnFileType";
            this.treeListColumnFileType.Visible = true;
            this.treeListColumnFileType.VisibleIndex = 1;
            this.treeListColumnFileType.Width = 54;
            // 
            // barManagerModExplorer
            // 
            this.barManagerModExplorer.DockControls.Add(this.barDockControlTop);
            this.barManagerModExplorer.DockControls.Add(this.barDockControlBottom);
            this.barManagerModExplorer.DockControls.Add(this.barDockControlLeft);
            this.barManagerModExplorer.DockControls.Add(this.barDockControlRight);
            this.barManagerModExplorer.Form = this;
            this.barManagerModExplorer.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemAddFile,
            this.barButtonItemDelete,
            this.barButtonItemRename,
            this.barButtonItemCopy,
            this.barButtonItemPaste,
            this.barButtonItemCopyPath,
            this.barButtonItemMarkAs,
            this.barButtonItemShowInExplorer,
            this.barButtonItemExpandAll,
            this.barButtonItemCollapseAll});
            this.barManagerModExplorer.MaxItemId = 10;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManagerModExplorer;
            this.barDockControlTop.Size = new System.Drawing.Size(363, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 445);
            this.barDockControlBottom.Manager = this.barManagerModExplorer;
            this.barDockControlBottom.Size = new System.Drawing.Size(363, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManagerModExplorer;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 445);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(363, 0);
            this.barDockControlRight.Manager = this.barManagerModExplorer;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 445);
            // 
            // barButtonItemAddFile
            // 
            this.barButtonItemAddFile.Caption = "Add File";
            this.barButtonItemAddFile.Id = 0;
            this.barButtonItemAddFile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemAddFile.ImageOptions.SvgImage")));
            this.barButtonItemAddFile.Name = "barButtonItemAddFile";
            this.barButtonItemAddFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAddFile_ItemClick);
            // 
            // barButtonItemDelete
            // 
            this.barButtonItemDelete.Caption = "Delete";
            this.barButtonItemDelete.Id = 1;
            this.barButtonItemDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemDelete.ImageOptions.SvgImage")));
            this.barButtonItemDelete.Name = "barButtonItemDelete";
            this.barButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDelete_ItemClick);
            // 
            // barButtonItemRename
            // 
            this.barButtonItemRename.Caption = "Rename";
            this.barButtonItemRename.Id = 2;
            this.barButtonItemRename.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemRename.ImageOptions.SvgImage")));
            this.barButtonItemRename.Name = "barButtonItemRename";
            this.barButtonItemRename.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemRename_ItemClick);
            // 
            // barButtonItemCopy
            // 
            this.barButtonItemCopy.Caption = "Copy";
            this.barButtonItemCopy.Id = 3;
            this.barButtonItemCopy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemCopy.ImageOptions.SvgImage")));
            this.barButtonItemCopy.Name = "barButtonItemCopy";
            this.barButtonItemCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCopy_ItemClick);
            // 
            // barButtonItemPaste
            // 
            this.barButtonItemPaste.Caption = "Paste";
            this.barButtonItemPaste.Id = 4;
            this.barButtonItemPaste.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemPaste.ImageOptions.SvgImage")));
            this.barButtonItemPaste.Name = "barButtonItemPaste";
            this.barButtonItemPaste.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemPaste_ItemClick);
            // 
            // barButtonItemCopyPath
            // 
            this.barButtonItemCopyPath.Caption = "Copy Path";
            this.barButtonItemCopyPath.Id = 5;
            this.barButtonItemCopyPath.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemCopyPath.ImageOptions.SvgImage")));
            this.barButtonItemCopyPath.Name = "barButtonItemCopyPath";
            this.barButtonItemCopyPath.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCopyPath_ItemClick);
            // 
            // barButtonItemMarkAs
            // 
            this.barButtonItemMarkAs.Caption = "Mark as Mod / DLC File";
            this.barButtonItemMarkAs.Id = 6;
            this.barButtonItemMarkAs.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemMarkAs.ImageOptions.SvgImage")));
            this.barButtonItemMarkAs.Name = "barButtonItemMarkAs";
            this.barButtonItemMarkAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemMarkAs_ItemClick);
            // 
            // barButtonItemShowInExplorer
            // 
            this.barButtonItemShowInExplorer.Caption = "Show In Windows File Explorer";
            this.barButtonItemShowInExplorer.Id = 7;
            this.barButtonItemShowInExplorer.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemShowInExplorer.ImageOptions.SvgImage")));
            this.barButtonItemShowInExplorer.Name = "barButtonItemShowInExplorer";
            this.barButtonItemShowInExplorer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemShowInExplorer_ItemClick);
            // 
            // barButtonItemExpandAll
            // 
            this.barButtonItemExpandAll.Caption = "Expand All";
            this.barButtonItemExpandAll.Id = 8;
            this.barButtonItemExpandAll.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemExpandAll.ImageOptions.SvgImage")));
            this.barButtonItemExpandAll.Name = "barButtonItemExpandAll";
            this.barButtonItemExpandAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExpandAll_ItemClick);
            // 
            // barButtonItemCollapseAll
            // 
            this.barButtonItemCollapseAll.Caption = "Collapse All";
            this.barButtonItemCollapseAll.Id = 9;
            this.barButtonItemCollapseAll.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemCollapseAll.ImageOptions.SvgImage")));
            this.barButtonItemCollapseAll.Name = "barButtonItemCollapseAll";
            this.barButtonItemCollapseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCollapseAll_ItemClick);
            // 
            // svgImageCollectionModExplorer
            // 
            this.svgImageCollectionModExplorer.Add("genericFile", "image://svgimages/richedit/insertimage.svg");
            this.svgImageCollectionModExplorer.Add("normalFolder", "image://svgimages/icon builder/actions_folderclose.svg");
            this.svgImageCollectionModExplorer.Add("openFolder", "image://svgimages/actions/open.svg");
            this.svgImageCollectionModExplorer.Add("csv", "image://svgimages/export/exporttocsv.svg");
            this.svgImageCollectionModExplorer.Add("redswf", "image://svgimages/dashboards/sliceanddice.svg");
            this.svgImageCollectionModExplorer.Add("env", "image://svgimages/icon builder/business_world.svg");
            this.svgImageCollectionModExplorer.Add("journal", "image://svgimages/spreadsheet/text.svg");
            this.svgImageCollectionModExplorer.Add("w2beh", "image://svgimages/business objects/bo_employee.svg");
            this.svgImageCollectionModExplorer.Add("xml", "image://svgimages/export/exporttoxml.svg");
            this.svgImageCollectionModExplorer.Add("w2behtree", "image://svgimages/icon builder/travel_forest.svg");
            this.svgImageCollectionModExplorer.Add("w2scene", "image://svgimages/business objects/bo_organization.svg");
            this.svgImageCollectionModExplorer.Add("w2p", "image://svgimages/icon builder/travel_walk.svg");
            this.svgImageCollectionModExplorer.Add("w2rig", "image://svgimages/spreadsheet/chartdatalabels_right.svg");
            // 
            // fileWatcherModExplorer
            // 
            this.fileWatcherModExplorer.EnableRaisingEvents = true;
            this.fileWatcherModExplorer.IncludeSubdirectories = true;
            this.fileWatcherModExplorer.SynchronizingObject = this;
            this.fileWatcherModExplorer.Created += new System.IO.FileSystemEventHandler(this.FileChanges_Detected);
            this.fileWatcherModExplorer.Deleted += new System.IO.FileSystemEventHandler(this.FileChanges_Detected);
            this.fileWatcherModExplorer.Renamed += new System.IO.RenamedEventHandler(this.FileChanges_Detected);
            // 
            // popupMenuModExplorer
            // 
            this.popupMenuModExplorer.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExpandAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCollapseAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemAddFile, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemRename),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemPaste),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCopyPath),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemMarkAs),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemShowInExplorer, true)});
            this.popupMenuModExplorer.Manager = this.barManagerModExplorer;
            this.popupMenuModExplorer.Name = "popupMenuModExplorer";
            // 
            // ModExplorer
            // 
            this.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListModFiles);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModExplorer";
            this.Size = new System.Drawing.Size(363, 445);
            this.Load += new System.EventHandler(this.frmModExplorer_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.treeListModFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerModExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollectionModExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcherModExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuModExplorer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FileSystemWatcher fileWatcherModExplorer;
        private DevExpress.XtraTreeList.TreeList treeListModFiles;
        private DevExpress.Utils.SvgImageCollection svgImageCollectionModExplorer;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnDisplayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnFileType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnFullName;
        private DevExpress.XtraBars.PopupMenu popupMenuModExplorer;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManagerModExplorer;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddFile;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRename;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCopy;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPaste;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCopyPath;
        private DevExpress.XtraBars.BarButtonItem barButtonItemMarkAs;
        private DevExpress.XtraBars.BarButtonItem barButtonItemShowInExplorer;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExpandAll;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCollapseAll;
    }
}