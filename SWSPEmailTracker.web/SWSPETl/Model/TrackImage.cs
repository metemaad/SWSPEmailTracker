using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using SWSPEmailTracker.web.Infrastructure;

namespace SWSPEmailTracker.web.SWSPETl.Model
{
    public class TrackImage:SWSPEmailTracker.web.SWSPETl.Model.TrackItem
    {

       public virtual string Title { get; set; }
      // public virtual User Owner { get; set; }
       public virtual byte[] TrackImageByte { get; set; }
       
       public override string TrackTitle { get { return Title; }

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
               return "<img src=\"" + emailsenderengine + "/images/VisitorIDentificationNumber/" +LocalID.ToString() + "/a1.jpg\">"; 
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
       public virtual string LocalID { get; set; }
       public override string TypeDesc
       {
           get { return ""; }
       }
       public override bool Update()
       {

           string s = "set @a:='" + LocalID + "';" +
                      "update TrackImage set Title='" + Title + "',TrackImageByte=?p where TrackItem_id=@a; select @a";

           bool res = false;
           try
           {
               var webDataAccess = new WebDataAccess();
               DataTable a = webDataAccess.ExecQP(s,new MySqlParameter("?p",TrackImageByte));
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
           var webDataAccess = new WebDataAccess();
           DataTable dt = webDataAccess.Populate("select UUID() as a;");
           DataRow dr = dt.Rows[0];

           string s = //"set @a:=UUID();" +
                      "insert into TrackItem (Id) values('"+dr[0].ToString()+"');" +
                      "insert into TrackImage (TrackItem_id,Title,TrackImageByte) values('" + dr[0].ToString() + "','" + Title + "',?p);";

           bool res = false;
           try
           {
               
                webDataAccess.ExecP(s,new MySqlParameter("?p",TrackImageByte));
                
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
                   webDataAccess.Exec("delete from TrackImage where TrackItem_id='" + LocalID +

                                      "';  delete from TrackImage where Id='" + LocalID + "'");
               res = a;
           }
           catch (Exception exception)
           {
               res = false;
           }
           return res;
       }
       public virtual IList<TrackImage> LoadAll()
       {
           var webDataAccess = new WebDataAccess();
           var a = webDataAccess.Populate("Select * from TrackImage");

           var mappings = new Dictionary<string, string>
                               {
                                   {"Title", "Title"},
                                   {"TrackImageByte", "TrackImageByte"},
                                   {"LocalID", "TrackItem_id"},
                               };

           IList<TrackImage> items = a.ToList<TrackImage>(mappings);
           return items;
       }
    }
}
