using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class EmailTemplateMap : ClassMap<EmailTemplate>
    {
        public EmailTemplateMap()
        {
            Id(x => x.Id);
            Map(x => x.DKIMDomain);
            Map(x => x.DKIMSelector);
            Map(x => x.EmailHTMLData).Length(2147483647).Not.LazyLoad();
            Map(x => x.EmailPlainData).Length(2147483647).Not.LazyLoad();
            Map(x => x.EmailSubject).Index("EmailTemplateEmailSubjectIndex");
            Map(x => x.FromName);
            Map(x => x.Host);
            Map(x => x.Password);
            Map(x => x.ReplyTo);
            Map(x => x.SenderUsername);
            Map(x => x.ONLineTemplateID);
            

        }
    }
}