using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Commands;
using WeifenLuo.WinFormsUI.Docking;

namespace WolvenKit
{
    public partial class OutputView : XtraUserControl
    {
        public enum Logtype
        {
            Normal,
            Error,
            Important,
            Success,
            Wcc
        }

        public OutputView()
        {
            InitializeComponent();
        }

        public void AddText(string text, Logtype type = Logtype.Normal)
        {
            switch (type)
            {
                case Logtype.Error:
                    txOutput.AppendText(text, Color.DarkRed);
                    break;
                case Logtype.Important:
                    txOutput.AppendText(text, Color.DarkBlue);
                    break;
                case Logtype.Wcc:
                    txOutput.AppendText(text, Color.DarkOrchid);
                    break;
                case Logtype.Success:
                    txOutput.AppendText(text, Color.LimeGreen);
                    break;
                default:
                    txOutput.AppendText(text, Color.White);
                    break;
            }

            txOutput.ScrollToCaret();
        }

        internal void Clear()
        {
            txOutput.Text = string.Empty;
        }

        private void txOutput_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu != null)
            {
                e.Menu.RemoveMenuItem(RichEditCommandId.CreateBookmark);
                e.Menu.RemoveMenuItem(RichEditCommandId.ShowBookmarkForm);
                e.Menu.RemoveMenuItem(RichEditCommandId.CreateHyperlink);
                e.Menu.RemoveMenuItem(RichEditCommandId.NewCommentContentMenu);
            }
        }

        public void SaveDocument()
        {
            txOutput.SaveDocumentAs();
        }

        public void ClearDocument()
        {
            Clear();
        }
    }

    public static class RichTextEditExtensions
    {
        public static void AppendText(this RichEditControl box, string text, Color color)
        {
            var document = box.Document;
            var documentPosition = document.Selection.Start;
            document.BeginUpdate();
            document.InsertText(documentPosition, "[" + DateTime.Now.ToString("G") + "]: " + text);
            var documentRange = box.Document.CreateRange(document.Selection.Start, text.Length);
            var characterProperties = box.Document.BeginUpdateCharacters(documentRange);
            characterProperties.ForeColor = color;
            box.Document.EndUpdateCharacters(characterProperties);
            document.EndUpdate();
            
        }
    }
}