using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class EmailMap : ClassMap<Email>
    {
        public EmailMap()
        {
            Id(x => x.Id);
            Map(x => x.Type);

            Map(x => x.Value).Index("EmailValueIndex");
            Map(x => x.IsPrimery).Index("EmailIsPrimeryIndex");
            Map(x => x.IsValid).Index("EmailIsValidIndex");
            Map(x => x.CreateDate);
            References(x => x.EmailFailedDeliveryStatus).Not.LazyLoad();
            References(x => x.Person).Not.LazyLoad();

        }
    }
    
}
