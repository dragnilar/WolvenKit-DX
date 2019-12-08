using System;
using System.IO;
using System.Windows.Forms;
using WolvenKit.CR2W;
using WolvenKit.Interfaces;
using WolvenKit.Render;

namespace WolvenKit.Controls
{
    public partial class CR2WDocumentContainer : DevExpress.XtraEditors.XtraUserControl
    {
        public object SaveTarget { get; set; }
        public CR2WFile ContainerFile;
        public event EventHandler<FileSavedEventArgs> OnFileSaved;

        public string FileName
        {
            get => ContainerFile.FileName;
            set => ContainerFile.FileName = value;
        }
        public CR2WDocumentContainer()
        {
            InitializeComponent();
        }

        public void LoadFile(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                LoadFileInternal(fs, fileName);
            }

            SetUpControls(fileName);
        }
        public void LoadFile(string fileName, Stream stream)
        {
            LoadFileInternal(stream, fileName);
            SetUpControls(fileName);
        }

        private void SetUpControls(string fileName)
        {
            switch (Path.GetExtension(fileName))
            {
                case SupportedFileType.W2Scene:
                    {
                        var flowDiagram = new ChunkFlowDiagram
                        {
                            File = ContainerFile,
                            Dock = DockStyle.Fill
                        };
                        Controls.Add(flowDiagram);
                        break;
                    }
                case SupportedFileType.Journal:
                    {
                        var journalEditor = new frmJournalEditor
                        {
                            File = ContainerFile,
                            Dock = DockStyle.Fill
                        };
                        Controls.Add(journalEditor);
                        break;
                    }
                case SupportedFileType.Xbm:
                    {
                        var imageViewer = new ImagePreview
                        {
                            File = ContainerFile,
                            Dock = DockStyle.Fill
                        };
                        Controls.Add(imageViewer);
                        break;
                    }
                case SupportedFileType.W2Mesh:
                    {
                        var renderControl = new RendererControl
                        {
                            LoadDocument = delegate { return ContainerFile; },
                            MeshFile = ContainerFile,
                            Dock = DockStyle.Fill
                        };
                        Controls.Add(renderControl);
                        break;
                    }
                default:
                    var chunkEditor = new ChunkListEditor
                    {
                        File = ContainerFile,
                        Dock = DockStyle.Fill
                    };
                    Controls.Add(chunkEditor);
                    break;
            }
        }

        private void LoadFileInternal(Stream stream, string filename)
        {
            Text = Path.GetFileName(filename) + " [" + filename + "]";

            using (var reader = new BinaryReader(stream))
            {
                ContainerFile = new CR2WFile(reader)
                {
                    FileName = filename,
                    EditorController = MainController.Get(),
                    LocalizedStringSource = MainController.Get()
                };
            }
        }

        public void SaveFile()
        {
            if (SaveTarget == null)
                SaveToFileNameInternal();
            else
                SaveToMemoryStreamInternal();
        }

        private void SaveToMemoryStreamInternal()
        {
            using (var mem = new MemoryStream())
            {
                using (var writer = new BinaryWriter(mem))
                {
                    ContainerFile.Write(writer);
                    OnFileSaved?.Invoke(this, new FileSavedEventArgs { FileName = FileName, Stream = mem, File = ContainerFile });
                }
            }
        }

        private void SaveToFileNameInternal()
        {
            try
            {
                using (var mem = new MemoryStream())
                {
                    using (var writer = new BinaryWriter(mem))
                    {
                        ContainerFile.Write(writer);
                        mem.Seek(0, SeekOrigin.Begin);

                        using (var fs = new FileStream(FileName, FileMode.Create, FileAccess.Write))
                        {
                            mem.WriteTo(fs);
                            OnFileSaved?.Invoke(this,
                                new FileSavedEventArgs { FileName = FileName, Stream = fs, File = ContainerFile });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MainController.Get().QueueLog("Failed to save the file(s)! They are probably in use.\n" + e);
            }
        }
    }
}
