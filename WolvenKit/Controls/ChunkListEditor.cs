using DevExpress.XtraGrid.Views.Grid;
using WolvenKit.CR2W;

namespace WolvenKit.Controls
{
    public partial class ChunkListEditor : DevExpress.XtraEditors.XtraUserControl
    {
        private CR2WFile _file;
        public CR2WFile File
        {
            get => _file;
            set
            {
                _file = value;
                gridControlChunkEditor.DataSource = _file.chunks;
            }
        }

        public ChunkListEditor()
        {
            InitializeComponent();
            gridViewChunkEditor.RowClick += GridViewChunkEditorOnRowClick;
        }

        private void GridViewChunkEditorOnRowClick(object sender, RowClickEventArgs e)
        {
            if (gridViewChunkEditor.GetRow(e.RowHandle) is CR2WChunk selectedRow)
            {
                chunkPropertyViewerControl.Chunk = selectedRow;
                chunkListPropertyEditor1.Chunk = selectedRow;
            }
        }

    }
}
