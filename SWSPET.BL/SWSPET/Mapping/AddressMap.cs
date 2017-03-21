using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Id(x => x.Id);
            Map(x => x.City);
            Map(x => x.Country);
            Map(x => x.ExtendedAddress);
            Map(x => x.Formatted);
            Map(x => x.POBox);
            Map(x => x.PostalCode);
            Map(x => x.Region);
            Map(x => x.Street);
            Map(x => x.Type);
        }
    }
}
