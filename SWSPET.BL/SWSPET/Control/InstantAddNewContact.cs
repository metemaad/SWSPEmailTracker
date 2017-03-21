using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SWSPET.BL.Infrastructure;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Control
{
    public partial class InstantAddNewContact : UserControl
    {
        public InstantAddNewContact()
        {
            InitializeComponent();
        }

        private void radTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (radTextBox2.Text.Contains('@'))
                {

                    var sp = radTextBox2.Text.Split('@');
                    radTextBox5.Text = "Http://www." + sp[1];
                }


            }
            catch (Exception exception)
            {
            }
        }

        private void radTextBox2_Leave(object sender, EventArgs e)
        {
            if (!radTextBox2.Text.Contains('@'))
            {
                MessageBox.Show("Please Check The email address. its not in Format.");
                
            }else
            {
                    var sp = radTextBox2.Text.Split('@');
                var tel = new Telnet("", 25, 30);
                bool a=tel.SearchMx(sp[0], sp[1]);
                radTextBox2.ForeColor = a ? Color.Green : Color.Red;

            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

            try
            {

                var person = new Person {GivenName = radTextBox1.Text};
                var email = new Email
                                {
                                    IsValid = true,
                                    Value = radTextBox2.Text,
                                    Type = "email",
                                    CreateDate = DateTime.Now
                                };
                person.Emails.Add(email);
                var web = new Website {Value = radTextBox5.Text};
                person.Websites.Add(web);
                var address = new Address {ExtendedAddress = radTextBox4.Text};

                person.Addresses.Add(address);
                var phone = new Phone {Value = radTextBox3.Text};
                person.Phones.Add(phone);
                person.Persist();
                MessageBox.Show("Saved." );
                radTextBox1.Text = "";
                radTextBox2.Text = "";
                radTextBox3.Text = "";
                radTextBox4.Text = "";
                radTextBox5.Text = "";

            }
            catch (Exception exception) {
                MessageBox.Show("Cant Save:" + exception.Message); }

        }
    }
}
