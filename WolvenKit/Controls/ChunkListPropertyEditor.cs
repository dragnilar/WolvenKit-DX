using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BrightIdeasSoftware;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using W3SavegameEditor.Core.Savegame.Values;
using W3SavegameEditor.Core.Savegame.Variables;
using WolvenKit.CR2W;
using WolvenKit.CR2W.Editors;
using WolvenKit.CR2W.Types;
using WolvenKit.Forms;
using WolvenKit.Models;

namespace WolvenKit.Controls
{
    public partial class ChunkListPropertyEditor : XtraUserControl
    {
        private CR2WChunk chunk;

        //TODO - These button edits show modal dialogs to edit the actual variable; W3Edit and WK used inline controls. 
        //They would have to be recreated as custom repository items in order to be made edit-able inline. I don't feel like making those ATM.
        private readonly RepositoryItemButtonEdit repoItemByteArrayEditButton = new RepositoryItemButtonEdit();
        private readonly RepositoryItemComboBox repoItemComboBoxEdit = new RepositoryItemComboBox();
        private readonly RepositoryItemDateEdit repoItemDateEdit = new RepositoryItemDateEdit();
        private readonly RepositoryItemButtonEdit repoItemIdTagButtonEdit = new RepositoryItemButtonEdit();
        private readonly RepositoryItemButtonEdit repoItemPointArrayEditButton = new RepositoryItemButtonEdit();

        private readonly RepositoryItemSpinEdit repoItemSpinEdit = new RepositoryItemSpinEdit();

        //TODO - The entire way the CR2W types and their editors are handled needs to be refactored for the DX Tree List
        //There are a lot of custom controls being used for the various types and I am feeling that it isn't a very nice editing
        //experience to be having to manually edit the types in the tree anyway. I think having separate windows may be a better idea.
        //For now this control will not be accessible within WKDX.
        private readonly RepositoryItemTextEdit repoItemTextEdit = new RepositoryItemTextEdit();
        private readonly RepositoryItemButtonEdit repoItemXmlButtonEdit = new RepositoryItemButtonEdit();
        private readonly RepositoryItemCheckEdit repositoryItemCheckEdit = new RepositoryItemCheckEdit();
        private readonly RepositoryItemColorPickEdit repositoryItemColorPickEdit = new RepositoryItemColorPickEdit();

        public ChunkListPropertyEditor()
        {
            InitializeComponent();
            repoItemByteArrayEditButton.ButtonClick += RepoItemByteArrayEditButtonOnClick;
        }

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

        private void RepoItemByteArrayEditButtonOnClick(object sender, ButtonPressedEventArgs  e)
        {
            var data = treeListChunkProperties.GetFocusedRow() as VariableListNode;
            if (data == null) return;
            var byteArrayDialog = new ByteArrayDialogView {StartPosition = FormStartPosition.CenterScreen, Variable = data.Variable.GetValue() as CByteArray };
            byteArrayDialog.ShowDialog();
            byteArrayDialog.Dispose();
        }

        public void CreatePropertyLayout(IEditableVariable variable)
        {
            if (EditObject == variable) return;
            EditObject = variable;
            if (variable == null)
                return;
            treeListChunkProperties.DataSource = BuildTreeListItems(variable);
        }


        private VariableListNode BuildTreeListItems(IEditableVariable variable, TreeListNode parent = null, VariableListNode actualParent = null)
        {
            var node = new VariableListNode
            {
                Variable = variable,
                Children = new List<VariableListNode>()
            };
            var treeNode = treeListChunkProperties.AppendNode(node, parent, actualParent);
            try
            {
                var editableVariables = variable.GetEditableVariables();
                if (editableVariables == null) return node;
                foreach (var editableVariable in editableVariables)
                    node.Children.Add(BuildTreeListItems(editableVariable, treeNode, node));

                return node;
            }

            catch (Exception e)
            {
                MainController.Get().QueueLog(
                    "Error loading nodes for the chunk list property editor.\nThe chunk list property editor may not be fully initialized." +
                    $"\n {e}", OutputView.Logtype.Error);
                return node;
            }
        }

        private void treeListChunkProperties_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            //TODO - Do we need this?
        }


        private void treeView_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            MainController.Get().ProjectUnsaved = true;
        }

        private void treeListChunkProperties_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            var row = treeListChunkProperties.GetRow(e.Node.Id);
            var variable = (row as VariableListNode)?.Variable;
            if (variable != null)
            {
                if (e.Column == treeListColumnValue)
                    //TODO - Implement these below...
                    //CColorShift - ColorPickEdit (uses three different subtypes like luminance, etc.)
                    //CName - Can be ComboBoxEdit or TextEdit (lame)
                    //CVariant - Either no editor or specific editor

                    switch (variable.GetType().Name)
                    {
                        case nameof(CDateTime):
                            e.RepositoryItem = repoItemDateEdit;
                            break;
                        case nameof(CByteArray):
                        case nameof(CBytes):
                            e.RepositoryItem = repoItemByteArrayEditButton;
                            break;
                        case nameof(CArray):
                        case nameof(CR2WChunk):
                        case nameof(CVector):
                        case nameof(CVariable):
                            e.RepositoryItem = null;
                            break;
                        case nameof(CXml):
                            e.RepositoryItem = repoItemXmlButtonEdit;
                            break;
                        case nameof(IdTag):
                            e.RepositoryItem = repoItemIdTagButtonEdit;
                            break;
                        case nameof(CPtr):
                        case nameof(CHandle):
                            e.RepositoryItem = repoItemComboBoxEdit;
                            break;
                        case nameof(CSoft):
                            e.RepositoryItem = repoItemPointArrayEditButton;
                            break;
                        case nameof(CDynamicInt):
                        case nameof(CInt16):
                        case nameof(CInt32):
                        case nameof(CInt64):
                        case nameof(CInt8):
                        case nameof(CUInt8):
                        case nameof(CUInt16):
                        case nameof(CUInt32):
                        case nameof(CUInt64):
                        case nameof(CFloat):
                            e.RepositoryItem = repoItemSpinEdit;
                            break;
                        case nameof(CColor):
                            e.RepositoryItem = repositoryItemColorPickEdit;
                            break;
                        case nameof(CBool):
                            e.RepositoryItem = repositoryItemCheckEdit;
                            break;
                        default:
                            e.RepositoryItem = repoItemTextEdit;
                            break;
                    }
                else if (e.Column == treeListColumnName) e.RepositoryItem = repoItemTextEdit;
            }
        }

        // This event is generated by Data Source Configuration Wizard
        void unboundSource1_ValueNeeded(object sender, DevExpress.Data.UnboundSourceValueNeededEventArgs e)
        {

            // Handle this event to obtain data from your data source
            // e.Value = something /* TODO: Assign the real data here.*/
        }

        // This event is generated by Data Source Configuration Wizard
        void unboundSource1_ValuePushed(object sender, DevExpress.Data.UnboundSourceValuePushedEventArgs e)
        {

            // Handle this event to save modified data back to your data source
            // something = e.Value; /* TODO: Propagate the value into the storage.*/
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
    }
}