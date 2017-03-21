using System;
using System.ComponentModel;
using System.Windows.Forms;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
     public  class TrackData:Entity
    {
         [AutoSize(DataGridViewAutoSizeColumnMode.AllCells)]
        [DisplayName("DateTime")]
        public virtual DateTime DateTime { get; set; }
         [DisplayName(" Visitor IP")]
         [AutoSize(DataGridViewAutoSizeColumnMode.AllCells)]
        public virtual string VisitorIP { get; set; }

         public virtual IPInfo IP { get; set; }
         [DisplayName("IP Info")]
         [AutoSize(DataGridViewAutoSizeColumnMode.AllCells)]
         public virtual string IPInformation { get { return IP!=null? IP.Descriptor:string.Empty; } }

         [DisplayName("Track Name")]
         [AutoSize(DataGridViewAutoSizeColumnMode.AllCells)]
         public virtual string Trackname { get { return TrackID!=null? TrackID.TrackTitle:string.Empty; } }

        public virtual TrackItem TrackID { get; set; }

         [DisplayName("VisitorID")]
         [AutoSize(DataGridViewAutoSizeColumnMode.AllCells)]
        public virtual string Visitorname { get { return VisitorID!=null? VisitorID.Descriptor:string.Empty; } }
        public virtual Person VisitorID { get; set; }

       
        
        public virtual string Descr { get; set; }
        public virtual string SessionID { get; set; }


         public override string TypeDesc
         {
             get { return "trackata"; }
         }
    }
    public  class InboxData:Entity
    {
        public override string TypeDesc
        {
            get { return ""; }
        }
    }
}
