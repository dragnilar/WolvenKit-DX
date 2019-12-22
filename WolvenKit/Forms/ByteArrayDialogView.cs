using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WolvenKit.CR2W;
using WolvenKit.CR2W.Editors;
using WolvenKit.CR2W.Interfaces;
using WolvenKit.CR2W.Types;

namespace WolvenKit.Forms
{
    public partial class ByteArrayDialogView : DevExpress.XtraEditors.XtraForm
    {

        private IByteSource bytes;
        public ByteArrayDialogView()
        {
            InitializeComponent();
        }

        public IByteSource Variable
        {
            get { return bytes; }
            set
            {
                bytes = value;
            }
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            ((CVariable) Variable).cr2w.CreateVariableEditor(((CVariable) Variable), EVariableEditorAction.Open);
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            ((CVariable) Variable).cr2w.CreateVariableEditor(((CVariable) Variable), EVariableEditorAction.Import);
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            ((CVariable) Variable).cr2w.CreateVariableEditor(((CVariable) Variable), EVariableEditorAction.Export);
        }
    }
}