// Decompiled with JetBrains decompiler
// Type: W3Edit.frmChunkList
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using BrightIdeasSoftware;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using W3Edit.CR2W;
using WeifenLuo.WinFormsUI.Docking;

namespace W3Edit
{
  public class frmChunkList : DockContent
  {
    private CR2WFile file;
    private IContainer components;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem addChunkToolStripMenuItem;
    private ToolStripMenuItem deleteChunkToolStripMenuItem;
    private ObjectListView listView;
    private OLVColumn colIndex;
    private OLVColumn colName;
    private OLVColumn colDisplay;

    public CR2WFile File
    {
      get
      {
        return this.file;
      }
      set
      {
        this.file = value;
        this.updateList();
      }
    }

    public event EventHandler<SelectChunkArgs> OnSelectChunk;

    public frmChunkList()
    {
      this.InitializeComponent();
      this.listView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.chunkListView_ItemSelectionChanged);
    }

    private void updateList()
    {
      if (this.File == null)
        return;
      this.listView.Objects = (IEnumerable) this.File.chunks;
    }

    private void chunkListView_ItemSelectionChanged(
      object sender,
      ListViewItemSelectionChangedEventArgs e)
    {
      if (this.OnSelectChunk == null || (CR2WChunk) this.listView.SelectedObject == null)
        return;
      this.OnSelectChunk((object) this, new SelectChunkArgs()
      {
        Chunk = (CR2WChunk) this.listView.SelectedObject
      });
    }

    private void addChunkToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmAddChunk frmAddChunk = new frmAddChunk();
      if (frmAddChunk.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        CR2WChunk chunk = this.File.CreateChunk(frmAddChunk.ChunkType, (CR2WChunk) null);
        this.listView.AddObject((object) chunk);
        if (this.OnSelectChunk == null || chunk == null)
          return;
        this.OnSelectChunk((object) this, new SelectChunkArgs()
        {
          Chunk = chunk
        });
      }
      catch (InvalidChunkTypeException ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Error adding chunk.");
      }
    }

    private void deleteChunkToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.listView.SelectedObjects.Count == 0 || MessageBox.Show("Are you sure you want to delete the selected chunk(s)? \n\n NOTE: Any pointers or handles to these chunks will NOT be deleted.", "Confirmation", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      IList selectedObjects = this.listView.SelectedObjects;
      foreach (CR2WChunk chunk in (IEnumerable) selectedObjects)
        this.File.RemoveChunk(chunk);
      this.listView.RemoveObjects((ICollection) selectedObjects);
      this.listView.UpdateObjects((ICollection) this.File.chunks);
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
      this.addChunkToolStripMenuItem = new ToolStripMenuItem();
      this.deleteChunkToolStripMenuItem = new ToolStripMenuItem();
      this.listView = new ObjectListView();
      this.colIndex = new OLVColumn();
      this.colName = new OLVColumn();
      this.colDisplay = new OLVColumn();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.listView).BeginInit();
      this.SuspendLayout();
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.addChunkToolStripMenuItem,
        (ToolStripItem) this.deleteChunkToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(146, 48);
      this.addChunkToolStripMenuItem.Name = "addChunkToolStripMenuItem";
      this.addChunkToolStripMenuItem.Size = new Size(145, 22);
      this.addChunkToolStripMenuItem.Text = "Add Chunk";
      this.addChunkToolStripMenuItem.Click += new EventHandler(this.addChunkToolStripMenuItem_Click);
      this.deleteChunkToolStripMenuItem.Name = "deleteChunkToolStripMenuItem";
      this.deleteChunkToolStripMenuItem.Size = new Size(145, 22);
      this.deleteChunkToolStripMenuItem.Text = "Delete Chunk";
      this.deleteChunkToolStripMenuItem.Click += new EventHandler(this.deleteChunkToolStripMenuItem_Click);
      this.listView.AllColumns.Add(this.colIndex);
      this.listView.AllColumns.Add(this.colName);
      this.listView.AllColumns.Add(this.colDisplay);
      this.listView.Columns.AddRange(new ColumnHeader[3]
      {
        (ColumnHeader) this.colIndex,
        (ColumnHeader) this.colName,
        (ColumnHeader) this.colDisplay
      });
      this.listView.ContextMenuStrip = this.contextMenuStrip1;
      this.listView.Dock = DockStyle.Fill;
      this.listView.FullRowSelect = true;
      this.listView.GridLines = true;
      this.listView.Location = new Point(0, 0);
      this.listView.Name = "listView";
      this.listView.ShowGroups = false;
      this.listView.Size = new Size(528, 253);
      this.listView.TabIndex = 4;
      this.listView.UseCompatibleStateImageBehavior = false;
      this.listView.View = View.Details;
      this.colIndex.AspectName = "ChunkIndex";
      this.colIndex.Text = "Index";
      this.colName.AspectName = "Name";
      this.colName.Text = "Name";
      this.colName.Width = 300;
      this.colDisplay.AspectName = "Preview";
      this.colDisplay.Text = "Preview";
      this.colDisplay.Width = 352;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(528, 253);
      this.CloseButton = false;
      this.CloseButtonVisible = false;
      this.Controls.Add((Control) this.listView);
      this.DockAreas = DockAreas.Float | DockAreas.Document;
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.MinimumSize = new Size(100, 100);
      this.Name = nameof (frmChunkList);
      this.Text = "Chunk List";
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.listView).EndInit();
      this.ResumeLayout(false);
    }
  }
}
