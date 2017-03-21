using FluentNHibernate.Mapping;
using SWSPEmailTracker.web.SWSPETl.Model;

namespace SWSPEmailTracker.web.SWSPETl.Mapping
{
    public class TrackItemMap : ClassMap<TrackItem>
    {
        public TrackItemMap()
        {
            Id(x => x.Id);
            
        }
    }
}