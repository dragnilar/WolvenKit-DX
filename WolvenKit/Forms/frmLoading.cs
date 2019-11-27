using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolvenKit.Forms
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            MainController.Get().PropertyChanged += MainControllerUpdated;
            MainController.Get().InitForm(this);
            VersionLbl.Text = "Version " +
                              FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            copyrightLbl.Text = "https://github.com/Traderain/Wolven-kit";
        }

        private void frmLoading_Shown(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("Witcher3").Length != 0)
            {
                if (MessageBox.Show(
                        "The Game is running. Please note that running the program like this makes some stuff unusable. Would you still like to run the program like this?",
                        "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    Environment.Exit(0);
                else
                    Close();
            }
            else
            {
                Application.DoEvents();
                Task.Factory.StartNew(() => MainController.Get().Initialize()); //Start the async task to load our stuff
            }
        }

        private void MainControllerUpdated(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "loadStatus")
                Invoke(new strDelegate(SetStatusLabelText), ((MainController) sender).loadStatus);
            if (e.PropertyName == "Loaded")
                Invoke(new boolDelegate(Finish), ((MainController) sender).Loaded);
        }

        private void Finish(bool b)
        {
            if (b)
            {
                Close();
            }
            else
            {
                LoadLbl.Text = "Failed to initialize!";
                Application.DoEvents();
                Thread.Sleep(3000);
                Close();
            }
        }

        private void SetStatusLabelText(string text)
        {
            LoadLbl.Text = text;
        }

        private delegate void strDelegate(string t);

        private delegate void boolDelegate(bool b);
    }
}