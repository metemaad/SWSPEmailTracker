using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate.Linq;
using SWSPEmailTracker.web.SWSPETl.Model;

namespace SWSPEmailTracker
{
    public partial class LinkTemplateManager : Form
    {
        private IList<LinkTrack> _f;

        public LinkTemplateManager()
        {
            InitializeComponent();
        }

        private void LinkTemplateManager_Load(object sender, EventArgs e)
        {
            UpdateData();
        }
        private void UpdateData()
        {
            Application.DoEvents();
            var fff = new LinkTrack();
            _f = fff.LoadAll();
                //SWSPEmailTracker.web.Infrastructure.DataAccess.NhSession.Query<SWSPEmailTracker.web.SWSPETl.Model.LinkTrack>().ToList();

            toolStripComboBox1.ComboBox.DataSource = _f;
            toolStripComboBox1.ComboBox.DisplayMember = "Descriptor";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var fwa =new web.SWSPETl.Model.LinkTrack();
            var fw=fwa.LoadAll();
               //SWSPEmailTracker.web.Infrastructure.DataAccess.NhSession.Query
               //    <SWSPEmailTracker.web.SWSPETl.Model.LinkTrack>().ToList();
            var fs = fw.Where(x => x.TrackTitle == textBox1.Text).ToList();
            if (fs.Count > 0)
            {
                var o = MessageBox.Show(textBox1.Text + " Link track is in your server database. do you like to update that track?", "", MessageBoxButtons.YesNo);
                if (o == DialogResult.Yes)
                {
                    var a = fs.First();
                    a.Title = textBox1.Text;

                    a.TrackDest = textBox2.Text;
                    a.Update();
                    //search in local
                    var local =
                        SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<SWSPET.BL.SWSPET.Model.LinkTrack>().Where(
                            x => x.ServerTrackID == a.Id.ToString()).ToList();
                    if (local.Count > 0)
                    {
                        var b = local.First();

                        b.Title = a.Title;
                        b.TrackDest = textBox2.Text;
                        b.ServerTrackID = a.LocalID.ToString();
                        b.Persist();
                    }
                    else
                    {
                        var b = new SWSPET.BL.SWSPET.Model.LinkTrack()
                        {
                            Title = a.Title,
                            TrackDest = textBox2.Text,
                            ServerTrackID = a.LocalID.ToString()
                        };
                        b.Persist();
                    }

                    MessageBox.Show("Updated.");
                }
            }
            else
            {
                var a = new web.SWSPETl.Model.LinkTrack()
                {
                    Title = textBox1.Text,
                    TrackDest = textBox2.Text
                };
                a.Persist();

                var local =
                       SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<SWSPET.BL.SWSPET.Model.LinkTrack>().Where(
                           x => x.ServerTrackID == a.Id.ToString()).ToList();
                if (local.Count > 0)
                {
                    var b = local.First();

                    b.Title = a.Title;
                    b.TrackDest = textBox2.Text;
                    b.ServerTrackID = a.LocalID.ToString();
                    b.Persist();
                }
                else
                {
                    var b = new SWSPET.BL.SWSPET.Model.LinkTrack()
                    {
                        Title = a.Title,
                TrackDest = textBox2.Text,
                        ServerTrackID = a.LocalID.ToString()
                    };
                    b.Persist();
                }

                MessageBox.Show("Inserted.");
            }
            UpdateData();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var fj = (LinkTrack)toolStripComboBox1.ComboBox.SelectedItem;

            textBox1.Text = fj.Title;
            textBox2.Text = fj.TrackDest;
        }
    }
}
