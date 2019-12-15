// Decompiled with JetBrains decompiler
// Type: W3Edit.Win32
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System;
using System.Runtime.InteropServices;

namespace W3Edit
{
  public class Win32
  {
    public const int GWL_STYLE = -16;
    public const int WS_VSCROLL = 2097152;
    public const int WS_HSCROLL = 1048576;

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
  }
}
