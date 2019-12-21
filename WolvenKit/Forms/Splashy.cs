using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace WolvenKit.Forms
{
    public partial class Splashy : SplashScreen
    {
        public enum SplashScreenCommand
        {
        }

        public Splashy()
        {
            InitializeComponent();
            Shown += Splashy_Shown;
            MainController.Get().PropertyChanged += MainControllerUpdated;
        }

        private void Splashy_Shown(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("Witcher3").Length != 0)
            {
                if (XtraMessageBox.Show(
                        "The Game is running. Please note that running the program like this makes some stuff unusable. Would you still like to run the program like this?",
                        "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    Environment.Exit(0);
                else
                    Close();
            }
        }

        private void MainControllerUpdated(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "LoadStatus")
                Invoke(new strDelegate(SetStatusLabelText), ((MainController) sender).LoadStatus);
            if (e.PropertyName == "Loaded")
                Invoke(new boolDelegate(Finish), ((MainController) sender).Loaded);
            if (e.PropertyName == "LoadPercentage")
                Invoke(new intDelegate(SetLoadPercentage), ((MainController) sender).LoadPercentage);
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        private void SetStatusLabelText(string text)
        {
            textEditStatus.Text = text;
        }

        private void SetLoadPercentage(int percentage)
        {
            progressBarControlSplashy.Position = percentage;
        }

        private void Finish(bool success)
        {
            if (!success)
            {
                textEditStatus.Text = "Failed to initialize!";
                Application.DoEvents();
                Thread.Sleep(3000);
            }
        }


        private delegate void strDelegate(string t);

        private delegate void boolDelegate(bool b);

        private delegate void intDelegate(int i);
    }
}