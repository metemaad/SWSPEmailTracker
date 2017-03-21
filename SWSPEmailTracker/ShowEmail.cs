using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SWSPET.BL.SWSPET.Model;

namespace SWSPEmailTracker
{
    public partial class ShowEmail : Form
    {
        public ShowEmail(IncommingEmail Iemail)
        
        {
            
            InitializeComponent();
            iemail = Iemail;
            showEmailUI1.ObjectInstance = iemail;
           
        }
        public IncommingEmail iemail { get; set; }
        private void ShowEmail_Load(object sender, EventArgs e)
        {
            

        }

        private void showEmailUI1_Load(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
