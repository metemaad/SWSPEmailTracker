using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class EmailFailedDeliveryStatusMap : ClassMap<EmailFailedDeliveryStatus>
    {
        public EmailFailedDeliveryStatusMap()
        {
            Id(x => x.Id);
            Map(x => x.Action).Length(int.MaxValue);
            Map(x => x.ArrivalDate).Length(int.MaxValue);
            Map(x => x.DiagnosticCode).Length(2147483647).CustomSqlType("nvarchar(MAX)").Not.LazyLoad();
            References(x => x.FinalRecipient);
            Map(x => x.LastAttemptDate).Length(250);
            Map(x => x.ReceivedFromMTA).Length(int.MaxValue);
            Map(x => x.RemoteMTA).Length(int.MaxValue);
            Map(x => x.ReportingMTA).Length(int.MaxValue);
            Map(x => x.Status).Length(int.MaxValue);
        }

    }
}
