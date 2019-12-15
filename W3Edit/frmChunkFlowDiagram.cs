// Decompiled with JetBrains decompiler
// Type: W3Edit.frmChunkFlowDiagram
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using W3Edit.CR2W;
using W3Edit.CR2W.Types;
using W3Edit.FlowTreeEditors;
using WeifenLuo.WinFormsUI.Docking;

namespace W3Edit
{
  public class frmChunkFlowDiagram : DockContent
  {
    private int connectionPointSize = 7;
    private CR2WFile file;
    private Brush selectionBackground;
    private Pen selectionBorder;
    private Pen selectionItemHighlight;
    private Brush selectionItemHighlightBrush;
    private Point selectionStart;
    private Point selectionEnd;
    private HashSet<ChunkEditor> selectedEditors;
    private bool isSelecting;
    private Pen connectionTargetColor;
    private bool isConnecting;
    private CPtr connectingSource;
    private ChunkEditor connectingSourceEditor;
    private int connectingSourceIndex;
    public ChunkEditor EditorUnderCursor;
    private Dictionary<int, List<ChunkEditor>> EditorLayout;
    private int maxdepth;
    private ChunkEditor connectingTarget;
    private IContainer components;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem copyToolStripMenuItem;
    private ToolStripMenuItem pasteToolStripMenuItem;
    private ToolStripMenuItem copyDisplayTextToolStripMenuItem;

    public CR2WFile File
    {
      get
      {
        return this.file;
      }
      set
      {
        this.file = value;
        this.createChunkEditors();
      }
    }

    public Dictionary<CR2WChunk, ChunkEditor> ChunkEditors { get; set; }

    public event EventHandler<SelectChunkArgs> OnSelectChunk;

    public frmChunkFlowDiagram()
    {
      this.InitializeComponent();
      this.selectionBackground = (Brush) new SolidBrush(Color.FromArgb(100, SystemColors.Highlight));
      this.selectionBorder = new Pen(Color.FromArgb(200, SystemColors.Highlight));
      this.selectionItemHighlight = new Pen(Color.Green, 2f);
      this.selectionItemHighlightBrush = (Brush) new SolidBrush(Color.Green);
      this.selectedEditors = new HashSet<ChunkEditor>();
      this.connectionTargetColor = new Pen(Color.Red, 2f);
    }

    private void createChunkEditors()
    {
      if (this.File == null)
        return;
      this.ChunkEditors = new Dictionary<CR2WChunk, ChunkEditor>();
      List<CR2WChunk> rootNodes = new List<CR2WChunk>();
      CR2WChunk chunk = this.File.chunks[0];
      if (this.File != null && this.File.chunks.Count > 0)
      {
        switch (chunk.Type)
        {
          case "CStoryScene":
            this.getStorySceneRootNodes(rootNodes);
            break;
        }
      }
      this.EditorLayout = new Dictionary<int, List<ChunkEditor>>();
      foreach (CR2WChunk c in rootNodes)
        this.createEditor(0, c);
      for (int maxdepth = this.maxdepth; maxdepth >= 0; --maxdepth)
      {
        int x = maxdepth * 400;
        int y = 0;
        if (this.EditorLayout.ContainsKey(maxdepth))
        {
          foreach (ChunkEditor chunkEditor in this.EditorLayout[maxdepth])
          {
            chunkEditor.Location = new Point(x, y);
            y += chunkEditor.Height + 15;
          }
        }
      }
      int num1 = 0;
      int num2 = 0;
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        if (num1 < control.Location.X + control.Width)
          num1 = control.Location.X + control.Width;
        if (num2 < control.Location.Y + control.Height)
          num2 = control.Location.Y + control.Height;
      }
      this.AutoScrollMinSize = new Size(num1 + 100, num2 + 100);
    }

    private void createEditor(int depth, CR2WChunk c)
    {
      if (this.ChunkEditors.ContainsKey(c))
        return;
      ChunkEditor editor = this.GetEditor(c);
      editor.Chunk = c;
      editor.OnSelectChunk += new EventHandler<SelectChunkArgs>(this.editor_OnSelectChunk);
      editor.OnManualMove += new EventHandler<MoveEditorArgs>(this.editor_OnMove);
      editor.LocationChanged += new EventHandler(this.editor_LocationChanged);
      this.Controls.Add((Control) editor);
      this.ChunkEditors.Add(c, editor);
      if (depth > this.maxdepth)
        this.maxdepth = depth;
      if (!this.EditorLayout.ContainsKey(depth))
        this.EditorLayout.Add(depth, new List<ChunkEditor>());
      this.EditorLayout[depth].Add(editor);
      List<CPtr> connections = editor.GetConnections();
      if (connections == null)
        return;
      foreach (CPtr cptr in connections)
      {
        if (cptr.PtrTarget != null)
          this.createEditor(depth + 1, cptr.PtrTarget);
      }
    }

