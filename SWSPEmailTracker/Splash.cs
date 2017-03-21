using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate.Linq;
using SWSPEmailTracker.web.Infrastructure;
using SWSPET.BL.SWSPET.Model;

namespace SWSPEmailTracker
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            
            Application.DoEvents();
            this.Visible = true;
            Application.DoEvents();
            progressBar1.Value = 10;

            Application.DoEvents();
            var a = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<Person>().ToList();
            progressBar1.Value = 40; Application.DoEvents();
            var b = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<IncommingEmail>().ToList();
            progressBar1.Value = 60; Application.DoEvents();
            //var linkTrack=new web.SWSPETl.Model.LinkTrack();
            //var c = linkTrack.LoadAll();
            progressBar1.Value = 80; Application.DoEvents();
            var o = new MainForm();
            this.Visible = false;
            o.ShowDialog();
        }
        
        //40x40x12 uv4 ArgumentOutOfRangeException 3200 1000ta
//        roye dar chap
//vazn 7,450
//     1,200
//        3770
//        2tike


    }
}
