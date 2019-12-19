using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using WolvenKit.CR2W;
using WolvenKit.CR2W.Editors;
using WolvenKit.CR2W.Types;

namespace WolvenKit.Controls
{
    public partial class ChunkListPropertyEditor : DevExpress.XtraEditors.XtraUserControl
    {
        //TODO - The entire way the CR2W types and their editors are handled needs to be refactored for the DX Tree List
        //There are a lot of custom controls being used for the various types and I am feeling that it isn't a very nice editing
        //experience to be having to manually edit the types in the tree anyway. I think having separate windows may be a better idea.
        //For now this control will not be accessible within WKDX.
        RepositoryItemTextEdit repoItemTextEdit = new RepositoryItemTextEdit();
        RepositoryItemColorPickEdit repositoryItemColorPickEdit = new RepositoryItemColorPickEdit();
        RepositoryItemComboBox repoItemColItemComboBox = new RepositoryItemComboBox();
        RepositoryItemSpinEdit repoItemSpinEdit = new RepositoryItemSpinEdit();
        RepositoryItemDateEdit repoItemDateEdit = new RepositoryItemDateEdit();
        RepositoryItemCheckEdit repositoryItemCheckEdit = new RepositoryItemCheckEdit();

        //TODO - These button edits show modal dialogs to edit the actual variable; W3Edit and WK used inline controls. 
        //They would have to be recreated as custom repository items in order to be made edit-able inline. I don't feel like making those ATM.
        RepositoryItemButtonEdit repoItemByteArrayEditButton = new RepositoryItemButtonEdit();
        RepositoryItemButtonEdit repoItemPointArrayEditButton = new RepositoryItemButtonEdit();
        RepositoryItemButtonEdit repoItemXmlButtonEdit = new RepositoryItemButtonEdit();
        RepositoryItemButtonEdit idTagButtonEdit = new RepositoryItemButtonEdit();

        public ChunkListPropertyEditor()
        {
            InitializeComponent();
        }

                private CR2WChunk chunk;
        public CR2WChunk Chunk
        {
            get => chunk;
            set
            {
                chunk = value;
                CreatePropertyLayout(chunk);
            }
        }

        public IEditableVariable EditObject { get; set; }
        public object Source { get; set; }

        public void CreatePropertyLayout(IEditableVariable v)
        {
            if (EditObject != v)
            {
                EditObject = v;


                if (v == null)
                {
                    treeListChunkProperties.RootValue = null;
                    return;
                }

                var root = AddListViewItems(v);

                treeListChunkProperties.RootValue = root.Children;
                treeListChunkProperties.Refresh();
                treeListChunkProperties.ExpandAll();
            }
        }


        private VariableListNode AddListViewItems(IEditableVariable v, VariableListNode parent = null,
            int arrayindex = 0)
        {
            var node = new VariableListNode
            {
                Variable = v,
                Children = new List<VariableListNode>(),
                Parent = parent
            };
            var vars = v.GetEditableVariables();
            if (vars != null)
                for (var i = 0; i < vars.Count; i++)
                    node.Children.Add(AddListViewItems(vars[i], node, i));

            return node;
        }

