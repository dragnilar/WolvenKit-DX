// Decompiled with JetBrains decompiler
// Type: W3Edit.frmOutput
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace W3Edit
{
  public class frmOutput : DockContent
  {
    private IContainer components;
    private RichTextBox txOutput;

    public void AddText(string text)
    {
      this.txOutput.AppendText(text);
      this.txOutput.ScrollToCaret();
    }

    public frmOutput()
    {
      this.InitializeComponent();
    }

    internal void Clear()
    {
      this.txOutput.Clear();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmOutput));
      this.txOutput = new RichTextBox();
      this.SuspendLayout();
      this.txOutput.Dock = DockStyle.Fill;
      this.txOutput.Location = new Point(0, 0);
      this.txOutput.Name = "txOutput";
      this.txOutput.Size = new Size(284, 262);
      this.txOutput.TabIndex = 0;
      this.txOutput.Text = "";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(284, 262);
      this.Controls.Add((Control) this.txOutput);
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmOutput);
      this.Text = "Output";
      this.ResumeLayout(false);
    }
  }
}
