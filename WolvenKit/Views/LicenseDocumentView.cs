using DevExpress.XtraEditors;
using WolvenKit.Properties;

namespace WolvenKit.Views
{
    public partial class LicenseDocumentView : XtraForm
    {
        public LicenseDocumentView()
        {
            InitializeComponent();
            richEditControlLIcense.RtfText = Resources.wcc_eula;
        }
    }
}