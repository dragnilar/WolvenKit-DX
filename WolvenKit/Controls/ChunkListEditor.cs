using WolvenKit.CR2W;

namespace WolvenKit.Controls
{
    public partial class ChunkListEditor : DevExpress.XtraEditors.XtraUserControl
    {
        public CR2WFile File
        {
            get => chunkListViewerControl.File;
            set => chunkListViewerControl.File = value;
        }

        public ChunkListEditor()
        {
            InitializeComponent();
        }

        private void chunkListViewerControl_OnSelectChunk(object sender, SelectChunkArgs e)
        {
            if (e.Chunk != null)
            {
                chunkPropertyViewerControl.Chunk = e.Chunk;
            }
        }
    }
}
