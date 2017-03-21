using System;
using System.Windows.Forms;

namespace SWSPET.BL.SWSPET.Control
{
    public partial class TextInsertForm : Form
    {
        private bool _accepted = false;

        public TextInsertForm(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
        }

        public string HTML
        {
            get { return textBox1.Text; }
        }

        public bool Accepted
        {
            get { return _accepted; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _accepted = true;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}