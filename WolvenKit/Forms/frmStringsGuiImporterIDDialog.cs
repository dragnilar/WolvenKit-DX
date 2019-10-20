using System.Collections.Generic;
using System.Windows.Forms;

namespace WolvenKit
{
    public partial class frmStringsGuiImporterIDDialog : Form
    {
        private Dictionary<int, string> strings;

        public frmStringsGuiImporterIDDialog()
        {
            InitializeComponent();
        }

        public void PassStrings(Dictionary<int, string> strings)
        {
            this.strings = strings;
        }

        public void FillDataGridView()
        {
            foreach (var str in strings) dataGridView1.Rows.Add(str.Key, str.Value);
        }
    }
}