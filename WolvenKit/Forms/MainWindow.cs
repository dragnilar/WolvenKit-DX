using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using DevExpress.XtraSplashScreen;
using WolvenKit.Bundles;
using WolvenKit.Cache;
using WolvenKit.Common;
using WolvenKit.Controls;
using WolvenKit.CR2W;
using WolvenKit.CR2W.Types;
using WolvenKit.Forms;
using WolvenKit.Interfaces;
using WolvenKit.StringEncoder;

namespace WolvenKit
{
    public partial class MainWindow : XtraForm
    {
        public static Task Packer;
        private readonly string BaseTitle = "Wolven Kit DX";
        public bool RenderW2Mesh;

        public MainWindow()
        {
            InitializeComponent();
            CheckForSettings();
            SplashScreenManager.ShowForm(typeof(Splashy));
            Application.DoEvents();
            MainController.Get().Initialize();
            SplashScreenManager.CloseForm();
            MainController.Get().PropertyChanged += MainControllerUpdated;
            MainController.Get().InitForm(this);
            Shown += OnShown;
        }

        private void CheckForSettings()
        {
            if (File.Exists(MainController.Get().Configuration.ExecutablePath)) return;
            var settings = new SettingsDialogView {StartPosition = FormStartPosition.CenterScreen};
            var result = settings.ShowDialog();
            if (result != DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            UpdateTitle();
            SetPalette();
            UserLookAndFeel.Default.StyleChanged += DefaultOnStyleChanged;
        }

        public W3Mod ActiveMod
        {
            get => MainController.Get().ActiveMod;
            set
            {
                MainController.Get().ActiveMod = value;
                UpdateTitle();
            }
        }

        public string Version => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        private void SetPalette()
        {
            var palette = Configuration.Load().Palette;
            if (string.IsNullOrWhiteSpace(palette)) return;
            var actualPalette = SkinSvgPalette.Bezier.PaletteSet.FirstOrDefault(x => x.Key == palette);
            UserLookAndFeel.Default.SetSkinStyle(actualPalette.Value);
        }

        private void DefaultOnStyleChanged(object sender, EventArgs e)
        {
            MainController.Get().Configuration.Palette = UserLookAndFeel.Default.ActiveSvgPaletteName;
            MainController.Get().Configuration.Save();
        }


        private void barButtonItemFBXCollisons_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show(@"For this to work make sure your model has either of both of these layers:
            \n_tri - trimesh\n_col - for simple stuff like boxes and spheres", "Information about importing models",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            using (var of = new OpenFileDialog())
            {
                of.Title = "Please select your fbx file with _col or _tri layers";
                of.Filter = "FBX files | *.fbx";
                if (of.ShowDialog() != DialogResult.OK) return;
                using (var sf = new SaveFileDialog())
                {
                    sf.Filter = "Witcher 3 mesh file | *.w2mesh";
                    sf.Title = "Please specify a location to save the imported file";
                    sf.InitialDirectory = MainController.Get().Configuration.InitialFileDirectory;
                    if (sf.ShowDialog() == DialogResult.OK) ImportFile(of.FileName, sf.FileName);
                }
            }
        }

        private void barButtonItemNvidiaClothFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var of = new OpenFileDialog())
            {
                of.Title = "Please select your cloth file for importing";
                of.Filter = "APB files | *.apb";
                if (of.ShowDialog() == DialogResult.OK)
                    using (var sf = new SaveFileDialog())
                    {
                        sf.Filter = "Witcher 3 cloth file | *.redcloth";
                        sf.Title = "Please specify a location to save the imported file";
                        sf.InitialDirectory = MainController.Get().Configuration.InitialFileDirectory;
                        if (sf.ShowDialog() == DialogResult.OK) ImportFile(of.FileName, sf.FileName);
                    }
            }
        }

