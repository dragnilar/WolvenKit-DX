using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WeifenLuo.WinFormsUI.Docking;
using WolvenKit.CR2W;
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
                case ".w2scene":
                {
                    var flowDiagram = new ChunkFlowDiagram
                    {
                        File = ContainerFile,
                        Dock =  DockStyle.Fill
                    };
                    Controls.Add(flowDiagram);
                    break;
                }
                case ".journal":
                {
                    var JournalEditor = new frmJournalEditor
                    {
                        File = ContainerFile,
                        Dock =  DockStyle.Fill
                    };
                    Controls.Add(JournalEditor);
                    break;
                }
                case ".xbm":
                {
                    var ImageViewer = new frmImagePreview
                    {
                        File = ContainerFile,
                        Dock =  DockStyle.Fill
                    };
                    Controls.Add(ImageViewer);
                    break;
                }
                case ".w2mesh":
                {
                    var renderControl = new frmRender
                    {
                        LoadDocument = delegate { return ContainerFile; },
                        MeshFile = ContainerFile,
                        DockAreas = DockAreas.Document
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
                saveToFileName();
            else
                saveToMemoryStream();
        }

        private void saveToMemoryStream()
        {
            using (var mem = new MemoryStream())
            {
                using (var writer = new BinaryWriter(mem))
                {
                    ContainerFile.Write(writer);

                    if (OnFileSaved != null)
                        OnFileSaved(this, new FileSavedEventArgs {FileName = FileName, Stream = mem, File = ContainerFile});
                }
            }
        }

        private void saveToFileName()
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

                            if (OnFileSaved != null)
                                OnFileSaved(this,
                                    new FileSavedEventArgs {FileName = FileName, Stream = fs, File = ContainerFile});
                            fs.Close();
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
