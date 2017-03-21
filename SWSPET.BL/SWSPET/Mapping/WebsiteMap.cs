using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class WebsiteMap : ClassMap<Website>
    {
        public WebsiteMap()
        {
            Id(x => x.Id);
            Map(x => x.Type);
            Map(x => x.Value).Index("WebsiteValueIndex");

        }
    }
    
   
}
