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
        public int ClientChannelGroupId { get; set; }
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
        public int ClientIconId { get; set; }
        public bool ClientIsChannelCommander { get; set; }
        public string ClientCountry { get; set; }
        public int ClientChannelGroupInheritedChannelId { get; set; }
        public List<BadgeTypes> ClientBadges { get; set; } = new List<BadgeTypes>();
        

        public Result Result { get; set; }

        public override string ToString()
        {
            return ClientNickname;
        }
    }
}
