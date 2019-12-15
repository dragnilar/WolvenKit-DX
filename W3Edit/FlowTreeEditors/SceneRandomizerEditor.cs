// Decompiled with JetBrains decompiler
// Type: W3Edit.FlowTreeEditors.SceneRandomizerEditor
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using W3Edit.CR2W;
using W3Edit.CR2W.Types;

namespace W3Edit.FlowTreeEditors
{
  public class SceneRandomizerEditor : ChunkEditor
  {
    private IContainer components;

    public SceneRandomizerEditor()
    {
      this.InitializeComponent();
    }

    public override List<CPtr> GetConnections()
    {
      List<CPtr> cptrList = new List<CPtr>();
      CVariable variableByName = this.Chunk.GetVariableByName("outputs");
      if (variableByName != null && variableByName is CArray)
      {
        foreach (CVariable cvariable in (CArray) variableByName)
        {
          if (cvariable != null && cvariable is CPtr)
          {
            CPtr cptr = (CPtr) cvariable;
            cptrList.Add(cptr);
          }
        }
      }
      return cptrList;
    }

    public override void UpdateView()
    {
      base.UpdateView();
      int y = 21;
      int num = 0;
      CVariable variableByName = this.Chunk.GetVariableByName("outputs");
      if (variableByName != null && variableByName is CArray)
      {
        foreach (CVariable cvariable in (CArray) variableByName)
        {
          if (cvariable != null && cvariable is CPtr)
          {
            CPtr ptr = (CPtr) cvariable;
            string ptrTargetType = ptr.PtrTargetType;
            Label label1 = new Label();
            label1.Width = this.Width;
            label1.Height = 20;
            label1.Location = new Point(0, y);
            label1.TextAlign = ContentAlignment.TopRight;
            label1.AutoSize = false;
            label1.Text = num.ToString();
            Label label2 = label1;
            label2.Click += (EventHandler) ((sender, e) => this.FireSelectEvent(ptr.PtrTarget));
            this.Controls.Add((Control) label2);
            ++num;
            y += label2.Height;
          }
        }
      }
      this.Height = y;
    }

    public override Point GetConnectionLocation(int i)
    {
      return new Point(0, i * 20 + 21 + 10);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.AutoScaleMode = AutoScaleMode.Font;
    }
  }
}
