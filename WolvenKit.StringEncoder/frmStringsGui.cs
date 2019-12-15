using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.Utils.Extensions;
using WolvenKit.Common;
using WolvenKit.W3Strings;

namespace WolvenKit.StringEncoder
{
    internal enum EDisplayNameType
    {
        VAR,
        GROUP
    }

    public partial class frmStringsGui : XtraForm
    {
        private readonly W3Mod activeMod;
        private readonly List<string> groups = new List<string>();

        private readonly int idsLimit = 1000;

        private readonly IEnumerable<W3Language> languages = W3Language.languages;

        private readonly List<LanguageStringsCollection> languagesStrings = new List<LanguageStringsCollection>();
        private readonly List<int> modIDs = new List<int> { 0 };
        private bool abortedSwitchingBackToAllLanguages;
        private int counter;

        private string currentModID = string.Empty;
        private bool fileIsSaved;

        private bool fileOpened;
        private string languageTabSelected = "ar";
        private bool multipleIDs;
        private bool rowAddedAutomatically;

        private BindingList<W3EncodedString> W3EncodedStrings;

        private object AllLanguagesVal;
        private object SeperateLanguagesVal;
        private bool BringToFront;

        public frmStringsGui(W3Mod mod, bool bringToFront = false)
        {
            InitializeComponent();
            activeMod = mod;
            AllLanguagesVal = repoItemComboBoxLanguage.Items[0];
            SeperateLanguagesVal = repoItemComboBoxLanguage.Items[1];
            barEditItemLanguage.EditValue = AllLanguagesVal;
            barButtonItemSave.Enabled = false;

            CreateDataSource();

            if (activeMod != null)
            {
                var csvDir = activeMod.ProjectDirectory + "\\strings\\CSV";
                if (!Directory.Exists(csvDir))
                    return;

                var fileNames = Directory.GetFiles(csvDir, "*.csv*", SearchOption.AllDirectories)
                    .Select(x => Path.GetFullPath(x)).ToArray();
                if (fileNames.Length == 0)
                    return;

                barEditItemLanguage.EditValue = AllLanguagesVal;
                languagesStrings.Clear();

                rowAddedAutomatically = true;

                {
                    var rows = ParseCSV(fileNames[0]);
                    GetCSVIDs(rows);
                }

                foreach (var file in fileNames)
                {
                    var rows = ParseCSV(file);

                    var firstLine = File.ReadLines(file, Encoding.UTF8).First();
                    var language = Regex.Match(firstLine, "language=([a-zA-Z]+)]").Groups[1].Value;

                    var strings = new List<List<string>>();

                    rows.ForEach(x => { strings.Add(new List<string> { x[0], x[1], x[2], x[3] }); });

                    languagesStrings.Add(new LanguageStringsCollection(language, strings));

                    foreach (var lang in languagesStrings.Where(lang => lang.language == "ar"))
                    {
                        W3EncodedStrings.Clear();
                        foreach (var str in lang.strings)
                            W3EncodedStrings.Add(W3EncodedString.GenerateW3String(Convert.ToInt32(str[0]), str[1],
                                str[2], str[3]));
                        break;
                    }
                }

                fileOpened = true;
                HashStringKeys();
                UpdateModID();
                gridControlStringsEncoder.Visible = true;
                rowAddedAutomatically = false;
                BringToFront = bringToFront;
                this.Shown += OnShown;
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            if (BringToFront)
            {
                TopMost = true;
                Activate();
                BringToFront();
                TopMost = false;
            }
        }

        private void W3EncodedStringsOnListChanged(object sender, ListChangedEventArgs e)
        {
            barButtonItemSave.Enabled = true;
        }

        /*
            Events
        */

        /*
            toolStrip Buttons
        */

        private void barButtonItemNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridControlStringsEncoder.Visible == false)
                return;
            if (!fileIsSaved)
            {
                var result = MessageBox.Show("File is not saved. Do you want to continue anyway?", "Wolven Kit DX String Encoder DX String Encoder",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Cancel)
                    return;
            }

            W3EncodedStrings.Clear();
            CreateDataSource();
            modIDs.Clear();
            barEditItemModId.EditValue = string.Empty;
            gridControlStringsEncoder.Visible = false;
            languagesStrings.Clear();
        }

