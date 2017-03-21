using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class FinalRecipientMap : ClassMap<FinalRecipient>
    {
        public FinalRecipientMap()
        {
            Id(x => x.Id);
            Map(x => x.ReceivedFromEmail).Length(int.MaxValue);
            Map(x => x.Type);
            
        }

    }
}