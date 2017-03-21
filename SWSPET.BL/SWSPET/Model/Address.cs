using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class Address:Entity
    {
        public virtual Person Person { get; set; }
        public virtual string Type { get; set; }
        public virtual string Formatted { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string POBox { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }

        public virtual string Country { get; set; }
        public virtual string ExtendedAddress { get; set; }
        public override string Descriptor
        {
            get
            {
                return "No:"+POBox+","+Street+"St."+","+City+","+Country+","+ExtendedAddress+"PostalCode:"+PostalCode;
            }
        }
        public override string TypeDesc
        {
            get { return "Address"; }
        }
    }
}