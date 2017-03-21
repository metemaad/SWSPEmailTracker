using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NHibernate.Linq;
using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using SWSPEmailTracker.Properties;
using SWSPET.BL.Infrastructure;
using SWSPET.BL.SWSPET.Control;
using SWSPET.BL.SWSPET.Model;
using SWSPVCard;
using Telerik.WinControls.UI;
using TrackData = SWSPEmailTracker.web.SWSPETl.Model.TrackData;

namespace SWSPEmailTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var p = new Person();
            
            TextReader sr = new StringReader(@"BEGIN:VCARD
VERSION:3.0
FN:陳小鬼
N:陳;小鬼;;;
URL:http\://www.google.com/profiles/112282717991366007788
END:VCARD
");
            p.Vcard=new vCard(sr);

        }

        private void Updatedata()
        {
            var td = new TrackData();
            var query2 = td.LoadAll();// SWSPEmailTracker.web.Infrastructure.DataAccess.NhSession.Query<TrackData>();
            var list2 = query2.ToList();

            var results = from tr in list2
                          group tr by tr.TrackID into g
                          orderby g.Key
                          select new
                          {
                              TrackID = Trackname(g.Key),
                              Count = g.Count()
                          };
            var l = results.ToList();

        }

        private static string Trackname(string key)
        {
            if (SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<TrackItem>().ToList().Where(x => x.TrackId == key).ToList().Count > 0)
            {

                return
                    SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<TrackItem>().ToList().Where(x => x.TrackId == key)
                        .First().TrackTitle;
            }
            else
            {
                return key;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SmtpClient client = new SmtpClient();
            //client.Port = 25;
            ////587;
            //client.Host = "smtp.smartwsp.com";
            ////client.EnableSsl = true;
            ////client.Timeout = 10000;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Credentials = new System.Net.NetworkCredential("info@smartwsp.com", "ha1487606");

            //MailMessage mm = new MailMessage("info@smartwsp.com", "edward.craig2012@gmail.com", "test", "test");
            //mm.Body = "<p><img src=\"http://www.smartwsp.com/webmail/f.php\" alt=\"Smiley face\" ></p>";
            //mm.IsBodyHtml = true;
            //mm.Headers.
            //mm.BodyEncoding = UTF8Encoding.UTF8;
            //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;


            //client.Send(mm);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("test101", "emfami@gmail.com");
            //dictionary.Add("فونت جدید", "aranmedical@yahoo.com");


            foreach (var o in dictionary)
            {
                sendmail(o.Key, o.Value.ToString());
            }



            MessageBox.Show("ok");
        }

        private void sendmail(string tit, string _to)
        {
            string smtp = "smtp.smartwsp.com";//~~ YOUR STMP SERVER HERE ~~
            string from = "info@smartwsp.com";
            string subject = "تبلیغات به همراه پیگیری" + tit;
            string to = _to;
            string body = "This is the body of the message." + Environment.NewLine + "This is the second line";
            body += "<p><img src=\"http://www.smartwsp.com/webmail/f.php\" alt=\"Smiley face\" ></p>";
            //mm.IsBodyHtml = true;

            string base64privatekey = @"-----BEGIN RSA PRIVATE KEY-----
MIIByQIBAAJhAKJ2lzDLZ8XlVambQfMXn3LRGKOD5o6lMIgulclWjZwP56LRqdg5
ZX15bhc/GsvW8xW/R5Sh1NnkJNyL/cqY1a+GzzL47t7EXzVc+nRLWT1kwTvFNGIo
AUsFUq+J6+OprwIDAQABAmBOX0UaLdWWusYzNol++nNZ0RLAtr1/LKMX3tk1MkLH
+Ug13EzB2RZjjDOWlUOY98yxW9/hX05Uc9V5MPo+q2Lzg8wBtyRLqlORd7pfxYCn
Kapi2RPMcR1CxEJdXOkLCFECMQDTO0fzuShRvL8q0m5sitIHlLA/L+0+r9KaSRM/
3WQrmUpV+fAC3C31XGjhHv2EuAkCMQDE5U2nP2ZWVlSbxOKBqX724amoL7rrkUew
ti9TEjfaBndGKF2yYF7/+g53ZowRkfcCME/xOJr58VN17pejSl1T8Icj88wGNHCs
FDWGAH4EKNwDSMnfLMG4WMBqd9rzYpkvGQIwLhAHDq2CX4hq2tZAt1zT2yYH7tTb
weiHAQxeHe0RK+x/UuZ2pRhuoSv63mwbMLEZAjAP2vy6Yn+f9SKw2mKuj1zLjEhG
6ppw+nKD50ncnPoP322UMxVNG4Eah0GYJ4DLP0U=
-----END RSA PRIVATE KEY-----";

            HashAlgorithm hash = new SHA256Managed();
            // HACK!! simulate the quoted-printable encoding SmtpClient will use
            string hashBody = body.Replace(Environment.NewLine, "=0D=0A") + Environment.NewLine;
            byte[] bodyBytes = Encoding.ASCII.GetBytes(hashBody);
            string hashout = Convert.ToBase64String(hash.ComputeHash(bodyBytes));
            // timestamp  - seconds since 00:00:00 on January 1, 1970 UTC
            TimeSpan t = DateTime.Now.ToUniversalTime() - DateTime.SpecifyKind(DateTime.Parse("00:00:00 January 1, 1970"), DateTimeKind.Utc);

            string signatureHeader = "v=1; " +
             "a=rsa-sha256; " +
             "c=relaxed/relaxed; " +
             "d=dkimtester.info; " +
             "s=p; " +
             "t=" + Convert.ToInt64(t.TotalSeconds) + "; " +
             "bh=" + hashout + "; " +
             "h=From:To:Subject:Content-Type:Content-Transfer-Encoding; " +
             "b=";

            string canonicalizedHeaders =
            "from:" + from + Environment.NewLine +
            "to:" + to + Environment.NewLine +
            "subject:" + subject + Environment.NewLine +
            @"content-type:text/plain; charset=us-ascii
content-transfer-encoding:quoted-printable
dkim-signature:" + signatureHeader;

            TextReader reader = new StringReader(base64privatekey);
            Org.BouncyCastle.OpenSsl.PemReader r = new Org.BouncyCastle.OpenSsl.PemReader(reader);
            AsymmetricCipherKeyPair o = r.ReadObject() as AsymmetricCipherKeyPair;
            byte[] plaintext = Encoding.ASCII.GetBytes(canonicalizedHeaders);
            ISigner sig = SignerUtilities.GetSigner("SHA256WithRSAEncryption");
            sig.Init(true, o.Private);
            sig.BlockUpdate(plaintext, 0, plaintext.Length);
            byte[] signature = sig.GenerateSignature();
            signatureHeader += Convert.ToBase64String(signature);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = Body();
            message.IsBodyHtml = true;
            message.Headers.Add("DKIM-Signature", signatureHeader);
            SmtpClient client = new SmtpClient(smtp);
            client.Port = 25;
            //587;
            //client.Host = "smtp.smartwsp.com";
            //client.EnableSsl = true;
            //client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("info@smartwsp.com", "ha1487606");
            client.Send(message);
            //Console.Write("sent to: " + to);
        }
        private string Body()
        {

            StreamReader sr = new StreamReader(Application.StartupPath + "\\TextFile1.txt");


            return sr.ReadToEnd();
        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void radRepeatButton1_Click(object sender, EventArgs e)
        {
            var impconui = new ImportContact();
            impconui.ShowDialog();
        }

        private void RadRepeatButton4Click(object sender, EventArgs e)
        {
            var o = new pop3test();
            o.ShowDialog();
        }

        private void RadRepeatButton3Click(object sender, EventArgs e)
        {
            var o = new SendingMail
                        {
                            EmailWebService =
                                "http://www.smartwsp.com/webmail/mailer/a/installtest5.php?to={0}&TMP={1}&VID={2}&NAME={3}"
                        };
            o.ShowDialog();

        }

        private void RadMenuItem5Click(object sender, EventArgs e)
        {
            var a = new ImageTemplateManager();
            a.ShowDialog();
        }

        private void RadLabel1Click(object sender, EventArgs e)
        {
            Updatedata();
        }

        //private void baseGridView1_SelectionChanged(object sender, EventArgs e)
        //{

        //}

        //private void baseGridView1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //var a = baseGridView1.SelectedRows[0].Cells[0].Value;

        //        var q1 = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<TrackItem>().ToList().Where(
        //            x => x.TrackTitle == (string)a).ToList();
        //        var query2 = SWSPEmailTracker.web.Infrastructure.DataAccess.NhSession.Query<TrackData>().ToList().Where(
        //            x => x.TrackID == q1.First().TrackId);
        //        var list2 = query2.Select(r => new
        //                                         {
        //                                             DateTime = r.DateTime.ToString(),
        //                                             IP = r.VisitorIP.ToString(),
        //                                             VisitorID = GetVisitorName(r.VisitorID),

        //                                         }).ToList();


        //        baseGridView1.InitilizeGrid(typeof(TrackData));
        //        baseGridView1.DataSource = list2;

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private string GetVisitorName(object o)
        {
            var a =
                SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<Person>().Where(x => x.Id.ToString() == (string)o).
                    ToList();
            if (a.Count > 0)
            {
                return a.First().Descriptor.ToString();
            }
            else
            {
                return o.ToString();
            }
        }

        private void RadRepeatButton5Click(object sender, EventArgs e)
        {
            SWSPET.BL.Infrastructure.DataAccess.UpdateDatabase();
            //var emails = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<Email>().ToList();
            //foreach (var email in emails)
            //{
            //    email.IsValid = true;
            //    email.Persist();
            //}



            var l = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<IPInfo>().ToList();
            foreach (var ipInfo in l)
            {
                ipInfo.UpdateIPInformation(ipInfo.IP);
                ipInfo.Persist();
            }
            foreach (var trackData in l)
            {

                var ipinfo = new IPInfo();
                ipinfo.UpdateIPInformation("2.179.81.30");

                //trackData.ip = ipinfo;
            }
            MessageBox.Show("ok");
        }

        private void RadMenuItem7Click(object sender, EventArgs e)
        {
            var o = new PersonContacts();
            o.ShowDialog();
        }


        private int DownloadTrackData(Telerik.WinControls.UI.RadProgressBarElement progressBar)
        {
            int trackupates = 0;

            UpdateSyncPersent(progressBar, 0, 100);
            var tracks = DataAccess.NhSession.Query<TrackItem>();
            foreach (var trackItem in tracks)
            {
                Updaterichtextbox1("Downloading Track " + trackItem.TrackTitle + "... ");

                var item = trackItem;
                var trd = new TrackData();
                var query2 =trd.LoadAll()// SWSPEmailTracker.web.Infrastructure.DataAccess.NhSession.Query<SWSPEmailTracker.web.SWSPETl.Model.TrackData>()
                    .Where(x => x.TrackID == item.Id.ToString());


                var list2 = query2.ToList();

                UpdateSyncPersent(progressBar, 0, list2.Count);
                //SWSPEmailTracker.web.Infrastructure.DataAccess.Flush();

                Updaterichtextbox1("Track " + trackItem.TrackTitle + ":" + list2.Count.ToString());
                trackupates += list2.Count;
                foreach (var trackData in list2)
                {

                    UpdateSyncPersent(progressBar, progressBar.Value1 + 1, list2.Count);

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
                    var td = new SWSPET.BL.SWSPET.Model.TrackData
                                 {
                                     DateTime = trackData.DateTime,
                                     VisitorID = visitor,
                                     VisitorIP = trackData.VisitorIP,
                                     SessionID = trackData.SessionID,
                                     TrackID = trackItem,
                                     Descr = trackData.Descr,
                                     IP = ipinfo

                                 };
                    td.Persist();

                    trackData.Delete();

                }
            }
            //
            //SWSPET.BL.Infrastructure.DataAccess.CreateDatabase();
            //SWSPEmailTracker.web.Infrastructure.DataAccess.Flush();
            return trackupates;
        }
        private Person NewContactPerson(string displayname, string emailaddress)
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
                var e = new Email { Value = emailaddress, IsValid = true ,CreateDate = DateTime.Now};
                e.Persist();
                var p = new Person { FamilyName = displayname };
                p.Emails.Add(e);
                p.Persist();
                person = p;
            }
            return person;

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

        private int ReceiveMails(Pop3Client pop3Client, Telerik.WinControls.UI.RadProgressBarElement progressBar, string server, int serverport, string loginname, string password, bool SSL, bool DeleteAfterFetch)
        {
            int mailrecived = 0;
            var emails = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<Email>().ToList();

            UpdateSyncPersent(progressBar, 0, 100);

            try
            {

                if (pop3Client.Connected)
                    pop3Client.Disconnect();
                pop3Client.Connect(server, serverport, SSL);
                pop3Client.Authenticate(loginname, password);
                var count = pop3Client.GetMessageCount();
                Updaterichtextbox1("New Emails: " + count.ToString());

                UpdateSyncPersent(progressBar, 0, count);

                int success = 0;
                int fail = 0;
                for (int i = count; i >= 1; i -= 1)
                {

                    UpdateSyncPersent(progressBar, progressBar.Value1 + 1, count);


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
                                    if (DeleteAfterFetch) { pop3Client.DeleteMessage(i); }

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
                                    if (DeleteAfterFetch) { pop3Client.DeleteMessage(i); }

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
                                if (DeleteAfterFetch) { pop3Client.DeleteMessage(i); }

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
                if (pop3Client.Connected) {pop3Client.Disconnect();}
                Updaterichtextbox1("Finished.");
                // Enable the buttons again
                //   connectAndRetrieveButton.Enabled = true;
                // uidlButton.Enabled = true;
                //progressBar.Value = 100;
            }
            return mailrecived;
        }


        private void UpdateSync(bool firstupdate, int delay)
        {

            UpdateSyncPersent(radProgressBarElement2, 0, 100);

            Application.DoEvents();
            //download track data
            Updaterichtextbox1("Downloading Track Data . . . ");
            int trackupdates = DownloadTrackData(radProgressBarElement2);

            //download recived emails
            var pop3Client = new Pop3Client();
            Updaterichtextbox1("Downloading Recived CNWTC.co Emails  . . .");

            Application.DoEvents();
            var mailrecived = 0;
            mailrecived = ReceiveMails(pop3Client, radProgressBarElement2, "mail.cnwtc.co", 110, "info@CNWTC.co", "a@12345678", false, true);

            Updaterichtextbox1("Downloading Recived Gmail  . . .");

            Application.DoEvents();
            mailrecived += ReceiveMails(pop3Client, radProgressBarElement2, "pop.gmail.com", 995, "cnwtc.christina@gmail.com", "a@12345678", true, true);

            Updaterichtextbox1("Downloading Recived Yahoo  . . .");

            Application.DoEvents();
            mailrecived += ReceiveMails(pop3Client, radProgressBarElement2, "pop.mail.yahoo.com", 995, "cnwtcchristina", "a@12345678", true, true);


            Updaterichtextbox1("Downloading Recived HOTMAIL  . . .");

            Application.DoEvents();
            mailrecived += ReceiveMails(pop3Client, radProgressBarElement2, "pop3.live.com", 995, "christina.cnwtc@hotmail.com", "a@12345678", true, true);

            Updaterichtextbox1("Downloading Recived Christina @ CNWTC.co  . . .");

            Application.DoEvents();
            mailrecived = ReceiveMails(pop3Client, radProgressBarElement2, "mail.cnwtc.co", 110, "christina@CNWTC.co", "a@12345678", false, true);

            //Updaterichtextbox1("Downloading Recived hrgsoft  . . .");

            //Application.DoEvents();
            //mailrecived += ReceiveMails(pop3Client, radProgressBarElement2, "mail.smartwsp.com", 110, "info@hrgsoft.ir", "ha1487606", false, true);

            Application.DoEvents();
            if (trackupdates > 0 || firstupdate) Updategraphcontry();
            Application.DoEvents();
            if (mailrecived > 0 || firstupdate) loadincommingemails();
            Application.DoEvents();
            if (mailrecived > 0 || firstupdate || trackupdates > 0)
            {
                try
                {
                    AddNodes();
                }
                catch (Exception exception) { }
            }
            Application.DoEvents();
            if (mailrecived == 0 && trackupdates == 0)
            {
                delay = 2 * delay;
                delay = Math.Min(delay, 54000000);
            }
            else
            {
                delay = 60000;
            }
            Updaterichtextbox1("wait for " + delay + "ms");
            System.Threading.Thread.Sleep(delay);

            UpdateSync(false, delay);
        }
        private void CommandBarButton2Click2(object sender, EventArgs e)
        {
            commandBarButton2.Enabled = false;
            radRichTextBox1.Text = "";


            var tStart = new Thread(() => UpdateSync(true, 60000));
            
            //tStart.Abort();
            tStart.Start();

        }
        private void Updaterichtextbox1(string s)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)(() => Updaterichtextbox1(s)));
            }
            else
            {

                radRichTextBox1.Text += s + Resources.NewLine;
                Application.DoEvents();
            }
        }
        private void UpdateSyncPersent(Telerik.WinControls.UI.RadProgressBarElement pb, int val1, int max)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)(() => UpdateSyncPersent(pb, val1, max)));
            }
            else
            {
                pb.Maximum = max;
                pb.Value1 = Math.Min(max, val1);

                Application.DoEvents();
            }
        }

        private void RadRichTextBox1TextChanged(object sender, EventArgs e)
        {
            radRichTextBox1.SelectionStart = radRichTextBox1.Text.Length; //Set the current caret position at the end
            radRichTextBox1.ScrollToCaret(); //Now scroll it automatically
        }
        public class Groupdata
        {
            public virtual long Count { get; set; }
            private string _name;


            public virtual string Name { get { return _name ?? string.Empty; } set { _name = value; } }
        }
        private void Updategraphcontry()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)(Updategraphcontry));
            }
            else
            {

                var res = DataAccess.NhSession.CreateSQLQuery("select  top 10 countrycode as Name,COUNT(*) as Count from ipinfo group by countrycode order by count(*) desc")
                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Groupdata)))
                            .List<Groupdata>();

                radChart1.Series.Clear();

                radChart1.DataSource = res;

                radChart1.PlotArea.XAxis.DataLabelsColumn = "Name";
                radChart1.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Font = new System.Drawing.Font("Ariel", 8);


                radChart1.DataBind();

                Application.DoEvents();
            }
        }
        private void commandBarButton8_Click(object sender, EventArgs e)
        {


        }

        private void radChart1_DataBound(object sender, EventArgs e)
        {
            try
            {
                radChart1.Series[0].DataYColumn = "Count";
            }catch(Exception exception){}

        }

        private void commandBarButton3_Click(object sender, EventArgs e)
        {
            var o = new SendingMail();
            o.ShowDialog();
        }

        private void commandBarButton1_Click(object sender, EventArgs e)
        {
            loadincommingemails();
        }

        private void loadincommingemails()
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)(loadincommingemails));
            }
            else
            {
                var l =
                    DataAccess.NhSession.Query<IncommingEmail>().Where(x => x.IsRead == false).OrderByDescending(
                        x => x.SentDate).OrderByDescending(x => x.Date).ToList();
                radGridView1.DataSource = l;
            }
        }

        private void commandBarButton8_Click_1(object sender, EventArgs e)
        {

            if (radGridView1.SelectedRows[0].DataBoundItem != null)
            {
                var a = (IncommingEmail)radGridView1.SelectedRows[0].DataBoundItem;
                DataAccess.NhSession.Flush();
                var o = new ShowEmail(a);

                o.ShowDialog();
                loadincommingemails();
            }
            else
            {
                MessageBox.Show("Please select an email.");
            }
        }
        private void AddNodes()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)(AddNodes));
            }
            else
            {
                radTreeView1.Nodes.Clear();
                var res = DataAccess.NhSession.CreateSQLQuery("select 'Unread' as Name ,COUNT(*) as Count  from incommingemail where isread=0 ")
                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Groupdata)))
                            .List<Groupdata>();


                //
                //
                var node1 = new RadTreeNode("Unread Emails (" + res.First().Count + ")")
                                {
                                    Tag = "Unread Email",
                                    //BackColor = Color.LightBlue,
                                    Image = Image.FromFile(Application.StartupPath + @"\IMG\unreademail.png"),
                                    ItemHeight = 32,
                                    ForeColor = Color.Navy,
                                    Font = new Font("Times New Roman", 10, FontStyle.Bold),
                                };

                radTreeView1.Nodes.Add(node1);

                res = DataAccess.NhSession.CreateSQLQuery("select dbo.get_PersonName(cast(From_id as nvarchar(max))) as Name,COUNT(*) as Count from incommingemail where isread=0 group by From_id")
                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Groupdata)))
                            .List<Groupdata>();

                foreach (var groupdata in res)
                {
                    var groupdataode2 = new RadTreeNode(groupdata.Name + "(" + groupdata.Count + ")")
                                            {
                                                Image = Image.FromFile(Application.StartupPath + @"\IMG\contacts.png"),
                                                ItemHeight = 32
                                            };

                    node1.Nodes.Add(groupdataode2);
                }





                res = DataAccess.NhSession.CreateSQLQuery("select 'Unread' as Name ,COUNT(*) as Count  from incommingemail where isimportant=1 ")
                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Groupdata)))
                            .List<Groupdata>();


                //
                //
                var node3 = new RadTreeNode("Important Emails (" + res.First().Count + ")")
                                {
                                    Tag = "Important Email",
                                    //BackColor = Color.LightBlue,
                                    Image = Image.FromFile(Application.StartupPath + @"\IMG\important.png"),
                                    ItemHeight = 32,
                                    ForeColor = Color.Navy,
                                    Font = new Font("Times New Roman", 10, FontStyle.Bold),
                                };

                radTreeView1.Nodes.Add(node3);

                res = DataAccess.NhSession.CreateSQLQuery("select dbo.get_PersonName(cast(From_id as nvarchar(max))) as Name,COUNT(*) as Count from incommingemail where isimportant=1 group by From_id")
                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Groupdata)))
                            .List<Groupdata>();

                foreach (var groupdata in res)
                {
                    var groupdataode2 = new RadTreeNode(groupdata.Name + "(" + groupdata.Count + ")")
                    {
                        Image = Image.FromFile(Application.StartupPath + @"\IMG\contacts.png"),
                        ItemHeight = 32
                    };

                    node3.Nodes.Add(groupdataode2);
                }

                var node4 = new RadTreeNode("Track Items ")
                {
                    Tag = "Important Email",
                    BackColor = Color.LightCyan,
                    Image = Image.FromFile(Application.StartupPath + @"\IMG\track.jpg"),
                    //ForeColor = Color.MidnightBlue,
                    Font = new Font("Times New Roman", 10, FontStyle.Bold),
                };

                radTreeView1.Nodes.Add(node4);

                res = DataAccess.NhSession.CreateSQLQuery("select dbo.get_track_item_title(TrackID_id) as Name,COUNT(*) as Count from TrackData group by TrackID_id")
                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Groupdata)))
                            .List<Groupdata>();

                foreach (var groupdata in res)
                {
                    var groupdataode2 = new RadTreeNode(groupdata.Name + "(" + groupdata.Count + ")")
                    {
                        //                    Image = Image.FromFile(Application.StartupPath + @"\IMG\track.jpg"),
                        //      ItemHeight = 32
                    };

                    node4.Nodes.Add(groupdataode2);
                }



                var node5 = new RadTreeNode("Interested Persons ")
                {
                    Tag = "Interested Person",
                    BackColor = Color.LightCyan,
                    Image = Image.FromFile(Application.StartupPath + @"\IMG\intrested.png"),
                    //ForeColor = Color.MidnightBlue,
                    Font = new Font("Times New Roman", 10, FontStyle.Bold),
                };

                radTreeView1.Nodes.Add(node5);

                res = DataAccess.NhSession.CreateSQLQuery("select top 100  cast(VisitorID_id as nvarchar(max)) as Name,COUNT(*) as Count from TrackData group by VisitorID_id order by COUNT(*) desc")
                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Groupdata)))
                            .List<Groupdata>();

                foreach (var groupdata in res)
                {
                    try
                    {
                        var p =
                            DataAccess.NhSession.Query<Person>().Where(x => x.Id.ToString() == groupdata.Name).ToList().
                                First();
                        var groupdataode2 = new RadTreeNode(p.Descriptor + "(" + groupdata.Count + ")");

                        var resa = DataAccess.NhSession.CreateSQLQuery("exec dbo.PersonTracks '" + p.Id + "'")
                            .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(PersonTrack)))
                            .List<PersonTrack>();

                        foreach (var groupdata5 in resa)
                        {
                            var groupdataode3 =
                                new RadTreeNode(groupdata5.trackName + "(" + groupdata5.VisitorIP + ")" +
                                                groupdata5.location + "-" + groupdata5.DateTime.ToString());
                            groupdataode2.Nodes.Add(groupdataode3);
                        }

                        groupdataode2.Image = Image.FromFile(Application.StartupPath + @"\IMG\loction.png");
                        node5.Nodes.Add(groupdataode2);
                    }
                    catch (Exception ex)
                    {
                    }

                }

                //node2.Nodes.Add(Node4);
                ////Alternative methods for adding nodes
                ////RadTreeNode Node1 = radTreeView1.Nodes.Add("Node1");
                ////RadTreeNode Node2 = radTreeView1.Nodes.Add("Node2");
                ////Node1.Nodes.Add("Node3");
                //Node2.Nodes.Add("Node4");
            }
        }

        public class PersonTrack
        {
            public DateTime DateTime
            {
                get;
                set;
            }
            public string VisitorIP { get; set; }
            public string location { get; set; }
            public string trackName { get; set; }
        }
        private void commandBarButton5_Click(object sender, EventArgs e)
        {

        }

        private void commandBarButton4_Click(object sender, EventArgs e)
        {
            var o = new PersonContacts();
            o.ShowDialog();

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            var a = new Telnet("mail.smartwsp.com", 25, 30);
            //a.Check();
            bool aa ;//= a.SearchMx("info", "smartwsp.com");
            var email = DataAccess.NhSession.Query<Email>().ToList();
            foreach (var email1 in email)
            {
                if (email1.Value.Contains('@'))
                {
                    var sp = email1.Value.Split('@');
                    aa = a.SearchMx(sp[0], sp[1]);
                    email1.IsValid = aa;
                    Updaterichtextbox1(email1.Value+ " :"+aa.ToString());
                    email1.Persist();

                }else
                {
                    email1.IsValid = false;
                    Updaterichtextbox1(email1.Value + " : False");
                    email1.Persist();
                }
            }



        }

        private void documentWindow3_Enter(object sender, EventArgs e)
        {
            documentWindow3.Controls.Clear();
            var a = new RecentContacts();
            a.Dock = DockStyle.Fill;
            documentWindow3.Controls.Add(a);

            //MessengerAPI.Messenger MSN = new MessengerAPI.Messenger();



        }

        private void radCommandBar2_Click(object sender, EventArgs e)
        {
            
        }

        private void commandBarButton1_Click_1(object sender, EventArgs e)
        {
            ImportContact o = new ImportContact();
            o.ShowDialog();

        }

        private void commandBarButton5_Click_1(object sender, EventArgs e)
        {

            var d = DataAccess.NhSession.Query<Email>().Where(x => x.Value == commandBarTextBox1.Text).ToList();
            richTextBox1.Text = "";
            foreach (var email in d)
            {
                var t = DataAccess.NhSession.Query<SWSPET.BL.SWSPET.Model.TrackData>().Where(x => x.VisitorID == email.Person).ToList();
                foreach (var trackData in t)
                {
                    SWSPET.BL.SWSPET.Model.TrackData data = trackData;
                    var dm =
                        DataAccess.NhSession.Query<SWSPET.BL.SWSPET.Model.TrackItem>().Where(x => x== data.TrackID).ToList();
                    string tnam = trackData.TrackID.TrackId;
                    if (dm.Count > 0) {
                        tnam = dm.First().TrackTitle; }
                    richTextBox1.Text +=tnam+" : "+ "IP:"+trackData.VisitorIP+" Date:"+trackData.DateTime.ToString()+"\r\n";
                }
            }

        }

        private void radMenuItem8_Click(object sender, EventArgs e)
        {
           
        }

        private void commandBarButton6_Click(object sender, EventArgs e)
        {
            var a = new TemplateManagerEditor();
            a.ShowDialog();
        }

        private void commandBarButton7_Click(object sender, EventArgs e)
        {
            var a = new SWSPEmailTracker.PersonTrack();
            a.ShowDialog();
        }

        private void radCommandBar3_Click(object sender, EventArgs e)
        {

        }

        private void radCommandBar1_Click(object sender, EventArgs e)
        {

        }

    }


}
