using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate.Linq;
using SWSPEmailTracker.Properties;
using SWSPET.BL.Infrastructure;
using SWSPET.BL.SWSPET.Model;

namespace SWSPEmailTracker
{
    public partial class PersonTrack : Form
    {
        public PersonTrack()
        {
            InitializeComponent();
        }

        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            var email = DataAccess.NhSession.Query<Email>().Where(x => x.Value == toolStripTextBox1.Text).ToList();
            if (email.Count > 0)
            {
                
                var person = email.First().Person;
                var i = DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.Sender == person).ToList();
                var id = (from c in i select new {dat = c.SentDate, txt = c.Subject + "" + c.TextBody}).ToList();
                var vendlist = id.Select(variable => new TraksLlll {dat = variable.dat, txt = variable.txt}).ToList();
                var o = DataAccess.NhSession.Query<OutgoingEmail>().Where(x => x.Recipient == person).ToList();
                var od = (from c in o select new {dat = c.SentDate, txt = c.Subject + "" + c.BodyPlain}).ToList();
                vendlist.AddRange(od.Select(variable => new TraksLlll {dat = variable.dat, txt = variable.txt}));
                var t = DataAccess.NhSession.Query<TrackData>().Where(x => x.VisitorID == person).ToList();
                var td = (from c in t
                         select
                             new {dat = c.DateTime, txt = c.IP.RegionName + " " + c.IP.IP + " " + c.TrackID.TrackTitle}).ToList();
                vendlist.AddRange(td.Select(variable => new TraksLlll {dat = variable.dat, txt = variable.txt}));

                var f = vendlist.OrderBy(x => x.dat).ToList();
                radLabel1.Text = "";
                foreach (var variable in f)
                {
                    radLabel1.Text += variable.dat.ToString() + Resources.NewLine;
                    radLabel1.Text += variable.txt + Resources.NewLine;
                    radLabel1.Text += Resources.NewLine;

                }


            }
        }
        public class TraksLlll
        {
            public DateTime dat { get; set; }
            public String txt { get; set; }
            
        }

        private void PersonTrack_Load(object sender, EventArgs e)
        {

        }
    }
}
