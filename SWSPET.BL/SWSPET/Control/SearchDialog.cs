using System;
using System.Windows.Forms;

namespace SWSPET.BL.SWSPET.Control
{
    public partial class SearchDialog : Form
    {
        private readonly SearchableBrowser _browser;
        private static string _last = null;

        public SearchDialog(SearchableBrowser browser)
        {
            _browser = browser;
            InitializeComponent();
            downButton.Checked = true;
            searchString.Text = _last;
            findButton.Enabled = searchString.Text.Length > 0;
            Disposed += new EventHandler(SearchDialog_Disposed);
            searchString.TextChanged += new EventHandler(searchString_TextChanged);
        }

        private void searchString_TextChanged(object sender, EventArgs e)
        {
            findButton.Enabled = searchString.Text.Length > 0;
        }

        private void SearchDialog_Disposed(object sender, EventArgs e)
        {
            _last = searchString.Text;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if (!_browser.Search(searchString.Text, downButton.Checked, matchWholeWord.Checked, matchCase.Checked))
            {
                MessageBox.Show(this, "Finished searching the document.", "Explorer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

   
}