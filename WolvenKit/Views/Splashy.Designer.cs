namespace WolvenKit.Views
{
    partial class Splashy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splashy));
            this.peImage = new DevExpress.XtraEditors.PictureEdit();
            this.progressBarControlSplashy = new DevExpress.XtraEditors.ProgressBarControl();
            this.textEditStatus = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlSplashy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // peImage
            // 
            this.peImage.EditValue = ((object)(resources.GetObject("peImage.EditValue")));
            this.peImage.Location = new System.Drawing.Point(12, 12);
            this.peImage.Name = "peImage";
            this.peImage.Properties.AllowFocused = false;
            this.peImage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peImage.Properties.Appearance.Options.UseBackColor = true;
            this.peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peImage.Properties.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.peImage.Properties.ShowMenu = false;
            this.peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.peImage.Size = new System.Drawing.Size(872, 567);
            this.peImage.TabIndex = 9;
            this.peImage.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.True;
            // 
            // progressBarControlSplashy
            // 
            this.progressBarControlSplashy.Location = new System.Drawing.Point(30, 431);
            this.progressBarControlSplashy.Name = "progressBarControlSplashy";
            this.progressBarControlSplashy.Properties.ShowTitle = true;
            this.progressBarControlSplashy.Size = new System.Drawing.Size(842, 60);
            this.progressBarControlSplashy.TabIndex = 10;
            // 
            // textEditStatus
            // 
            this.textEditStatus.EditValue = "Loading...";
            this.textEditStatus.Location = new System.Drawing.Point(30, 405);
            this.textEditStatus.Name = "textEditStatus";
            this.textEditStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditStatus.Properties.Appearance.Options.UseFont = true;
            this.textEditStatus.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditStatus.Size = new System.Drawing.Size(842, 22);
            this.textEditStatus.TabIndex = 11;
            // 
            // Splashy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 591);
            this.Controls.Add(this.textEditStatus);
            this.Controls.Add(this.progressBarControlSplashy);
            this.Controls.Add(this.peImage);
            this.Name = "Splashy";
            this.Text = "Splashy";
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlSplashy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditStatus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PictureEdit peImage;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControlSplashy;
        private DevExpress.XtraEditors.TextEdit textEditStatus;
    }
}
