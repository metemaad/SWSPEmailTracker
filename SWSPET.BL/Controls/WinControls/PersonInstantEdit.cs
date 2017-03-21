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

namespace SWSPET.BL.Controls.WinControls
{
    public partial class PersonInstantEdit : UserControl
    {
        public Person CurrentPerson { get; set; }
        public void Update()
        {
            ShowInUI();
            

        }

        public PersonInstantEdit()
        {
            InitializeComponent();
        }

        private void SaveBTN(object sender, EventArgs e)
        {

            CurrentPerson.GivenName = textBox1.Text;
            CurrentPerson.FamilyName = textBox2.Text;
            var s = textBox3.Text.Split(';');
            CurrentPerson.Emails.Clear();

            foreach (var s1 in s)
            {
                
                if (string.IsNullOrEmpty(s1))
                {
                    //if (!CurrentPerson.Emails.Contains(phone.Person) && (phone.Person != null))
                    CurrentPerson.Emails.Add(new Email()
                                                 {
                                                     Person = CurrentPerson,
                                                     Value = s1,
                                                     CreateDate = DateTime.Now,
                                                     IsPrimery = true,
                                                     IsValid = true
                                                 });
                }
            }
            var d = textBox4.Text.Split(';');
            CurrentPerson.Phones.Clear();

            foreach (var s1 in d)
            {
                CurrentPerson.Phones.Add(new Phone() { Person = CurrentPerson, Value = s1 });
            }


            var es = textBox5.Text.Split(';');
            CurrentPerson.Websites.Clear();

            foreach (var s1 in es)
            {
                CurrentPerson.Websites.Add(new Website() { Value = s1 });

            }
            var f = textBox6.Text.Split(';');
            CurrentPerson.Addresses.Clear();

            foreach (var s1 in f)
            {
                var fa = s1.Split(',');
                //"No:" + POBox + "," + Street + "St." + "," + City + "," + Country + "," + ExtendedAddress + "PostalCode:" + PostalCode;
                CurrentPerson.Addresses.Add(new Address()
                {
                    POBox = fa.Length >= 1 ? fa[0].Replace("No:", "") : "",
                    Street = fa.Length >= 2 ? fa[1].Replace("St.", "") : "",
                    City = fa.Length >= 3 ? fa[2] : "",
                    Country = fa.Length >= 4 ? fa[3] : "",
                    ExtendedAddress = fa.Length >= 5 ? fa[4] : "",
                    PostalCode = fa.Length >= 6 ? fa[5].Replace("PostalCode:", "") : ""
                });
            }


            // var ehho = new Organization{ Person = CurrentPerson,Department = email.Department,Type=email.Type,JobDescription=email.JobDescription,Location = email.Location,Name=email.Name,Symbol=email.Symbol};

            var fo = textBox7.Text.Split(';');
            CurrentPerson.Organizations.Clear();

            foreach (var s1 in fo)
            {
                var fa = s1.Split(',');
                //"JobDescription,Name,Location,Department,Symbol,Title
                CurrentPerson.Organizations.Add(new Organization
                {
                    JobDescription = fa.Length >= 1 ? fa[0] : "",
                    Name = fa.Length >= 1 ? fa[1] : "",
                    Location = fa.Length >= 1 ? fa[2] : "",
                    Person = CurrentPerson,
                    Department = fa.Length >= 1 ? fa[3] : "",
                    Symbol = fa.Length >= 1 ? fa[4] : "",
                    Title = fa.Length >= 1 ? fa[5] : ""
                });
            }
            CurrentPerson.Persist();
            DataAccess.Flush();
            MessageBox.Show("Saved.");
        }
        private void FindSimilar()
        {
            var similarPerson=new List<Person>();
            if( (textBox1.TextLength > 0)&& !(textBox2.TextLength > 0))
            {
                var a =
                    DataAccess.NhSession.Query<Person>().Where(
                        x => x.GivenName.Contains(textBox1.Text) ).ToList();
                foreach (var person in a.Where(person => !similarPerson.Contains(person) && (person != null)))
                {
                    similarPerson.Add(person);
                }
            }
            if ((textBox2.TextLength > 0) && !(textBox1.TextLength > 0))
            {
                var a =
                    DataAccess.NhSession.Query<Person>().Where(
                        x=>x.FamilyName.Contains(textBox2.Text)
                        ).ToList();
                foreach (var person in a.Where(person => !similarPerson.Contains(person) && (person != null)))
                {
                    similarPerson.Add(person);
                }
            }
            if ((textBox2.TextLength > 0) && (textBox1.TextLength > 0))
            {
                var a =
                    DataAccess.NhSession.Query<Person>().Where(
                       
                        x => x.GivenName.Contains(textBox1.Text) && x.FamilyName.Contains(textBox2.Text)
                        ).ToList();
                foreach (var person in a.Where(person => !similarPerson.Contains(person) && (person != null)))
                {
                    similarPerson.Add(person);
                }
            }
            if (textBox4.Text.Length > 0)
            {
                var spphone = textBox4.Text.Split(';');
                foreach (var s in spphone)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        var b = DataAccess.NhSession.Query<Phone>().Where(x => x.Value.Contains(s)).ToList();
                        foreach (var phone in b)
                        {
                            if (!similarPerson.Contains(phone.Person) && (phone.Person != null))
                                similarPerson.Add(phone.Person);
                        }
                    }
                }
            }
            if (textBox3.Text.Length > 0)
            {
                var spemail = textBox3.Text.Split(';');
                foreach (var s in spemail)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        var b = DataAccess.NhSession.Query<Email>().Where(x => x.Value.Contains(s)).ToList();
                        foreach (var email in b)
                        {
                            if (!similarPerson.Contains(email.Person)&&(email.Person!=null))
                                similarPerson.Add(email.Person);

                        }
                    }

                }
            }
            
            checkedListBox1.DataSource = similarPerson;
            checkedListBox1.DisplayMember = "Descriptor";
            //checkedListBox1.ValueMember = "Id";
            Application.DoEvents();
            MessageBox.Show("");
            radButton3.Text = checkedListBox1.Items.Count.ToString();
            
            for (var i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
            Application.DoEvents();
            
        }

        private void RadButton1Click(object sender, EventArgs e)
        {
            var d = DataAccess.NhSession.Query<Phone>().ToList().Where(x => x.Value.Contains(textBox4.Text)).ToList();
            if (d.Count>0)
            {
                string s = d.First().Person == null ? d.First().Person.Descriptor : "Blank";
                var o = MessageBox.Show("Do you like to use old info:"+s, "", MessageBoxButtons.YesNo);
                if (d.First().Person != null)
                {
                   
                    textBox1.Text = d.First().Person.GivenName;
                    textBox1.Text = d.First().Person.FamilyName;
                    textBox3.Text = "";
                    foreach (var email in d.First().Person.Emails)
                    {
                        textBox3.Text += email.Value + ";";
                    }
                    var tmp=textBox4.Text;
                    textBox4.Text = "";
                    foreach (var phone in d.First().Person.Phones)
                    {
                        textBox4.Text += phone.Value + ";";
                    }
                    textBox4.Text += tmp;
                    textBox5.Text = "";
                    foreach (var website in d.First().Person.Websites)
                    {
                        textBox5.Text += website.Value + ";";
                    }
                }
            }else
            {
                MessageBox.Show("Not found");
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            savenew = false;
            FindSimilar();
            Application.DoEvents();
        }

        public bool savenew = false;
        private void RadButton5Click(object sender, EventArgs e)
        {
            //MessageBox.Show([color="#2E8B57"]textBox.Tag[/color] + " must be a decimal number.", Title);
				
            CurrentPerson=new Person();
            CurrentPerson.GivenName = textBox1.Text;
            CurrentPerson.FamilyName = textBox2.Text;
            CurrentPerson.Emails.Clear();
            CurrentPerson.Phones.Clear();
            CurrentPerson.Persist();

            var chkp = checkedListBox1.CheckedItems;
            foreach (var checkedItem in chkp)
            {
                
                
                var p=(Person) checkedItem;
                
                if (p.GivenName != null)
                    if (CurrentPerson.GivenName.Length < p.GivenName.Length) {
                        CurrentPerson.GivenName = p.GivenName; }
                if (p.FamilyName != null)
                    if (CurrentPerson.FamilyName.Length < p.FamilyName.Length)
                    {
                        CurrentPerson.FamilyName = p.FamilyName;
                    }

                foreach (var phone in p.Phones)
                {
                    if (!(CurrentPerson.Phones.Where(x => x.Value.Contains(phone.Value)).ToList().Count > 0))
                    {
                        var phh = new Phone {Person = CurrentPerson, Value = phone.Value, Type = phone.Type};
                        phh.Persist();
                        var g = CurrentPerson.Phones.Where(x => x.Value==phone.Value).ToList();
                        if (g.Count <= 0)
                        {
                            CurrentPerson.Phones.Add(phh);
                        }
                    }
                }
                foreach (var email in p.Emails)
                {
                    if (!(CurrentPerson.Emails.Where(x => x.Value==email.Value).ToList().Count > 0))
                    {
                        var ehh = new Email {Person = CurrentPerson, Value = email.Value, Type = email.Type};
                        ehh.Persist();
                        //if not contain 
                        CurrentPerson.Emails.Add(ehh);
                    }
                }

                foreach (var email in p.Websites)
                {
                    if (!(CurrentPerson.Emails.Where(x => x.Value==email.Value).ToList().Count > 0))
                    {
                        var ehhw = new Website { Person = CurrentPerson, Value = email.Value, Type = email.Type };
                        ehhw.Persist();
                        //if not contain 
                        CurrentPerson.Websites.Add(ehhw);
                    }
                }

                foreach (var email in p.Organizations)
                {
                    if (!(CurrentPerson.Emails.Where(x => x.Descriptor == email.Descriptor).ToList().Count > 0))
                    {
                        var ehho = new Organization{ Person = CurrentPerson,Department = email.Department,
                            Type=email.Type
                            ,JobDescription=email.JobDescription,Location = email.Location,Name=email.Name,Symbol=email.Symbol};
                        ehho.Persist();
                        //if not contain 
                        CurrentPerson.Organizations.Add(ehho);
                    }
                }


                foreach (var email in p.Addresses)
                {
                    if (!(CurrentPerson.Addresses.Where(x => x.Descriptor == email.Descriptor).ToList().Count > 0))
                    {
                        var ehhA = new Address
                                       {
                                           Person = CurrentPerson,City=email.City,Country=email.Country,Type=email.Type,ExtendedAddress =email.ExtendedAddress
                                           ,Formatted = email.Formatted,POBox = email.POBox,PostalCode =email.PostalCode
                                       };
                        ehhA.Persist();
                        //if not contain 
                        CurrentPerson.Addresses.Add(ehhA);
                    }
                }
                string [] sp = {":::"};
                if (CurrentPerson.GroupMembership==null)
                {
                    CurrentPerson.GroupMembership = "";
                }
                var grp = CurrentPerson.GroupMembership.Split(sp,StringSplitOptions.RemoveEmptyEntries);
                var extgrp = "";
                if (p.GroupMembership == null)
                {
                    p.GroupMembership = "";
                }
                var pgrp = p.GroupMembership.Split(sp,StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in pgrp)
                {
                    if (!grp.Contains(s))
                    {
                        extgrp += s + ":::";
                    }
                }
                extgrp += CurrentPerson.GroupMembership;
                CurrentPerson.GroupMembership = extgrp;
                CurrentPerson.Persist();

                var trackdata = DataAccess.NhSession.Query<TrackData>().Where(x => x.VisitorID == p).ToList();
                foreach (var trackData in trackdata)
                {
                    trackData.VisitorID = CurrentPerson;
                    trackData.Persist();

                }
                var incommail = DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.From == p).ToList();
                foreach (var trackData in incommail)
                {
                    trackData.From = CurrentPerson;
                    trackData.Persist();

                }



                var sincommail = DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.Sender == p).ToList();
                foreach (var trackData in sincommail)
                {
                    trackData.Sender = CurrentPerson;
                    trackData.Persist();

                }

                var rtincommail = DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.ReplayTo == p).ToList();
                foreach (var trackData in rtincommail)
                {
                    trackData.ReplayTo = CurrentPerson;
                    trackData.Persist();

                }

                var rpincommail = DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.ReturnPath == p).ToList();
                foreach (var trackData in rpincommail)
                {
                    trackData.ReturnPath = CurrentPerson;
                    trackData.Persist();

                }




                var tommail = DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.TO.Contains(p)).ToList();
                foreach (var trackData in tommail)
                {
                    if (trackData.TO.Contains(p))
                    {
                        trackData.TO.Add(CurrentPerson);
                        trackData.TO.Remove(p);
                    }
                    

                    trackData.Persist();
                }

                var bccmmail = DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.BCC.Contains(p)).ToList();
                foreach (var trackData in bccmmail)
                {
                    if (trackData.BCC.Contains(p))
                    {
                        trackData.BCC.Add(CurrentPerson);
                        trackData.BCC.Remove(p);
                    }
                    

                    trackData.Persist();
                }
                var ccmmail = DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.CC.Contains(p)).ToList();
                foreach (var trackData in ccmmail)
                {
                    if (trackData.CC.Contains(p))
                    {
                        trackData.CC.Add(CurrentPerson);
                        trackData.CC.Remove(p);
                    }
                    
                    trackData.Persist();
                }

                var outmail = DataAccess.NhSession.Query<OutgoingEmail>().Where(x => x.Recipient == p).ToList();
                foreach (var trackData in outmail)
                {
                    trackData.Recipient = CurrentPerson;
                    trackData.Persist();

                }
                p.Delete();

                
              
            }
            //foreach (var variable in chkp)
            //{
            //    var p = ((Person)variable);
            //    p.Delete();
            //}
            DataAccess.Flush();
            ShowInUI();
            checkedListBox1.DataSource=null;
            checkedListBox1.Items.Clear();
            MessageBox.Show("Merged");
           // FindSimilar();
        }

        private void ShowInUI()
        {
            if (CurrentPerson != null)
            {

                var trackdata =
                    DataAccess.NhSession.Query<TrackData>().Where(x => x.VisitorID == CurrentPerson).ToList();
                label10.Text = "TrackData:" + trackdata.Count;
                label10.Text += "\r\n";
                var incommail =
                    DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.From == CurrentPerson).ToList();
                label10.Text += "inbox From:" + incommail.Count;
                label10.Text += "\r\n";


                var sincommail =
                    DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.Sender == CurrentPerson).ToList();
                label10.Text += "inbox Sender:" + sincommail.Count;
                label10.Text += "\r\n";
                var rtincommail =
                    DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.ReplayTo == CurrentPerson).ToList();
                label10.Text += "inbox ReplayTo:" + rtincommail.Count;
                label10.Text += "\r\n";
                var rpincommail =
                    DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.ReturnPath == CurrentPerson).ToList();
                label10.Text += "inbox ReturnPath:" + rpincommail.Count;
                label10.Text += "\r\n";


                var tommail =
                    DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.TO.Contains(CurrentPerson)).ToList();
                label10.Text += "inbox TO:" + tommail.Count;
                label10.Text += "\r\n";
                var bccmmail =
                    DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.BCC.Contains(CurrentPerson)).ToList();
                label10.Text += "inbox BCC:" + bccmmail.Count;
                label10.Text += "\r\n";
                var ccmmail =
                    DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.CC.Contains(CurrentPerson)).ToList();
                label10.Text += "inbox CC:" + ccmmail.Count;
                label10.Text += "\r\n";
                var outmail =
                    DataAccess.NhSession.Query<OutgoingEmail>().Where(x => x.Recipient == CurrentPerson).ToList();
                label10.Text += "outbox Recipient:" + outmail.Count;
                label10.Text += "\r\n";

                textBox1.Text = CurrentPerson.GivenName;
                textBox2.Text = CurrentPerson.FamilyName;
                textBox3.Text = "";
                foreach (var email in CurrentPerson.Emails)
                {
                    textBox3.Text += email.Value + ";";
                }

                textBox4.Text = "";
                foreach (var email in CurrentPerson.Phones)
                {
                    textBox4.Text += email.Value + ";";
                }

                textBox6.Text = "";
                foreach (var email in CurrentPerson.Addresses)
                {
                    textBox6.Text += email.Descriptor + ";";
                }
                textBox7.Text = "";
                foreach (var email in CurrentPerson.Organizations)
                {
                    textBox7.Text += email.Descriptor + ";";
                }
                textBox8.Text = "";
                foreach (var email in CurrentPerson.Websites)
                {
                    textBox8.Text += email.Value + ";";
                }
            }else
            {
                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
                textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = ""; textBox8.Text = "";
            }
        }

        private void CheckedListBox1SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void checkedListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            savenew = false;
                CurrentPerson = (SWSPET.Model.Person)checkedListBox1.SelectedItem;
            ShowInUI();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            if (CurrentPerson==null)
            {
                CurrentPerson=new Person();
            }
            SaveBTN(sender, e);
        }

        private void baseTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
