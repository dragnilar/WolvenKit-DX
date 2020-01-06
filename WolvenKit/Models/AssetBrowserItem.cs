using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolvenKit.Interfaces;

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
        public bool IsChecked { get; set; }

        public AssetBrowserItem(string name, string fullPath, List<IWitcherFile> files, List<WitcherTreeNode> directories, int imageIndex)
        {
            Directories = directories;
            FullPath = fullPath;
            Name = name;
            Files = files;
            IsDirectory = true;
            ImageIndex = imageIndex;
            IsChecked = false;
        }

        public AssetBrowserItem(string name, string fullPath, string size, string compressionType, string bundleType,
            int imageIndex)
        {
            Name = name;
            FullPath = fullPath;
            IsDirectory = false;
            ImageIndex = imageIndex;
            Size = size;
            CompressionType = compressionType;
            BundleType = bundleType;
            IsChecked = false;
        }


    }
}