    private void editor_LocationChanged(object sender, EventArgs e)
    {
      this.Invalidate();
    }

    private void editor_OnMove(object sender, MoveEditorArgs e)
    {
      if (((IEnumerable<object>) this.selectedEditors).Contains<object>(sender))
      {
        foreach (ChunkEditor selectedEditor in this.selectedEditors)
        {
          if (selectedEditor != sender)
            selectedEditor.Location = new Point(selectedEditor.Location.X + e.Relative.X, selectedEditor.Location.Y + e.Relative.Y);
        }
      }
      this.Refresh();
    }

    private void editor_OnSelectChunk(object sender, SelectChunkArgs e)
    {
      if (this.OnSelectChunk == null)
        return;
      this.OnSelectChunk(sender, e);
    }

    private void getStorySceneRootNodes(List<CR2WChunk> rootNodes)
    {
      CVariable variableByName = this.File.chunks[0].GetVariableByName("controlParts");
      if (variableByName == null || !(variableByName is CArray))
        return;
      foreach (CVariable cvariable in (CArray) variableByName)
      {
        if (cvariable is CPtr)
        {
          CPtr cptr = (CPtr) cvariable;
          if (cptr != null && cptr.PtrTargetType == "CStorySceneInput")
            rootNodes.Add(cptr.PtrTarget);
        }
      }
    }

    public ChunkEditor GetEditor(CR2WChunk c)
    {
      if (c.data is CStorySceneSection)
        return (ChunkEditor) new SceneSectionEditor();
      switch (c.Type)
      {
        case "CStorySceneChoice":
          return (ChunkEditor) new SceneChoiceEditor();
        case "CStorySceneFlowCondition":
          return (ChunkEditor) new SceneFlowConditionEditor();
        case "CStorySceneRandomizer":
          return (ChunkEditor) new SceneRandomizerEditor();
        default:
          return (ChunkEditor) new SceneLinkEditor();
      }
    }

    private void frmChunkFlowView_Paint(object sender, PaintEventArgs e)
    {
      foreach (ChunkEditor chunkEditor1 in this.ChunkEditors.Values)
      {
        bool flag = false;
        if (this.selectedEditors.Contains(chunkEditor1))
          flag = true;
        Brush brush = flag ? this.selectionItemHighlightBrush : Brushes.Black;
        Pen c = flag ? this.selectionItemHighlight : Pens.Black;
        int i = 0;
        List<CPtr> connections = chunkEditor1.GetConnections();
        if (connections != null)
        {
          foreach (CPtr cptr in connections)
          {
            if (this.ChunkEditors.ContainsKey(cptr.PtrTarget))
            {
              ChunkEditor chunkEditor2 = this.ChunkEditors[cptr.PtrTarget];
              Point connectionLocation = chunkEditor1.GetConnectionLocation(i);
              e.Graphics.FillRectangle(brush, chunkEditor1.Location.X + chunkEditor1.Width, chunkEditor1.Location.Y + connectionLocation.Y - this.connectionPointSize / 2, this.connectionPointSize, this.connectionPointSize);
              this.DrawConnectionBezier(e.Graphics, c, chunkEditor1.Location.X + chunkEditor1.Width + this.connectionPointSize, chunkEditor1.Location.Y + connectionLocation.Y, chunkEditor2.Location.X, chunkEditor2.Location.Y + chunkEditor2.Height / 2);
            }
            ++i;
          }
        }
        if (flag)
          e.Graphics.DrawRectangle(this.selectionItemHighlight, chunkEditor1.Location.X - 1, chunkEditor1.Location.Y - 1, chunkEditor1.Width + 2, chunkEditor1.Height + 2);
      }
      if (this.isSelecting)
      {
        Rectangle rect = new Rectangle(this.selectionStart.X < this.selectionEnd.X ? this.selectionStart.X : this.selectionEnd.X, this.selectionStart.Y < this.selectionEnd.Y ? this.selectionStart.Y : this.selectionEnd.Y, Math.Abs(this.selectionStart.X - this.selectionEnd.X), Math.Abs(this.selectionStart.Y - this.selectionEnd.Y));
        e.Graphics.FillRectangle(this.selectionBackground, rect);
        e.Graphics.DrawRectangle(this.selectionBorder, rect);
      }
      if (!this.isConnecting)
        return;
      ChunkEditor connectingSourceEditor = this.connectingSourceEditor;
      Point connectionLocation1 = connectingSourceEditor.GetConnectionLocation(this.connectingSourceIndex);
      if (this.connectingTarget != null)
      {
        Rectangle rect = new Rectangle(this.connectingTarget.Location.X - 1, this.connectingTarget.Location.Y - 1, this.connectingTarget.Width + 2, this.connectingTarget.Height + 2);
        e.Graphics.DrawRectangle(this.connectionTargetColor, rect);
        this.DrawConnectionBezier(e.Graphics, this.connectionTargetColor, connectingSourceEditor.Location.X + connectingSourceEditor.Width + this.connectionPointSize, connectingSourceEditor.Location.Y + connectionLocation1.Y, this.connectingTarget.Location.X, this.connectingTarget.Location.Y + this.connectingTarget.Height / 2);
      }
      else
        this.DrawConnectionBezier(e.Graphics, this.connectionTargetColor, connectingSourceEditor.Location.X + connectingSourceEditor.Width + this.connectionPointSize, connectingSourceEditor.Location.Y + connectionLocation1.Y, this.selectionEnd.X, this.selectionEnd.Y);
    }

