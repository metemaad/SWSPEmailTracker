using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{
    public class ImageTrackMap : SubclassMap<TrackImage>
    {
        public ImageTrackMap()
        {
            //Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.TrackImageByte).Length(Int32.MaxValue).Not.LazyLoad();

        }
    }
}
