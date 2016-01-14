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
        public int CpId { get; set; }
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
        private string channelPassword = null;
        public string ChannelPassword
        {
            get
            {
                return channelPassword;
            }
            set
            {
                channelPassword = TS3Helper.UnescapeString(value);
            }
        }
        public Codec ChannelCodec { get; set; }
        public int ChannelCodecQuality { get; set; }
        public int ChannelMaxclients { get; set; }
        public int ChannelMaxfamilyclients { get; set; }
        public int ChannelOrder { get; set; }
        public bool ChannelFlagPermanent { get; set; }
        public bool ChannelFlagSemiPermanent { get; set; }
        public bool ChannelFlagTemporary { get; set; }
        public bool ChannelFlagDefault { get; set; }
        public bool ChannelFlagPassword { get; set; }
        public int ChannelCodecLatencyFactor { get; set; }
        public bool ChannelCodecIsUnencrypted { get; set; }
        private string channelSecuritySalt = null;
        public string ChannelSecuritySalt
        {
            get
            {
                return channelSecuritySalt;
            }
            set
            {
                channelSecuritySalt = TS3Helper.UnescapeString(value);
            }
        }
        public int ChannelDeleteDelay { get; set; }
        public int ChannelFlagMaxclientsUnlimited { get; set; }
        public int ChannelFlagMaxfamilyclientsUnlimited { get; set; }
        public int ChannelFlagMaxfamilyclientsInherited { get; set; }
        private string channelFilepath = null;
        public string ChannelFilepath
        {
            get
            {
                return channelFilepath;
            }
            set
            {
                channelFilepath = TS3Helper.UnescapeString(value);
            }
        }
        public int ChannelNeededTalkPower { get; set; }
        public bool ChannelForcedSilence { get; set; }
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
        public ulong ChannelIconId { get; set; }
        public bool ChannelFlagAreSubscribed { get; set; }
        public bool ChannelFlagPrivate { get; set; }
        public int SecondsEmpty { get; set; }
        public int TotalClients { get; set; }
        public int TotalClientsFamily { get; set; }
        public int ChannelNeededSubscribePower { get; set; }

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
                this.CpId = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.cpid.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_name.ToString()) != null)
                this.ChannelName = result.GetResultByList(list, ChannelProperties.channel_name.ToString());
            if (result.GetResultByList(list, ChannelProperties.channel_topic.ToString()) != null)
                this.ChannelTopic = result.GetResultByList(list, ChannelProperties.channel_topic.ToString());
            if (result.GetResultByList(list, ChannelProperties.channel_description.ToString()) != null)
                this.ChannelDescription = result.GetResultByList(list, ChannelProperties.channel_description.ToString());
            if (result.GetResultByList(list, ChannelProperties.channel_password.ToString()) != null)
                this.ChannelPassword = result.GetResultByList(list, ChannelProperties.channel_password.ToString());
            if (result.GetResultByList(list, ChannelProperties.channel_codec.ToString()) != null)
                this.ChannelCodec = (TS3Models.Codec)Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_codec.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_codec_quality.ToString()) != null)
                this.ChannelCodecQuality = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_codec_quality.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_maxclients.ToString()) != null)
                this.ChannelMaxclients = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_maxclients.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_maxfamilyclients.ToString()) != null)
                this.ChannelMaxfamilyclients = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_maxfamilyclients.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_order.ToString()) != null)
                this.ChannelOrder = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_order.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_permanent.ToString()) != null)
                this.ChannelFlagPermanent = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_permanent.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_semi_permanent.ToString()) != null)
                this.ChannelFlagSemiPermanent = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_semi_permanent.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_temporary.ToString()) != null)
                this.ChannelFlagTemporary = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_temporary.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_default.ToString()) != null)
                this.ChannelFlagDefault = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_default.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_password.ToString()) != null)
                this.ChannelFlagPassword = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_password.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_codec_latency_factor.ToString()) != null)
                this.ChannelCodecLatencyFactor = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_codec_latency_factor.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_codec_is_unencrypted.ToString()) != null)
                this.ChannelCodecIsUnencrypted = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_codec_is_unencrypted.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_security_salt.ToString()) != null)
                this.ChannelSecuritySalt = result.GetResultByList(list, ChannelProperties.channel_security_salt.ToString());
            if (result.GetResultByList(list, ChannelProperties.channel_delete_delay.ToString()) != null)
                this.ChannelDeleteDelay = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_delete_delay.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_maxclients_unlimited.ToString()) != null)
                this.ChannelFlagMaxclientsUnlimited = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_maxclients_unlimited.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_maxfamilyclients_unlimited.ToString()) != null)
                this.ChannelFlagMaxfamilyclientsUnlimited = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_maxfamilyclients_unlimited.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_maxfamilyclients_inherited.ToString()) != null)
                this.ChannelFlagMaxfamilyclientsInherited = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_maxfamilyclients_inherited.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_filepath.ToString()) != null)
                this.ChannelFilepath = result.GetResultByList(list, ChannelProperties.channel_filepath.ToString());
            if (result.GetResultByList(list, ChannelProperties.channel_needed_talk_power.ToString()) != null)
                this.ChannelNeededTalkPower = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_needed_talk_power.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_forced_silence.ToString()) != null)
                this.ChannelForcedSilence = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_forced_silence.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_name_phonetic.ToString()) != null)
                this.ChannelNamePhonetic = result.GetResultByList(list, ChannelProperties.channel_name_phonetic.ToString());
            if (result.GetResultByList(list, ChannelProperties.channel_icon_id.ToString()) != null)
                this.ChannelIconId = Convert.ToUInt64(result.GetResultByList(list, ChannelProperties.channel_icon_id.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_are_subscribed.ToString()) != null)
                this.ChannelFlagAreSubscribed = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_are_subscribed.ToString())));
            if (result.GetResultByList(list, ChannelProperties.channel_flag_private.ToString()) != null)
                this.ChannelFlagPrivate = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_flag_private.ToString())));
            if (result.GetResultByList(list, ChannelProperties.seconds_empty.ToString()) != null)
                this.SecondsEmpty = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.seconds_empty.ToString()));
            if (result.GetResultByList(list, ChannelProperties.total_clients.ToString()) != null)
                this.TotalClients = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.total_clients.ToString()));
            if (result.GetResultByList(list, ChannelProperties.total_clients_family.ToString()) != null)
                this.TotalClientsFamily = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.total_clients_family.ToString()));
            if (result.GetResultByList(list, ChannelProperties.channel_needed_subscribe_power.ToString()) != null)
                this.ChannelNeededSubscribePower = Convert.ToInt32(result.GetResultByList(list, ChannelProperties.channel_needed_subscribe_power.ToString()));
            return this;
        }
    }
}
