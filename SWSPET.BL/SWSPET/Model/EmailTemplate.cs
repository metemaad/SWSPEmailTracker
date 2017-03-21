

using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class EmailTemplate : Entity
    {
        public virtual string EmailSubject { get; set; }

        public virtual string EmailSubjectID
        {
            get { return EmailSubject + Id.ToString(); }
        }
        public virtual byte[] EmailHTMLData { get; set; }
        public virtual byte[] EmailPlainData { get; set; }
        public virtual string SenderUsername { get; set; }
        public virtual string Password { get; set; }
        public virtual string FromName { get; set; }
        public virtual string ReplyTo { get; set; }
        public virtual string Host { get; set; }
        public virtual string DKIMSelector { get; set; }
        public virtual string DKIMDomain { get; set; }

        public virtual string ONLineTemplateID { get; set; }

        public override string Descriptor
        {
            get
            {
                return EmailSubject;
            }
        }
        public override string TypeDesc
        {
            get { return ""; }
        }
    }
}
