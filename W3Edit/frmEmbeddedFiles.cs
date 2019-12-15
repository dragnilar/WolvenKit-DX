// Decompiled with JetBrains decompiler
// Type: W3Edit.frmEmbeddedFiles
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using BrightIdeasSoftware;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using W3Edit.CR2W;
using WeifenLuo.WinFormsUI.Docking;

namespace W3Edit
{
  public class frmEmbeddedFiles : DockContent
  {
    private CR2WFile file;
    private IContainer components;
    private ObjectListView listView;
    private OLVColumn colSize;
    private OLVColumn colName;
    private OLVColumn colUnk3;
    private OLVColumn colUnk4;

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

    public frmEmbeddedFiles()
    {
      this.InitializeComponent();
      this.listView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.chunkListView_ItemSelectionChanged);
    }

    private void chunkListView_ItemSelectionChanged(
      object sender,
      ListViewItemSelectionChangedEventArgs e)
    {
    }

    private void updateList()
    {
      if (this.File == null)
        return;
      this.listView.Objects = (IEnumerable) this.File.block7;
    }

    private void listView_CellClick(object sender, CellClickEventArgs e)
    {
      if (e.Column == null || e.Item == null || e.ClickCount != 2)
        return;
      frmCR2WDocument frmCr2Wdocument = MainController.Get().LoadDocument("Embedded file", new MemoryStream(((CR2WHeaderBlock7) e.Model).unknowndata), false);
      if (frmCr2Wdocument == null)
        return;
      frmCr2Wdocument.OnFileSaved += new EventHandler<FileSavedEventArgs>(this.OnFileSaved);
      frmCr2Wdocument.SaveTarget = (object) (CR2WHeaderBlock7) e.Model;
    }

    private void OnFileSaved(object sender, FileSavedEventArgs e)
    {
      ((CR2WHeaderBlock7) ((frmCR2WDocument) sender).SaveTarget).unknowndata = ((MemoryStream) e.Stream).ToArray();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.listView = new ObjectListView();
      this.colSize = new OLVColumn();
      this.colName = new OLVColumn();
      this.colUnk3 = new OLVColumn();
      this.colUnk4 = new OLVColumn();
      ((ISupportInitialize) this.listView).BeginInit();
      this.SuspendLayout();
      this.listView.AllColumns.Add(this.colSize);
      this.listView.AllColumns.Add(this.colUnk3);
      this.listView.AllColumns.Add(this.colUnk4);
      this.listView.AllColumns.Add(this.colName);
      this.listView.Columns.AddRange(new ColumnHeader[4]
      {
        (ColumnHeader) this.colSize,
        (ColumnHeader) this.colUnk3,
        (ColumnHeader) this.colUnk4,
        (ColumnHeader) this.colName
      });
      this.listView.Dock = DockStyle.Fill;
      this.listView.FullRowSelect = true;
      this.listView.GridLines = true;
      this.listView.Location = new Point(0, 0);
      this.listView.Name = "listView";
      this.listView.ShowGroups = false;
      this.listView.Size = new Size(284, 262);
      this.listView.TabIndex = 5;
      this.listView.UseCompatibleStateImageBehavior = false;
      this.listView.View = View.Details;
      this.listView.CellClick += new EventHandler<CellClickEventArgs>(this.listView_CellClick);
      this.colSize.AspectName = "size";
      this.colSize.Text = "Size";
      this.colSize.Width = 100;
      this.colName.AspectName = "Handles";
      this.colName.Text = "Handles";
      this.colName.Width = 400;
      this.colUnk3.AspectName = "unk3";
      this.colUnk3.Text = "unk3";
      this.colUnk4.AspectName = "unk4";
      this.colUnk4.Text = "unk4";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(284, 262);
      this.CloseButton = false;
      this.CloseButtonVisible = false;
      this.Controls.Add((Control) this.listView);
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (frmEmbeddedFiles);
      this.Text = "Embedded files";
      ((ISupportInitialize) this.listView).EndInit();
      this.ResumeLayout(false);
    }
  }
}
