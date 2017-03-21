using FluentNHibernate.Mapping;
using SWSPEmailTracker.web.SWSPETl.Model;

namespace SWSPEmailTracker.web.SWSPETl.Mapping
{
    public class TrackDataMap : ClassMap<TrackData>
    {
        public TrackDataMap()
        {
            Id(x => x.Id);
            Map(x => x.DateTime).Index("TrackDataDateTimeIndex"); 
            Map(x => x.VisitorIP).Index("TrackDataVisitorIPIndex");
            Map(x => x.TrackID).Index("TrackDataTrackIDIndex");
            Map(x => x.VisitorID).Index("TrackDataVisitorIDIndex");
            Map(x => x.Descr).Length(2147483647).Not.LazyLoad();
            Map(x => x.SessionID);
            //select TrackID,count(*) as c from TrackData where TrackID=''

        }
    }

   
}
