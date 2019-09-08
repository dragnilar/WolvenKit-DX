using System;
using System.Linq;
using System.Windows.Forms;

namespace WolvenKit
{
    public partial class frmStringsGuiScriptsPrefixDialog : Form
    {
        public string prefix = string.Empty;
        public frmStringsGuiScriptsPrefixDialog()
        {
            InitializeComponent();

            this.buttonOk.DialogResult = DialogResult.OK;
            this.buttonCancel.DialogResult = DialogResult.Cancel;
        }

        private void textBoxPrefix_TextChanged(object sender, EventArgs e)
        {
            prefix = this.textBoxPrefix.Text;
        }
    }
}
