using System;
using System.Collections.Generic;
using System.ComponentModel;
using NHibernate.Linq;


using SWSPEmailTracker.web.Infrastructure;

namespace SWSPEmailTracker.web.SWSPETl.Model
{
    public class TrackData : Entity
    {
        [DisplayName("DateTime")]
        public virtual DateTime DateTime { get; set; }
        [DisplayName("IP")]
        public virtual string VisitorIP { get; set; }

        public virtual string TrackID { get; set; }
        [DisplayName("VisitorID")]
        public virtual string VisitorID { get; set; }



        public virtual string Descr { get; set; }
        public virtual string SessionID { get; set; }


        public override string TypeDesc
        {
            get { return "trackata"; }
        }

        public override bool Update()
        {
            throw new NotImplementedException();
        }

        public  IList<TrackData> LoadAll()
        {
            var webDataAccess = new WebDataAccess();
            var a = webDataAccess.Populate("Select * from TrackData");
            var mappings = new Dictionary<string, string>
                               {
                                   {"LocalID", "Id"},
                                   {"DateTime", "DateTime"},
                                   {"VisitorIP", "VisitorIP"},
                                   {"TrackID", "TrackID"},
                                   {"VisitorID", "VisitorID"},
                                   {"Descr", "Descr"},
                                   {"SessionID", "SessionID"}
                               };

            var items = a.ToList<TrackData>(mappings);

            return items;
        }
        public virtual string LocalID { get; set; }
        public override bool Delete()
        {
            bool res = false;
            try
            {
                var webDataAccess = new WebDataAccess();
                var a =
                    webDataAccess.Exec("delete from TrackData where Id='" + LocalID +"'; ");
                res = a;
            }
            catch (Exception exception)
            {
                res = false;
            }
            return res;
        }
      
    }
}
