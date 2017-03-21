using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class TrackDataMap : ClassMap<TrackData>
    {
        public TrackDataMap()
        {
            Id(x => x.Id);
            Map(x => x.DateTime).Index("TrackDataDateTimeIndex");
            Map(x => x.Descr).Index("TrackDataDescrIndex");
            Map(x => x.SessionID).Index("TrackDataSessionIDIndex");
            Map(x => x.VisitorIP).Index("TrackDataVisitorIPIndex");

            References(x => x.TrackID).Nullable().Not.LazyLoad().Index("TrackDataTrackIDIndex");
            References(x => x.VisitorID).Nullable().Not.LazyLoad().Index("TrackDataVisitorIDIndex");
            References(x => x.IP).Nullable().Not.LazyLoad().Index("TrackDataIPIndex");
        }
    }
}