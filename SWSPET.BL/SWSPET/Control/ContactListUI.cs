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
    public partial class ContactListUI : UserControl
    {
        public ContactListUI()
        {
            InitializeComponent();
        }

        private void ContactListUI_Load(object sender, EventArgs e)
        {
            Updatedata();
        }

        private void Updatedata()
        {
            var a = new ContactGrid {Dock = DockStyle.Fill};
            a.NewPerson += a_NewPerson;
            a.EditPerson += a_EditPerson;
            
            this.radPanel1.Controls.Clear();
            this.radPanel1.Controls.Add(a);
        }

        void a_EditPerson(Person person, EventArgs e)
        {
            var a = new PersonUI {Dock = DockStyle.Fill, ObjectInstance = person};
            a.SavePerson += a_SavePerson;

            radPanel1.Controls.Clear();
            radPanel1.Controls.Add(a);
        }

        void a_SavePerson(EventArgs e)
        {
            Updatedata();
        }

        void a_NewPerson(EventArgs e)
        {
            var a = new PersonUI();

            radPanel1.Controls.Clear();
            radPanel1.Controls.Add(a);

        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
