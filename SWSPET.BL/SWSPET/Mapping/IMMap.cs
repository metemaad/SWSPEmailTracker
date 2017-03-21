using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class IMMap : ClassMap<IM>
    {
        public IMMap()
        {
            Id(x => x.Id);
            Map(x => x.Type);
            Map(x => x.Value);

        }
    }
    
}
