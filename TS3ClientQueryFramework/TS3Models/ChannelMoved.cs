using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class ChannelMoved
    {
        public Channel Channel { get; set; }
        public ReasonIdentifier Reason { get; set; }
        public Client Invoker { get; set; }

        public Result Result { get; set; }
    }
}
