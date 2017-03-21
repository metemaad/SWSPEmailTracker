using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class IM:Entity
    {
        public virtual string Type { get; set; }
        public virtual string Service { get; set; }
        public virtual string Value { get; set; }

        public override string TypeDesc
        {
            get { return "IM"; }
        }
    }
}