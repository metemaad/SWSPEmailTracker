using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class Phone:Entity
    {
        public virtual string Type { get; set; }
        public virtual string Value { get; set; }
        public virtual Person Person { get; set; }
        public override string TypeDesc
        {
            get { return "Phone"; }
        }
    }
}