        private void barButtonItemOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenCSV();
        }

        private void barButtonItemImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImportW3Strings();
        }

        private void barButtonItemFromXml_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenerateFromXML();
        }

        private void barButtonItemFromScripts_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReadScripts();
        }

        private void barButtonItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewStringsEncoder.RowCount != 1)
                SaveCSV();
            else
                MessageBox.Show("Current file is empty.", "Wolven Kit DX String Encoder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void barButtonItemEncode_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewStringsEncoder.RowCount != 1)
                Encode();
            else
                MessageBox.Show("Current file is empty.", "Wolven Kit DX String Encoder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void repoItemTextEditModIDs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) splitContainerMain.Focus();
        }


        private void repoItemComboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (abortedSwitchingBackToAllLanguages)
                abortedSwitchingBackToAllLanguages = false;
            //return;
            if (barEditItemLanguage.EditValue == SeperateLanguagesVal)
            {
                tabControlLanguages.Controls.Clear();

                var allLanguagesStrings = new List<List<string>>();

                foreach (var w3EncodedString in W3EncodedStrings)
                {
                    allLanguagesStrings.Add(new List<string>
                    {
                        w3EncodedString.Id.ToString(), w3EncodedString.HexKey, w3EncodedString.StringKey, w3EncodedString.Localization
                    });
                }

                languagesStrings.Add(new LanguageStringsCollection("all", allLanguagesStrings));


                foreach (var language in languages)
                {
                    var languageStrings = new List<List<string>>();

                    foreach (var str in allLanguagesStrings)
                        languageStrings.Add(new List<string> { str[0], str[1], str[2], str[3] });

                    languagesStrings.Add(new LanguageStringsCollection(language.Handle, languageStrings));

                    var newTabPage = new TabPage();
                    newTabPage.Location = new Point(4, 22);
                    newTabPage.Name = "tabPage" + language.Handle;
                    newTabPage.Padding = new Padding(3);
                    newTabPage.Size = new Size(998, 0);
                    newTabPage.TabIndex = 0;
                    newTabPage.Text = language.Handle;
                    newTabPage.UseVisualStyleBackColor = true;
                    tabControlLanguages.Controls.Add(newTabPage);
                }
            }
            else if (W3EncodedStrings != null)
            {
                var result = MessageBox.Show("Are you sure? English strings will be used for all languages.",
                    "Wolven Kit DX String Encoder", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Cancel)
                {
                    barEditItemLanguage.EditValue = AllLanguagesVal;
                    abortedSwitchingBackToAllLanguages = true;
                    return;
                }

                tabControlLanguages.Controls.Clear();

                W3EncodedStrings.Clear();
                foreach (var str in languagesStrings[7].strings)
                    W3EncodedStrings.Add(W3EncodedString.GenerateW3String(Convert.ToInt32(str[0]), str[1], str[2],
                        str[3]));
                languagesStrings.Clear();

                var newTabPage = new TabPage
                {
                    Location = new Point(4, 22),
                    Name = "tabPageAllLanguages",
                    Padding = new Padding(3),
                    Size = new Size(998, 0),
                    TabIndex = 0,
                    Text = "All Languages",
                    UseVisualStyleBackColor = true
                };
                tabControlLanguages.Controls.Add(newTabPage);
            }
        }

        private void repoItemTextEditModIDs_Leave(object sender, EventArgs e)
        {
            FillModIDIfValid();
            currentModID = barEditItemModId.EditValue.ToString();
        }

        /*
            End of events
        */

        private void HashStringKeys()
        {
            foreach (var w3EncodedString in W3EncodedStrings)
            {
                if (w3EncodedString == null) continue;
                var key = w3EncodedString.StringKey;
                if (key == string.Empty) continue;

                var convertedKey = key.ToCharArray();
                uint hash = 0;
                foreach (var c in convertedKey)
                {
                    hash *= 31;
                    hash += c;
                }

                w3EncodedString.HexKey = hash.ToString("X");
            }
        }

        private void ImportW3Strings()
        {
            XtraMessageBox.Show("This is not supported in the stand alone version of the String Encoder at present.",
                "Not Supported", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //if (barEditItemModId.EditValue == string.Empty)
            //{
            //    AskForModID();
            //    return;
            //}

            //var guiStrings = new List<string>();

            //foreach (DataGridViewRow row in dataGridViewStrings.Rows)
            //    if (row.Cells[3].Value != null)
            //        guiStrings.Add(row.Cells[3].Value.ToString());

            //var importer = new frmStringsGuiImporter(guiStrings);

            //importer.ShowDialog();
            //var stringsManager = MainController.Get().W3StringManager;
            //var strings = stringsManager.GetImportedStrings();
            //if (strings == null)
            //    return;

            //foreach (var str in strings) dataTableGridViewSource.Rows.Add(str[0], str[1], string.Empty, str[2]);

            //stringsManager.ClearImportedStrings();
            //UpdateModID();
        }

        private void GenerateFromXML()
        {
            if (barEditItemModId.EditValue.ToString() != string.Empty && FillModIDIfValid())
                ReadXML();
            else
                AskForModID();
        }

        private void AskForModID()
        {
            MessageBox.Show("Enter mod ID.", "Wolven Kit DX String Encoder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            barEditItemModId.EditValue = string.Empty;
        }

        public string ShowScriptPrefixDialog()
        {
            XtraMessageBox.Show("This is not implemented in the stand alone version of the string encoder.",
                "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //var testDialog = new frmStringsGuiScriptsPrefixDialog();
            //var prefix = string.Empty;
            //if (testDialog.ShowDialog(this) == DialogResult.OK)
            //    prefix = testDialog.prefix;
            //else
            //    prefix = "Cancelled";

            //testDialog.Dispose();

            //return prefix;
            return string.Empty;
        }

        private void ReadScripts()
        {
            if (barEditItemModId.EditValue.ToString() == string.Empty)
            {
                AskForModID();
                return;
            }

            var scriptsDir = string.Empty;

            if (activeMod != null)
                scriptsDir = activeMod.FileDirectory + "\\scripts";

            var prefix = ShowScriptPrefixDialog();

            if (prefix == "Cancelled") return;

            if (prefix == string.Empty)
            {
                MessageBox.Show("Empty prefix.", "Wolven Kit DX String Encoder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            var contents = string.Empty;
            if (!Directory.Exists(scriptsDir))
            {
                var fbw = new FolderBrowserDialog
                {
                    Description = "Please select the scripts directory!"
                };
                if (fbw.ShowDialog() == DialogResult.OK) scriptsDir = fbw.SelectedPath;
            }

            var filenames = Directory.GetFiles(scriptsDir, "*.ws*", SearchOption.AllDirectories)
                .Select(x => Path.GetFullPath(x)).ToArray();
            foreach (var file in filenames)
                contents += File.ReadAllText(file);

            var regex = new Regex("\"(" + prefix + ".+)\"");
            var matches = regex.Matches(contents);

            if (matches.Count == 0)
            {
                MessageBox.Show("No matches.", "Wolven Kit DX String Encoder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var strings = new List<string>();
            var convertToLower = false;

            var counter = 0;
            foreach (Match match in matches)
            {
                if (match.Groups[1].Value.ToLower() != match.Groups[1].Value && !convertToLower)
                {
                    var result = MessageBox.Show(
                        "Found uppercase string keys. String keys called in scripts must be all lowercase. " +
                        "Do you want to read them as lowercase? You will need to change the string keys in the scripts, or pass them to StrLower() function.",
                        "Wolven Kit DX String Encoder", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    if (result == DialogResult.OK)
                        convertToLower = true;
                }

                ++counter;
            }

            if (convertToLower)
                foreach (Match match in matches)
                    strings.Add(counter + 2110000000 + modIDs[0] * 1000 + "||" + match.Groups[1].Value + "|" +
                                match.Groups[1].Value.ToLower());
            else
                foreach (Match match in matches)
                    strings.Add(counter + 2110000000 + modIDs[0] * 1000 + "||" + match.Groups[1].Value + "|" +
                                match.Groups[1].Value);

            var rows = strings.Select(x => x.Split('|')).ToList();

            rowAddedAutomatically = true;

            currentModID = barEditItemModId.EditValue.ToString();
            rows.ForEach(x =>
            {
                W3EncodedStrings.Add(W3EncodedString.ConvertStringArrayToW3EncodedString(x));

                rowAddedAutomatically = false;

                gridControlStringsEncoder.Visible = true;
                UpdateModID();
                HashStringKeys();
            });
        }

        private void ReadXML()
        {
            rowAddedAutomatically = true;
            //TODO check tags for custom display names, add prefixes to keys
            var path = GetXMLPath();

            // to prevent ID being 0 when Leave event for text box wasn't triggered
            FillModIDIfValid();

            if (path != string.Empty)
            {
                //Fix encoding
                File.WriteAllLines(path,
                    new[] { "<?xml version=\"1.0\" encoding=\"utf-8\"?>" }.ToList()
                        .Concat(File.ReadAllLines(path).Skip(1).ToArray()));

                var doc = XDocument.Load(path);

                // vars displayNames
                foreach (var vars in doc.Descendants("UserConfig").Descendants("Group").Descendants("VisibleVars"))
                    foreach (var var in vars.Descendants("Var"))
                    {
                        var name = var.Attribute("displayName").Value;
                        if (counter > idsLimit)
                            W3EncodedStrings.Add(W3EncodedString.GenerateW3String(counter + 2110000000 + modIDs[1] * 1000,
                                string.Empty,
                                DisplayNameToKey(name), name));
                        else
                            W3EncodedStrings.Add(W3EncodedString.GenerateW3String(counter + 2110000000 + modIDs[0] * 1000
                                , string.Empty,
                                DisplayNameToKey(name), name));

                        ++counter;
                    }

                // optionsArray vars displayNames
                foreach (var vars in doc.Descendants("UserConfig").Descendants("Group").Descendants("VisibleVars")
                    .Descendants("OptionsArray"))
                    foreach (var var in vars.Descendants("Option"))
                    {
                        var name = var.Attribute("displayName").Value;
                        if (counter > idsLimit)
                            W3EncodedStrings.Add(W3EncodedString.GenerateW3String(counter + 2110000000 + modIDs[1] * 1000
                                , string.Empty,
                                DisplayNameToKey(name), name));
                        else
                            W3EncodedStrings.Add(W3EncodedString.GenerateW3String(counter + 2110000000 + modIDs[0] * 1000
                                , string.Empty,
                                DisplayNameToKey(name), name));
                        ++counter;
                    }

                // groups displayNames
                foreach (var vars in doc.Descendants("UserConfig"))
                    foreach (var var in vars.Descendants("Group"))
                    {
                        var name = var.Attribute("displayName").Value;

                        var groupNames = DisplayNameToKeyGroup(name);

                        foreach (var groupName in groupNames)
                        {
                            var splitGroupName = groupName.Split('_').ToList();
                            splitGroupName.RemoveAt(0);
                            var localisationName = string.Join(string.Empty, splitGroupName);

                            if (counter > idsLimit)
                                W3EncodedStrings.Add(W3EncodedString.GenerateW3String(
                                    counter + 2110000000 + modIDs[0] * 1000
                                    , string.Empty,
                                    groupName, localisationName));
                            else
                                W3EncodedStrings.Add(W3EncodedString.GenerateW3String(
                                    counter + 2110000000 + modIDs[0] * 1000
                                    , string.Empty,
                                    groupName, localisationName));

                            ++counter;
                        }
                    }
            }

            rowAddedAutomatically = false;

            HashStringKeys();
            UpdateModID();
        }

        private string GetXMLPath()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "XML | *.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
                return ofd.FileName;
            return string.Empty;
        }

        private List<string> DisplayNameToKeyGroup(string name)
        {
            var nameConverted = name.ToCharArray(0, name.Length);
            var stringKeys = new List<string>();
            var stringKey = string.Empty;

            for (var i = 0; i < nameConverted.Length; ++i)
            {
                if (nameConverted[i] == ' ')
                    nameConverted[i] = '_';

                stringKey += nameConverted[i];
            }

            var stringKeySplitted = stringKey.Split('.');

            if (groups.Count() == 0)
            {
                groups.Add(stringKeySplitted[stringKeySplitted.Length - 1]);
                stringKeys.Add("panel_" + stringKeySplitted[stringKeySplitted.Length - 1]);
            }

            for (var i = 0; i < stringKeySplitted.Length; ++i)
                for (var j = 0; j < groups.Count(); ++j)
                    if (!groups.Contains(stringKeySplitted[i]))
                    {
                        groups.Add(stringKeySplitted[i]);
                        stringKeys.Add("panel_" + stringKeySplitted[i]);
                    }

            return stringKeys;
        }

        private string DisplayNameToKey(string name)
        {
            var nameConverted = name.ToCharArray(0, name.Length);
            var stringKey = string.Empty;

            stringKey += "option_";

            for (var i = 0; i < nameConverted.Length; ++i)
                if (nameConverted[i] == ' ')
                {
                    nameConverted[i] = '_';
                    stringKey += nameConverted[i];
                }
                else
                {
                    stringKey += nameConverted[i];
                }

            return stringKey;
        }

        private bool IsIDValid(string id)
        {
            var digits = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var convertedId = id.ToCharArray();
            var validCharCount = 0;
            var idLength = id.Length;
            for (var i = 0; i < idLength; ++i)
                for (var j = 0; j < 10; ++j)
                    if (convertedId[i] == digits[j])
                    {
                        ++validCharCount;
                        break;
                    }
                    else if (convertedId[i] == ';')
                    {
                        multipleIDs = true;
                        ++validCharCount;
                        break;
                    }

            if (!multipleIDs && idLength > 4)
                return false;
            if (validCharCount == idLength && validCharCount != 0)
                return true;

            return false;
        }

        private bool AreAllIDsValid(string[] splittedIDs)
        {
            foreach (var modID in splittedIDs)
            {
                var count = splittedIDs.Count(f => f == modID);
                if (modID.Length > 4)
                    return false;
                if (count > 1)
                    return false;
            }

            return true;
        }

        private bool FillModIDIfValid()
        {
            modIDs.Clear();
            string[] splittedIDs;

            if (!IsIDValid(barEditItemModId.EditValue.ToString()))
            {
                MessageBox.Show("Invalid Mod ID.", "Wolven Kit DX String Encoder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                if (currentModID != string.Empty)
                    barEditItemModId.EditValue = currentModID;
                else
                    barEditItemModId.EditValue = string.Empty;

                return false;
            }

            if (!multipleIDs)
            {
                modIDs.Add(Convert.ToInt32(barEditItemModId.EditValue));
                gridControlStringsEncoder.Visible = true;
                UpdateModID();
            }
            else
            {
                splittedIDs = barEditItemModId.EditValue.ToString().Split(';');

                if (!AreAllIDsValid(splittedIDs))
                {
                    MessageBox.Show("Invalid Mod ID.", "Wolven Kit DX String Encoder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    if (currentModID != string.Empty)
                        barEditItemModId.EditValue = currentModID;
                    else
                        barEditItemModId.EditValue = string.Empty;

                    return false;
                }

                if (!gridControlStringsEncoder.Visible) gridControlStringsEncoder.Visible = true;

                foreach (var id in splittedIDs)
                    modIDs.Add(Convert.ToInt32(id));
            }

            return true;
        }

        private void UpdateModID()
        {
            rowAddedAutomatically = true;
            //TODO - fix for empty dataGridView
            if (W3EncodedStrings == null)
                return;

            var counter = 0;
            var newModID = modIDs[0] * 1000 + 2110000000;
            foreach (var row in W3EncodedStrings)
            {
                var newModIdRow = newModID + counter;
                row.Id = newModIdRow;
                ++counter;
                if (counter / idsLimit >= modIDs.Count)
                {
                    MessageBox.Show("Number of strings exceeds " + counter + ", number of IDs: " + modIDs.Count
                                    + "\nStrings Limit per one modID is " + idsLimit + " Enter more modIDs.",
                        "Wolven Kit DX String Encoder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    W3EncodedStrings.Clear();
                    break;
                }
            }

            rowAddedAutomatically = false;
        }

        private void SaveCSV()
        {
            gridControlStringsEncoder.EndUpdate();
            HashStringKeys();

            var outputPath = string.Empty;
            if (activeMod != null)
            {
                outputPath = activeMod.ProjectDirectory + "\\strings\\CSV";
                if (!Directory.Exists(outputPath))
                    Directory.CreateDirectory(activeMod.ProjectDirectory + "\\strings\\CSV");
            }
            else
            {
                outputPath = GetPath();
            }

            if (outputPath == string.Empty)
                return;
            var sb = new StringBuilder();
            var firstStringId = modIDs[0] * 1000 + 2110000000;
            if (barEditItemLanguage.EditValue == AllLanguagesVal)
            {
                if (W3EncodedStrings.Any(x=>x.Id < firstStringId))
                    if (W3EncodedStrings.Count >= 1)
                    {
                        W3EncodedStrings.OrderByDescending(x => x.Id).First().Id =
                           W3EncodedStrings.OrderByDescending(x => x.Id).ElementAt(1).Id + 1;
                    }
                    else
                     W3EncodedStrings.First().Id = modIDs[0] * firstStringId;

                foreach (var encodedString in W3EncodedStrings)
                    sb.AppendLine(string.Join("|", encodedString.Id.ToString(), encodedString.HexKey,
                        encodedString.StringKey, encodedString.Localization));

                foreach (var language in languages)
                    using (var file = new StreamWriter(outputPath + "\\" + language.Handle + ".csv"))
                    {
                        file.WriteLine(";meta[language=" + language.Handle + "]", Encoding.UTF8);
                        file.WriteLine("; id | key(hex) | key(str) | text", Encoding.UTF8);

                        var csv = sb.ToString();

                        // leaving space for the hex key empty
                        if (!fileOpened)
                        {
                            var splitCsv = csv.Split('\n').ToList();
                            var splitCsvLength = splitCsv.Count();
                            for (var j = 0; j < splitCsvLength; ++j)
                                if (splitCsv[j] == "\r" || splitCsv[j] == string.Empty)
                                {
                                    // remove empty rows
                                    splitCsv.RemoveAt(j);
                                    --splitCsvLength;
                                    --j;
                                }

                            csv = string.Join("\n", splitCsv);

                        }
                        csv += "\n";
                        file.WriteLine(csv, Encoding.UTF8);
                    }
            }
            else
            {
                foreach (var language in languagesStrings)
                {
                    foreach (var line in language.strings)
                        sb.AppendLine(string.Join("|", line.ToArray()));

                    using (var file = new StreamWriter(outputPath + "\\" + language.language + ".csv"))
                    {
                        file.WriteLine(";meta[language=" + language.language + "]", Encoding.UTF8);
                        file.WriteLine("; id | key(hex) | key(str) | text", Encoding.UTF8);

                        var csv = sb.ToString();

                        // leaving space for the hex key empty
                        if (!fileOpened)
                        {
                            var splittedCsv = csv.Split('\n').ToList();
                            var splittedCsvLength = splittedCsv.Count();
                            for (var j = 0; j < splittedCsvLength; ++j)
                                if (splittedCsv[j] == "\r" || splittedCsv[j] == string.Empty)
                                {
                                    // remove empty rows
                                    splittedCsv.RemoveAt(j);
                                    --splittedCsvLength;
                                    --j;
                                }

                            csv = string.Join("\n", splittedCsv);

                        }
                        csv += "\n";
                        file.WriteLine(csv, Encoding.UTF8);
                    }

                    sb.Clear();
                }
            }

            WriteHash("csv");
            fileIsSaved = true;
            barButtonItemSave.Enabled = false;
        }

        private string GetPath()
        {
            var fbw = new FolderBrowserDialog();
            if (fbw.ShowDialog() == DialogResult.OK)
                return fbw.SelectedPath + "//";
            return string.Empty;
        }

        private void CreateDataSource()
        {
            if (W3EncodedStrings == null)
            {
                W3EncodedStrings = new BindingList<W3EncodedString>
                {
                    AllowNew = true,
                    AllowEdit = true,
                    AllowRemove = true
                };
                gridControlStringsEncoder.DataSource = W3EncodedStrings;
                W3EncodedStrings.ListChanged += W3EncodedStringsOnListChanged;
            }
        }

        private void GetCSVIDs(List<string[]> rows)
        {
            modIDs.Clear();
            modIDs.Add((Convert.ToInt32(rows[0][0]) - 2110000000) / 1000);

            // get multiple ids
            foreach (var row in rows)
            {
                var currentRowID = Convert.ToInt32((Convert.ToInt32(row[0]) - 2110000000) / 1000);
                foreach (var addedID in modIDs.ToList()) // to prevent modified collection exception
                    if (currentRowID != addedID)
                        if (!multipleIDs)
                        {
                            multipleIDs = true;
                            modIDs.Add(currentRowID);
                        }
            }

            barEditItemModId.EditValue = string.Empty;
            if (multipleIDs)
            {
                foreach (var id in modIDs)
                    barEditItemModId.EditValue += Convert.ToString(id) + ";";
                // delete last ;
                var stringToRemove = barEditItemModId.EditValue.ToString();
                barEditItemModId.EditValue =
                    stringToRemove.Remove(stringToRemove.Length - 1);
            }
            else
            {
                barEditItemModId.EditValue = Convert.ToString(modIDs[0]);
            }
        }

        private List<string[]> ParseCSV(string path)
        {
            var rows = File.ReadAllLines(path, Encoding.UTF8).Select(x => x.Split('|')).ToList();

            for (var i = 0; i < rows.Count(); ++i)
                if (rows[i].Length == 1)
                {
                    rows.RemoveAt(i);
                    --i;
                }
                else if (rows[i][0][0] == ';'
                ) // need to be separated in two statements so this won't compare an empty row
                {
                    rows.RemoveAt(i);
                    --i;
                }

            return rows;
        }

        private void OpenCSV()
        {
            rowAddedAutomatically = true;
            string filePath;
            var ofd = new OpenFileDialog();
            ofd.Filter = "CSV | *.csv;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;

                var rows = ParseCSV(filePath);
                GetCSVIDs(rows);

                if (barEditItemLanguage.EditValue == SeperateLanguagesVal)
                {
                    var firstLine = File.ReadLines(filePath, Encoding.UTF8).First();
                    var language = Regex.Match(firstLine, "language=([a-zAZ]+)]").Groups[1].Value;
                    var strings = new List<List<string>>();

                    rows.ForEach(row => { strings.Add(new List<string> { row[0], row[1], row[2], row[3] }); });

                    foreach (var lang in languagesStrings)
                        if (lang.language == language)
                        {
                            lang.strings = strings;

                            if (lang.language == "ar" && languageTabSelected == "ar")
                                foreach (var str in lang.strings)
                                    W3EncodedStrings.Add(W3EncodedString.GenerateW3String(Convert.ToInt32(str[0]),
                                        str[1], str[2], str[3]));
                            break;
                        }
                }
                else
                {
                    currentModID = barEditItemModId.EditValue.ToString();
                    rows.ForEach(row =>
                    {
                        W3EncodedStrings.Add(W3EncodedString.ConvertStringArrayToW3EncodedString(row));
                    });
                }
            }
            else
            {
                return;
            }

            fileOpened = true;
            HashStringKeys();
            UpdateModID();
            gridControlStringsEncoder.Visible = true;
            rowAddedAutomatically = false;
        }

        private void Encode()
        {
            gridControlStringsEncoder.EndUpdate();
            HashStringKeys();

            var stringsDir = string.Empty;
            if (activeMod != null)
            {
                stringsDir = activeMod.ProjectDirectory + "\\strings";
                if (!Directory.Exists(stringsDir))
                    Directory.CreateDirectory(activeMod.ProjectDirectory + "\\strings");
            }
            else
            {
                stringsDir = GetPath();
            }

            if (stringsDir == string.Empty)
                return;
            if (barEditItemLanguage.EditValue == AllLanguagesVal)
            {
                var strings = new List<List<string>>();
                foreach (var encodedString in W3EncodedStrings)
                {
                    //Do not add the hex key
                    var str = new List<string>
                    {
                        encodedString.Id.ToString(),
                        encodedString.StringKey,
                        encodedString.Localization
                    };
                    strings.Add(str);
                }

                foreach (var lang in languages)
                {
                    var w3tringFile = new W3StringFile();
                    w3tringFile.Create(strings, lang.Handle);
                    using (var bw = new BinaryWriter(File.OpenWrite(stringsDir + "\\" + lang.Handle + ".w3strings")))
                    {
                        w3tringFile.Write(bw);
                    }
                }
            }
            else
            {
                foreach (var lang in languagesStrings)
                {
                    if (lang.language == "all") continue;

                    if (lang.language == languageTabSelected)
                    {
                        lang.strings.Clear();
                        foreach (var w3EncodedString in W3EncodedStrings)
                            lang.strings.Add(new List<string>
                            {
                                w3EncodedString.Id.ToString(), w3EncodedString.HexKey,
                                w3EncodedString.StringKey, w3EncodedString.Localization
                            });
                    }

                    var w3tringFile = new W3StringFile();
                    var stringsBlock1Strings = new List<List<string>>();
                    foreach (var str in lang.strings)
                        stringsBlock1Strings.Add(new List<string> { str[0], str[2], str[3] }); //Do not add the hex key
                    w3tringFile.Create(stringsBlock1Strings, lang.language);
                    using (var bw = new BinaryWriter(File.OpenWrite(stringsDir + "\\" + lang.language + ".w3strings")))
                    {
                        w3tringFile.Write(bw);
                    }
                }
            }

            WriteHash("encoded");

            MessageBox.Show("Strings encoded.", "Wolven Kit DX String Encoder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        // to check for not encoded csvs, function from Sound_Cache.cs (FNV1A64)
        private ulong CalculateHash(byte[] bytes)
        {
            const ulong fnv64Offset = 0xcbf29ce484222325;
            const ulong fnv64Prime = 0x100000001b3;
            var hash = fnv64Offset;
            foreach (var b in bytes)
            {
                hash = hash ^ b;
                hash = hash * fnv64Prime % 0xFFFFFFFFFFFFFFFF;
            }

            return hash;
        }

        private void WriteHash(string type) // encoded strings hash/csv hash
        {
            var toHash = string.Empty;
            var outputPath = string.Empty;

            if (type == "encoded")
            {
                var stringsDir = activeMod.ProjectDirectory + "\\strings";
                if (!Directory.Exists(stringsDir))
                    return;

                outputPath = stringsDir;

                if (barEditItemLanguage.EditValue == SeperateLanguagesVal)
                    toHash += (from lang in languagesStrings from str in lang.strings from column in str select column)
                        .Aggregate(toHash, (current, column) => current + column);
                else
                    foreach (var w3EncodedString in W3EncodedStrings)
                    {
                        toHash += w3EncodedString.Id.ToString();
                        toHash += w3EncodedString.HexKey;
                        toHash += w3EncodedString.StringKey;
                        toHash += w3EncodedString.Localization;
                    }
            }

            if (type == "csv")
            {
                var csvDir = activeMod.ProjectDirectory + "\\strings\\CSV";
                if (!Directory.Exists(csvDir))
                    return;

                var fileNames = Directory.GetFiles(csvDir, "*.csv*", SearchOption.AllDirectories)
                    .Select(x => Path.GetFullPath(x)).ToArray();
                if (fileNames.Length == 0)
                    return;

                outputPath = csvDir;

                var cells = new List<string>();

                foreach (var file in fileNames)
                {
                    var content = File.ReadAllLines(file);
                    //var splittedContent = content.Split('|');

                    foreach (var line in content)
                    {
                        if (line.Contains(";"))
                            continue;
                        var splitted = line.Split('|');

                        foreach (var cell in splitted)
                        {
                            if (cell == string.Empty)
                                continue;

                            cells.Add(cell);
                        }
                    }
                }

                foreach (var cell in cells)
                    toHash += cell;
            }

            var hash = CalculateHash(Encoding.ASCII.GetBytes(toHash));

            using (var bw = new BinaryWriter(File.OpenWrite(outputPath + "\\hash")))
            {
                bw.Write(hash);
            }
        }

        public bool AreHashesDifferent()
        {
            if (activeMod == null)
                return false;

            var stringsHashPath = activeMod.ProjectDirectory + "\\strings\\hash";
            if (!File.Exists(stringsHashPath))
                return false;

            byte[] hash;
            using (var br = new BinaryReader(File.OpenRead(stringsHashPath)))
            {
                hash = br.ReadBytes(32);
            }

            ulong hashStringsBytesSum = 0;

            foreach (var b in hash)
                hashStringsBytesSum += b;

            var csvHashPath = activeMod.ProjectDirectory + "\\strings\\CSV\\hash";
            if (!File.Exists(csvHashPath))
                return false;

            using (var br = new BinaryReader(File.OpenRead(csvHashPath)))
            {
                hash = br.ReadBytes(32);
            }

            ulong hashCsvBytesSum = 0;

            foreach (var b in hash)
                hashCsvBytesSum += b;

            if (hashStringsBytesSum == hashCsvBytesSum)
                return true;

            return false;
        }

        private void tabControlLanguages_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == null)
                return;

            gridControlStringsEncoder.EndUpdate();

            foreach (var language in languagesStrings.Where(language => language.language == languageTabSelected))
            {
                language.strings.Clear();


                foreach (var w3EncodedString in W3EncodedStrings)
                {
                    language.strings.Add(new List<string>
                    {
                        w3EncodedString.Id.ToString(), w3EncodedString.HexKey, w3EncodedString.StringKey, w3EncodedString.Localization
                    });
                }
            }

            foreach (var language in languagesStrings.Where(language => language.language == e.TabPage.Text))
            {
                W3EncodedStrings.Clear();

                foreach (var str in language.strings)
                    W3EncodedStrings.Add(W3EncodedString.GenerateW3String(Convert.ToInt32(str[0]), str[1], str[2],
                        str[3]));
                break;
            }

            if (e.TabPage != null)
                languageTabSelected = e.TabPage.Text;

            HashStringKeys();
            UpdateModID();
        }

        private void gridViewStringsEncoder_RowDeleted(object sender, RowDeletedEventArgs e)
        {
            UpdateModID();
        }

        private void gridViewStringsEncoder_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            if (rowAddedAutomatically)
                return;

            if ((string)barEditItemModId.EditValue == string.Empty)
            {
                AskForModID();
                return;
            }
            HashStringKeys();
            fileIsSaved = false;
        }

        private void gridViewStringsEncoder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (XtraMessageBox.Show("Do you want to delete this string?", "Delete Encoded String?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                var view = sender as GridView;
                view?.DeleteRow(view.FocusedRowHandle);
            }
        }

        private void gridViewStringsEncoder_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (sender == null) return;
            rowAddedAutomatically = false;
            if (!(sender is GridView view)) return;
            int id;
            if (W3EncodedStrings.Count >= 1)
                id = W3EncodedStrings.Max(x=>x.Id) + 1;
            else
                id = modIDs[0] * 1000 + 2110000000;
            view.SetRowCellValue(e.RowHandle, gridColumnId, id);
        }
    }

    internal class LanguageStringsCollection
    {
        public string language;
        public List<List<string>> strings;

        public LanguageStringsCollection(string language, List<List<string>> strings)
        {
            this.language = language;
            this.strings = strings;
        }
    }
}