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

        public Channel FillWithResult(Result result)
        {
            return FillWithResult(result, result.ResultsList.First());
        }

        public Channel FillWithResult(Result result, Dictionary<string, string> list)
        {
            if (result.GetResultByList(list, ChannelProperties.cid.ToString()) != null)
                this.CId = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.cid.ToString()));
            if (result.GetResultByList(list, ChannelProperties.cpid.ToString()) != null)
                this.PId = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.cpid.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_name.ToString()) != null)
                this.ChannelName = result.GetResultByList(list, ChannelProperties.channel_name.ToString());
            if (result.GetResultByList(list, ChannelProperties.channel_topic.ToString()) != null)
                this.ChannelTopic = result.GetResultByList(list, ChannelProperties.channel_topic.ToString());
            if (result.GetResultByList(list, ChannelProperties.channel_codec.ToString()) != null)
                this.ChannelCodec = (TS3Models.Codec)Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_codec.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_codec_quality.ToString()) != null)
                this.ChannelCodecQuality = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_codec_quality.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_maxclients.ToString()) != null)
                this.ChannelMaxClients = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_maxclients.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_maxfamilyclients.ToString()) != null)
                this.ChannelMaxFamilyClients = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_maxfamilyclients.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_order.ToString()) != null)
                this.ChannelOrder = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_order.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_permanent.ToString()) != null)
                this.ChannelFlagPermanent = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_permanent.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_semi_permanent.ToString()) != null)
                this.ChannelFlagSemiPermanent = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_semi_permanent.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_default.ToString()) != null)
                this.ChannelFlagDefault = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_default.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_password.ToString()) != null)
                this.ChannelFlagPassword = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_password.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_codec_latency_factor.ToString()) != null)
                this.ChannelCodecLatencyFactor = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_codec_latency_factor.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_codec_is_unencrypted.ToString()) != null)
                this.ChannelCodecIsUnencrypted = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_codec_is_unencrypted.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_delete_delay.ToString()) != null)
                this.ChannelDeleteDelay = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_delete_delay.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_maxclients_unlimited.ToString()) != null)
                this.ChannelFlagMaxClientsUnlimited = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_maxclients_unlimited.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_maxfamilyclients_unlimited.ToString()) != null)
                this.ChannelFlagMaxFamilyClientsUnlimited = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_maxfamilyclients_unlimited.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_maxfamilyclients_inherited.ToString()) != null)
                this.ChannelFlagMaxFamilyClientsInherited = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_maxfamilyclients_inherited.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_needed_talk_power.ToString()) != null)
                this.ChannelNeededTalkPower = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_needed_talk_power.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_name_phonetic.ToString()) != null)
                this.ChannelNamePhonetic = result.GetResultByList(list, ChannelProperties.channel_name_phonetic.ToString());
            if (result.GetResultByList(list, ChannelProperties.channel_icon_id.ToString()) != null)
                this.ChannelIconId = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_icon_id.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_are_subscribed.ToString()) != null)
                this.ChannelFlagAreSubscribed = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_are_subscribed.ToString()));
            if (result.GetResultByList(list, ChannelProperties.total_clients.ToString()) != null)
                this.TotalClients = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.total_clients.ToString()));
            return this;
        }
    }
}
