// Decompiled with JetBrains decompiler
// Type: W3Edit.frmBundleExplorer
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using W3Edit.Bundles;

namespace W3Edit
{
  public class frmBundleExplorer : Form
  {
    private IContainer components;
    private Label lblFilePath;
    private TextBox txPath;
    private Button btOpen;
    private Button btClose;
    private ImageList treeImages;
    private ListView fileListView;
    private ColumnHeader colFileName;
    private ColumnHeader colFileSize;
    private Panel pathPanel;
    private ColumnHeader colCompressionRatio;
    private ColumnHeader colCompressiontype;
    private ColumnHeader colTimeStamp;

    public BundleTreeNode ActiveNode { get; set; }

    public BundleTreeNode RootNode { get; set; }

    public string[] SelectedPaths
    {
      get
      {
        return this.txPath.Text.Split(';');
      }
    }

    public frmBundleExplorer()
    {
      this.InitializeComponent();
      this.RootNode = MainController.Get().BundleManager.RootNode;
    }

    private void frmBundleExplorer_Load(object sender, EventArgs e)
    {
    }

    public void OpenNode(BundleTreeNode node)
    {
      if (this.ActiveNode == node)
        return;
      this.ActiveNode = node;
      this.UpdatePathPanel();
      this.fileListView.Items.Clear();
      if (node.Parent != null)
      {
        ListView.ListViewItemCollection items = this.fileListView.Items;
        frmBundleExplorer.BundleListItem bundleListItem1 = new frmBundleExplorer.BundleListItem();
        bundleListItem1.Node = node.Parent;
        bundleListItem1.Text = "..";
        bundleListItem1.IsDirectory = true;
        bundleListItem1.ImageKey = "openFolder";
        frmBundleExplorer.BundleListItem bundleListItem2 = bundleListItem1;
        items.Add((ListViewItem) bundleListItem2);
      }
      foreach (KeyValuePair<string, BundleTreeNode> directory in node.Directories)
      {
        ListView.ListViewItemCollection items = this.fileListView.Items;
        frmBundleExplorer.BundleListItem bundleListItem1 = new frmBundleExplorer.BundleListItem();
        bundleListItem1.Node = directory.Value;
        bundleListItem1.Text = directory.Key;
        bundleListItem1.IsDirectory = true;
        bundleListItem1.ImageKey = "openFolder";
        frmBundleExplorer.BundleListItem bundleListItem2 = bundleListItem1;
        items.Add((ListViewItem) bundleListItem2);
      }
      foreach (KeyValuePair<string, List<BundleItem>> file in node.Files)
      {
        BundleItem bundleItem = file.Value[file.Value.Count - 1];
        ListView.ListViewItemCollection items = this.fileListView.Items;
        frmBundleExplorer.BundleListItem bundleListItem1 = new frmBundleExplorer.BundleListItem();
        bundleListItem1.Node = (BundleTreeNode) null;
        bundleListItem1.FullPath = bundleItem.Name;
        bundleListItem1.Text = file.Key;
        bundleListItem1.IsDirectory = false;
        bundleListItem1.ImageKey = "genericFile";
        frmBundleExplorer.BundleListItem bundleListItem2 = bundleListItem1;
        ListViewItem listViewItem = items.Add((ListViewItem) bundleListItem2);
        listViewItem.SubItems.Add(bundleItem.Size.ToString());
        listViewItem.SubItems.Add(string.Format("{0}%", (object) (100 - (int) ((double) bundleItem.ZSize / (double) bundleItem.Size * 100.0))));
        listViewItem.SubItems.Add(bundleItem.CompressionType);
        listViewItem.SubItems.Add(bundleItem.TimeStamp.ToString("X"));
      }
    }

    private void UpdatePathPanel()
    {
      List<BundleTreeNode> bundleTreeNodeList = new List<BundleTreeNode>();
      for (BundleTreeNode bundleTreeNode = this.ActiveNode; bundleTreeNode != null; bundleTreeNode = bundleTreeNode.Parent)
        bundleTreeNodeList.Add(bundleTreeNode);
      this.pathPanel.Controls.Clear();
      int x = 0;
      bundleTreeNodeList.Reverse();
      foreach (BundleTreeNode bundleTreeNode in bundleTreeNodeList)
      {
        BundleTreeNode link = bundleTreeNode;
        Label label = new Label();
        label.Text = link.Name + " >";
        label.Location = new Point(x, -3);
        label.Padding = new Padding(0);
        label.Margin = new Padding(0);
        Size size = TextRenderer.MeasureText(label.Text, label.Font);
        label.Width = size.Width;
        label.Height = 23;
        label.BackColor = Color.Transparent;
        label.MouseLeave += new EventHandler(this.button_MouseLeave);
        label.MouseEnter += new EventHandler(this.button_MouseEnter);
        label.TextAlign = ContentAlignment.MiddleCenter;
        label.Cursor = Cursors.Hand;
        label.Click += (EventHandler) ((sender, e) => this.OpenNode(link));
        this.pathPanel.Controls.Add((Control) label);
        x += label.Width;
      }
    }

