using System.ComponentModel;
using System.Windows.Forms;

namespace WolvenKit
{
    partial class AddChunkDialogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddChunkDialogView));
            this.comboBoxEditType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.formAssistantAddChunk = new DevExpress.XtraBars.FormAssistant();
            this.lcAddChunk = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcCancelButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcAddButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTypeComboBoxEdit = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceBottom = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceMiddleButtons = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceTop = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcAddChunk)).BeginInit();
            this.lcAddChunk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcAddButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTypeComboBoxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceMiddleButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceTop)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEditType
            // 
            this.comboBoxEditType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEditType.Location = new System.Drawing.Point(59, 37);
            this.comboBoxEditType.Name = "comboBoxEditType";
            this.comboBoxEditType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEditType.Properties.Appearance.Options.UseFont = true;
            this.comboBoxEditType.Size = new System.Drawing.Size(403, 26);
            this.comboBoxEditType.StyleController = this.lcAddChunk;
            this.comboBoxEditType.TabIndex = 12;
            this.comboBoxEditType.SelectedIndexChanged += new System.EventHandler(this.txType_SelectedIndexChanged);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonCancel.Appearance.Options.UseFont = true;
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btCancel.ImageOptions.SvgImage")));
            this.simpleButtonCancel.Location = new System.Drawing.Point(304, 96);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(158, 36);
            this.simpleButtonCancel.StyleController = this.lcAddChunk;
            this.simpleButtonCancel.TabIndex = 11;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonOK.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonOK.Appearance.Options.UseFont = true;
            this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btOK.ImageOptions.SvgImage")));
            this.simpleButtonOK.Location = new System.Drawing.Point(12, 96);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(177, 36);
            this.simpleButtonOK.StyleController = this.lcAddChunk;
            this.simpleButtonOK.TabIndex = 10;
            this.simpleButtonOK.Text = "Add";
            // 
            // lcAddChunk
            // 
            this.lcAddChunk.Controls.Add(this.comboBoxEditType);
            this.lcAddChunk.Controls.Add(this.simpleButtonOK);
            this.lcAddChunk.Controls.Add(this.simpleButtonCancel);
            this.lcAddChunk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcAddChunk.Location = new System.Drawing.Point(0, 0);
            this.lcAddChunk.Name = "lcAddChunk";
            this.lcAddChunk.Root = this.Root;
            this.lcAddChunk.Size = new System.Drawing.Size(474, 144);
            this.lcAddChunk.TabIndex = 13;
            this.lcAddChunk.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciTypeComboBoxEdit,
            this.lcCancelButton,
            this.lcAddButton,
            this.emptySpaceBottom,
            this.emptySpaceMiddleButtons,
            this.emptySpaceTop});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(474, 144);
            this.Root.TextVisible = false;
            // 
            // lcCancelButton
            // 
            this.lcCancelButton.Control = this.simpleButtonCancel;
            this.lcCancelButton.Location = new System.Drawing.Point(292, 84);
            this.lcCancelButton.Name = "lcCancelButton";
            this.lcCancelButton.Size = new System.Drawing.Size(162, 40);
            this.lcCancelButton.TextSize = new System.Drawing.Size(0, 0);
            this.lcCancelButton.TextVisible = false;
            // 
            // lcAddButton
            // 
            this.lcAddButton.Control = this.simpleButtonOK;
            this.lcAddButton.Location = new System.Drawing.Point(0, 84);
            this.lcAddButton.Name = "lcAddButton";
            this.lcAddButton.Size = new System.Drawing.Size(181, 40);
            this.lcAddButton.TextSize = new System.Drawing.Size(0, 0);
            this.lcAddButton.TextVisible = false;
            // 
            // lciTypeComboBoxEdit
            // 
            this.lciTypeComboBoxEdit.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lciTypeComboBoxEdit.AppearanceItemCaption.Options.UseFont = true;
            this.lciTypeComboBoxEdit.Control = this.comboBoxEditType;
            this.lciTypeComboBoxEdit.Location = new System.Drawing.Point(0, 25);
            this.lciTypeComboBoxEdit.Name = "lciTypeComboBoxEdit";
            this.lciTypeComboBoxEdit.Size = new System.Drawing.Size(454, 30);
            this.lciTypeComboBoxEdit.Text = "Type";
            this.lciTypeComboBoxEdit.TextSize = new System.Drawing.Size(35, 19);
            // 
            // emptySpaceBottom
            // 
            this.emptySpaceBottom.AllowHotTrack = false;
            this.emptySpaceBottom.Location = new System.Drawing.Point(0, 55);
            this.emptySpaceBottom.Name = "emptySpaceBottom";
            this.emptySpaceBottom.Size = new System.Drawing.Size(454, 29);
            this.emptySpaceBottom.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceMiddleButtons
            // 
            this.emptySpaceMiddleButtons.AllowHotTrack = false;
            this.emptySpaceMiddleButtons.Location = new System.Drawing.Point(181, 84);
            this.emptySpaceMiddleButtons.Name = "emptySpaceMiddleButtons";
            this.emptySpaceMiddleButtons.Size = new System.Drawing.Size(111, 40);
            this.emptySpaceMiddleButtons.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceTop
            // 
            this.emptySpaceTop.AllowHotTrack = false;
            this.emptySpaceTop.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceTop.Name = "emptySpaceTop";
            this.emptySpaceTop.Size = new System.Drawing.Size(454, 25);
            this.emptySpaceTop.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmAddChunk
            // 
            this.AcceptButton = this.simpleButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(474, 144);
            this.Controls.Add(this.lcAddChunk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(1000, 200);
            this.MinimumSize = new System.Drawing.Size(199, 89);
            this.Name = "AddChunkDialogView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Chunk";
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcAddChunk)).EndInit();
            this.lcAddChunk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcAddButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTypeComboBoxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceMiddleButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditType;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DevExpress.XtraBars.FormAssistant formAssistantAddChunk;
        private DevExpress.XtraLayout.LayoutControl lcAddChunk;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lcCancelButton;
        private DevExpress.XtraLayout.LayoutControlItem lcAddButton;
        private DevExpress.XtraLayout.LayoutControlItem lciTypeComboBoxEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceBottom;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceMiddleButtons;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceTop;
    }
}