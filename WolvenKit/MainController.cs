using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WolvenKit.Bundles;
using WolvenKit.Cache;
using WolvenKit.Common;
using WolvenKit.Controls;
using WolvenKit.CR2W;
using WolvenKit.CR2W.Interfaces;
using WolvenKit.CR2W.Types;
using WolvenKit.Interfaces;
using WolvenKit.Properties;
using WolvenKit.Views;
using WolvenKit.W3Strings;

namespace WolvenKit
{
    public class MainController : IVariableEditor, ILocalizedStringSource, INotifyPropertyChanged
    {
        public const string ManagerCacheDir = "ManagerCache";
        private static MainController mainController;

        private bool _loaded;

        private string _loadstatus = "Loading...";

        private int _loadPercentage = 0;

        public static List<string> EditableFiles = new List<string>
        {
            SupportedFileType.Xbm,
            SupportedFileType.W2Mesh,
            SupportedFileType.W2Scene,
            SupportedFileType.Journal,
            SupportedFileType.W2Mg,
            SupportedFileType.W2P,
            SupportedFileType.Ent,
            SupportedFileType.RedDlc,
            SupportedFileType.Beh,
            SupportedFileType.BehTree,
            SupportedFileType.Rig,
            SupportedFileType.Env,
        };


        private KeyValuePair<string, OutputView.Logtype> _logMessage =
            new KeyValuePair<string, OutputView.Logtype>(string.Empty, OutputView.Logtype.Normal);

        private string _projectstatus = "Idle";
        public string InitialModProject = string.Empty;
        public string InitialWKP = string.Empty;

        /// <summary>
        ///     Shows whether there are unsaved changes in the project.
        /// </summary>
        public bool ProjectUnsaved = false;

        public string VLCLibDir = "C:\\Program Files\\VideoLAN\\VLC";

        private MainController()
        {
        }

        public Configuration Configuration { get; private set; }
        public MainWindow Window { get; private set; }
        public W3Mod ActiveMod { get; set; }

        public string ProjectStatus
        {
            get => _projectstatus;
            set => SetField(ref _projectstatus, value, "ProjectStatus");
        }

        public string LoadStatus
        {
            get => _loadstatus;
            set => SetField(ref _loadstatus, value, "LoadStatus");
        }
        
        public int LoadPercentage
        {
            get => _loadPercentage;
            set => SetField(ref _loadPercentage, value, "LoadPercentage");
        }
        

        public bool Loaded
        {
            get => _loaded;
            set => SetField(ref _loaded, value, "Loaded");
        }

        public KeyValuePair<string, OutputView.Logtype> LogMessage
        {
            get => _logMessage;
            set => SetField(ref _logMessage, value, "LogMessage");
        }

