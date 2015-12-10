using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class Client
    {
        public int ClId { get; set; }
        public Channel Channel { get; set; }
        public int ClientDatabaseId { get; set; }
        private string clientNickname = null;
        public string ClientNickname
        {
            get
            {
                return clientNickname;
            }
            set
            {
                clientNickname = TS3Helper.UnescapeString(value);
            }
        }
        public int ClientType { get; set; }
        public Result Result { get; set; }

        public override string ToString()
        {
            return ClientNickname;
        }
    }
}
