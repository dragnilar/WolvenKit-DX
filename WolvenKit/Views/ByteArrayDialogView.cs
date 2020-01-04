using System;
using WolvenKit.CR2W;
using WolvenKit.CR2W.Interfaces;
using WolvenKit.CR2W.Types;

namespace WolvenKit.Views
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