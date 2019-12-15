// Decompiled with JetBrains decompiler
// Type: W3Edit.FlowTreeEditors.SceneLinkEditor
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using W3Edit.CR2W;
using W3Edit.CR2W.Types;

namespace W3Edit.FlowTreeEditors
{
  public class SceneLinkEditor : ChunkEditor
  {
    private IContainer components;

    public SceneLinkEditor()
    {
      this.InitializeComponent();
    }

    public override List<CPtr> GetConnections()
    {
      List<CPtr> cptrList = new List<CPtr>();
      if (this.Chunk != null)
      {
        CVariable variableByName = this.Chunk.GetVariableByName("nextLinkElement");
        if (variableByName != null && variableByName is CPtr)
        {
          CPtr cptr = (CPtr) variableByName;
          if (cptr.PtrTarget != null)
            cptrList.Add(cptr);
        }
      }
      return cptrList;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Name = nameof (SceneLinkEditor);
      this.ResumeLayout(false);
    }
  }
}
