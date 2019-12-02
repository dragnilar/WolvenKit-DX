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
            this.barButtonItemViewModExplorer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemViewOutput = new DevExpress.XtraBars.BarButtonItem();
            this.themePalleteDropDrownList = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            this.barButtonItemWitcherScript = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemModToolLic = new DevExpress.XtraBars.BarButtonItem();
            this.ReportABug = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAboutWolvenkit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDonate = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemBuildDate = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemClearOutput = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSaveOutput = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupBuild = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupOutput = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageProjectTools = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupProject = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupTools = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageSettingsAndHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSettings = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupHelp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBarMainWindow = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dockManagerMainWindow = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelOutput = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.outputViewControl = new WolvenKit.OutputView();
            this.dockPanelModExplorer = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.modExplorerControl = new WolvenKit.ModExplorer();
            this.documentManagerMain = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedViewMain = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLaunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNewFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerMainWindow)).BeginInit();
            this.dockPanelOutput.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dockPanelModExplorer.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewMain)).BeginInit();
            this.SuspendLayout();
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
            this.barCheckItemRenderW2Mesh,
            this.barButtonItemViewModExplorer,
            this.barButtonItemViewOutput,
            this.themePalleteDropDrownList,
            this.barButtonItemWitcherScript,
            this.barButtonItemModToolLic,
            this.ReportABug,
            this.barButtonItemAboutWolvenkit,
            this.barButtonItemDonate,
            this.barStaticItemStatus,
            this.barStaticItemBuildDate,
            this.barButtonItemClearOutput,
            this.barButtonItemSaveOutput});
            this.ribbonControlMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonControlMain.MaxItemId = 57;
            this.ribbonControlMain.Name = "ribbonControlMain";
            this.ribbonControlMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageHome,
            this.ribbonPageProjectTools,
            this.ribbonPageSettingsAndHelp});
            this.ribbonControlMain.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControlMain.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControlMain.ShowQatLocationSelector = false;
            this.ribbonControlMain.ShowToolbarCustomizeItem = false;
            this.ribbonControlMain.Size = new System.Drawing.Size(1280, 158);
            this.ribbonControlMain.StatusBar = this.ribbonStatusBarMainWindow;
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
            // barButtonItemViewModExplorer
            // 
            this.barButtonItemViewModExplorer.Caption = "Mod Explorer";
            this.barButtonItemViewModExplorer.Id = 42;
            this.barButtonItemViewModExplorer.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemViewModExplorer.ImageOptions.SvgImage")));
            this.barButtonItemViewModExplorer.Name = "barButtonItemViewModExplorer";
            this.barButtonItemViewModExplorer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemViewModExplorer_ItemClick);
            // 
            // barButtonItemViewOutput
            // 
            this.barButtonItemViewOutput.Caption = "View Output";
            this.barButtonItemViewOutput.Id = 43;
            this.barButtonItemViewOutput.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemViewOutput.ImageOptions.SvgImage")));
            this.barButtonItemViewOutput.Name = "barButtonItemViewOutput";
            this.barButtonItemViewOutput.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemViewOutput_ItemClick);
            // 
            // themePalleteDropDrownList
            // 
            this.themePalleteDropDrownList.Id = 45;
            this.themePalleteDropDrownList.Name = "themePalleteDropDrownList";
            // 
            // barButtonItemWitcherScript
            // 
            this.barButtonItemWitcherScript.Caption = "Witcherscript Documentation";
            this.barButtonItemWitcherScript.Id = 47;
            this.barButtonItemWitcherScript.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemWitcherScript.ImageOptions.SvgImage")));
            this.barButtonItemWitcherScript.Name = "barButtonItemWitcherScript";
            this.barButtonItemWitcherScript.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemWitcherScript_ItemClick);
            // 
            // barButtonItemModToolLic
            // 
            this.barButtonItemModToolLic.Caption = "Witcher III Mod Tool License";
            this.barButtonItemModToolLic.Id = 48;
            this.barButtonItemModToolLic.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemModToolLic.ImageOptions.SvgImage")));
            this.barButtonItemModToolLic.Name = "barButtonItemModToolLic";
            this.barButtonItemModToolLic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemModToolLic_ItemClick);
            // 
            // ReportABug
            // 
            this.ReportABug.Caption = "Report A Bug";
            this.ReportABug.Id = 49;
            this.ReportABug.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ReportABug.ImageOptions.SvgImage")));
            this.ReportABug.Name = "ReportABug";
            this.ReportABug.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ReportABug_ItemClick);
            // 
            // barButtonItemAboutWolvenkit
            // 
            this.barButtonItemAboutWolvenkit.Caption = "About Wolvenkit DX";
            this.barButtonItemAboutWolvenkit.Id = 51;
            this.barButtonItemAboutWolvenkit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemAboutWolvenkit.ImageOptions.SvgImage")));
            this.barButtonItemAboutWolvenkit.Name = "barButtonItemAboutWolvenkit";
            this.barButtonItemAboutWolvenkit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAboutWolvenkit_ItemClick);
            // 
            // barButtonItemDonate
            // 
            this.barButtonItemDonate.Caption = "Donate To Original Team";
            this.barButtonItemDonate.Id = 52;
            this.barButtonItemDonate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemDonate.ImageOptions.SvgImage")));
            this.barButtonItemDonate.Name = "barButtonItemDonate";
            this.barButtonItemDonate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDonate_ItemClick);
            // 
            // barStaticItemStatus
            // 
            this.barStaticItemStatus.Caption = "Ready";
            this.barStaticItemStatus.Id = 53;
            this.barStaticItemStatus.Name = "barStaticItemStatus";
            // 
            // barStaticItemBuildDate
            // 
            this.barStaticItemBuildDate.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItemBuildDate.Caption = "Build Date";
            this.barStaticItemBuildDate.Id = 54;
            this.barStaticItemBuildDate.Name = "barStaticItemBuildDate";
            // 
            // barButtonItemClearOutput
            // 
            this.barButtonItemClearOutput.Caption = "Clear Output";
            this.barButtonItemClearOutput.Id = 55;
            this.barButtonItemClearOutput.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemClearOutput.ImageOptions.SvgImage")));
            this.barButtonItemClearOutput.Name = "barButtonItemClearOutput";
            this.barButtonItemClearOutput.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemClearOutput_ItemClick);
            // 
            // barButtonItemSaveOutput
            // 
            this.barButtonItemSaveOutput.Caption = "Save Output";
            this.barButtonItemSaveOutput.Id = 56;
            this.barButtonItemSaveOutput.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemSaveOutput.ImageOptions.SvgImage")));
            this.barButtonItemSaveOutput.Name = "barButtonItemSaveOutput";
            this.barButtonItemSaveOutput.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSaveOutput_ItemClick);
            // 
            // ribbonPageHome
            // 
            this.ribbonPageHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupFile,
            this.ribbonPageGroupBuild,
            this.ribbonPageGroupView,
            this.ribbonPageGroupOutput});
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
            // ribbonPageGroupView
            // 
            this.ribbonPageGroupView.ItemLinks.Add(this.barButtonItemViewModExplorer);
            this.ribbonPageGroupView.ItemLinks.Add(this.barButtonItemViewOutput);
            this.ribbonPageGroupView.Name = "ribbonPageGroupView";
            this.ribbonPageGroupView.Text = "View";
            // 
            // ribbonPageGroupOutput
            // 
            this.ribbonPageGroupOutput.ItemLinks.Add(this.barButtonItemClearOutput);
            this.ribbonPageGroupOutput.ItemLinks.Add(this.barButtonItemSaveOutput);
            this.ribbonPageGroupOutput.Name = "ribbonPageGroupOutput";
            this.ribbonPageGroupOutput.Text = "Output Log";
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
            // ribbonPageSettingsAndHelp
            // 
            this.ribbonPageSettingsAndHelp.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupSettings,
            this.ribbonPageGroupHelp});
            this.ribbonPageSettingsAndHelp.Name = "ribbonPageSettingsAndHelp";
            this.ribbonPageSettingsAndHelp.Text = "Settings / Help";
            // 
            // ribbonPageGroupSettings
            // 
            this.ribbonPageGroupSettings.ItemLinks.Add(this.themePalleteDropDrownList);
            this.ribbonPageGroupSettings.Name = "ribbonPageGroupSettings";
            this.ribbonPageGroupSettings.Text = "Settings";
            // 
            // ribbonPageGroupHelp
            // 
            this.ribbonPageGroupHelp.ItemLinks.Add(this.barButtonItemWitcherScript);
            this.ribbonPageGroupHelp.ItemLinks.Add(this.barButtonItemModToolLic);
            this.ribbonPageGroupHelp.ItemLinks.Add(this.ReportABug);
            this.ribbonPageGroupHelp.ItemLinks.Add(this.barButtonItemAboutWolvenkit);
            this.ribbonPageGroupHelp.ItemLinks.Add(this.barButtonItemDonate);
            this.ribbonPageGroupHelp.Name = "ribbonPageGroupHelp";
            this.ribbonPageGroupHelp.Text = "Help";
            // 
            // ribbonStatusBarMainWindow
            // 
            this.ribbonStatusBarMainWindow.ItemLinks.Add(this.barStaticItemStatus);
            this.ribbonStatusBarMainWindow.ItemLinks.Add(this.barStaticItemBuildDate);
            this.ribbonStatusBarMainWindow.Location = new System.Drawing.Point(0, 744);
            this.ribbonStatusBarMainWindow.Name = "ribbonStatusBarMainWindow";
            this.ribbonStatusBarMainWindow.Ribbon = this.ribbonControlMain;
            this.ribbonStatusBarMainWindow.Size = new System.Drawing.Size(1280, 26);
            // 
            // dockManagerMainWindow
            // 
            this.dockManagerMainWindow.Form = this;
            this.dockManagerMainWindow.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelOutput,
            this.dockPanelModExplorer});
            this.dockManagerMainWindow.Style = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Light;
            this.dockManagerMainWindow.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanelOutput
            // 
            this.dockPanelOutput.Controls.Add(this.dockPanel1_Container);
            this.dockPanelOutput.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelOutput.ID = new System.Guid("155d2b35-13d2-45ff-bf75-acff0d69da23");
            this.dockPanelOutput.Location = new System.Drawing.Point(0, 618);
            this.dockPanelOutput.Name = "dockPanelOutput";
            this.dockPanelOutput.OriginalSize = new System.Drawing.Size(200, 126);
            this.dockPanelOutput.Size = new System.Drawing.Size(1280, 126);
            this.dockPanelOutput.Text = "Output";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.outputViewControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 28);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1280, 98);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // outputViewControl
            // 
            this.outputViewControl.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputViewControl.Appearance.Options.UseFont = true;
            this.outputViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputViewControl.Location = new System.Drawing.Point(0, 0);
            this.outputViewControl.Name = "outputViewControl";
            this.outputViewControl.Size = new System.Drawing.Size(1280, 98);
            this.outputViewControl.TabIndex = 0;
            // 
            // dockPanelModExplorer
            // 
            this.dockPanelModExplorer.Controls.Add(this.dockPanel2_Container);
            this.dockPanelModExplorer.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelModExplorer.ID = new System.Guid("50856fd6-7347-48d1-a37e-9d341c9f5a58");
            this.dockPanelModExplorer.Location = new System.Drawing.Point(0, 158);
            this.dockPanelModExplorer.Name = "dockPanelModExplorer";
            this.dockPanelModExplorer.OriginalSize = new System.Drawing.Size(447, 200);
            this.dockPanelModExplorer.Size = new System.Drawing.Size(447, 460);
            this.dockPanelModExplorer.Text = "Mod Explorer";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.modExplorerControl);
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 27);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(446, 433);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // modExplorerControl
            // 
            this.modExplorerControl.ActiveMod = null;
            this.modExplorerControl.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modExplorerControl.Appearance.Options.UseFont = true;
            this.modExplorerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modExplorerControl.Location = new System.Drawing.Point(0, 0);
            this.modExplorerControl.Margin = new System.Windows.Forms.Padding(2);
            this.modExplorerControl.Name = "modExplorerControl";
            this.modExplorerControl.Size = new System.Drawing.Size(446, 433);
            this.modExplorerControl.TabIndex = 0;
            this.modExplorerControl.RequestFileOpen += new System.EventHandler<WolvenKit.RequestFileArgs>(this.ModExplorer_RequestFileOpen);
            this.modExplorerControl.RequestFileDelete += new System.EventHandler<WolvenKit.RequestFileArgs>(this.ModExplorer_RequestFileDelete);
            this.modExplorerControl.RequestFileAdd += new System.EventHandler<WolvenKit.RequestFileArgs>(this.ModExplorer_RequestAddFile);
            this.modExplorerControl.RequestFileRename += new System.EventHandler<WolvenKit.RequestFileArgs>(this.ModExplorer_RequestFileRename);
            // 
            // documentManagerMain
            // 
            this.documentManagerMain.ContainerControl = this;
            this.documentManagerMain.View = this.tabbedViewMain;
            this.documentManagerMain.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedViewMain});
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 770);
            this.Controls.Add(this.dockPanelModExplorer);
            this.Controls.Add(this.dockPanelOutput);
            this.Controls.Add(this.ribbonStatusBarMainWindow);
            this.Controls.Add(this.ribbonControlMain);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmMain.IconOptions.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(584, 391);
            this.Name = "frmMain";
            this.Text = "Wolven kit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLaunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNewFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerMainWindow)).EndInit();
            this.dockPanelOutput.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanelModExplorer.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupView;
        private DevExpress.XtraBars.BarButtonItem barButtonItemViewModExplorer;
        private DevExpress.XtraBars.BarButtonItem barButtonItemViewOutput;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageSettingsAndHelp;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSettings;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupHelp;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem themePalleteDropDrownList;
        private DevExpress.XtraBars.BarButtonItem barButtonItemWitcherScript;
        private DevExpress.XtraBars.BarButtonItem barButtonItemModToolLic;
        private DevExpress.XtraBars.BarButtonItem ReportABug;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAboutWolvenkit;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDonate;
        private DevExpress.XtraBars.BarStaticItem barStaticItemStatus;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBarMainWindow;
        private DevExpress.XtraBars.BarStaticItem barStaticItemBuildDate;
        private DevExpress.XtraBars.Docking.DockManager dockManagerMainWindow;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelModExplorer;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelOutput;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private OutputView outputViewControl;
        private ModExplorer modExplorerControl;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManagerMain;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedViewMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupOutput;
        private DevExpress.XtraBars.BarButtonItem barButtonItemClearOutput;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSaveOutput;
    }
}