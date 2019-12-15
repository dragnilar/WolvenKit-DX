// Decompiled with JetBrains decompiler
// Type: W3Edit.frmMain
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using W3Edit.Bundles;
using W3Edit.CR2W;
using W3Edit.CR2W.Types;
using W3Edit.Mod;
using WeifenLuo.WinFormsUI.Docking;

namespace W3Edit
{
  public class frmMain : Form
  {
    private string BaseTitle = "Sarcen's Witcher 3 Mod Editor";
    public List<frmCR2WDocument> OpenDocuments = new List<frmCR2WDocument>();
    private frmCR2WDocument activedocument;
    private IContainer components;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem newModToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem openModToolStripMenuItem;
    private ToolStripMenuItem toolsToolStripMenuItem;
    private ToolStripMenuItem optionsToolStripMenuItem;
    private DockPanel dockPanel;
    private VS2012LightTheme vS2012LightTheme1;
    private ToolStrip toolStrip1;
    private ToolStripButton btRunGame;
    private ToolStripContainer toolStripContainer1;
    private ToolStrip toolStrip2;
    private ToolStripButton tbtSave;
    private ToolStripButton tbtOpen;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripMenuItem modExplorerToolStripMenuItem;
    private ToolStripButton tbtSaveAll;
    private ToolStripButton tbtAddFile;
    private ToolStripButton btPack;
    private ToolStrip toolStrip3;
    private ToolStripButton tbtNewMod;
    private ToolStripButton tbtOpenMod;
    private ToolStripMenuItem modToolStripMenuItem;
    private ToolStripMenuItem addFileToolStripMenuItem1;
    private ToolStripMenuItem modSettingsToolStripMenuItem;

    public W3Mod ActiveMod
    {
      get
      {
        return ModManager.Get().ActiveMod;
      }
      set
      {
        ModManager.Get().ActiveMod = value;
        this.UpdateTitle();
      }
    }

    public string Version
    {
      get
      {
        return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
      }
    }

    private void UpdateTitle()
    {
      this.Text = this.BaseTitle + " v" + this.Version;
      if (this.ActiveMod != null)
      {
        frmMain frmMain = this;
        frmMain.Text = frmMain.Text + " [" + this.ActiveMod.Name + "] ";
      }
      if (this.ActiveDocument == null || this.ActiveDocument.IsDisposed)
        return;
      this.Text += Path.GetFileName(this.ActiveDocument.FileName);
    }

    public frmModExplorer ModExplorer { get; set; }

    public frmOutput Output { get; set; }

    public frmMain()
    {
      this.InitializeComponent();
      this.UpdateTitle();
    }

    private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
    {
      Configuration configuration = MainController.Get().Configuration;
      configuration.MainState = this.WindowState;
      this.WindowState = FormWindowState.Normal;
      configuration.MainSize = this.Size;
      configuration.MainLocation = this.Location;
      this.dockPanel.SaveAsXml(Path.Combine(Path.GetDirectoryName(Configuration.ConfigurationPath), "main_layout.xml"));
    }

    private void frmMain_Shown(object sender, EventArgs e)
    {
      Configuration configuration = MainController.Get().Configuration;
      this.Size = configuration.MainSize;
      this.Location = configuration.MainLocation;
      this.WindowState = configuration.MainState;
      try
      {
        this.dockPanel.LoadFromXml(Path.Combine(Path.GetDirectoryName(Configuration.ConfigurationPath), "main_layout.xml"), new DeserializeDockContent(this.DeserializeDockContent));
      }
      catch
      {
      }
    }

    public IDockContent DeserializeDockContent(string persistString)
    {
      return (IDockContent) null;
    }

