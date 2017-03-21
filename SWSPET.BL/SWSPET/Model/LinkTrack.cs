using System.Configuration;
using SWSPET.BL.Infrastructure;
using SWSPET.BL.Login.Model;

namespace SWSPET.BL.SWSPET.Model
{
    public class LinkTrack : TrackItem
    {
        public virtual string Title { get; set; }

        //public virtual User Owner { get; set; }
        public override string TrackTitle
        {
            get { return Title; }

        }
        public override string TrackId
        {
            get { return Id.ToString(); }
        }
        public virtual string Tracklink
        {
            get
            {
                var emailsenderengine = ConfigurationManager.ConnectionStrings["SWSPEmailServiceLink"].ConnectionString;
                //mhttp://www.cnwtc.co/webmail/links/VisitorIDentificationNumber/c7db7925-0187-4aff-a291-a1be0005f72b
                return "<a href=\"" + emailsenderengine + "/links/VisitorIDentificationNumber/" + Id.ToString() + "\">" + Title + "</a>";
            }
        }
        public virtual string TrackDest { get; set; }
        public override string Descriptor
        {
            get
            {
                return Title;
            }
        }
        public override string TypeDesc
        {
            get { return ""; }
        }
    }
}