using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class IPInfoMap:ClassMap<IPInfo>
    {
        public IPInfoMap()
        {
            Id(x => x.Id);
            Map(x => x.IP).Index("IPInfoIPIndex");
            Map(x => x.Latitude);
            Map(x => x.Longitude);
            Map(x => x.CountryCode).Index("IPInfoCountryCodeIndex");
            Map(x => x.CountryName);
            Map(x=>x.City);
            Map(x=>x.AreaCode);
            Map(x=>x.MetroCode);
            Map(x=>x.RegionCode);
            Map(x=>x.RegionName);
            Map(x=>x.ZipCode);

        }

    }
}