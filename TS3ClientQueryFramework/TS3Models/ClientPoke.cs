using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class ClientPoke
    {
        private string msg = null;
        public string Msg
        {
            get
            {
                return msg;
            }
            set
            {
                msg = TS3Helper.UnescapeString(value);
            }
        }
        public Client Invoker { get; set; }
        public Result Result { get; set; }

        public override string ToString()
        {
            return Msg;
        }
    }
}
