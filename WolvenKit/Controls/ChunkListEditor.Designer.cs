namespace WolvenKit.Controls
{
    partial class ChunkListEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControlChunkEditor = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlChunkEditor = new DevExpress.XtraGrid.GridControl();
            this.gridViewChunkEditor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnChunkIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPreview = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chunkPropertyViewerControl = new WolvenKit.ChunkPropertyViewer();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciChunkProperties = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterChunkListEditor = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlChunkEditor)).BeginInit();
            this.layoutControlChunkEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChunkEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChunkEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChunkProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterChunkListEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlChunkEditor
            // 
            this.layoutControlChunkEditor.Controls.Add(this.gridControlChunkEditor);
            this.layoutControlChunkEditor.Controls.Add(this.chunkPropertyViewerControl);
            this.layoutControlChunkEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlChunkEditor.Location = new System.Drawing.Point(0, 0);
            this.layoutControlChunkEditor.Name = "layoutControlChunkEditor";
            this.layoutControlChunkEditor.Root = this.Root;
            this.layoutControlChunkEditor.Size = new System.Drawing.Size(879, 726);
            this.layoutControlChunkEditor.TabIndex = 0;
            this.layoutControlChunkEditor.Text = "layoutControl1";
            // 
            // gridControlChunkEditor
            // 
            this.gridControlChunkEditor.Location = new System.Drawing.Point(12, 12);
            this.gridControlChunkEditor.MainView = this.gridViewChunkEditor;
            this.gridControlChunkEditor.Name = "gridControlChunkEditor";
            this.gridControlChunkEditor.Size = new System.Drawing.Size(855, 330);
            this.gridControlChunkEditor.TabIndex = 6;
            this.gridControlChunkEditor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewChunkEditor});
            // 
            // gridViewChunkEditor
            // 
            this.gridViewChunkEditor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnChunkIndex,
            this.gridColumnName,
            this.gridColumnPreview});
            this.gridViewChunkEditor.GridControl = this.gridControlChunkEditor;
            this.gridViewChunkEditor.Name = "gridViewChunkEditor";
            this.gridViewChunkEditor.OptionsBehavior.Editable = false;
            this.gridViewChunkEditor.OptionsFind.AlwaysVisible = true;
            this.gridViewChunkEditor.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridViewChunkEditor.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // gridColumnChunkIndex
            // 
            this.gridColumnChunkIndex.Caption = "Index";
            this.gridColumnChunkIndex.FieldName = "ChunkIndex";
            this.gridColumnChunkIndex.Name = "gridColumnChunkIndex";
            this.gridColumnChunkIndex.Visible = true;
            this.gridColumnChunkIndex.VisibleIndex = 0;
            this.gridColumnChunkIndex.Width = 72;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Name";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 1;
            this.gridColumnName.Width = 191;
            // 
            // gridColumnPreview
            // 
            this.gridColumnPreview.Caption = "Preview";
            this.gridColumnPreview.FieldName = "Preview";
            this.gridColumnPreview.Name = "gridColumnPreview";
            this.gridColumnPreview.Visible = true;
            this.gridColumnPreview.VisibleIndex = 2;
            this.gridColumnPreview.Width = 565;
            // 
            // chunkPropertyViewerControl
            // 
            this.chunkPropertyViewerControl.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chunkPropertyViewerControl.Appearance.Options.UseFont = true;
            this.chunkPropertyViewerControl.Chunk = null;
            this.chunkPropertyViewerControl.EditObject = null;
            this.chunkPropertyViewerControl.Location = new System.Drawing.Point(12, 356);
            this.chunkPropertyViewerControl.Name = "chunkPropertyViewerControl";
            this.chunkPropertyViewerControl.Size = new System.Drawing.Size(855, 358);
            this.chunkPropertyViewerControl.Source = null;
            this.chunkPropertyViewerControl.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciChunkProperties,
            this.splitterChunkListEditor,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(879, 726);
            this.Root.TextVisible = false;
            // 
            // lciChunkProperties
            // 
            this.lciChunkProperties.Control = this.chunkPropertyViewerControl;
            this.lciChunkProperties.Location = new System.Drawing.Point(0, 344);
            this.lciChunkProperties.Name = "lciChunkProperties";
            this.lciChunkProperties.Size = new System.Drawing.Size(859, 362);
            this.lciChunkProperties.TextSize = new System.Drawing.Size(0, 0);
            this.lciChunkProperties.TextVisible = false;
            // 
            // splitterChunkListEditor
            // 
            this.splitterChunkListEditor.AllowHotTrack = true;
            this.splitterChunkListEditor.Location = new System.Drawing.Point(0, 334);
            this.splitterChunkListEditor.Name = "splitterChunkListEditor";
            this.splitterChunkListEditor.Size = new System.Drawing.Size(859, 10);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlChunkEditor;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(859, 334);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ChunkListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControlChunkEditor);
            this.Name = "ChunkListEditor";
            this.Size = new System.Drawing.Size(879, 726);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlChunkEditor)).EndInit();
            this.layoutControlChunkEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChunkEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChunkEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChunkProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterChunkListEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlChunkEditor;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private ChunkPropertyViewer chunkPropertyViewerControl;
        private DevExpress.XtraLayout.LayoutControlItem lciChunkProperties;
        private DevExpress.XtraLayout.SplitterItem splitterChunkListEditor;
        private DevExpress.XtraGrid.GridControl gridControlChunkEditor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewChunkEditor;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnChunkIndex;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPreview;
    }
}