    public frmCR2WDocument LoadDocument(
      string filename,
      MemoryStream memoryStream = null,
      bool suppressErrors = false)
    {
      if (memoryStream == null && !File.Exists(filename))
        return (frmCR2WDocument) null;
      for (int index = 0; index < this.OpenDocuments.Count; ++index)
      {
        if (this.OpenDocuments[index].FileName == filename)
        {
          this.OpenDocuments[index].Activate();
          return (frmCR2WDocument) null;
        }
      }
      frmCR2WDocument frmCr2Wdocument = new frmCR2WDocument();
      this.OpenDocuments.Add(frmCr2Wdocument);
      try
      {
        if (memoryStream != null)
          frmCr2Wdocument.LoadFile(filename, (Stream) memoryStream);
        else
          frmCr2Wdocument.LoadFile(filename);
      }
      catch (InvalidFileTypeException ex)
      {
        if (!suppressErrors)
        {
          int num = (int) MessageBox.Show((IWin32Window) this, ex.Message, "Error opening file.");
        }
        this.OpenDocuments.Remove(frmCr2Wdocument);
        frmCr2Wdocument.Dispose();
        return (frmCR2WDocument) null;
      }
      catch (MissingTypeException ex)
      {
        if (!suppressErrors)
        {
          int num = (int) MessageBox.Show((IWin32Window) this, ex.Message, "Error opening file.");
        }
        this.OpenDocuments.Remove(frmCr2Wdocument);
        frmCr2Wdocument.Dispose();
        return (frmCR2WDocument) null;
      }
      frmCr2Wdocument.Activated += new EventHandler(this.doc_Activated);
      frmCr2Wdocument.Show(this.dockPanel, DockState.Document);
      frmCr2Wdocument.FormClosed += new FormClosedEventHandler(this.doc_FormClosed);
      StringBuilder stringBuilder = new StringBuilder();
      if (frmCr2Wdocument.File.UnknownTypes.Count<string>() > 0)
      {
        this.ShowOutput();
        stringBuilder.Append(frmCr2Wdocument.FileName + ": contains " + (object) frmCr2Wdocument.File.UnknownTypes.Count + " unknown type(s):\n");
        foreach (string unknownType in frmCr2Wdocument.File.UnknownTypes)
          stringBuilder.Append("\"" + unknownType + "\", \n");
        stringBuilder.Append("-------\n\n");
      }
      bool flag = false;
      for (int index = 0; index < frmCr2Wdocument.File.chunks.Count; ++index)
      {
        if (frmCr2Wdocument.File.chunks[index].unknownBytes != null && frmCr2Wdocument.File.chunks[index].unknownBytes.Bytes != null && frmCr2Wdocument.File.chunks[index].unknownBytes.Bytes.Length > 0)
        {
          stringBuilder.Append(frmCr2Wdocument.File.chunks[index].Name + " contains " + (object) frmCr2Wdocument.File.chunks[index].unknownBytes.Bytes.Length + " unknown bytes. \n");
          flag = true;
        }
      }
      if (flag)
        stringBuilder.Append("-------\n\n");
      this.AddOutput(stringBuilder.ToString());
      return frmCr2Wdocument;
    }

    private void frmMain_MdiChildActivate(object sender, EventArgs e)
    {
      if (!(sender is frmCR2WDocument))
        return;
      this.doc_Activated(sender, e);
    }

    private void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
    {
      if (!(this.dockPanel.ActiveDocument is frmCR2WDocument))
        return;
      this.doc_Activated((object) this.dockPanel.ActiveDocument, e);
    }

    private void doc_Activated(object sender, EventArgs e)
    {
      this.ActiveDocument = (frmCR2WDocument) sender;
    }

    private void doc_FormClosed(object sender, FormClosedEventArgs e)
    {
      frmCR2WDocument frmCr2Wdocument = (frmCR2WDocument) sender;
      this.OpenDocuments.Remove(frmCr2Wdocument);
      if (frmCr2Wdocument != this.ActiveDocument)
        return;
      this.ActiveDocument = (frmCR2WDocument) null;
    }

    private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.addModFile("");
    }

    private void addModFile(string browseToPath = "")
    {
      if (this.ActiveMod == null)
        return;
      frmBundleExplorer frmBundleExplorer = new frmBundleExplorer();
      frmBundleExplorer.OpenPath(browseToPath);
      if (frmBundleExplorer.ShowDialog() != DialogResult.OK)
        return;
      foreach (string selectedPath in frmBundleExplorer.SelectedPaths)
        this.AddToMod(selectedPath);
      this.UpdateModFileList(false);
      this.SaveMod();
    }

    private void AddToMod(string depotpath)
    {
      BundleManager bundleManager = MainController.Get().BundleManager;
      if (!bundleManager.Items.ContainsKey(depotpath))
        return;
      BundleItem bundleItem1;
      if (bundleManager.Items[depotpath].Count > 1)
      {
        Dictionary<string, BundleItem> dictionary = new Dictionary<string, BundleItem>();
        foreach (BundleItem bundleItem2 in bundleManager.Items[depotpath])
          dictionary.Add(bundleItem2.Bundle.FileName, bundleItem2);
        frmExtractAmbigious extractAmbigious = new frmExtractAmbigious((IEnumerable<string>) dictionary.Keys);
        if (extractAmbigious.ShowDialog() == DialogResult.Cancel)
          return;
        bundleItem1 = dictionary[extractAmbigious.SelectedBundle];
      }
      else
        bundleItem1 = bundleManager.Items[depotpath].Last<BundleItem>();
      string str = Path.Combine(this.ActiveMod.FileDirectory, depotpath);
      try
      {
        Directory.CreateDirectory(Path.GetDirectoryName(str));
      }
      catch
      {
      }
      if (File.Exists(str))
      {
        if (MessageBox.Show(str + " already exists, do you want to overwrite it?", "Add mod file error.", MessageBoxButtons.OKCancel) != DialogResult.OK)
          return;
        File.Delete(str);
      }
      bundleItem1.Extract(str);
    }

    private void UpdateModFileList(bool clear = false)
    {
      if (this.ModExplorer == null)
        return;
      this.ModExplorer.UpdateModFileList(clear);
    }

