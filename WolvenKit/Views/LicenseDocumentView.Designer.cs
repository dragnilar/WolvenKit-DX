namespace WolvenKit.Views
{
    partial class LicenseDocumentView
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
            this.richEditControlLIcense = new DevExpress.XtraRichEdit.RichEditControl();
            this.SuspendLayout();
            // 
            // richEditControlLIcense
            // 
            this.richEditControlLIcense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControlLIcense.DocumentViewDirection = DevExpress.XtraRichEdit.DocumentViewDirection.LeftToRight;
            this.richEditControlLIcense.Location = new System.Drawing.Point(0, 0);
            this.richEditControlLIcense.Name = "richEditControlLIcense";
            this.richEditControlLIcense.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditControlLIcense.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditControlLIcense.Size = new System.Drawing.Size(1000, 770);
            this.richEditControlLIcense.TabIndex = 0;
            // 
            // LicenseDocumentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 770);
            this.Controls.Add(this.richEditControlLIcense);
            this.IconOptions.Image = global::WolvenKit.Properties.Resources.wkdxicon;
            this.Name = "LicenseDocumentView";
            this.Text = "Witcher III Modding Tool License";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditControlLIcense;
    }
}