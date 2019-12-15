// Decompiled with JetBrains decompiler
// Type: W3Edit.FlowTreeEditors.SceneSectionEditor
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using W3Edit.CR2W;
using W3Edit.CR2W.Types;

namespace W3Edit.FlowTreeEditors
{
  public class SceneSectionEditor : SceneLinkEditor
  {
    private List<Label> lines;
    private IContainer components;

    public SceneSectionEditor()
    {
      this.InitializeComponent();
    }

    public override void UpdateView()
    {
      base.UpdateView();
      if (this.lines != null)
      {
        foreach (Control line in this.lines)
          this.Controls.Remove(line);
      }
      this.lines = new List<Label>();
      int y = 21;
      int num = 0;
      CVariable variableByName = this.Chunk.GetVariableByName("sceneElements");
      if (variableByName != null && variableByName is CArray)
      {
        foreach (CVariable cvariable in (CArray) variableByName)
        {
          if (cvariable != null && cvariable is CPtr)
          {
            CPtr ptr = (CPtr) cvariable;
            switch (ptr.PtrTargetType)
            {
              case "CStorySceneLine":
                ++num;
                Label label1 = new Label();
                label1.Width = this.Width;
                label1.Height = 20;
                label1.Location = new Point(0, y);
                label1.AutoSize = false;
                label1.Text = this.GetDisplayString(ptr.PtrTarget);
                Label label2 = label1;
                this.lines.Add(label2);
                this.Controls.Add((Control) label2);
                Size size = TextRenderer.MeasureText(label2.Text, label2.Font, new Size(this.Width - 6, 100), TextFormatFlags.WordBreak);
                label2.Height = size.Height + 5;
                label2.BackColor = num % 2 == 0 ? Color.LightBlue : Color.Transparent;
                label2.Click += (EventHandler) ((sender, e) => this.FireSelectEvent(ptr.PtrTarget));
                y += label2.Height;
                continue;
              default:
                continue;
            }
          }
        }
      }
      this.Height = y;
    }

    private string GetDisplayString(CR2WChunk c)
    {
      string str = "";
      if (c != null)
      {
        CVariable variableByName1 = c.GetVariableByName("voicetag");
        if (variableByName1 != null && variableByName1 is CName)
          str = str + ((CName) variableByName1).Value + ": ";
        CVariable variableByName2 = c.GetVariableByName("dialogLine");
        if (variableByName2 != null && variableByName2 is CLocalizedString)
          str += ((CLocalizedString) variableByName2).Text;
      }
      return str;
    }

    public override List<CPtr> GetConnections()
    {
      List<CPtr> cptrList = new List<CPtr>();
      CVariable variableByName1 = this.Chunk.GetVariableByName("choice");
      if (variableByName1 != null && variableByName1 is CPtr)
      {
        CPtr cptr = (CPtr) variableByName1;
        if (cptr.PtrTarget != null)
          cptrList.Add(cptr);
      }
      CVariable variableByName2 = this.Chunk.GetVariableByName("nextLinkElement");
      if (variableByName2 != null && variableByName2 is CPtr)
      {
        CPtr cptr = (CPtr) variableByName2;
        if (cptr.PtrTarget != null)
          cptrList.Add(cptr);
      }
      return cptrList;
    }

    public override string GetCopyText()
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (Label line in this.lines)
        stringBuilder.AppendLine(line.Text);
      return stringBuilder.ToString();
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
