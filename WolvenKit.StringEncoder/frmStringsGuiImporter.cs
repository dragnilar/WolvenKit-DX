using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WolvenKit.Interfaces;
using WolvenKit.W3Strings;

namespace WolvenKit
{
    public partial class frmStringsGuiImporter : Form
    {
        private readonly List<string> guiStrings;

        private bool matchCaseSearch;
        private readonly List<List<string>> strings = new List<List<string>>();
        private readonly W3StringManager stringsManager;
        private readonly Configuration _configuration;

        public frmStringsGuiImporter(List<string> guiStrings, W3StringManager w3StringManager, Configuration configuration)
        {
            this.guiStrings = guiStrings;
            stringsManager = w3StringManager;
            _configuration = configuration;
            InitializeComponent();
        }

        public frmStringsGuiImporter(W3StringManager w3StringManager, Configuration configuration)
        {
            InitializeComponent();
            stringsManager = w3StringManager;
            _configuration = configuration;
            comboBoxLanguage.Text = _configuration.TextLanguage;
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void buttonShowID_Click(object sender, EventArgs e)
        {
            ShowIDDialog();
        }

        private void ShowIDDialog()
        {
            var idDialog = new frmStringsGuiImporterIDDialog();
            var stringsWithIDs = new Dictionary<int, string>();

            foreach (ListViewItem item in listViewStrings.SelectedItems)
            {
                var stringWithID = strings.Find(x => x.Contains(item.Text));
                stringsWithIDs.Add(Convert.ToInt32(stringWithID[0]), stringWithID[2]);
            }

            idDialog.PassStrings(stringsWithIDs);
            idDialog.FillDataGridView();
            idDialog.ShowDialog();
        }

        private void listViewStrings_ItemSelectionChanged(object sender, EventArgs e)
        {
            if (listViewStrings.SelectedItems.Count != 0)
                buttonShowID.Enabled = true;
            else
                buttonShowID.Enabled = false;
        }

        private void checkBoxMachCaseSearch_CheckedChanged(object sender, EventArgs e)
        {
            matchCaseSearch = checkBoxMachCaseSearch.Checked;
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
        }

        private void buttonLoadGameStr_Click(object sender, EventArgs e)
        {
            listViewStrings.Clear();
            strings.Clear();

            LoadGameStrings();
        }

        private void buttonLoadCustom_Click(object sender, EventArgs e)
        {
            listViewStrings.Clear();
            strings.Clear();

            LoadCustomStrings();
        }

        private void LoadCustomStrings()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "W3Strings | *.w3strings";
            var path = string.Empty;
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            path = ofd.FileName;

            var file = new W3StringFile();

            using (var br = new BinaryReader(File.OpenRead(path)))
            {
                file.Read(br);
            }

            foreach (var str in file.block1) strings.Add(new List<string> { str.str_id.ToString(), "0", str.str });

            FillListView(strings);
            toolStripStatusLabelStringsCount.Text = "Strings Loaded: " + strings.Count;
        }

        private void LoadGameStrings()
        {
            stringsManager.Load(comboBoxLanguage.SelectedItem.ToString(),
                Path.GetDirectoryName(_configuration.ExecutablePath));

            foreach (var line in stringsManager.Lines)
                strings.Add(new List<string> { line.Value[0].str_id.ToString(), "0", line.Value[0].str });
            FillListView(strings);
            toolStripStatusLabelStringsCount.Text = "Strings Loaded: " + strings.Count;

            if (guiStrings.Count == 0)
                return;

            var matchedStringsCounter = 0;
            foreach (ListViewItem item in listViewStrings.Items)
            {
                if (guiStrings.Contains(item.Text))
                {
                    item.ForeColor = Color.Blue;
                    ++matchedStringsCounter;
                }

                if (matchedStringsCounter == guiStrings.Count)
                    return;
            }
        }

        private void FillListView(List<List<string>> strings)
        {
            var items = new List<ListViewItem>();

            foreach (var str in strings) items.Add(new ListViewItem(str[2]));
            listViewStrings.Items.AddRange(items.ToArray());
        }

        private void Search()
        {
            listViewStrings.Clear();
            if (textBoxSearch.Text == string.Empty)
                FillListView(strings);
            var stringsArr = strings.Select(a => a.ToArray()).ToArray();
            var results = new List<List<string>>();
            if (matchCaseSearch)
                foreach (var str in strings)
                {
                    if (str[2].Contains(textBoxSearch.Text))
                        results.Add(str);
                }
            else
                foreach (var str in strings)
                    if (str[2].ToUpper().Contains(textBoxSearch.Text.ToUpper()))
                        results.Add(str);

            FillListView(results.ToList());
        }

        private void Import()
        {
            if (listViewStrings.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nothing selected.", "Wolven Kit", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var stringsToImport = new List<List<string>>();
            foreach (ListViewItem item in listViewStrings.SelectedItems)
            {
                foreach (var str in strings)
                    if (item.Text == str[2])
                        stringsToImport.Add(str);
                item.ForeColor = Color.Blue;
            }

            stringsManager.SaveImportedStrings(stringsToImport);
        }
    }
}