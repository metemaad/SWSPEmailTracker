using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using SWSPEmailTracker.web.Infrastructure;

namespace SWSPEmailTracker.web.SWSPETl.Model
{
    public class EmailTemplate : Entity
    {
        public virtual string EmailSubject { get; set; }

        public virtual string EmailSubjectID
        {
            get { return EmailSubject +LocalID.ToString(); }
        }
        public virtual byte[] EmailHTMLData { get; set; }
        public virtual byte[] EmailPlainData { get; set; }
        public virtual string SenderUsername { get; set; }
        public virtual string Password { get; set; }
        public virtual string FromName { get; set; }
        public virtual string ReplyTo { get; set; }
        public virtual string Host { get; set; }
        public virtual string DKIMSelector { get; set; }
        public virtual string DKIMDomain { get; set; }
        public virtual string LocalID { get; set; }

        public override bool Update()
        {

            string s = "set @a:='" + LocalID + "';" +
                       " UPDATE EmailTemplate SET DKIMDomain = '" + DKIMDomain + "',DKIMSelector = '" + DKIMSelector+ "',EmailHTMLData = ?p1," +
" EmailPlainData = ?p2,EmailSubject = '" + EmailSubject + "',FromName ='" + FromName + "',Host = '" + Host + "',Password = '" + Password + "',ReplyTo = '" + ReplyTo+ "'," +
"SenderUsername = '" + SenderUsername + "' WHERE Id=@a; select @a";

            bool res = false;
            try
            {
                var webDataAccess = new WebDataAccess();
                DataTable a = webDataAccess.ExecQP2(s, new MySqlParameter("?p1", EmailHTMLData), new MySqlParameter("?p2", EmailPlainData));
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
                       "INSERT INTO EmailTemplate (Id,DKIMDomain,DKIMSelector,EmailHTMLData,EmailPlainData,EmailSubject,FromName,Host,Password,ReplyTo,SenderUsername)"+
" VALUES(@a,'" + DKIMDomain + "','" + DKIMSelector + "',?p1,?p2,'" + EmailSubject + "','" + FromName +
"','" + Host + "','" + Password + "','" + ReplyTo + "','" + SenderUsername+ "');  select @a as a";

            bool res = false;
            try
            {
                var webDataAccess = new WebDataAccess();
                DataTable a = webDataAccess.ExecQP2(s, new MySqlParameter("?p1", EmailHTMLData), new MySqlParameter("?p2",EmailPlainData));
                
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
        //public override bool Delete()
        //{
        //    bool res = false;
        //    try
        //    {
        //        var webDataAccess = new WebDataAccess();
        //        var a =
        //            webDataAccess.Exec("delete from TrackImage where TrackItem_id='" + LocalID +

        //                               "';  delete from TrackImage where Id='" + LocalID + "'");
        //        res = a;
        //    }
        //    catch (Exception exception)
        //    {
        //        res = false;
        //    }
        //    return res;
        //}
        public virtual IList<EmailTemplate> LoadAll()
        {
            var webDataAccess = new WebDataAccess();
            var a = webDataAccess.Populate("Select * from EmailTemplate");

            var mappings = new Dictionary<string, string>
                               {
            
                                    {"EmailSubject", "EmailSubject"},
                                    
                                    {"EmailHTMLData", "EmailHTMLData"},
                                    {"EmailPlainData", "EmailPlainData"},
                                    {"SenderUsername", "SenderUsername"},
                                    {"Password", "Password"},
                                    {"FromName", "FromName"},
                                    {"ReplyTo", "ReplyTo"},
                                    {"Host", "Host"},
                                    {"DKIMSelector", "DKIMSelector"},
                                    {"DKIMDomain", "DKIMDomain"},
                                    {"LocalID", "Id"},
                               };

            IList<EmailTemplate> items = a.ToList<EmailTemplate>(mappings);
            return items;
        }
        public override string Descriptor
        {
            get
            {
                return EmailSubject;
            }
        }
        public override string TypeDesc
        {
            get { return ""; }
        }

        
    }
}
