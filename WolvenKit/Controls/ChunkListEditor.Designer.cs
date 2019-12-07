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
            this.chunkPropertyViewerControl = new WolvenKit.ChunkPropertyViewer();
            this.chunkListViewerControl = new WolvenKit.ChunkListViewer();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciChunkListViewer = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciChunkProperties = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterChunkListEditor = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlChunkEditor)).BeginInit();
            this.layoutControlChunkEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChunkListViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChunkProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterChunkListEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlChunkEditor
            // 
            this.layoutControlChunkEditor.Controls.Add(this.chunkPropertyViewerControl);
            this.layoutControlChunkEditor.Controls.Add(this.chunkListViewerControl);
            this.layoutControlChunkEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlChunkEditor.Location = new System.Drawing.Point(0, 0);
            this.layoutControlChunkEditor.Name = "layoutControlChunkEditor";
            this.layoutControlChunkEditor.Root = this.Root;
            this.layoutControlChunkEditor.Size = new System.Drawing.Size(879, 726);
            this.layoutControlChunkEditor.TabIndex = 0;
            this.layoutControlChunkEditor.Text = "layoutControl1";
            // 
            // chunkPropertyViewerControl
            // 
            this.chunkPropertyViewerControl.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chunkPropertyViewerControl.Appearance.Options.UseFont = true;
            this.chunkPropertyViewerControl.Chunk = null;
            this.chunkPropertyViewerControl.EditObject = null;
            this.chunkPropertyViewerControl.Location = new System.Drawing.Point(12, 526);
            this.chunkPropertyViewerControl.Name = "chunkPropertyViewerControl";
            this.chunkPropertyViewerControl.Size = new System.Drawing.Size(855, 188);
            this.chunkPropertyViewerControl.Source = null;
            this.chunkPropertyViewerControl.TabIndex = 5;
            // 
            // chunkListViewerControl
            // 
            this.chunkListViewerControl.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chunkListViewerControl.Appearance.Options.UseFont = true;
            this.chunkListViewerControl.File = null;
            this.chunkListViewerControl.Location = new System.Drawing.Point(12, 12);
            this.chunkListViewerControl.MinimumSize = new System.Drawing.Size(100, 100);
            this.chunkListViewerControl.Name = "chunkListViewerControl";
            this.chunkListViewerControl.Size = new System.Drawing.Size(855, 500);
            this.chunkListViewerControl.TabIndex = 4;
            this.chunkListViewerControl.OnSelectChunk += new System.EventHandler<WolvenKit.SelectChunkArgs>(this.chunkListViewerControl_OnSelectChunk);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciChunkListViewer,
            this.lciChunkProperties,
            this.splitterChunkListEditor});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(879, 726);
            this.Root.TextVisible = false;
            // 
            // lciChunkListViewer
            // 
            this.lciChunkListViewer.Control = this.chunkListViewerControl;
            this.lciChunkListViewer.Location = new System.Drawing.Point(0, 0);
            this.lciChunkListViewer.Name = "lciChunkListViewer";
            this.lciChunkListViewer.Size = new System.Drawing.Size(859, 504);
            this.lciChunkListViewer.TextSize = new System.Drawing.Size(0, 0);
            this.lciChunkListViewer.TextVisible = false;
            // 
            // lciChunkProperties
            // 
            this.lciChunkProperties.Control = this.chunkPropertyViewerControl;
            this.lciChunkProperties.Location = new System.Drawing.Point(0, 514);
            this.lciChunkProperties.Name = "lciChunkProperties";
            this.lciChunkProperties.Size = new System.Drawing.Size(859, 192);
            this.lciChunkProperties.TextSize = new System.Drawing.Size(0, 0);
            this.lciChunkProperties.TextVisible = false;
            // 
            // splitterChunkListEditor
            // 
            this.splitterChunkListEditor.AllowHotTrack = true;
            this.splitterChunkListEditor.Location = new System.Drawing.Point(0, 504);
            this.splitterChunkListEditor.Name = "splitterChunkListEditor";
            this.splitterChunkListEditor.Size = new System.Drawing.Size(859, 10);
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
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChunkListViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChunkProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterChunkListEditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlChunkEditor;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private ChunkPropertyViewer chunkPropertyViewerControl;
        private ChunkListViewer chunkListViewerControl;
        private DevExpress.XtraLayout.LayoutControlItem lciChunkListViewer;
        private DevExpress.XtraLayout.LayoutControlItem lciChunkProperties;
        private DevExpress.XtraLayout.SplitterItem splitterChunkListEditor;
    }
}
