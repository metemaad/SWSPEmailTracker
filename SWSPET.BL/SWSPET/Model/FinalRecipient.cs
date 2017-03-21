using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class FinalRecipient:Entity
    {
        public virtual string Type { get; set; }
        public virtual string ReceivedFromEmail { get; set; }
        public override string TypeDesc
        {
            get { return "FinalRecipient"; }
        }
    }
}