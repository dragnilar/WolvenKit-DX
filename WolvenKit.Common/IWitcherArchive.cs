using System.Collections.Generic;
using System.Windows.Forms;

namespace WolvenKit.Interfaces
{
    public interface IWitcherArchive
    {
        WitcherTreeNode RootNode { get; set; }
        List<IWitcherFile> FileList { get; set; }
        string TypeName { get; }
        List<string> Extensions { get; set; }
        AutoCompleteStringCollection AutocompleteSource { get; set; }
        Dictionary<string, List<IWitcherFile>> Items { get; set; }
    }
}
