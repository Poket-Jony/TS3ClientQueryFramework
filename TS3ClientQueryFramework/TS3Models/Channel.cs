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
        private string channelTopic = null;
        public string ChannelTopic
        {
            get
            {
                return channelTopic;
            }
            set
            {
                channelTopic = TS3Helper.UnescapeString(value);
            }
        }
        private string channelDescription = null;
        public string ChannelDescription
        {
            get
            {
                return channelDescription;
            }
            set
            {
                channelDescription = TS3Helper.UnescapeString(value);
            }
        }
        public Codec ChannelCodec { get; set; }
        public int ChannelCodecQuality { get; set; }
        public int ChannelMaxClients { get; set; }
        public int ChannelMaxFamilyClients { get; set; }
        public bool ChannelFlagPermanent { get; set; }
        public bool ChannelFlagSemiPermanent { get; set; }
        public bool ChannelFlagDefault { get; set; }
        public bool ChannelFlagPassword { get; set; }
        public int ChannelCodecLatencyFactor { get; set; }
        public bool ChannelCodecIsUnencrypted { get; set; }
        public int ChannelDeleteDelay { get; set; }
        public bool ChannelFlagMaxClientsUnlimited { get; set; }
        public bool ChannelFlagMaxFamilyClientsUnlimited { get; set; }
        public bool ChannelFlagMaxFamilyClientsInherited { get; set; }
        public int ChannelNeededTalkPower { get; set; }
        private string channelNamePhonetic = null;
        public string ChannelNamePhonetic
        {
            get
            {
                return channelNamePhonetic;
            }
            set
            {
                channelNamePhonetic = TS3Helper.UnescapeString(value);
            }
        }
        public int ChannelIconId { get; set; }

        public Result Result { get; set; }

        public override string ToString()
        {
            return ChannelName;
        }
    }
}
