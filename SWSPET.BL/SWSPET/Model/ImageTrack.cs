using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using SWSPET.BL.Login.Model;

namespace SWSPET.BL.SWSPET.Model
{
    public class TrackImage : TrackItem
    {

        public virtual string Title { get; set; }
        // public virtual User Owner { get; set; }
        public virtual byte[] TrackImageByte { get; set; }

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
                //mhttp://www.cnwtc.co/webmail/images/VisitorIDentificationNumber/c7db7925-0187-4a4f-a291-a1be0005f72b/a1.jpg
                return "<img src=\"" + emailsenderengine + "/images/VisitorIDentificationNumber/" + Id.ToString() + "/a1.jpg\">";
            }
        }

        //private abstract void uploadImage( string  ftpserver, string username,string password);
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
