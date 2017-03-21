using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class InboxInformationMap : ClassMap<InboxInformation>
    {
        public InboxInformationMap()
        {
            Id(x => x.Id);
            Map(x => x.Password);
            Map(x => x.Host);
            Map(x => x.UserName);
            Map(x => x.IsSsl);
            Map(x => x.PortPop3);
            Map(x => x.PortSmtp);
            Map(x => x.InboxName);
            Map(x => x.DeleteAfterFetch);
        }
    }
}