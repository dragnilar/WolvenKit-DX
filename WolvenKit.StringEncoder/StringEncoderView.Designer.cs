using DevExpress.XtraTab;

namespace WolvenKit.StringEncoder
{
	partial class StringEncoderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringEncoderView));
            this.tabControlLanguages = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageAllLanguages = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlStringsEncoder = new DevExpress.XtraGrid.GridControl();
            this.gridViewStringsEncoder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnHexKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStringKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLocalization = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoItemLocalizationMemoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.barManagerStringEncoder = new DevExpress.XtraBars.BarManager(this.components);
            this.barToolStrip = new DevExpress.XtraBars.Bar();
            this.fileMenuItem = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOpen = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.genStringsMenuItem = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemFromXml = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemFromScripts = new DevExpress.XtraBars.BarButtonItem();
            this.barMenuStrip = new DevExpress.XtraBars.Bar();
            this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemEncode = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItemModId = new DevExpress.XtraBars.BarEditItem();
            this.repoItemTextEditModIDs = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barEditItemLanguage = new DevExpress.XtraBars.BarEditItem();
            this.repoItemComboBoxLanguage = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlLanguages)).BeginInit();
            this.tabControlLanguages.SuspendLayout();
            this.xtraTabPageAllLanguages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStringsEncoder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStringsEncoder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemLocalizationMemoEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerStringEncoder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemTextEditModIDs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemComboBoxLanguage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlLanguages
            // 
            this.tabControlLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLanguages.Location = new System.Drawing.Point(0, 52);
            this.tabControlLanguages.Name = "tabControlLanguages";
            this.tabControlLanguages.SelectedTabPage = this.xtraTabPageAllLanguages;
            this.tabControlLanguages.Size = new System.Drawing.Size(1184, 485);
            this.tabControlLanguages.TabIndex = 0;
            this.tabControlLanguages.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageAllLanguages});
            this.tabControlLanguages.Selected += new DevExpress.XtraTab.TabPageEventHandler(this.tabControlLanguages_Selected);
            // 
            // xtraTabPageAllLanguages
            // 
            this.xtraTabPageAllLanguages.Controls.Add(this.gridControlStringsEncoder);
            this.xtraTabPageAllLanguages.Name = "xtraTabPageAllLanguages";
            this.xtraTabPageAllLanguages.Size = new System.Drawing.Size(1182, 456);
            this.xtraTabPageAllLanguages.Text = "All Languages";
            // 
            // gridControlStringsEncoder
            // 
            this.gridControlStringsEncoder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlStringsEncoder.Location = new System.Drawing.Point(0, 0);
            this.gridControlStringsEncoder.MainView = this.gridViewStringsEncoder;
            this.gridControlStringsEncoder.Name = "gridControlStringsEncoder";
            this.gridControlStringsEncoder.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoItemLocalizationMemoEdit});
            this.gridControlStringsEncoder.Size = new System.Drawing.Size(1182, 456);
            this.gridControlStringsEncoder.TabIndex = 0;
            this.gridControlStringsEncoder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStringsEncoder});
            this.gridControlStringsEncoder.Visible = false;
            // 
            // gridViewStringsEncoder
            // 
            this.gridViewStringsEncoder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnHexKey,
            this.gridColumnStringKey,
            this.gridColumnLocalization});
            this.gridViewStringsEncoder.GridControl = this.gridControlStringsEncoder;
            this.gridViewStringsEncoder.Name = "gridViewStringsEncoder";
            this.gridViewStringsEncoder.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridViewStringsEncoder.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.gridViewStringsEncoder.OptionsEditForm.EditFormColumnCount = 2;
            this.gridViewStringsEncoder.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewStringsEncoder.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewStringsEncoder.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewStringsEncoder.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewStringsEncoder.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewStringsEncoder.OptionsView.ShowFooter = true;
            this.gridViewStringsEncoder.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewStringsEncoder_InitNewRow);
            this.gridViewStringsEncoder.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gridViewStringsEncoder_RowDeleted);
            this.gridViewStringsEncoder.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridViewStringsEncoder_ValidateRow);
            this.gridViewStringsEncoder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewStringsEncoder_KeyDown);
            // 
            // gridColumnId
            // 
            this.gridColumnId.Caption = "Id";
            this.gridColumnId.FieldName = "Id";
            this.gridColumnId.Name = "gridColumnId";
            this.gridColumnId.OptionsColumn.ReadOnly = true;
            this.gridColumnId.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnId.Visible = true;
            this.gridColumnId.VisibleIndex = 0;
            this.gridColumnId.Width = 107;
            // 
            // gridColumnHexKey
            // 
            this.gridColumnHexKey.Caption = "Hex Key";
            this.gridColumnHexKey.FieldName = "HexKey";
            this.gridColumnHexKey.Name = "gridColumnHexKey";
            this.gridColumnHexKey.OptionsColumn.ReadOnly = true;
            this.gridColumnHexKey.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnHexKey.Visible = true;
            this.gridColumnHexKey.VisibleIndex = 1;
            this.gridColumnHexKey.Width = 113;
            // 
            // gridColumnStringKey
            // 
            this.gridColumnStringKey.Caption = "String Key";
            this.gridColumnStringKey.FieldName = "StringKey";
            this.gridColumnStringKey.Name = "gridColumnStringKey";
            this.gridColumnStringKey.Visible = true;
            this.gridColumnStringKey.VisibleIndex = 2;
            this.gridColumnStringKey.Width = 119;
            // 
            // gridColumnLocalization
            // 
            this.gridColumnLocalization.Caption = "Localization";
            this.gridColumnLocalization.ColumnEdit = this.repoItemLocalizationMemoEdit;
            this.gridColumnLocalization.FieldName = "Localization";
            this.gridColumnLocalization.Name = "gridColumnLocalization";
            this.gridColumnLocalization.Visible = true;
            this.gridColumnLocalization.VisibleIndex = 3;
            this.gridColumnLocalization.Width = 818;
            // 
            // repoItemLocalizationMemoEdit
            // 
            this.repoItemLocalizationMemoEdit.Name = "repoItemLocalizationMemoEdit";
            // 
            // barManagerStringEncoder
            // 
            this.barManagerStringEncoder.AllowCustomization = false;
            this.barManagerStringEncoder.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barToolStrip,
            this.barMenuStrip});
            this.barManagerStringEncoder.DockControls.Add(this.barDockControlTop);
            this.barManagerStringEncoder.DockControls.Add(this.barDockControlBottom);
            this.barManagerStringEncoder.DockControls.Add(this.barDockControlLeft);
            this.barManagerStringEncoder.DockControls.Add(this.barDockControlRight);
            this.barManagerStringEncoder.Form = this;
            this.barManagerStringEncoder.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.fileMenuItem,
            this.genStringsMenuItem,
            this.barButtonItemOpen,
            this.barButtonItemImport,
            this.barButtonItemNew,
            this.barButtonItemFromXml,
            this.barButtonItemFromScripts,
            this.barButtonItemSave,
            this.barButtonItemEncode,
            this.barEditItemModId,
            this.barEditItemLanguage});
            this.barManagerStringEncoder.MaxItemId = 12;
            this.barManagerStringEncoder.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoItemTextEditModIDs,
            this.repoItemComboBoxLanguage});
            // 
            // barToolStrip
            // 
            this.barToolStrip.BarName = "Tool Strip";
            this.barToolStrip.DockCol = 0;
            this.barToolStrip.DockRow = 0;
            this.barToolStrip.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barToolStrip.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fileMenuItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.genStringsMenuItem, true)});
            this.barToolStrip.OptionsBar.AllowQuickCustomization = false;
            this.barToolStrip.OptionsBar.DrawDragBorder = false;
            this.barToolStrip.Text = "Tool Strip";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.Caption = "File";
            this.fileMenuItem.Id = 0;
            this.fileMenuItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemImport)});
            this.fileMenuItem.Name = "fileMenuItem";
            // 
            // barButtonItemNew
            // 
            this.barButtonItemNew.Caption = "New";
            this.barButtonItemNew.Id = 5;
            this.barButtonItemNew.Name = "barButtonItemNew";
            this.barButtonItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemNew_ItemClick);
            // 
            // barButtonItemOpen
            // 
            this.barButtonItemOpen.Caption = "Open";
            this.barButtonItemOpen.Id = 3;
            this.barButtonItemOpen.Name = "barButtonItemOpen";
            this.barButtonItemOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOpen_ItemClick);
            // 
            // barButtonItemImport
            // 
            this.barButtonItemImport.Caption = "Import";
            this.barButtonItemImport.Id = 4;
            this.barButtonItemImport.Name = "barButtonItemImport";
            this.barButtonItemImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemImport_ItemClick);
            // 
            // genStringsMenuItem
            // 
            this.genStringsMenuItem.Caption = "Generate Strings";
            this.genStringsMenuItem.Id = 1;
            this.genStringsMenuItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemFromXml),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemFromScripts)});
            this.genStringsMenuItem.Name = "genStringsMenuItem";
            // 
            // barButtonItemFromXml
            // 
            this.barButtonItemFromXml.Caption = "From XML";
            this.barButtonItemFromXml.Id = 6;
            this.barButtonItemFromXml.Name = "barButtonItemFromXml";
            this.barButtonItemFromXml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemFromXml_ItemClick);
            // 
            // barButtonItemFromScripts
            // 
            this.barButtonItemFromScripts.Caption = "From Scripts";
            this.barButtonItemFromScripts.Id = 7;
            this.barButtonItemFromScripts.Name = "barButtonItemFromScripts";
            this.barButtonItemFromScripts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemFromScripts_ItemClick);
            // 
            // barMenuStrip
            // 
            this.barMenuStrip.BarName = "Button Menu";
            this.barMenuStrip.DockCol = 0;
            this.barMenuStrip.DockRow = 1;
            this.barMenuStrip.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenuStrip.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemEncode),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEditItemModId),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEditItemLanguage)});
            this.barMenuStrip.OptionsBar.AllowQuickCustomization = false;
            this.barMenuStrip.OptionsBar.DrawDragBorder = false;
            this.barMenuStrip.Text = "Button Menu";
            // 
            // barButtonItemSave
            // 
            this.barButtonItemSave.Caption = "Save";
            this.barButtonItemSave.Id = 8;
            this.barButtonItemSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemSave.ImageOptions.SvgImage")));
            this.barButtonItemSave.Name = "barButtonItemSave";
            this.barButtonItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSave_ItemClick);
            // 
            // barButtonItemEncode
            // 
            this.barButtonItemEncode.Caption = "Encode";
            this.barButtonItemEncode.Id = 9;
            this.barButtonItemEncode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemEncode.ImageOptions.SvgImage")));
            this.barButtonItemEncode.Name = "barButtonItemEncode";
            this.barButtonItemEncode.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemEncode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemEncode_ItemClick);
            // 
            // barEditItemModId
            // 
            this.barEditItemModId.Caption = "Mod ID (seperate multiple IDs with \";\")";
            this.barEditItemModId.Edit = this.repoItemTextEditModIDs;
            this.barEditItemModId.EditWidth = 150;
            this.barEditItemModId.Id = 10;
            this.barEditItemModId.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barEditItemModId.ImageOptions.SvgImage")));
            this.barEditItemModId.Name = "barEditItemModId";
            this.barEditItemModId.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repoItemTextEditModIDs
            // 
            this.repoItemTextEditModIDs.AutoHeight = false;
            this.repoItemTextEditModIDs.Name = "repoItemTextEditModIDs";
            this.repoItemTextEditModIDs.Leave += new System.EventHandler(this.repoItemTextEditModIDs_Leave);
            // 
            // barEditItemLanguage
            // 
            this.barEditItemLanguage.Caption = "Language:";
            this.barEditItemLanguage.Edit = this.repoItemComboBoxLanguage;
            this.barEditItemLanguage.EditWidth = 150;
            this.barEditItemLanguage.Id = 11;
            this.barEditItemLanguage.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barEditItemLanguage.ImageOptions.SvgImage")));
            this.barEditItemLanguage.Name = "barEditItemLanguage";
            this.barEditItemLanguage.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repoItemComboBoxLanguage
            // 
            this.repoItemComboBoxLanguage.AutoHeight = false;
            this.repoItemComboBoxLanguage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoItemComboBoxLanguage.Items.AddRange(new object[] {
            "All Languages",
            "Separate Languages"});
            this.repoItemComboBoxLanguage.Name = "repoItemComboBoxLanguage";
            this.repoItemComboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.repoItemComboBoxLanguage_SelectedIndexChanged);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManagerStringEncoder;
            this.barDockControlTop.Size = new System.Drawing.Size(1184, 52);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 537);
            this.barDockControlBottom.Manager = this.barManagerStringEncoder;
            this.barDockControlBottom.Size = new System.Drawing.Size(1184, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 52);
            this.barDockControlLeft.Manager = this.barManagerStringEncoder;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 485);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1184, 52);
            this.barDockControlRight.Manager = this.barManagerStringEncoder;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 485);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // StringEncoderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 537);
            this.Controls.Add(this.tabControlLanguages);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("StringEncoderView.IconOptions.Icon")));
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("StringEncoderView.IconOptions.Image")));
            this.MinimumSize = new System.Drawing.Size(1184, 39);
            this.Name = "StringEncoderView";
            this.Text = "Wolvenkit DX String Encoder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tabControlLanguages)).EndInit();
            this.tabControlLanguages.ResumeLayout(false);
            this.xtraTabPageAllLanguages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStringsEncoder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStringsEncoder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemLocalizationMemoEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerStringEncoder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemTextEditModIDs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemComboBoxLanguage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraTab.XtraTabControl tabControlLanguages;
		private DevExpress.XtraGrid.GridControl gridControlStringsEncoder;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStringsEncoder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnHexKey;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStringKey;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLocalization;
        private DevExpress.XtraBars.BarManager barManagerStringEncoder;
        private DevExpress.XtraBars.Bar barToolStrip;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem fileMenuItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItemNew;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOpen;
        private DevExpress.XtraBars.BarButtonItem barButtonItemImport;
        private DevExpress.XtraBars.BarSubItem genStringsMenuItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItemFromXml;
        private DevExpress.XtraBars.BarButtonItem barButtonItemFromScripts;
        private DevExpress.XtraBars.Bar barMenuStrip;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItemEncode;
        private DevExpress.XtraBars.BarEditItem barEditItemModId;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoItemTextEditModIDs;
        private DevExpress.XtraBars.BarEditItem barEditItemLanguage;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repoItemComboBoxLanguage;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repoItemLocalizationMemoEdit;
        private XtraTabPage xtraTabPageAllLanguages;
    }
}