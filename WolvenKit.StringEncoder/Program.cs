using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using WolvenKit.Interfaces;

namespace WolvenKit.StringEncoder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var w3Mod = new W3Mod();
            var dlg = new OpenFileDialog
            {
                Title = "Open Witcher 3 Mod Project",
                Filter = "Witcher 3 Mod|*.w3modproj",
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var ser = new XmlSerializer(typeof(W3Mod));
                var modfile = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                w3Mod = (W3Mod)ser.Deserialize(modfile);
                w3Mod.FileName = dlg.FileName;
                modfile.Close();
            }
            else
            {
                Environment.Exit(0);
            }


            Application.Run(new StringEncoderView(w3Mod, true));
        }
    }
}
