using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class IncommingEmail : Entity<IncommingEmail>
    {
        public virtual bool IsRead { get; set; }
        public virtual bool IsImportant { get; set; }
        public virtual byte[] OriginalMessage { get; set; }

        public virtual Person Sender { get; set; }


        public virtual Person ReplayTo { get; set; }
        public virtual Person ReturnPath { get; set; }
        

        [DisplayName("Subject")]
        [BoldColumnAttribute("Tahoma", 10, FontStyle.Bold)]
        [AutoSize(DataGridViewAutoSizeColumnMode.AllCells)]
        public virtual string Subject { get; set; }



        private IList<Person> _bcc;
        public virtual IList<Person> BCC
        {
            get { return _bcc ?? (_bcc = new List<Person>()); }
            set { _bcc = value; }
        }

        public virtual string BCCDescr
        {
            get
            {
                try
                {
                    return BCC.Aggregate("", (current, person) => current + ("<" + person.Descriptor + "> "));
                }catch
                {
                    return "";
                }
            }
        }

        public virtual string CCDescr
        {
            get
            {
                try
                {
                    return CC.Aggregate("", (current, person) => current + ("<" + person.Descriptor + "> "));
                }
                catch 
                {
                    return "";
                }
            }
        }
        private IList<Person> _cc;
        public virtual IList<Person> CC
        {
            get { return _cc ?? (_cc = new List<Person>()); }
            set { _cc = value; }
        }


        [DisplayName("Date")]
        [AutoSize(DataGridViewAutoSizeColumnMode.AllCells)]
        public virtual string Date { get; set; }
        public virtual DateTime SentDate { get; set; }
        [DisplayName("From")]
        [AutoSize(DataGridViewAutoSizeColumnMode.AllCells)]
        public virtual string FromDesc
        {
            get { return From != null ? From.Descriptor : string.Empty; }
        }
        public virtual Person From { get; set; }

        private IList<Person> _to;
        public virtual IList<Person> TO
        {
            get { return _to ?? (_to = new List<Person>()); }
            set { _to = value; }
        }


        public virtual string InReplayTo { get; set; }
        public virtual string MessageID { get; set; }
        public virtual string HTMLBody { get; set; }
        public virtual string TextBody { get; set; }


        private IList<EmailAttachment> _emailAttachment;
        public virtual IList<EmailAttachment> EmailAttachment
        {
            get { return _emailAttachment ?? (_emailAttachment = new List<EmailAttachment>()); }
            set { _emailAttachment = value; }
        }
        //save the binery
        //save email main info
        //sender ,replay to , returnpath,subject,bcc,cc,date,sentdate,from,inreplayto,messageid,sender,body,attachments

    }
}
