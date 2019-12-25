using System;
using System.Windows.Forms;

namespace WolvenKit.Bundles
{
    internal class __Metadata_Store_Test
    {
        [STAThread]
        private static int Main(string[] args)
        {
            using (var of = new OpenFileDialog {Filter = "Metadata files | *.store"})
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    var f = new Metadata_Store(of.FileName);
                }
            }

            Console.WriteLine("Done!");
            Console.ReadLine();
            return 0;
        }
    }
}