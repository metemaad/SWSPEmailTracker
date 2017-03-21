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
using SWSPET.BL.Infrastructure;
using SWSPET.BL.SWSPET.Model;
using SWSPVCard;

namespace SWSPEmailTracker
{
    public partial class ImportContact : Form
    {
        public ImportContact()
        {
            InitializeComponent();

        }

        private void radRepeatButton1_Click(object sender, EventArgs e)
        {

            //DataAccess.UpdateDatabase();
            //var t = new TrackData {DateTime = DateTime.Now, TrackID = "iiii", VisitorID = "mjj", VisitorIP = "9.0.9.0",SessionID = "eee"};
            //t.Persist();
            //var ps = DataAccess.NhSession.Query<TrackData>().ToList();

            var persons = DataAccess.NhSession.Query<Person>().ToList();

            if (openFileDialog1.ShowDialog() != DialogResult.None)
            {



                string path = openFileDialog1.FileName;

                var sr = new StreamReader(path);
                int i = 0;

                var emails = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<Email>().ToList();
                var emaildic = new Dictionary<string, object>();
                foreach (var email in emails)
                {
                    if (emaildic.ContainsKey(email.Value.Trim()) == false)
                    {
                        emaildic.Add(email.Value.Trim(), email.Value.Trim());
                    }
                }
                SWSPET.BL.Infrastructure.DataAccess.Flush();
                bool firstrow = true;
                while (sr.EndOfStream == false)
                {

                    var cl = sr.ReadLine();
                    if (firstrow)
                    {
                        firstrow = false;
                        continue;
                    }

                    if (cl != null)
                    {

                        var s = cl.Split(',');
                        string e1 = Str(s, 28).Trim();
                        string e2 = Str(s, 30).Trim();

                        if ((emaildic.ContainsKey(e1) && emaildic.ContainsKey(e2)) || (string.IsNullOrEmpty(e1) && string.IsNullOrEmpty(e2)))
                        {

                            i++;
                            radRepeatButton1.Text = i.ToString();
                            Application.DoEvents();
                            continue;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(e1) && !emaildic.ContainsKey(e1)) { emaildic.Add(e1.ToString(), e1); }
                            if (!string.IsNullOrEmpty(e2) && !emaildic.ContainsKey(e2)) { emaildic.Add(e2.ToString(), e2); }
                        }


                        var person = new Person
                                         {
                                             Name = Str(s, 0),
                                             GivenName = Str(s, 1),
                                             AdditionalName = Str(s, 2),
                                             FamilyName = Str(s, 3),
                                             YomiName = Str(s, 4),
                                             GivenNameYomi = Str(s, 5),
                                             AdditionalNameYomi = Str(s, 6),
                                             FamilyNameYomi = Str(s, 7),
                                             NamePrefix = Str(s, 8),
                                             NameSuffix = Str(s, 9),
                                             Initials = Str(s, 10),
                                             Nickname = Str(s, 11),
                                             ShortName = Str(s, 12),
                                             MaidenName = Str(s, 13),
                                             Birthday = Str(s, 14),
                                             Gender = Str(s, 15),
                                             Location = Str(s, 16),
                                             BillingInformation = Str(s, 17),
                                             DirectoryServer = Str(s, 18),
                                             Mileage = Str(s, 19),
                                             Occupation = Str(s, 20),
                                             Hobby = Str(s, 21),
                                             Sensitivity = Str(s, 22),
                                             Priority = Str(s, 23),
                                             Subject = "1",// Str(s, 24),
                                             Notes = Str(s, 25),
                                             GroupMembership = Str(s, 26)
                                         };
                        // Str(s, 0);
                        person.Emails.Clear();
                        if (String.IsNullOrEmpty(Str(s, 28)) == false)
                        {
                            person.Emails.Add(new Email { Type = Str(s, 27), Value = Str(s, 28) });
                            if (emaildic.ContainsKey(e1) == false)
                            {
                                emaildic.Add(e1, e1);
                            }


                        }
                        if (String.IsNullOrEmpty(Str(s, 30)) == false)
                        {
                            person.Emails.Add(new Email { Type = Str(s, 29), Value = Str(s, 30) });
                            if (emaildic.ContainsKey(e2) == false)
                            {
                                emaildic.Add(e2, e2);
                            }
                        }
                        person.IMs.Clear();
                        if (String.IsNullOrEmpty(Str(s, 33)) == false)
                        {
                            person.IMs.Add(new IM { Type = Str(s, 31), Service = Str(s, 32), Value = Str(s, 33) });
                        }
                        person.Phones.Clear();
                        if (String.IsNullOrEmpty(Str(s, 35)) == false)
                        {
                            person.Phones.Add(new Phone { Type = Str(s, 34), Value = Str(s, 35) });
                        }
                        if (String.IsNullOrEmpty(Str(s, 37)) == false)
                        {
                            person.Phones.Add(new Phone { Type = Str(s, 36), Value = Str(s, 37) });
                        }
                        if (String.IsNullOrEmpty(Str(s, 39)) == false)
                        {
                            person.Phones.Add(new Phone { Type = Str(s, 38), Value = Str(s, 39) });
                        }
                        if (String.IsNullOrEmpty(Str(s, 41)) == false)
                        {
                            person.Phones.Add(new Phone { Type = Str(s, 40), Value = Str(s, 41) });
                        }
                        if (String.IsNullOrEmpty(Str(s, 43)) == false)
                        {
                            person.Phones.Add(new Phone { Type = Str(s, 42), Value = Str(s, 43) });
                        }
                        if (String.IsNullOrEmpty(Str(s, 45)) == false)
                        {
                            person.Phones.Add(new Phone { Type = Str(s, 44), Value = Str(s, 45) });
                        }

                        person.Addresses.Clear();
                        if (String.IsNullOrEmpty(Str(s, 49)) == false)
                        {
                            person.Addresses.Add(new Address
                                                     {
                                                         Type = Str(s, 46),
                                                         Formatted = Str(s, 47),
                                                         Street = Str(s, 48),
                                                         City = Str(s, 49),
                                                         POBox = Str(s, 50),
                                                         Region = Str(s, 51),
                                                         PostalCode = Str(s, 52),
                                                         Country = Str(s, 53),
                                                         ExtendedAddress = Str(s, 54)
                                                     });
                        }
                        if (String.IsNullOrEmpty(Str(s, 58)) == false)
                        {
                            person.Addresses.Add(new Address
                                                     {
                                                         Type = Str(s, 55),
                                                         Formatted = Str(s, 56),
                                                         Street = Str(s, 57),
                                                         City = Str(s, 58),
                                                         POBox = Str(s, 59),
                                                         Region = Str(s, 60),
                                                         PostalCode = Str(s, 61),
                                                         Country = Str(s, 62),
                                                         ExtendedAddress = Str(s, 63)
                                                     });
                        }
                        person.Organizations.Clear();
                        if (String.IsNullOrEmpty(Str(s, 65)) == false)
                        {
                            person.Organizations.Add(new Organization
                                                         {
                                                             Type = Str(s, 64),
                                                             Name = Str(s, 65),
                                                             YomiName = Str(s, 66),
                                                             Title = Str(s, 67),
                                                             Department = Str(s, 68),
                                                             Symbol = Str(s, 69),
                                                             Location = Str(s, 70),
                                                             JobDescription = Str(s, 71)
                                                         });
                        }
                        person.Websites.Clear();
                        if (String.IsNullOrEmpty(Str(s, 73)) == false)
                        {
                            person.Websites.Add(new Website { Type = Str(s, 72), Value = Str(s, 73) });
                        }
                        person.Persist();

                        i++;
                        radRepeatButton1.Text = i.ToString();
                        Application.DoEvents();
                    }
                }
            }
        }

