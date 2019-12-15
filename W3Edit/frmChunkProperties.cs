// Decompiled with JetBrains decompiler
// Type: W3Edit.frmChunkProperties
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using W3Edit.CR2W;
using W3Edit.CR2W.Editors;
using W3Edit.CR2W.Types;
using WeifenLuo.WinFormsUI.Docking;

namespace W3Edit
{
  public class frmChunkProperties : DockContent
  {
    private CR2WChunk chunk;
    private IContainer components;
    private TreeListView treeView;
    private OLVColumn colName;
    private OLVColumn colValue;
    private OLVColumn colType;
    private ContextMenuStrip contextMenu;
    private ToolStripMenuItem addVariableToolStripMenuItem;
    private ToolStripMenuItem removeVariableToolStripMenuItem;
    private ToolStripMenuItem expandAllToolStripMenuItem;
    private ToolStripMenuItem expandAllChildrenToolStripMenuItem;
    private ToolStripMenuItem collapseAllToolStripMenuItem;
    private ToolStripMenuItem collapseAllChildrenToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripSeparator toolStripMenuItem2;
    private ToolStripMenuItem copyToolStripMenuItem;
    private ToolStripMenuItem pasteToolStripMenuItem;
    private ToolStripSeparator toolSplitPtr;
    private ToolStripMenuItem ptrPropertiesToolStripMenuItem;
    private ToolStripMenuItem copyTextToolStripMenuItem;

    public frmChunkProperties()
    {
      this.InitializeComponent();
      this.treeView.CanExpandGetter = (TreeListView.CanExpandGetterDelegate) (x => ((frmChunkProperties.VariableListNode) x).ChildCount > 0);
      this.treeView.ChildrenGetter = (TreeListView.ChildrenGetterDelegate) (x => (IEnumerable) ((frmChunkProperties.VariableListNode) x).Children);
    }

    public CR2WChunk Chunk
    {
      get
      {
        return this.chunk;
      }
      set
      {
        this.chunk = value;
        this.CreatePropertyLayout((IEditableVariable) this.chunk);
      }
    }

    public IEditableVariable EditObject { get; set; }

    public void CreatePropertyLayout(IEditableVariable v)
    {
      if (this.EditObject == v)
        return;
      this.EditObject = v;
      if (v == null)
      {
        this.treeView.Roots = (IEnumerable) null;
      }
      else
      {
        frmChunkProperties.VariableListNode variableListNode = this.AddListViewItems(v, (frmChunkProperties.VariableListNode) null, 0);
        this.treeView.Roots = (IEnumerable) variableListNode.Children;
        this.treeView.RefreshObjects((IList) variableListNode.Children);
        int depth = 0;
        while (this.ExpandOneLevel(depth, variableListNode.Children, 0))
          ++depth;
      }
    }

    private bool ExpandOneLevel(
      int depth,
      List<frmChunkProperties.VariableListNode> children,
      int currentLevel = 0)
    {
      bool flag = false;
      foreach (frmChunkProperties.VariableListNode child in children)
      {
        if (currentLevel == depth)
        {
          this.treeView.Expand((object) child);
          if ((Win32.GetWindowLong(this.treeView.Handle, -16) & 2097152) == 2097152)
          {
            this.treeView.Collapse((object) child);
            return false;
          }
          flag = true;
        }
        else if (this.ExpandOneLevel(depth, child.Children, currentLevel + 1))
          flag = true;
      }
      return flag;
    }

    private frmChunkProperties.VariableListNode AddListViewItems(
      IEditableVariable v,
      frmChunkProperties.VariableListNode parent = null,
      int arrayindex = 0)
    {
      frmChunkProperties.VariableListNode parent1 = new frmChunkProperties.VariableListNode();
      parent1.Variable = v;
      parent1.Children = new List<frmChunkProperties.VariableListNode>();
      parent1.Parent = parent;
      List<IEditableVariable> editableVariables = v.GetEditableVariables();
      if (editableVariables != null)
      {
        for (int arrayindex1 = 0; arrayindex1 < editableVariables.Count; ++arrayindex1)
          parent1.Children.Add(this.AddListViewItems(editableVariables[arrayindex1], parent1, arrayindex1));
      }
      return parent1;
    }

