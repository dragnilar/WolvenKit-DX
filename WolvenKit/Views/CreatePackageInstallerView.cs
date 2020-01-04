using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.Utils.StructuredStorage.Internal.Reader;
using DevExpress.Xpo.Logger;
using DevExpress.XtraEditors;

namespace WolvenKit.Views
{
    public partial class CreatePackageInstallerView : DevExpress.XtraEditors.XtraForm
    {
        private Color HeaderColor = Color.Red;
        private Color IconBackGroundColor = Color.Black;
        private string IconPath; 
        public CreatePackageInstallerView()
        {
            InitializeComponent();
            Shown += OnShown;
            simpleButtonCreatePackage.Click += SimpleButtonCreatePackageOnClick;
            simpleButtonCancel.Click += SimpleButtonCancelOnClick;
        }

        private void SimpleButtonCancelOnClick(object sender, EventArgs e)
        {
            Close();
        }

        private async void SimpleButtonCreatePackageOnClick(object sender, EventArgs e)
        {
            try
            {
                using (var saveDialog = new XtraSaveFileDialog())
                {
                    saveDialog.Title = "Please select a location to save the package";
                    saveDialog.Filter = "WolvenKit Package File | *.wkp";
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        var isSuccessful = await CreatePackage(saveDialog.FileName);
                        if (isSuccessful)
                        {
                            XtraMessageBox.Show($"Package {saveDialog.FileName} Has Been Successfully Created!",
                                "Package Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(
                                "An error occurred creating the package. Review the log / output window for details.",
                                "Error Creating The Package", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error Creating The Package: \n\n {ex}", "Error Creating Package",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void OnShown(object sender, EventArgs e)
        {
            colorPickEditIconBG.Color = IconBackGroundColor;
            colorPickEditHeaderBGColor.Color = HeaderColor;
        }


        private async Task<bool> CreatePackage(string outpath)
        {
            if (MainController.Get().ActiveMod == null)
                MessageBox.Show("No project loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            var packeddir = Path.Combine(MainController.Get().ActiveMod.ProjectDirectory, @"packed\");
            var contentdir = Path.Combine(MainController.Get().ActiveMod.ProjectDirectory, @"packed\content\");
            if (!Directory.Exists(contentdir))
            {
                Directory.CreateDirectory(contentdir);
            }
            else
            {
                var di = new DirectoryInfo(contentdir);
                foreach (var file in di.GetFiles()) file.Delete();
                foreach (var dir in di.GetDirectories()) dir.Delete(true);
            }

            var packtask = MainController.Get().Window.PackAndInstallMod();
            await packtask;
            var installdir = Path.Combine(MainController.Get().ActiveMod.ProjectDirectory, @"Installer/");
            if (!Directory.Exists(installdir))
                Directory.CreateDirectory(installdir);
            var asm = WKPackage.CreateModAssembly(textEditModVersion.Text, textEditModName.Text,
                new Tuple<string, string, string, string, string, string>(textEditAuthor.Text, textEditDonationUrl.Text, textEditWeb.Text,
                    textEditFaceButt.Text, textEditTwitter.Text, textEditYouTube.Text), memoEditDescription.Text, memoEditLargeDescription.Text,
                textEditLicense.Text, new Tuple<Color, bool, Color>(HeaderColor, checkEditBlackTextColor.Checked, IconBackGroundColor),
                new List<XElement>());
            var pkg = new WKPackage(asm, IconPath,
                Path.Combine(MainController.Get().ActiveMod.ProjectDirectory, @"packed"));

            pkg.Save(outpath);
            MainController.Get().LogMessage =
                new KeyValuePair<string, OutputView.Logtype>("Installer created: " + outpath + "\n",
                    OutputView.Logtype.Success);
            if (!File.Exists(outpath))
            {
                MainController.Get().LogMessage =
                    new KeyValuePair<string, OutputView.Logtype>("Couldn't create installer. Something went wrong.",
                        OutputView.Logtype.Error);
                return false;
            }

            MainController.Get().ProjectStatus = "Ready";
            Commonfunctions.ShowFileInExplorer(outpath);
            return true;
        }

        private void colorPickEditHeaderBGColor_EditValueChanged(object sender, EventArgs e)
        {
            HeaderColor = colorPickEditHeaderBGColor.Color;
        }

        private void colorPickEditIconBG_EditValueChanged(object sender, EventArgs e)
        {
            IconBackGroundColor = colorPickEditIconBG.Color;
        }

        private void pictureEditModIcon_EditValueChanged(object sender, EventArgs e)
        {
            var imagePath = pictureEditModIcon.GetLoadedImageLocation();
            IconPath = !string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath) ? imagePath : string.Empty;
        }
    }



}