        private string Str(string[] strings, int i1)
        {

            try
            {
                return strings[i1];
            }
            catch (Exception)
            {
                return "";

            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            var persons = DataAccess.NhSession.Query<Person>().ToList();

            if (openFileDialog1.ShowDialog() != DialogResult.None)
            {



                string path = openFileDialog1.FileName;

                var sr = new StreamReader(path);
                int i = 0;

                var emaildic = Loademaildictionary();
                bool firstrow = true;
                while (sr.EndOfStream == false)
                {

                    var cl = sr.ReadLine();
                    if (firstrow)
                    {
                        firstrow = false;
                        continue;
                    }

                    if (cl != null)
                    {

                        var s = cl.Split('\t');
                        var emails = s[5].Split(',');

                        string e1 = Str(emails, 0).Trim();
                        string e2 = Str(emails, 1).Trim();

                        if ((emaildic.ContainsKey(e1) && emaildic.ContainsKey(e2)) || (string.IsNullOrEmpty(e1) && string.IsNullOrEmpty(e2)))
                        {

                            i++;
                            radRepeatButton1.Text = i.ToString();
                            Application.DoEvents();
                            continue;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(e1) && !emaildic.ContainsKey(e1)) { emaildic.Add(e1.ToString(), e1); }
                            if (!string.IsNullOrEmpty(e2) && !emaildic.ContainsKey(e2)) { emaildic.Add(e2.ToString(), e2); }
                        }


                        var person = new Person
                                         {
                                             Name = Str(s, 0),
                                             GivenName = Str(s, 0),
                                             //AdditionalName = Str(s, 2),
                                             //FamilyName = Str(s, 3),
                                             //YomiName = Str(s, 4),
                                             //GivenNameYomi = Str(s, 5),
                                             //AdditionalNameYomi = Str(s, 6),
                                             //FamilyNameYomi = Str(s, 7),
                                             NamePrefix = Str(s, 1),
                                             //NameSuffix = Str(s, 9),
                                             //Initials = Str(s, 10),
                                             Nickname = Str(s, 0),
                                             //ShortName = Str(s, 12),
                                             //MaidenName = Str(s, 13),
                                             //Birthday = Str(s, 14),
                                             //Gender = Str(s, 15),
                                             Location = Str(s, 4),
                                             //BillingInformation = Str(s, 17),
                                             //DirectoryServer = Str(s, 18),
                                             //Mileage = Str(s, 19),
                                             Occupation = Str(s, 2),
                                             //Hobby = Str(s, 21),
                                             //Sensitivity = Str(s, 22),
                                             //Priority = Str(s, 23),
                                             // Subject = "1",// Str(s, 24),
                                             // Notes = Str(s, 25),
                                             GroupMembership = "عراق"
                                         };
                        // Str(s, 0);
                        person.Emails.Clear();
                        if (String.IsNullOrEmpty(e1) == false)
                        {
                            person.Emails.Add(new Email { Type = "Email", Value = e1 });
                            if (emaildic.ContainsKey(e1) == false)
                            {
                                emaildic.Add(e1, e1);
                            }


                        }
                        if (String.IsNullOrEmpty(e2) == false)
                        {
                            person.Emails.Add(new Email { Type = "Email", Value = e2 });
                            if (emaildic.ContainsKey(e2) == false)
                            {
                                emaildic.Add(e2, e2);
                            }
                        }
                        person.IMs.Clear();
                        //if (String.IsNullOrEmpty(Str(s, 33)) == false)
                        //{
                        //    person.IMs.Add(new IM { Type = Str(s, 31), Service = Str(s, 32), Value = Str(s, 33) });
                        //}
                        person.Phones.Clear();
                        if (String.IsNullOrEmpty(Str(s, 4)) == false)
                        {
                            person.Phones.Add(new Phone { Type = "Phone", Value = Str(s, 4) });
                        }
                        //if (String.IsNullOrEmpty(Str(s, 37)) == false)
                        //{
                        //    person.Phones.Add(new Phone { Type = Str(s, 36), Value = Str(s, 37) });
                        //}
                        //if (String.IsNullOrEmpty(Str(s, 39)) == false)
                        //{
                        //    person.Phones.Add(new Phone { Type = Str(s, 38), Value = Str(s, 39) });
                        //}
                        //if (String.IsNullOrEmpty(Str(s, 41)) == false)
                        //{
                        //    person.Phones.Add(new Phone { Type = Str(s, 40), Value = Str(s, 41) });
                        //}
                        //if (String.IsNullOrEmpty(Str(s, 43)) == false)
                        //{
                        //    person.Phones.Add(new Phone { Type = Str(s, 42), Value = Str(s, 43) });
                        //}
                        //if (String.IsNullOrEmpty(Str(s, 45)) == false)
                        //{
                        //    person.Phones.Add(new Phone { Type = Str(s, 44), Value = Str(s, 45) });
                        //}

                        person.Addresses.Clear();
                        if (String.IsNullOrEmpty(Str(s, 3)) == false)
                        {
                            person.Addresses.Add(new Address
                            {
                                Type = "",
                                Formatted = "",
                                Street = Str(s, 3),
                                City = "بغداد",
                                //POBox = Str(s, 50),
                                //Region = Str(s, 51),
                                //PostalCode = Str(s, 52),
                                Country = "عراق",
                                ExtendedAddress = Str(s, 3)
                            });
                        }
                        //if (String.IsNullOrEmpty(Str(s, 58)) == false)
                        //{
                        //    person.Addresses.Add(new Address
                        //    {
                        //        Type = Str(s, 55),
                        //        Formatted = Str(s, 56),
                        //        Street = Str(s, 57),
                        //        City = Str(s, 58),
                        //        POBox = Str(s, 59),
                        //        Region = Str(s, 60),
                        //        PostalCode = Str(s, 61),
                        //        Country = Str(s, 62),
                        //        ExtendedAddress = Str(s, 63)
                        //    });
                        //}
                        person.Organizations.Clear();
                        if (String.IsNullOrEmpty(Str(s, 2)) == false)
                        {
                            person.Organizations.Add(new Organization
                            {
                                //Type = Str(s, 64),
                                //Name = Str(s, 65),
                                //YomiName = Str(s, 66),
                                Title = Str(s, 2),
                                //Department = Str(s, 68),
                                //Symbol = Str(s, 69),
                                //Location = Str(s, 70),
                                JobDescription = Str(s, 2)
                            });
                        }
                        //person.Websites.Clear();
                        //if (String.IsNullOrEmpty(Str(s, 73)) == false)
                        //{
                        //    person.Websites.Add(new Website { Type = Str(s, 72), Value = Str(s, 73) });
                        //}
                        person.Persist();

                        i++;
                        radRepeatButton1.Text = i.ToString();
                        Application.DoEvents();
                    }
                }
            }
        }

