using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using WolvenKit.Common;

namespace WolvenKit
{
    public partial class ModExplorer : XtraUserControl
    {
        public static DateTime LastChange;
        public static TimeSpan mindiff = TimeSpan.FromMilliseconds(500);
        public bool FoldersShown = true;

        public ModExplorer()
        {
            InitializeComponent();
            UpdateModFileList(true, true);
            LastChange = DateTime.Now;
        }

        public W3Mod ActiveMod
        {
            get => MainController.Get().ActiveMod;
            set => MainController.Get().ActiveMod = value;
        }

        public event EventHandler<RequestFileArgs> RequestFileOpen;
        public event EventHandler<RequestFileArgs> RequestFileDelete;
        public event EventHandler<RequestFileArgs> RequestFileAdd;
        public event EventHandler<RequestFileArgs> RequestFileRename;


        public void PauseMonitoring()
        {
            fileWatcherModExplorer.EnableRaisingEvents = false;
        }

        public void ResumeMonitoring()
        {
            fileWatcherModExplorer.Path = ActiveMod.FileDirectory;
            fileWatcherModExplorer.EnableRaisingEvents = true;
        }

        public void StopMonitoringDirectory()
        {
            fileWatcherModExplorer.Dispose();
        }

        public bool DeleteNode(string fullPath)
        {
            foreach (var t in fullPath.Split('\\'))
            {
                var node = treeListModFiles.FindNodeByFieldValue(treeListColumnFullName.FieldName, t);
                if (node != null)
                {
                    treeListModFiles.Nodes.Remove(node);
                    return true;
                }

                break;
            }

            return false;
        }

        public void UpdateModFileList(bool showfolders, bool clear = false, string rootFilePath = null)
        {
            if (ActiveMod == null)
                return;
            treeListModFiles.BeginUpdate();
            if (treeListModFiles.Nodes == null || treeListModFiles.Nodes.Count == 0)
            {
                InitFolders(rootFilePath, null);
            }
            else if (treeListModFiles.Nodes.Count > 0)
            {
                treeListModFiles.Nodes.Clear();
                InitFolders(rootFilePath, null);
            }

            treeListModFiles.ExpandAll();
            treeListModFiles.EndUpdate();
        }


        private void InitFolders(string path, TreeListNode parentNode)
        {
            treeListModFiles.BeginUnboundLoad();
            try
            {
                foreach (var s in Directory.GetDirectories(path))
                    try
                    {
                        var di = new DirectoryInfo(s);
                        var node = treeListModFiles.AppendNode(new object[] {s, di.Name, "Folder"}, parentNode);
                        node.StateImageIndex = 1;
                        node.HasChildren = HasFiles(s);
                        if (node.HasChildren)
                            node.Tag = true;
                    }
                    catch
                    {
                        // ignored
                    }
            }
            catch
            {
                // ignored
            }

            InitFiles(path, parentNode);
            treeListModFiles.EndUnboundLoad();
        }

        private void InitFiles(string path, TreeListNode parentNode)
        {
            var root = Directory.GetFiles(path);
            try
            {
                foreach (var s in root)
                {
                    var fi = new FileInfo(s);
                    var node = treeListModFiles.AppendNode(new object[] {s, fi.Name, "File"}, parentNode);
                    node.StateImageIndex = GetImageIndex(fi.Extension);
                    node.HasChildren = false;
                }
            }
            catch
            {
                // ignored
            }
        }

        private int GetImageIndex(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".csv":
                    return 3;
                case ".redswf":
                    return 4;
                case ".env":
                    return 5;
                case ".journal":
                    return 6;
                case ".w2beh":
                    return 7;
                case ".xml":
                    return 8;
                case ".w2behtree":
                    return 9;
                case ".w2scene":
                    return 10;
                case ".w2p":
                    return 11;
                case ".w2rig":
                    return 12;
                case ".ws":
                    return 13;
                case ".w2ent":
                    return 14;
                default:
                    return 0;
            }
        }


        private bool HasFiles(string path)
        {
            var root = Directory.GetFiles(path);
            if (root.Length > 0) return true;
            root = Directory.GetDirectories(path);
            if (root.Length > 0) return true;
            return false;
        }

