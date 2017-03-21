using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class EmailFailedDeliveryStatus:Entity, IDisposable
    {
        public virtual string Action { get; set; }
        public virtual string Status { get; set; }
        public virtual string RemoteMTA { get; set; }
        public virtual FinalRecipient FinalRecipient { get; set; }
        public virtual string DiagnosticCode { get; set; }
        public virtual string LastAttemptDate { get; set; }
        public virtual string ArrivalDate { get; set; }
        public virtual string ReportingMTA { get; set; }
        public virtual string ReceivedFromMTA { get; set; }
        public override string TypeDesc
        {
            get { return "EmailFailedDeliveryStatus"; }
        }

        public void Dispose()
        {
            DataAccess.NhSession.Flush();
        }
    }
}
