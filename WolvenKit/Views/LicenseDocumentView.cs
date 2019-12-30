using DevExpress.XtraEditors;
using WolvenKit.Properties;

namespace WolvenKit
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