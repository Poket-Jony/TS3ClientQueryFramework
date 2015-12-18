using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class ServerEdited
    {
        public ReasonIdentifier Reason { get; set; }
        public Client Invoker { get; set; }
        public VirtualServer VirtualServer { get; set; }

        public Result Result { get; set; }
    }
}
