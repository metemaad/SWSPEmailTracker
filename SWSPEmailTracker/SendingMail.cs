using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using SWSPEmailTracker.Properties;
using SWSPET.BL.Infrastructure;
using SWSPET.BL.SWSPET.Model;
using Telerik.WinControls.RichTextBox;
using Telerik.WinControls.UI;


namespace SWSPEmailTracker
{
    public partial class SendingMail : Form
    {
        private string _emailWebService =
            "http://www.smartwsp.com/webmail/mailer/a/installtest5.php?to={0}&TMP={1}&VID={2}&NAME={3}";
        public string EmailWebService
        {
            get { return _emailWebService; }
            set { _emailWebService = value; }
        }
        public SendingMail()
        {
            InitializeComponent();
        }

        private Thread t;
        private void Button1Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Application.DoEvents();
            var selectedTemplate = (EmailTemplate)comboBox1.SelectedItem;
            var perl = DataAccess.NhSession.Query<Email>().ToList();
            

        
            t = new Thread(() => Sendmail(selectedTemplate, perl));
            t.Start();

            button1.Enabled = true;
            Application.DoEvents();
            
        }
        private void Sendmail(EmailTemplate selectedTemplate,IList<Email> perl)
        {
            var dict = radListView1.Items.Where(radlistv => radlistv.CheckState == Telerik.WinControls.Enumerations.ToggleState.On).ToDictionary<ListViewDataItem, string, object>(radlistv => radlistv.Text, radlistv => radlistv.DataBoundItem);
            
            int max = dict.Count;
            radProgressBar1.Maximum = max;
            int i = 0;
            radProgressBar1.Value1 = i;
            Application.DoEvents();
            foreach (var email in dict)
            {
                try
                {
                    var a = email.Value;
                    //var b =a.Value;
                    Person person=null ;
                    var p= perl.Where(x => x.Value == email.Key).ToList();
                    if (p.Count > 0)
                    {
                        person = (from email1 in p where email1.Person != null select email1.Person).FirstOrDefault();
                    }
                    string sendingname = person.SendingName;
                    if (string.IsNullOrEmpty(sendingname.Trim()))
                    {
                        sendingname = "Mr";
                    }
                    var request =
                        WebRequest.Create(string.Format(_emailWebService, email.Key, selectedTemplate.ONLineTemplateID, person.Id.ToString(), sendingname));

                    var response = request.GetResponse();
                    using (var responseStream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(responseStream);
                        var stringResponse = reader.ReadToEnd();

                        if (stringResponse.StartsWith("Ok."))
                        {
                            //MessageBox.Show("ok");
                            stringResponse = stringResponse.Replace("Ok.", "");

                            Updaterichtextbox1(email.Key + " Sent.  " + "MessageID:" + stringResponse);
                            var omail = new OutgoingEmail
                            {
                                MessageID = stringResponse,
                                Recipient = person,
                                Subject = selectedTemplate.EmailSubject,
                                BodyPlain =Encoding.UTF8.GetString( selectedTemplate.EmailPlainData),
                                Date = DateTime.Now.ToString(),
                                SentDate = DateTime.Now,
                                IsRead = false
                            };
                            omail.Persist();
                        }
                        else
                        {
                            Updaterichtextbox1(email.Key + " Sent failed.  ");
                            var f = person.Emails.ToList().Where(x => x.Value.Trim() == email.Key).ToList();
                            foreach (var Va in f)
                            {
                                Va.IsValid = false;
                                Va.Persist();
                            }
                        }
                        Application.DoEvents();
                    }
                    i++;
                    radProgressBar1.Value1 = i;
                    radProgressBar1.Text = i.ToString() + @"/" + max.ToString();
                    Application.DoEvents();
                }
                catch
                {
                    Updaterichtextbox1(email.Key + " Sent failed.  \r\n");

                    Application.DoEvents();


                }
            }
            //this.Close();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
          

                //client.UploadFile(, );
                string fileToUpload = @"C:\Users\swsp\Downloads\Programs\pd.jpg";
                string uploadUrl = "http://www.smartwsp.com/webmail/mailer/a/upload.php";
                //string uploadUrl = "http://10.0.2.2/musicapp/handle_upload.php";
                FileStream rdr = new FileStream(fileToUpload, FileMode.Open);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uploadUrl);
                req.Method = "POST"; // you might use "POST"
                req.ContentLength = rdr.Length;
                req.AllowWriteStreamBuffering = true;

                Stream reqStream = req.GetRequestStream();

                byte[] inData = new byte[rdr.Length];

                // Get data from upload file to inData 
                int bytesRead = rdr.Read(inData, 0, int.Parse(rdr.Length.ToString()));

                // put data into request stream
                reqStream.Write(inData, 0, int.Parse(rdr.Length.ToString()));

                rdr.Close();
                req.GetResponse();

