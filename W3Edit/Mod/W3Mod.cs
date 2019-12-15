// Decompiled with JetBrains decompiler
// Type: W3Edit.Mod.W3Mod
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace W3Edit.Mod
{
  public class W3Mod
  {
    [XmlIgnore]
    public string FileName { get; set; }

    [XmlIgnore]
    public string Directory
    {
      get
      {
        return Path.Combine(Path.GetDirectoryName(this.FileName), this.Name);
      }
    }

    [XmlIgnore]
    public string FileDirectory
    {
      get
      {
        return Path.Combine(this.Directory, "files");
      }
    }

    public string Name { get; set; }

    [XmlIgnore]
    public List<string> Files
    {
      get
      {
        List<string> stringList = new List<string>();
        if (!System.IO.Directory.Exists(this.FileDirectory))
          System.IO.Directory.CreateDirectory(this.FileDirectory);
        foreach (string file in System.IO.Directory.GetFiles(this.FileDirectory, "*", SearchOption.AllDirectories))
          stringList.Add(file.Substring(this.FileDirectory.Length + 1));
        return stringList;
      }
    }

    public bool InstallAsDLC { get; set; }
  }
}
