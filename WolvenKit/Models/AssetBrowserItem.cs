using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolvenKit.Common;

namespace WolvenKit.Models
{
    public sealed class AssetBrowserItem
    {
        public bool IsDirectory { get; set; }
        public List<WitcherTreeNode> Directories { get; set; }
        public List<IWitcherFile> Files { get; set; }
        public string FullPath { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string CompressionType { get; set; }
        public string BundleType { get; set; }
        public int ImageIndex { get; set; }

    }
}
