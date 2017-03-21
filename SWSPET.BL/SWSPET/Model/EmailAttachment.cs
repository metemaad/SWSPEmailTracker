using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class EmailAttachment:Entity
    {

        public virtual byte[] AttachmentData { get; set; }
        public virtual string AttachmentType { get; set; }
        public virtual string FileName { get; set; }
        public override string TypeDesc
        {
            get { return ""; }
        }
    }
}