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
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace SWSPET.BL.SWSPET.Control
{
    public partial class PersonUI : UserControl, IUiPart
    {
        public event SavePersonHandler SavePerson;
        public EventArgs e = null;
        public delegate void SavePersonHandler(EventArgs e);
        public PersonUI()
        {
            InitializeComponent();
        }

        private void Loadsearchparam()
        {
            var dic = new Dictionary<string, object>();


            var cat0 = DataAccess.NhSession.Query<Person>().ToList();
            var cat = cat0.Select(x => x.GroupMembership).Distinct().ToList();
            foreach (var a in cat)
            {
                try
                {
                    string[] sa = { ":::" };
                    var sp = a.Split(sa, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var s in sp.Where(s => !dic.ContainsKey(s.Trim())))
                    {
                        dic.Add(s.Trim(), s.Trim());
                    }
                }
                catch (Exception exception)
                {
                }


            }
            

            radListView1.DataSource = dic;
            foreach (var item in radListView1.Items)
            {
                if (((Person)ObjectInstance).GroupMembership.Contains(item.Text))
                {
                    item.CheckState = ToggleState.On;
                }
            }
        }
        public object ObjectInstance
        {
            get { return bindingSource1.DataSource; }
            set { bindingSource1.DataSource = value; }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (SavePerson != null)
            {
                var grp = radListView1.Items.Where(variable => variable.CheckState == ToggleState.On).Aggregate("", (current, variable) => current + (" ::: " + variable.Text));
                ((Person) ObjectInstance).GroupMembership = grp;
                SavePerson(e);
            }
        }

        private void PersonUI_Load(object sender, EventArgs e)
        {
            baseGridView1.InitilizeGrid(typeof(Email));
            var a = ((Person) ObjectInstance).Emails;
            baseGridView1.DataSource = a;

            Loadsearchparam();
        }
    }
}
