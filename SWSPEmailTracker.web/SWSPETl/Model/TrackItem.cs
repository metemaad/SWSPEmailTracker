using System;
using SWSPEmailTracker.web.Infrastructure;

namespace SWSPEmailTracker.web.SWSPETl.Model
{
    public class TrackItem : Entity
    {
        public virtual string TrackTitle { get { return Id.ToString(); } }

        public virtual string TrackId
        {
            get { return Id.ToString(); }
        }

        
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