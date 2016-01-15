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
        private string clientUniqueIdentifier = null;
        public string ClientUniqueIdentifier
        {
            get
            {
                return clientUniqueIdentifier;
            }
            set
            {
                clientUniqueIdentifier = TS3Helper.UnescapeString(value);
            }
        }
        public bool ClientInputMuted { get; set; }
        public bool ClientOutputMuted { get; set; }
        public bool ClientOutputOnlyMuted { get; set; }
        public bool ClientInputHardware { get; set; }
        public bool ClientOutputHardware { get; set; }
        public string ClientMetaData { get; set; }
        public bool ClientIsRecording { get; set; }
        public ChannelGroup ClientChannelGroup { get; set; }
        public List<ServerGroup> ClientServerGroups { get; set; } = new List<ServerGroup>();
        public bool ClientAway { get; set; }
        private string clientAwayMessage = null;
        public string ClientAwayMessage
        {
            get
            {
                return clientAwayMessage;
            }
            set
            {
                clientAwayMessage = TS3Helper.UnescapeString(value);
            }
        }
        public string ClientFlagAvatar { get; set; } //MD5 hash
        public bool ClientTalkPower { get; set; }
        public bool ClientTalkRequest { get; set; }
        private string clientTalkRequestMsg = null;
        public string ClientTalkRequestMsg
        {
            get
            {
                return clientTalkRequestMsg;
            }
            set
            {
                clientTalkRequestMsg = TS3Helper.UnescapeString(value);
            }
        }
        private string clientDescription = null;
        public string ClientDescription
        {
            get
            {
                return clientDescription;
            }
            set
            {
                clientDescription = TS3Helper.UnescapeString(value);
            }
        }
        public bool ClientIsTalker { get; set; }
        public bool ClientIsPrioritySpeaker { get; set; }
        public int ClientUnreadMessages { get; set; }
        private string clientNicknamePhonetic = null;
        public string ClientNicknamePhonetic
        {
            get
            {
                return clientNicknamePhonetic;
            }
            set
            {
                clientNicknamePhonetic = TS3Helper.UnescapeString(value);
            }
        }
        public int ClientNeededServerqueryViewPower { get; set; }
        public ulong ClientIconId { get; set; }
        public bool ClientIsChannelCommander { get; set; }
        public string ClientCountry { get; set; }
        public int ClientChannelGroupInheritedChannelId { get; set; }
        public List<BadgeTypes> ClientBadges { get; set; } = new List<BadgeTypes>();
        

        public Result Result { get; set; }

        public override string ToString()
        {
            return ClientNickname;
        }

        public Client FillWithResult(Result result)
        {
            return FillWithResult(result, result.ResultsList.First());
        }

        public Client FillWithResult(Result result, Dictionary<string, string> list)
        {
            if (result.GetResultByList(list, ClientProperties.client_servergroups.ToString()) != null)
            {
                List<TS3Models.ServerGroup> serverGroups = new List<TS3Models.ServerGroup>();
                List<string> sepList = TS3Helper.GetSeperatedList(result.GetResultByList(list, ClientProperties.client_servergroups.ToString()));
                if (sepList != null && sepList.Count != 0)
                {
                    foreach (string groupId in sepList)
                    {
                        serverGroups.Add(new TS3Models.ServerGroup()
                        {
                            SgId = Convert.ToInt32(groupId)
                        });
                    }
                }
                this.ClientServerGroups = serverGroups;
            }
            if (result.GetResultByList(list, ClientProperties.client_badges.ToString()) != null)
            {
                Dictionary<string, string> paramList = TS3Helper.GetSeperatedParamList(result.GetResultByList(list, ClientProperties.client_badges.ToString()));
                List<TS3Models.BadgeTypes> badges = new List<TS3Models.BadgeTypes>();
                if (paramList != null && paramList.Count != 0)
                {
                    foreach (KeyValuePair<string, string> param in paramList)
                    {
                        TS3Models.BadgeTypes badge;
                        if (Enum.TryParse<TS3Models.BadgeTypes>(param.Key, out badge))
                        {
                            if (Convert.ToBoolean(Convert.ToInt32(param.Value)))
                                badges.Add(badge);
                        }
                    }
                }
                this.ClientBadges = badges;
            }
            if (result.GetResultByList(list, ClientProperties.clid.ToString()) != null)
                this.ClId = Convert.ToInt32(result.GetResultByList(list, ClientProperties.clid.ToString()));
            if (result.GetResultByList(list, ClientProperties.client_unique_identifier.ToString()) != null)
                this.ClientUniqueIdentifier = result.GetResultByList(list, ClientProperties.client_unique_identifier.ToString());
            if (result.GetResultByList(list, ClientProperties.client_nickname.ToString()) != null)
                this.ClientNickname = result.GetResultByList(list, ClientProperties.client_nickname.ToString());
            if (result.GetResultByList(list, ClientProperties.client_input_muted.ToString()) != null)
                this.ClientInputMuted = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_input_muted.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_output_muted.ToString()) != null)
                this.ClientOutputMuted = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_output_muted.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_outputonly_muted.ToString()) != null)
                this.ClientOutputOnlyMuted = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_outputonly_muted.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_input_hardware.ToString()) != null)
                this.ClientInputHardware = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_input_hardware.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_output_hardware.ToString()) != null)
                this.ClientOutputHardware = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_output_hardware.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_meta_data.ToString()) != null)
                this.ClientMetaData = result.GetResultByList(list, ClientProperties.client_meta_data.ToString());
            if (result.GetResultByList(list, ClientProperties.client_is_recording.ToString()) != null)
                this.ClientIsRecording = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_is_recording.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_database_id.ToString()) != null)
                this.ClientDatabaseId = Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_database_id.ToString()));
            if (result.GetResultByList(list, ClientProperties.client_channel_group_id.ToString()) != null)
                this.ClientChannelGroup = new TS3Models.ChannelGroup()
                {
                    CgId = Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_channel_group_id.ToString()))
                };
            if (result.GetResultByList(list, ClientProperties.client_away.ToString()) != null)
                this.ClientAway = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_away.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_away_message.ToString()) != null)
                this.ClientAwayMessage = result.GetResultByList(list, ClientProperties.client_away_message.ToString());
            if (result.GetResultByList(list, ClientProperties.client_type.ToString()) != null)
                this.ClientType = Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_type.ToString()));
            if (result.GetResultByList(list, ClientProperties.client_flag_avatar.ToString()) != null)
                this.ClientFlagAvatar = result.GetResultByList(list, ClientProperties.client_flag_avatar.ToString());
            if (result.GetResultByList(list, ClientProperties.client_talk_power.ToString()) != null)
                this.ClientTalkPower = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_talk_power.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_talk_request.ToString()) != null)
                this.ClientTalkRequest = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_talk_request.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_talk_request_msg.ToString()) != null)
                this.ClientTalkRequestMsg = result.GetResultByList(list, ClientProperties.client_talk_request_msg.ToString());
            if (result.GetResultByList(list, ClientProperties.client_description.ToString()) != null)
                this.ClientDescription = result.GetResultByList(list, ClientProperties.client_description.ToString());
            if (result.GetResultByList(list, ClientProperties.client_is_talker.ToString()) != null)
                this.ClientIsTalker = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_is_talker.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_is_priority_speaker.ToString()) != null)
                this.ClientIsPrioritySpeaker = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_is_priority_speaker.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_unread_messages.ToString()) != null)
                this.ClientUnreadMessages = Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_unread_messages.ToString()));
            if (result.GetResultByList(list, ClientProperties.client_nickname_phonetic.ToString()) != null)
                this.ClientNicknamePhonetic = result.GetResultByList(list, ClientProperties.client_nickname_phonetic.ToString());
            if (result.GetResultByList(list, ClientProperties.client_needed_serverquery_view_power.ToString()) != null)
                this.ClientNeededServerqueryViewPower = Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_needed_serverquery_view_power.ToString()));
            if (result.GetResultByList(list, ClientProperties.client_icon_id.ToString()) != null)
                this.ClientIconId = Convert.ToUInt64(result.GetResultByList(list, ClientProperties.client_icon_id.ToString()));
            if (result.GetResultByList(list, ClientProperties.client_is_channel_commander.ToString()) != null)
                this.ClientIsChannelCommander = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_is_channel_commander.ToString())));
            if (result.GetResultByList(list, ClientProperties.client_country.ToString()) != null)
                this.ClientCountry = result.GetResultByList(list, ClientProperties.client_country.ToString());
            if (result.GetResultByList(list, ClientProperties.client_channel_group_inherited_channel_id.ToString()) != null)
                this.ClientChannelGroupInheritedChannelId = Convert.ToInt32(result.GetResultByList(list, ClientProperties.client_channel_group_inherited_channel_id.ToString()));
            this.Result = result;
            return this;
        }
    }
}