        private static Dictionary<string, object> Loademaildictionary()
        {
            var emails = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<Email>().ToList();
            var emaildic = new Dictionary<string, object>();
            foreach (var email in emails)
            {
                if (emaildic.ContainsKey(email.Value.Trim()) == false)
                {
                    emaildic.Add(email.Value.Trim(), email.Value.Trim());
                }
            }
            SWSPET.BL.Infrastructure.DataAccess.Flush();
            return emaildic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var persons = DataAccess.NhSession.Query<Person>().ToList();

            if (openFileDialog1.ShowDialog() != DialogResult.None)
            {



                string path = openFileDialog1.FileName;

                var sr = new StreamReader(path);
                int i = 0;

                var emaildic = Loademaildictionary();
                bool firstrow = true;
                while (sr.EndOfStream == false)
                {

                    var cl = sr.ReadLine();
                    if (firstrow)
                    {
                        firstrow = false;
                        continue;
                    }

                    if (cl != null)
                    {

                        var s = cl.Split('\t');
                        var emails = s[0].Split(',');

                        string e1 = Str(emails, 0).Trim();
                        string e2 = Str(emails, 1).Trim();

                        if ((emaildic.ContainsKey(e1) && emaildic.ContainsKey(e2)) || (string.IsNullOrEmpty(e1) && string.IsNullOrEmpty(e2)))
                        {

                            i++;
                            radRepeatButton1.Text = i.ToString();
                            Application.DoEvents();
                            continue;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(e1) && !emaildic.ContainsKey(e1)) { emaildic.Add(e1.ToString(), e1); }
                            if (!string.IsNullOrEmpty(e2) && !emaildic.ContainsKey(e2)) { emaildic.Add(e2.ToString(), e2); }
                        }


                        var person = new Person
                        {
                            //Name = Str(s, 0),
                            GivenName = Str(s, 0),
                            //AdditionalName = Str(s, 2),
                            //FamilyName = Str(s, 3),
                            //YomiName = Str(s, 4),
                            //GivenNameYomi = Str(s, 5),
                            //AdditionalNameYomi = Str(s, 6),
                            //FamilyNameYomi = Str(s, 7),
                            //NamePrefix = Str(s, 1),
                            //NameSuffix = Str(s, 9),
                            //Initials = Str(s, 10),
                            //Nickname = Str(s, 0),
                            //ShortName = Str(s, 12),
                            //MaidenName = Str(s, 13),
                            //Birthday = Str(s, 14),
                            //Gender = Str(s, 15),
                            Location = "Arab",

                            GroupMembership = "ArabHealthList"
                        };
                        // Str(s, 0);
                        person.Emails.Clear();
                        if (String.IsNullOrEmpty(e1) == false)
                        {
                            person.Emails.Add(new Email { Type = "Email", Value = e1 });
                            if (emaildic.ContainsKey(e1) == false)
                            {
                                emaildic.Add(e1, e1);
                            }


                        }
                        person.Persist();

                        i++;
                        radRepeatButton1.Text = i.ToString();
                        Application.DoEvents();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var persons = DataAccess.NhSession.Query<Person>().ToList();

            if (openFileDialog1.ShowDialog() != DialogResult.None)
            {



                string path = openFileDialog1.FileName;

                var sr = new StreamReader(path);
                int i = 0;

                var emaildic = Loademaildictionary();
                bool firstrow = true;
                while (sr.EndOfStream == false)
                {

                    var cl = sr.ReadLine();
                    if (firstrow)
                    {
                        firstrow = false;
                        continue;
                    }

                    if (cl != null)
                    {

                        var s = cl.Split('\t');
                        var emails = s[2].Split(',');

                        string e1 = Str(emails, 0).Trim();
                        string e2 = Str(emails, 1).Trim();

                        if ((emaildic.ContainsKey(e1) && emaildic.ContainsKey(e2)) || (string.IsNullOrEmpty(e1) && string.IsNullOrEmpty(e2)))
                        {

                            i++;
                            radRepeatButton1.Text = i.ToString();
                            Application.DoEvents();
                            continue;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(e1) && !emaildic.ContainsKey(e1)) { emaildic.Add(e1.ToString(), e1); }
                            if (!string.IsNullOrEmpty(e2) && !emaildic.ContainsKey(e2)) { emaildic.Add(e2.ToString(), e2); }
                        }


                        var person = new Person
                        {
                            //Name = Str(s, 0),
                            GivenName = Str(s, 0) + " " + Str(s, 1),
                            //AdditionalName = Str(s, 2),
                            //FamilyName = Str(s, 3),
                            //YomiName = Str(s, 4),
                            //GivenNameYomi = Str(s, 5),
                            //AdditionalNameYomi = Str(s, 6),
                            //FamilyNameYomi = Str(s, 7),
                            //NamePrefix = Str(s, 1),
                            //NameSuffix = Str(s, 9),
                            //Initials = Str(s, 10),
                            //Nickname = Str(s, 0),
                            //ShortName = Str(s, 12),
                            //MaidenName = Str(s, 13),
                            //Birthday = Str(s, 14),
                            //Gender = Str(s, 15),
                            Location = "Unknown",

                            GroupMembership = "L1"
                        };
                        // Str(s, 0);
                        person.Emails.Clear();
                        if (String.IsNullOrEmpty(e1) == false)
                        {
                            person.Emails.Add(new Email { Type = "Email", Value = e1 });
                            if (emaildic.ContainsKey(e1) == false)
                            {
                                emaildic.Add(e1, e1);
                            }


                        }
                        person.Phones.Clear();
                        if (String.IsNullOrEmpty(Str(s, 5)) == false)
                        {
                            person.Phones.Add(new Phone { Type = "Phone", Value = Str(s, 5) });
                        }
                        //if (String.IsNullOrEmpty(Str(s, 37)) == false)
                        //{
                        //    person.Phones.Add(new Phone { Type = Str(s, 36), Value = Str(s, 37) });
                        //}
                        //if (String.IsNullOrEmpty(Str(s, 39)) == false)
                        //{
                        //    person.Phones.Add(new Phone { Type = Str(s, 38), Value = Str(s, 39) });
                        //}
                        //if (String.IsNullOrEmpty(Str(s, 41)) == false)
                        //{
                        //    person.Phones.Add(new Phone { Type = Str(s, 40), Value = Str(s, 41) });
                        //}
                        //if (String.IsNullOrEmpty(Str(s, 43)) == false)
                        //{
                        //    person.Phones.Add(new Phone { Type = Str(s, 42), Value = Str(s, 43) });
                        //}
                        //if (String.IsNullOrEmpty(Str(s, 45)) == false)
                        //{
                        //    person.Phones.Add(new Phone { Type = Str(s, 44), Value = Str(s, 45) });
                        //}

                        person.Addresses.Clear();
                        if (String.IsNullOrEmpty(Str(s, 4) + "," + Str(s, 3)) == false)
                        {
                            person.Addresses.Add(new Address
                            {
                                Type = "",
                                Formatted = "",
                                Street = Str(s, 4) + "," + Str(s, 3),
                                City = "u/n",
                                //POBox = Str(s, 50),
                                //Region = Str(s, 51),
                                //PostalCode = Str(s, 52),
                                Country = "u/n",
                                ExtendedAddress = Str(s, 4) + "," + Str(s, 3)
                            });
                        }
                        person.Persist();

                        i++;
                        radRepeatButton1.Text = i.ToString();
                        Application.DoEvents();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var persons = DataAccess.NhSession.Query<Person>().ToList();

            if (openFileDialog1.ShowDialog() != DialogResult.None)
            {



                string path = openFileDialog1.FileName;

                var sr = new StreamReader(path);
                int i = 0;

                var emaildic = Loademaildictionary();
                bool firstrow = true;
                while (sr.EndOfStream == false)
                {

                    var cl = sr.ReadLine();
                    var vcard = cl + "\r\n";
                    if (cl == "BEGIN:VCARD")
                    {
                        
                        while (cl != "END:VCARD")
                        {
                            cl = sr.ReadLine();
                            vcard += cl + "\r\n";
                        }
                        TextReader srtxt = new StringReader(vcard);
                        var Vcard = new vCard(srtxt);
                    }
                }
            }

        }
    }
}
