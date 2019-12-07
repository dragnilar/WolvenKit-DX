using System;
using System.IO;
using System.Windows.Forms;
using WolvenKit.Common;

namespace WolvenKit
{
    public class WitcherListViewItem : ListViewItem, ICloneable
    {
        public WitcherListViewItem()
        {
        }

        public WitcherListViewItem(IWitcherFile wf)
        {
            IsDirectory = false;
            Node = new WitcherTreeNode();
            Node.Name = Path.Combine("Root", wf.Bundle.TypeName, Path.GetDirectoryName(wf.Name));
            FullPath = wf.Name;
            Text = wf.Name;
        }

        public bool IsDirectory { get; set; }
        public WitcherTreeNode Node { get; set; }
        public string FullPath { get; set; }

        public string ExplorerPath => Path.Combine(Node.FullPath, Path.GetFileName(FullPath));

        public override object Clone()
        {
            var c = (WitcherListViewItem)MemberwiseClone();
            c.IsDirectory = IsDirectory;
            c.Node = Node;
            c.FullPath = FullPath;
            return c;
        }
    }
}