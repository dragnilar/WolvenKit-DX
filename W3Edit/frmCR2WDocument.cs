// Decompiled with JetBrains decompiler
// Type: W3Edit.frmCR2WDocument
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using W3Edit.CR2W;
using WeifenLuo.WinFormsUI.Docking;

namespace W3Edit
{
  public class frmCR2WDocument : DockContent
  {
    private CR2WFile file;
    private frmChunkList chunkList;
    private frmChunkProperties propertyWindow;
    private frmChunkFlowDiagram flowDiagram;
    private frmEmbeddedFiles embeddedFiles;
    private IContainer components;
    private ImageList imageList1;
    private DockPanel dockPanel;
    private VS2012LightTheme vS2012LightTheme1;

    public CR2WFile File
    {
      get
      {
        return this.file;
      }
      set
      {
        this.file = value;
        if (this.chunkList != null && !this.chunkList.IsDisposed)
          this.chunkList.File = this.file;
        if (this.flowDiagram != null && !this.flowDiagram.IsDisposed)
          this.flowDiagram.File = this.file;
        if (this.embeddedFiles == null || this.embeddedFiles.IsDisposed)
          return;
        this.embeddedFiles.File = this.file;
        if (this.file.block7.Count <= 0)
          return;
        this.embeddedFiles.Show(this.dockPanel, DockState.Document);
      }
    }

    public string FileName
    {
      get
      {
        return this.File.FileName;
      }
      set
      {
        this.File.FileName = value;
      }
    }

    public event EventHandler<FileSavedEventArgs> OnFileSaved;

    public object SaveTarget { get; set; }

    public frmCR2WDocument()
    {
      this.InitializeComponent();
      try
      {
        this.dockPanel.LoadFromXml(Path.Combine(Path.GetDirectoryName(Configuration.ConfigurationPath), "cr2wdocument_layout.xml"), new DeserializeDockContent(this.DeserializeDockContent));
      }
      catch
      {
      }
      this.chunkList = new frmChunkList();
      this.chunkList.File = this.File;
      this.chunkList.DockAreas = DockAreas.Document;
      this.chunkList.Show(this.dockPanel, DockState.Document);
      this.chunkList.OnSelectChunk += new EventHandler<SelectChunkArgs>(this.frmCR2WDocument_OnSelectChunk);
      if (MainController.Get().Configuration.EnableFlowTreeEditor)
      {
        this.flowDiagram = new frmChunkFlowDiagram();
        this.flowDiagram.File = this.File;
        this.flowDiagram.DockAreas = DockAreas.Document;
        this.flowDiagram.Show(this.dockPanel, DockState.Document);
        this.flowDiagram.OnSelectChunk += new EventHandler<SelectChunkArgs>(this.frmCR2WDocument_OnSelectChunk);
      }
      this.embeddedFiles = new frmEmbeddedFiles();
      this.embeddedFiles.File = this.file;
      this.embeddedFiles.DockAreas = DockAreas.Document;
      this.embeddedFiles.Hide();
      this.propertyWindow = new frmChunkProperties();
      this.propertyWindow.Show(this.dockPanel, DockState.DockBottom);
      this.chunkList.Activate();
    }

    private void frmCR2WDocument_FormClosed(object sender, FormClosedEventArgs e)
    {
      this.dockPanel.SaveAsXml(Path.Combine(Path.GetDirectoryName(Configuration.ConfigurationPath), "cr2wdocument_layout.xml"));
      if (this.propertyWindow == null || this.propertyWindow.IsDisposed)
        return;
      this.propertyWindow.Close();
    }

    public IDockContent DeserializeDockContent(string persistString)
    {
      return (IDockContent) null;
    }

    private void frmCR2WDocument_OnSelectChunk(object sender, SelectChunkArgs e)
    {
      if (this.propertyWindow == null || this.propertyWindow.IsDisposed)
      {
        this.propertyWindow = new frmChunkProperties();
        this.propertyWindow.Show(this.dockPanel, DockState.DockBottom);
      }
      this.propertyWindow.Chunk = e.Chunk;
    }

    public void LoadFile(string filename)
    {
      using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
      {
        this.loadFile((Stream) fileStream, filename);
        fileStream.Close();
      }
    }

    public void LoadFile(string filename, Stream stream)
    {
      this.loadFile(stream, filename);
    }

    private void loadFile(Stream stream, string filename)
    {
      this.Text = Path.GetFileName(filename) + " [" + filename + "]";
      using (BinaryReader file = new BinaryReader(stream))
        this.File = new CR2WFile(file)
        {
          FileName = filename,
          EditorController = (IVariableEditor) MainController.Get(),
          LocalizedStringSource = (ILocalizedStringSource) MainController.Get()
        };
    }

    public void SaveFile()
    {
      if (this.SaveTarget == null)
        this.saveToFileName();
      else
        this.saveToMemoryStream();
    }

    private void saveToMemoryStream()
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (BinaryWriter file = new BinaryWriter((Stream) memoryStream))
        {
          this.File.Write(file);
          if (this.OnFileSaved == null)
            return;
          this.OnFileSaved((object) this, new FileSavedEventArgs()
          {
            FileName = this.FileName,
            Stream = (Stream) memoryStream,
            File = this.File
          });
        }
      }
    }

    private void saveToFileName()
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (BinaryWriter file = new BinaryWriter((Stream) memoryStream))
        {
          this.File.Write(file);
          memoryStream.Seek(0L, SeekOrigin.Begin);
          using (FileStream fileStream = new FileStream(this.FileName, FileMode.Create, FileAccess.Write))
          {
            memoryStream.WriteTo((Stream) fileStream);
            if (this.OnFileSaved != null)
              this.OnFileSaved((object) this, new FileSavedEventArgs()
              {
                FileName = this.FileName,
                Stream = (Stream) fileStream,
                File = this.File
              });
            fileStream.Close();
          }
        }
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
      this.components = (IContainer) new Container();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmCR2WDocument));
      this.imageList1 = new ImageList(this.components);
      this.dockPanel = new DockPanel();
      this.vS2012LightTheme1 = new VS2012LightTheme();
      this.SuspendLayout();
      this.imageList1.ColorDepth = ColorDepth.Depth8Bit;
      this.imageList1.ImageSize = new Size(16, 16);
      this.imageList1.TransparentColor = Color.Transparent;
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
      this.dockPanel.Size = new Size(588, 395);
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
      this.dockPanel.TabIndex = 1;
      this.dockPanel.Theme = (ThemeBase) this.vS2012LightTheme1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new Size(588, 395);
      this.Controls.Add((Control) this.dockPanel);
      this.DockAreas = DockAreas.Float | DockAreas.Document;
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmCR2WDocument);
      this.Text = nameof (frmCR2WDocument);
      this.FormClosed += new FormClosedEventHandler(this.frmCR2WDocument_FormClosed);
      this.ResumeLayout(false);
    }
  }
}
