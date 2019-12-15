// Decompiled with JetBrains decompiler
// Type: W3Edit.frmRenameDialog
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace W3Edit
{
  public class frmRenameDialog : Form
  {
    private IContainer components;
    private Button btOk;
    private Button btCancel;
    private TextBox txFileName;

    public string FileName
    {
      get
      {
        return this.txFileName.Text;
      }
      set
      {
        this.txFileName.Text = value;
      }
    }

    public frmRenameDialog()
    {
      this.InitializeComponent();
    }

    private void txFileName_Enter(object sender, EventArgs e)
    {
    }

    private void frmRenameDialog_Activated(object sender, EventArgs e)
    {
      this.txFileName.Focus();
      this.txFileName.Select(Path.GetDirectoryName(this.txFileName.Text).Length + 1, Path.GetFileNameWithoutExtension(this.txFileName.Text).Length);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btOk = new Button();
      this.btCancel = new Button();
      this.txFileName = new TextBox();
      this.SuspendLayout();
      this.btOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btOk.DialogResult = DialogResult.OK;
      this.btOk.Location = new Point(370, 38);
      this.btOk.Name = "btOk";
      this.btOk.Size = new Size(75, 23);
      this.btOk.TabIndex = 0;
      this.btOk.Text = "Ok";
      this.btOk.UseVisualStyleBackColor = true;
      this.btCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btCancel.DialogResult = DialogResult.Cancel;
      this.btCancel.Location = new Point(12, 38);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new Size(75, 23);
      this.btCancel.TabIndex = 1;
      this.btCancel.Text = "Cancel";
      this.btCancel.UseVisualStyleBackColor = true;
      this.txFileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txFileName.Location = new Point(12, 12);
      this.txFileName.Name = "txFileName";
      this.txFileName.Size = new Size(433, 20);
      this.txFileName.TabIndex = 2;
      this.txFileName.Enter += new EventHandler(this.txFileName_Enter);
      this.AcceptButton = (IButtonControl) this.btOk;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btCancel;
      this.ClientSize = new Size(457, 70);
      this.ControlBox = false;
      this.Controls.Add((Control) this.txFileName);
      this.Controls.Add((Control) this.btCancel);
      this.Controls.Add((Control) this.btOk);
      this.MaximumSize = new Size(1000, 108);
      this.MinimumSize = new Size(200, 108);
      this.Name = nameof (frmRenameDialog);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Rename";
      this.Activated += new EventHandler(this.frmRenameDialog_Activated);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