        private void treeListChunkProperties_CustomNodeCellEdit(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            var row = treeListChunkProperties.GetRow(e.Node.Id);
            var variable = (row as VariableListNode)?.Variable;
            if (variable != null)
            {
                if (e.Column == treeListColumnValue)
                { 
                    //TODO - Implement these below...
                    //CByteArray - ByteArrayEditor
                    //Array - No Repo Item
                    //CBytes - ByteArrayEditButton
                    //CColor - ColorPickEdit
                    //CColorShift - ColorPickEdit (uses three different subtypes like luminance, etc.)
                    //CDateTime - DateTimeEdit
                    //CFloat - TextEdit (use spin edit instead???)
                    //CGuid - TextEdit
                    //CHandle - ComboBoxEdit
                    //CLocalizedStrings - TextEdit
                    //CName - Can be ComboBoxEdit or TextEdit (lame)
                    //CPtr - ComboBoxEdit
                    //CSoft - PointArrayEditButton
                    //CString - TextEdit
                    //CStringAnsi - TextEdit
                    //CVariable - No Repo Item
                    //CVariant - Either no editor or specific editor
                    //CVector - No Editor
                    //CXml - XmlButtonEdit
                    //CIdTag - IdTagButtonEdit
                    //CBool - CheckEdit
                    //CDynamicInt, CInt16, CInt32, CInt64, CInt8, CUInt16, CUInt32, CUInt64, CUInt8 - TextEdit (possibly spin edit???)
                    //CR2WChunk - No Repo Item

                    switch (variable.GetType().Name)
                    {
                        default:
                            e.RepositoryItem = repoItemTextEdit;
                            break;
                    }

                }
                else if (e.Column  == treeListColumnName)
                {
                    e.RepositoryItem = repoItemTextEdit;
                }
            }
        }



        //TODO - Replace with Dx Context Menu
        //private void contextMenu_Opening(object sender, CancelEventArgs e)
        //{
        //    var sNodes = treeView.SelectedObjects.Cast<ChunkPropertyViewer.VariableListNode>().Where(item => item?.Variable != null)
        //        .ToList();
        //    if (sNodes.ToArray().Length <= 0)
        //    {
        //        e.Cancel = true;
        //        return;
        //    }

        //    addVariableToolStripMenuItem.Enabled = sNodes.All(x => x.Variable.CanAddVariable(null));
        //    removeVariableToolStripMenuItem.Enabled =
        //        sNodes.All(x => x.Parent != null && x.Parent.Variable.CanRemoveVariable(x.Variable));
        //    pasteToolStripMenuItem.Enabled = CopyController.VariableTargets != null && sNodes.All(x =>
        //                                         x.Variable != null &&
        //                                         CopyController.VariableTargets.Any(z => x.Variable.CanAddVariable(z)));
        //    ptrPropertiesToolStripMenuItem.Visible = sNodes.All(x => x.Variable is CPtr) && sNodes.Count == 1;
        //}

        //public void copyVariable()
        //{
        //    var tocopynodes = (from ChunkPropertyViewer.VariableListNode item in treeView.SelectedObjects
        //                       where item?.Variable != null
        //                       select item.Variable).ToList();
        //    if (tocopynodes.Count > 0) CopyController.VariableTargets = tocopynodes;
        //}

        //public void pasteVariable()
        //{
        //    var node = (ChunkPropertyViewer.VariableListNode)treeView.SelectedObject;
        //    if (CopyController.VariableTargets == null || node?.Variable == null ||
        //        !node.Variable.CanAddVariable(null)) return;

        //    if (CopyController.VariableTargets.All(x => x is CVariable))
        //        foreach (var newvar in from v in CopyController.VariableTargets.Select(x => (CVariable)x)
        //                               let context = new CR2WCopyAction
        //                               {
        //                                   SourceFile = v.cr2w,
        //                                   DestinationFile = node.Variable.CR2WOwner,
        //                                   MaxIterationDepth = 0
        //                               }
        //                               select v.Copy(context))
        //        {
        //            node.Variable.AddVariable(newvar);

        //            var subnode = AddListViewItems(newvar, node);
        //            node.Children.Add(subnode);

        //            treeView.RefreshObject(node);
        //            treeView.RefreshObject(subnode);
        //        }
        //}

        //TODO - Replace with DX Context Menu
        //private void addVariableToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var node = (ChunkPropertyViewer.VariableListNode)treeView.SelectedObject;
        //    if (node?.Variable == null || !node.Variable.CanAddVariable(null)) return;

        //    CVariable newvar = null;