        public string GetLocalizedString(uint val)
        {
            return W3StringManager.GetString(val);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CreateVariableEditor(CVariable editvar, EVariableEditorAction action)
        {
            switch (action)
            {
                case EVariableEditorAction.Export:
                    ExportBytes(editvar);
                    break;
                case EVariableEditorAction.Import:
                    ImportBytes(editvar);
                    break;
                case EVariableEditorAction.Open:
                    OpenEditorFor(editvar);
                    break;
            }
        }

        /// <summary>
        ///     Usefull function for blindly importing a file.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <param name="archive">The manager to search for the file in.</param>
        /// <returns></returns>
        public List<byte[]> ImportFile(string name, IWitcherArchive archive)
        {
            var ret = new List<byte[]>();
            archive.FileList.ToList().Where(x => x.Name.Contains(name)).ToList().ForEach(x =>
            {
                using (var ms = new MemoryStream())
                {
                    x.Extract(ms);
                    ret.Add(ms.ToArray());
                }
            });
            return ret;
        }

        /// <summary>
        ///     Here we setup stuff we need in every form. Borders etc can be done here in the future.
        /// </summary>
        /// <param name="form">The form to initialize.</param>
        public void InitForm(Form form)
        {
            var bmp = Resources.Logo_wkit;
            form.Icon = Icon.FromHandle(bmp.GetHicon());
        }

        /// <summary>
        ///     Queues a string for logging in the main window.
        /// </summary>
        /// <param name="msg">The message to log.</param>
        /// <param name="type">The type of the log. Not needed.</param>
        public void QueueLog(string msg, OutputView.Logtype type = OutputView.Logtype.Normal)
        {
            LogMessage = new KeyValuePair<string, OutputView.Logtype>(msg, type);
        }

        public static MainController Get()
        {
            if (mainController == null)
            {
                mainController = new MainController();
                mainController.Configuration = Configuration.Load();
                mainController.Window = new MainWindow();
            }

            return mainController;
        }

        /// <summary>
        ///     Initializes the archive managers in an async thread
        /// </summary>
        /// <returns></returns>
        public void Initialize()
        {
            try
            {
                LoadStatus = "Loading string manager";

                #region Load string manager

                var sw = new Stopwatch();
                sw.Start();
                if (W3StringManager == null)
                    try
                    {
                        if (File.Exists(Path.Combine(ManagerCacheDir, "string_cache.bin")) &&
                            new FileInfo(Path.Combine(ManagerCacheDir, "string_cache.bin")).Length > 0)
                        {
                            using (var file = File.Open(Path.Combine(ManagerCacheDir, "string_cache.bin"),
                                FileMode.Open))
                            {
                                W3StringManager = Serializer.Deserialize<W3StringManager>(file);
                            }
                        }
                        else
                        {
                            W3StringManager = new W3StringManager();
                            W3StringManager.Load(Configuration.TextLanguage,
                                Path.GetDirectoryName(Configuration.ExecutablePath));
                            Directory.CreateDirectory(ManagerCacheDir);
                            using (var file = File.Open(Path.Combine(ManagerCacheDir, "string_cache.bin"),
                                FileMode.Create))
                            {
                                Serializer.Serialize(file, W3StringManager);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        if (File.Exists(Path.Combine(ManagerCacheDir, "string_cache.bin")))
                            File.Delete(Path.Combine(ManagerCacheDir, "string_cache.bin"));
                        W3StringManager = new W3StringManager();
                        W3StringManager.Load(Configuration.TextLanguage,
                            Path.GetDirectoryName(Configuration.ExecutablePath));
                    }

                var i = sw.ElapsedMilliseconds;
                sw.Stop();

                #endregion

                LoadStatus = "Loading bundle manager!";
                LoadPercentage = 14;

                #region Load bundle manager

                if (BundleManager == null)
                    try
                    {
                        if (File.Exists(Path.Combine(ManagerCacheDir, "bundle_cache.json")))
                        {
                            using (var file = File.OpenText(Path.Combine(ManagerCacheDir, "bundle_cache.json")))
                            {
                                var serializer = new JsonSerializer();
                                serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                                serializer.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                                serializer.TypeNameHandling = TypeNameHandling.Auto;
                                BundleManager = (BundleManager)serializer.Deserialize(file, typeof(BundleManager));
                            }
                        }
                        else
                        {
                            BundleManager = new BundleManager();
                            BundleManager.LoadAll(Path.GetDirectoryName(Configuration.ExecutablePath));
                            File.WriteAllText(Path.Combine(ManagerCacheDir, "bundle_cache.json"),
                                JsonConvert.SerializeObject(BundleManager, Formatting.None, new JsonSerializerSettings
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                                    TypeNameHandling = TypeNameHandling.Auto
                                }));
                        }
                    }
                    catch (Exception)
                    {
                        if (File.Exists(Path.Combine(ManagerCacheDir, "bundle_cache.json")))
                            File.Delete(Path.Combine(ManagerCacheDir, "bundle_cache.json"));
                        BundleManager = new BundleManager();
                        BundleManager.LoadAll(Path.GetDirectoryName(Configuration.ExecutablePath));
                    }

                #endregion

                LoadStatus = "Loading mod bundle manager!";
                LoadPercentage = 28;

                #region Load mod bundle manager

                if (ModBundleManager == null)
                {
                    ModBundleManager = new BundleManager();
                    ModBundleManager.LoadModsBundles(Path.GetDirectoryName(Configuration.ExecutablePath));
                }

                #endregion

                LoadStatus = "Loading texture manager!";
                LoadPercentage = 42;

                #region Load texture manager

                if (TextureManager == null)
                    try
                    {
                        if (File.Exists(Path.Combine(ManagerCacheDir, "texture_cache.json")))
                        {
                            using (var file = File.OpenText(Path.Combine(ManagerCacheDir, "texture_cache.json")))
                            {
                                var serializer = new JsonSerializer();
                                serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                                serializer.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                                serializer.TypeNameHandling = TypeNameHandling.Auto;
                                TextureManager = (TextureManager)serializer.Deserialize(file, typeof(TextureManager));
                            }
                        }
                        else
                        {
                            TextureManager = new TextureManager();
                            TextureManager.LoadAll(Path.GetDirectoryName(Configuration.ExecutablePath));
                            File.WriteAllText(Path.Combine(ManagerCacheDir, "texture_cache.json"),
                                JsonConvert.SerializeObject(TextureManager, Formatting.None, new JsonSerializerSettings
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                                    TypeNameHandling = TypeNameHandling.Auto
                                }));
                        }
                    }
                    catch (Exception)
                    {
                        if (File.Exists(Path.Combine(ManagerCacheDir, "texture_cache.json")))
                            File.Delete(Path.Combine(ManagerCacheDir, "texture_cache.json"));
                        TextureManager = new TextureManager();
                        TextureManager.LoadAll(Path.GetDirectoryName(Configuration.ExecutablePath));
                    }

                #endregion

                LoadStatus = "Loading mod texure manager!";
                LoadPercentage = 56;

                #region Load mod texture manager

                if (ModTextureManager == null)
                {
                    ModTextureManager = new TextureManager();
                    ModTextureManager.LoadModsBundles(Path.GetDirectoryName(Configuration.ExecutablePath));
                }

                #endregion

                LoadStatus = "Loading sound manager!";
                LoadPercentage = 70;

                #region Load sound manager

                if (SoundManager == null)
                    try
                    {
                        if (File.Exists(Path.Combine(ManagerCacheDir, "sound_cache.json")))
                        {
                            using (var file = File.OpenText(Path.Combine(ManagerCacheDir, "sound_cache.json")))
                            {
                                var serializer = new JsonSerializer();
                                serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                                serializer.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                                serializer.TypeNameHandling = TypeNameHandling.Auto;
                                SoundManager = (SoundManager)serializer.Deserialize(file, typeof(SoundManager));
                            }
                        }
                        else
                        {
                            SoundManager = new SoundManager();
                            SoundManager.LoadAll(Path.GetDirectoryName(Configuration.ExecutablePath));
                            File.WriteAllText(Path.Combine(ManagerCacheDir, "sound_cache.json"),
                                JsonConvert.SerializeObject(SoundManager, Formatting.None, new JsonSerializerSettings
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                                    TypeNameHandling = TypeNameHandling.Auto
                                }));
                        }
                    }
                    catch (Exception)
                    {
                        if (File.Exists(Path.Combine(ManagerCacheDir, "sound_cache.json")))
                            File.Delete(Path.Combine(ManagerCacheDir, "sound_cache.json"));
                        SoundManager = new SoundManager();
                        SoundManager.LoadAll(Path.GetDirectoryName(Configuration.ExecutablePath));
                    }

                #endregion

                LoadStatus = "Loading mod sound manager!";
                LoadPercentage = 84;

                #region Load mod sound manager

                if (ModSoundManager == null)
                {
                    ModSoundManager = new SoundManager();
                    ModSoundManager.LoadModsBundles(Path.GetDirectoryName(Configuration.ExecutablePath));
                }

                #endregion

                LoadStatus = "Loaded";
                LoadPercentage = 100;

                mainController.Loaded = true;
            }
            catch (Exception e)
            {
                mainController.Loaded = false;
                Console.WriteLine(e.Message);
            }
        }

