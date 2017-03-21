using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class EmailAttachmentMap:ClassMap<EmailAttachment>
    {
        public EmailAttachmentMap()
        {
            Id(x => x.Id);
            Map(x => x.AttachmentData).Length(2147483647).CustomSqlType("varbinary(MAX)").Not.LazyLoad();
            Map(x => x.AttachmentType);
            Map(x => x.FileName);
        }

    }
}