        //    if (node.Variable is CArray)
        //    {
        //        var nodearray = (CArray)node.Variable;
        //        newvar = CR2WTypeManager.Get().GetByName(nodearray.elementtype, string.Empty, Chunk.cr2w, false);
        //        if (newvar == null)
        //            return;
        //    }
        //    else
        //    {
        //        var frm = new frmAddVariable();
        //        if (frm.ShowDialog() != DialogResult.OK) return;

        //        newvar = CR2WTypeManager.Get().GetByName(frm.VariableType, frm.VariableName, Chunk.cr2w, false);
        //        if (newvar == null)
        //            return;

        //        newvar.Name = frm.VariableName;
        //        newvar.Type = frm.VariableType;
        //    }

        //    if (newvar is CHandle)
        //    {
        //        var result = MessageBox.Show("Add as chunk handle? (Yes for chunk handle, No for normal handle)",
        //            "Adding handle.", MessageBoxButtons.YesNoCancel);
        //        if (result == DialogResult.Cancel)
        //            return;

        //        ((CHandle)newvar).ChunkHandle = result == DialogResult.Yes;
        //    }

        //    node.Variable.AddVariable(newvar);

        //    var subnode = AddListViewItems(newvar, node);
        //    node.Children.Add(subnode);

        //    treeView.RefreshObject(node);
        //    treeView.RefreshObject(subnode);
        //}

        //TODO - Replace with DX Context Menu
        //private void removeVariableToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    foreach (ChunkPropertyViewer.VariableListNode node in treeView.SelectedObjects)
        //        if (node?.Parent != null && node.Parent.Variable.CanRemoveVariable(node.Variable))
        //        {
        //            node.Parent.Variable.RemoveVariable(node.Variable);
        //            node.Parent.Children.Remove(node);
        //            try
        //            {
        //                treeView.RefreshObject(node.Parent);
        //            }
        //            catch
        //            {
        //            } //TODO: Do this better, works now but it shouldn't be done like this. :p
        //        }
        //}

        //TODO - Replace with DX Context Menu
        //private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    treeView.ExpandAll();
        //}

        //private void expandAllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var node = (ChunkPropertyViewer.VariableListNode)treeView.SelectedObject;
        //    if (node != null)
        //    {
        //        treeView.Expand(node);
        //        foreach (var c in node.Children) treeView.Expand(c);
        //    }
        //}

        //TODO - Replace with DX Context menu
        //private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    treeView.CollapseAll();
        //}

        //private void collapseAllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var node = (ChunkPropertyViewer.VariableListNode)treeView.SelectedObject;
        //    if (node != null)
        //        foreach (var c in node.Children)
        //            treeView.Collapse(c);
        //}

        //TODO - Replace with Dx Context Menu
        //private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    copyVariable();
        //}

        //private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    pasteVariable();
        //}

        //TODO - This may not be necessary 
        //private void treeView_CellClick(object sender, CellClickEventArgs e)
        //{
        //    if (e.Column == null || e.Item == null)
        //        return;

        //    if (e.ClickCount == 2 && e.Column.AspectName == "Name")
        //        treeView.StartCellEdit(e.Item, 0);
        //    else if (e.Column.AspectName == "Value") treeView.StartCellEdit(e.Item, 1);
        //}

        //TODO - Replace with DX Context Menu
        //private void ptrPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var node = (ChunkPropertyViewer.VariableListNode)treeView.SelectedObject;
        //    if ((node?.Variable as CPtr)?.PtrTarget == null)
        //        return;

        //    Chunk = ((CPtr)node.Variable).PtrTarget;
        //}

        //private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var node = (ChunkPropertyViewer.VariableListNode)treeView.SelectedObject;
        //    if (node?.Parent == null || !node.Parent.Variable.CanRemoveVariable(node.Variable))
        //        return;
        //    if (node.Value != null)
        //    {
        //        if (node.Value == string.Empty)
        //            Clipboard.SetText(node.Type + ":??");
        //        else
        //            Clipboard.SetText(node.Value);
        //    }
        //}

        private void treeView_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            MainController.Get().ProjectUnsaved = true;
        }



    }
}
