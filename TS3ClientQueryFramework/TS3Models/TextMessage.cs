using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class TextMessage
    {
        public int ScHandlerId { get; set; }
        public TextMessageTargetMode TargetMode { get; set; }
        public string Msg { get; set; }
        public int Target { get; set; }
        public int InvokerId { get; set; }
        public string InvokerName { get; set; }
        public string InvokerUId { get; set; }
        public Result Result { get; set; }

        public override string ToString()
        {
            return Msg;
        }
    }
}
