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
        public ByteArrayDialogView()
        {
            InitializeComponent();
            simpleButtonOpen.Click += SimpleButtonOpenOnClick;
            simpleButtonClose.Click += SimpleButtonCloseOnClick;
            simpleButtonExport.Click += SimpleButtonExportOnClick;
            simpleButtonImport.Click += SimpleButtonImportOnClick;
            
        }

        private void SimpleButtonImportOnClick(object sender, EventArgs e)
        {
            ((CVariable) Variable).cr2w.CreateVariableEditor(((CVariable) Variable), EVariableEditorAction.Import);
        }

        private void SimpleButtonOpenOnClick(object sender, EventArgs e)
        {
            ((CVariable) Variable).cr2w.CreateVariableEditor(((CVariable) Variable), EVariableEditorAction.Open);
        }

        private void SimpleButtonExportOnClick(object sender, EventArgs e)
        {
            ((CVariable) Variable).cr2w.CreateVariableEditor(((CVariable) Variable), EVariableEditorAction.Export);
        }

        private void SimpleButtonCloseOnClick(object sender, EventArgs e)
        {
            Close();
        }

        public IByteSource Variable { get; set; }

    }
}