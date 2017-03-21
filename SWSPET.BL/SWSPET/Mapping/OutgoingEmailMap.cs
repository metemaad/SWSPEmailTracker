using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class OutgoingEmailMap : ClassMap<OutgoingEmail>
    {
        public OutgoingEmailMap()
        {
            Id(x => x.Id);
            Map(x => x.OriginalMessage).Length(2147483647).CustomSqlType("varbinary(MAX)").Not.LazyLoad();
            Map(x => x.BodyPlain).Length(2147483647).CustomSqlType("nvarchar(MAX)").Not.LazyLoad().Index("OutgoingEmailBodyPlainIndex");
            Map(x => x.Date).Index("OutgoingEmailDateIndex");
            Map(x => x.MessageID).Length(2147).CustomSqlType("nvarchar(MAX)").Not.LazyLoad().Index("OutgoingEmailMessageIDIndex");
            Map(x => x.SentDate).Index("OutgoingEmailSentDateIndex");
            Map(x => x.IsRead).Default("0").Index("OutgoingEmailIsReadIndex");
            Map(x => x.Subject).Length(2147483647).CustomSqlType("nvarchar(MAX)").Not.LazyLoad().Index("OutgoingEmailSubjectIndex");

            References(x => x.Recipient).Not.LazyLoad().Index("OutgoingEmailRecipientIndex");
            References(x => x.Sender).Not.LazyLoad().Index("OutgoingEmailSenderIndex");

            HasMany(x => x.EmailAttachment).LazyLoad().Cascade.All();

        }
    }
}