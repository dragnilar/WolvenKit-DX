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
            scintillaControl.StyleResetDefault();
            scintillaControl.Styles[Style.Default].BackColor = Color.Black;
            scintillaControl.Styles[Style.Default].ForeColor = Color.White;
            scintillaControl.Styles[Style.LineNumber].ForeColor = Color.White;
            scintillaControl.Styles[Style.Default].Font = "Consolas";
            scintillaControl.StyleClearAll();
            scintillaControl.Text = File.ReadAllText(FilePath);
            scintillaControl.AssignCmdKey(Keys.ControlKey | Keys.D, Command.LineDuplicate);
            ConfigureScintilla();

        }

        private void ConfigureScintilla()
        {
            scintillaControl.Margins[0].Width = 16;
            scintillaControl.Lexer = Lexer.Cpp;
            scintillaControl.SetKeywords(0, "private protected public default event enum struct editable function super parent statemachine class extends latent");
            scintillaControl.SetKeywords(1, "var this new import hint final timer return break exec");
            scintillaControl.SetKeywords(2, "int bool name float string String vector Vector out saved optional void array CEntityTemplate CR4Player W3IgniProjectile W3DamageAction SAbilityAttributeValue CEntity");
            scintillaControl.SetKeywords(3, "true false in");
            scintillaControl.SetKeywords(4, "if else for switch case while do");
            scintillaControl.Styles[Style.Cpp.CommentLine].ForeColor = Color.Green;
            scintillaControl.Styles[Style.Cpp.Comment].ForeColor = Color.Green;
            scintillaControl.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            scintillaControl.Styles[Style.Cpp.Number].ForeColor = Color.Orange;
            scintillaControl.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            scintillaControl.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            scintillaControl.Styles[Style.Cpp.String].ForeColor = Color.Orange; // Red
            scintillaControl.Styles[Style.Cpp.Character].ForeColor = Color.Orange; // Red
            scintillaControl.Styles[Style.Cpp.Verbatim].ForeColor = Color.Orange; // Red
            scintillaControl.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            scintillaControl.Styles[Style.Cpp.Operator].ForeColor = Color.Red;
            scintillaControl.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
            scintillaControl.Styles[Style.Cpp.GlobalClass].ForeColor = Color.Yellow;
            ;


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
