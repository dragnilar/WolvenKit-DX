using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ScintillaNET;
using WolvenKit.CR2W;

namespace WolvenKit.Controls
{
    public partial class ScriptEditor : DevExpress.XtraEditors.XtraUserControl
    {

        public string FilePath { get; set; }

        public ScriptEditor(string filePath)
        {
            InitializeComponent();
            FilePath = filePath;
            scintillaControl.Styles[Style.Default].BackColor = Color.DarkSlateGray;
            scintillaControl.Text = File.ReadAllText(FilePath);
            ConfigureScintilla();

        }

        private void ConfigureScintilla()
        {
            scintillaControl.Margins[0].Width = 16;
        }

        public void SaveFile()
        {
            File.WriteAllText(FilePath, "");
            using (var streamWriter = File.AppendText(FilePath))
            {
                streamWriter.Write(scintillaControl.Text);
            }
        }
    }
}
