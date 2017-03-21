using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate.Linq;
using SWSPET.BL.Infrastructure;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Control
{
    public partial class RecentContacts : UserControl
    {
        public RecentContacts()
        {
            InitializeComponent();
        }

        private void Recent_Contacts_Load(object sender, EventArgs e)
        {
            if (DataAccess.NhSession != null)
            {
                var l = DataAccess.NhSession.Query<Email>().OrderByDescending(x => x.CreateDate).Take(20);
                if (l != null)
                {
                    radGridView1.DataSource = l;
                }
            }
        }
    }
}
