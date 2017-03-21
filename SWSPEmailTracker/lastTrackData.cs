using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate.Linq;
using Telerik.WinControls.UI;

namespace SWSPEmailTracker
{
    public partial class lastTrackData : Form
    {
        public lastTrackData()
        {
            InitializeComponent();
        }

        private void lastTrackData_Load(object sender, EventArgs e)
        {
            this.Text = "Loading Tracks....";
            Application.DoEvents();
            var p =
                SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<SWSPET.BL.SWSPET.Model.TrackData>().ToList().Where(
                    x => x.DateTime.AddDays(30) <= DateTime.Now).ToList().OrderBy(x=>x.DateTime).ToList();
            baseGridView1.InitilizeGrid(typeof(SWSPET.BL.SWSPET.Model.TrackData));
            baseGridView1.DataSource = p;

            var results = from tr in p
                          where tr.TrackID != null && tr.VisitorID != null
                          group tr by tr.TrackID.TrackTitle into g

                          orderby g.Key
                          select new
                          {
                              TrackName = g.Key,
                              Count = g.Count()
                          };
            radTreeView1.Nodes.Clear();
            foreach (var result in results)
            {
                var t1 = new RadTreeNode();
                t1.Name =result.TrackName+"("+result.Count+")";
                t1.Text = t1.Name;
                t1.Nodes.Clear();
                var rr = from tr in p
                         where tr.TrackID.TrackTitle==result.TrackName && tr.VisitorID!=null
                         group tr by tr.VisitorID.Descriptor into g

                         orderby g.Key
                         select new
                         {
                             Visitor = g.Key,
                             Count = g.Count()
                         };
                foreach (var VARIABLE in rr)
                {
                    var t2 = new RadTreeNode();
                    t2.Name = VARIABLE.Visitor + "(" + VARIABLE.Count + ")";
                    t2.Text = t2.Name;
                    var rr00 = from tr in p
                               where tr.TrackID.TrackTitle == result.TrackName && tr.VisitorID!=null && tr.VisitorID.Descriptor == VARIABLE.Visitor && tr.IP != null
                             select new
                             {
                                 IPdd = tr.IP,
                                 Datetime=tr.DateTime,
                                 
                             };
                    t2.Nodes.Clear();
                    foreach (var ddd in rr00)
                    {
                        var t3 = new RadTreeNode();
                        t3.Name =ddd.Datetime+"  : "+ ddd.IPdd.CountryCode+", "+ddd.IPdd.City+", "+ddd.IPdd.AreaCode+", "+ddd.IPdd.RegionName+":  "+ddd.IPdd.IP;
                        t3.Text = t3.Name;
                        t2.Nodes.Add(t3);
                    }
                    t1.Nodes.Add(t2);
                }
                radTreeView1.Nodes.Add(t1);
            }
            Application.DoEvents();
            this.Text = "Loaded";
        }
    }
}