    private void DrawConnectionBezier(Graphics g, Pen c, int x1, int y1, int x2, int y2)
    {
      int num1 = 0;
      int num2 = Math.Max(Math.Min(Math.Abs(x1 - x2) / 2, 200), 50);
      g.DrawBezier(c, (float) x1, (float) y1, (float) (x1 + num2), (float) (y1 + num1), (float) (x2 - num2), (float) (y2 - num1), (float) x2, (float) y2);
    }

    private void frmChunkFlowDiagram_Scroll(object sender, ScrollEventArgs e)
    {
      this.Invalidate();
    }

    private void frmChunkFlowDiagram_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void frmChunkFlowDiagram_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      foreach (ChunkEditor chunkEditor in this.ChunkEditors.Values)
      {
        List<CPtr> connections = chunkEditor.GetConnections();
        if (connections != null)
        {
          for (int i = 0; i < connections.Count; ++i)
          {
            Point connectionLocation = chunkEditor.GetConnectionLocation(i);
            if (new Rectangle(chunkEditor.Location.X + chunkEditor.Width, chunkEditor.Location.Y + connectionLocation.Y - this.connectionPointSize / 2, this.connectionPointSize, this.connectionPointSize).Contains(e.Location))
            {
              this.connectingSource = connections[i];
              this.connectingSourceEditor = chunkEditor;
              this.connectingSourceIndex = i;
              this.isConnecting = true;
              return;
            }
          }
        }
      }
      this.selectionStart = e.Location;
      this.isSelecting = true;
    }

    private void frmChunkFlowDiagram_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.isSelecting)
      {
        this.selectionEnd = e.Location;
        this.SelectChunks();
        this.Invalidate();
      }
      if (!this.isConnecting)
        return;
      this.selectionEnd = e.Location;
      this.CheckConnectTarget();
      this.Invalidate();
    }

    private void CheckConnectTarget()
    {
      this.connectingTarget = (ChunkEditor) null;
      foreach (ChunkEditor chunkEditor in this.ChunkEditors.Values)
      {
        if (new Rectangle(chunkEditor.Location, chunkEditor.Size).Contains(this.selectionEnd.X, this.selectionEnd.Y))
        {
          this.connectingTarget = chunkEditor;
          break;
        }
      }
    }

    private void frmChunkFlowDiagram_MouseUp(object sender, MouseEventArgs e)
    {
      if (this.isSelecting)
      {
        this.selectionEnd = e.Location;
        this.isSelecting = false;
        this.SelectChunks();
        this.Invalidate();
      }
      if (!this.isConnecting)
        return;
      this.selectionEnd = e.Location;
      this.isConnecting = false;
      this.DoConnect();
      this.Invalidate();
    }

    private void DoConnect()
    {
      if (this.connectingTarget == null)
        return;
      this.connectingSource.PtrTarget = this.connectingTarget.Chunk;
    }

    private void SelectChunks()
    {
      this.selectedEditors.Clear();
      Rectangle rectangle = new Rectangle(this.selectionStart.X < this.selectionEnd.X ? this.selectionStart.X : this.selectionEnd.X, this.selectionStart.Y < this.selectionEnd.Y ? this.selectionStart.Y : this.selectionEnd.Y, Math.Abs(this.selectionStart.X - this.selectionEnd.X), Math.Abs(this.selectionStart.Y - this.selectionEnd.Y));
      foreach (ChunkEditor chunkEditor in this.ChunkEditors.Values)
      {
        Rectangle rect = new Rectangle(chunkEditor.Location, chunkEditor.Size);
        if (rectangle.IntersectsWith(rect))
          this.selectedEditors.Add(chunkEditor);
      }
    }

    protected override Point ScrollToControl(Control activeControl)
    {
      return this.AutoScrollPosition;
    }

    private void frmChunkFlowDiagram_Load(object sender, EventArgs e)
    {
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
      this.EditorUnderCursor = (ChunkEditor) null;
      foreach (ChunkEditor chunkEditor in this.ChunkEditors.Values)
      {
        if (new Rectangle(this.PointToScreen(chunkEditor.Location), chunkEditor.Size).Contains(this.contextMenuStrip1.Left, this.contextMenuStrip1.Top))
        {
          this.EditorUnderCursor = chunkEditor;
          break;
        }
      }
      this.copyToolStripMenuItem.Enabled = this.selectedEditors.Count > 0 || this.EditorUnderCursor != null;
      this.copyDisplayTextToolStripMenuItem.Enabled = this.selectedEditors.Count > 0 || this.EditorUnderCursor != null;
      this.pasteToolStripMenuItem.Enabled = CopyController.ChunkList != null;
    }

    private void copyDisplayTextToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (this.selectedEditors.Count == 0)
      {
        ChunkEditor editorUnderCursor = this.EditorUnderCursor;
        if (editorUnderCursor != null)
          stringBuilder.AppendLine(editorUnderCursor.GetCopyText());
      }
      else
      {
        foreach (ChunkEditor selectedEditor in this.selectedEditors)
          stringBuilder.AppendLine(selectedEditor.GetCopyText());
      }
      if (stringBuilder.Length <= 0)
        return;
      Clipboard.SetText(stringBuilder.ToString());
    }

    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
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
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.copyToolStripMenuItem = new ToolStripMenuItem();
      this.pasteToolStripMenuItem = new ToolStripMenuItem();
      this.copyDisplayTextToolStripMenuItem = new ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.copyToolStripMenuItem,
        (ToolStripItem) this.pasteToolStripMenuItem,
        (ToolStripItem) this.copyDisplayTextToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(169, 92);
      this.contextMenuStrip1.Opening += new CancelEventHandler(this.contextMenuStrip1_Opening);
      this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      this.copyToolStripMenuItem.Size = new Size(168, 22);
      this.copyToolStripMenuItem.Text = "Copy";
      this.copyToolStripMenuItem.Click += new EventHandler(this.copyToolStripMenuItem_Click);
      this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
      this.pasteToolStripMenuItem.Size = new Size(168, 22);
      this.pasteToolStripMenuItem.Text = "Paste";
      this.pasteToolStripMenuItem.Click += new EventHandler(this.pasteToolStripMenuItem_Click);
      this.copyDisplayTextToolStripMenuItem.Name = "copyDisplayTextToolStripMenuItem";
      this.copyDisplayTextToolStripMenuItem.Size = new Size(168, 22);
      this.copyDisplayTextToolStripMenuItem.Text = "Copy Display Text";
      this.copyDisplayTextToolStripMenuItem.Click += new EventHandler(this.copyDisplayTextToolStripMenuItem_Click);
      this.AutoScaleMode = AutoScaleMode.None;
      this.AutoScroll = true;
      this.ClientSize = new Size(715, 446);
      this.CloseButton = false;
      this.CloseButtonVisible = false;
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.DockAreas = DockAreas.Float | DockAreas.Document;
      this.DoubleBuffered = true;
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (frmChunkFlowDiagram);
      this.Text = "Flow Diagram";
      this.Load += new EventHandler(this.frmChunkFlowDiagram_Load);
      this.Scroll += new ScrollEventHandler(this.frmChunkFlowDiagram_Scroll);
      this.Paint += new PaintEventHandler(this.frmChunkFlowView_Paint);
      this.KeyDown += new KeyEventHandler(this.frmChunkFlowDiagram_KeyDown);
      this.MouseDown += new MouseEventHandler(this.frmChunkFlowDiagram_MouseDown);
      this.MouseMove += new MouseEventHandler(this.frmChunkFlowDiagram_MouseMove);
      this.MouseUp += new MouseEventHandler(this.frmChunkFlowDiagram_MouseUp);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
