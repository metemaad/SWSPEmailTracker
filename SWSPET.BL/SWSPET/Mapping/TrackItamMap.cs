using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class TrackItamMap : ClassMap<TrackItem>
    {
        public TrackItamMap()
        {
            Id(x => x.Id);
            Map(x => x.ServerTrackID);
            
        }
    }
}