using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class ClientLeftView
    {
        public int CfId { get; set; }
        public int CtId { get; set; }
        public int ReasonId { get; set; }
        public Client Invoker { get; set; }
        private string reasonMsg = null;
        public string ReasonMsg
        {
            get
            {
                return reasonMsg;
            }
            set
            {
                reasonMsg = TS3Helper.UnescapeString(value);
            }
        }
        public int BanTime { get; set; }
        public int ClId { get; set; }

        public Result Result { get; set; }
    }
}
