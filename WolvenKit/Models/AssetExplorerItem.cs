using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using WolvenKit.Annotations;
using WolvenKit.Interfaces;

namespace WolvenKit.Models
{
    public sealed class AssetExplorerItem : INotifyPropertyChanged
    {
        public bool IsDirectory { get; set; }
        public List<WitcherTreeNode> Directories { get; set; }
        public List<IWitcherFile> Files { get; set; }
        public IWitcherFile InternalFile { get; set; }
        public string FullPath { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string CompressionType { get; set; }
        public string BundleType { get; set; }
        public int ImageIndex { get; set; }
        public bool IsChecked { get; set; }

        public string DirectoryPath {get;}
        

        public AssetExplorerItem(string name, string fullPath, List<IWitcherFile> files, List<WitcherTreeNode> directories, int imageIndex)
        {
            Directories = directories;
            FullPath = fullPath;
            Name = name;
            Files = files;
            IsDirectory = true;
            ImageIndex = imageIndex;
            IsChecked = false;
        }

        public AssetExplorerItem(string name, string fullPath, string size, string compressionType, string bundleType,
            int imageIndex, IWitcherFile internalFile)
        {
            Name = name;
            FullPath = fullPath;
            IsDirectory = false;
            ImageIndex = imageIndex;
            Size = size;
            CompressionType = compressionType;
            BundleType = bundleType;
            IsChecked = false;
            InternalFile = internalFile;
            DirectoryPath = bundleType == "SoundCache" ? Path.GetDirectoryName(fullPath) : $"Root\\{bundleType}\\{Path.GetDirectoryName(fullPath)}";
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
