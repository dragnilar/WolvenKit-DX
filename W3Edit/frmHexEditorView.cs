// Decompiled with JetBrains decompiler
// Type: W3Edit.frmHexEditorView
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using W3Edit.CR2W;
using W3Edit.CR2W.Editors;
using W3Edit.CR2W.Types;

namespace W3Edit
{
  public class frmHexEditorView : Form, IVirtualListDataSource
  {
    private byte[] bytes;
    private byte[] readable;
    private int bytestart;
    private IContainer components;
    private TreeListView treeView;
    private OLVColumn colName;
    private OLVColumn colValue;
    private OLVColumn colType;
    private SplitContainer splitContainer1;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel spacer;
    private ToolStripStatusLabel lblPosition;
    private OLVColumn colEndAt;
    private OLVColumn colHex;
    private OLVColumn colMethod;
    private VirtualObjectListView listView;
    private OLVColumn colPosition;
    private OLVColumn colPos;

    public CR2WFile File { get; set; }

    public byte[] Bytes
    {
      get
      {
        return this.bytes;
      }
      set
      {
        this.bytes = value;
        this.UpdateHex();
      }
    }

    private List<frmHexEditorView.VariableListNode> Root { get; set; }

    private List<frmHexEditorView.HexListNode> HexRoot { get; set; }

    public frmHexEditorView()
    {
      this.InitializeComponent();
      this.Root = new List<frmHexEditorView.VariableListNode>();
      this.treeView.CanExpandGetter = (TreeListView.CanExpandGetterDelegate) (x => ((frmHexEditorView.VariableListNode) x).ChildCount > 0);
      this.treeView.ChildrenGetter = (TreeListView.ChildrenGetterDelegate) (x => (IEnumerable) ((frmHexEditorView.VariableListNode) x).Children);
      this.treeView.Roots = (IEnumerable) this.Root;
      for (int index = 0; index < 16; ++index)
      {
        OLVColumn olvColumn = new OLVColumn();
        olvColumn.Name = nameof (colHex) + index.ToString("X2");
        olvColumn.Text = index.ToString("X2");
        olvColumn.AspectName = "Hex" + index.ToString("X2");
        olvColumn.Width = 30;
        olvColumn.Sortable = false;
        olvColumn.Searchable = false;
        olvColumn.RendererDelegate = (RenderDelegate) ((e, g, r, rowObject) =>
        {
          DrawListViewSubItemEventArgs subItemEventArgs = (DrawListViewSubItemEventArgs) e;
          int i = subItemEventArgs.ColumnIndex - 1;
          frmHexEditorView.HexListNode hexListNode = (frmHexEditorView.HexListNode) rowObject;
          if (hexListNode.pos + i == this.bytestart)
          {
            g.FillRectangle(SystemBrushes.Highlight, r.X - 1, r.Y - 1, r.Width + 2, r.Height + 2);
            g.DrawString(hexListNode.GetHex(i), this.listView.Font, SystemBrushes.HighlightText, (float) (r.X + 3), (float) (r.Y + 2));
          }
          else
          {
            g.FillRectangle(SystemBrushes.Window, r.X - 1, r.Y - 1, r.Width + 2, r.Height + 2);
            g.DrawString(hexListNode.GetHex(i), this.listView.Font, SystemBrushes.WindowText, (float) (r.X + 3), (float) (r.Y + 2));
          }
          subItemEventArgs.DrawDefault = false;
          return true;
        });
        this.listView.Columns.Add((ColumnHeader) olvColumn);
      }
      ListView.ColumnHeaderCollection columns = this.listView.Columns;
      OLVColumn olvColumn1 = new OLVColumn();
      olvColumn1.Name = "colText";
      olvColumn1.Text = "Text";
      olvColumn1.AspectName = "Text";
      olvColumn1.HeaderFont = ((OLVColumn) this.listView.Columns[0]).HeaderFont;
      olvColumn1.Width = 200;
      olvColumn1.Sortable = false;
      olvColumn1.Searchable = false;
      OLVColumn olvColumn2 = olvColumn1;
      columns.Add((ColumnHeader) olvColumn2);
    }

