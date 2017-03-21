using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate.Linq;
using SWSPET.BL.Controls.WinControls;
using SWSPET.BL.Infrastructure;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Control
{
    public partial class ShowEmailUI : UiPart
    {
        public ShowEmailUI()
        {
            InitializeComponent();
            
        }
        private  void Updatedata()
        {
            if (ObjectInstance != null)
            {
                radLabel1.Text = ((IncommingEmail) ObjectInstance).Subject ?? string.Empty;
                radLabel5.Text = ((IncommingEmail)ObjectInstance).FromDesc ?? string.Empty;
                radLabel6.Text = ((IncommingEmail)ObjectInstance).BCCDescr?? string.Empty;
                radLabel7.Text = ((IncommingEmail)ObjectInstance).CCDescr ?? string.Empty;

                radButton1.Visible = ((IncommingEmail)ObjectInstance).From != null;
                radButton2.Visible = ((IncommingEmail)ObjectInstance).CC!= null;
                radButton3.Visible = ((IncommingEmail)ObjectInstance).BCC != null;
                webBrowser1.DocumentText = ((IncommingEmail)ObjectInstance).TextBody!=null ?((IncommingEmail)ObjectInstance).TextBody.Replace("img>", "p>").Replace("<img", "<P"):string.Empty;

                if (!string.IsNullOrEmpty(((IncommingEmail) ObjectInstance).HTMLBody))
                {
                    webBrowser1.DocumentText = ((IncommingEmail)ObjectInstance).HTMLBody.Replace("img>", "p>").Replace("<img", "<P");

                }
                var ps = DataAccess.NhSession;
                var ieu =
                    ps.Query<IncommingEmail>().Where(x => x.Id == ((IncommingEmail)ObjectInstance).Id)
                        .ToList();
                
                foreach (var incommingEmail in ieu)
                {
                    incommingEmail.IsRead = true;

                    incommingEmail.Persist(ps);
                }
                ps.Flush();
                
            }
        }

        private void radPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowEmailUI_Load(object sender, EventArgs e)
        {
            Updatedata();
        }

        private void commandBarButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void commandBarButton2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void RadButton1Click(object sender, EventArgs e)
        {
            personInstantEdit1.CurrentPerson = ((IncommingEmail) ObjectInstance).From;
            personInstantEdit1.Update();

        }

        private void radButton14_Click(object sender, EventArgs e)
        {
            var ps = DataAccess.NhSession;
            var ieu =
                ps.Query<IncommingEmail>().Where(x => x.Id == ((IncommingEmail)ObjectInstance).Id)
                    .ToList();

            foreach (var incommingEmail in ieu)
            {
                incommingEmail.IsRead = false;

                incommingEmail.Persist(ps);
            }
            ps.Flush();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            var ps = DataAccess.NhSession;
            var ieu =
                ps.Query<IncommingEmail>().Where(x => x.Id == ((IncommingEmail)ObjectInstance).Id)
                    .ToList();

            foreach (var incommingEmail in ieu)
            {
                incommingEmail.IsImportant = !((IncommingEmail)ObjectInstance).IsImportant;

                incommingEmail.Persist(ps);
            }
            ps.Flush();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            personInstantEdit1.CurrentPerson = ((IncommingEmail)ObjectInstance).CC.First();
            personInstantEdit1.Update();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            personInstantEdit1.CurrentPerson = ((IncommingEmail)ObjectInstance).CC.First();
            personInstantEdit1.Update();

        }

        private void personInstantEdit1_Load(object sender, EventArgs e)
        {

        }
    }
}
