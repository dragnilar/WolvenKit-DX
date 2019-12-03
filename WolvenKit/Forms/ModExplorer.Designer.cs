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
            this.treeListModFiles = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnFullName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnFileType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.svgImageCollectionModExplorer = new DevExpress.Utils.SvgImageCollection(this.components);
            this.fileWatcherModExplorer = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.treeListModFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollectionModExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcherModExplorer)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListModFiles
            // 
            this.treeListModFiles.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnFullName,
            this.treeListColumnDisplayName,
            this.treeListColumnFileType});
            this.treeListModFiles.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.treeListModFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListModFiles.Location = new System.Drawing.Point(0, 0);
            this.treeListModFiles.Margin = new System.Windows.Forms.Padding(2);
            this.treeListModFiles.Name = "treeListModFiles";
            this.treeListModFiles.OptionsBehavior.Editable = false;
            this.treeListModFiles.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.treeListModFiles.OptionsFind.AlwaysVisible = true;
            this.treeListModFiles.Size = new System.Drawing.Size(363, 445);
            this.treeListModFiles.StateImageList = this.svgImageCollectionModExplorer;
            this.treeListModFiles.TabIndex = 0;
            this.treeListModFiles.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.modFileList_BeforeExpand);
            this.treeListModFiles.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.modFileList_AfterExpand);
            this.treeListModFiles.AfterCollapse += new DevExpress.XtraTreeList.NodeEventHandler(this.modFileList_AfterCollapse);
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
            // ModExplorer
            // 
            this.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListModFiles);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModExplorer";
            this.Size = new System.Drawing.Size(363, 445);
            this.Load += new System.EventHandler(this.frmModExplorer_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.treeListModFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollectionModExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcherModExplorer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private FileSystemWatcher fileWatcherModExplorer;
        private DevExpress.XtraTreeList.TreeList treeListModFiles;
        private DevExpress.Utils.SvgImageCollection svgImageCollectionModExplorer;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnDisplayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnFileType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnFullName;
    }
}