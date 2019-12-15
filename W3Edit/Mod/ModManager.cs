// Decompiled with JetBrains decompiler
// Type: W3Edit.Mod.ModManager
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

namespace W3Edit.Mod
{
  public class ModManager
  {
    private static ModManager instance;

    public static ModManager Get()
    {
      if (ModManager.instance == null)
        ModManager.instance = new ModManager();
      return ModManager.instance;
    }

    public W3Mod ActiveMod { get; set; }
  }
}
