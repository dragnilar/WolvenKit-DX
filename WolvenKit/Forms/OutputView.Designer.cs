using System.ComponentModel;
using System.Windows.Forms;

namespace WolvenKit
{
    partial class OutputView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.txOutput = new DevExpress.XtraRichEdit.RichEditControl();
            this.SuspendLayout();
            // 
            // txOutput
            // 
            this.txOutput.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txOutput.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.txOutput.Location = new System.Drawing.Point(0, 0);
            this.txOutput.Name = "txOutput";
            this.txOutput.Options.Bookmarks.Visibility = DevExpress.XtraRichEdit.RichEditBookmarkVisibility.Hidden;
            this.txOutput.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.txOutput.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.txOutput.Size = new System.Drawing.Size(930, 259);
            this.txOutput.TabIndex = 1;
            this.txOutput.PopupMenuShowing += new DevExpress.XtraRichEdit.PopupMenuShowingEventHandler(this.txOutput_PopupMenuShowing);
            // 
            // OutputView
            // 
            this.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txOutput);
            this.Name = "OutputView";
            this.Size = new System.Drawing.Size(930, 259);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraRichEdit.RichEditControl txOutput;
    }
}