    private void UpdateHex()
    {
      this.HexRoot = new List<frmHexEditorView.HexListNode>();
      this.readable = new byte[this.bytes.Length];
      for (int index = 0; index < this.bytes.Length; ++index)
        this.readable[index] = this.bytes[index] <= (byte) 31 || this.bytes[index] >= (byte) 127 ? (byte) 46 : this.bytes[index];
      for (int pos = 0; pos < this.bytes.Length; pos += 16)
        this.HexRoot.Add(new frmHexEditorView.HexListNode(this.bytes, this.readable, pos));
      this.listView.VirtualListDataSource = (IVirtualListDataSource) this;
    }

    internal frmHexEditorView.VariableListNode CreatePropertyLayout(
      IEditableVariable v)
    {
      frmHexEditorView.VariableListNode variableListNode = this.AddListViewItems(v, (frmHexEditorView.VariableListNode) null, 0);
      this.Root.Add(variableListNode);
      return variableListNode;
    }

    private frmHexEditorView.VariableListNode AddListViewItems(
      IEditableVariable v,
      frmHexEditorView.VariableListNode parent = null,
      int arrayindex = 0)
    {
      frmHexEditorView.VariableListNode parent1 = new frmHexEditorView.VariableListNode();
      parent1.Variable = v;
      parent1.Children = new List<frmHexEditorView.VariableListNode>();
      parent1.Parent = parent;
      List<IEditableVariable> editableVariables = v.GetEditableVariables();
      if (editableVariables != null)
      {
        for (int arrayindex1 = 0; arrayindex1 < editableVariables.Count; ++arrayindex1)
          parent1.Children.Add(this.AddListViewItems(editableVariables[arrayindex1], parent1, arrayindex1));
      }
      return parent1;
    }

