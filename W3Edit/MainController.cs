// Decompiled with JetBrains decompiler
// Type: W3Edit.MainController
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using W3Edit.Bundles;
using W3Edit.CR2W;
using W3Edit.CR2W.Editors;
using W3Edit.CR2W.Types;
using W3Edit.W3Strings;

namespace W3Edit
{
  public class MainController : IVariableEditor, ILocalizedStringSource
  {
    private static MainController mainController;
    private W3StringManager w3StringManager;
    private Configuration configuration;
    private BundleManager bundleManager;
    private frmMain window;

    public static MainController Get()
    {
      if (MainController.mainController == null)
      {
        MainController.mainController = new MainController();
        MainController.mainController.Initialize();
      }
      return MainController.mainController;
    }

    public W3StringManager W3StringManager
    {
      get
      {
        if (this.w3StringManager == null)
        {
          this.w3StringManager = new W3StringManager();
          this.w3StringManager.Load(this.configuration.TextLanguage, Path.GetDirectoryName(this.configuration.ExecutablePath), false);
        }
        return this.w3StringManager;
      }
    }

    public BundleManager BundleManager
    {
      get
      {
        if (this.bundleManager == null)
        {
          this.bundleManager = new BundleManager();
          this.bundleManager.LoadAll(Path.GetDirectoryName(this.configuration.ExecutablePath));
        }
        return this.bundleManager;
      }
    }

    public Configuration Configuration
    {
      get
      {
        return this.configuration;
      }
    }

    public frmMain Window
    {
      get
      {
        return this.window;
      }
    }

    private MainController()
    {
    }

    public void Initialize()
    {
      this.configuration = Configuration.Load();
      this.window = new frmMain();
    }

    public frmCR2WDocument LoadDocument(string filename, bool suppressErrors = false)
    {
      return this.Window.LoadDocument(filename, (MemoryStream) null, suppressErrors);
    }

    public frmCR2WDocument LoadDocument(
      string filename,
      MemoryStream memoryStream,
      bool suppressErrors = false)
    {
      return this.Window.LoadDocument(filename, memoryStream, suppressErrors);
    }

    public void ReloadStringManager()
    {
      this.W3StringManager.Load(this.configuration.TextLanguage, Path.GetDirectoryName(this.configuration.ExecutablePath), true);
    }

    public void CreateVariableEditor(CVariable editvar, EVariableEditorAction action)
    {
      switch (action)
      {
        case EVariableEditorAction.Open:
          this.openEditorFor(editvar);
          break;
        case EVariableEditorAction.Export:
          this.exportBytes(editvar);
          break;
        case EVariableEditorAction.Import:
          this.importBytes(editvar);
          break;
      }
    }

    private void importBytes(CVariable editvar)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = MainController.Get().Configuration.InitialExportDirectory;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      MainController.Get().Configuration.InitialExportDirectory = Path.GetDirectoryName(openFileDialog.FileName);
      using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
      {
        using (BinaryReader reader = new BinaryReader((Stream) fileStream))
        {
          byte[] importBytes = ImportExportUtility.GetImportBytes(reader);
          editvar.SetValue((object) importBytes);
        }
        fileStream.Close();
      }
    }

    private void exportBytes(CVariable editvar)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      byte[] bytes = (byte[]) null;
      if (editvar is IByteSource)
        bytes = ((IByteSource) editvar).Bytes;
      saveFileDialog.Filter = string.Join("|", (IEnumerable<string>) ImportExportUtility.GetPossibleExtensions(bytes));
      saveFileDialog.InitialDirectory = MainController.Get().Configuration.InitialExportDirectory;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      MainController.Get().Configuration.InitialExportDirectory = Path.GetDirectoryName(saveFileDialog.FileName);
      using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream))
        {
          byte[] exportBytes = ImportExportUtility.GetExportBytes(bytes, Path.GetExtension(saveFileDialog.FileName));
          binaryWriter.Write(exportBytes);
        }
        fileStream.Close();
      }
    }

    private void openHexEditorFor(CVariable editvar)
    {
      frmHexEditorView frmHexEditorView = new frmHexEditorView();
      frmHexEditorView.File = editvar.cr2w;
      if (editvar is IByteSource)
        frmHexEditorView.Bytes = ((IByteSource) editvar).Bytes;
      frmHexEditorView.Text = "Hex Viewer [" + editvar.FullName + "]";
      frmHexEditorView.Show();
    }

    private void openEditorFor(CVariable editvar)
    {
      byte[] buffer = (byte[]) null;
      if (editvar is IByteSource)
        buffer = ((IByteSource) editvar).Bytes;
      if (buffer == null)
        return;
      frmCR2WDocument frmCr2Wdocument = this.LoadDocument(editvar.cr2w.FileName + ":" + editvar.FullName, new MemoryStream(buffer), true);
      if (frmCr2Wdocument != null)
      {
        frmCr2Wdocument.OnFileSaved += new EventHandler<FileSavedEventArgs>(this.onVariableEditorSave);
        frmCr2Wdocument.SaveTarget = (object) editvar;
      }
      else
        this.openHexEditorFor(editvar);
    }

    private void onVariableEditorSave(object sender, FileSavedEventArgs args)
    {
      if (!(args.Stream is MemoryStream))
        return;
      ((CVariable) ((frmCR2WDocument) sender).SaveTarget).SetValue((object) ((MemoryStream) args.Stream).ToArray());
    }

    public string GetLocalizedString(uint val)
    {
      return this.W3StringManager.GetString(val);
    }
  }
}