    private void treeView_CellEditStarting(object sender, CellEditEventArgs e)
    {
      if (e.Column.AspectName == "Value")
      {
        e.Control = ((frmChunkProperties.VariableListNode) e.RowObject).Variable.GetEditor();
        if (e.Control != null)
        {
          e.Control.Location = new Point(e.CellBounds.Location.X, e.CellBounds.Location.Y - 1);
          e.Control.Width = e.CellBounds.Width;
        }
        e.Cancel = e.Control == null;
      }
      else
      {
        if (e.Column.AspectName == "Name")
          return;
        e.Cancel = true;
      }
    }

    private void frmChunkProperties_Resize(object sender, EventArgs e)
    {
    }

    private void frmChunkProperties_Shown(object sender, EventArgs e)
    {
    }

    private void contextMenu_Opening(object sender, CancelEventArgs e)
    {
      frmChunkProperties.VariableListNode selectedObject = (frmChunkProperties.VariableListNode) this.treeView.SelectedObject;
      if (selectedObject == null)
      {
        e.Cancel = true;
      }
      else
      {
        this.addVariableToolStripMenuItem.Enabled = selectedObject.Variable.CanAddVariable((IEditableVariable) null);
        this.removeVariableToolStripMenuItem.Enabled = selectedObject.Parent != null && selectedObject.Parent.Variable.CanRemoveVariable(selectedObject.Variable);
        this.pasteToolStripMenuItem.Enabled = CopyController.VariableTarget != null && selectedObject.Variable != null && selectedObject.Variable.CanAddVariable(CopyController.VariableTarget);
        this.ptrPropertiesToolStripMenuItem.Visible = selectedObject.Variable is CPtr;
      }
    }

    private void copyVariable()
    {
      frmChunkProperties.VariableListNode selectedObject = (frmChunkProperties.VariableListNode) this.treeView.SelectedObject;
      if (selectedObject == null || selectedObject.Variable == null)
        return;
      CopyController.VariableTarget = selectedObject.Variable;
    }

    private void pasteVariable()
    {
      frmChunkProperties.VariableListNode selectedObject = (frmChunkProperties.VariableListNode) this.treeView.SelectedObject;
      if (CopyController.VariableTarget == null || selectedObject == null || (selectedObject.Variable == null || !selectedObject.Variable.CanAddVariable((IEditableVariable) null)) || !(CopyController.VariableTarget is CVariable))
        return;
      CVariable variableTarget = (CVariable) CopyController.VariableTarget;
      CR2WCopyAction context = new CR2WCopyAction()
      {
        SourceFile = variableTarget.cr2w,
        DestinationFile = selectedObject.Variable.CR2WOwner,
        MaxIterationDepth = 0
      };
      CVariable var = variableTarget.Copy(context);
      selectedObject.Variable.AddVariable(var);
      frmChunkProperties.VariableListNode variableListNode = this.AddListViewItems((IEditableVariable) var, selectedObject, 0);
      selectedObject.Children.Add(variableListNode);
      this.treeView.RefreshObject((object) selectedObject);
      this.treeView.RefreshObject((object) variableListNode);
    }

