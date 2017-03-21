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
    public partial class ContactGrid : UserControl
    {
        public event NewPersonHandler NewPerson;
        public EventArgs e = null;
        public delegate void NewPersonHandler(EventArgs e);

        public event EditPersonHandler EditPerson;
        
        public delegate void EditPersonHandler(Person person,EventArgs e);


        public ContactGrid()
        {
            InitializeComponent();
            updateGrid();
        }

        private void baseGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void updateGrid()
        {
            var l = DataAccess.NhSession.Query<Person>().ToList().Where(x=>x.Hasemail==true ).ToList();
            baseGridView1.InitilizeGrid(typeof(Person));
            baseGridView1.DataSource = l;
            toolStripStatusLabel2.Text = 100.ToString();
        }

        private void newPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new event

            if (NewPerson != null)
            {
                NewPerson( e);
            }
        }

        private void removePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //remove direct and update

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //edit event
            if (EditPerson!= null)
            {
                var a =(Person) baseGridView1.SelectedRows[0].DataBoundItem;
                EditPerson(a, e);
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            updateGrid(toolStripTextBox1.Text);
        }

        private void updateGrid(string s)
        {
            var l = DataAccess.NhSession.Query<Person>().ToList().
                Where(x=>x.Name.Contains(s) || x.FamilyName.Contains(s) || x.GivenName.Contains(s)).ToList();
            baseGridView1.InitilizeGrid(typeof(Person));
            baseGridView1.DataSource = l;
            toolStripStatusLabel2.Text = l.Count.ToString();
        }
    }
}
