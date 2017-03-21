using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NHibernate.Linq;
using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using SWSPEmailTracker.Properties;
using SWSPEmailTracker.web.Infrastructure;
using SWSPET.BL.Infrastructure;
using SWSPET.BL.SWSPET.Model;

namespace SWSPEmailTracker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
           // AbortAllTreads();
            base.OnClosed(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //StartUpTreads();
        }
        private void AbortAllTreads()
        {
            //_syncTrackItemsThread.Abort();
            //_syncGraphThread.Abort();
            //_syncIncommingEmailsThread.Abort();
            //_syncInboxesThread.Abort();
            //_managinThread.Abort();
            
        }
        private void StartUpTreads()
        {
            
            //_managinThread.Start();

        }
        private void ImageTrackObjectToolStripMenuItemClick(object sender, EventArgs e)
        {
            var o = new ImageTemplateManager();
            o.ShowDialog();
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PersonFolderToolStripMenuItemClick(object sender, EventArgs e)
        {
            var o = new PersonTrack();
            o.ShowDialog();
        }

        private void SendBulkMailToolStripMenuItemClick(object sender, EventArgs e)
        {
            var o = new SendingMail();
            o.ShowDialog();
        }

        private void TamplateListToolStripMenuItemClick(object sender, EventArgs e)
        {
            var o = new TemplateManager();
            o.ShowDialog();
        }

        private void RadButton1Click(object sender, EventArgs e)
        {
           // this.Close();
            Application.Exit();
            
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            
            for (int i=1;i<10;i++)
            {
                for (int j=1;j<10;j++)
                {

                }
            }
        }

        private int DownloadTrackData()
        {
            int trackupates = 0;
            
            //UpdateSyncPersent(progressBar, 0, 100);
            var tracks =SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<TrackItem>().ToList().Where(x=>x.ServerTrackID!=null);


            foreach (var trackItem in tracks)
            {
                Updaterichtextbox1("Downloading Track " + trackItem.TrackTitle + "... ");

                var item = trackItem;
                var td = new web.SWSPETl.Model.TrackData();
                var query2 =td.LoadAll() //DataAccess.NhSession.Query<SWSPEmailTracker.web.SWSPETl.Model.TrackData>()
                    .Where(x => x.TrackID == item.ServerTrackID.ToString());


                var list2 = query2.ToList();

              //  UpdateSyncPersent(progressBar, 0, list2.Count);
                //SWSPEmailTracker.web.Infrastructure.DataAccess.Flush();

                Updaterichtextbox1("Track " + trackItem.TrackTitle + ":" + list2.Count.ToString());
                trackupates += list2.Count;
                foreach (var trackData in list2)
                {

                //    UpdateSyncPersent(progressBar, progressBar.Value1 + 1, list2.Count);

                    var visitorlist =
                        SWSPET.BL.SWSPET.Model.Person.LoadAll<Person>().Where(x => x.Id.ToString() == trackData.VisitorID).
                            ToList();
                    var visitor = visitorlist.Count > 0 ? visitorlist.First() : null;
                    Updaterichtextbox1("load IP:" + trackData.VisitorIP + " info . . . ");

                    var ipinfo = new IPInfo();
                    var a = DataAccess.NhSession.Query<IPInfo>().Where(x => x.IP == trackData.VisitorIP).ToList();
                    if (a.Count > 0)
                    {
                        ipinfo = a.First();
                        ipinfo.UpdateIPInformation(trackData.VisitorIP);
                    }
                    else
                    {
                        ipinfo.UpdateIPInformation(trackData.VisitorIP);
                    }
                    ipinfo.Persist();
                    try
                    {
                        Updaterichtextbox1("Track: " + ipinfo.CountryName + " " + ipinfo.City + " " + visitor.Descriptor +
                                           " " + trackData.VisitorIP + " " + trackData.DateTime);
                    }
                    catch (Exception exception)
                    {
                        Updaterichtextbox1("Track: " + ipinfo.CountryName + " " + ipinfo.City + " " + trackData.VisitorIP + " " + trackData.DateTime + exception.Message);
                    }
                    Application.DoEvents();
                    var tdi = new SWSPET.BL.SWSPET.Model.TrackData
                             {
                                 DateTime = trackData.DateTime,
                                 VisitorID = visitor,
                                 VisitorIP = trackData.VisitorIP,
                                 SessionID = trackData.SessionID,
                                 TrackID = trackItem,
                                 Descr = trackData.Descr,
                                 IP = ipinfo

                             };
                    tdi.Persist();

                    trackData.Delete();

                }
            }
            //
            //SWSPET.BL.Infrastructure.DataAccess.CreateDatabase();
            //SWSPEmailTracker.web.Infrastructure.DataAccess.Flush();
            return trackupates;
        }
        private void UpdateSync(bool firstupdate, int delay)
        {

            //UpdateSyncPersent(radProgressBarElement2, 0, 100);

            Application.DoEvents();
            //download track data
            Updaterichtextbox1("Downloading Track Data . . . ");
            int trackupdates = DownloadTrackData();

            
            //Application.DoEvents();
            //if (trackupdates == 0)
            //{
            //    delay = 2 * delay;
            //    delay = Math.Min(delay, 54000000);
            //}
            //else
            //{
            //    delay = 60000;
            //}
            
            //if (!_shouldStopTrackSync)
            //{
            //    //Updaterichtextbox1("Wait For " + delay + "ms");
            //  //  System.Threading.Thread.Sleep(delay);
            //   // UpdateSync(false, delay);
                Updaterichtextbox1("Track Downloading Stoped.");
            //}
            //else
            //{
            //    Updaterichtextbox1("Track Downloading Stoped.");
            //}
        }
        private void Updaterichtextbox1(string s)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)(() => Updaterichtextbox1(s)));
            }
            else
            {
                if (radRichTextBox1.TextLength>=5000)
                {
                    radRichTextBox1.Text = "";
                }
                radRichTextBox1.Text += s + Resources.NewLine;
                Application.DoEvents();
            }
        }
        private volatile bool _shouldStopTrackSync;
        private void RadButton7Click(object sender, EventArgs e)
        {
        }

        private Thread _syncTrackItemsThread;
        private Thread _syncGraphThread;
        private Thread _syncIncommingEmailsThread;
        private Thread _syncInboxesThread;
        private Thread _managinThread;
        private void MainForm_Load(object sender, EventArgs e)
        {

            this.Visible = false;

            Application.DoEvents();
            this.Visible = true;
            Application.DoEvents();

            //_syncTrackItemsThread = new Thread(() => UpdateSync(true, 60000));
            //_syncGraphThread=new Thread(Updategraphcontry);
            //_syncIncommingEmailsThread = new Thread(Loadincommingemails);
            //_syncInboxesThread=new Thread(()=> UpdateInboxesSync(true,60000));
            //_managinThread=new Thread(()=>ManageThreads(true));
            //_managinThread.Start();
            Loadincommingemails();
            Updategraphcontry();
        }
        //private  void ManageThreads(bool start)
        //{
        //    if (start)
        //    {
        //        _syncTrackItemsThread.Start();
        //        _syncIncommingEmailsThread.Start();
        //        _syncInboxesThread.Start();
        //        _syncGraphThread.Start();
        //    }
        //    else
        //    {
        //    }
        //    Updaterichtextbox1("Track BG Worker:"+_syncTrackItemsThread.ThreadState.ToString());
        //    Updaterichtextbox1("Incomming Emails BG Worker:" +_syncIncommingEmailsThread.ThreadState.ToString());
        //    Updaterichtextbox1("Inboxes BG Worker:" +_syncInboxesThread.ThreadState.ToString());
        //    Updaterichtextbox1("Graph BG Worker:" +_syncGraphThread.ThreadState.ToString());
        //    Updaterichtextbox1("Monitoring Background Workers.");
        //    Thread.Sleep(300000);
        //    ManageThreads(false);
        //}

        private void RadButton9Click(object sender, EventArgs e)
        {
        //    web.Infrastructure.DataAccess.CreateDatabase();
        }

        private void Loadincommingemails()
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)(Loadincommingemails));
            }
            else
            {
                var 

                     l =SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.IsRead == false).OrderByDescending(
                        x => x.SentDate).OrderByDescending(x => x.Date).ToList();
                
                baseGridView1.SuspendLayout();
                baseGridView1.InitilizeGrid(typeof (IncommingEmail));
                baseGridView1.RowHeadersVisible = false;
                baseGridView1.DataSource = l;
                baseGridView1.PerformLayout();
               
            }
        }
        private void Updategraphcontry()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)(Updategraphcontry));
            }
            else
            {
                radChart1.SuspendLayout();
                radChart1.Visible = false;
                radChart1.PerformLayout();
                
                ////var session = SWSPET.BL.Infrastructure.DataAccess.NhSession;
                //IList<Form1.Groupdata> res;
               
                   var res  = SWSPET.BL.Infrastructure.DataAccess.NhSession.CreateSQLQuery(
                            "select  top 10 countrycode as Name,COUNT(*) as Count from ipinfo group by countrycode order by count(*) desc")
                            .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof (Form1.Groupdata)))
                            .List<Form1.Groupdata>().ToList();
                
                radChart1.Series.Clear();
                radChart1.SuspendLayout();
                radChart1.DataSource = res;
                radChart1.PlotArea.XAxis.DataLabelsColumn = "Name";
                radChart1.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Font = new System.Drawing.Font("Ariel", 8);
                radChart1.DataBind();
                radChart1.Visible = true;
                radChart1.PerformLayout();
                
            }
        }
        private void RadButton10Click(object sender, EventArgs e)
        {
            UpdateSync(true, 60000);
            //_shouldStopTrackSync = false;
            //if (!_syncTrackItemsThread.IsAlive)
            //{
            //    _syncTrackItemsThread = new Thread(() => UpdateSync(true, 60000));
            //}
            //if ((_syncTrackItemsThread.ThreadState == ThreadState.Stopped) || (_syncTrackItemsThread.ThreadState == ThreadState.Unstarted))
            //{
            //    Updaterichtextbox1("Downloading Track Data Set To Start.");
            //    _syncTrackItemsThread.Start();
            //}
            //else
            //{
            //    Updaterichtextbox1("Downloading Track Data Set To in Running.");
            //}
        }

        private void RadButton11Click(object sender, EventArgs e)
        {
            Updaterichtextbox1("Downloading Track Data Set To Stop.");
            _shouldStopTrackSync = true;
            
        }

        private void RadButton17Click(object sender, EventArgs e)
        {
            Updategraphcontry();
            //if (!_syncGraphThread.IsAlive)
            //{
            //    _syncGraphThread = new Thread(Updategraphcontry);
            //}
            //if ((_syncGraphThread.ThreadState == ThreadState.Stopped) || (_syncGraphThread.ThreadState == ThreadState.Unstarted))
            //{
            //    Updaterichtextbox1("Graph Update is Starting.");
            //    _syncGraphThread.Start();
            //}
            //else
            //{
            //    Updaterichtextbox1("Graph Update is Running.");
            //}
            
        }

        private void RadButton13Click(object sender, EventArgs e)
        {
            Loadincommingemails();
            //if (!_syncIncommingEmailsThread.IsAlive)
            //{
            //    _syncIncommingEmailsThread = new Thread(Loadincommingemails);
            //}
            //if ((_syncIncommingEmailsThread.ThreadState == ThreadState.Stopped) || (_syncIncommingEmailsThread.ThreadState == ThreadState.Unstarted))
            //{
            //    Updaterichtextbox1("Incomming Emails Update is Starting.");
            //    _syncIncommingEmailsThread.Start();
            //}
            //else
            //{
            //    Updaterichtextbox1("Incomming Emails Update is Running.");
            //}
            

        }

        private void RadButton6Click(object sender, EventArgs e)
        {
            AbortAllTreads();
            var a = new TemplateManager();
            a.ShowDialog();
            StartUpTreads();
        }
        private void UpdateInboxesSync(bool firstupdate, int delay)
        {

            Application.DoEvents();
            var pop3Client = new Pop3Client();
            var mailrecived = 0;
            var inboxes = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<InboxInformation>().ToList();
            
            foreach (var inboxInformation in inboxes)
            {
                Updaterichtextbox1("Downloading "+inboxInformation.InboxName+" Emails  . . .");

                Application.DoEvents();
                mailrecived += ReceiveMails(pop3Client, inboxInformation.Host, inboxInformation.PortPop3, inboxInformation.UserName, inboxInformation.Password
                    , inboxInformation.IsSsl, inboxInformation.DeleteAfterFetch);

                
            }
            
            //////////////Application.DoEvents();
            //////////////if (mailrecived == 0 )
            //////////////{
            //////////////    delay = 2 * delay;
            //////////////    delay = Math.Min(delay, 54000000);
            //////////////}
            //////////////else
            //////////////{
            //////////////    delay = 60000;
            //////////////}
            //Updaterichtextbox1("wait for " + delay + "ms");
            //System.Threading.Thread.Sleep(delay);

            //UpdateInboxesSync(false, delay);
        }
        private int ReceiveMails(Pop3Client pop3Client, 
            string server, int serverport, string loginname, string password, bool ssl, bool deleteAfterFetch)
        {
            int mailrecived = 0;
            var emails = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<Email>().ToList();

            //UpdateSyncPersent(progressBar, 0, 100);

            try
            {

                if (pop3Client.Connected)
                    pop3Client.Disconnect();
                pop3Client.Connect(server, serverport, ssl);
                pop3Client.Authenticate(loginname, password);
                var count = pop3Client.GetMessageCount();
                Updaterichtextbox1("New Emails: " + count.ToString());

              //  UpdateSyncPersent(progressBar, 0, count);

                int success = 0;
                int fail = 0;
                for (int i = count; i >= 1; i -= 1)
                {

                //    UpdateSyncPersent(progressBar, progressBar.Value1 + 1, count);


                    if (IsDisposed)
                        return 0;

                    Application.DoEvents();
                    Updaterichtextbox1("Message " + i.ToString() + " of " + count.ToString());
                    try
                    {
                        var message = pop3Client.GetMessage(i);

                        // Add the message to the dictionary from the messageNumber to the Message
                        //      messages.Add(i, message);

                        // Create a TreeNode tree that mimics the Message hierarchy
                        //    TreeNode node = new TreeNodeBuilder().VisitMessage(message);

                        // Set the Tag property to the messageNumber
                        // We can use this to find the Message again later
                        //  node.Tag = i;

                        // Show the built node in our list of messages
                        //listMessages.Nodes.Add(node);
                        //foreach (var findAllAttachment in message.FindAllAttachments())
                        //{

                        //}

                        //MimeReader mime = new MimeReader();     // this class processes the .EML mime content

                        if (message.MessagePart.IsMultiPart == true && message.MessagePart.MessageParts.Count > 1)
                        {

                            if (message.MessagePart.MessageParts[1].ContentType.MediaType == "message/delivery-status")
                            {
                                Updaterichtextbox1("Message status:delivery-status ");
                                try
                                {
                                    var s = message.MessagePart.MessageParts[1].GetBodyAsText();
                                    s = s.Replace("\r", "");
                                    var ss = s.Split('\n');
                                    var emailFailedDeliveryStatus = new EmailFailedDeliveryStatus();
                                    using (emailFailedDeliveryStatus)
                                    {


                                        foreach (var s1 in ss)
                                        {
                                            var sitem = s1.Split(Convert.ToChar(":"));

                                            switch (sitem[0])
                                            {
                                                case "Action":
                                                    emailFailedDeliveryStatus.Action = sitem[1];
                                                    break;
                                                case "Status":
                                                    emailFailedDeliveryStatus.Status = sitem[1];
                                                    break;
                                                case "Remote-MTA":
                                                    emailFailedDeliveryStatus.RemoteMTA = s1;
                                                    break;
                                                case "Final-Recipient":
                                                    var rr = sitem[1].Split(';');
                                                    var fr = new FinalRecipient { ReceivedFromEmail = rr[1], Type = rr[0] };
                                                    fr.Persist();
                                                    emailFailedDeliveryStatus.FinalRecipient = fr;
                                                    break;
                                                case "Diagnostic-Code":
                                                    emailFailedDeliveryStatus.DiagnosticCode = s1;
                                                    break;
                                                case "Last-Attempt-Date":
                                                    emailFailedDeliveryStatus.LastAttemptDate = s1;
                                                    break;
                                                case "Arrival-Date":
                                                    emailFailedDeliveryStatus.ArrivalDate = s1;
                                                    break;
                                                case "Reporting-MTA":
                                                    emailFailedDeliveryStatus.ReportingMTA = s1;
                                                    break;
                                                case "Received-From-MTA":
                                                    emailFailedDeliveryStatus.ReceivedFromMTA = s1;
                                                    break;


                                                default:
                                                    break;
                                            }


                                        }
                                        emailFailedDeliveryStatus.Persist();
                                        var upsatestat = emails.Where(
                                            x =>
                                            x.Value.Trim() ==
                                            emailFailedDeliveryStatus.FinalRecipient.ReceivedFromEmail.Trim()).
                                            ToList();
                                        foreach (var email in upsatestat)
                                        {
                                            email.EmailFailedDeliveryStatus = emailFailedDeliveryStatus;
                                            email.IsValid = false;
                                            email.Persist();
                                        }
                                    }
                                    Application.DoEvents();

                                }

                                catch (Exception ex)
                                {
                                    Updaterichtextbox1(message.MessagePart.MessageParts[1].GetBodyAsText() + "\r\n" +
                                                    ex.Message);

                                }
                                finally
                                {
                                    if (deleteAfterFetch) { pop3Client.DeleteMessage(i); }

                                }
                            }
                            else
                            {
                                try
                                {
                                    SaveIncommingEMail(message);
                                }
                                finally
                                {
                                    if (deleteAfterFetch) { pop3Client.DeleteMessage(i); }

                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                SaveIncommingEMail(message);
                            }
                            finally
                            {
                                if (deleteAfterFetch) { pop3Client.DeleteMessage(i); }

                            }
                        }
                        success++;
                    }
                    catch (Exception e)
                    {
                        Updaterichtextbox1(
                            "Message fetching failed: " + e.Message + "\r\n" +
                            "Stack trace:\r\n" +
                            e.StackTrace);
                        fail++;
                    }
                    mailrecived = success + fail;
                    //progressBar.Value1 = (int)(((double)(count - i) / count) * 100);
                }


                Updaterichtextbox1("Mail received!\r\nSuccesses: " + success + "\r\nFailed: " + fail + "\r\nMessage fetching done");


                if (fail > 0)
                {
                    Updaterichtextbox1("Since some of the emails were not parsed correctly (exceptions were thrown)\r\n" +
                                    "please consider sending your log file to the developer for fixing.\r\n" +
                                    "If you are able to include any extra information, please do so." +
                                    "Help improve OpenPop!");

                }
            }
            catch (InvalidLoginException)
            {
                Updaterichtextbox1("The server did not accept the user credentials! POP3 Server Authentication");

            }
            catch (PopServerNotFoundException)
            {
                Updaterichtextbox1("The server could not be found POP3 Retrieval");

            }
            catch (PopServerLockedException)
            {
                Updaterichtextbox1("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere? POP3 Account Locked");

            }
            catch (LoginDelayException)
            {
                Updaterichtextbox1("Login not allowed. Server enforces delay between logins. Have you connected recently? POP3 Account Login Delay");

            }
            catch (Exception e)
            {
                Updaterichtextbox1("Error occurred retrieving mail. POP3 Retrieval " + e.Message);

            }
            finally
            {
                if (pop3Client.Connected) { pop3Client.Disconnect(); }
                Updaterichtextbox1("Finished.");
                // Enable the buttons again
                //   connectAndRetrieveButton.Enabled = true;
                // uidlButton.Enabled = true;
                //progressBar.Value = 100;
            }
            return mailrecived;
        }
        private void SaveIncommingEMail(OpenPop.Mime.Message message)
        {
            var emaillist = DataAccess.NhSession.Query<Email>().ToList();
            Updaterichtextbox1("Message: " + message.Headers.Subject);
            var iemail = new IncommingEmail { OriginalMessage = message.RawMessage };

            foreach (var bcc in message.Headers.Bcc)
            {
                var bccfind = emaillist.Where(x => x.Value == bcc.Address).ToList();
                iemail.BCC.Add(bccfind.Count > 0 ? bccfind.First().Person : NewContactPerson(bcc.DisplayName, bcc.Address));
            }

            foreach (var cc in message.Headers.Cc)
            {
                var ccfind = emaillist.Where(x => x.Value == cc.Address).ToList();
                iemail.CC.Add(ccfind.Count > 0 ? ccfind.First().Person : NewContactPerson(cc.DisplayName, cc.Address));
            }

            foreach (var to in message.Headers.To)
            {
                var tofind = emaillist.Where(x => x.Value == to.Address).ToList();
                iemail.TO.Add(tofind.Count > 0 ? tofind.First().Person : NewContactPerson(to.DisplayName, to.Address));
            }

            var t = message.FindAllMessagePartsWithMediaType("text/html");
            iemail.HTMLBody = "";
            foreach (var messagePart in t.Where(messagePart => messagePart.Body != null))
            {
                iemail.HTMLBody += messagePart.BodyEncoding.GetString(messagePart.Body);
            }

            iemail.TextBody = "";
            var t0 = message.FindAllMessagePartsWithMediaType("text/plain");
            foreach (var messagePart in t0.Where(messagePart => messagePart.Body != null))
            {
                iemail.TextBody += messagePart.BodyEncoding.GetString(messagePart.Body);
            }


            var fromfind = emaillist.Where(x => x.Value == message.Headers.From.Address).ToList();
            iemail.From = fromfind.Count > 0 ? fromfind.First().Person : NewContactPerson(message.Headers.From.DisplayName, message.Headers.From.Address);

            try
            {
                var senderfind = emaillist.Where(x => x.Value == message.Headers.Sender.Address).ToList();
                iemail.Sender = senderfind.Count > 0
                                    ? senderfind.First().Person
                                    : NewContactPerson(message.Headers.Sender.DisplayName,
                                                       message.Headers.Sender.Address);
            }
            catch (Exception exception)
            {
                iemail.Sender = null;
            }
            try
            {
                var replayTofind = emaillist.Where(x => x.Value == message.Headers.ReplyTo.Address).ToList();
                iemail.ReplayTo = replayTofind.Count > 0 ? replayTofind.First().Person : NewContactPerson(message.Headers.ReplyTo.DisplayName, message.Headers.ReplyTo.Address);
            }
            catch (Exception exception)
            {
                iemail.ReplayTo = null;
            }

            try
            {
                var returnPathfind = emaillist.Where(x => x.Value == message.Headers.ReturnPath.Address).ToList();
                iemail.ReturnPath = returnPathfind.Count > 0 ? returnPathfind.First().Person : NewContactPerson(message.Headers.ReturnPath.DisplayName, message.Headers.ReturnPath.Address);
            }
            catch (Exception exception)
            {
                iemail.ReturnPath = null;
            }

            iemail.InReplayTo = "";
            foreach (var email in message.Headers.InReplyTo)
            {
                iemail.InReplayTo += email + ";";
            }

            iemail.MessageID = message.Headers.MessageId;

            foreach (var part in message.FindAllAttachments())
            {
                var ea = new EmailAttachment
                {
                    AttachmentType = part.ContentType.MediaType,
                    FileName = part.FileName,
                    AttachmentData = part.Body
                };
                //ea.AttachmentData=part.
                ea.Persist();
                iemail.EmailAttachment.Add(ea);

            }
            iemail.Subject = message.Headers.Subject;
            try
            {
                iemail.SentDate = message.Headers.DateSent;
            }
            catch (Exception exception)
            {
                iemail.SentDate = DateTime.Now;
            }
            iemail.Date = message.Headers.Date;
            iemail.Persist();
            Updaterichtextbox1("Message saved. ");
            //check [to] [cc] [bcc] to add contacts to list
            //save the binery
            //save email main info
            //sender replay to , returnpath,subject,bcc,cc,date,sentdate,from,inreplayto,messageid,sender,body,attachments
        }
        private static Person NewContactPerson(string displayname, string emailaddress)
        {

            Person person;
            var emaillist = DataAccess.NhSession.Query<Email>().ToList();
            var bccfind = emaillist.Where(x => x.Value == emailaddress).ToList();
            if (bccfind.Count > 0)
            {
                person = bccfind.First().Person;
            }
            else
            {
                var e = new Email { Value = emailaddress, IsValid = true, CreateDate = DateTime.Now };
                e.Persist();
                var p = new Person { FamilyName = displayname };
                p.Emails.Add(e);
                p.Persist();
                person = p;
            }
            return person;

        }

        private void ImportToolStripMenuItemClick(object sender, EventArgs e)
        {
            var o = new ImportContact();
            o.ShowDialog();
        }

        private void RadButton4Click(object sender, EventArgs e)
        {
            var o = new ImportContact();
            o.ShowDialog();
        }

        private void RadButton5Click(object sender, EventArgs e)
        {
            AbortAllTreads();
            var o = new SendingMail();
            o.ShowDialog();
            StartUpTreads();
        }

        private void RadButton12Click(object sender, EventArgs e)
        {
            var o = new AddPersonLigth();
            o.ShowDialog();
        }

        private void RadButton16Click(object sender, EventArgs e)
        {
             UpdateInboxesSync(true, 60000);
        }

        private void RadRichTextBox1TextChanged(object sender, EventArgs e)
        {
            radRichTextBox1.SelectionStart = radRichTextBox1.Text.Length; //Set the current caret position at the end
            radRichTextBox1.ScrollToCaret(); //Now scroll it automatically
        }

        private void RadButton14Click(object sender, EventArgs e)
        {
            AbortAllTreads();
            //var t1=new Thread(OpenShowmail);
            //t1.Start();
            OpenShowmail();
            Loadincommingemails();
            StartUpTreads();
        }
        private void OpenShowmail()
        {
            if (baseGridView1.SelectedRows[0].DataBoundItem != null)
            {
                var a = (IncommingEmail)baseGridView1.SelectedRows[0].DataBoundItem;
                //DataAccess.NhSession.Flush();
                var o = new ShowEmail(a);

                o.ShowDialog();
                //if (_syncIncommingEmailsThread.ThreadState == ThreadState.Stopped)
                //{

                //    _syncIncommingEmailsThread =
                //    new Thread(Loadincommingemails);
                //    _syncIncommingEmailsThread.Start();
                //    Updaterichtextbox1("Updating Incomming Emails Start.");
                //}
                //loadincommingemails();

            }
            else
            {

               MessageBox.Show("Please select an email.");
            }
        }

        private void inboxEmailConfigurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void baseGridView1_DoubleClick(object sender, EventArgs e)
        {
            AbortAllTreads();
            //var t1=new Thread(OpenShowmail);
            //t1.Start();
            OpenShowmail();
            Loadincommingemails();
            StartUpTreads();
        }

        private void radButton18_Click(object sender, EventArgs e)
        {
            var i =new ImageTemplateManager();
            i.ShowDialog();
        }

        private void radButton15_Click(object sender, EventArgs e)
        {
            var i = new LinkTemplateManager();
            i.ShowDialog();
        }

        private void radButton7_Click(object sender, EventArgs e)
        {
            var o = new lastTrackData();
            o.ShowDialog();
        }
    }
}