    private void addVariableToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmChunkProperties.VariableListNode selectedObject = (frmChunkProperties.VariableListNode) this.treeView.SelectedObject;
      if (selectedObject == null || selectedObject.Variable == null || !selectedObject.Variable.CanAddVariable((IEditableVariable) null))
        return;
      CVariable byName;
      if (selectedObject.Variable is CArray)
      {
        byName = CR2WTypeManager.Get().GetByName(((CArray) selectedObject.Variable).elementtype, "", this.Chunk.cr2w, false);
        if (byName == null)
          return;
      }
      else
      {
        frmAddVariable frmAddVariable = new frmAddVariable();
        if (frmAddVariable.ShowDialog() != DialogResult.OK)
          return;
        byName = CR2WTypeManager.Get().GetByName(frmAddVariable.VariableType, frmAddVariable.VariableName, this.Chunk.cr2w, false);
        if (byName == null)
          return;
        byName.Name = frmAddVariable.VariableName;
        byName.Type = frmAddVariable.VariableType;
      }
      if (byName is CHandle)
      {
        DialogResult dialogResult = MessageBox.Show("Add as chunk handle? (Yes for chunk handle, No for normal handle)", "Adding handle.", MessageBoxButtons.YesNoCancel);
        if (dialogResult == DialogResult.Cancel)
          return;
        ((CHandle) byName).ChunkHandle = dialogResult == DialogResult.Yes;
      }
      selectedObject.Variable.AddVariable(byName);
      frmChunkProperties.VariableListNode variableListNode = this.AddListViewItems((IEditableVariable) byName, selectedObject, 0);
      selectedObject.Children.Add(variableListNode);
      this.treeView.RefreshObject((object) selectedObject);
      this.treeView.RefreshObject((object) variableListNode);
    }

