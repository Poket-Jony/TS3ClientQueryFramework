using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class ClientEnterView
    {
        public int CfId { get; set; }
        public int CtId { get; set; }
        public ReasonIdentifier Reason { get; set; }
        public Client Client { get; set; }

        public Result Result { get; set; }
    }
}
