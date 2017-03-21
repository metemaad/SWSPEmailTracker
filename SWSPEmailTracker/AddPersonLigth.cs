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
    public partial class AddPersonLigth : Form
    {
        public AddPersonLigth()
        {
            InitializeComponent();
        }

        private void AddPersonLigth_Load(object sender, EventArgs e)
        {

        }
        
        
        protected override void OnLoad(EventArgs e)
        {
            //if (Person==null)
            //{
            //    Person = new Person();
            //    Person.FamilyNameYomi = "New";
            //}
            //personInstantEdit1.savenew = true;
            //personInstantEdit1.CurrentPerson = Person;
            base.OnLoad(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            //var o = MessageBox.Show("Do you like to save?", "", MessageBoxButtons.YesNo);
            //if (o==System.Windows.Forms.DialogResult.Yes)
            //{
            //    Person = personInstantEdit1.CurrentPerson;
            //    Person.Persist();
            //    SWSPET.BL.Infrastructure.DataAccess.Flush();
            //}
            //else
            //{
            //    try
            //    {
            //        if (personInstantEdit1.savenew) Person.Delete();
            //    }
            //    catch(Exception exception)
            //    {
            //        MessageBox.Show("Person is a refrence");
            //    }
            //}
            
            base.OnClosed(e);
        }

        private void personInstantEdit1_Load(object sender, EventArgs e)
        {

        }
    }
}
