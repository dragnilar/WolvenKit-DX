// Decompiled with JetBrains decompiler
// Type: W3Edit.frmModExplorer
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using W3Edit.Mod;
using WeifenLuo.WinFormsUI.Docking;

namespace W3Edit
{
  public class frmModExplorer : DockContent
  {
    private IContainer components;
    private TreeView modFileList;
    private ImageList treeImages;
    private ContextMenuStrip contextMenu;
    private ToolStripMenuItem removeFileToolStripMenuItem;
    private ToolStripMenuItem addFileToolStripMenuItem;
    private ToolStripMenuItem renameToolStripMenuItem;

    public W3Mod ActiveMod
    {
      get
      {
        return ModManager.Get().ActiveMod;
      }
      set
      {
        ModManager.Get().ActiveMod = value;
      }
    }

    public event EventHandler<RequestFileArgs> RequestFileOpen;

    public event EventHandler<RequestFileArgs> RequestFileDelete;

    public event EventHandler<RequestFileArgs> RequestFileAdd;

    public event EventHandler<RequestFileArgs> RequestFileRename;

    public frmModExplorer()
    {
      this.InitializeComponent();
      this.UpdateModFileList(false);
    }

    public bool DeleteNode(string fullpath)
    {
      string[] strArray = fullpath.Split('\\');
      TreeNodeCollection nodes = this.modFileList.Nodes;
      for (int index = 0; index < strArray.Length && nodes.ContainsKey(strArray[index]); ++index)
      {
        TreeNode treeNode = nodes[strArray[index]];
        nodes = treeNode.Nodes;
        if (index == strArray.Length - 1)
        {
          treeNode.Remove();
          return true;
        }
      }
      return false;
    }

    public void UpdateModFileList(bool clear = false)
    {
      if (clear)
        this.modFileList.Nodes.Clear();
      if (this.ActiveMod == null)
        return;
      foreach (string file in this.ActiveMod.Files)
      {
        TreeNodeCollection nodes = this.modFileList.Nodes;
        string[] strArray = file.Split('\\');
        for (int index = 0; index < strArray.Length; ++index)
        {
          if (!nodes.ContainsKey(strArray[index]))
          {
            TreeNode treeNode = nodes.Add(strArray[index], strArray[index]);
            if (index == strArray.Length - 1)
            {
              treeNode.ImageKey = "genericFile";
              treeNode.SelectedImageKey = "genericFile";
            }
            else
            {
              treeNode.ImageKey = "openFolder";
              treeNode.SelectedImageKey = "openFolder";
            }
            if (treeNode.Parent != null)
              treeNode.Parent.Expand();
            nodes = treeNode.Nodes;
          }
          else
            nodes = nodes[strArray[index]].Nodes;
        }
      }
    }

    private void modFileList_DoubleClick(object sender, EventArgs e)
    {
    }

    private void modFileList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      if (this.RequestFileOpen == null)
        return;
      this.RequestFileOpen((object) this, new RequestFileArgs()
      {
        File = e.Node.FullPath
      });
    }

    private void removeFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.modFileList.SelectedNode == null || this.RequestFileDelete == null)
        return;
      this.RequestFileDelete((object) this, new RequestFileArgs()
      {
        File = this.modFileList.SelectedNode.FullPath
      });
    }

    private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.RequestFileAdd((object) this, new RequestFileArgs()
      {
        File = this.modFileList.SelectedNode == null ? "" : this.modFileList.SelectedNode.FullPath
      });
    }

    private void modFileList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.modFileList.SelectedNode = e.Node;
      this.contextMenu.Show((Control) this.modFileList, e.Location);
    }

    private void renameToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.modFileList.SelectedNode == null || this.RequestFileRename == null)
        return;
      this.RequestFileRename((object) this, new RequestFileArgs()
      {
        File = this.modFileList.SelectedNode.FullPath
      });
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmModExplorer));
      this.modFileList = new TreeView();
      this.treeImages = new ImageList(this.components);
      this.contextMenu = new ContextMenuStrip(this.components);
      this.addFileToolStripMenuItem = new ToolStripMenuItem();
      this.removeFileToolStripMenuItem = new ToolStripMenuItem();
      this.renameToolStripMenuItem = new ToolStripMenuItem();
      this.contextMenu.SuspendLayout();
      this.SuspendLayout();
      this.modFileList.BorderStyle = BorderStyle.None;
      this.modFileList.Dock = DockStyle.Fill;
      this.modFileList.ImageIndex = 0;
      this.modFileList.ImageList = this.treeImages;
      this.modFileList.Location = new Point(0, 0);
      this.modFileList.Name = "modFileList";
      this.modFileList.SelectedImageIndex = 0;
      this.modFileList.Size = new Size(484, 405);
      this.modFileList.TabIndex = 0;
      this.modFileList.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.modFileList_NodeMouseClick);
      this.modFileList.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(this.modFileList_NodeMouseDoubleClick);
      this.modFileList.DoubleClick += new EventHandler(this.modFileList_DoubleClick);
      this.treeImages.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("treeImages.ImageStream");
      this.treeImages.TransparentColor = Color.Transparent;
      this.treeImages.Images.SetKeyName(0, "genericFile");
      this.treeImages.Images.SetKeyName(1, "normalFolder");
      this.treeImages.Images.SetKeyName(2, "openFolder");
      this.contextMenu.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.addFileToolStripMenuItem,
        (ToolStripItem) this.removeFileToolStripMenuItem,
        (ToolStripItem) this.renameToolStripMenuItem
      });
      this.contextMenu.Name = "contextMenu";
      this.contextMenu.Size = new Size(153, 92);
      this.addFileToolStripMenuItem.Image = (Image) W3Edit.Properties.Resources.AddNodefromFile_354;
      this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
      this.addFileToolStripMenuItem.Size = new Size(152, 22);
      this.addFileToolStripMenuItem.Text = "Add File";
      this.addFileToolStripMenuItem.Click += new EventHandler(this.addFileToolStripMenuItem_Click);
      this.removeFileToolStripMenuItem.Name = "removeFileToolStripMenuItem";
      this.removeFileToolStripMenuItem.Size = new Size(152, 22);
      this.removeFileToolStripMenuItem.Text = "Delete";
      this.removeFileToolStripMenuItem.Click += new EventHandler(this.removeFileToolStripMenuItem_Click);
      this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
      this.renameToolStripMenuItem.Size = new Size(152, 22);
      this.renameToolStripMenuItem.Text = "Rename";
      this.renameToolStripMenuItem.Click += new EventHandler(this.renameToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(484, 405);
      this.Controls.Add((Control) this.modFileList);
      this.DockAreas = DockAreas.Float | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.DockBottom;
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmModExplorer);
      this.Text = "Mod Explorer";
      this.contextMenu.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
