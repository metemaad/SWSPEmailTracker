using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class Email:Entity
    {
        public virtual Person Person { get; set; }
        [DisplayName("Person Description")]
        
        public virtual string PersonDescription
        {
            get { return Person.Descriptor; }
        }
        [DisplayName("Email Type")]
        
        public virtual string Type { get; set; }
        [DisplayName("Email")]
        public virtual string Value { get; set; }
        public virtual EmailFailedDeliveryStatus EmailFailedDeliveryStatus { get; set; }
        [DisplayName("Is Valid")]
        public virtual bool IsValid { get; set; }
        [DisplayName("Is Primery")]
        [AutoSize(DataGridViewAutoSizeColumnMode.AllCells)]
        public virtual bool IsPrimery { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        
        public override string TypeDesc
        {
            get { return "Email"; }
        }
    }

    
}
