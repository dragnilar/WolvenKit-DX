// Decompiled with JetBrains decompiler
// Type: W3Edit.frmExtractAmbigious
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace W3Edit
{
  public class frmExtractAmbigious : Form
  {
    private IContainer components;
    private Button btCancel;
    private Button btOk;
    private ListBox lsBundleList;
    private Label lblMessage;

    public frmExtractAmbigious(IEnumerable<string> options)
    {
      this.InitializeComponent();
      this.lsBundleList.Items.AddRange((object[]) options.ToArray<string>());
      this.lsBundleList.SelectedIndex = this.lsBundleList.Items.Count - 1;
    }

    public string SelectedBundle
    {
      get
      {
        return (string) this.lsBundleList.SelectedItem;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btCancel = new Button();
      this.btOk = new Button();
      this.lsBundleList = new ListBox();
      this.lblMessage = new Label();
      this.SuspendLayout();
      this.btCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btCancel.DialogResult = DialogResult.Cancel;
      this.btCancel.Location = new Point(12, 311);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new Size(75, 23);
      this.btCancel.TabIndex = 7;
      this.btCancel.Text = "Cancel";
      this.btCancel.UseVisualStyleBackColor = true;
      this.btOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btOk.DialogResult = DialogResult.OK;
      this.btOk.Location = new Point(727, 311);
      this.btOk.Name = "btOk";
      this.btOk.Size = new Size(75, 23);
      this.btOk.TabIndex = 6;
      this.btOk.Text = "Ok";
      this.btOk.UseVisualStyleBackColor = true;
      this.lsBundleList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lsBundleList.FormattingEnabled = true;
      this.lsBundleList.IntegralHeight = false;
      this.lsBundleList.Location = new Point(13, 34);
      this.lsBundleList.Name = "lsBundleList";
      this.lsBundleList.Size = new Size(789, 271);
      this.lsBundleList.TabIndex = 8;
      this.lblMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblMessage.AutoEllipsis = true;
      this.lblMessage.Location = new Point(13, 15);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new Size(789, 16);
      this.lblMessage.TabIndex = 9;
      this.lblMessage.Text = "The file you are trying to extract exists in one or more bundles, select one.";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(814, 346);
      this.Controls.Add((Control) this.lblMessage);
      this.Controls.Add((Control) this.lsBundleList);
      this.Controls.Add((Control) this.btCancel);
      this.Controls.Add((Control) this.btOk);
      this.MinimumSize = new Size(420, 152);
      this.Name = nameof (frmExtractAmbigious);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Extract ambigious";
      this.ResumeLayout(false);
    }
  }
}
