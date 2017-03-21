using System;
using System.ComponentModel;
using SWSPEmailTracker.web.Infrastructure;

namespace SWSPEmailTracker.web.SWSPETl.Model
{
    public class TrackGRPData :Entity
    {
         
        [DisplayName("TrackID")]
        public virtual string TrackID { get; set; }
        [DisplayName("Count")]
        public virtual int Count { get; set; }

        public override string TypeDesc
        {
            get { return ""; }
        }

        public override bool Update()
        {
            throw new NotImplementedException();
        }
    }
}