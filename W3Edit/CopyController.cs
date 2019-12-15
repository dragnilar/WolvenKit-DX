// Decompiled with JetBrains decompiler
// Type: W3Edit.CopyController
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System.Collections.Generic;
using W3Edit.CR2W;
using W3Edit.CR2W.Editors;

namespace W3Edit
{
  public class CopyController
  {
    public static IEditableVariable VariableTarget { get; set; }

    public static List<CR2WChunk> ChunkList { get; set; }
  }
}
