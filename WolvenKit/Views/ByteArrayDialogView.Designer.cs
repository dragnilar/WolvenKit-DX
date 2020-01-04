namespace WolvenKit.Views
{
    partial class ByteArrayDialogView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ByteArrayDialogView));
            this.lcByteArrayDialog = new DevExpress.XtraLayout.LayoutControl();
            this.lcgByteArrayDialog = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleButtonExport = new DevExpress.XtraEditors.SimpleButton();
            this.lciExportButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceTop = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleButtonImport = new DevExpress.XtraEditors.SimpleButton();
            this.lciImportButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButtonOpen = new DevExpress.XtraEditors.SimpleButton();
            this.lciOpenButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceExportRight = new DevExpress.XtraLayout.EmptySpaceItem();
            this.empySpaceImportRight = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceOpenRight = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceExportLeft = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceCloseLeft = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
            this.lciCloseButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceBottom = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcByteArrayDialog)).BeginInit();
            this.lcByteArrayDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgByteArrayDialog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExportButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImportButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOpenButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceExportRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empySpaceImportRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceOpenRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceExportLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceCloseLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // lcByteArrayDialog
            // 
            this.lcByteArrayDialog.Controls.Add(this.simpleButtonOpen);
            this.lcByteArrayDialog.Controls.Add(this.simpleButtonImport);
            this.lcByteArrayDialog.Controls.Add(this.simpleButtonExport);
            this.lcByteArrayDialog.Controls.Add(this.simpleButtonClose);
            this.lcByteArrayDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcByteArrayDialog.Location = new System.Drawing.Point(0, 0);
            this.lcByteArrayDialog.Name = "lcByteArrayDialog";
            this.lcByteArrayDialog.Root = this.lcgByteArrayDialog;
            this.lcByteArrayDialog.Size = new System.Drawing.Size(523, 191);
            this.lcByteArrayDialog.TabIndex = 0;
            this.lcByteArrayDialog.Text = "layoutControl1";
            // 
            // lcgByteArrayDialog
            // 
            this.lcgByteArrayDialog.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgByteArrayDialog.GroupBordersVisible = false;
            this.lcgByteArrayDialog.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciExportButton,
            this.lciImportButton,
            this.lciOpenButton,
            this.emptySpaceTop,
            this.emptySpaceExportRight,
            this.empySpaceImportRight,
            this.emptySpaceOpenRight,
            this.emptySpaceCloseLeft,
            this.emptySpaceExportLeft,
            this.emptySpaceBottom,
            this.lciCloseButton});
            this.lcgByteArrayDialog.Name = "lcgByteArrayDialog";
            this.lcgByteArrayDialog.Size = new System.Drawing.Size(523, 191);
            this.lcgByteArrayDialog.TextVisible = false;
            // 
            // simpleButtonExport
            // 
            this.simpleButtonExport.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonExport.Appearance.Options.UseFont = true;
            this.simpleButtonExport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButtonExport.Location = new System.Drawing.Point(44, 62);
            this.simpleButtonExport.Name = "simpleButtonExport";
            this.simpleButtonExport.Size = new System.Drawing.Size(110, 36);
            this.simpleButtonExport.StyleController = this.lcByteArrayDialog;
            this.simpleButtonExport.TabIndex = 4;
            this.simpleButtonExport.Text = "Export...";
            this.simpleButtonExport.ToolTip = "Export the byte array to a file. You can import it into another one.";
            // 
            // lciExportButton
            // 
            this.lciExportButton.Control = this.simpleButtonExport;
            this.lciExportButton.Location = new System.Drawing.Point(32, 50);
            this.lciExportButton.Name = "lciExportButton";
            this.lciExportButton.Size = new System.Drawing.Size(114, 40);
            this.lciExportButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciExportButton.TextVisible = false;
            // 
            // emptySpaceTop
            // 
            this.emptySpaceTop.AllowHotTrack = false;
            this.emptySpaceTop.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceTop.Name = "emptySpaceTop";
            this.emptySpaceTop.Size = new System.Drawing.Size(503, 50);
            this.emptySpaceTop.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleButtonImport
            // 
            this.simpleButtonImport.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonImport.Appearance.Options.UseFont = true;
            this.simpleButtonImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButtonImport.Location = new System.Drawing.Point(182, 62);
            this.simpleButtonImport.Name = "simpleButtonImport";
            this.simpleButtonImport.Size = new System.Drawing.Size(126, 36);
            this.simpleButtonImport.StyleController = this.lcByteArrayDialog;
            this.simpleButtonImport.TabIndex = 5;
            this.simpleButtonImport.Text = "Import";
            this.simpleButtonImport.ToolTip = "Import a previously exported byte array.";
            // 
            // lciImportButton
            // 
            this.lciImportButton.Control = this.simpleButtonImport;
            this.lciImportButton.Location = new System.Drawing.Point(170, 50);
            this.lciImportButton.Name = "lciImportButton";
            this.lciImportButton.Size = new System.Drawing.Size(130, 40);
            this.lciImportButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciImportButton.TextVisible = false;
            // 
            // simpleButtonOpen
            // 
            this.simpleButtonOpen.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonOpen.Appearance.Options.UseFont = true;
            this.simpleButtonOpen.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButtonOpen.Location = new System.Drawing.Point(344, 62);
            this.simpleButtonOpen.Name = "simpleButtonOpen";
            this.simpleButtonOpen.Size = new System.Drawing.Size(140, 36);
            this.simpleButtonOpen.StyleController = this.lcByteArrayDialog;
            this.simpleButtonOpen.TabIndex = 6;
            this.simpleButtonOpen.Text = "Open";
            this.simpleButtonOpen.ToolTip = "Open the byte array for editing.";
            // 
            // lciOpenButton
            // 
            this.lciOpenButton.Control = this.simpleButtonOpen;
            this.lciOpenButton.Location = new System.Drawing.Point(332, 50);
            this.lciOpenButton.Name = "lciOpenButton";
            this.lciOpenButton.Size = new System.Drawing.Size(144, 40);
            this.lciOpenButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciOpenButton.TextVisible = false;
            // 
            // emptySpaceExportRight
            // 
            this.emptySpaceExportRight.AllowHotTrack = false;
            this.emptySpaceExportRight.Location = new System.Drawing.Point(146, 50);
            this.emptySpaceExportRight.Name = "emptySpaceExportRight";
            this.emptySpaceExportRight.Size = new System.Drawing.Size(24, 40);
            this.emptySpaceExportRight.TextSize = new System.Drawing.Size(0, 0);
            // 
            // empySpaceImportRight
            // 
            this.empySpaceImportRight.AllowHotTrack = false;
            this.empySpaceImportRight.Location = new System.Drawing.Point(300, 50);
            this.empySpaceImportRight.Name = "empySpaceImportRight";
            this.empySpaceImportRight.Size = new System.Drawing.Size(32, 40);
            this.empySpaceImportRight.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceOpenRight
            // 
            this.emptySpaceOpenRight.AllowHotTrack = false;
            this.emptySpaceOpenRight.Location = new System.Drawing.Point(476, 50);
            this.emptySpaceOpenRight.Name = "emptySpaceOpenRight";
            this.emptySpaceOpenRight.Size = new System.Drawing.Size(27, 40);
            this.emptySpaceOpenRight.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceExportLeft
            // 
            this.emptySpaceExportLeft.AllowHotTrack = false;
            this.emptySpaceExportLeft.Location = new System.Drawing.Point(0, 50);
            this.emptySpaceExportLeft.Name = "emptySpaceExportLeft";
            this.emptySpaceExportLeft.Size = new System.Drawing.Size(32, 40);
            this.emptySpaceExportLeft.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceCloseLeft
            // 
            this.emptySpaceCloseLeft.AllowHotTrack = false;
            this.emptySpaceCloseLeft.Location = new System.Drawing.Point(0, 131);
            this.emptySpaceCloseLeft.Name = "emptySpaceCloseLeft";
            this.emptySpaceCloseLeft.Size = new System.Drawing.Size(332, 40);
            this.emptySpaceCloseLeft.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleButtonClose
            // 
            this.simpleButtonClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonClose.Appearance.Options.UseFont = true;
            this.simpleButtonClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton4.ImageOptions.SvgImage")));
            this.simpleButtonClose.Location = new System.Drawing.Point(344, 143);
            this.simpleButtonClose.Name = "simpleButtonClose";
            this.simpleButtonClose.Size = new System.Drawing.Size(167, 36);
            this.simpleButtonClose.StyleController = this.lcByteArrayDialog;
            this.simpleButtonClose.TabIndex = 7;
            this.simpleButtonClose.Text = "Close";
            // 
            // lciCloseButton
            // 
            this.lciCloseButton.Control = this.simpleButtonClose;
            this.lciCloseButton.Location = new System.Drawing.Point(332, 131);
            this.lciCloseButton.Name = "lciCloseButton";
            this.lciCloseButton.Size = new System.Drawing.Size(171, 40);
            this.lciCloseButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciCloseButton.TextVisible = false;
            // 
            // emptySpaceBottom
            // 
            this.emptySpaceBottom.AllowHotTrack = false;
            this.emptySpaceBottom.Location = new System.Drawing.Point(0, 90);
            this.emptySpaceBottom.Name = "emptySpaceBottom";
            this.emptySpaceBottom.Size = new System.Drawing.Size(503, 41);
            this.emptySpaceBottom.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ByteArrayDialogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 191);
            this.Controls.Add(this.lcByteArrayDialog);
            this.IconOptions.Image = global::WolvenKit.Properties.Resources.wkdxicon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ByteArrayDialogView";
            this.Text = "Select An Option For The Byte Array";
            ((System.ComponentModel.ISupportInitialize)(this.lcByteArrayDialog)).EndInit();
            this.lcByteArrayDialog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgByteArrayDialog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExportButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImportButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOpenButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceExportRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empySpaceImportRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceOpenRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceExportLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceCloseLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcByteArrayDialog;
        private DevExpress.XtraLayout.LayoutControlGroup lcgByteArrayDialog;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOpen;
        private DevExpress.XtraEditors.SimpleButton simpleButtonImport;
        private DevExpress.XtraEditors.SimpleButton simpleButtonExport;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClose;
        private DevExpress.XtraLayout.LayoutControlItem lciExportButton;
        private DevExpress.XtraLayout.LayoutControlItem lciImportButton;
        private DevExpress.XtraLayout.LayoutControlItem lciOpenButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceTop;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceExportRight;
        private DevExpress.XtraLayout.EmptySpaceItem empySpaceImportRight;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceOpenRight;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceCloseLeft;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceExportLeft;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceBottom;
        private DevExpress.XtraLayout.LayoutControlItem lciCloseButton;
    }
}