using System;
using System.Windows.Forms;

namespace WolvenKit.Views
{
    public partial class Input : Form
    {
        public Input(string question)
        {
            InitializeComponent();
            questionLabel.Text = question;
        }

        public string Resulttext => textBox1.Text;

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}