using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class ClientPoke
    {
        public int ScHandlerId { get; set; }
        public string Msg { get; set; }
        public Client Invoker { get; set; }
        public Result Result { get; set; }

        public override string ToString()
        {
            return Msg;
        }
    }
}