    private void ReadBytes(int bytestart, BinaryReader reader)
    {
      reader.BaseStream.Seek((long) bytestart, SeekOrigin.Begin);
      try
      {
        CVector cvector = new CVector(this.File);
        cvector.Read(reader, (uint) (this.bytes.Length - bytestart));
        frmHexEditorView.VariableListNode propertyLayout = this.CreatePropertyLayout((IEditableVariable) cvector);
        propertyLayout.EndPosition = (int) reader.BaseStream.Position;
        propertyLayout.HexValue = this.bytes[bytestart].ToString("X2");
        propertyLayout.Method = "CVector";
      }
      catch
      {
      }
      reader.BaseStream.Seek((long) bytestart, SeekOrigin.Begin);
      try
      {
        CUInt64 cuInt64 = new CUInt64(this.File);
        cuInt64.Read(reader, (uint) (this.bytes.Length - bytestart));
        frmHexEditorView.VariableListNode propertyLayout = this.CreatePropertyLayout((IEditableVariable) cuInt64);
        propertyLayout.EndPosition = (int) reader.BaseStream.Position;
        propertyLayout.HexValue = this.bytes[bytestart].ToString("X2");
        propertyLayout.Method = "CUInt64";
      }
      catch
      {
      }
      reader.BaseStream.Seek((long) bytestart, SeekOrigin.Begin);
      try
      {
        CUInt32 cuInt32 = new CUInt32(this.File);
        cuInt32.Read(reader, (uint) (this.bytes.Length - bytestart));
        frmHexEditorView.VariableListNode propertyLayout = this.CreatePropertyLayout((IEditableVariable) cuInt32);
        propertyLayout.EndPosition = (int) reader.BaseStream.Position;
        propertyLayout.HexValue = this.bytes[bytestart].ToString("X2");
        propertyLayout.Method = "CUInt32";
      }
      catch
      {
      }
      reader.BaseStream.Seek((long) bytestart, SeekOrigin.Begin);
      try
      {
        CUInt16 cuInt16 = new CUInt16(this.File);
        cuInt16.Read(reader, (uint) (this.bytes.Length - bytestart));
        frmHexEditorView.VariableListNode propertyLayout = this.CreatePropertyLayout((IEditableVariable) cuInt16);
        propertyLayout.EndPosition = (int) reader.BaseStream.Position;
        propertyLayout.HexValue = this.bytes[bytestart].ToString("X2");
        propertyLayout.Method = "CUInt16";
      }
      catch
      {
      }
      reader.BaseStream.Seek((long) bytestart, SeekOrigin.Begin);
      try
      {
        CUInt8 cuInt8 = new CUInt8(this.File);
        cuInt8.Read(reader, (uint) (this.bytes.Length - bytestart));
        frmHexEditorView.VariableListNode propertyLayout = this.CreatePropertyLayout((IEditableVariable) cuInt8);
        propertyLayout.EndPosition = (int) reader.BaseStream.Position;
        propertyLayout.HexValue = this.bytes[bytestart].ToString("X2");
        propertyLayout.Method = "CUInt8";
      }
      catch
      {
      }
      reader.BaseStream.Seek((long) bytestart, SeekOrigin.Begin);
      try
      {
        CDynamicInt cdynamicInt = new CDynamicInt(this.File);
        cdynamicInt.Read(reader, (uint) (this.bytes.Length - bytestart));
        frmHexEditorView.VariableListNode propertyLayout = this.CreatePropertyLayout((IEditableVariable) cdynamicInt);
        propertyLayout.EndPosition = (int) reader.BaseStream.Position;
        propertyLayout.HexValue = this.bytes[bytestart].ToString("X2");
        propertyLayout.Method = "CDynamicInt";
      }
      catch
      {
      }
      reader.BaseStream.Seek((long) bytestart, SeekOrigin.Begin);
      try
      {
        CFloat cfloat = new CFloat(this.File);
        cfloat.Read(reader, (uint) (this.bytes.Length - bytestart));
        frmHexEditorView.VariableListNode propertyLayout = this.CreatePropertyLayout((IEditableVariable) cfloat);
        propertyLayout.EndPosition = (int) reader.BaseStream.Position;
        propertyLayout.HexValue = this.bytes[bytestart].ToString("X2");
        propertyLayout.Method = "CFloat";
      }
      catch
      {
      }
      reader.BaseStream.Seek((long) bytestart, SeekOrigin.Begin);
      try
      {
        CName cname = new CName(this.File);
        cname.Read(reader, (uint) (this.bytes.Length - bytestart));
        frmHexEditorView.VariableListNode propertyLayout = this.CreatePropertyLayout((IEditableVariable) cname);
        propertyLayout.EndPosition = (int) reader.BaseStream.Position;
        propertyLayout.HexValue = this.bytes[bytestart].ToString("X2");
        propertyLayout.Method = "CName";
        string str = propertyLayout.Value;
      }
      catch
      {
      }
      reader.BaseStream.Seek((long) bytestart, SeekOrigin.Begin);
      try
      {
        CHandle chandle = new CHandle(this.File);
        chandle.Read(reader, (uint) (this.bytes.Length - bytestart));
        frmHexEditorView.VariableListNode propertyLayout = this.CreatePropertyLayout((IEditableVariable) chandle);
        propertyLayout.EndPosition = (int) reader.BaseStream.Position;
        propertyLayout.HexValue = this.bytes[bytestart].ToString("X2");
        propertyLayout.Method = "CHandle";
        string str = propertyLayout.Value;
      }
      catch
      {
      }
      reader.BaseStream.Seek((long) bytestart, SeekOrigin.Begin);
      try
      {
        CSoft csoft = new CSoft(this.File);
        csoft.Read(reader, (uint) (this.bytes.Length - bytestart));
        frmHexEditorView.VariableListNode propertyLayout = this.CreatePropertyLayout((IEditableVariable) csoft);
        propertyLayout.EndPosition = (int) reader.BaseStream.Position;
        propertyLayout.HexValue = this.bytes[bytestart].ToString("X2");
        propertyLayout.Method = "CSoft";
        string str = propertyLayout.Value;
      }
      catch
      {
      }
      reader.BaseStream.Seek((long) bytestart, SeekOrigin.Begin);
      try
      {
        CVariable cvariable = this.File.ReadVariable(reader);
        cvariable.Read(reader, (uint) (this.bytes.Length - bytestart));
        frmHexEditorView.VariableListNode propertyLayout = this.CreatePropertyLayout((IEditableVariable) cvariable);
        propertyLayout.EndPosition = (int) reader.BaseStream.Position;
        propertyLayout.HexValue = this.bytes[bytestart].ToString("X2");
        propertyLayout.Method = "ReadVariable";
      }
      catch
      {
      }
    }

