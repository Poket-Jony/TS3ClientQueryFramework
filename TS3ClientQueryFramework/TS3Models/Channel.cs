using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class Channel
    {
        public int CId { get; set; }
        public int PId { get; set; }
        public int ChannelOrder { get; set; }
        private string channelName = null;
        public string ChannelName
        {
            get
            {
                return channelName;
            }
            set
            {
                channelName = TS3Helper.UnescapeString(value);
            }
        }
        public int ChannelFlagAreSubscribed { get; set; }
        public int TotalClients { get; set; }
        public Result Result { get; set; }

        public override string ToString()
        {
            return ChannelName;
        }
    }
}