    private void removeVariableToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmChunkProperties.VariableListNode selectedObject = (frmChunkProperties.VariableListNode) this.treeView.SelectedObject;
      if (selectedObject == null || selectedObject.Parent == null || !selectedObject.Parent.Variable.CanRemoveVariable(selectedObject.Variable))
        return;
      selectedObject.Parent.Variable.RemoveVariable(selectedObject.Variable);
      selectedObject.Parent.Children.Remove(selectedObject);
      this.treeView.RefreshObject((object) selectedObject.Parent);
    }

    public object Source { get; set; }

    private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.treeView.ExpandAll();
    }

    private void expandAllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmChunkProperties.VariableListNode selectedObject = (frmChunkProperties.VariableListNode) this.treeView.SelectedObject;
      if (selectedObject == null)
        return;
      this.treeView.Expand((object) selectedObject);
      foreach (object child in selectedObject.Children)
        this.treeView.Expand(child);
    }

    private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.treeView.CollapseAll();
    }

    private void collapseAllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmChunkProperties.VariableListNode selectedObject = (frmChunkProperties.VariableListNode) this.treeView.SelectedObject;
      if (selectedObject == null)
        return;
      foreach (object child in selectedObject.Children)
        this.treeView.Collapse(child);
    }

    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.copyVariable();
    }

    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.pasteVariable();
    }

    private void editNameToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void treeView_CellClick(object sender, CellClickEventArgs e)
    {
      if (e.Column == null || e.Item == null)
        return;
      if (e.ClickCount == 2 && e.Column.AspectName == "Name")
      {
        this.treeView.StartCellEdit(e.Item, 0);
      }
      else
      {
        if (!(e.Column.AspectName == "Value"))
          return;
        this.treeView.StartCellEdit(e.Item, 1);
      }
    }

    private void ptrPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmChunkProperties.VariableListNode selectedObject = (frmChunkProperties.VariableListNode) this.treeView.SelectedObject;
      if (selectedObject == null || !(selectedObject.Variable is CPtr) || ((CPtr) selectedObject.Variable).PtrTarget == null)
        return;
      this.Chunk = ((CPtr) selectedObject.Variable).PtrTarget;
    }

    private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmChunkProperties.VariableListNode selectedObject = (frmChunkProperties.VariableListNode) this.treeView.SelectedObject;
      if (selectedObject == null || selectedObject.Parent == null || !selectedObject.Parent.Variable.CanRemoveVariable(selectedObject.Variable))
        return;
      Clipboard.SetText(selectedObject.Value);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmChunkProperties));
      this.treeView = new TreeListView();
      this.colName = new OLVColumn();
      this.colValue = new OLVColumn();
      this.colType = new OLVColumn();
      this.contextMenu = new ContextMenuStrip(this.components);
      this.expandAllToolStripMenuItem = new ToolStripMenuItem();
      this.expandAllChildrenToolStripMenuItem = new ToolStripMenuItem();
      this.collapseAllToolStripMenuItem = new ToolStripMenuItem();
      this.collapseAllChildrenToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem1 = new ToolStripSeparator();
      this.addVariableToolStripMenuItem = new ToolStripMenuItem();
      this.removeVariableToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem2 = new ToolStripSeparator();
      this.copyToolStripMenuItem = new ToolStripMenuItem();
      this.pasteToolStripMenuItem = new ToolStripMenuItem();
      this.toolSplitPtr = new ToolStripSeparator();
      this.ptrPropertiesToolStripMenuItem = new ToolStripMenuItem();
      this.copyTextToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.treeView).BeginInit();
      this.contextMenu.SuspendLayout();
      this.SuspendLayout();
      this.treeView.AllColumns.Add(this.colName);
      this.treeView.AllColumns.Add(this.colValue);
      this.treeView.AllColumns.Add(this.colType);
      this.treeView.AlternateRowBackColor = Color.LightCyan;
      this.treeView.Columns.AddRange(new ColumnHeader[3]
      {
        (ColumnHeader) this.colName,
        (ColumnHeader) this.colValue,
        (ColumnHeader) this.colType
      });
      this.treeView.ContextMenuStrip = this.contextMenu;
      this.treeView.Dock = DockStyle.Fill;
      this.treeView.FullRowSelect = true;
      this.treeView.Location = new Point(0, 0);
      this.treeView.Name = "treeView";
      this.treeView.OwnerDraw = true;
      this.treeView.ShowGroups = false;
      this.treeView.Size = new Size(813, 493);
      this.treeView.TabIndex = 1;
      this.treeView.UseAlternatingBackColors = true;
      this.treeView.UseCompatibleStateImageBehavior = false;
      this.treeView.View = View.Details;
      this.treeView.VirtualMode = true;
      this.treeView.CellEditStarting += new CellEditEventHandler(this.treeView_CellEditStarting);
      this.treeView.CellClick += new EventHandler<CellClickEventArgs>(this.treeView_CellClick);
      this.colName.AspectName = "Name";
      this.colName.Text = "Name";
      this.colName.Width = 300;
      this.colValue.AspectName = "Value";
      this.colValue.Text = "Value";
      this.colValue.Width = 404;
      this.colType.AspectName = "Type";
      this.colType.Text = "Type";
      this.colType.Width = 100;
      this.contextMenu.Items.AddRange(new ToolStripItem[13]
      {
        (ToolStripItem) this.expandAllToolStripMenuItem,
        (ToolStripItem) this.expandAllChildrenToolStripMenuItem,
        (ToolStripItem) this.collapseAllToolStripMenuItem,
        (ToolStripItem) this.collapseAllChildrenToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem1,
        (ToolStripItem) this.addVariableToolStripMenuItem,
        (ToolStripItem) this.removeVariableToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem2,
        (ToolStripItem) this.copyToolStripMenuItem,
        (ToolStripItem) this.pasteToolStripMenuItem,
        (ToolStripItem) this.copyTextToolStripMenuItem,
        (ToolStripItem) this.toolSplitPtr,
        (ToolStripItem) this.ptrPropertiesToolStripMenuItem
      });
      this.contextMenu.Name = "contextMenu";
      this.contextMenu.Size = new Size(185, 264);
      this.contextMenu.Opening += new CancelEventHandler(this.contextMenu_Opening);
      this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
      this.expandAllToolStripMenuItem.Size = new Size(184, 22);
      this.expandAllToolStripMenuItem.Text = "Expand All";
      this.expandAllToolStripMenuItem.Click += new EventHandler(this.expandAllToolStripMenuItem_Click);
      this.expandAllChildrenToolStripMenuItem.Name = "expandAllChildrenToolStripMenuItem";
      this.expandAllChildrenToolStripMenuItem.Size = new Size(184, 22);
      this.expandAllChildrenToolStripMenuItem.Text = "Expand All Children";
      this.expandAllChildrenToolStripMenuItem.Click += new EventHandler(this.expandAllChildrenToolStripMenuItem_Click);
      this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
      this.collapseAllToolStripMenuItem.Size = new Size(184, 22);
      this.collapseAllToolStripMenuItem.Text = "Collapse All";
      this.collapseAllToolStripMenuItem.Click += new EventHandler(this.collapseAllToolStripMenuItem_Click);
      this.collapseAllChildrenToolStripMenuItem.Name = "collapseAllChildrenToolStripMenuItem";
      this.collapseAllChildrenToolStripMenuItem.Size = new Size(184, 22);
      this.collapseAllChildrenToolStripMenuItem.Text = "Collapse All Children";
      this.collapseAllChildrenToolStripMenuItem.Click += new EventHandler(this.collapseAllChildrenToolStripMenuItem_Click);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(181, 6);
      this.addVariableToolStripMenuItem.Name = "addVariableToolStripMenuItem";
      this.addVariableToolStripMenuItem.Size = new Size(184, 22);
      this.addVariableToolStripMenuItem.Text = "Add Variable";
      this.addVariableToolStripMenuItem.Click += new EventHandler(this.addVariableToolStripMenuItem_Click);
      this.removeVariableToolStripMenuItem.Name = "removeVariableToolStripMenuItem";
      this.removeVariableToolStripMenuItem.Size = new Size(184, 22);
      this.removeVariableToolStripMenuItem.Text = "Remove Variable";
      this.removeVariableToolStripMenuItem.Click += new EventHandler(this.removeVariableToolStripMenuItem_Click);
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new Size(181, 6);
      this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      this.copyToolStripMenuItem.Size = new Size(184, 22);
      this.copyToolStripMenuItem.Text = "Copy Variable";
      this.copyToolStripMenuItem.Click += new EventHandler(this.copyToolStripMenuItem_Click);
      this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
      this.pasteToolStripMenuItem.Size = new Size(184, 22);
      this.pasteToolStripMenuItem.Text = "Paste Variable";
      this.pasteToolStripMenuItem.Click += new EventHandler(this.pasteToolStripMenuItem_Click);
      this.toolSplitPtr.Name = "toolSplitPtr";
      this.toolSplitPtr.Size = new Size(181, 6);
      this.ptrPropertiesToolStripMenuItem.Name = "ptrPropertiesToolStripMenuItem";
      this.ptrPropertiesToolStripMenuItem.Size = new Size(184, 22);
      this.ptrPropertiesToolStripMenuItem.Text = "Ptr Properties";
      this.ptrPropertiesToolStripMenuItem.Click += new EventHandler(this.ptrPropertiesToolStripMenuItem_Click);
      this.copyTextToolStripMenuItem.Name = "copyTextToolStripMenuItem";
      this.copyTextToolStripMenuItem.Size = new Size(184, 22);
      this.copyTextToolStripMenuItem.Text = "Copy Text";
      this.copyTextToolStripMenuItem.Click += new EventHandler(this.copyTextToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(813, 493);
      this.CloseButton = false;
      this.CloseButtonVisible = false;
      this.Controls.Add((Control) this.treeView);
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmChunkProperties);
      this.Text = "Properties";
      this.Shown += new EventHandler(this.frmChunkProperties_Shown);
      this.Resize += new EventHandler(this.frmChunkProperties_Resize);
      ((ISupportInitialize) this.treeView).EndInit();
      this.contextMenu.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    internal class VariableListNode
    {
      public string Name
      {
        get
        {
          if (this.Variable.Name != null)
            return this.Variable.Name;
          return this.Parent == null ? "" : this.Parent.Children.IndexOf(this).ToString();
        }
        set
        {
          if (this.Variable.Name == null)
            return;
          this.Variable.Name = value;
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

      public int ChildCount
      {
        get
        {
          return this.Children.Count;
        }
      }

      public List<frmChunkProperties.VariableListNode> Children { get; set; }

      public frmChunkProperties.VariableListNode Parent { get; set; }

      public IEditableVariable Variable { get; set; }
    }
  }
}
