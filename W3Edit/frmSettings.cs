// Decompiled with JetBrains decompiler
// Type: W3Edit.frmSettings
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
  public class frmSettings : Form
  {
    private IContainer components;
    private TextBox txExecutablePath;
    private Label lblExecutable;
    private Button btnBrowseExe;
    private Button btSave;
    private Label lblLanguage;
    private TextBox txTextLanguage;
    private Label lblVoiceLanguage;
    private TextBox txVoiceLanguage;
    private Button btBrowseWCC_Lite;
    private Label lblWCC_Lite;
    private TextBox txWCC_Lite;
    private Button btCancel;
    private CheckBox cbFlowDiagram;

    public frmSettings()
    {
      this.InitializeComponent();
      Configuration configuration = MainController.Get().Configuration;
      this.txExecutablePath.Text = configuration.ExecutablePath;
      this.txTextLanguage.Text = configuration.TextLanguage;
      this.txVoiceLanguage.Text = configuration.VoiceLanguage;
      this.txWCC_Lite.Text = configuration.WCC_Lite;
      this.cbFlowDiagram.Checked = configuration.EnableFlowTreeEditor;
    }

    private void btnBrowseExe_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = "Select Witcher 3 Executable.";
      openFileDialog.FileName = this.txExecutablePath.Text;
      openFileDialog.Filter = "witcher3.exe|witcher3.exe";
      if (openFileDialog.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      this.txExecutablePath.Text = openFileDialog.FileName;
    }

    private void btSave_Click(object sender, EventArgs e)
    {
      if (!File.Exists(this.txExecutablePath.Text))
      {
        this.DialogResult = DialogResult.None;
        this.txExecutablePath.Focus();
        int num = (int) MessageBox.Show("Invalid witcher3.exe path", "failed to save.");
      }
      else if (!File.Exists(this.txWCC_Lite.Text))
      {
        this.DialogResult = DialogResult.None;
        this.txWCC_Lite.Focus();
        int num = (int) MessageBox.Show("Invalid wcc_lite.exe path", "failed to save.");
      }
      else
      {
        Configuration configuration = MainController.Get().Configuration;
        configuration.ExecutablePath = this.txExecutablePath.Text;
        configuration.WCC_Lite = this.txWCC_Lite.Text;
        configuration.TextLanguage = this.txTextLanguage.Text;
        configuration.VoiceLanguage = this.txVoiceLanguage.Text;
        configuration.EnableFlowTreeEditor = this.cbFlowDiagram.Checked;
        MainController.Get().ReloadStringManager();
        configuration.Save();
      }
    }

    private void btBrowseWCC_Lite_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = "Select wcc_lite.exe.";
      openFileDialog.FileName = this.txExecutablePath.Text;
      openFileDialog.Filter = "wcc_lite.exe|wcc_lite.exe";
      if (openFileDialog.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      this.txWCC_Lite.Text = openFileDialog.FileName;
    }

    private void cbFlowDiagram_CheckedChanged(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmSettings));
      this.txExecutablePath = new TextBox();
      this.lblExecutable = new Label();
      this.btnBrowseExe = new Button();
      this.btSave = new Button();
      this.lblLanguage = new Label();
      this.txTextLanguage = new TextBox();
      this.lblVoiceLanguage = new Label();
      this.txVoiceLanguage = new TextBox();
      this.btBrowseWCC_Lite = new Button();
      this.lblWCC_Lite = new Label();
      this.txWCC_Lite = new TextBox();
      this.btCancel = new Button();
      this.cbFlowDiagram = new CheckBox();
      this.SuspendLayout();
      this.txExecutablePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txExecutablePath.Location = new Point(13, 28);
      this.txExecutablePath.Name = "txExecutablePath";
      this.txExecutablePath.Size = new Size(490, 20);
      this.txExecutablePath.TabIndex = 0;
      this.lblExecutable.AutoSize = true;
      this.lblExecutable.Location = new Point(13, 9);
      this.lblExecutable.Name = "lblExecutable";
      this.lblExecutable.Size = new Size(135, 13);
      this.lblExecutable.TabIndex = 1;
      this.lblExecutable.Text = "Witcher 3 executable path:";
      this.btnBrowseExe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnBrowseExe.Location = new Point(509, 26);
      this.btnBrowseExe.Name = "btnBrowseExe";
      this.btnBrowseExe.Size = new Size(75, 23);
      this.btnBrowseExe.TabIndex = 2;
      this.btnBrowseExe.Text = "Browse...";
      this.btnBrowseExe.UseVisualStyleBackColor = true;
      this.btnBrowseExe.Click += new EventHandler(this.btnBrowseExe_Click);
      this.btSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btSave.DialogResult = DialogResult.OK;
      this.btSave.Location = new Point(509, 172);
      this.btSave.Name = "btSave";
      this.btSave.Size = new Size(75, 23);
      this.btSave.TabIndex = 3;
      this.btSave.Text = "Save";
      this.btSave.UseVisualStyleBackColor = true;
      this.btSave.Click += new EventHandler(this.btSave_Click);
      this.lblLanguage.AutoSize = true;
      this.lblLanguage.Location = new Point(12, 93);
      this.lblLanguage.Name = "lblLanguage";
      this.lblLanguage.Size = new Size(124, 13);
      this.lblLanguage.TabIndex = 5;
      this.lblLanguage.Text = "Text Language (e.g. EN)";
      this.txTextLanguage.Location = new Point(12, 112);
      this.txTextLanguage.Name = "txTextLanguage";
      this.txTextLanguage.Size = new Size(135, 20);
      this.txTextLanguage.TabIndex = 4;
      this.lblVoiceLanguage.AutoSize = true;
      this.lblVoiceLanguage.Location = new Point(153, 93);
      this.lblVoiceLanguage.Name = "lblVoiceLanguage";
      this.lblVoiceLanguage.Size = new Size(140, 13);
      this.lblVoiceLanguage.TabIndex = 7;
      this.lblVoiceLanguage.Text = "Speech Language (e.g. EN)";
      this.txVoiceLanguage.Location = new Point(153, 112);
      this.txVoiceLanguage.Name = "txVoiceLanguage";
      this.txVoiceLanguage.Size = new Size(135, 20);
      this.txVoiceLanguage.TabIndex = 6;
      this.btBrowseWCC_Lite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btBrowseWCC_Lite.Location = new Point(508, 67);
      this.btBrowseWCC_Lite.Name = "btBrowseWCC_Lite";
      this.btBrowseWCC_Lite.Size = new Size(75, 23);
      this.btBrowseWCC_Lite.TabIndex = 10;
      this.btBrowseWCC_Lite.Text = "Browse...";
      this.btBrowseWCC_Lite.UseVisualStyleBackColor = true;
      this.btBrowseWCC_Lite.Click += new EventHandler(this.btBrowseWCC_Lite_Click);
      this.lblWCC_Lite.AutoSize = true;
      this.lblWCC_Lite.Location = new Point(12, 51);
      this.lblWCC_Lite.Name = "lblWCC_Lite";
      this.lblWCC_Lite.Size = new Size(103, 13);
      this.lblWCC_Lite.TabIndex = 9;
      this.lblWCC_Lite.Text = "WCC_Lite.exe Path:";
      this.txWCC_Lite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txWCC_Lite.Location = new Point(12, 67);
      this.txWCC_Lite.Name = "txWCC_Lite";
      this.txWCC_Lite.Size = new Size(490, 20);
      this.txWCC_Lite.TabIndex = 8;
      this.btCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btCancel.DialogResult = DialogResult.Cancel;
      this.btCancel.Location = new Point(12, 172);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new Size(75, 23);
      this.btCancel.TabIndex = 11;
      this.btCancel.Text = "Cancel";
      this.btCancel.UseVisualStyleBackColor = true;
      this.cbFlowDiagram.AutoSize = true;
      this.cbFlowDiagram.Location = new Point(12, 139);
      this.cbFlowDiagram.Name = "cbFlowDiagram";
      this.cbFlowDiagram.Size = new Size(219, 17);
      this.cbFlowDiagram.TabIndex = 12;
      this.cbFlowDiagram.Text = "Show flow diagram tab (work in progress)";
      this.cbFlowDiagram.UseVisualStyleBackColor = true;
      this.cbFlowDiagram.CheckedChanged += new EventHandler(this.cbFlowDiagram_CheckedChanged);
      this.AcceptButton = (IButtonControl) this.btSave;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btCancel;
      this.ClientSize = new Size(596, 207);
      this.Controls.Add((Control) this.cbFlowDiagram);
      this.Controls.Add((Control) this.btCancel);
      this.Controls.Add((Control) this.btBrowseWCC_Lite);
      this.Controls.Add((Control) this.lblWCC_Lite);
      this.Controls.Add((Control) this.txWCC_Lite);
      this.Controls.Add((Control) this.lblVoiceLanguage);
      this.Controls.Add((Control) this.txVoiceLanguage);
      this.Controls.Add((Control) this.lblLanguage);
      this.Controls.Add((Control) this.txTextLanguage);
      this.Controls.Add((Control) this.btSave);
      this.Controls.Add((Control) this.btnBrowseExe);
      this.Controls.Add((Control) this.lblExecutable);
      this.Controls.Add((Control) this.txExecutablePath);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmSettings);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Settings";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
