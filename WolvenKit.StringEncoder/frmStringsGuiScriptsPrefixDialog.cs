using System;
using System.Windows.Forms;

namespace WolvenKit
{
    public partial class frmStringsGuiScriptsPrefixDialog : Form
    {
        public string prefix = string.Empty;

        public frmStringsGuiScriptsPrefixDialog()
        {
            InitializeComponent();

            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
        }

        private void textBoxPrefix_TextChanged(object sender, EventArgs e)
        {
            prefix = textBoxPrefix.Text;
        }
    }
}