        public CR2WDocumentContainer LoadDocument(string filename, bool suppressErrors = false)
        {
            return Window.LoadDocument(filename, null, suppressErrors);
        }

        public CR2WDocumentContainer LoadDocument(string filename, MemoryStream memoryStream, bool suppressErrors = false)
        {
            return Window.LoadDocument(filename, memoryStream, suppressErrors);
        }

        public void ReloadStringManager()
        {
            W3StringManager.Load(Configuration.TextLanguage, Path.GetDirectoryName(Configuration.ExecutablePath), true);
        }

        private void ImportBytes(CVariable editvar)
        {
            var dlg = new OpenFileDialog { InitialDirectory = Get().Configuration.InitialExportDirectory };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Get().Configuration.InitialExportDirectory = Path.GetDirectoryName(dlg.FileName);

                using (var fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(fs))
                    {
                        var bytes = ImportExportUtility.GetImportBytes(reader);
                        editvar.SetValue(bytes);
                    }
                }
            }
        }

        private void ExportBytes(CVariable editvar)
        {
            var dlg = new SaveFileDialog();
            byte[] bytes = null;

            if (editvar is IByteSource) bytes = ((IByteSource)editvar).Bytes;

            dlg.Filter = string.Join("|", ImportExportUtility.GetPossibleExtensions(bytes, editvar.Name));
            dlg.InitialDirectory = Get().Configuration.InitialExportDirectory;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Get().Configuration.InitialExportDirectory = Path.GetDirectoryName(dlg.FileName);

                using (var fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write))
                {
                    using (var writer = new BinaryWriter(fs))
                    {
                        bytes = ImportExportUtility.GetExportBytes(bytes, Path.GetExtension(dlg.FileName));
                        writer.Write(bytes);
                    }
                }
            }
        }

        private void OpenHexEditorFor(CVariable editvar)
        {
            var editor = new frmHexEditorView { File = editvar.cr2w };

            if (editvar is IByteSource) editor.Bytes = ((IByteSource)editvar).Bytes;

            editor.Text = "Hex Viewer [" + editvar.FullName + "]";
            editor.Show();
        }

        private void OpenEditorFor(CVariable editvar)
        {
            byte[] bytes = null;

            if (editvar is IByteSource) bytes = ((IByteSource)editvar).Bytes;

            if (bytes != null)
            {
                try
                {
                    var doc = new XtraForm { StartPosition = FormStartPosition.CenterScreen, Text = editvar.FullName, Tag = "BufferEditor", Height = 640, Width = 800};
                    var container = new CR2WDocumentContainer();
                    var memoryStream = new MemoryStream(bytes);
                    container.LoadFile(editvar.FullName, memoryStream);
                    container.OnFileSaved += OnVariableEditorSave;
                    container.SaveTarget = editvar;
                    container.Dock = DockStyle.Fill;
                    doc.Controls.Add(container);
                    doc.Show();
                }
                catch (Exception ex)
                {
                    QueueLog($"Error opening buffer/file, defaulting to the hex editor.\n\n Further Details: {ex}", OutputView.Logtype.Error);
                    OpenHexEditorFor(editvar);
                }
            }
        }

        private void OnVariableEditorSave(object sender, FileSavedEventArgs args)
        {
            if (args.Stream is MemoryStream)
            {
                var doc = (CR2WDocumentContainer)sender;
                var editvar = (CVariable)doc.SaveTarget;
                editvar.SetValue(((MemoryStream)args.Stream).ToArray());
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #region Archive Managers

        //Public getters
        public W3StringManager W3StringManager { get; private set; }

        public BundleManager BundleManager { get; private set; }

        public BundleManager ModBundleManager { get; private set; }

        public SoundManager SoundManager { get; private set; }

        public SoundManager ModSoundManager { get; private set; }

        public TextureManager TextureManager { get; private set; }

        public TextureManager ModTextureManager { get; private set; }

        #endregion
    }
}