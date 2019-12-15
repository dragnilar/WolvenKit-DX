// Decompiled with JetBrains decompiler
// Type: W3Edit.frmModSettings
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using W3Edit.Mod;

namespace W3Edit
{
  public class frmModSettings : Form
  {
    private W3Mod mod;
    private IContainer components;
    private Label lblName;
    private TextBox txName;
    private CheckBox cbInstallAsDLC;
    private Button btSave;
    private Button btCancel;

    public W3Mod Mod
    {
      get
      {
        return this.mod;
      }
      set
      {
        this.mod = value;
        this.txName.Text = this.mod.Name;
        this.cbInstallAsDLC.Checked = this.mod.InstallAsDLC;
      }
    }

    public frmModSettings()
    {
      this.InitializeComponent();
    }

    private void btSave_Click(object sender, EventArgs e)
    {
      if (this.mod == null)
        return;
      this.mod.Name = this.txName.Text;
      this.mod.InstallAsDLC = this.cbInstallAsDLC.Checked;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.lblName = new Label();
      this.txName = new TextBox();
      this.cbInstallAsDLC = new CheckBox();
      this.btSave = new Button();
      this.btCancel = new Button();
      this.SuspendLayout();
      this.lblName.AutoSize = true;
      this.lblName.Location = new Point(12, 9);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(35, 13);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "Name";
      this.txName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txName.Location = new Point(159, 6);
      this.txName.Name = "txName";
      this.txName.Size = new Size(224, 20);
      this.txName.TabIndex = 1;
      this.cbInstallAsDLC.AutoEllipsis = true;
      this.cbInstallAsDLC.CheckAlign = ContentAlignment.MiddleRight;
      this.cbInstallAsDLC.Location = new Point(12, 32);
      this.cbInstallAsDLC.Name = "cbInstallAsDLC";
      this.cbInstallAsDLC.Size = new Size(162, 24);
      this.cbInstallAsDLC.TabIndex = 3;
      this.cbInstallAsDLC.Text = "Install as DLC";
      this.cbInstallAsDLC.UseVisualStyleBackColor = true;
      this.btSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btSave.DialogResult = DialogResult.OK;
      this.btSave.Location = new Point(308, 62);
      this.btSave.Name = "btSave";
      this.btSave.Size = new Size(75, 23);
      this.btSave.TabIndex = 4;
      this.btSave.Text = "Save";
      this.btSave.UseVisualStyleBackColor = true;
      this.btSave.Click += new EventHandler(this.btSave_Click);
      this.btCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btCancel.DialogResult = DialogResult.Cancel;
      this.btCancel.Location = new Point(15, 62);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new Size(75, 23);
      this.btCancel.TabIndex = 5;
      this.btCancel.Text = "Cancel";
      this.btCancel.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btSave;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btCancel;
      this.ClientSize = new Size(395, 97);
      this.Controls.Add((Control) this.btCancel);
      this.Controls.Add((Control) this.btSave);
      this.Controls.Add((Control) this.cbInstallAsDLC);
      this.Controls.Add((Control) this.txName);
      this.Controls.Add((Control) this.lblName);
      this.MinimumSize = new Size(300, 135);
      this.Name = nameof (frmModSettings);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Mod Settings";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
