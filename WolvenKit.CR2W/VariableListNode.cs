using System.Collections.Generic;
using WolvenKit.CR2W.Editors;

namespace WolvenKit.CR2W
{
    public class VariableListNode
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
    }
}