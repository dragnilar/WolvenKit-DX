// Decompiled with JetBrains decompiler
// Type: W3Edit.frmAddChunk
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
  public class frmAddChunk : Form
  {
    private IContainer components;
    private ComboBox txType;
    private Button btCancel;
    private Button btOK;
    private Label lblType;

    public string ChunkType
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

    public frmAddChunk()
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
      this.txType = new ComboBox();
      this.btCancel = new Button();
      this.btOK = new Button();
      this.lblType = new Label();
      this.SuspendLayout();
      this.txType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txType.FormattingEnabled = true;
      this.txType.Location = new Point(43, 7);
      this.txType.Name = "txType";
      this.txType.Size = new Size(218, 21);
      this.txType.TabIndex = 12;
      this.btCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btCancel.DialogResult = DialogResult.Cancel;
      this.btCancel.Location = new Point(12, 33);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new Size(75, 23);
      this.btCancel.TabIndex = 11;
      this.btCancel.Text = "Cancel";
      this.btCancel.UseVisualStyleBackColor = true;
      this.btOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btOK.DialogResult = DialogResult.OK;
      this.btOK.Location = new Point(186, 33);
      this.btOK.Name = "btOK";
      this.btOK.Size = new Size(75, 23);
      this.btOK.TabIndex = 10;
      this.btOK.Text = "Add";
      this.btOK.UseVisualStyleBackColor = true;
      this.lblType.AutoSize = true;
      this.lblType.Location = new Point(6, 10);
      this.lblType.Name = "lblType";
      this.lblType.Size = new Size(31, 13);
      this.lblType.TabIndex = 7;
      this.lblType.Text = "Type";
      this.AcceptButton = (IButtonControl) this.btOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btCancel;
      this.ClientSize = new Size(273, 68);
      this.Controls.Add((Control) this.txType);
      this.Controls.Add((Control) this.btCancel);
      this.Controls.Add((Control) this.btOK);
      this.Controls.Add((Control) this.lblType);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.MaximumSize = new Size(1000, 102);
      this.MinimumSize = new Size(199, 102);
      this.Name = nameof (frmAddChunk);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Add Chunk";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