    private void button_MouseEnter(object sender, EventArgs e)
    {
      ((Control) sender).BackColor = Color.LightBlue;
    }

    private void button_MouseLeave(object sender, EventArgs e)
    {
      ((Control) sender).BackColor = Color.Transparent;
    }

    private void fileListView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (this.fileListView.SelectedItems.Count <= 0)
        return;
      frmBundleExplorer.BundleListItem selectedItem = (frmBundleExplorer.BundleListItem) this.fileListView.SelectedItems[0];
      if (selectedItem.IsDirectory)
        this.OpenNode(selectedItem.Node);
      else
        this.txPath.Text = selectedItem.FullPath;
    }

    private void fileListView_DoubleClick(object sender, EventArgs e)
    {
    }

    private void fileListView_ItemSelectionChanged(
      object sender,
      ListViewItemSelectionChangedEventArgs e)
    {
      if (this.fileListView.SelectedItems.Count <= 0)
        return;
      List<string> stringList = new List<string>();
      foreach (frmBundleExplorer.BundleListItem selectedItem in this.fileListView.SelectedItems)
      {
        if (!selectedItem.IsDirectory)
          stringList.Add(selectedItem.FullPath);
      }
      this.txPath.Text = string.Join(";", (IEnumerable<string>) stringList);
    }

    private void fileListView_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void pathPanel_Click(object sender, EventArgs e)
    {
      this.pathPanel.Controls.Clear();
      TextBox textBox = new TextBox();
      textBox.Location = new Point(16, 2);
      textBox.Width = this.pathPanel.Width;
      textBox.Height = this.pathPanel.Height;
      textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      textBox.BorderStyle = BorderStyle.None;
      this.pathPanel.Controls.Add((Control) textBox);
      textBox.Focus();
      textBox.LostFocus += new EventHandler(this.textbox_LostFocus);
      textBox.KeyDown += new KeyEventHandler(this.textbox_KeyDown);
      textBox.PreviewKeyDown += new PreviewKeyDownEventHandler(this.textbox_PreviewKeyDown);
      textBox.Margin = new Padding(3);
      textBox.Text = this.ActiveNode.FullPath;
      textBox.SelectAll();
      textBox.AcceptsReturn = true;
    }

