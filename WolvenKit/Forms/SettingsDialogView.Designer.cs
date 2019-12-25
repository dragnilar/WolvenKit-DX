using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace WolvenKit
{
    partial class SettingsDialogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialogView));
            this.txExecutablePath = new DevExpress.XtraEditors.TextEdit();
            this.lblExecutable = new DevExpress.XtraEditors.LabelControl();
            this.btnBrowseExe = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblLanguage = new DevExpress.XtraEditors.LabelControl();
            this.lblVoiceLanguage = new DevExpress.XtraEditors.LabelControl();
            this.btBrowseWCC_Lite = new DevExpress.XtraEditors.SimpleButton();
            this.lblWCC_Lite = new DevExpress.XtraEditors.LabelControl();
            this.txWCC_Lite = new DevExpress.XtraEditors.TextEdit();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txTextLanguage = new DevExpress.XtraEditors.TextEdit();
            this.txVoiceLanguage = new DevExpress.XtraEditors.TextEdit();
            this.exeSearcherSlave = new System.ComponentModel.BackgroundWorker();
            this.W3exeTickLBL = new DevExpress.XtraEditors.LabelControl();
            this.WCCexeTickLBL = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txExecutablePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txWCC_Lite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txTextLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txVoiceLanguage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txExecutablePath
            // 
            this.txExecutablePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txExecutablePath.Location = new System.Drawing.Point(35, 27);
            this.txExecutablePath.Name = "txExecutablePath";
            this.txExecutablePath.Size = new System.Drawing.Size(442, 20);
            this.txExecutablePath.TabIndex = 0;
            this.txExecutablePath.TextChanged += new System.EventHandler(this.txExecutablePath_TextChanged);
            // 
            // lblExecutable
            // 
            this.lblExecutable.Location = new System.Drawing.Point(35, 9);
            this.lblExecutable.Name = "lblExecutable";
            this.lblExecutable.Size = new System.Drawing.Size(131, 13);
            this.lblExecutable.TabIndex = 1;
            this.lblExecutable.Text = "Witcher 3 executable path:";
            // 
            // btnBrowseExe
            // 
            this.btnBrowseExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseExe.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBrowseExe.ImageOptions.SvgImage")));
            this.btnBrowseExe.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnBrowseExe.Location = new System.Drawing.Point(483, 26);
            this.btnBrowseExe.Name = "btnBrowseExe";
            this.btnBrowseExe.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseExe.TabIndex = 2;
            this.btnBrowseExe.Text = "Browse...";
            this.btnBrowseExe.Click += new System.EventHandler(this.btnBrowseExe_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btSave.ImageOptions.SvgImage")));
            this.btSave.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btSave.Location = new System.Drawing.Point(483, 108);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Save";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lblLanguage
            // 
            this.lblLanguage.Enabled = false;
            this.lblLanguage.Location = new System.Drawing.Point(12, 98);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(119, 13);
            this.lblLanguage.TabIndex = 5;
            this.lblLanguage.Text = "Text Language (e.g. EN)";
            // 
            // lblVoiceLanguage
            // 
            this.lblVoiceLanguage.Enabled = false;
            this.lblVoiceLanguage.Location = new System.Drawing.Point(153, 98);
            this.lblVoiceLanguage.Name = "lblVoiceLanguage";
            this.lblVoiceLanguage.Size = new System.Drawing.Size(132, 13);
            this.lblVoiceLanguage.TabIndex = 7;
            this.lblVoiceLanguage.Text = "Speech Language (e.g. EN)";
            // 
            // btBrowseWCC_Lite
            // 
            this.btBrowseWCC_Lite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseWCC_Lite.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btBrowseWCC_Lite.ImageOptions.SvgImage")));
            this.btBrowseWCC_Lite.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btBrowseWCC_Lite.Location = new System.Drawing.Point(483, 66);
            this.btBrowseWCC_Lite.Name = "btBrowseWCC_Lite";
            this.btBrowseWCC_Lite.Size = new System.Drawing.Size(75, 23);
            this.btBrowseWCC_Lite.TabIndex = 10;
            this.btBrowseWCC_Lite.Text = "Browse...";
            this.btBrowseWCC_Lite.Click += new System.EventHandler(this.btBrowseWCC_Lite_Click);
            // 
            // lblWCC_Lite
            // 
            this.lblWCC_Lite.Location = new System.Drawing.Point(35, 50);
            this.lblWCC_Lite.Name = "lblWCC_Lite";
            this.lblWCC_Lite.Size = new System.Drawing.Size(98, 13);
            this.lblWCC_Lite.TabIndex = 9;
            this.lblWCC_Lite.Text = "WCC_Lite.exe Path:";
            // 
            // txWCC_Lite
            // 
            this.txWCC_Lite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txWCC_Lite.Location = new System.Drawing.Point(35, 67);
            this.txWCC_Lite.Name = "txWCC_Lite";
            this.txWCC_Lite.Size = new System.Drawing.Size(441, 20);
            this.txWCC_Lite.TabIndex = 8;
            this.txWCC_Lite.TextChanged += new System.EventHandler(this.txWCC_Lite_TextChanged);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btCancel.ImageOptions.SvgImage")));
            this.btCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btCancel.Location = new System.Drawing.Point(402, 108);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 11;
            this.btCancel.Text = "Cancel";
            // 
            // txTextLanguage
            // 
            this.txTextLanguage.Enabled = false;
            this.txTextLanguage.Location = new System.Drawing.Point(12, 117);
            this.txTextLanguage.Name = "txTextLanguage";
            this.txTextLanguage.Size = new System.Drawing.Size(135, 20);
            this.txTextLanguage.TabIndex = 4;
            // 
            // txVoiceLanguage
            // 
            this.txVoiceLanguage.Enabled = false;
            this.txVoiceLanguage.Location = new System.Drawing.Point(153, 117);
            this.txVoiceLanguage.Name = "txVoiceLanguage";
            this.txVoiceLanguage.Size = new System.Drawing.Size(135, 20);
            this.txVoiceLanguage.TabIndex = 6;
            // 
            // exeSearcherSlave
            // 
            this.exeSearcherSlave.WorkerReportsProgress = true;
            this.exeSearcherSlave.WorkerSupportsCancellation = true;
            this.exeSearcherSlave.DoWork += new System.ComponentModel.DoWorkEventHandler(this.exeSearcherSlave_DoWork);
            this.exeSearcherSlave.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.exeSearcherSlave_ProgressChanged);
            this.exeSearcherSlave.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.exeSearcherSlave_RunWorkerCompleted);
            // 
            // W3exeTickLBL
            // 
            this.W3exeTickLBL.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.W3exeTickLBL.Appearance.ForeColor = System.Drawing.Color.Red;
            this.W3exeTickLBL.Appearance.Options.UseFont = true;
            this.W3exeTickLBL.Appearance.Options.UseForeColor = true;
            this.W3exeTickLBL.Location = new System.Drawing.Point(17, 31);
            this.W3exeTickLBL.Name = "W3exeTickLBL";
            this.W3exeTickLBL.Size = new System.Drawing.Size(9, 13);
            this.W3exeTickLBL.TabIndex = 13;
            this.W3exeTickLBL.Text = "X";
            // 
            // WCCexeTickLBL
            // 
            this.WCCexeTickLBL.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WCCexeTickLBL.Appearance.ForeColor = System.Drawing.Color.Red;
            this.WCCexeTickLBL.Appearance.Options.UseFont = true;
            this.WCCexeTickLBL.Appearance.Options.UseForeColor = true;
            this.WCCexeTickLBL.Location = new System.Drawing.Point(17, 71);
            this.WCCexeTickLBL.Name = "WCCexeTickLBL";
            this.WCCexeTickLBL.Size = new System.Drawing.Size(9, 13);
            this.WCCexeTickLBL.TabIndex = 14;
            this.WCCexeTickLBL.Text = "X";
            // 
            // SettingsDialogView
            // 
            this.AcceptButton = this.btSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(588, 143);
            this.Controls.Add(this.WCCexeTickLBL);
            this.Controls.Add(this.W3exeTickLBL);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btBrowseWCC_Lite);
            this.Controls.Add(this.lblWCC_Lite);
            this.Controls.Add(this.txWCC_Lite);
            this.Controls.Add(this.lblVoiceLanguage);
            this.Controls.Add(this.txVoiceLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.txTextLanguage);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btnBrowseExe);
            this.Controls.Add(this.lblExecutable);
            this.Controls.Add(this.txExecutablePath);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("SettingsDialogView.IconOptions.Icon")));
            this.IconOptions.Image = global::WolvenKit.Properties.Resources.wkdxicon;
            this.Name = "SettingsDialogView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.txExecutablePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txWCC_Lite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txTextLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txVoiceLanguage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txExecutablePath;
        private DevExpress.XtraEditors.LabelControl lblExecutable;
        private DevExpress.XtraEditors.SimpleButton btnBrowseExe;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.LabelControl lblLanguage;
        private DevExpress.XtraEditors.LabelControl lblVoiceLanguage;
        private DevExpress.XtraEditors.SimpleButton btBrowseWCC_Lite;
        private DevExpress.XtraEditors.LabelControl lblWCC_Lite;
        private DevExpress.XtraEditors.TextEdit txWCC_Lite;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.TextEdit txTextLanguage;
        private DevExpress.XtraEditors.TextEdit txVoiceLanguage;
        private BackgroundWorker exeSearcherSlave;
        private DevExpress.XtraEditors.LabelControl W3exeTickLBL;
        private DevExpress.XtraEditors.LabelControl WCCexeTickLBL;
    }
}