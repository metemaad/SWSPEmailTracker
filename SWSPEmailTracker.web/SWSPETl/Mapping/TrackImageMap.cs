using System;
using FluentNHibernate.Mapping;


namespace SWSPEmailTracker.web.SWSPETl.Mapping
{
    public class TrackImageMap : SubclassMap<web.SWSPETl.Model.TrackImage>
    {
        public TrackImageMap()
        {
            //Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.TrackImageByte).Length(Int32.MaxValue).Not.LazyLoad();
            //.CustomSqlType("varbinary(MAX)")
            
            

        }
    }
}
