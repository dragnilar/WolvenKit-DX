using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WolvenKit.Render
{
    public partial class RenderWindow : DevExpress.XtraEditors.XtraForm
    {
        public RenderWindow()
        {
            InitializeComponent();
            var renderer = new RendererControl();
            renderer.Dock = DockStyle.Fill;
            this.Controls.Add(renderer);
        }
    }
}