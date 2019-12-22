namespace WolvenKit
{
    partial class ImagePreview
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagePreview));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImagePreviewControl = new DevExpress.XtraEditors.PictureEdit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreviewControl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyImageToolStripMenuItem,
            this.saveImageAsToolStripMenuItem,
            this.replaceImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 70);
            // 
            // copyImageToolStripMenuItem
            // 
            this.copyImageToolStripMenuItem.Name = "copyImageToolStripMenuItem";
            this.copyImageToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.copyImageToolStripMenuItem.Text = "Copy Image";
            this.copyImageToolStripMenuItem.Click += new System.EventHandler(this.copyImageToolStripMenuItem_Click);
            // 
            // saveImageAsToolStripMenuItem
            // 
            this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
            this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveImageAsToolStripMenuItem.Text = "Save image as";
            this.saveImageAsToolStripMenuItem.Click += new System.EventHandler(this.saveImageAsToolStripMenuItem_Click);
            // 
            // replaceImageToolStripMenuItem
            // 
            this.replaceImageToolStripMenuItem.Name = "replaceImageToolStripMenuItem";
            this.replaceImageToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.replaceImageToolStripMenuItem.Text = "Replace image";
            this.replaceImageToolStripMenuItem.Click += new System.EventHandler(this.replaceImageToolStripMenuItem_Click);
            // 
            // ImagePreviewControl
            // 
            this.ImagePreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePreviewControl.Location = new System.Drawing.Point(0, 0);
            this.ImagePreviewControl.Name = "ImagePreviewControl";
            this.ImagePreviewControl.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.True;
            this.ImagePreviewControl.Properties.AllowScrollViaMouseDrag = true;
            this.ImagePreviewControl.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.True;
            this.ImagePreviewControl.Properties.Appearance.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ImagePreviewControl.Properties.Appearance.Options.UseBackColor = true;
            this.ImagePreviewControl.Properties.ContextMenuStrip = this.contextMenuStrip1;
            this.ImagePreviewControl.Properties.ErrorImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ImagePreviewControl.Properties.ErrorImageOptions.SvgImage")));
            this.ImagePreviewControl.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.True;
            this.ImagePreviewControl.Properties.ShowScrollBars = true;
            this.ImagePreviewControl.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            this.ImagePreviewControl.Size = new System.Drawing.Size(657, 535);
            this.ImagePreviewControl.TabIndex = 1;
            // 
            // ImagePreview
            // 
            this.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ImagePreviewControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImagePreview";
            this.Size = new System.Drawing.Size(657, 535);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreviewControl.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceImageToolStripMenuItem;
        private DevExpress.XtraEditors.PictureEdit ImagePreviewControl;
    }
}