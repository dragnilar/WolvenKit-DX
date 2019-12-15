// Decompiled with JetBrains decompiler
// Type: W3Edit.FlowTreeEditors.SceneFlowConditionEditor
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
  public class SceneFlowConditionEditor : ChunkEditor
  {
    private IContainer components;
    private Label lblTrue;
    private Label lblFalse;
    private Label lblCondition;

    public SceneFlowConditionEditor()
    {
      this.InitializeComponent();
    }

    public override void UpdateView()
    {
      int height = this.Height;
      base.UpdateView();
      this.Height = height;
      this.lblCondition.Text = "";
      CVariable variableByName1 = this.Chunk.GetVariableByName("questCondition");
      if (variableByName1 != null && variableByName1 is CPtr)
      {
        CPtr questCondition = (CPtr) variableByName1;
        if (questCondition.PtrTarget != null)
        {
          this.lblCondition.Click += (EventHandler) ((sender, e) => this.FireSelectEvent(questCondition.PtrTarget));
          CVariable variableByName2 = questCondition.PtrTarget.GetVariableByName("factId");
          if (variableByName2 != null && variableByName2 is CString)
            this.lblCondition.Text = ((CString) variableByName2).val;
          else
            this.lblCondition.Text = questCondition.PtrTarget.Name;
        }
      }
      CVariable variableByName3 = this.Chunk.GetVariableByName("comment");
      if (variableByName3 == null || !(variableByName3 is CString))
        return;
      this.lblCondition.Text = ((CString) variableByName3).val;
    }

    public override List<CPtr> GetConnections()
    {
      List<CPtr> cptrList = new List<CPtr>();
      if (this.Chunk != null)
      {
        CVariable variableByName1 = this.Chunk.GetVariableByName("trueLink");
        if (variableByName1 != null && variableByName1 is CPtr)
        {
          CPtr cptr = (CPtr) variableByName1;
          if (cptr.PtrTarget != null)
            cptrList.Add(cptr);
        }
        CVariable variableByName2 = this.Chunk.GetVariableByName("falseLink");
        if (variableByName2 != null && variableByName2 is CPtr)
        {
          CPtr cptr = (CPtr) variableByName2;
          if (cptr.PtrTarget != null)
            cptrList.Add(cptr);
        }
      }
      return cptrList;
    }

    public override Point GetConnectionLocation(int i)
    {
      if (i == 0)
        return new Point(0, this.lblTrue.Top + this.lblTrue.Height / 2);
      return i == 1 ? new Point(0, this.lblFalse.Top + this.lblFalse.Height / 2) : new Point(0, i * 20 + 21 + 10);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.lblTrue = new Label();
      this.lblFalse = new Label();
      this.lblCondition = new Label();
      this.SuspendLayout();
      this.lblTrue.Location = new Point(276, 18);
      this.lblTrue.Name = "lblTrue";
      this.lblTrue.Size = new Size(35, 15);
      this.lblTrue.TabIndex = 1;
      this.lblTrue.Text = "True";
      this.lblFalse.Location = new Point(276, 30);
      this.lblFalse.Name = "lblFalse";
      this.lblFalse.Size = new Size(35, 15);
      this.lblFalse.TabIndex = 2;
      this.lblFalse.Text = "False";
      this.lblCondition.Location = new Point(3, 20);
      this.lblCondition.Name = "lblCondition";
      this.lblCondition.Size = new Size(267, 23);
      this.lblCondition.TabIndex = 3;
      this.lblCondition.Text = "label1";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.lblCondition);
      this.Controls.Add((Control) this.lblFalse);
      this.Controls.Add((Control) this.lblTrue);
      this.Name = "SceneFlowCondition";
      this.Controls.SetChildIndex((Control) this.lblTrue, 0);
      this.Controls.SetChildIndex((Control) this.lblFalse, 0);
      this.Controls.SetChildIndex((Control) this.lblCondition, 0);
      this.ResumeLayout(false);
    }
  }
}
