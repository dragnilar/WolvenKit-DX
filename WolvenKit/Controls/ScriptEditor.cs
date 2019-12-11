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


        public ScriptEditor(string filePath)
        {
            InitializeComponent();
            scintillaControl.Styles[Style.Default].BackColor = Color.DarkSlateGray;
            scintillaControl.Styles[Style.Default].ForeColor = Color.White;
            scintillaControl.Text = File.ReadAllText(filePath);

        }
    }
}