    public void AddObjects(ICollection modelObjects)
    {
    }

    public object GetNthObject(int n)
    {
      return (object) this.HexRoot[n];
    }

    public int GetObjectCount()
    {
      return this.HexRoot.Count;
    }

    public int GetObjectIndex(object model)
    {
      return this.HexRoot.IndexOf((frmHexEditorView.HexListNode) model);
    }

    public void PrepareCache(int first, int last)
    {
    }

    public void RemoveObjects(ICollection modelObjects)
    {
    }

    public int SearchText(string value, int first, int last, OLVColumn column)
    {
      return 0;
    }

    public void SetObjects(IEnumerable collection)
    {
    }

    public void Sort(OLVColumn column, SortOrder order)
    {
    }

    public void UpdateObject(int index, object modelObject)
    {
    }

    private void listView_CellClick(object sender, CellClickEventArgs e)
    {
      if (e.Item == null || e.Column == null)
        return;
      int index = e.Item.Index;
      int num = e.ColumnIndex - 1;
      if (num > 15 || num < 0)
        return;
      this.bytestart = index * 16 + num;
      this.lblPosition.Text = "ln: " + (object) index + " col: " + (object) num + " pos: " + (object) this.bytestart;
      this.ExaminePosition();
    }

    private void ExaminePosition()
    {
      BinaryReader reader = new BinaryReader((Stream) new MemoryStream(this.bytes));
      this.Root.Clear();
      this.treeView.Roots = (IEnumerable) null;
      int selectedIndex = this.listView.SelectedIndex;
      this.listView.SelectedIndex = this.bytestart / 16;
      this.listView.EnsureVisible(this.listView.SelectedIndex);
      this.listView.Refresh();
      this.ReadBytes(this.bytestart, reader);
      this.treeView.Roots = (IEnumerable) this.Root;
      this.treeView.ExpandAll();
    }

