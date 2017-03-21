using System;
using System.Collections.Generic;
using System.ComponentModel;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class OutgoingEmail:Entity<OutgoingEmail>
    {
        public virtual byte[] OriginalMessage { get; set; }
        public virtual Person Sender { get; set; }
        public virtual bool IsRead { get; set; }
        [DisplayName("Date")]
        public virtual string Date { get; set; }
        public virtual DateTime SentDate { get; set; }

        public virtual Person Recipient { get; set; }

        public virtual string MessageID { get; set; }

        [DisplayName("Subject")]

        public virtual string Subject { get; set; }
        public virtual string BodyPlain { get; set; }
        private IList<EmailAttachment> _emailAttachment;
        public virtual IList<EmailAttachment> EmailAttachment
        {
            get { return _emailAttachment ?? (_emailAttachment = new List<EmailAttachment>()); }
            set { _emailAttachment = value; }
        }



    }
}