namespace WolvenKit.Controls
{
    partial class ChunkListPropertyEditor
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
            this.treeListChunkProperties = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeListChunkProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListChunkProperties
            // 
            this.treeListChunkProperties.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnName,
            this.treeListColumnValue,
            this.treeListColumnType});
            this.treeListChunkProperties.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListChunkProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListChunkProperties.Location = new System.Drawing.Point(0, 0);
            this.treeListChunkProperties.Name = "treeListChunkProperties";
            this.treeListChunkProperties.Size = new System.Drawing.Size(850, 450);
            this.treeListChunkProperties.TabIndex = 0;
            this.treeListChunkProperties.CustomNodeCellEdit += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.treeListChunkProperties_CustomNodeCellEdit);
            this.treeListChunkProperties.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeListChunkProperties_BeforeExpand);
            // 
            // treeListColumnName
            // 
            this.treeListColumnName.Caption = "Name";
            this.treeListColumnName.FieldName = "Name";
            this.treeListColumnName.Name = "treeListColumnName";
            this.treeListColumnName.OptionsColumn.AllowEdit = false;
            this.treeListColumnName.Visible = true;
            this.treeListColumnName.VisibleIndex = 0;
            this.treeListColumnName.Width = 298;
            // 
            // treeListColumnValue
            // 
            this.treeListColumnValue.Caption = "Value";
            this.treeListColumnValue.FieldName = "Value";
            this.treeListColumnValue.Name = "treeListColumnValue";
            this.treeListColumnValue.Visible = true;
            this.treeListColumnValue.VisibleIndex = 1;
            this.treeListColumnValue.Width = 414;
            // 
            // treeListColumnType
            // 
            this.treeListColumnType.Caption = "Type";
            this.treeListColumnType.FieldName = "Type";
            this.treeListColumnType.Name = "treeListColumnType";
            this.treeListColumnType.OptionsColumn.AllowEdit = false;
            this.treeListColumnType.Visible = true;
            this.treeListColumnType.VisibleIndex = 2;
            this.treeListColumnType.Width = 111;
            // 
            // ChunkListPropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListChunkProperties);
            this.Name = "ChunkListPropertyEditor";
            this.Size = new System.Drawing.Size(850, 450);
            ((System.ComponentModel.ISupportInitialize)(this.treeListChunkProperties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListChunkProperties;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnValue;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnType;
    }
}
