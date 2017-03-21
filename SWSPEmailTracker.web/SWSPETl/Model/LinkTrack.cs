using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using SWSPEmailTracker.web.Infrastructure;

namespace SWSPEmailTracker.web.SWSPETl.Model
{
    public class LinkTrack : TrackItem
    {
        public virtual string Title { get; set; }
        public virtual string LocalID { get; set; }
        //public virtual User Owner { get; set; }
        public override string TrackTitle
        {
            get { return Title; }

        }
        public override string TrackId
        {
            get { return LocalID.ToString(); }
        }
        public virtual string Tracklink
        {
            get
            {
                var emailsenderengine = ConfigurationManager.ConnectionStrings["SWSPEmailServiceLink"].ConnectionString;
                //mhttp://www.cnwtc.co/webmail/links/VisitorIDentificationNumber/c7db7925-0187-4aff-a291-a1be0005f72b
                return "<a href=\"" + emailsenderengine + "/links/VisitorIDentificationNumber/" + LocalID.ToString() + "\">" + Title + "</a>";
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
        public override bool Update()
        {

            string s = "set @a:='"+LocalID+"';" +
                       "update LinkTrack set Title='"+Title+"',TrackDest='"+TrackDest+"' where TrackItem_id=@a;";

            bool res = false;
            try
            {
                var webDataAccess = new WebDataAccess();
                DataTable a = webDataAccess.ExecQ(s);
                DataRow dr = a.Rows[0];
                LocalID = dr[0].ToString();
                res = true;
            }
            catch (Exception exception)
            {
                res = false;
            }
            return res;
        }
        public override bool Persist()
        {

            string s = "set @a:=UUID();" +
                       "insert into TrackItem (Id) values(@a);" +
                       "insert into LinkTrack (TrackItem_id,Title,TrackDest) values(@a,'" + Title + "','" + TrackDest +
                       "');  select @a as a";

            bool res = false;
            try
            {
                var webDataAccess = new WebDataAccess();
                DataTable a = webDataAccess.ExecQ(s);
                DataRow dr = a.Rows[0];
                LocalID = dr[0].ToString();
                res = true;
            }
            catch (Exception exception)
            {
                res = false;
            }
            return res;
        }
        public override bool Delete()
        {
            bool res = false;
            try
            {
                var webDataAccess = new WebDataAccess();
                var a =
                    webDataAccess.Exec("delete from LinkTrack where TrackItem_id='" + LocalID +

                                       "';  delete from TrackItem where Id='" + LocalID + "'");
                res = a;
            }
            catch (Exception exception)
            {
                res = false;
            }
            return res;
        }
        public virtual IList<LinkTrack> LoadAll()
        {
            var webDataAccess = new WebDataAccess();
            var a = webDataAccess.Populate("Select * from LinkTrack");

            var mappings = new Dictionary<string, string>
                               {
                                   {"Title", "Title"},
                                   {"TrackDest", "TrackDest"},
                                   {"LocalID", "TrackItem_id"},
                               };

            var items = a.ToList<LinkTrack>(mappings);
            return items;
        }
    }
}