using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using NHibernate.Linq;
using OpenPop.Common.Logging;
using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using SWSPET.BL.SWSPET.Model;
using SWSPET.BL.emlreader;
using Message = OpenPop.Mime.Message;

namespace SWSPEmailTracker
{
    public partial class pop3test : Form
    {
        public pop3test()
        {
            InitializeComponent();
        }

        private void radRepeatButton1_Click(object sender, EventArgs e)
        {
            var pop3Client = new Pop3Client();
            
            ReceiveMails(pop3Client);

           

        }
        private void ReceiveMails( Pop3Client pop3Client )
        {
            var emails = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<Email>().ToList();
            progressBar.Value1 = 0;

            try
            {

                if (pop3Client.Connected)
                    pop3Client.Disconnect();
                pop3Client.Connect("mail.smartwsp.com",110,false);
                pop3Client.Authenticate("info@smartwsp.com","ha1487606");
                int count = pop3Client.GetMessageCount();
                //totalMessagesTextBox.Text = count.ToString();
                //messageTextBox.Text = "";
                //messages.Clear();
                //listMessages.Nodes.Clear();
                //listAttachments.Nodes.Clear();
                
                int success = 0;
                int fail = 0;
                for (int i = count; i >= 1; i -= 1)
                {
                
                    if (IsDisposed)
                        return;

                    Application.DoEvents();

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

                        if (message.MessagePart.IsMultiPart==true && message.MessagePart.MessageParts.Count>1)
                        {

                            if (message.MessagePart.MessageParts[1].ContentType.MediaType == "message/delivery-status")
                            {
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
                                                    var fr = new FinalRecipient
                                                                 {ReceivedFromEmail = rr[1], Type = rr[0]};
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
                                    
                                catch(Exception ex)
                                {
                                    MessageBox.Show(message.MessagePart.MessageParts[1].GetBodyAsText() + "\r\n" +
                                                    ex.Message);
                                }finally
                                {
                                    pop3Client.DeleteMessage(i);

                                }
                            }
                        }
//                        byte[] bytes = message.MessagePart.MessageParts[1].Body;
//                        // this get's the MailMessage into Peter's RxMailMessage class
//                        // which is derived from the MS MailMessage class
//                        MemoryStream stream = new MemoryStream();
//                        stream.Write(bytes, 0, bytes.Length);
                        
////                        import email

////msg = email.message_from_string(emailstr)

////if (msg.is_multipart() and len(msg.get_payload()) > 1 and 
////    msg.get_payload(1).get_content_type() == 'message/delivery-status'):
////    # email is DSN
////    print(msg.get_payload(0).get_payload()) # human-readable section

////    for dsn in msg.get_payload(1).get_payload():
////        print('action: %s' % dsn['action']) # e.g., "failed", "delivered"

////    if len(msg.get_payload()) > 2:
////        print(msg.get_payload(2)) # original message
//                        RxMailMessage mm = mime.GetEmail(stream);
                        success++;
                    }
                    catch (Exception e)
                    {
                        DefaultLogger.Log.LogError(
                            "TestForm: Message fetching failed: " + e.Message + "\r\n" +
                            "Stack trace:\r\n" +
                            e.StackTrace);
                        fail++;
                    }

                    progressBar.Value1 = (int)(((double)(count - i) / count) * 100);
                }

                MessageBox.Show(this, "Mail received!\nSuccesses: " + success + "\nFailed: " + fail, "Message fetching done");

                if (fail > 0)
                {
                    MessageBox.Show(this,
                                    "Since some of the emails were not parsed correctly (exceptions were thrown)\r\n" +
                                    "please consider sending your log file to the developer for fixing.\r\n" +
                                    "If you are able to include any extra information, please do so.",
                                    "Help improve OpenPop!");
                }
            }
            catch (InvalidLoginException)
            {
                MessageBox.Show(this, "The server did not accept the user credentials!", "POP3 Server Authentication");
            }
            catch (PopServerNotFoundException)
            {
                MessageBox.Show(this, "The server could not be found", "POP3 Retrieval");
            }
            catch (PopServerLockedException)
            {
                MessageBox.Show(this, "The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
            }
            catch (LoginDelayException)
            {
                MessageBox.Show(this, "Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Error occurred retrieving mail. " + e.Message, "POP3 Retrieval");
            }
            finally
            {
                // Enable the buttons again
             //   connectAndRetrieveButton.Enabled = true;
               // uidlButton.Enabled = true;
                progressBar.Value1 = 100;
            }
        }

    }
}
