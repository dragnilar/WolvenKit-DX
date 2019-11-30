using System.ComponentModel;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WolvenKit
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinOurDiscordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.witcherIIIModdingToolLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordStepsToReproduceBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutRedkit2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.statusLBL = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.richpresenceworker = new System.ComponentModel.BackgroundWorker();
            this.ribbonControlMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemNewMod = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOpenMod = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRecent = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSaveAll = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddFileFromBundle = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBuildMod = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLaunch = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuLaunch = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItemDebug = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCustomParams = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBuildAndLaunch = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQuickBuild = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddModFile = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuImport = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItemFBXCollisons = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNvidiaClothFile = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddNewFile = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuNewFile = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barSubItemMod = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemScriptMod = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemWwiseMod = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChunkFileMod = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemDLC = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemScriptDLC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemWwiseDLC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChunkFileDLC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCreatePackInstaller = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReload = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemProjectSettings = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPackageInstaller = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSaveExplorer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemStringsEncoder = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemGameDebugger = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMenuCreator = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDumpGameAssets = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOptions = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItemRenderW2Mesh = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPageHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupBuild = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageProjectTools = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupProject = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupTools = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.menuStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLaunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNewFile)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.buildDateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1280, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "topMS";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modExplorerToolStripMenuItem,
            this.outputToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // modExplorerToolStripMenuItem
            // 
            this.modExplorerToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.FileGroup_10135_16x;
            this.modExplorerToolStripMenuItem.Name = "modExplorerToolStripMenuItem";
            this.modExplorerToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.modExplorerToolStripMenuItem.Text = "Mod explorer";
            this.modExplorerToolStripMenuItem.Click += new System.EventHandler(this.modExplorerToolStripMenuItem_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.FileGroup_10135_16x;
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.outputToolStripMenuItem.Text = "Output";
            this.outputToolStripMenuItem.Click += new System.EventHandler(this.OutputToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joinOurDiscordToolStripMenuItem,
            this.tutorialsToolStripMenuItem,
            this.witcherIIIModdingToolLicenseToolStripMenuItem,
            this.reportABugToolStripMenuItem,
            this.recordStepsToReproduceBugToolStripMenuItem,
            this.toolStripSeparator7,
            this.aboutRedkit2ToolStripMenuItem,
            this.donateToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // joinOurDiscordToolStripMenuItem
            // 
            this.joinOurDiscordToolStripMenuItem.Image = global::WolvenKit.Properties.Resources._2c21aeda16de354ba5334551a883b481;
            this.joinOurDiscordToolStripMenuItem.Name = "joinOurDiscordToolStripMenuItem";
            this.joinOurDiscordToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.joinOurDiscordToolStripMenuItem.Text = "Join our discord";
            this.joinOurDiscordToolStripMenuItem.Click += new System.EventHandler(this.joinOurDiscordToolStripMenuItem_Click_1);
            // 
            // tutorialsToolStripMenuItem
            // 
            this.tutorialsToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.info_icon_23818;
            this.tutorialsToolStripMenuItem.Name = "tutorialsToolStripMenuItem";
            this.tutorialsToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.tutorialsToolStripMenuItem.Text = "Witcherscript documentation";
            this.tutorialsToolStripMenuItem.Click += new System.EventHandler(this.WitcherScriptToolStripMenuItem_Click);
            // 
            // witcherIIIModdingToolLicenseToolStripMenuItem
            // 
            this.witcherIIIModdingToolLicenseToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.witcher3_101;
            this.witcherIIIModdingToolLicenseToolStripMenuItem.Name = "witcherIIIModdingToolLicenseToolStripMenuItem";
            this.witcherIIIModdingToolLicenseToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.witcherIIIModdingToolLicenseToolStripMenuItem.Text = "Witcher III Modding Tool License";
            this.witcherIIIModdingToolLicenseToolStripMenuItem.Click += new System.EventHandler(this.witcherIIIModdingToolLicenseToolStripMenuItem_Click);
            // 
            // reportABugToolStripMenuItem
            // 
            this.reportABugToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.mail;
            this.reportABugToolStripMenuItem.Name = "reportABugToolStripMenuItem";
            this.reportABugToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.reportABugToolStripMenuItem.Text = "Report a bug";
            this.reportABugToolStripMenuItem.Click += new System.EventHandler(this.ReportABugToolStripMenuItem_Click);
            // 
            // recordStepsToReproduceBugToolStripMenuItem
            // 
            this.recordStepsToReproduceBugToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.player_record;
            this.recordStepsToReproduceBugToolStripMenuItem.Name = "recordStepsToReproduceBugToolStripMenuItem";
            this.recordStepsToReproduceBugToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.recordStepsToReproduceBugToolStripMenuItem.Text = "Record steps to reproduce bug";
            this.recordStepsToReproduceBugToolStripMenuItem.Click += new System.EventHandler(this.RecordStepsToReproduceBugToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(243, 6);
            // 
            // aboutRedkit2ToolStripMenuItem
            // 
            this.aboutRedkit2ToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.info_icon_23818;
            this.aboutRedkit2ToolStripMenuItem.Name = "aboutRedkit2ToolStripMenuItem";
            this.aboutRedkit2ToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.aboutRedkit2ToolStripMenuItem.Text = "About Wolven kit";
            this.aboutRedkit2ToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("donateToolStripMenuItem.Image")));
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // buildDateToolStripMenuItem
            // 
            this.buildDateToolStripMenuItem.Enabled = false;
            this.buildDateToolStripMenuItem.Name = "buildDateToolStripMenuItem";
            this.buildDateToolStripMenuItem.ShowShortcutKeys = false;
            this.buildDateToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.buildDateToolStripMenuItem.Text = "Build date";
            // 
            // dockPanel
            // 
            this.dockPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel.Location = new System.Drawing.Point(0, 187);
            this.dockPanel.Margin = new System.Windows.Forms.Padding(2);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.ShowDocumentIcon = true;
            this.dockPanel.Size = new System.Drawing.Size(1280, 558);
            this.dockPanel.TabIndex = 9;
            this.dockPanel.ActiveDocumentChanged += new System.EventHandler(this.dockPanel_ActiveDocumentChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLBL,
            this.toolStripSeparator9,
            this.toolStripProgressBar1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 745);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1280, 25);
            this.toolStrip2.TabIndex = 12;
            this.toolStrip2.Text = "bottomTS";
            // 
            // statusLBL
            // 
            this.statusLBL.Name = "statusLBL";
            this.statusLBL.Size = new System.Drawing.Size(39, 22);
            this.statusLBL.Text = "Ready";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            this.toolStripProgressBar1.Visible = false;
            // 
            // richpresenceworker
            // 
            this.richpresenceworker.WorkerSupportsCancellation = true;
            this.richpresenceworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.richpresenceworker_DoWork);
            this.richpresenceworker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.richpresenceworker_ProgressChanged);
            this.richpresenceworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.richpresenceworker_RunWorkerCompleted);
            // 
            // ribbonControlMain
            // 
            this.ribbonControlMain.ExpandCollapseItem.Id = 0;
            this.ribbonControlMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControlMain.ExpandCollapseItem,
            this.ribbonControlMain.SearchEditItem,
            this.barButtonItemNewMod,
            this.barButtonItemOpenMod,
            this.barButtonItemRecent,
            this.barButtonItemSave,
            this.barButtonItemSaveAll,
            this.barButtonItemAddFileFromBundle,
            this.barButtonItemBuildMod,
            this.barButtonItemLaunch,
            this.barButtonItemDebug,
            this.barButtonItemCustomParams,
            this.barButtonItemBuildAndLaunch,
            this.barButtonItemQuickBuild,
            this.barButtonItemAddModFile,
            this.barButtonItemImport,
            this.barButtonItemExport,
            this.barButtonItemFBXCollisons,
            this.barButtonItemNvidiaClothFile,
            this.barButtonItemAddNewFile,
            this.barSubItemMod,
            this.barSubItemDLC,
            this.barButtonItemScriptMod,
            this.barButtonItemWwiseMod,
            this.barButtonItemChunkFileMod,
            this.barButtonItemScriptDLC,
            this.barButtonItemWwiseDLC,
            this.barButtonItemChunkFileDLC,
            this.barButtonItemCreatePackInstaller,
            this.barButtonItemReload,
            this.barButtonItemProjectSettings,
            this.barButtonItemPackageInstaller,
            this.barButtonItemSaveExplorer,
            this.barButtonItemStringsEncoder,
            this.barButtonItemGameDebugger,
            this.barButtonItemMenuCreator,
            this.barButtonItemDumpGameAssets,
            this.barButtonItemOptions,
            this.barCheckItemRenderW2Mesh});
            this.ribbonControlMain.Location = new System.Drawing.Point(0, 24);
            this.ribbonControlMain.MaxItemId = 42;
            this.ribbonControlMain.Name = "ribbonControlMain";
            this.ribbonControlMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageHome,
            this.ribbonPageProjectTools});
            this.ribbonControlMain.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControlMain.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControlMain.ShowQatLocationSelector = false;
            this.ribbonControlMain.ShowToolbarCustomizeItem = false;
            this.ribbonControlMain.Size = new System.Drawing.Size(1280, 158);
            this.ribbonControlMain.Toolbar.ShowCustomizeItem = false;
            // 
            // barButtonItemNewMod
            // 
            this.barButtonItemNewMod.Caption = "Create New Mod";
            this.barButtonItemNewMod.Id = 1;
            this.barButtonItemNewMod.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemNewMod.ImageOptions.SvgImage")));
            this.barButtonItemNewMod.Name = "barButtonItemNewMod";
            this.barButtonItemNewMod.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemNewMod_ItemClick);
            // 
            // barButtonItemOpenMod
            // 
            this.barButtonItemOpenMod.Caption = "Open Mod";
            this.barButtonItemOpenMod.Id = 2;
            this.barButtonItemOpenMod.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemOpenMod.ImageOptions.SvgImage")));
            this.barButtonItemOpenMod.Name = "barButtonItemOpenMod";
            this.barButtonItemOpenMod.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOpenMod_ItemClick);
            // 
            // barButtonItemRecent
            // 
            this.barButtonItemRecent.Caption = "Recent Files";
            this.barButtonItemRecent.Id = 3;
            this.barButtonItemRecent.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemRecent.ImageOptions.SvgImage")));
            this.barButtonItemRecent.Name = "barButtonItemRecent";
            this.barButtonItemRecent.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemRecent_ItemClick);
            // 
            // barButtonItemSave
            // 
            this.barButtonItemSave.Caption = "Save";
            this.barButtonItemSave.Id = 4;
            this.barButtonItemSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemSave.ImageOptions.SvgImage")));
            this.barButtonItemSave.Name = "barButtonItemSave";
            this.barButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSave_ItemClick);
            // 
            // barButtonItemSaveAll
            // 
            this.barButtonItemSaveAll.Caption = "Save All";
            this.barButtonItemSaveAll.Id = 5;
            this.barButtonItemSaveAll.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemSaveAll.ImageOptions.SvgImage")));
            this.barButtonItemSaveAll.Name = "barButtonItemSaveAll";
            this.barButtonItemSaveAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSaveAll_ItemClick);
            // 
            // barButtonItemAddFileFromBundle
            // 
            this.barButtonItemAddFileFromBundle.Caption = "Add File From Bundle";
            this.barButtonItemAddFileFromBundle.Id = 6;
            this.barButtonItemAddFileFromBundle.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemAddFileFromBundle.ImageOptions.SvgImage")));
            this.barButtonItemAddFileFromBundle.Name = "barButtonItemAddFileFromBundle";
            this.barButtonItemAddFileFromBundle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAddFileFromBundle_ItemClick);
            // 
            // barButtonItemBuildMod
            // 
            this.barButtonItemBuildMod.Caption = "Build Mod";
            this.barButtonItemBuildMod.Id = 7;
            this.barButtonItemBuildMod.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemBuildMod.ImageOptions.SvgImage")));
            this.barButtonItemBuildMod.Name = "barButtonItemBuildMod";
            this.barButtonItemBuildMod.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemBuildMod_ItemClick);
            // 
            // barButtonItemLaunch
            // 
            this.barButtonItemLaunch.ActAsDropDown = true;
            this.barButtonItemLaunch.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItemLaunch.Caption = "Launch Game";
            this.barButtonItemLaunch.DropDownControl = this.popupMenuLaunch;
            this.barButtonItemLaunch.Id = 8;
            this.barButtonItemLaunch.ImageOptions.Image = global::WolvenKit.Properties.Resources.witcher3_101;
            this.barButtonItemLaunch.ImageOptions.LargeImage = global::WolvenKit.Properties.Resources.witcher3_101;
            this.barButtonItemLaunch.Name = "barButtonItemLaunch";
            // 
            // popupMenuLaunch
            // 
            this.popupMenuLaunch.ItemLinks.Add(this.barButtonItemDebug);
            this.popupMenuLaunch.ItemLinks.Add(this.barButtonItemCustomParams);
            this.popupMenuLaunch.ItemLinks.Add(this.barButtonItemBuildAndLaunch);
            this.popupMenuLaunch.Name = "popupMenuLaunch";
            this.popupMenuLaunch.Ribbon = this.ribbonControlMain;
            // 
            // barButtonItemDebug
            // 
            this.barButtonItemDebug.Caption = "Launch Game For Debugging";
            this.barButtonItemDebug.Id = 9;
            this.barButtonItemDebug.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemDebug.ImageOptions.SvgImage")));
            this.barButtonItemDebug.Name = "barButtonItemDebug";
            this.barButtonItemDebug.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDebug_ItemClick);
            // 
            // barButtonItemCustomParams
            // 
            this.barButtonItemCustomParams.Caption = "Launch with Custom Parameters";
            this.barButtonItemCustomParams.Id = 10;
            this.barButtonItemCustomParams.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemCustomParams.ImageOptions.SvgImage")));
            this.barButtonItemCustomParams.Name = "barButtonItemCustomParams";
            this.barButtonItemCustomParams.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCustomParams_ItemClick);
            // 
            // barButtonItemBuildAndLaunch
            // 
            this.barButtonItemBuildAndLaunch.Caption = "Build And Launch Game";
            this.barButtonItemBuildAndLaunch.Id = 11;
            this.barButtonItemBuildAndLaunch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemBuildAndLaunch.ImageOptions.SvgImage")));
            this.barButtonItemBuildAndLaunch.Name = "barButtonItemBuildAndLaunch";
            this.barButtonItemBuildAndLaunch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemBuildAndLaunch_ItemClick);
            // 
            // barButtonItemQuickBuild
            // 
            this.barButtonItemQuickBuild.Caption = "Quick Build";
            this.barButtonItemQuickBuild.Id = 12;
            this.barButtonItemQuickBuild.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemQuickBuild.ImageOptions.SvgImage")));
            this.barButtonItemQuickBuild.Name = "barButtonItemQuickBuild";
            this.barButtonItemQuickBuild.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQuickBuild_ItemClick);
            // 
            // barButtonItemAddModFile
            // 
            this.barButtonItemAddModFile.Caption = "Add File From Another Mod";
            this.barButtonItemAddModFile.Id = 13;
            this.barButtonItemAddModFile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemAddModFile.ImageOptions.SvgImage")));
            this.barButtonItemAddModFile.Name = "barButtonItemAddModFile";
            this.barButtonItemAddModFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAddModFile_ItemClick);
            // 
            // barButtonItemImport
            // 
            this.barButtonItemImport.ActAsDropDown = true;
            this.barButtonItemImport.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItemImport.Caption = "Import";
            this.barButtonItemImport.DropDownControl = this.popupMenuImport;
            this.barButtonItemImport.Id = 15;
            this.barButtonItemImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemImport.ImageOptions.SvgImage")));
            this.barButtonItemImport.Name = "barButtonItemImport";
            // 
            // popupMenuImport
            // 
            this.popupMenuImport.ItemLinks.Add(this.barButtonItemFBXCollisons);
            this.popupMenuImport.ItemLinks.Add(this.barButtonItemNvidiaClothFile);
            this.popupMenuImport.Name = "popupMenuImport";
            this.popupMenuImport.Ribbon = this.ribbonControlMain;
            // 
            // barButtonItemFBXCollisons
            // 
            this.barButtonItemFBXCollisons.Caption = "FBX With Collisons";
            this.barButtonItemFBXCollisons.Id = 17;
            this.barButtonItemFBXCollisons.Name = "barButtonItemFBXCollisons";
            this.barButtonItemFBXCollisons.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemFBXCollisons_ItemClick);
            // 
            // barButtonItemNvidiaClothFile
            // 
            this.barButtonItemNvidiaClothFile.Caption = "Nvidia Cloth File";
            this.barButtonItemNvidiaClothFile.Id = 18;
            this.barButtonItemNvidiaClothFile.Name = "barButtonItemNvidiaClothFile";
            this.barButtonItemNvidiaClothFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemNvidiaClothFile_ItemClick);
            // 
            // barButtonItemExport
            // 
            this.barButtonItemExport.Caption = "Export";
            this.barButtonItemExport.Id = 16;
            this.barButtonItemExport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemExport.ImageOptions.SvgImage")));
            this.barButtonItemExport.Name = "barButtonItemExport";
            this.barButtonItemExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExport_ItemClick);
            // 
            // barButtonItemAddNewFile
            // 
            this.barButtonItemAddNewFile.ActAsDropDown = true;
            this.barButtonItemAddNewFile.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItemAddNewFile.Caption = "Add New File";
            this.barButtonItemAddNewFile.DropDownControl = this.popupMenuNewFile;
            this.barButtonItemAddNewFile.Id = 19;
            this.barButtonItemAddNewFile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemAddNewFile.ImageOptions.SvgImage")));
            this.barButtonItemAddNewFile.Name = "barButtonItemAddNewFile";
            // 
            // popupMenuNewFile
            // 
            this.popupMenuNewFile.ItemLinks.Add(this.barSubItemMod);
            this.popupMenuNewFile.ItemLinks.Add(this.barSubItemDLC);
            this.popupMenuNewFile.Name = "popupMenuNewFile";
            this.popupMenuNewFile.Ribbon = this.ribbonControlMain;
            // 
            // barSubItemMod
            // 
            this.barSubItemMod.Caption = "Mod";
            this.barSubItemMod.Id = 22;
            this.barSubItemMod.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemScriptMod),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemWwiseMod),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemChunkFileMod)});
            this.barSubItemMod.Name = "barSubItemMod";
            // 
            // barButtonItemScriptMod
            // 
            this.barButtonItemScriptMod.Caption = "Script";
            this.barButtonItemScriptMod.Id = 24;
            this.barButtonItemScriptMod.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemScriptMod.ImageOptions.SvgImage")));
            this.barButtonItemScriptMod.Name = "barButtonItemScriptMod";
            this.barButtonItemScriptMod.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemScriptMod_ItemClick);
            // 
            // barButtonItemWwiseMod
            // 
            this.barButtonItemWwiseMod.Caption = "Wwise Sound(bank)";
            this.barButtonItemWwiseMod.Id = 25;
            this.barButtonItemWwiseMod.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemWwiseMod.ImageOptions.SvgImage")));
            this.barButtonItemWwiseMod.Name = "barButtonItemWwiseMod";
            this.barButtonItemWwiseMod.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemWwiseMod_ItemClick);
            // 
            // barButtonItemChunkFileMod
            // 
            this.barButtonItemChunkFileMod.Caption = "Chunk file";
            this.barButtonItemChunkFileMod.Id = 26;
            this.barButtonItemChunkFileMod.Name = "barButtonItemChunkFileMod";
            this.barButtonItemChunkFileMod.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemChunkFileMod.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemChunkFileMod_ItemClick);
            // 
            // barSubItemDLC
            // 
            this.barSubItemDLC.Caption = "DLC";
            this.barSubItemDLC.Id = 23;
            this.barSubItemDLC.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemScriptDLC),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemWwiseDLC),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemChunkFileDLC)});
            this.barSubItemDLC.Name = "barSubItemDLC";
            // 
            // barButtonItemScriptDLC
            // 
            this.barButtonItemScriptDLC.Caption = "Script";
            this.barButtonItemScriptDLC.Id = 27;
            this.barButtonItemScriptDLC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemScriptDLC.ImageOptions.SvgImage")));
            this.barButtonItemScriptDLC.Name = "barButtonItemScriptDLC";
            this.barButtonItemScriptDLC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemScriptDLC_ItemClick);
            // 
            // barButtonItemWwiseDLC
            // 
            this.barButtonItemWwiseDLC.Caption = "WWise Sound(bank)";
            this.barButtonItemWwiseDLC.Id = 28;
            this.barButtonItemWwiseDLC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemWwiseDLC.ImageOptions.SvgImage")));
            this.barButtonItemWwiseDLC.Name = "barButtonItemWwiseDLC";
            this.barButtonItemWwiseDLC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemWwiseDLC_ItemClick);
            // 
            // barButtonItemChunkFileDLC
            // 
            this.barButtonItemChunkFileDLC.Caption = "Chunk file";
            this.barButtonItemChunkFileDLC.Id = 29;
            this.barButtonItemChunkFileDLC.Name = "barButtonItemChunkFileDLC";
            this.barButtonItemChunkFileDLC.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemChunkFileDLC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemChunkFileDLC_ItemClick);
            // 
            // barButtonItemCreatePackInstaller
            // 
            this.barButtonItemCreatePackInstaller.Caption = "Create Package Installer";
            this.barButtonItemCreatePackInstaller.Id = 30;
            this.barButtonItemCreatePackInstaller.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemCreatePackInstaller.ImageOptions.SvgImage")));
            this.barButtonItemCreatePackInstaller.Name = "barButtonItemCreatePackInstaller";
            this.barButtonItemCreatePackInstaller.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCreatePackInstaller_ItemClick);
            // 
            // barButtonItemReload
            // 
            this.barButtonItemReload.Caption = "Reload Project";
            this.barButtonItemReload.Id = 31;
            this.barButtonItemReload.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemReload.ImageOptions.SvgImage")));
            this.barButtonItemReload.Name = "barButtonItemReload";
            this.barButtonItemReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemReload_ItemClick);
            // 
            // barButtonItemProjectSettings
            // 
            this.barButtonItemProjectSettings.Caption = "Project Settings";
            this.barButtonItemProjectSettings.Id = 32;
            this.barButtonItemProjectSettings.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemProjectSettings.ImageOptions.SvgImage")));
            this.barButtonItemProjectSettings.Name = "barButtonItemProjectSettings";
            this.barButtonItemProjectSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemProjectSettings_ItemClick);
            // 
            // barButtonItemPackageInstaller
            // 
            this.barButtonItemPackageInstaller.Caption = "Package Installer";
            this.barButtonItemPackageInstaller.Id = 33;
            this.barButtonItemPackageInstaller.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemPackageInstaller.ImageOptions.SvgImage")));
            this.barButtonItemPackageInstaller.Name = "barButtonItemPackageInstaller";
            this.barButtonItemPackageInstaller.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemPackageInstaller_ItemClick);
            // 
            // barButtonItemSaveExplorer
            // 
            this.barButtonItemSaveExplorer.Caption = "Save Explorer";
            this.barButtonItemSaveExplorer.Id = 34;
            this.barButtonItemSaveExplorer.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemSaveExplorer.ImageOptions.SvgImage")));
            this.barButtonItemSaveExplorer.Name = "barButtonItemSaveExplorer";
            this.barButtonItemSaveExplorer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSaveExplorer_ItemClick);
            // 
            // barButtonItemStringsEncoder
            // 
            this.barButtonItemStringsEncoder.Caption = "Strings Encoder GUI";
            this.barButtonItemStringsEncoder.Id = 35;
            this.barButtonItemStringsEncoder.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemStringsEncoder.ImageOptions.SvgImage")));
            this.barButtonItemStringsEncoder.Name = "barButtonItemStringsEncoder";
            this.barButtonItemStringsEncoder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemStringsEncoder_ItemClick);
            // 
            // barButtonItemGameDebugger
            // 
            this.barButtonItemGameDebugger.Caption = "Game Debugger";
            this.barButtonItemGameDebugger.Id = 36;
            this.barButtonItemGameDebugger.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemGameDebugger.ImageOptions.SvgImage")));
            this.barButtonItemGameDebugger.Name = "barButtonItemGameDebugger";
            this.barButtonItemGameDebugger.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemGameDebugger_ItemClick);
            // 
            // barButtonItemMenuCreator
            // 
            this.barButtonItemMenuCreator.Caption = "Menu Creator";
            this.barButtonItemMenuCreator.Id = 37;
            this.barButtonItemMenuCreator.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemMenuCreator.ImageOptions.SvgImage")));
            this.barButtonItemMenuCreator.Name = "barButtonItemMenuCreator";
            this.barButtonItemMenuCreator.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemMenuCreator_ItemClick);
            // 
            // barButtonItemDumpGameAssets
            // 
            this.barButtonItemDumpGameAssets.Caption = "Dump Game Assets";
            this.barButtonItemDumpGameAssets.Id = 38;
            this.barButtonItemDumpGameAssets.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemDumpGameAssets.ImageOptions.SvgImage")));
            this.barButtonItemDumpGameAssets.Name = "barButtonItemDumpGameAssets";
            this.barButtonItemDumpGameAssets.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDumpGameAssets_ItemClick);
            // 
            // barButtonItemOptions
            // 
            this.barButtonItemOptions.Caption = "Options";
            this.barButtonItemOptions.Id = 40;
            this.barButtonItemOptions.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemOptions.ImageOptions.SvgImage")));
            this.barButtonItemOptions.Name = "barButtonItemOptions";
            this.barButtonItemOptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOptions_ItemClick);
            // 
            // barCheckItemRenderW2Mesh
            // 
            this.barCheckItemRenderW2Mesh.Caption = "Render W2 Mesh";
            this.barCheckItemRenderW2Mesh.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.barCheckItemRenderW2Mesh.Id = 41;
            this.barCheckItemRenderW2Mesh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barCheckItemRenderW2Mesh.ImageOptions.SvgImage")));
            this.barCheckItemRenderW2Mesh.Name = "barCheckItemRenderW2Mesh";
            this.barCheckItemRenderW2Mesh.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemRenderW2Mesh_CheckedChanged);
            // 
            // ribbonPageHome
            // 
            this.ribbonPageHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupFile,
            this.ribbonPageGroupBuild});
            this.ribbonPageHome.Name = "ribbonPageHome";
            this.ribbonPageHome.Text = "Home";
            // 
            // ribbonPageGroupFile
            // 
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonItemNewMod);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonItemOpenMod);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonItemRecent);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonItemSave);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonItemSaveAll);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonItemAddNewFile);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonItemAddFileFromBundle);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonItemAddModFile);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonItemImport);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonItemExport);
            this.ribbonPageGroupFile.Name = "ribbonPageGroupFile";
            this.ribbonPageGroupFile.Text = "File";
            // 
            // ribbonPageGroupBuild
            // 
            this.ribbonPageGroupBuild.ItemLinks.Add(this.barButtonItemBuildMod);
            this.ribbonPageGroupBuild.ItemLinks.Add(this.barButtonItemQuickBuild);
            this.ribbonPageGroupBuild.ItemLinks.Add(this.barButtonItemLaunch);
            this.ribbonPageGroupBuild.Name = "ribbonPageGroupBuild";
            this.ribbonPageGroupBuild.Text = "Build";
            // 
            // ribbonPageProjectTools
            // 
            this.ribbonPageProjectTools.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupProject,
            this.ribbonPageGroupTools});
            this.ribbonPageProjectTools.Name = "ribbonPageProjectTools";
            this.ribbonPageProjectTools.Text = "Project Tools";
            // 
            // ribbonPageGroupProject
            // 
            this.ribbonPageGroupProject.ItemLinks.Add(this.barButtonItemCreatePackInstaller);
            this.ribbonPageGroupProject.ItemLinks.Add(this.barButtonItemReload);
            this.ribbonPageGroupProject.ItemLinks.Add(this.barButtonItemProjectSettings);
            this.ribbonPageGroupProject.Name = "ribbonPageGroupProject";
            this.ribbonPageGroupProject.Text = "Project";
            // 
            // ribbonPageGroupTools
            // 
            this.ribbonPageGroupTools.ItemLinks.Add(this.barButtonItemPackageInstaller);
            this.ribbonPageGroupTools.ItemLinks.Add(this.barButtonItemSaveExplorer);
            this.ribbonPageGroupTools.ItemLinks.Add(this.barButtonItemStringsEncoder);
            this.ribbonPageGroupTools.ItemLinks.Add(this.barButtonItemMenuCreator);
            this.ribbonPageGroupTools.ItemLinks.Add(this.barCheckItemRenderW2Mesh);
            this.ribbonPageGroupTools.ItemLinks.Add(this.barButtonItemOptions);
            this.ribbonPageGroupTools.Name = "ribbonPageGroupTools";
            this.ribbonPageGroupTools.Text = "Tools";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 770);
            this.Controls.Add(this.ribbonControlMain);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.menuStrip1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmMain.IconOptions.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(584, 391);
            this.Name = "frmMain";
            this.Text = "Wolven kit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLaunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNewFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem modExplorerToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutRedkit2ToolStripMenuItem;
        private ToolStripMenuItem joinOurDiscordToolStripMenuItem;
        private DockPanel dockPanel;
        private ToolStripMenuItem outputToolStripMenuItem;
        private ToolStripMenuItem tutorialsToolStripMenuItem;
        private ToolStripMenuItem witcherIIIModdingToolLicenseToolStripMenuItem;
        private ToolStripMenuItem buildDateToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem recordStepsToReproduceBugToolStripMenuItem;
        private ToolStripMenuItem reportABugToolStripMenuItem;
        private ToolStrip toolStrip2;
        private ToolStripLabel statusLBL;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripMenuItem donateToolStripMenuItem;
        private BackgroundWorker richpresenceworker;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControlMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFile;
        private DevExpress.XtraBars.BarButtonItem barButtonItemNewMod;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOpenMod;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRecent;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSaveAll;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddFileFromBundle;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupBuild;
        private DevExpress.XtraBars.BarButtonItem barButtonItemBuildMod;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLaunch;
        private DevExpress.XtraBars.PopupMenu popupMenuLaunch;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDebug;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCustomParams;
        private DevExpress.XtraBars.BarButtonItem barButtonItemBuildAndLaunch;
        private DevExpress.XtraBars.BarButtonItem barButtonItemQuickBuild;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddModFile;
        private DevExpress.XtraBars.BarButtonItem barButtonItemImport;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExport;
        private DevExpress.XtraBars.PopupMenu popupMenuImport;
        private DevExpress.XtraBars.BarButtonItem barButtonItemFBXCollisons;
        private DevExpress.XtraBars.BarButtonItem barButtonItemNvidiaClothFile;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddNewFile;
        private DevExpress.XtraBars.PopupMenu popupMenuNewFile;
        private DevExpress.XtraBars.BarSubItem barSubItemMod;
        private DevExpress.XtraBars.BarButtonItem barButtonItemScriptMod;
        private DevExpress.XtraBars.BarButtonItem barButtonItemWwiseMod;
        private DevExpress.XtraBars.BarButtonItem barButtonItemChunkFileMod;
        private DevExpress.XtraBars.BarSubItem barSubItemDLC;
        private DevExpress.XtraBars.BarButtonItem barButtonItemScriptDLC;
        private DevExpress.XtraBars.BarButtonItem barButtonItemWwiseDLC;
        private DevExpress.XtraBars.BarButtonItem barButtonItemChunkFileDLC;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageProjectTools;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupProject;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCreatePackInstaller;
        private DevExpress.XtraBars.BarButtonItem barButtonItemReload;
        private DevExpress.XtraBars.BarButtonItem barButtonItemProjectSettings;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupTools;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPackageInstaller;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSaveExplorer;
        private DevExpress.XtraBars.BarButtonItem barButtonItemStringsEncoder;
        private DevExpress.XtraBars.BarButtonItem barButtonItemGameDebugger;
        private DevExpress.XtraBars.BarButtonItem barButtonItemMenuCreator;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDumpGameAssets;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOptions;
        private DevExpress.XtraBars.BarCheckItem barCheckItemRenderW2Mesh;
    }
}