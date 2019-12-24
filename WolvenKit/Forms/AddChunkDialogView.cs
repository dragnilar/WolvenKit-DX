using System.Windows.Forms;
using WolvenKit.CR2W.Types;

namespace WolvenKit
{
    public partial class AddChunkDialogView : DevExpress.XtraEditors.XtraForm
    {
        public AddChunkDialogView()
        {
            InitializeComponent();


            var mng = CR2WTypeManager.Get();

            var types = mng.AvailableTypes;
            types.Sort();

            comboBoxEditType.Properties.Items.AddRange(types.ToArray());
        }

        public string ChunkType
        {
            get => comboBoxEditType.Text;
            set => comboBoxEditType.Text = value;
        }

        private void txType_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}