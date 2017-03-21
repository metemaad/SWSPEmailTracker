using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class TrackItem : Entity
    {
        public virtual string TrackTitle { get { return Id.ToString(); } }

        public virtual string ServerTrackID { get; set; }
        public virtual string TrackId
        {
            get { return Id.ToString(); }
        }

        
        public override string TypeDesc
        {
            get { return ""; }
        }
    }
}