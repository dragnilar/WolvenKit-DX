using System;
using System.Collections.Generic;
using DevExpress.XtraTreeList;
using WolvenKit.CR2W.Editors;

namespace WolvenKit.Models
{
    public class VariableListNode : TreeList.IVirtualTreeListData 
    {
        public string Name
        {
            get
            {
                if (Variable.Name != null)
                    return Variable.Name;

                return Parent?.Children.IndexOf(this).ToString() ?? string.Empty;
            }
            set
            {
                if (Variable.Name != null) Variable.Name = value;
            }
        }

        public string Value => Variable.ToString();

        public string Type => Variable.Type;

        public int ChildCount => Children.Count;

        public List<VariableListNode> Children { get; set; }
        public VariableListNode Parent { get; set; }
        public IEditableVariable Variable { get; set; }
        public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            info.Children = Children;
        }

        public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            if (info.Column.Name == "treeListColumnName")
            {
                info.CellData = Name;
            }
            else if (info.Column.Name == "treeListColumnType")
            {
                info.CellData = Type;
            }
            else if (info.Column.Name == "treeListColumnValue")
            {
                info.CellData = Value;
            }
        }

        public void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            if (info.Column.Name == "treeListColumnValue")
            {
                Variable.SetValue(info.NewCellData);
            }
        }
    }
}