using FluentNHibernate.Mapping;
using SWSPET.BL.Loging.Model;

namespace SWSPET.BL.Loging.Mapping
{    public class LogDataMap : ClassMap<LogData>
    {
    public LogDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Txt).Length(int.MaxValue);
            Map(x => x.ObjectType);
            Map(x => x.LogDate);
            Map(x => x.Guid);

            References(x => x.User).Cascade.SaveUpdate();
        }
    }
}