    private void openModToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.openMod();
    }

    private void openMod()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = "Open Witcher 3 Mod Project";
      openFileDialog.Filter = "Witcher 3 Mod|*.w3modproj";
      openFileDialog.InitialDirectory = MainController.Get().Configuration.InitialModDirectory;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      MainController.Get().Configuration.InitialModDirectory = Path.GetDirectoryName(openFileDialog.FileName);
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (W3Mod));
      FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
      this.ActiveMod = (W3Mod) xmlSerializer.Deserialize((Stream) fileStream);
      this.ActiveMod.FileName = openFileDialog.FileName;
      fileStream.Close();
      this.ShowModExplorer();
      this.UpdateModFileList(true);
    }

    private void ShowModExplorer()
    {
      if (this.ModExplorer == null || this.ModExplorer.IsDisposed)
      {
        this.ModExplorer = new frmModExplorer();
        this.ModExplorer.Show(this.dockPanel, DockState.DockLeft);
        this.ModExplorer.RequestFileOpen += new EventHandler<RequestFileArgs>(this.ModExplorer_RequestFileOpen);
        this.ModExplorer.RequestFileDelete += new EventHandler<RequestFileArgs>(this.ModExplorer_RequestFileDelete);
        this.ModExplorer.RequestFileAdd += new EventHandler<RequestFileArgs>(this.ModExplorer_RequestAddFile);
        this.ModExplorer.RequestFileRename += new EventHandler<RequestFileArgs>(this.ModExplorer_RequestFileRename);
      }
      this.ModExplorer.Activate();
    }

    private void ModExplorer_RequestFileRename(object sender, RequestFileArgs e)
    {
      string file = e.File;
      string str1 = Path.Combine(this.ActiveMod.FileDirectory, file);
      if (!File.Exists(str1))
        return;
      frmRenameDialog frmRenameDialog = new frmRenameDialog();
      frmRenameDialog.FileName = file;
      if (frmRenameDialog.ShowDialog() != DialogResult.OK || !(frmRenameDialog.FileName != file))
        return;
      string str2 = Path.Combine(this.ActiveMod.FileDirectory, frmRenameDialog.FileName);
      if (File.Exists(str2))
        return;
      try
      {
        Directory.CreateDirectory(Path.GetDirectoryName(str2));
      }
      catch
      {
      }
      File.Move(str1, str2);
      if (this.ModExplorer == null)
        return;
      this.ModExplorer.DeleteNode(file);
      this.ModExplorer.UpdateModFileList(false);
    }

    private void ModExplorer_RequestAddFile(object sender, RequestFileArgs e)
    {
      this.addModFile(e.File);
    }

    private void ModExplorer_RequestFileDelete(object sender, RequestFileArgs e)
    {
      string file = e.File;
      if (MessageBox.Show("Are you sure you want to permanently delete this?", "Confirmation", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      this.removeFromMod(file);
    }

    private void removeFromMod(string filename)
    {
      for (int index = 0; index < this.OpenDocuments.Count; ++index)
      {
        if (this.OpenDocuments[index].FileName == filename)
        {
          this.OpenDocuments[index].Close();
          break;
        }
      }
      string path = Path.Combine(this.ActiveMod.FileDirectory, filename);
      if (File.Exists(path))
      {
        File.Delete(path);
      }
      else
      {
        try
        {
          Directory.Delete(path, true);
        }
        catch (Exception ex)
        {
        }
      }
      if (this.ModExplorer != null)
        this.ModExplorer.DeleteNode(filename);
      this.SaveMod();
    }

    private void ModExplorer_RequestFileOpen(object sender, RequestFileArgs e)
    {
      string str = Path.Combine(this.ActiveMod.FileDirectory, e.File);
      switch (Path.GetExtension(str))
      {
        case ".csv":
        case ".xml":
        case ".txt":
          this.ShellExecute(str);
          break;
        default:
          this.LoadDocument(str, (MemoryStream) null, false);
          break;
      }
    }

    private void ShellExecute(string fullpath)
    {
      Process.Start(new ProcessStartInfo(fullpath)
      {
        UseShellExecute = true
      });
    }

    private void ShowOutput()
    {
      if (this.Output == null || this.Output.IsDisposed)
      {
        this.Output = new frmOutput();
        this.Output.Show(this.dockPanel, DockState.DockBottom);
      }
      this.Output.Focus();
    }

    private void newModToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.createNewMod();
    }

    private void createNewMod()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Title = "Create Witcher 3 Mod Project";
      saveFileDialog.Filter = "Witcher 3 Mod|*.w3modproj";
      saveFileDialog.InitialDirectory = MainController.Get().Configuration.InitialModDirectory;
      while (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        if (saveFileDialog.FileName.Contains<char>(' '))
        {
          int num1 = (int) MessageBox.Show("The mod path should not contain spaces because wcc_lite.exe will have trouble with that.", "Invalid path");
        }
        else
        {
          MainController.Get().Configuration.InitialModDirectory = Path.GetDirectoryName(saveFileDialog.FileName);
          string withoutExtension = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
          string path = Path.Combine(Path.GetDirectoryName(saveFileDialog.FileName), withoutExtension);
          try
          {
            Directory.CreateDirectory(path);
          }
          catch (Exception ex)
          {
            int num2 = (int) MessageBox.Show("Failed to create mod directory: \n" + path + "\n\n" + ex.Message);
            break;
          }
          this.ActiveMod = new W3Mod()
          {
            FileName = saveFileDialog.FileName,
            Name = withoutExtension
          };
          this.ShowModExplorer();
          this.UpdateModFileList(true);
          this.SaveMod();
          break;
        }
      }
    }

    private void SaveMod()
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (W3Mod));
      FileStream fileStream = new FileStream(this.ActiveMod.FileName, FileMode.Create, FileAccess.Write);
      xmlSerializer.Serialize((Stream) fileStream, (object) this.ActiveMod);
      fileStream.Close();
    }

    private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new frmSettings().ShowDialog();
    }

    private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
    {
    }

    private void modExplorerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowModExplorer();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void tbtOpen_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = "Open CR2W File";
      openFileDialog.InitialDirectory = MainController.Get().Configuration.InitialFileDirectory;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      MainController.Get().Configuration.InitialFileDirectory = Path.GetDirectoryName(openFileDialog.FileName);
      this.LoadDocument(openFileDialog.FileName, (MemoryStream) null, false);
    }

    private void tbtSave_Click(object sender, EventArgs e)
    {
      this.saveActiveFile();
    }

    private void saveActiveFile()
    {
      if (this.ActiveDocument == null || this.ActiveDocument.IsDisposed)
        return;
      this.saveFile(this.ActiveDocument);
    }

    private void tbtSaveAll_Click(object sender, EventArgs e)
    {
      this.saveAllFiles();
    }

    private void saveAllFiles()
    {
      foreach (frmCR2WDocument openDocument in this.OpenDocuments)
      {
        if (openDocument.SaveTarget != null)
          this.saveFile(openDocument);
      }
      foreach (frmCR2WDocument openDocument in this.OpenDocuments)
      {
        if (openDocument.SaveTarget == null)
          this.saveFile(openDocument);
      }
    }

    private void saveFile(frmCR2WDocument d)
    {
      d.SaveFile();
    }

    private void tbtAddFile_Click(object sender, EventArgs e)
    {
      if (this.ActiveMod == null)
        return;
      this.addModFile("");
    }

    private void btPack_Click(object sender, EventArgs e)
    {
      if (this.ActiveMod == null)
        return;
      this.btPack.Enabled = false;
      this.ShowOutput();
      this.ClearOutput();
      this.saveAllFiles();
      Task task = this.packMod();
      while (!task.IsCompleted)
        Application.DoEvents();
      Task modMetaData = this.createModMetaData();
      while (!modMetaData.IsCompleted)
        Application.DoEvents();
      this.installMod();
      this.btPack.Enabled = true;
    }

    private void ClearOutput()
    {
      if (this.Output == null || this.Output.IsDisposed)
        return;
      this.Output.Clear();
    }

    private void AddOutput(string text)
    {
      if (this.Output == null || this.Output.IsDisposed || string.IsNullOrWhiteSpace(text))
        return;
      this.Output.AddText(text);
    }

    private void installMod()
    {
      string path1 = Path.Combine(this.ActiveMod.Directory, "packed");
      string path3 = this.ActiveMod.Name;
      if (!this.ActiveMod.InstallAsDLC && !path3.StartsWith("mod"))
        path3 = "mod" + path3;
      string str = !this.ActiveMod.InstallAsDLC ? Path.Combine(Path.GetDirectoryName(MainController.Get().Configuration.ExecutablePath), "..\\..\\Mods\\", path3) : Path.Combine(Path.GetDirectoryName(MainController.Get().Configuration.ExecutablePath), "..\\..\\DLC\\", path3);
      if (!Directory.Exists(str))
        Directory.CreateDirectory(str);
      foreach (string directory in Directory.GetDirectories(path1, "*", SearchOption.AllDirectories))
      {
        string path2 = directory.Substring(path1.Length + 1);
        string path4 = Path.Combine(str, path2);
        if (!Directory.Exists(path4))
          Directory.CreateDirectory(path4);
      }
      foreach (string file in Directory.GetFiles(path1, "*", SearchOption.AllDirectories))
      {
        string path2 = file.Substring(path1.Length + 1);
        string destFileName = Path.Combine(str, path2);
        File.Copy(file, destFileName, true);
      }
      this.AddOutput("Mod Installed to " + str + "\n");
    }

    private async Task packMod()
    {
      Configuration config = MainController.Get().Configuration;
      ProcessStartInfo proc = new ProcessStartInfo(config.WCC_Lite);
      proc.WorkingDirectory = Path.GetDirectoryName(config.WCC_Lite);
      string packedDir = Path.Combine(this.ActiveMod.Directory, "packed\\content\\");
      string uncookedDir = this.ActiveMod.FileDirectory;
      if (!Directory.Exists(packedDir))
        Directory.CreateDirectory(packedDir);
      proc.Arguments = string.Format("pack -dir={0} -outdir={1}", (object) uncookedDir, (object) packedDir);
      proc.UseShellExecute = false;
      proc.RedirectStandardOutput = true;
      proc.WindowStyle = ProcessWindowStyle.Hidden;
      proc.CreateNoWindow = true;
      this.AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n");
      using (Process process = Process.Start(proc))
      {
        using (StreamReader reader = process.StandardOutput)
        {
          do
          {
            string result = await reader.ReadLineAsync();
            this.AddOutput(result + "\n");
            Application.DoEvents();
          }
          while (!reader.EndOfStream);
        }
      }
    }

    private async Task createModMetaData()
    {
      Configuration config = MainController.Get().Configuration;
      ProcessStartInfo proc = new ProcessStartInfo(config.WCC_Lite);
      proc.WorkingDirectory = Path.GetDirectoryName(config.WCC_Lite);
      string packedDir = Path.Combine(this.ActiveMod.Directory, "packed\\content\\");
      proc.Arguments = string.Format("metadatastore -path={0}", (object) packedDir);
      proc.UseShellExecute = false;
      proc.RedirectStandardOutput = true;
      proc.WindowStyle = ProcessWindowStyle.Hidden;
      proc.CreateNoWindow = true;
      this.AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n");
      using (Process process = Process.Start(proc))
      {
        using (StreamReader reader = process.StandardOutput)
        {
          do
          {
            string result = await reader.ReadLineAsync();
            this.AddOutput(result + "\n");
            Application.DoEvents();
          }
          while (!reader.EndOfStream);
        }
      }
    }

    public frmCR2WDocument ActiveDocument
    {
      get
      {
        return this.activedocument;
      }
      set
      {
        this.activedocument = value;
        this.UpdateTitle();
      }
    }

    private void btRunGame_Click(object sender, EventArgs e)
    {
      this.ClearOutput();
      this.ShowOutput();
      this.executeGame();
    }

    private async void executeGame()
    {
      Configuration config = MainController.Get().Configuration;
      ProcessStartInfo proc = new ProcessStartInfo(config.ExecutablePath);
      proc.WorkingDirectory = Path.GetDirectoryName(config.ExecutablePath);
      proc.Arguments = "-debugscripts";
      proc.UseShellExecute = false;
      proc.RedirectStandardOutput = true;
      this.AddOutput("Executing " + proc.FileName + " " + proc.Arguments + "\n");
      string documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      string scriptlog = Path.Combine(documents, "The Witcher 3\\scriptslog.txt");
      if (File.Exists(scriptlog))
        File.Delete(scriptlog);
      using (Process process = Process.Start(proc))
      {
        Task task2 = this.RedirectScriptlogOutput(process);
        await task2;
      }
    }

    private async Task RedirectScriptlogOutput(Process process)
    {
      string documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      string scriptlog = Path.Combine(documents, "The Witcher 3\\scriptslog.txt");
      using (FileStream fs = new FileStream(scriptlog, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
      {
        using (StreamReader fsr = new StreamReader((Stream) fs))
        {
          while (!process.HasExited)
          {
            string result = await fsr.ReadToEndAsync();
            this.AddOutput(result);
            Application.DoEvents();
          }
        }
        fs.Close();
      }
    }

    private async Task RedirectProcessOutput(Process process)
    {
      using (StreamReader reader = process.StandardOutput)
      {
        do
        {
          string result = await reader.ReadLineAsync();
          this.AddOutput(result + "\n");
          Application.DoEvents();
        }
        while (!reader.EndOfStream);
      }
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      bool flag = false;
      while (!File.Exists(MainController.Get().Configuration.ExecutablePath))
      {
        if (new frmSettings().ShowDialog() != DialogResult.OK)
        {
          flag = true;
          break;
        }
      }
      if (!flag)
        return;
      this.Close();
    }

    private void tbtNewMod_Click(object sender, EventArgs e)
    {
      this.createNewMod();
    }

    private void tbtOpenMod_Click(object sender, EventArgs e)
    {
      this.openMod();
    }

    private void addFileToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      this.addModFile("");
    }

    private void modSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.ActiveMod == null)
        return;
      using (frmModSettings frmModSettings = new frmModSettings())
      {
        frmModSettings.Mod = this.ActiveMod;
        if (frmModSettings.ShowDialog() != DialogResult.OK)
          return;
        this.UpdateTitle();
        this.SaveMod();
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      DockPanelSkin dockPanelSkin = new DockPanelSkin();
      AutoHideStripSkin autoHideStripSkin = new AutoHideStripSkin();
      DockPanelGradient dockPanelGradient1 = new DockPanelGradient();
      TabGradient tabGradient1 = new TabGradient();
      DockPaneStripSkin dockPaneStripSkin = new DockPaneStripSkin();
      DockPaneStripGradient paneStripGradient = new DockPaneStripGradient();
      TabGradient tabGradient2 = new TabGradient();
      DockPanelGradient dockPanelGradient2 = new DockPanelGradient();
      TabGradient tabGradient3 = new TabGradient();
      DockPaneStripToolWindowGradient toolWindowGradient = new DockPaneStripToolWindowGradient();
      TabGradient tabGradient4 = new TabGradient();
      TabGradient tabGradient5 = new TabGradient();
      DockPanelGradient dockPanelGradient3 = new DockPanelGradient();
      TabGradient tabGradient6 = new TabGradient();
      TabGradient tabGradient7 = new TabGradient();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMain));
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem1 = new ToolStripSeparator();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.modToolStripMenuItem = new ToolStripMenuItem();
      this.toolsToolStripMenuItem = new ToolStripMenuItem();
      this.viewToolStripMenuItem = new ToolStripMenuItem();
      this.modExplorerToolStripMenuItem = new ToolStripMenuItem();
      this.dockPanel = new DockPanel();
      this.vS2012LightTheme1 = new VS2012LightTheme();
      this.toolStrip1 = new ToolStrip();
      this.toolStripContainer1 = new ToolStripContainer();
      this.toolStrip2 = new ToolStrip();
      this.toolStrip3 = new ToolStrip();
      this.modSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.newModToolStripMenuItem = new ToolStripMenuItem();
      this.openModToolStripMenuItem = new ToolStripMenuItem();
      this.addFileToolStripMenuItem1 = new ToolStripMenuItem();
      this.optionsToolStripMenuItem = new ToolStripMenuItem();
      this.tbtNewMod = new ToolStripButton();
      this.tbtOpenMod = new ToolStripButton();
      this.tbtOpen = new ToolStripButton();
      this.tbtSave = new ToolStripButton();
      this.tbtSaveAll = new ToolStripButton();
      this.tbtAddFile = new ToolStripButton();
      this.btRunGame = new ToolStripButton();
      this.btPack = new ToolStripButton();
      this.menuStrip1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.toolStripContainer1.ContentPanel.SuspendLayout();
      this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
      this.toolStripContainer1.SuspendLayout();
      this.toolStrip2.SuspendLayout();
      this.toolStrip3.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip1.Dock = DockStyle.None;
      this.menuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.modToolStripMenuItem,
        (ToolStripItem) this.toolsToolStripMenuItem,
        (ToolStripItem) this.viewToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(569, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.newModToolStripMenuItem,
        (ToolStripItem) this.openModToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem1,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(128, 6);
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new Size(131, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
      this.modToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.addFileToolStripMenuItem1,
        (ToolStripItem) this.modSettingsToolStripMenuItem
      });
      this.modToolStripMenuItem.Name = "modToolStripMenuItem";
      this.modToolStripMenuItem.Size = new Size(44, 20);
      this.modToolStripMenuItem.Text = "Mod";
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.optionsToolStripMenuItem
      });
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new Size(48, 20);
      this.toolsToolStripMenuItem.Text = "&Tools";
      this.viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.modExplorerToolStripMenuItem
      });
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new Size(44, 20);
      this.viewToolStripMenuItem.Text = "&View";
      this.modExplorerToolStripMenuItem.Name = "modExplorerToolStripMenuItem";
      this.modExplorerToolStripMenuItem.Size = new Size(144, 22);
      this.modExplorerToolStripMenuItem.Text = "Mod Explorer";
      this.modExplorerToolStripMenuItem.Click += new EventHandler(this.modExplorerToolStripMenuItem_Click);
      this.dockPanel.Dock = DockStyle.Fill;
      this.dockPanel.DockBackColor = SystemColors.AppWorkspace;
      this.dockPanel.DockBottomPortion = 150.0;
      this.dockPanel.DockLeftPortion = 200.0;
      this.dockPanel.DockRightPortion = 200.0;
      this.dockPanel.DockTopPortion = 150.0;
      this.dockPanel.DocumentStyle = DocumentStyle.DockingWindow;
      this.dockPanel.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World, (byte) 0);
      this.dockPanel.Location = new Point(0, 0);
      this.dockPanel.Name = "dockPanel";
      this.dockPanel.RightToLeftLayout = true;
      this.dockPanel.Size = new Size(569, 312);
      dockPanelGradient1.EndColor = SystemColors.ControlLight;
      dockPanelGradient1.StartColor = Color.FromArgb(0, 122, 204);
      autoHideStripSkin.DockStripGradient = dockPanelGradient1;
      tabGradient1.EndColor = SystemColors.Control;
      tabGradient1.StartColor = SystemColors.Control;
      tabGradient1.TextColor = SystemColors.ControlDarkDark;
      autoHideStripSkin.TabGradient = tabGradient1;
      autoHideStripSkin.TextFont = new Font("Segoe UI", 9f);
      dockPanelSkin.AutoHideStripSkin = autoHideStripSkin;
      tabGradient2.EndColor = Color.FromArgb(204, 206, 219);
      tabGradient2.StartColor = Color.FromArgb(0, 122, 204);
      tabGradient2.TextColor = Color.White;
      paneStripGradient.ActiveTabGradient = tabGradient2;
      dockPanelGradient2.EndColor = SystemColors.Control;
      dockPanelGradient2.StartColor = SystemColors.Control;
      paneStripGradient.DockStripGradient = dockPanelGradient2;
      tabGradient3.EndColor = Color.FromArgb(28, 151, 234);
      tabGradient3.StartColor = SystemColors.Control;
      tabGradient3.TextColor = Color.Black;
      paneStripGradient.InactiveTabGradient = tabGradient3;
      dockPaneStripSkin.DocumentGradient = paneStripGradient;
      dockPaneStripSkin.TextFont = new Font("Segoe UI", 9f);
      tabGradient4.EndColor = Color.FromArgb(80, 170, 220);
      tabGradient4.LinearGradientMode = LinearGradientMode.Vertical;
      tabGradient4.StartColor = Color.FromArgb(0, 122, 204);
      tabGradient4.TextColor = Color.White;
      toolWindowGradient.ActiveCaptionGradient = tabGradient4;
      tabGradient5.EndColor = SystemColors.ControlLightLight;
      tabGradient5.StartColor = SystemColors.ControlLightLight;
      tabGradient5.TextColor = Color.FromArgb(0, 122, 204);
      toolWindowGradient.ActiveTabGradient = tabGradient5;
      dockPanelGradient3.EndColor = SystemColors.Control;
      dockPanelGradient3.StartColor = SystemColors.Control;
      toolWindowGradient.DockStripGradient = dockPanelGradient3;
      tabGradient6.EndColor = SystemColors.ControlDark;
      tabGradient6.LinearGradientMode = LinearGradientMode.Vertical;
      tabGradient6.StartColor = SystemColors.Control;
      tabGradient6.TextColor = SystemColors.GrayText;
      toolWindowGradient.InactiveCaptionGradient = tabGradient6;
      tabGradient7.EndColor = SystemColors.Control;
      tabGradient7.StartColor = SystemColors.Control;
      tabGradient7.TextColor = SystemColors.GrayText;
      toolWindowGradient.InactiveTabGradient = tabGradient7;
      dockPaneStripSkin.ToolWindowGradient = toolWindowGradient;
      dockPanelSkin.DockPaneStripSkin = dockPaneStripSkin;
      this.dockPanel.Skin = dockPanelSkin;
      this.dockPanel.TabIndex = 0;
      this.dockPanel.Theme = (ThemeBase) this.vS2012LightTheme1;
      this.dockPanel.ActiveDocumentChanged += new EventHandler(this.dockPanel_ActiveDocumentChanged);
      this.toolStrip1.Dock = DockStyle.None;
      this.toolStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.btRunGame,
        (ToolStripItem) this.btPack
      });
      this.toolStrip1.Location = new Point(176, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(58, 25);
      this.toolStrip1.TabIndex = 3;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStripContainer1.BottomToolStripPanelVisible = false;
      this.toolStripContainer1.ContentPanel.AutoScroll = true;
      this.toolStripContainer1.ContentPanel.Controls.Add((Control) this.dockPanel);
      this.toolStripContainer1.ContentPanel.Size = new Size(569, 312);
      this.toolStripContainer1.Dock = DockStyle.Fill;
      this.toolStripContainer1.LeftToolStripPanelVisible = false;
      this.toolStripContainer1.Location = new Point(0, 0);
      this.toolStripContainer1.Name = "toolStripContainer1";
      this.toolStripContainer1.RightToolStripPanelVisible = false;
      this.toolStripContainer1.Size = new Size(569, 361);
      this.toolStripContainer1.TabIndex = 4;
      this.toolStripContainer1.Text = "toolStripContainer1";
      this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control) this.menuStrip1);
      this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control) this.toolStrip3);
      this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control) this.toolStrip2);
      this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control) this.toolStrip1);
      this.toolStrip2.Dock = DockStyle.None;
      this.toolStrip2.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.tbtOpen,
        (ToolStripItem) this.tbtSave,
        (ToolStripItem) this.tbtSaveAll,
        (ToolStripItem) this.tbtAddFile
      });
      this.toolStrip2.Location = new Point(61, 24);
      this.toolStrip2.Name = "toolStrip2";
      this.toolStrip2.Size = new Size(104, 25);
      this.toolStrip2.TabIndex = 4;
      this.toolStrip3.Dock = DockStyle.None;
      this.toolStrip3.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.tbtNewMod,
        (ToolStripItem) this.tbtOpenMod
      });
      this.toolStrip3.Location = new Point(3, 24);
      this.toolStrip3.Name = "toolStrip3";
      this.toolStrip3.Size = new Size(58, 25);
      this.toolStrip3.TabIndex = 5;
      this.modSettingsToolStripMenuItem.Name = "modSettingsToolStripMenuItem";
      this.modSettingsToolStripMenuItem.Size = new Size(152, 22);
      this.modSettingsToolStripMenuItem.Text = "Mod Settings";
      this.modSettingsToolStripMenuItem.Click += new EventHandler(this.modSettingsToolStripMenuItem_Click);
      this.newModToolStripMenuItem.Image = (Image) W3Edit.Properties.Resources.NewSolutionFolder_6289;
      this.newModToolStripMenuItem.Name = "newModToolStripMenuItem";
      this.newModToolStripMenuItem.Size = new Size(131, 22);
      this.newModToolStripMenuItem.Text = "&New Mod";
      this.newModToolStripMenuItem.Click += new EventHandler(this.newModToolStripMenuItem_Click);
      this.openModToolStripMenuItem.Image = (Image) W3Edit.Properties.Resources.Open_6529;
      this.openModToolStripMenuItem.Name = "openModToolStripMenuItem";
      this.openModToolStripMenuItem.Size = new Size(131, 22);
      this.openModToolStripMenuItem.Text = "Open Mod";
      this.openModToolStripMenuItem.Click += new EventHandler(this.openModToolStripMenuItem_Click);
      this.addFileToolStripMenuItem1.Image = (Image) W3Edit.Properties.Resources.AddNodefromFile_354;
      this.addFileToolStripMenuItem1.Name = "addFileToolStripMenuItem1";
      this.addFileToolStripMenuItem1.Size = new Size(152, 22);
      this.addFileToolStripMenuItem1.Text = "Add File";
      this.addFileToolStripMenuItem1.Click += new EventHandler(this.addFileToolStripMenuItem1_Click);
      this.optionsToolStripMenuItem.Image = (Image) W3Edit.Properties.Resources.gear_16xLG;
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new Size(125, 22);
      this.optionsToolStripMenuItem.Text = "&Options...";
      this.optionsToolStripMenuItem.Click += new EventHandler(this.optionsToolStripMenuItem_Click);
      this.tbtNewMod.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tbtNewMod.Image = (Image) W3Edit.Properties.Resources.NewSolutionFolder_6289;
      this.tbtNewMod.ImageTransparentColor = Color.Magenta;
      this.tbtNewMod.Name = "tbtNewMod";
      this.tbtNewMod.Size = new Size(23, 22);
      this.tbtNewMod.Text = "New Mod";
      this.tbtNewMod.Click += new EventHandler(this.tbtNewMod_Click);
      this.tbtOpenMod.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tbtOpenMod.Image = (Image) W3Edit.Properties.Resources.Open_6529;
      this.tbtOpenMod.ImageTransparentColor = Color.Magenta;
      this.tbtOpenMod.Name = "tbtOpenMod";
      this.tbtOpenMod.Size = new Size(23, 22);
      this.tbtOpenMod.Text = "Open Mod";
      this.tbtOpenMod.Click += new EventHandler(this.tbtOpenMod_Click);
      this.tbtOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tbtOpen.Image = (Image) W3Edit.Properties.Resources.Open_6529;
      this.tbtOpen.ImageTransparentColor = Color.Magenta;
      this.tbtOpen.Name = "tbtOpen";
      this.tbtOpen.Size = new Size(23, 22);
      this.tbtOpen.Text = "Open File";
      this.tbtOpen.Click += new EventHandler(this.tbtOpen_Click);
      this.tbtSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tbtSave.Image = (Image) W3Edit.Properties.Resources.Save_6530;
      this.tbtSave.ImageTransparentColor = Color.Magenta;
      this.tbtSave.Name = "tbtSave";
      this.tbtSave.Size = new Size(23, 22);
      this.tbtSave.Text = "Save";
      this.tbtSave.Click += new EventHandler(this.tbtSave_Click);
      this.tbtSaveAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tbtSaveAll.Image = (Image) W3Edit.Properties.Resources.Saveall_6518;
      this.tbtSaveAll.ImageTransparentColor = Color.Magenta;
      this.tbtSaveAll.Name = "tbtSaveAll";
      this.tbtSaveAll.Size = new Size(23, 22);
      this.tbtSaveAll.Text = "Save All";
      this.tbtSaveAll.Click += new EventHandler(this.tbtSaveAll_Click);
      this.tbtAddFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tbtAddFile.Image = (Image) W3Edit.Properties.Resources.AddNodefromFile_354;
      this.tbtAddFile.ImageTransparentColor = Color.Magenta;
      this.tbtAddFile.Name = "tbtAddFile";
      this.tbtAddFile.Size = new Size(23, 22);
      this.tbtAddFile.Text = "Add File";
      this.tbtAddFile.Click += new EventHandler(this.tbtAddFile_Click);
      this.btRunGame.Alignment = ToolStripItemAlignment.Right;
      this.btRunGame.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btRunGame.Image = (Image) componentResourceManager.GetObject("btRunGame.Image");
      this.btRunGame.ImageTransparentColor = Color.Magenta;
      this.btRunGame.Name = "btRunGame";
      this.btRunGame.Size = new Size(23, 22);
      this.btRunGame.Text = "Run game";
      this.btRunGame.Click += new EventHandler(this.btRunGame_Click);
      this.btPack.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btPack.Image = (Image) W3Edit.Properties.Resources.FileGroup_10135_16x;
      this.btPack.ImageTransparentColor = Color.Magenta;
      this.btPack.Name = "btPack";
      this.btPack.Size = new Size(23, 22);
      this.btPack.Text = "Pack and Install Mod";
      this.btPack.Click += new EventHandler(this.btPack_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(569, 361);
      this.Controls.Add((Control) this.toolStripContainer1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new Size(585, 399);
      this.Name = nameof (frmMain);
      this.Text = "Witcher 3 Mod Editor";
      this.FormClosed += new FormClosedEventHandler(this.frmMain_FormClosed);
      this.Load += new EventHandler(this.frmMain_Load);
      this.MdiChildActivate += new EventHandler(this.frmMain_MdiChildActivate);
      this.Shown += new EventHandler(this.frmMain_Shown);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.toolStripContainer1.ContentPanel.ResumeLayout(false);
      this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
      this.toolStripContainer1.TopToolStripPanel.PerformLayout();
      this.toolStripContainer1.ResumeLayout(false);
      this.toolStripContainer1.PerformLayout();
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.toolStrip3.ResumeLayout(false);
      this.toolStrip3.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
