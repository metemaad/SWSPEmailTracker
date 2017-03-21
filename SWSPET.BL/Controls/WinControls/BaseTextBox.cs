using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SWSPET.BL.Controls.WinControls
{
    public partial class BaseTextBox : TextBox
    {
        private string _tooltip;

        public BaseTextBox()
        {
            InitializeComponent();
        }

        public string ToolTip
        {
            get { return _tooltip; }
            set { _tooltip = value; toolTip1.SetToolTip(this, _tooltip); }
        }
       
    }
}
