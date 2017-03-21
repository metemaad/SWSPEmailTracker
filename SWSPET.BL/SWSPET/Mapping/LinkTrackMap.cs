using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class LinkTrackMap : SubclassMap<LinkTrack>
    {
        public LinkTrackMap()
        {
            //Id(x => x.Id);
            Map(x => x.Title);

        }
    }
}