    private void listView_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Left)
      {
        --this.bytestart;
        e.SuppressKeyPress = true;
      }
      if (e.KeyCode == Keys.Right)
      {
        ++this.bytestart;
        e.SuppressKeyPress = true;
      }
      if (e.KeyCode == Keys.Up)
      {
        this.bytestart -= 16;
        e.SuppressKeyPress = true;
      }
      if (e.KeyCode == Keys.Down)
      {
        this.bytestart += 16;
        e.SuppressKeyPress = true;
      }
      if (this.bytestart < 0)
        this.bytestart = 0;
      if (this.bytestart >= this.bytes.Length)
        this.bytestart = this.bytes.Length - 1;
      this.ExaminePosition();
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
      this.treeView = new TreeListView();
      this.colMethod = new OLVColumn();
      this.colName = new OLVColumn();
      this.colValue = new OLVColumn();
      this.colHex = new OLVColumn();
      this.colType = new OLVColumn();
      this.colEndAt = new OLVColumn();
      this.splitContainer1 = new SplitContainer();
      this.listView = new VirtualObjectListView();
      this.colPos = new OLVColumn();
      this.statusStrip1 = new StatusStrip();
      this.spacer = new ToolStripStatusLabel();
      this.lblPosition = new ToolStripStatusLabel();
      this.colPosition = new OLVColumn();
      ((ISupportInitialize) this.treeView).BeginInit();
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((ISupportInitialize) this.listView).BeginInit();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      this.treeView.AllColumns.Add(this.colMethod);
      this.treeView.AllColumns.Add(this.colName);
      this.treeView.AllColumns.Add(this.colValue);
      this.treeView.AllColumns.Add(this.colHex);
      this.treeView.AllColumns.Add(this.colType);
      this.treeView.AllColumns.Add(this.colEndAt);
      this.treeView.AlternateRowBackColor = Color.LightCyan;
      this.treeView.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
      this.treeView.Columns.AddRange(new ColumnHeader[6]
      {
        (ColumnHeader) this.colMethod,
        (ColumnHeader) this.colName,
        (ColumnHeader) this.colValue,
        (ColumnHeader) this.colHex,
        (ColumnHeader) this.colType,
        (ColumnHeader) this.colEndAt
      });
      this.treeView.Dock = DockStyle.Fill;
      this.treeView.FullRowSelect = true;
      this.treeView.Location = new Point(0, 0);
      this.treeView.Name = "treeView";
      this.treeView.OwnerDraw = true;
      this.treeView.ShowGroups = false;
      this.treeView.Size = new Size(688, 168);
      this.treeView.TabIndex = 2;
      this.treeView.UseAlternatingBackColors = true;
      this.treeView.UseCompatibleStateImageBehavior = false;
      this.treeView.View = View.Details;
      this.treeView.VirtualMode = true;
      this.colMethod.AspectName = "Method";
      this.colMethod.Text = "Method";
      this.colMethod.Width = 116;
      this.colName.AspectName = "Name";
      this.colName.Text = "Name";
      this.colName.Width = 100;
      this.colValue.AspectName = "Value";
      this.colValue.Text = "Value";
      this.colValue.Width = 200;
      this.colHex.AspectName = "HexValue";
      this.colHex.Text = "Hex";
      this.colType.AspectName = "Type";
      this.colType.Text = "Type";
      this.colType.Width = 100;
      this.colEndAt.AspectName = "EndPosition";
      this.colEndAt.Text = "End Pos";
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = Orientation.Horizontal;
      this.splitContainer1.Panel1.Controls.Add((Control) this.listView);
      this.splitContainer1.Panel2.Controls.Add((Control) this.treeView);
      this.splitContainer1.Panel2.Controls.Add((Control) this.statusStrip1);
      this.splitContainer1.Size = new Size(688, 423);
      this.splitContainer1.SplitterDistance = 229;
      this.splitContainer1.TabIndex = 3;
      this.listView.AllColumns.Add(this.colPos);
      this.listView.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
      this.listView.Columns.AddRange(new ColumnHeader[1]
      {
        (ColumnHeader) this.colPos
      });
      this.listView.Dock = DockStyle.Fill;
      this.listView.Font = new Font("Courier New", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.listView.FullRowSelect = true;
      this.listView.GridLines = true;
      this.listView.Location = new Point(0, 0);
      this.listView.Name = "listView";
      this.listView.OwnerDraw = true;
      this.listView.ShowGroups = false;
      this.listView.Size = new Size(688, 229);
      this.listView.TabIndex = 1;
      this.listView.UseCompatibleStateImageBehavior = false;
      this.listView.View = View.Details;
      this.listView.VirtualMode = true;
      this.listView.CellClick += new EventHandler<CellClickEventArgs>(this.listView_CellClick);
      this.listView.KeyDown += new KeyEventHandler(this.listView_KeyDown);
      this.colPos.AspectName = "Position";
      this.colPos.Groupable = false;
      this.colPos.HeaderFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.colPos.IsEditable = false;
      this.colPos.Searchable = false;
      this.colPos.Sortable = false;
      this.colPos.Text = "Position";
      this.colPos.Width = 95;
      this.statusStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.spacer,
        (ToolStripItem) this.lblPosition
      });
      this.statusStrip1.Location = new Point(0, 168);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(688, 22);
      this.statusStrip1.TabIndex = 3;
      this.statusStrip1.Text = "status";
      this.spacer.Name = "spacer";
      this.spacer.Size = new Size(647, 17);
      this.spacer.Spring = true;
      this.lblPosition.Name = "lblPosition";
      this.lblPosition.Size = new Size(26, 17);
      this.lblPosition.Text = "Pos";
      this.colPosition.AspectName = "Position";
      this.colPosition.DisplayIndex = 0;
      this.colPosition.Text = "Position";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(688, 423);
      this.Controls.Add((Control) this.splitContainer1);
      this.Name = nameof (frmHexEditorView);
      this.Text = "Hex Viewer";
      ((ISupportInitialize) this.treeView).EndInit();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((ISupportInitialize) this.listView).EndInit();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
    }

    internal class HexListNode
    {
      private byte[] bytes;
      private byte[] readable;

      public int pos { get; set; }

      public string Position
      {
        get
        {
          return this.pos.ToString("X8");
        }
      }

      public string GetHex(int i)
      {
        return this.pos + i < this.bytes.Length ? this.bytes[this.pos + i].ToString("X2") : "";
      }

      public void SetHex(int i, string hex)
      {
        if (this.pos + i >= this.bytes.Length)
          return;
        try
        {
          this.bytes[this.pos + i] = Convert.ToByte(hex, 16);
          this.readable[this.pos + i] = this.bytes[i] <= (byte) 31 || this.bytes[i] >= (byte) 127 ? (byte) 46 : this.bytes[i];
        }
        catch
        {
        }
      }

      public string Text
      {
        get
        {
          return Encoding.Default.GetString(this.readable, this.pos, Math.Min(16, this.bytes.Length - this.pos));
        }
      }

      public string Hex00
      {
        get
        {
          return this.GetHex(0);
        }
        set
        {
          this.SetHex(0, value);
        }
      }

      public string Hex01
      {
        get
        {
          return this.GetHex(1);
        }
        set
        {
          this.SetHex(1, value);
        }
      }

      public string Hex02
      {
        get
        {
          return this.GetHex(2);
        }
        set
        {
          this.SetHex(2, value);
        }
      }

      public string Hex03
      {
        get
        {
          return this.GetHex(3);
        }
        set
        {
          this.SetHex(3, value);
        }
      }

      public string Hex04
      {
        get
        {
          return this.GetHex(4);
        }
        set
        {
          this.SetHex(4, value);
        }
      }

      public string Hex05
      {
        get
        {
          return this.GetHex(5);
        }
        set
        {
          this.SetHex(5, value);
        }
      }

      public string Hex06
      {
        get
        {
          return this.GetHex(6);
        }
        set
        {
          this.SetHex(6, value);
        }
      }

      public string Hex07
      {
        get
        {
          return this.GetHex(7);
        }
        set
        {
          this.SetHex(7, value);
        }
      }

      public string Hex08
      {
        get
        {
          return this.GetHex(8);
        }
        set
        {
          this.SetHex(8, value);
        }
      }

      public string Hex09
      {
        get
        {
          return this.GetHex(9);
        }
        set
        {
          this.SetHex(9, value);
        }
      }

      public string Hex0A
      {
        get
        {
          return this.GetHex(10);
        }
        set
        {
          this.SetHex(10, value);
        }
      }

      public string Hex0B
      {
        get
        {
          return this.GetHex(11);
        }
        set
        {
          this.SetHex(11, value);
        }
      }

      public string Hex0C
      {
        get
        {
          return this.GetHex(12);
        }
        set
        {
          this.SetHex(12, value);
        }
      }

      public string Hex0D
      {
        get
        {
          return this.GetHex(13);
        }
        set
        {
          this.SetHex(13, value);
        }
      }

      public string Hex0E
      {
        get
        {
          return this.GetHex(14);
        }
        set
        {
          this.SetHex(14, value);
        }
      }

      public string Hex0F
      {
        get
        {
          return this.GetHex(15);
        }
        set
        {
          this.SetHex(15, value);
        }
      }

      internal HexListNode(byte[] source, byte[] readable, int pos)
      {
        this.bytes = source;
        this.readable = readable;
        this.pos = pos;
      }
    }

    internal class VariableListNode
    {
      public string Name
      {
        get
        {
          if (this.Variable != null && this.Variable.Name != null)
            return this.Variable.Name;
          return this.Parent == null ? "" : this.Parent.Children.IndexOf(this).ToString();
        }
      }

      public string Value
      {
        get
        {
          return this.Variable.ToString();
        }
      }

      public string Type
      {
        get
        {
          return this.Variable.Type;
        }
      }

      public int EndPosition { get; set; }

      public string HexValue { get; set; }

      public int ChildCount
      {
        get
        {
          return this.Children.Count;
        }
      }

      public List<frmHexEditorView.VariableListNode> Children { get; set; }

      public frmHexEditorView.VariableListNode Parent { get; set; }

      public IEditableVariable Variable { get; set; }

      public string Method { get; set; }
    }
  }
}
