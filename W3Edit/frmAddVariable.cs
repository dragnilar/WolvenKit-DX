// Decompiled with JetBrains decompiler
// Type: W3Edit.frmAddVariable
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using W3Edit.CR2W.Types;

namespace W3Edit
{
  public class frmAddVariable : Form
  {
    private IContainer components;
    private Label lblType;
    private TextBox txName;
    private Label lblName;
    private Button btOK;
    private Button btCancel;
    private ComboBox txType;

    public string VariableName
    {
      get
      {
        return this.txName.Text;
      }
      set
      {
        this.txName.Text = value;
      }
    }

    public string VariableType
    {
      get
      {
        return this.txType.Text;
      }
      set
      {
        this.txType.Text = value;
      }
    }

    public frmAddVariable()
    {
      this.InitializeComponent();
      List<string> availableTypes = CR2WTypeManager.Get().AvailableTypes;
      availableTypes.Sort();
      this.txType.Items.AddRange((object[]) availableTypes.ToArray());
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.lblType = new Label();
      this.txName = new TextBox();
      this.lblName = new Label();
      this.btOK = new Button();
      this.btCancel = new Button();
      this.txType = new ComboBox();
      this.SuspendLayout();
      this.lblType.AutoSize = true;
      this.lblType.Location = new Point(12, 9);
      this.lblType.Name = "lblType";
      this.lblType.Size = new Size(31, 13);
      this.lblType.TabIndex = 0;
      this.lblType.Text = "Type";
      this.txName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txName.Location = new Point(49, 32);
      this.txName.Name = "txName";
      this.txName.Size = new Size(276, 20);
      this.txName.TabIndex = 3;
      this.lblName.AutoSize = true;
      this.lblName.Location = new Point(12, 35);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(35, 13);
      this.lblName.TabIndex = 2;
      this.lblName.Text = "Name";
      this.btOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btOK.DialogResult = DialogResult.OK;
      this.btOK.Location = new Point(250, 65);
      this.btOK.Name = "btOK";
      this.btOK.Size = new Size(75, 23);
      this.btOK.TabIndex = 4;
      this.btOK.Text = "Add";
      this.btOK.UseVisualStyleBackColor = true;
      this.btCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btCancel.DialogResult = DialogResult.Cancel;
      this.btCancel.Location = new Point(12, 65);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new Size(75, 23);
      this.btCancel.TabIndex = 5;
      this.btCancel.Text = "Cancel";
      this.btCancel.UseVisualStyleBackColor = true;
      this.txType.FormattingEnabled = true;
      this.txType.Location = new Point(49, 5);
      this.txType.Name = "txType";
      this.txType.Size = new Size(276, 21);
      this.txType.TabIndex = 6;
      this.AcceptButton = (IButtonControl) this.btOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btCancel;
      this.ClientSize = new Size(337, 96);
      this.Controls.Add((Control) this.txType);
      this.Controls.Add((Control) this.btCancel);
      this.Controls.Add((Control) this.btOK);
      this.Controls.Add((Control) this.txName);
      this.Controls.Add((Control) this.lblName);
      this.Controls.Add((Control) this.lblType);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.MaximumSize = new Size(1000, 130);
      this.MinimumSize = new Size(200, 130);
      this.Name = nameof (frmAddVariable);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Add Variable";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
