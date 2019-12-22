namespace WolvenKit.Forms
{
    partial class BufferEditorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chunkListEditorControl = new WolvenKit.Controls.ChunkListEditor();
            this.SuspendLayout();
            // 
            // chunkListEditorControl
            // 
            this.chunkListEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chunkListEditorControl.File = null;
            this.chunkListEditorControl.Location = new System.Drawing.Point(0, 0);
            this.chunkListEditorControl.Name = "chunkListEditorControl";
            this.chunkListEditorControl.Size = new System.Drawing.Size(971, 764);
            this.chunkListEditorControl.TabIndex = 0;
            // 
            // BufferEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 764);
            this.Controls.Add(this.chunkListEditorControl);
            this.IconOptions.Image = global::WolvenKit.Properties.Resources.wkdxicon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BufferEditorView";
            this.Text = "Buffer Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ChunkListEditor chunkListEditorControl;
    }
}