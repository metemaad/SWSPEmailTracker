using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class InboxInformation:Entity
    {
        public virtual string InboxName { get; set; }
        public virtual string Host { get; set; }
        public virtual int PortPop3 { get; set; }
        public virtual int PortSmtp { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual bool IsSsl { get; set; }
        public virtual bool DeleteAfterFetch { get; set; }

        public override string TypeDesc
        {
            get { return ""; }
        }
    }
}
