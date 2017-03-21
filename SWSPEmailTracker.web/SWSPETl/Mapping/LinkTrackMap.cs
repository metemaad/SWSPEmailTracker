using FluentNHibernate.Mapping;
using SWSPEmailTracker.web.SWSPETl.Model;

namespace SWSPEmailTracker.web.SWSPETl.Mapping
{
    public class LinkTrackMap : SubclassMap<LinkTrack>
    {
        public LinkTrackMap()
        {
            //Select Title,TrackDest from LinkTrack where TrackItem_id='$Id'
            //Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.TrackDest);// using full addresshttp://www.cnwtc.co/

        }
    }
}