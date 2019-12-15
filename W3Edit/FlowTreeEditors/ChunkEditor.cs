// Decompiled with JetBrains decompiler
// Type: W3Edit.FlowTreeEditors.ChunkEditor
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
  public class ChunkEditor : UserControl
  {
    private CR2WChunk chunk;
    private bool mouseMoving;
    private Point mouseStart;
    private IContainer components;
    private Label lblTitle;

    public virtual string GetCopyText()
    {
      return this.chunk.Name;
    }

    public CR2WChunk Chunk
    {
      get
      {
        return this.chunk;
      }
      set
      {
        this.chunk = value;
        this.UpdateView();
      }
    }

    public event EventHandler<SelectChunkArgs> OnSelectChunk;

    public event EventHandler<MoveEditorArgs> OnManualMove;

    public ChunkEditor()
    {
      this.InitializeComponent();
    }

    private void lblTitle_MouseDown(object sender, MouseEventArgs e)
    {
      this.mouseStart = e.Location;
      this.mouseMoving = true;
    }

    private void lblTitle_MouseUp(object sender, MouseEventArgs e)
    {
      this.mouseMoving = false;
    }

    private void lblTitle_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.mouseMoving)
        return;
      if (this.OnManualMove != null)
        this.OnManualMove((object) this, new MoveEditorArgs()
        {
          Relative = new Point(this.Location.X - this.mouseStart.X + e.X - this.Location.X, this.Location.Y - this.mouseStart.Y + e.Y - this.Location.Y)
        });
      this.Location = new Point(this.Location.X - this.mouseStart.X + e.X, this.Location.Y - this.mouseStart.Y + e.Y);
    }

    public virtual void UpdateView()
    {
      this.lblTitle.Text = this.chunk.Name;
      this.Height = this.lblTitle.Height;
    }

    public virtual List<CPtr> GetConnections()
    {
      return (List<CPtr>) null;
    }

    private void lblTitle_Click(object sender, EventArgs e)
    {
      this.FireSelectEvent(this.Chunk);
    }

    private void ChunkEditor_Click(object sender, EventArgs e)
    {
      this.FireSelectEvent(this.Chunk);
    }

    public void FireSelectEvent(CR2WChunk c)
    {
      if (this.OnSelectChunk == null)
        return;
      this.OnSelectChunk((object) this, new SelectChunkArgs()
      {
        Chunk = c
      });
    }

    public virtual Point GetConnectionLocation(int i)
    {
      return new Point(0, this.Height / 2);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.lblTitle = new Label();
      this.SuspendLayout();
      this.lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblTitle.AutoEllipsis = true;
      this.lblTitle.BackColor = SystemColors.ActiveCaption;
      this.lblTitle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTitle.ForeColor = SystemColors.ActiveCaptionText;
      this.lblTitle.Location = new Point(0, 0);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new Size(313, 18);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.Text = "label1";
      this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
      this.lblTitle.Click += new EventHandler(this.lblTitle_Click);
      this.lblTitle.MouseDown += new MouseEventHandler(this.lblTitle_MouseDown);
      this.lblTitle.MouseMove += new MouseEventHandler(this.lblTitle_MouseMove);
      this.lblTitle.MouseUp += new MouseEventHandler(this.lblTitle_MouseUp);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BorderStyle = BorderStyle.FixedSingle;
      this.Controls.Add((Control) this.lblTitle);
      this.DoubleBuffered = true;
      this.Name = nameof (ChunkEditor);
      this.Size = new Size(312, 46);
      this.Click += new EventHandler(this.ChunkEditor_Click);
      this.ResumeLayout(false);
    }
  }
}