        private void barButtonItemExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var sf = new SaveFileDialog())
            {
                sf.Title = "Please select a location to save the json dump of the cr2w file";
                sf.Filter = "JSON Files | *.json";
                if (sf.ShowDialog() == DialogResult.OK) throw new NotImplementedException("TODO");
            }
        }

        private void barButtonItemScriptMod_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActiveMod == null)
                return;

            var scriptsdirectory = ActiveMod.ModDirectory + "\\scripts\\local";
            if (!Directory.Exists(scriptsdirectory)) Directory.CreateDirectory(scriptsdirectory);
            var fullPath = scriptsdirectory + "\\" + "blank_script.ws";
            var count = 1;
            var fileNameOnly = Path.GetFileNameWithoutExtension(fullPath);
            var extension = Path.GetExtension(fullPath);
            var path = Path.GetDirectoryName(fullPath);
            var newFullPath = fullPath;
            while (File.Exists(newFullPath))
            {
                var tempFileName = $"{fileNameOnly}({count++})";
                if (path != null) newFullPath = Path.Combine(path, tempFileName + extension);
            }

            File.WriteAllLines(newFullPath,
                new[] { @"/*", $"{BaseTitle} - {Version}", DateTime.Now.ToString("d"), @"*/" });
        }

        private void barButtonItemWwiseMod_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var of = new OpenFileDialog())
            {
                of.Multiselect = true;
                of.Filter = "Wwise files | *.wem;*.bnk";
                of.Title = "Please select the wwise bank and sound files for importing them into your mod";
                if (of.ShowDialog() == DialogResult.OK)
                    foreach (var f in of.FileNames)
                    {
                        var newfilepath = Path.Combine(ActiveMod.ModDirectory, new SoundManager().TypeName,
                            Path.GetFileName(f));
                        //Create the directory because it will crash if it doesn't exist.
                        Directory.CreateDirectory(Path.GetDirectoryName(newfilepath));
                        File.Copy(f, newfilepath, true);
                    }
            }
        }

        private void barButtonItemChunkFileMod_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItemScriptDLC_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActiveMod == null)
                return;

            var scriptsdirectory = ActiveMod.DlcDirectory + "\\scripts\\local";
            if (!Directory.Exists(scriptsdirectory)) Directory.CreateDirectory(scriptsdirectory);
            var fullPath = scriptsdirectory + "\\" + "blank_script.ws";
            var count = 1;
            var fileNameOnly = Path.GetFileNameWithoutExtension(fullPath);
            var extension = Path.GetExtension(fullPath);
            var path = Path.GetDirectoryName(fullPath);
            var newFullPath = fullPath;
            while (File.Exists(newFullPath))
            {
                var tempFileName = $"{fileNameOnly}({count++})";
                if (path != null) newFullPath = Path.Combine(path, tempFileName + extension);
            }

            File.WriteAllLines(newFullPath,
                new[] { @"/*", $"{BaseTitle} - {Version}", DateTime.Now.ToString("d"), @"*/" });
        }

        private void barButtonItemWwiseDLC_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var of = new OpenFileDialog())
            {
                of.Multiselect = true;
                of.Filter = "Wwise files | *.wem;*.bnk";
                of.Title = "Please select the wwise bank and sound files for importing them into your DLC";
                if (of.ShowDialog() == DialogResult.OK)
                    foreach (var f in of.FileNames)
                    {
                        var newfilepath = Path.Combine(ActiveMod.DlcDirectory, new SoundManager().TypeName, "dlc",
                            ActiveMod.Name, Path.GetFileName(f));
                        //Create the directory because it will crash if it doesn't exist.
                        Directory.CreateDirectory(Path.GetDirectoryName(newfilepath));
                        File.Copy(f, newfilepath, true);
                    }
            }
        }

        private void barButtonItemChunkFileDLC_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItemCreatePackInstaller_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateInstaller();
        }

        private void barButtonItemReload_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (File.Exists(MainController.Get().ActiveMod?.FileName))
                openMod(MainController.Get().ActiveMod?.FileName);
        }

        private void barButtonItemProjectSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActiveMod == null)
                return;
            //With this cloned it won't get modified when we change it in dlg
            var oldmod = (W3Mod)ActiveMod.Clone();
            using (var dlg = new frmModSettings())
            {
                dlg.Mod = ActiveMod;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (oldmod.Name != dlg.Mod.Name)
                        try
                        {
                            modExplorerControl.StopMonitoringDirectory();
                            tabbedViewMain.Documents.Clear();
                            //Move the files directory
                            Directory.Move(oldmod.ProjectDirectory,
                                Path.Combine(Path.GetDirectoryName(oldmod.ProjectDirectory), dlg.Mod.Name));
                            //Delete the old directory
                            if (Directory.Exists(oldmod.ProjectDirectory))
                                Commonfunctions.DeleteFilesAndFoldersRecursively(oldmod.ProjectDirectory);
                            //Delete the old mod project file
                            if (File.Exists(oldmod.FileName))
                                File.Delete(oldmod.FileName);
                        }
                        catch (IOException)
                        {
                            XtraMessageBox.Show("Sorry but there already exist a folder/mod with that name.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    //Save the new settings and update the title
                    UpdateTitle();
                    SaveMod();
                    if (File.Exists(MainController.Get().ActiveMod?.FileName))
                        openMod(MainController.Get().ActiveMod?.FileName);
                    Commonfunctions.SendNotification("Succesfully updated mod settings!");
                }
            }
        }

        private void barButtonItemPackageInstaller_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var of = new OpenFileDialog())
            {
                of.Filter = "WolvenKit Package | *.wkp";
                if (of.ShowDialog() == DialogResult.OK)
                    using (var pi = new frmInstallPackage(of.FileName))
                    {
                        pi.ShowDialog();
                    }
                else
                    Commonfunctions.SendNotification("Invalid file!");
            }
        }

        private void barButtonItemSaveExplorer_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var sef = new frmSaveEditor())
            {
                sef.ShowDialog();
            }
        }

        private void barButtonItemStringsEncoder_ItemClick(object sender, ItemClickEventArgs e)
        {
            var stringsEncoder = new StringEncoderView(MainController.Get().ActiveMod);
            stringsEncoder.ShowDialog();
            stringsEncoder.Dispose();
        }

        private void barButtonItemGameDebugger_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gdb = new frmDebug();
            gdb.Show();
        }

        private void barButtonItemMenuCreator_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var fmc = new frmMenuCreator())
            {
                fmc.ShowDialog();
            }
        }

        private void barButtonItemDumpGameAssets_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show(
                @"This will generate a file which will show what wcc_lite sees from a file. Please keep in mind this doesn't always work",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            using (var of = new FolderBrowserDialog())
            {
                of.Description = "Select the folder to dump";
                if (of.ShowDialog() != DialogResult.OK) return;
                using (var sf = new FolderBrowserDialog())
                {
                    sf.Description = "Please specify a location to save the dumped file";
                    if (sf.ShowDialog() == DialogResult.OK)
                        _ = DumpFile(of.SelectedPath.EndsWith("\\") ? of.SelectedPath : of.SelectedPath + "\\",
                            sf.SelectedPath.EndsWith("\\") ? sf.SelectedPath : sf.SelectedPath + "\\");
                }
            }
        }


        private void barButtonItemOptions_ItemClick(object sender, ItemClickEventArgs e)
        {
            var settings = new SettingsDialogView();
            settings.ShowDialog();
        }

        private void barCheckItemRenderW2Mesh_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            RenderW2Mesh = barCheckItemRenderW2Mesh.Checked;
        }

        private void barButtonItemViewModExplorer_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowModExplorer();
        }

        private void barButtonItemViewOutput_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowOutput();
        }


        private void barButtonItemWitcherScript_ItemClick(object sender, ItemClickEventArgs e)
        {
            Process.Start("https://witcherscript.readthedocs.io");
        }

        private void barButtonItemModToolLic_ItemClick(object sender, ItemClickEventArgs e)
        {
            var wcclicense = new LicenseDocumentView();
            wcclicense.Show();
        }

        private void ReportABug_ItemClick(object sender, ItemClickEventArgs e)
        {
            var result = XtraMessageBox.Show(
                "If you say yes you will be taken to the Github page for Wolvenkit DX in your default browser.\n Before opening up an issue with the bug you have found,\nplease verify" +
                "that the bug has not already been reported.\nWhen you report a bug, please provide as many details as possible. Reproduction steps are greatly appreciated!",
                "Continue to Github?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Process.Start("https://github.com/dragnilar/Wolven-kit");
        }

        private void barButtonItemClearOutput_ItemClick(object sender, ItemClickEventArgs e)
        {
            outputViewControl.ClearDocument();
        }

        private void barButtonItemSaveOutput_ItemClick(object sender, ItemClickEventArgs e)
        {
            outputViewControl.SaveDocument();
        }

        private delegate void strDelegate(string t);

        private delegate void logDelegate(string t, OutputView.Logtype type);

        #region Methods

        /// <summary>
        ///     Occurs when something in the maincontroller is updated that is INotifyPropertyChanged
        ///     Thread safe and always should be
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainControllerUpdated(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ProjectStatus")
                Invoke(new strDelegate(SetStatusLabelText), ((MainController)sender).ProjectStatus);
            if (e.PropertyName == "LogMessage")
                Invoke(new logDelegate(AddOutput), ((MainController)sender).LogMessage.Key + "\n",
                    ((MainController)sender).LogMessage.Value);
        }

        private void SetStatusLabelText(string text)
        {
            barStaticItemStatus.Caption = text;
        }



        private void UpdateTitle()
        {
            barStaticItemBuildDate.Caption =
                $"Build Date: {Assembly.GetExecutingAssembly().GetLinkerTime().ToString("yyyy MMMM dd")}";
            Text = BaseTitle + " v" + Version;
            if (ActiveMod != null) Text += " [" + ActiveMod.Name + "] ";

            if (tabbedViewMain.ActiveDocument != null) Text += Path.GetFileName(tabbedViewMain.ActiveDocument.Caption);
        }

        private void saveAllFiles()
        {
            foreach (var form in Application.OpenForms)
            {
                if (!(form is XtraForm window)) continue;
                if (window.Tag?.ToString() != "BufferEditor") continue;
                if (window.Controls[0] is CR2WDocumentContainer documentContainer)
                {
                    documentContainer.SaveFile();
                }
            }
            foreach (var document in tabbedViewMain.Documents)
            {
                if (document.Control is CR2WDocumentContainer container && container.SaveTarget != null)
                {
                    saveFile(container);
                }
                else if (document.Control is ScriptEditor editor)
                {
                    editor.SaveFile();
                }

            }
            AddOutput("All files saved!\n");
            MainController.Get().ProjectStatus = "Item(s) Saved";
            MainController.Get().ProjectUnsaved = false;
        }

        private void saveFile(CR2WDocumentContainer d)
        {
            d.SaveFile();
            AddOutput(d.FileName + " saved!\n");
            MainController.Get().ProjectStatus = "Saved";
        }


        private void ClearOutput()
        {
            if (outputViewControl != null && !outputViewControl.IsDisposed) outputViewControl.Clear();
            MainController.Get().ProjectStatus = "Output cleared";
        }

        private void AddOutput(string text, OutputView.Logtype type = OutputView.Logtype.Normal)
        {
            if (outputViewControl != null && !outputViewControl.IsDisposed)
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                outputViewControl.AddText(text, type);
            }
        }

        public void PackProject()
        {
            if (Packer != null && (Packer.Status == TaskStatus.Running || Packer.Status == TaskStatus.WaitingToRun ||
                                   Packer.Status == TaskStatus.WaitingForActivation))
                XtraMessageBox.Show("Packing task already running. Please wait!", "WolvenKit", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            else
                Packer = PackAndInstallMod();
        }

        public void QuickPack()
        {
            if (Packer != null && (Packer.Status == TaskStatus.Running || Packer.Status == TaskStatus.WaitingToRun ||
                                   Packer.Status == TaskStatus.WaitingForActivation))
                XtraMessageBox.Show("Packing task already running. Please wait!", "WolvenKit", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            else
                Packer = QuickBuild();
        }

        /// <summary>
        ///     Installs the project from the packed folder of the project to the game
        /// </summary>
        private void InstallMod()
        {
            try
            {
                //Check if we have installed this mod before. If so do a little cleanup.
                if (File.Exists(ActiveMod.ProjectDirectory + "\\install_log.xml"))
                {
                    var log = XDocument.Load(ActiveMod.ProjectDirectory + "\\install_log.xml");
                    var dirs = log.Root.Element("Files")?.Descendants("Directory");
                    if (dirs != null)
                    {
                        //Loop throught dirs and delete the old files in them.
                        foreach (var d in dirs)
                            foreach (var f in d.Elements("file"))
                                if (File.Exists(f.Value))
                                {
                                    File.Delete(f.Value);
                                    Debug.WriteLine("File delete: " + f.Value);
                                }

                        //Delete the empty directories.
                        foreach (var d in dirs)
                            if (d.Attribute("Path") != null)
                                if (Directory.Exists(d.Attribute("Path").Value))
                                    if (!Directory.GetFiles(d.Attribute("Path").Value, "*", SearchOption.AllDirectories)
                                        .Any())
                                    {
                                        Directory.Delete(d.Attribute("Path").Value, true);
                                        Debug.WriteLine("Directory delete: " + d.Attribute("Path").Value);
                                    }
                    }

                    //Delete the old install log. We will make a new one so this is not needed anymore.
                    File.Delete(ActiveMod.ProjectDirectory + "\\install_log.xml");
                }

                var installlog = new XDocument(new XElement("InstalLog", new XAttribute("Project", ActiveMod.Name),
                    new XAttribute("Build_date", DateTime.Now.ToString())));
                var fileroot = new XElement("Files");
                //Copy and log the files.
                if (!Directory.Exists(Path.Combine(ActiveMod.ProjectDirectory, "packed")))
                {
                    AddOutput(
                        "Failed to install the mod! The packed directory doesn't exist! You forgot to tick any of the packing options?",
                        OutputView.Logtype.Important);
                    return;
                }

                fileroot.Add(Commonfunctions.DirectoryCopy(Path.Combine(ActiveMod.ProjectDirectory, "packed"),
                    MainController.Get().Configuration.GameRootDir, true));
                installlog.Root.Add(fileroot);
                //Save the log.
                installlog.Save(ActiveMod.ProjectDirectory + "\\install_log.xml");
                AddOutput(ActiveMod.Name + " installed!" + "\n", OutputView.Logtype.Success);
            }
            catch (Exception ex)
            {
                //If we screwed up something. Log it.
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }
        }

        private void CreateInstaller()
        {
            var cif = new CreatePackageInstallerView();
            cif.ShowDialog();
        }

        private async void executeGame(string args = "")
        {
            if (ActiveMod == null)
                return;
            if (Process.GetProcessesByName("Witcher3").Length != 0)
            {
                XtraMessageBox.Show(@"Game is already running!", string.Empty, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var config = MainController.Get().Configuration;
            var proc = new ProcessStartInfo(config.ExecutablePath)
            {
                WorkingDirectory = Path.GetDirectoryName(config.ExecutablePath),
                Arguments = args == string.Empty ? "-net -debugscripts" : args,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };


            AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n");

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var scriptlog = Path.Combine(documents, @"The Witcher 3\scriptslog.txt");
            if (File.Exists(scriptlog))
                File.Delete(scriptlog);

            using (var process = Process.Start(proc))
            {
                var task2 = RedirectScriptlogOutput(process);
                await task2;
            }
        }

        private async Task RedirectScriptlogOutput(Process process)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var scriptlog = Path.Combine(documents, @"The Witcher 3\scriptslog.txt");
            using (var fs = new FileStream(scriptlog, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var fsr = new StreamReader(fs))
                {
                    while (!process.HasExited)
                    {
                        var result = await fsr.ReadToEndAsync();

                        AddOutput(result);

                        Application.DoEvents();
                    }
                }

                fs.Close();
            }
        }

        private void removeFromMod(string filename)
        {
            // Close open documents
            //TODO - Re-implement multiple dockuments...
            //foreach (var t in OpenDocuments.Where(t => t.FileName == filename))
            //{
            //    t.Close();
            //    break;
            //}
            tabbedViewMain.Documents.Clear();

            // Delete from file structure
            var fullpath = Path.Combine(ActiveMod.FileDirectory, filename);
            if (File.Exists(fullpath))
                File.Delete(fullpath);
            else
                try
                {
                    Directory.Delete(fullpath, true);
                }
                catch (Exception)
                {
                    AddOutput("Failed to delete " + fullpath + "!");
                }

            // Delete from mod explorer
            modExplorerControl.DeleteNode(fullpath);

            SaveMod();
        }

        private static void ShellExecute(string fullpath)
        {
            var proc = new ProcessStartInfo(fullpath) { UseShellExecute = true };
            Process.Start(proc);
        }

        private static void PolymorphExecute(string fullpath, string extension)
        {
            File.WriteAllBytes(Path.GetTempPath() + "asd." + extension, new byte[] { 0x01 });
            var programname = new StringBuilder();
            NativeMethods.FindExecutable("asd." + extension, Path.GetTempPath(), programname);
            if (programname.ToString().ToUpper().Contains(".EXE"))
                Process.Start(programname.ToString(), fullpath);
            else
                throw new InvalidFileTypeException("Invalid file type");
        }

        public void LoadUsmFile(string path)
        {
            if (!File.Exists(path) || Path.GetExtension(path) != ".usm")
                return;
            //TODO - The USM player is for now a form, it will need to be converted to a user control if we want to show it in the dock panel...
            var usmplayer = new frmUsmPlayer(path);
            usmplayer.Show();
        }

        public void LoadDDSFile(string path)
        {
            var dockedImage = new frmTextureFile();
            dockedImage.Dock = DockStyle.Fill;
            tabbedViewMain.AddDocument(dockedImage);
            dockedImage.Text = Path.GetFileName(path);
            dockedImage.LoadImage(path);
        }

        private void LoadWitcherScriptFile(string filePath)
        {
            var scriptEditor = new ScriptEditor(filePath) {Dock = DockStyle.Fill};
            tabbedViewMain.AddDocument(scriptEditor);
            tabbedViewMain.Documents.Last().Caption = Path.GetFileName(filePath);
            tabbedViewMain.ActivateDocument(scriptEditor);
        }


        private void ShowOutput()
        {
            dockPanelOutput.Show();
        }


        private void createNewMod()
        {
            var dlg = new SaveFileDialog
            {
                Title = @"Create Witcher 3 Mod Project",
                Filter = @"Witcher 3 Mod|*.w3modproj",
                InitialDirectory = MainController.Get().Configuration.InitialModDirectory
            };

            while (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName.Contains(' '))
                {
                    XtraMessageBox.Show(
                        @"The mod path should not contain spaces because wcc_lite.exe will have trouble with that.",
                        "Invalid path");
                    continue;
                }

                MainController.Get().Configuration.InitialModDirectory = Path.GetDirectoryName(dlg.FileName);
                var modname = Path.GetFileNameWithoutExtension(dlg.FileName);
                var dirname = Path.GetDirectoryName(dlg.FileName);

                var moddir = Path.Combine(dirname, modname);
                try
                {
                    Directory.CreateDirectory(moddir);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Failed to create mod directory: \n" + moddir + "\n\n" + ex.Message);
                    return;
                }

                ActiveMod = new W3Mod
                {
                    FileName = dlg.FileName,
                    Name = modname
                };
                ResetWindows();
                UpdateModFileList();
                SaveMod();
                AddOutput("\"" + ActiveMod.Name + "\" successfully created and loaded!\n");
                break;
            }
        }

        private void SaveMod()
        {
            if (ActiveMod != null)
            {
                ActiveMod.LastOpenedFiles = new List<string>();
                if (ActiveMod.LastOpenedFiles != null && tabbedViewMain.Documents.Any())
                {

                    foreach (var document in tabbedViewMain.Documents)
                    {
                        if (document.Control is CR2WDocumentContainer container)
                        {
                            ActiveMod.LastOpenedFiles.Add(container.FileName);
                        }
                    }
                }
                var ser = new XmlSerializer(typeof(W3Mod));
                var modFile = new FileStream(ActiveMod.FileName, FileMode.Create, FileAccess.Write);
                ser.Serialize(modFile, ActiveMod);
                modFile.Close();
            }
        }


        private void openMod(string file = "")
        {
            try
            {
                //Opening the file from a dialog
                if (file == string.Empty)
                {
                    var dlg = new OpenFileDialog
                    {
                        Title = "Open Witcher 3 Mod Project",
                        Filter = "Witcher 3 Mod|*.w3modproj",
                        InitialDirectory = MainController.Get().Configuration.InitialModDirectory
                    };
                    if (dlg.ShowDialog() == DialogResult.OK)
                        file = dlg.FileName;
                    else
                        return;
                }

                var old = XDocument.Load(file);
                if (old.Descendants("InstallAsDLC").Any())
                {
                    //This is an old "Sarcen's W3Edit"-project. We need to upgrade it.
                    //Put the files into their respective folder.
                    switch (XtraMessageBox.Show(
                        $"The project you are opening has been made with an older version of {BaseTitle} or Sarcen's Witcher 3 Edit.\nIt needs to be upgraded for use with Wolvenkit.\nTo load as a mod please press yes. To load as a DLC project please press no.\n You can manually do the upgrade if you check the project structure: https://github.com/Traderain/Wolven-kit/wiki/Project-structure press cancel if you desire to do so. This may not always work but I tried my best.",
                        "Out of date project", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        default:
                            return;
                        case DialogResult.Yes:
                            {
                                Commonfunctions.DirectoryMove(
                                    Path.Combine(Path.GetDirectoryName(file), old.Root.Element("Name").Value, "files"),
                                    Path.Combine(Path.GetDirectoryName(file), old.Root.Element("Name").Value, "files",
                                        "Mod", "Bundle"));
                                break;
                            }
                        case DialogResult.No:
                            {
                                Commonfunctions.DirectoryMove(
                                    Path.Combine(Path.GetDirectoryName(file), old.Root.Element("Name").Value, "files"),
                                    Path.Combine(Path.GetDirectoryName(file), old.Root.Element("Name").Value, "files",
                                        "DLC", "Bundle"));
                                break;
                            }
                    }

                    //Upgrade the project xml
                    var nw = new W3Mod
                    {
                        Name = old.Root.Element("Name")?.Value,
                        FileName = file,
                        version = "1.0"
                    };
                    File.Delete(file);
                    var xs = new XmlSerializer(typeof(W3Mod));
                    var mf = new FileStream(file, FileMode.Create);
                    xs.Serialize(mf, nw);
                    mf.Close();
                }

                MainController.Get().Configuration.InitialModDirectory = Path.GetDirectoryName(file);

                //Loading the project
                var ser = new XmlSerializer(typeof(W3Mod));
                var modfile = new FileStream(file, FileMode.Open, FileAccess.Read);
                ActiveMod = (W3Mod)ser.Deserialize(modfile);
                ActiveMod.FileName = file;
                modfile.Close();
                ResetWindows();
                UpdateModFileList();
                AddOutput("\"" + ActiveMod.Name + "\" loaded successfully!\n");
                MainController.Get().ProjectStatus = "Ready";

                //Update the recent files.
                var files = new List<string>();
                if (File.Exists("recent_files.xml"))
                {
                    var doc = XDocument.Load("recent_files.xml");
                    files.AddRange(doc.Descendants("recentfile").Take(4).Select(x => x.Value));
                }

                files.Add(file);
                new XDocument(new XElement("RecentFiles", files.Distinct().Select(x => new XElement("recentfile", x))))
                    .Save("recent_files.xml");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Failed to upgrade the project!\n" + ex, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            //if (ActiveMod?.LastOpenedFiles != null)
            //    foreach (var doc in ActiveMod.LastOpenedFiles)
            //        if (File.Exists(doc))
            //            LoadDocument(doc);
        }

        /// <summary>
        ///     Scans the given archivemanagers for a file. If found, extracts it to the project.
        /// </summary>
        /// <param name="depotpath">Filename.</param>
        /// <param name="managers">The managers.</param>
        private bool AddToMod(WitcherListViewItem item, bool skipping, List<IWitcherArchive> managers, bool AddAsDLC)
        {
            var skip = skipping;
            var depotpath = item.ExplorerPath ?? item.FullPath ?? string.Empty;
            foreach (var manager in managers.Where(manager =>
                depotpath.StartsWith(Path.Combine("Root", manager.TypeName))))
                if (manager.Items.Any(x => x.Value.Any(y => y.Name == item.FullPath)))
                {
                    var archives = manager.FileList.Where(x => x.Name == item.FullPath)
                        .Select(y => new KeyValuePair<string, IWitcherFile>(y.Bundle.FileName, y));
                    var filename = Path.Combine(ActiveMod.FileDirectory,
                        AddAsDLC
                            ? Path.Combine("DLC", archives.First().Value.Bundle.TypeName, "dlc", ActiveMod.Name,
                                item.FullPath)
                            : Path.Combine("Mod", archives.First().Value.Bundle.TypeName, item.FullPath));
                    if (archives.Count() > 1)
                    {
                        var dlg = new frmExtractAmbigious(archives.Select(x => x.Key).ToList());
                        if (!skip)
                        {
                            var res = dlg.ShowDialog();
                            skip = dlg.Skip;
                            if (res == DialogResult.Cancel) return skip;
                        }

                        var selectedBundle = archives.FirstOrDefault(x => x.Key == dlg.SelectedBundle).Value;
                        try
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(filename));
                            if (File.Exists(filename)) File.Delete(filename);
                            selectedBundle.Extract(filename);
                        }
                        catch
                        {
                        }

                        return skip;
                    }

                    try
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(filename));
                        if (File.Exists(filename)) File.Delete(filename);

                        archives.FirstOrDefault().Value.Extract(filename);
                    }
                    catch (Exception ex)
                    {
                        AddOutput(ex.ToString(), OutputView.Logtype.Error);
                    }

                    return skip;
                }

            return skip;
        }

        /// <summary>
        ///     Opens the asset browser in the background
        /// </summary>
        /// <param name="loadmods">Load the mod files</param>
        /// <param name="browseToPath">The path to browse to</param>
        private void AddModFile(bool loadmods, string browseToPath = "")
        {
            if (ActiveMod == null)
                return;
            if (Application.OpenForms.OfType<AssetBrowserView>().Any())
            {
                var frm = Application.OpenForms.OfType<AssetBrowserView>().First();
                if (!string.IsNullOrEmpty(browseToPath))
                    frm.OpenPath(browseToPath);
                frm.WindowState = FormWindowState.Minimized;
                frm.Show();
                frm.WindowState = FormWindowState.Normal;
                return;
            }

            var explorer = new AssetBrowserView(loadmods
                ? new List<IWitcherArchive>
                {
                    MainController.Get().ModBundleManager,
                    MainController.Get().ModSoundManager,
                    MainController.Get().ModTextureManager
                }
                : new List<IWitcherArchive>
                {
                    MainController.Get().BundleManager,
                    MainController.Get().SoundManager,
                    MainController.Get().TextureManager
                });
            explorer.RequestFileAdd += Assetbrowser_FileAdd;
            explorer.OpenPath(browseToPath);
            explorer.Show();
        }

        /// <summary>
        ///     Update the list of files in the ModExplorer
        /// </summary>
        private void UpdateModFileList()
        {
            modExplorerControl.PauseMonitoring();
            modExplorerControl.UpdateModFileList(ActiveMod.FileDirectory);
            modExplorerControl.ResumeMonitoring();
        }

        /// <summary>
        ///     Closes all the "file documents", resets modexplorer and clears the output.
        /// </summary>
        private void ResetWindows()
        {
            //if (ActiveMod != null)
            //    //foreach (var t in OpenDocuments)
            //    //{
            //    //    t.Close();
            //    //    break;
            //    //}

            tabbedViewMain.Documents.Clear();
            dockPanelModExplorer.Close();
            ShowModExplorer();
            ShowOutput();
            ClearOutput();
        }

        private void ShowModExplorer()
        {
            dockPanelModExplorer.Show();
        }

        /// <summary>
        /// Opens the selected file path or memory stream (if supplied) in the CR2W Document Container.
        /// </summary>
        /// <param name="filePath">Full UNC file path to the file.</param>
        /// <param name="memoryStream">Optional, memory stream for the file (will take priority over the file if supplied)</param>
        /// <param name="suppressErrors">If set to true, will not display any exception/error messages that may pop up if files fail to open.</param>
        /// <returns></returns>
        public CR2WDocumentContainer LoadDocument(string filePath, MemoryStream memoryStream = null,
            bool suppressErrors = false)
        {
            if (memoryStream == null && !File.Exists(filePath))
                return null;
            var doc = new CR2WDocumentContainer();


            try
            {
                if (MainController.EditableFiles.Contains(Path.GetExtension(filePath)) || Path.GetFileName(filePath).ToLower() == "buffer" )
                {
                    if (memoryStream == null)
                    {
                        doc.LoadFile(filePath);
                    }
                    else
                    {
                        doc.LoadFile(filePath, memoryStream);
                    }
                }
                else
                {
                    Process.Start(filePath);
                    return null;
                }
            }
            catch (InvalidFileTypeException ex)
            {
                if (!suppressErrors)
                    XtraMessageBox.Show(this, ex.Message, @"Error opening file.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                doc.Dispose();
                return null;
            }
            catch (MissingTypeException ex)
            {
                if (!suppressErrors)
                    XtraMessageBox.Show(this, ex.Message, @"Error opening file.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                doc.Dispose();
                return null;
            }
            catch (Exception ex)
            {
                if (!suppressErrors)
                    XtraMessageBox.Show("Error opening selected file. Further details are as follows:\n\n" + ex,
                        "Error Loading File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                doc.Dispose();
                return null;
            }


            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            tabbedViewMain.AddDocument(doc);
            tabbedViewMain.Documents.Last().Caption = fileNameWithoutExtension;
            doc.Dock = DockStyle.Fill;

            var output = new StringBuilder();

            if (doc.ContainerFile != null)
            {
                if (doc.ContainerFile.block7.Count > 0)
                {
                    //TODO - This window may need to be converted to a user control, it isn't clear as to what control combination it belongs.
                    var embeddedFileForm = new EmbeddedFilesView()
                    {
                        File = doc.ContainerFile
                    };
                    embeddedFileForm.Show();
                }

                if (doc.ContainerFile.UnknownTypes.Any())
                {
                    ShowOutput();

                    output.Append(doc.FileName + ": contains " + doc.ContainerFile.UnknownTypes.Count + " unknown type(s):\n");
                    foreach (var unk in doc.ContainerFile.UnknownTypes) output.Append("\"" + unk + "\", \n");

                    output.Append("-------\n\n");
                }

                var hasUnknownBytes = false;

                foreach (var t in doc.ContainerFile.chunks.Where(t =>
                    t.unknownBytes?.Bytes != null && t.unknownBytes.Bytes.Length > 0))
                {
                    output.Append(t.Name + " contains " + t.unknownBytes.Bytes.Length + " unknown bytes. \n");
                    hasUnknownBytes = true;
                }

                if (hasUnknownBytes)
                    output.Append("-------\n\n");

                AddOutput(output.ToString());
            }

            return doc;
        }


        private async Task DumpFile(string folder, string outPutFolder)
        {
            var config = MainController.Get().Configuration;
            var proc = new ProcessStartInfo(config.WccLite) { WorkingDirectory = Path.GetDirectoryName(config.WccLite) };
            try
            {
                MainController.Get().ProjectStatus = "Dumping folder";
                proc.Arguments = $"dumpfile -dir={folder} -out={outPutFolder}";
                proc.UseShellExecute = false;
                proc.RedirectStandardOutput = true;
                proc.WindowStyle = ProcessWindowStyle.Hidden;
                proc.CreateNoWindow = true;
                AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                using (var process = Process.Start(proc))
                {
                    using (var reader = process.StandardOutput)
                    {
                        while (true)
                        {
                            var result = await reader.ReadLineAsync();

                            AddOutput(result + "\n", OutputView.Logtype.Wcc);

                            Application.DoEvents();

                            if (reader.EndOfStream)
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            MainController.Get().ProjectStatus = "File dumped succesfully!";
        }

        private async Task ImportFile(string infile, string outfile)
        {
            var config = MainController.Get().Configuration;
            var proc = new ProcessStartInfo(config.WccLite) { WorkingDirectory = Path.GetDirectoryName(config.WccLite) };
            try
            {
                var importwdir = Path.Combine(Path.GetDirectoryName(MainController.Get().Configuration.WccLite),
                    "WolvenKitWorkingDir");
                if (Directory.Exists(importwdir))
                    Directory.Delete(importwdir, true);
                Directory.CreateDirectory(importwdir);
                File.Copy(infile, Path.Combine(importwdir, Path.GetFileName(infile)));
                MainController.Get().ProjectStatus = "Importing file";
                proc.Arguments =
                    $"import -depot=\"{importwdir}\" -file={Path.Combine(importwdir, Path.GetFileName(infile))} -out={outfile}";
                proc.UseShellExecute = false;
                proc.RedirectStandardOutput = true;
                proc.WindowStyle = ProcessWindowStyle.Hidden;
                proc.CreateNoWindow = true;
                if (string.IsNullOrWhiteSpace(outfile))
                    AddOutput("The output directory is blank/empty, stopping import.", OutputView.Logtype.Error);
                Directory.CreateDirectory(Path.GetDirectoryName(outfile));

                AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                using (var process = Process.Start(proc))
                {
                    using (var reader = process.StandardOutput)
                    {
                        while (true)
                        {
                            var result = await reader.ReadLineAsync();

                            AddOutput(result + "\n", OutputView.Logtype.Wcc);

                            Application.DoEvents();

                            if (reader.EndOfStream)
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            MainController.Get().ProjectStatus = "File imported succesfully!";
        }

        #endregion //Methods

        #region Control events

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainController.Get().ProjectUnsaved)
                if (XtraMessageBox.Show("There are unsaved changes in your project. Would you like to save them?",
                        "WolvenKit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    saveAllFiles();

            SaveMod();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

            //Do not save the window state or any of that other stuff. It is annoying and causes friction with Windows.

            //TODO - Add back in serializing the layout
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            ResetWindows();
            try
            {
                //TODO - Add back in deserializing the layout
            }
            catch
            {
                // ignored
            }

            if (!string.IsNullOrEmpty(MainController.Get().InitialModProject))
                openMod(MainController.Get().InitialModProject);
            if (string.IsNullOrEmpty(MainController.Get().InitialWKP)) return;
            using (var pi = new frmInstallPackage(MainController.Get().InitialWKP))
            {
                pi.ShowDialog();
            }
        }


        private void barButtonItemNewMod_ItemClick(object sender, ItemClickEventArgs e)
        {
            createNewMod();
        }

        private void barButtonItemOpenMod_ItemClick(object sender, ItemClickEventArgs e)
        {
            openMod();
        }

        private void barButtonItemRecent_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new OpenFileDialog { Title = "Open CR2W File" };
            dlg.InitialDirectory = MainController.Get().Configuration.InitialFileDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MainController.Get().Configuration.InitialFileDirectory = Path.GetDirectoryName(dlg.FileName);
                LoadDocument(dlg.FileName);
            }
        }

        private void barButtonItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            saveActiveFile();
        }

        private void barButtonItemSaveAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            saveAllFiles();
            MainController.Get().ProjectStatus = "Item saved";
            AddOutput("Saved!\n");
        }

        private void barButtonItemAddFileFromBundle_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddModFile(false);
        }

        private void barButtonItemBuildMod_ItemClick(object sender, ItemClickEventArgs e)
        {
            PackProject();
        }

        private void barButtonItemQuickBuild_ItemClick(object sender, ItemClickEventArgs e)
        {
            QuickPack();
        }

        private void barButtonItemDebug_ItemClick(object sender, ItemClickEventArgs e)
        {
            executeGame();
        }

        private void barButtonItemCustomParams_ItemClick(object sender, ItemClickEventArgs e)
        {
            var getparams = new Input("Please give the commands to launch the game with!");
            if (getparams.ShowDialog() == DialogResult.OK) executeGame(getparams.Resulttext);
        }

        private void barButtonItemBuildAndLaunch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pack = PackAndInstallMod();
            while (!pack.IsCompleted)
                Application.DoEvents();
            var getparams = new Input("Please give the commands to launch the game with!");
            if (getparams.ShowDialog() == DialogResult.OK) executeGame(getparams.Resulttext);
        }

        private void Assetbrowser_FileAdd(object sender,
            Tuple<List<IWitcherArchive>, List<WitcherListViewItem>, bool> Details)
        {
            if (Process.GetProcessesByName("Witcher3").Length != 0)
            {
                XtraMessageBox.Show(@"Please close The Witcher 3 before tinkering with the files!", string.Empty,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MainController.Get().ProjectStatus = "Busy";
            var skipping = false;
            foreach (var item in Details.Item2) skipping = AddToMod(item, skipping, Details.Item1, Details.Item3);
            SaveMod();
            MainController.Get().ProjectStatus = "Ready";
        }

        private void ModExplorer_RequestFileOpen(object sender, RequestFileArgs e)
        {
            var path = Path.Combine(ActiveMod.FileDirectory, e.File);

            switch (Path.GetExtension(path))
            {
                case ".subs":
                    PolymorphExecute(path, ".txt");
                    break;
                case ".usm":
                    LoadUsmFile(path);
                    break;
                case SupportedFileType.WitcherScript:
                    LoadWitcherScriptFile(path); //TODO - This works but the scintilla editor needs to be styled and customized to provide a decent user experience.
                    //ShellExecute(path);
                    break;
                case ".dds":
                    LoadDDSFile(path);
                    break;
                default:
                    LoadDocument(path);
                    break;
            }
        }

        private void ModExplorer_RequestFileRename(object sender, RequestFileArgs e)
        {
            var filename = e.File;

            var fullPath = Path.Combine(ActiveMod.FileDirectory, filename);
            if (!File.Exists(fullPath))
                return;

            var dlg = new frmRenameDialog { FileName = filename };
            if (dlg.ShowDialog() == DialogResult.OK && dlg.FileName != filename)
            {
                var newFullPath = Path.Combine(ActiveMod.FileDirectory, dlg.FileName);

                if (File.Exists(newFullPath))
                    return;
                try
                {
                    var directoryPath = Path.GetDirectoryName(newFullPath);
                    if (directoryPath != null)
                    {
                        Directory.CreateDirectory(directoryPath);
                        File.Move(fullPath, newFullPath);
                    }

                    throw new FileNotFoundException("The directory for the specified file was not found.\n It was most likely deleted or renamed before the file rename could take place.");


                }
                catch(Exception ex)
                {
                    AddOutput($"An error occured renaming the file. The file was not renamed.\n Further Details:\n {ex}", OutputView.Logtype.Error);
                }
            }

            MainController.Get().ProjectStatus = "File renamed";

            //Dragnilar - After the file rename takes place, the file watcher for the mod explorer should update the tree list to show that the rename
            //took place. Previously this method was having to handle that itself. 
        }

        private void ModExplorer_RequestAddFile(object sender, RequestFileArgs e)
        {
            AddModFile(false, e.File);
        }

        private void ModExplorer_RequestFileDelete(object sender, RequestFileArgs e)
        {
            var filename = e.File;

            if (XtraMessageBox.Show(
                    "Are you sure you want to permanently delete this?", "Confirmation", MessageBoxButtons.OKCancel
                ) == DialogResult.OK)
                removeFromMod(filename);
        }


        private void saveActiveFile()
        {
            if (tabbedViewMain.ActiveDocument.Control is CR2WDocumentContainer container)
            {
                saveFile(container);
                AddOutput("Saved!\n");
            }
            else if (tabbedViewMain.ActiveDocument.Control is ScriptEditor editor)
            {
                editor.SaveFile();
            }
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            //Does this still need to be used??
        }


        private void barButtonItemAddModFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddModFile(true);
        }

        #endregion

        #region Mod Pack

        public async Task QuickBuild()
        {
            await PackAndInstallMod(true, false);
        }

        public async Task PackAndInstallMod(bool install = true, bool showForm = true)
        {
            if (ActiveMod == null)
                return;
            if (Process.GetProcessesByName("Witcher3").Length != 0)
            {
                XtraMessageBox.Show("Please close The Witcher 3 before tinkering with the files!", string.Empty,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var buildSettings = new BuildSettingsView();
            //TODO - This is a hack to skip the form, this needs to be refactored so it doesn't depend on the actual form
            if (showForm && buildSettings.ShowDialog() == DialogResult.OK || !showForm)
            {
                barButtonItemBuildMod.Enabled = false;
                ShowOutput();
                ClearOutput();
                saveAllFiles();
                var modpackDir = Path.Combine(ActiveMod.ProjectDirectory,
                    @"packed\Mods\mod" + ActiveMod.Name + @"\content\");
                var DlcpackDir = Path.Combine(ActiveMod.ProjectDirectory,
                    @"packed\DLC\dlc" + ActiveMod.Name + @"\content\");

                //Create the dirs. So script only mods don't die.
                Directory.CreateDirectory(modpackDir);
                Directory.CreateDirectory(DlcpackDir);

                //------------------------PRE COOKING-------------------------------------//

                //Handle strings.
                if (buildSettings.Strings)
                {
                    var stringsEncoder = new StringEncoderView(MainController.Get().ActiveMod);
                    if (stringsEncoder.AreHashesDifferent())
                    {
                        var result =
                            XtraMessageBox.Show(
                                "There are not encoded CSV files in your mod, do you want to open Strings Encoder GUI?",
                                string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            stringsEncoder.ShowDialog();
                            stringsEncoder.Dispose();
                        }


                    }
                }

                //Handle bundle packing.
                if (buildSettings.PackBundles) await PackBundles();

                //------------------------- COOKING -------------------------------------//

                //Cook the mod
                await CookMod();

                //------------------------POST COOKING------------------------------------//

                //Generate collision cache
                if (buildSettings.GenCollCache) await GenerateCollisionCache();

                //Handle texture caching
                if (buildSettings.GenTexCache) await PackTextures();

                //Handle metadata generation.
                if (buildSettings.GenMetadata) await CreateModMetaData();

                //Handle sound caching
                if (buildSettings.Sound)
                {
                    if (new DirectoryInfo(Path.Combine(ActiveMod.ModDirectory,
                            MainController.Get().SoundManager.TypeName)).GetFiles("*.*", SearchOption.AllDirectories)
                        .Where(file => file.Name.ToLower().EndsWith("wem") || file.Name.ToLower().EndsWith("bnk"))
                        .Any())
                    {
                        SoundCache.Write(
                            new DirectoryInfo(Path.Combine(ActiveMod.ModDirectory,
                                    MainController.Get().SoundManager.TypeName))
                                .GetFiles("*.*", SearchOption.AllDirectories)
                                .Where(file =>
                                    file.Name.ToLower().EndsWith("wem") || file.Name.ToLower().EndsWith("bnk"))
                                .ToList().Select(x => x.FullName).ToList(),
                            Path.Combine(modpackDir, @"soundspc.cache"));
                        AddOutput("Mod soundcache generated!\n", OutputView.Logtype.Important);
                    }
                    else
                    {
                        AddOutput("Mod soundcache wasn't generated!\n", OutputView.Logtype.Important);
                    }

                    if (new DirectoryInfo(Path.Combine(ActiveMod.DlcDirectory,
                            MainController.Get().SoundManager.TypeName)).GetFiles("*.*", SearchOption.AllDirectories)
                        .Where(file => file.Name.ToLower().EndsWith("wem") || file.Name.ToLower().EndsWith("bnk"))
                        .Any())
                    {
                        SoundCache.Write(
                            new DirectoryInfo(Path.Combine(ActiveMod.DlcDirectory,
                                    MainController.Get().SoundManager.TypeName))
                                .GetFiles("*.*", SearchOption.AllDirectories)
                                .Where(file =>
                                    file.Name.ToLower().EndsWith("wem") || file.Name.ToLower().EndsWith("bnk"))
                                .ToList().Select(x => x.FullName).ToList(),
                            Path.Combine(DlcpackDir, @"soundspc.cache"));
                        AddOutput("DLC soundcache generated!\n", OutputView.Logtype.Important);
                    }
                    else
                    {
                        AddOutput("DLC soundcache wasn't generated!\n", OutputView.Logtype.Important);
                    }
                }

                //Handle mod scripts
                if (Directory.Exists(Path.Combine(ActiveMod.ModDirectory, "scripts")) && Directory
                        .GetFiles(Path.Combine(ActiveMod.ModDirectory, "scripts"), "*.*", SearchOption.AllDirectories)
                        .Any())
                {
                    if (!Directory.Exists(Path.Combine(ActiveMod.ModDirectory, "scripts")))
                        Directory.CreateDirectory(Path.Combine(ActiveMod.ModDirectory, "scripts"));
                    //Now Create all of the directories
                    foreach (var dirPath in Directory.GetDirectories(Path.Combine(ActiveMod.ModDirectory, "scripts"),
                        "*.*",
                        SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(Path.Combine(ActiveMod.ModDirectory, "scripts"),
                            Path.Combine(modpackDir, "scripts")));

                    //Copy all the files & Replaces any files with the same name
                    foreach (var newPath in Directory.GetFiles(Path.Combine(ActiveMod.ModDirectory, "scripts"), "*.*",
                        SearchOption.AllDirectories))
                        File.Copy(newPath,
                            newPath.Replace(Path.Combine(ActiveMod.ModDirectory, "scripts"),
                                Path.Combine(modpackDir, "scripts")), true);
                }

                //Handle the DLC scripts
                if (Directory.Exists(Path.Combine(ActiveMod.DlcDirectory, "scripts")) && Directory
                        .GetFiles(Path.Combine(ActiveMod.DlcDirectory, "scripts"), "*.*", SearchOption.AllDirectories)
                        .Any())
                {
                    if (!Directory.Exists(Path.Combine(ActiveMod.DlcDirectory, "scripts")))
                        Directory.CreateDirectory(Path.Combine(ActiveMod.DlcDirectory, "scripts"));
                    //Now Create all of the directories
                    foreach (var dirPath in Directory.GetDirectories(Path.Combine(ActiveMod.DlcDirectory, "scripts"),
                        "*.*",
                        SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(Path.Combine(ActiveMod.DlcDirectory, "scripts"),
                            Path.Combine(DlcpackDir, "scripts")));

                    //Copy all the files & Replaces any files with the same name
                    foreach (var newPath in Directory.GetFiles(Path.Combine(ActiveMod.DlcDirectory, "scripts"), "*.*",
                        SearchOption.AllDirectories))
                        File.Copy(newPath,
                            newPath.Replace(Path.Combine(ActiveMod.DlcDirectory, "scripts"),
                                Path.Combine(DlcpackDir, "scripts")), true);
                }

                //Copy the generated w3strings
                if (buildSettings.Strings)
                {
                    var files = Directory.GetFiles(ActiveMod.ProjectDirectory + "\\strings")
                        .Where(s => Path.GetExtension(s) == ".w3strings").ToList();

                    files.ForEach(x => File.Copy(x, Path.Combine(DlcpackDir + Path.GetFileName(x))));
                    files.ForEach(x => File.Copy(x, Path.Combine(modpackDir, Path.GetFileName(x))));
                }

                //Install the mod
                if (install)
                    InstallMod();

                //Report that we are done
                MainController.Get().ProjectStatus = install ? "Mod Packed&Installed" : "Mod packed!";
                barButtonItemBuildMod.Enabled = true;
            }
        }

        /// <summary>
        ///     Packs the bundles for the DLC and the Mod. Always call this first since this cleans the direactories.
        /// </summary>
        private async Task PackBundles()
        {
            var config = MainController.Get().Configuration;
            var proc = new ProcessStartInfo(config.WccLite) { WorkingDirectory = Path.GetDirectoryName(config.WccLite) };
            var modpackDir = Path.Combine(ActiveMod.ProjectDirectory,
                @"packed\Mods\mod" + ActiveMod.Name + @"\content\");
            var DlcpackDir =
                Path.Combine(ActiveMod.ProjectDirectory, @"packed\DLC\dlc" + ActiveMod.Name + @"\content\");

            #region Directory cleanup

            if (!Directory.Exists(modpackDir))
            {
                Directory.CreateDirectory(modpackDir);
            }
            else
            {
                var di = new DirectoryInfo(modpackDir);
                foreach (var file in di.GetFiles()) file.Delete();
                foreach (var dir in di.GetDirectories()) dir.Delete(true);
            }

            if (!Directory.Exists(DlcpackDir))
            {
                Directory.CreateDirectory(DlcpackDir);
            }
            else
            {
                var di = new DirectoryInfo(DlcpackDir);
                foreach (var file in di.GetFiles()) file.Delete();
                foreach (var dir in di.GetDirectories()) dir.Delete(true);
            }

            #endregion

            #region Mod Bundle Packing

            try
            {
                if (Directory.GetFiles(Path.Combine(ActiveMod.ModDirectory, new Bundle().TypeName), "*",
                    SearchOption.AllDirectories).Any())
                {
                    MainController.Get().ProjectStatus = "Packing mod bundles";
                    proc.Arguments =
                        $"pack -dir={Path.Combine(ActiveMod.ModDirectory, new Bundle().TypeName)} -outdir={modpackDir}";
                    proc.UseShellExecute = false;
                    proc.RedirectStandardOutput = true;
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.CreateNoWindow = true;

                    AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                    using (var process = Process.Start(proc))
                    {
                        using (var reader = process.StandardOutput)
                        {
                            while (true)
                            {
                                var result = await reader.ReadLineAsync();

                                AddOutput(result + "\n", OutputView.Logtype.Wcc);

                                Application.DoEvents();

                                if (reader.EndOfStream)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                AddOutput("Mod Bundle directory not found. Bundles will not be packed for mod. \n",
                    OutputView.Logtype.Important);
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            #endregion

            #region DLC Bundle Packing

            try
            {
                if (Directory.GetFiles(Path.Combine(ActiveMod.DlcDirectory, new Bundle().TypeName), "*",
                    SearchOption.AllDirectories).Any())
                {
                    MainController.Get().ProjectStatus = "Packing dlc bundles";
                    proc.Arguments =
                        $"pack -dir={Path.Combine(ActiveMod.DlcDirectory, new Bundle().TypeName)} -outdir={DlcpackDir}";
                    proc.UseShellExecute = false;
                    proc.RedirectStandardOutput = true;
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.CreateNoWindow = true;

                    AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                    using (var process = Process.Start(proc))
                    {
                        using (var reader = process.StandardOutput)
                        {
                            while (true)
                            {
                                var result = await reader.ReadLineAsync();

                                AddOutput(result + "\n", OutputView.Logtype.Wcc);

                                Application.DoEvents();

                                if (reader.EndOfStream)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                AddOutput("DLC Bundle directory not found. Bundles will not packed for DLC. \n",
                    OutputView.Logtype.Important);
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            #endregion
        }

        private async Task CreateModMetaData()
        {
            var config = MainController.Get().Configuration;
            var proc = new ProcessStartInfo(config.WccLite) { WorkingDirectory = Path.GetDirectoryName(config.WccLite) };
            var modpackDir = Path.Combine(ActiveMod.ProjectDirectory,
                @"packed\Mods\mod" + ActiveMod.Name + @"\content\");
            var DlcpackDir =
                Path.Combine(ActiveMod.ProjectDirectory, @"packed\DLC\dlc" + ActiveMod.Name + @"\content\");

            #region Mod metadata Packing

            try
            {
                //We only pack this if we have bundles.
                if (Directory.GetFiles(Path.Combine(ActiveMod.ModDirectory, new Bundle().TypeName), "*",
                    SearchOption.AllDirectories).Any())
                {
                    MainController.Get().ProjectStatus = "Packing mod metadata";
                    proc.Arguments = $"metadatastore -path={modpackDir}";
                    proc.UseShellExecute = false;
                    proc.RedirectStandardOutput = true;
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.CreateNoWindow = true;

                    AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                    using (var process = Process.Start(proc))
                    {
                        using (var reader = process.StandardOutput)
                        {
                            while (true)
                            {
                                var result = await reader.ReadLineAsync();

                                AddOutput(result + "\n", OutputView.Logtype.Wcc);

                                Application.DoEvents();

                                if (reader.EndOfStream)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                AddOutput("Mod wasn't bundled. Metadata won't be generated. \n", OutputView.Logtype.Important);
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            #endregion

            #region DLC metadata Packing

            try
            {
                //We only pack this if we have bundles.
                if (Directory.GetFiles(Path.Combine(ActiveMod.DlcDirectory, new Bundle().TypeName), "*",
                    SearchOption.AllDirectories).Any())
                {
                    MainController.Get().ProjectStatus = "Packing DLC metadata";
                    proc.Arguments = $"metadatastore -path={DlcpackDir}";
                    proc.UseShellExecute = false;
                    proc.RedirectStandardOutput = true;
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.CreateNoWindow = true;

                    AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                    using (var process = Process.Start(proc))
                    {
                        using (var reader = process.StandardOutput)
                        {
                            while (true)
                            {
                                var result = await reader.ReadLineAsync();

                                AddOutput(result + "\n", OutputView.Logtype.Wcc);

                                Application.DoEvents();

                                if (reader.EndOfStream)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                AddOutput("DLC wasn't bundled. Metadata won't be generated. \n", OutputView.Logtype.Important);
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            #endregion
        }

        private async Task CookMod()
        {
            var config = MainController.Get().Configuration;
            var proc = new ProcessStartInfo(config.WccLite) { WorkingDirectory = Path.GetDirectoryName(config.WccLite) };
            var cookedModDir = Path.Combine(ActiveMod.ProjectDirectory,
                @"cooked\Mods\mod" + ActiveMod.Name + @"\content\");
            var cookedDLCDir = Path.Combine(ActiveMod.ProjectDirectory,
                @"cooked\DLC\dlc" + ActiveMod.Name + @"\content\");

            #region Cook Mod

            try
            {
                var modtexcachedir = Path.Combine(ActiveMod.ModDirectory, MainController.Get().TextureManager.TypeName);
                if (Directory.Exists(modtexcachedir) &&
                    Directory.GetFiles(modtexcachedir, "*", SearchOption.AllDirectories).Any())
                {
                    MainController.Get().ProjectStatus = "Cooking mod";
                    proc.Arguments =
                        $"cook -platform=pc -mod={Path.Combine(ActiveMod.ModDirectory, MainController.Get().TextureManager.TypeName)} -basedir={Path.Combine(ActiveMod.ModDirectory, MainController.Get().TextureManager.TypeName)}  -outdir={cookedModDir}";
                    proc.UseShellExecute = false;
                    proc.RedirectStandardOutput = true;
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.CreateNoWindow = true;
                    if (!Directory.Exists(cookedModDir))
                    {
                        Directory.CreateDirectory(cookedModDir);
                    }
                    else
                    {
                        var di = new DirectoryInfo(cookedModDir);
                        foreach (var file in di.GetFiles()) file.Delete();
                        foreach (var dir in di.GetDirectories()) dir.Delete(true);
                    }

                    AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                    using (var process = Process.Start(proc))
                    {
                        using (var reader = process.StandardOutput)
                        {
                            while (true)
                            {
                                var result = await reader.ReadLineAsync();

                                AddOutput(result + "\n", OutputView.Logtype.Wcc);

                                Application.DoEvents();

                                if (reader.EndOfStream)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                AddOutput("Mod TextureCache folder not found. Mod won't be cooked. \n", OutputView.Logtype.Important);
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            #endregion

            #region Cook DLC

            try
            {
                var dlctxcachedir = Path.Combine(ActiveMod.DlcDirectory, MainController.Get().TextureManager.TypeName);
                if (Directory.Exists(dlctxcachedir) &&
                    Directory.GetFiles(dlctxcachedir, "*", SearchOption.AllDirectories).Any())
                {
                    MainController.Get().ProjectStatus = "Cooking DLC";
                    proc.Arguments =
                        $"cook -platform=pc -mod={Path.Combine(ActiveMod.DlcDirectory, MainController.Get().TextureManager.TypeName)} -basedir={Path.Combine(ActiveMod.DlcDirectory, MainController.Get().TextureManager.TypeName)}  -outdir={cookedDLCDir}";
                    proc.UseShellExecute = false;
                    proc.RedirectStandardOutput = true;
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.CreateNoWindow = true;
                    if (!Directory.Exists(cookedDLCDir))
                    {
                        Directory.CreateDirectory(cookedDLCDir);
                    }
                    else
                    {
                        var di = new DirectoryInfo(cookedDLCDir);
                        foreach (var file in di.GetFiles()) file.Delete();
                        foreach (var dir in di.GetDirectories()) dir.Delete(true);
                    }

                    AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                    using (var process = Process.Start(proc))
                    {
                        using (var reader = process.StandardOutput)
                        {
                            while (true)
                            {
                                var result = await reader.ReadLineAsync();

                                AddOutput(result + "\n", OutputView.Logtype.Wcc);

                                Application.DoEvents();

                                if (reader.EndOfStream)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                AddOutput("DLC TextureCache folder not found. DLC won't be cooked. \n", OutputView.Logtype.Important);
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            #endregion
        }

        private async Task GenerateCollisionCache()
        {
            var config = MainController.Get().Configuration;
            var proc = new ProcessStartInfo(config.WccLite) { WorkingDirectory = Path.GetDirectoryName(config.WccLite) };
            var modpackDir = Path.Combine(ActiveMod.ProjectDirectory,
                @"packed\Mods\mod" + ActiveMod.Name + @"\content\");
            var DlcpackDir =
                Path.Combine(ActiveMod.ProjectDirectory, @"packed\DLC\dlc" + ActiveMod.Name + @"\content\");
            var cookedModDir = Path.Combine(ActiveMod.ProjectDirectory,
                @"cooked\Mods\mod" + ActiveMod.Name + @"\content\");
            var cookedDLCDir = Path.Combine(ActiveMod.ProjectDirectory,
                @"cooked\DLC\dlc" + ActiveMod.Name + @"\content\");

            #region Mod texture caching

            try
            {
                if (Directory.GetFiles(Path.Combine(ActiveMod.ModDirectory, new TextureCache().TypeName), "*",
                    SearchOption.AllDirectories).Any())
                {
                    MainController.Get().ProjectStatus = "Generating collision cache";
                    proc.Arguments =
                        $"buildcache physics -basedir={Path.Combine(ActiveMod.ModDirectory, MainController.Get().TextureManager.TypeName)} -platform=pc -db={cookedModDir}\\cook.db  -out={modpackDir}\\collision.cache";
                    proc.UseShellExecute = false;
                    proc.RedirectStandardOutput = true;
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.CreateNoWindow = true;

                    AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                    using (var process = Process.Start(proc))
                    {
                        using (var reader = process.StandardOutput)
                        {
                            while (true)
                            {
                                var result = await reader.ReadLineAsync();

                                AddOutput(result + "\n", OutputView.Logtype.Wcc);

                                Application.DoEvents();

                                if (reader.EndOfStream)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                AddOutput("Collision cache was not generated because mod was not cooked. \n",
                    OutputView.Logtype.Important);
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            #endregion

            #region DLC texture caching

            try
            {
                if (Directory.GetFiles(Path.Combine(ActiveMod.DlcDirectory, new TextureCache().TypeName), "*",
                    SearchOption.AllDirectories).Any())
                {
                    MainController.Get().ProjectStatus = "Generating DLC collision cache";
                    proc.Arguments =
                        $"buildcache physics -basedir={Path.Combine(ActiveMod.DlcDirectory, MainController.Get().TextureManager.TypeName)} -platform=pc -db={cookedDLCDir}\\cook.db  -out={DlcpackDir}\\collision.cache";
                    proc.UseShellExecute = false;
                    proc.RedirectStandardOutput = true;
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.CreateNoWindow = true;

                    AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                    using (var process = Process.Start(proc))
                    {
                        using (var reader = process.StandardOutput)
                        {
                            while (true)
                            {
                                var result = await reader.ReadLineAsync();

                                AddOutput(result + "\n", OutputView.Logtype.Wcc);

                                Application.DoEvents();

                                if (reader.EndOfStream)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                AddOutput("DLC wasn't cooked. Couldn't generate collision cache. \n", OutputView.Logtype.Important);
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            #endregion
        }

        private async Task PackTextures()
        {
            var config = MainController.Get().Configuration;
            var proc = new ProcessStartInfo(config.WccLite) { WorkingDirectory = Path.GetDirectoryName(config.WccLite) };
            var modpackDir = Path.Combine(ActiveMod.ProjectDirectory,
                @"packed\Mods\mod" + ActiveMod.Name + @"\content\");
            var DlcpackDir =
                Path.Combine(ActiveMod.ProjectDirectory, @"packed\DLC\dlc" + ActiveMod.Name + @"\content\");
            var cookedModDir = Path.Combine(ActiveMod.ProjectDirectory,
                @"cooked\Mods\mod" + ActiveMod.Name + @"\content\");
            var cookedDLCDir = Path.Combine(ActiveMod.ProjectDirectory,
                @"cooked\DLC\dlc" + ActiveMod.Name + @"\content\");

            #region Mod texture caching

            try
            {
                if (Directory.GetFiles(Path.Combine(ActiveMod.ModDirectory, new TextureCache().TypeName), "*",
                    SearchOption.AllDirectories).Any())
                {
                    MainController.Get().ProjectStatus = "Caching mod textures";
                    proc.Arguments =
                        $"buildcache textures -basedir={Path.Combine(ActiveMod.ModDirectory, MainController.Get().TextureManager.TypeName)} -platform=pc -db={cookedModDir}\\cook.db  -out={modpackDir}\\texture.cache";
                    proc.UseShellExecute = false;
                    proc.RedirectStandardOutput = true;
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.CreateNoWindow = true;

                    AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                    using (var process = Process.Start(proc))
                    {
                        using (var reader = process.StandardOutput)
                        {
                            while (true)
                            {
                                var result = await reader.ReadLineAsync();

                                AddOutput(result + "\n", OutputView.Logtype.Wcc);

                                Application.DoEvents();

                                if (reader.EndOfStream)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                AddOutput("Mod wasn't cooked. Textures won't be cached. \n", OutputView.Logtype.Important);
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            #endregion

            #region DLC texture caching

            try
            {
                if (Directory.GetFiles(Path.Combine(ActiveMod.DlcDirectory, new TextureCache().TypeName), "*",
                    SearchOption.AllDirectories).Any())
                {
                    MainController.Get().ProjectStatus = "Caching DLC textures";
                    proc.Arguments =
                        $"buildcache textures -basedir={Path.Combine(ActiveMod.DlcDirectory, MainController.Get().TextureManager.TypeName)} -platform=pc -db={cookedDLCDir}\\cook.db  -out={DlcpackDir}\\texture.cache";
                    proc.UseShellExecute = false;
                    proc.RedirectStandardOutput = true;
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.CreateNoWindow = true;

                    AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n", OutputView.Logtype.Important);

                    using (var process = Process.Start(proc))
                    {
                        using (var reader = process.StandardOutput)
                        {
                            while (true)
                            {
                                var result = await reader.ReadLineAsync();

                                AddOutput(result + "\n", OutputView.Logtype.Wcc);

                                Application.DoEvents();

                                if (reader.EndOfStream)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                AddOutput("DLC wasn't cooked. Textures won't be cached. \n", OutputView.Logtype.Important);
            }
            catch (Exception ex)
            {
                AddOutput(ex + "\n", OutputView.Logtype.Error);
            }

            #endregion
        }

        #endregion // Mod Pack
    }
}