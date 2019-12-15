using BrightIdeasSoftware;
using DevExpress.XtraEditors;
using System.IO;
using WolvenKit.Controls;
using WolvenKit.CR2W;

namespace WolvenKit
{
    public partial class EmbeddedFilesView : XtraUserControl
    {
        private CR2WFile file;

        public EmbeddedFilesView()
        {
            InitializeComponent();
            UpdateList();
        }

        public CR2WFile File
        {
            get => file;
            set
            {
                file = value;
                UpdateList();
            }
        }

        private void UpdateList()
        {
            if (File == null)
                return;

            listView.Objects = File.block7;
        }

        private void listView_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Column == null || e.Item == null)
                return;

            if (e.ClickCount == 2)
            {
                var mem = new MemoryStream(((CR2WHeaderBlock7)e.Model).unknowndata);

                var doc = MainController.Get().LoadDocument("Embedded file", mem);
                if (doc != null)
                {
                    doc.OnFileSaved += OnFileSaved;
                    doc.SaveTarget = (CR2WHeaderBlock7)e.Model;
                }
            }
        }

        private void OnFileSaved(object sender, FileSavedEventArgs e)
        {
            var doc = (CR2WDocumentContainer)sender;
            var editvar = (CR2WHeaderBlock7)doc.SaveTarget;
            editvar.unknowndata = ((MemoryStream)e.Stream).ToArray();
        }
    }
}