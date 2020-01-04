using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WolvenKit.Views
{
    public partial class frmExtractAmbigious : Form
    {
        public frmExtractAmbigious(IEnumerable<string> options)
        {
            InitializeComponent();

            lsBundleList.Items.AddRange(options.ToArray());
            lsBundleList.SelectedIndex = lsBundleList.Items.Count - 1;
        }

        public string SelectedBundle => (string)lsBundleList.SelectedItem;
        public bool Skip => dnamaCHB.Checked;
    }
}