using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class PhonesMap : ClassMap<Phone>
    {
        public PhonesMap()
        {
            Id(x => x.Id);
            Map(x => x.Type);
            Map(x => x.Value).Index("PhoneValueIndex");
            References(x => x.Person);
            
        }
    }
   
}