                // after uploading close stream 
                reqStream.Close();
           
        }

        private void Updaterichtextbox1(string s)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)(() => Updaterichtextbox1(s)));
            }
            else
            {
                if (richTextBox1.TextLength>5000)
                {
                    richTextBox1.Text = "";
                }
                richTextBox1.Text += s + Resources.NewLine;
                Application.DoEvents();
            }
        }



        private void RichTextBox1TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length; //Set the current caret position at the end
            richTextBox1.ScrollToCaret(); //Now scroll it automatically
        }

        private void SplitPanel2Click(object sender, EventArgs e)
        {

        }
        protected override void OnClosed(EventArgs e)
        {   if (t!=null)
            if (!((t.ThreadState==ThreadState.Unstarted)||(t.ThreadState==ThreadState.Aborted)||(t.ThreadState==ThreadState.Stopped)||(t.ThreadState==ThreadState.AbortRequested)||(t.ThreadState==ThreadState.StopRequested))) t.Abort();
            base.OnClosed(e);
        }
        
        private void SendingMail_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            var emailsenderengine = ConfigurationManager.ConnectionStrings["SWSPEmailServiceLink"].ConnectionString;
            _emailWebService = emailsenderengine + @"/send/{0}/{1}/{2}/{3}";
            EnableDoubleBuffering();
            this.SuspendLayout();
            Loadsearchparam();
            this.ResumeLayout();
            _fullperson = DataAccess.NhSession.CreateCriteria<Person>();
            var templates = DataAccess.NhSession.Query<EmailTemplate>().ToList();
            

            comboBox1.DataSource = templates;
            comboBox1.DisplayMember = "Descriptor";


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
            radScrollablePanel1.Controls.Clear();

            foreach (var a in from variable in dic
                              let ss = cat0.Where(x => x.GroupMembership != null).Where(x => x.GroupMembership.Contains(variable.Key)).ToList().Count
                              select new RadCheckBox
                                         {
                                             Name = variable.Key, Text = variable.Key + Resources.Prantez_open + ss + Resources.Prantez_close, Dock = DockStyle.Top, Height = 25, Checked = false
                                         })
            {
                radScrollablePanel1.Controls.Add(a);
            }
        }
        
      
        private void RadButton1Click1(object sender, EventArgs e)
        {
            var tStart = new Thread(Loadincommingemails);
            tStart.Start();


        }
        public void EnableDoubleBuffering()
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint,
               true);
            this.UpdateStyles();
        }

        private void RadCheckBox1ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            splitPanel2.Visible = radCheckBox1.IsChecked;
            radSplitContainer2.SplitPanels.Remove(splitPanel2);
        }
        private void Updateprogressbar2(int max,int cur1, int cur2)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)(() => Updateprogressbar2(max,cur1,cur2)));
            }
            else
            {
                radProgressBar2.Maximum = max+1;
                radProgressBar2.Value1 = cur1;
                radProgressBar2.Value2 = cur2;
                Application.DoEvents();

            }
        }

        private ICriteria _fullperson;
        private void Loadincommingemails()
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker) (Loadincommingemails));
            }
            else
            {

                var or = Restrictions.Disjunction();
                var presendlist = new Dictionary<string, Email>();
                foreach (var re3 in from object control in radScrollablePanel1.Controls[0].Controls
                                    where control.GetType() == typeof(RadCheckBox)
                                    where ((RadCheckBox)control).IsChecked
                                    select Restrictions.Like("GroupMembership", "%" + ((RadCheckBox)control).Name + "%"))
                {
                    or.Add(re3);
                }
                var person = _fullperson.Add(or).List<Person>();
                var aaa = person.SelectMany(person1 => person1.Emails).ToList();
            //    radScrollablePanel2.Controls.Clear();
                int max = aaa.Count;
                Updateprogressbar2(max, 0, 0);
                var reqe =new  RegexUtilities();
                foreach (var email in aaa)
                {
                    email.Value = email.Value.Trim();
                    if (reqe.IsValidEmail(email.Value))
                    {
                        if (radRadioButton2.IsChecked)
                        {
                            if (email.IsValid)
                            {
                                if (!presendlist.ContainsKey(email.Value))
                                {
                                    presendlist.Add(email.Value, email);
                                }
                            }
                        }
                        else
                        {
                            if (!presendlist.ContainsKey(email.Value))
                            {
                                presendlist.Add(email.Value, email);
                            }

                        }
                    }else
                    {
                    }
                    Updateprogressbar2(max, radProgressBar2.Value1 + 1, 0);
                }
                radListView1.DataSource = presendlist;


                foreach (var radlistv in radListView1.Items)
                {
                    radlistv.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                }
                    
                //this.SuspendLayout();
                //max = presendlist.Count;
                //updateprogressbar2(max, 0, 0);
                //foreach (var email in presendlist)
                //{
                //    var a = new RadCheckBox { Name = email.Key, Text = ((Email)email.Value).Person.Descriptor, Dock = DockStyle.Top, Height = 25, Checked = true };
                //    radScrollablePanel2.Controls.Add(a);                   
                //    updateprogressbar2(max, radProgressBar2.Value1 + 1, 0);
                //}
                //this.ResumeLayout();
                //Application.DoEvents();
            
            }
        }

        private void SendingMail_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }

}
