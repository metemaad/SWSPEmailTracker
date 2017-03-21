using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class Organization:Entity
    {
        public virtual Person Person { get; set; }
        public virtual string Type { get; set; }
        public virtual string Name { get; set; }
        public virtual string YomiName { get; set; }
        public virtual string Title { get; set; }
        public virtual string Department { get; set; }
        public virtual string Symbol { get; set; }
        public virtual string Location { get; set; }
        public virtual string JobDescription { get; set; }

        public override string TypeDesc
        {
            get { return "Organization"; }
        }
    }
}