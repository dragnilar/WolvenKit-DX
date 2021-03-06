﻿using System.Windows.Forms;
using WolvenKit.CR2W.Types;

namespace WolvenKit.Views
{
    public partial class frmAddVariable : Form
    {
        public frmAddVariable()
        {
            InitializeComponent();

            var mng = CR2WTypeManager.Get();

            var types = mng.AvailableTypes;
            types.Sort();

            txType.Items.AddRange(types.ToArray());
        }

        public string VariableName
        {
            get => txName.Text;
            set => txName.Text = value;
        }

        public string VariableType
        {
            get => txType.Text;
            set => txType.Text = value;
        }
    }
}