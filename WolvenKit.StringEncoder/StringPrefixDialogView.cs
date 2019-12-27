using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WolvenKit
{
    public partial class StringPrefixDialogView : XtraForm
    {
        public string prefix = string.Empty;

        public StringPrefixDialogView()
        {
            InitializeComponent();

            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            textBoxPrefix.Focus();
        }

        private void textBoxPrefix_TextChanged(object sender, EventArgs e)
        {
            prefix = textBoxPrefix.Text;
        }
    }
}