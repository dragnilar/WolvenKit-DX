using RtfPipe;
using System.IO;
using System.Windows.Forms;
using WolvenKit.Properties;

namespace WolvenKit
{
    public partial class frmWCCLicense : Form
    {
        public frmWCCLicense()
        {
            InitializeComponent();
            using (var reader = new StringReader(Resources.wcc_eula))
            {
                browserwcclicense.DocumentText =
                    Rtf.ToHtml(new RtfSource(reader));
            }

        }
    }
}