    private void textbox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
      TextBox textBox = (TextBox) sender;
      if (e.KeyCode != Keys.Return)
        return;
      this.OpenPath(textBox.Text);
    }

    public void OpenPath(string browsePath)
    {
      BundleTreeNode node = this.RootNode;
      string[] strArray = browsePath.Split('\\');
      bool flag = false;
      for (int index = 0; index < strArray.Length; ++index)
      {
        if (node.Directories.ContainsKey(strArray[index]))
        {
          node = node.Directories[strArray[index]];
          flag = true;
        }
        else if (index == strArray.Length - 1 && (node.Files.ContainsKey(strArray[index]) || strArray[index] == ""))
        {
          flag = true;
        }
        else
        {
          flag = false;
          break;
        }
      }
      if (!flag)
        return;
      this.OpenNode(node);
    }

    private void textbox_LostFocus(object sender, EventArgs e)
    {
      this.UpdatePathPanel();
    }

    private void textbox_KeyDown(object sender, KeyEventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmBundleExplorer));
      this.treeImages = new ImageList(this.components);
      this.lblFilePath = new Label();
      this.txPath = new TextBox();
      this.btOpen = new Button();
      this.btClose = new Button();
      this.fileListView = new ListView();
      this.colFileName = new ColumnHeader();
      this.colFileSize = new ColumnHeader();
      this.colCompressionRatio = new ColumnHeader();
      this.colCompressiontype = new ColumnHeader();
      this.pathPanel = new Panel();
      this.colTimeStamp = new ColumnHeader();
      this.SuspendLayout();
      this.treeImages.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("treeImages.ImageStream");
      this.treeImages.TransparentColor = Color.Transparent;
      this.treeImages.Images.SetKeyName(0, "genericFile");
      this.treeImages.Images.SetKeyName(1, "normalFolder");
      this.treeImages.Images.SetKeyName(2, "openFolder");
      this.lblFilePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblFilePath.AutoSize = true;
      this.lblFilePath.Location = new Point(14, 379);
      this.lblFilePath.Name = "lblFilePath";
      this.lblFilePath.Size = new Size(34, 13);
      this.lblFilePath.TabIndex = 1;
      this.lblFilePath.Text = "File(s)";
      this.txPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txPath.Location = new Point(54, 376);
      this.txPath.Name = "txPath";
      this.txPath.Size = new Size(623, 20);
      this.txPath.TabIndex = 2;
      this.btOpen.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btOpen.DialogResult = DialogResult.OK;
      this.btOpen.Location = new Point(572, 409);
      this.btOpen.Name = "btOpen";
      this.btOpen.Size = new Size(105, 23);
      this.btOpen.TabIndex = 3;
      this.btOpen.Text = "Add to Mod";
      this.btOpen.UseVisualStyleBackColor = true;
      this.btClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btClose.DialogResult = DialogResult.Cancel;
      this.btClose.Location = new Point(12, 409);
      this.btClose.Name = "btClose";
      this.btClose.Size = new Size(75, 23);
      this.btClose.TabIndex = 4;
      this.btClose.Text = "Close";
      this.btClose.UseVisualStyleBackColor = true;
      this.fileListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.fileListView.Columns.AddRange(new ColumnHeader[5]
      {
        this.colFileName,
        this.colFileSize,
        this.colCompressionRatio,
        this.colCompressiontype,
        this.colTimeStamp
      });
      this.fileListView.FullRowSelect = true;
      this.fileListView.HideSelection = false;
      this.fileListView.Location = new Point(12, 38);
      this.fileListView.Name = "fileListView";
      this.fileListView.Size = new Size(665, 332);
      this.fileListView.SmallImageList = this.treeImages;
      this.fileListView.TabIndex = 5;
      this.fileListView.UseCompatibleStateImageBehavior = false;
      this.fileListView.View = View.Details;
      this.fileListView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.fileListView_ItemSelectionChanged);
      this.fileListView.SelectedIndexChanged += new EventHandler(this.fileListView_SelectedIndexChanged);
      this.fileListView.DoubleClick += new EventHandler(this.fileListView_DoubleClick);
      this.fileListView.MouseDoubleClick += new MouseEventHandler(this.fileListView_MouseDoubleClick);
      this.colFileName.Text = "Name";
      this.colFileName.Width = 322;
      this.colFileSize.Text = "Size";
      this.colFileSize.Width = 65;
      this.colCompressionRatio.Text = "Compression Ratio";
      this.colCompressionRatio.Width = 108;
      this.colCompressiontype.Text = "Compression Type";
      this.colCompressiontype.Width = 83;
      this.pathPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.pathPanel.BackColor = SystemColors.Window;
      this.pathPanel.BorderStyle = BorderStyle.FixedSingle;
      this.pathPanel.Cursor = Cursors.IBeam;
      this.pathPanel.Location = new Point(12, 12);
      this.pathPanel.Name = "pathPanel";
      this.pathPanel.Size = new Size(665, 20);
      this.pathPanel.TabIndex = 6;
      this.pathPanel.Click += new EventHandler(this.pathPanel_Click);
      this.colTimeStamp.Text = "TimeStamp";
      this.colTimeStamp.Width = 77;
      this.AcceptButton = (IButtonControl) this.btOpen;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btClose;
      this.ClientSize = new Size(689, 444);
      this.Controls.Add((Control) this.pathPanel);
      this.Controls.Add((Control) this.fileListView);
      this.Controls.Add((Control) this.btClose);
      this.Controls.Add((Control) this.btOpen);
      this.Controls.Add((Control) this.txPath);
      this.Controls.Add((Control) this.lblFilePath);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmBundleExplorer);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Bundle Explorer";
      this.Load += new EventHandler(this.frmBundleExplorer_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public class BundleListItem : ListViewItem
    {
      public bool IsDirectory { get; set; }

      public BundleTreeNode Node { get; set; }

      public string FullPath { get; set; }
    }
  }
}
