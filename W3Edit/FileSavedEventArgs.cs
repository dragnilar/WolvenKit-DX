// Decompiled with JetBrains decompiler
// Type: W3Edit.FileSavedEventArgs
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System.IO;
using W3Edit.CR2W;

namespace W3Edit
{
  public class FileSavedEventArgs
  {
    public Stream Stream { get; set; }

    public string FileName { get; set; }

    public CR2WFile File { get; set; }
  }
}