        private void modFileList_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                InitFolders(e.Node.GetDisplayText(treeListColumnFullName.FieldName), e.Node);
                e.Node.Tag = null;
                Cursor.Current = Cursors.Default;
            }
        }

        private void modFileList_AfterExpand(object sender, NodeEventArgs e)
        {
            if (e.Node.StateImageIndex != 1) e.Node.StateImageIndex = 2;
        }

        private void modFileList_AfterCollapse(object sender, NodeEventArgs e)
        {
            if (e.Node.StateImageIndex != 1) e.Node.StateImageIndex = 1;
        }

        private void modFileList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
                if (sender is TreeList treeList)
                {
                    var hitInfo = treeList.CalcHitInfo(e.Location);
                    if (hitInfo.HitInfoType == HitInfoType.Cell)
                        RequestFileOpen?.Invoke(this,
                            new RequestFileArgs {File = hitInfo.Node[treeListColumnFullName.FieldName].ToString()});
                }
        }

        private void FileChanges_Detected(object sender, FileSystemEventArgs e)
        {
            UpdateModFileList(FoldersShown, true, ActiveMod.FileDirectory);
        }


        private void frmModExplorer_Shown(object sender, EventArgs e)
        {
            if (ActiveMod != null)
                fileWatcherModExplorer.Path = ActiveMod.FileDirectory;
        }

        private void modFileList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && treeListModFiles.Selection != null)
                RequestFileRename?.Invoke(this,
                    new RequestFileArgs
                        {File = treeListModFiles.Selection[0][treeListColumnFullName.FieldName].ToString()});
        }

        private void barButtonItemExpandAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            treeListModFiles.BeginUpdate();
            treeListModFiles.ExpandAll();
            treeListModFiles.EndUpdate();
        }

        private void barButtonItemCollapseAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            treeListModFiles.BeginUpdate();
            treeListModFiles.CollapseAll();
            treeListModFiles.EndUpdate();
        }

        private void barButtonItemAddFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedPath = GetSelectedNodeFilePath();
            if (!string.IsNullOrWhiteSpace(selectedPath))
                RequestFileAdd?.Invoke(this,
                    new RequestFileArgs {File = GetExplorerString(selectedPath ?? string.Empty)});
        }

        private void barButtonItemShowInExplorer_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedFilePath = GetSelectedNodeFilePath();
            if (!string.IsNullOrWhiteSpace(selectedFilePath))
            {
                var directoryPath = Path.GetDirectoryName(selectedFilePath);
                Process.Start("explorer.exe", directoryPath);
            }


        }

        private void barButtonItemMarkAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            //TODO - This may not work right...
            var selectedFilePath = GetSelectedNodeFilePath();
            var fileName = GetSelectedFileName();
            if (!string.IsNullOrWhiteSpace(selectedFilePath) && !string.IsNullOrWhiteSpace(fileName))
            {
                if (!File.Exists(selectedFilePath))
                    return;
                var newfullpath =
                    Path.Combine(new[] {ActiveMod.FileDirectory, fileName.Split('\\')[0] == "DLC" ? "Mod" : "DLC"}
                        .Concat(fileName.Split('\\').Skip(1).ToArray()).ToArray());

                if (File.Exists(newfullpath))
                    return;
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(newfullpath));
                }
                catch
                {
                }

                File.Move(selectedFilePath, newfullpath);
                MainController.Get().ProjectStatus = "File moved";
            }
        }

        private void barButtonItemCopyPath_ItemClick(object sender, ItemClickEventArgs e)
        {
            Clipboard.SetText(GetSelectedNodeFilePath());
        }

        private void barButtonItemPaste_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (File.Exists(Clipboard.GetText()))
            {
                var selectedFilePath = GetSelectedNodeFilePath();
                if (string.IsNullOrWhiteSpace(selectedFilePath)) return;
                var attr = File.GetAttributes(selectedFilePath);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    SafeCopy(Clipboard.GetText(),
                        selectedFilePath +
                        Path.GetFileName(Clipboard.GetText()));
                else
                    SafeCopy(Clipboard.GetText(),
                        Path.GetDirectoryName(selectedFilePath) +
                        "\\" + Path.GetFileName(Clipboard.GetText()));
            }
        }

        private void barButtonItemCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            //TODO - This may not work, I do not think it was implemented in the original WK
            var selectedFilePath = GetSelectedNodeFilePath();
            if (!string.IsNullOrWhiteSpace(selectedFilePath) && File.Exists(selectedFilePath))
                Clipboard.SetFileDropList(new StringCollection {selectedFilePath});
        }

        private void barButtonItemRename_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedFilePath = GetSelectedNodeFilePath();
            if (!string.IsNullOrWhiteSpace(selectedFilePath))
                RequestFileRename?.Invoke(this, new RequestFileArgs {File = selectedFilePath});
        }

        private void barButtonItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedFilePath = GetSelectedNodeFilePath();
            if (!string.IsNullOrWhiteSpace(selectedFilePath))
                RequestFileDelete?.Invoke(this, new RequestFileArgs {File = selectedFilePath});
        }


        private string GetSelectedNodeFilePath()
        {
            return treeListModFiles.Selection == null
                ? string.Empty
                : treeListModFiles.Selection[0][treeListColumnFullName.FieldName].ToString();
        }

        private string GetSelectedFileName()
        {
            return treeListModFiles.Selection == null
                ? string.Empty
                : treeListModFiles.Selection[0][treeListColumnDisplayName.FieldName].ToString();
        }


        public static IEnumerable<string> FallbackPaths(string path)
        {
            yield return path;

            var dir = Path.GetDirectoryName(path);
            var file = Path.GetFileNameWithoutExtension(path);
            var ext = Path.GetExtension(path);

            yield return Path.Combine(dir, file + " - Copy" + ext);
            for (var i = 2;; i++) yield return Path.Combine(dir, file + " - Copy " + i + ext);
        }

        public static void SafeCopy(string src, string dest)
        {
            foreach (var path in FallbackPaths(dest).Where(path => !File.Exists(path)))
            {
                File.Copy(src, path);
                break;
            }
        }

        public string GetExplorerString(string s)
        {
            if (s.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Length > 1)
            {
                var r = string.Join(Path.DirectorySeparatorChar.ToString(),
                    new[] {"Root"}.Concat(s.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Skip(1))
                        .ToArray());
                return string.Join(Path.DirectorySeparatorChar.ToString(),
                    new[] {"Root"}.Concat(s.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Skip(1))
                        .ToArray());
            }

            return s;
        }

        private void treeListModFiles_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            barButtonItemPaste.Enabled = treeListModFiles.Selection != null;
            popupMenuModExplorer.ShowPopup(MousePosition);
            e.Allow = false;
        }
    }
}