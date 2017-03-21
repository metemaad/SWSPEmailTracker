using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class IncommingEmailMap:ClassMap<IncommingEmail>
    {
        public IncommingEmailMap()
        {
            Id(x => x.Id);
            Map(x => x.OriginalMessage).Length(2147483647).CustomSqlType("varbinary(MAX)").Not.LazyLoad();
            Map(x => x.HTMLBody).Length(2147483647).CustomSqlType("nvarchar(MAX)").Not.LazyLoad().Index("IncommingEmailHTMLBodyIndex"); 
            Map(x => x.TextBody).Length(2147483647).CustomSqlType("nvarchar(MAX)").Not.LazyLoad().Index("IncommingEmailTextBodyIndex"); 
            Map(x => x.Date).Index("IncommingEmailDateIndex");
            Map(x => x.InReplayTo).Length(2147483647).CustomSqlType("nvarchar(MAX)").Not.LazyLoad();
            Map(x => x.MessageID).Length(2147).CustomSqlType("nvarchar(MAX)").Not.LazyLoad().Index("IncommingEmailMessageIDIndex");
            Map(x => x.SentDate).Index("IncommingEmailSentDateIndex");
            Map(x => x.IsRead).Default("0").Index("IncommingEmailIsReadIndex");
            Map(x => x.IsImportant).Default("0").Index("IncommingEmailIsImportantIndex");
            Map(x => x.Subject).Length(2147483647).CustomSqlType("nvarchar(MAX)").Not.LazyLoad().Index("IncommingEmailSubjectIndex");

            References(x => x.From).Not.LazyLoad().Index("IncommingEmailFromIndex");
            References(x => x.ReplayTo).Not.LazyLoad().Index("IncommingEmailReplayToIndex");
            References(x => x.ReturnPath).Not.LazyLoad().Index("IncommingEmailReturnPathIndex");
            References(x => x.Sender).Not.LazyLoad().Index("IncommingEmailSenderIndex");

            HasMany(x => x.BCC).LazyLoad().Cascade.All();
            HasMany(x => x.CC).LazyLoad().Cascade.All();
            HasMany(x => x.TO).LazyLoad().Cascade.All();
            HasMany(x => x.EmailAttachment).LazyLoad().Cascade.All();
        }
    }
}