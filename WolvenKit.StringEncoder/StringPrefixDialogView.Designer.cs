namespace WolvenKit
{
    partial class StringPrefixDialogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringPrefixDialogView));
            this.buttonOk = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxPrefix = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPrefix.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonOk.ImageOptions.SvgImage")));
            this.buttonOk.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.buttonOk.Location = new System.Drawing.Point(12, 76);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            // 
            // buttonCancel
            // 
            this.buttonCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonCancel.ImageOptions.SvgImage")));
            this.buttonCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.buttonCancel.Location = new System.Drawing.Point(313, 76);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Location = new System.Drawing.Point(12, 36);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(376, 20);
            this.textBoxPrefix.TabIndex = 2;
            this.textBoxPrefix.TextChanged += new System.EventHandler(this.textBoxPrefix_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter string key prefix: ";
            // 
            // StringPrefixDialogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 120);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPrefix);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("StringPrefixDialogView.IconOptions.Image")));
            this.MaximumSize = new System.Drawing.Size(400, 150);
            this.MinimumSize = new System.Drawing.Size(184, 141);
            this.Name = "StringPrefixDialogView";
            this.Text = "Enter string key prefix";
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPrefix.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonOk;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.TextEdit textBoxPrefix;
        private DevExpress.XtraEditors.LabelControl label1;
    }
}