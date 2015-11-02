using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework
{
    public class TS3Models
    {

        public enum HostMessageMode
        {
            HostMessageMode_LOG = 1, // 1: display message in chatlog
            HostMessageMode_MODAL = 2, // 2: display message in modal dialog
            HostMessageMode_MODALQUIT = 3 // 3: display message in modal dialog and close connection
        };
        public enum HostBannerMode
        {
            HostMessageMode_NOADJUST = 0, // 0: do not adjust
            HostMessageMode_IGNOREASPECT = 1, // 1: adjust but ignore aspect ratio (like TeamSpeak 2)
            HostMessageMode_KEEPASPECT = 2 // 2: adjust and keep aspect ratio
        };
        public enum Codec
        {
            CODEC_SPEEX_NARROWBAND = 0, // 0: speex narrowband (mono, 16bit, 8kHz)
            CODEC_SPEEX_WIDEBAND = 1, // 1: speex wideband (mono, 16bit, 16kHz)
            CODEC_SPEEX_ULTRAWIDEBAND = 2, // 2: speex ultra-wideband (mono, 16bit, 32kHz)
            CODEC_CELT_MONO = 3 // 3: celt mono (mono, 16bit, 48kHz)
        };
        public enum CodecEncryptionMode
        {
            CODEC_CRYPT_INDIVIDUAL = 0, // 0: configure per channel
            CODEC_CRYPT_DISABLED = 1, // 1: globally disabled
            CODEC_CRYPT_ENABLED = 2 // 2: globally enabled
        };
        public enum TextMessageTargetMode
        {
            TextMessageTarget_CLIENT = 1, // 1: target is a client
            TextMessageTarget_CHANNEL = 2, // 2: target is a channel
            TextMessageTarget_SERVER = 3 // 3: target is a virtual server
        };
        public enum LogLevel
        {
            LogLevel_ERROR = 1, // 1: everything that is really bad
            LogLevel_WARNING = 2, // 2: everything that might be bad
            LogLevel_DEBUG = 3, // 3: output that might help find a problem
            LogLevel_INFO = 4 // 4: informational output
        };
        public enum ReasonIdentifier
        {
            REASON_KICK_CHANNEL = 4, // 4: kick client from channel
            REASON_KICK_SERVER = 5 // 5: kick client from server
        };
        public enum PermissionGroupDatabaseTypes
        {
            PermGroupDBTypeTemplate = 0, // 0: template group (used for new virtual servers)
            PermGroupDBTypeRegular = 1, // 1: regular group (used for regular clients)
            PermGroupDBTypeQuery = 2 // 2: global query group (used for ServerQuery clients)
        };
        public enum PermissionGroupTypes
        {
            PermGroupTypeServerGroup = 0, // 0: server group permission
            PermGroupTypeGlobalClient = 1, // 1: client specific permission
            PermGroupTypeChannel = 2, // 2: channel specific permission
            PermGroupTypeChannelGroup = 3, // 3: channel group permission
            PermGroupTypeChannelClient = 4 // 4: channel-client specific permission
        };
        public enum TokenType
        {
            TokenServerGroup = 0, // 0: server group token (id1={groupID} id2=0)
            TokenChannelGroup = 1 // 1: channel group token (id1={groupID} id2={channelID})
        };

        public enum Notifications
        {
            notifytextmessage = 0,
            notifyclientpoke = 1,
            notifycliententerview = 2,
            notifyclientleftview = 3,
            notifyserveredited = 4,
            notifychanneldescriptionchanged = 5,
            notifychannelpasswordchanged = 6,
            notifychannelmoved = 7,
            notifychanneledited = 8,
            notifychannelcreated = 9,
            notifychanneldeleted = 10,
            notifyclientmoved = 11,
            notifytokenused = 12
        };

        public class Result
        {
            public int ErrorId { get; set; }
            private string errorMsg = null;
            public string ErrorMsg
            {
                get
                {
                    return errorMsg;
                }
                set
                {
                    errorMsg = TS3Helper.UnescapeString(value);
                }
            }
            public List<Dictionary<string, string>> ResultsList = new List<Dictionary<string, string>>();
            public string ResultString { get; set; }

            public string GetFirstResult(string key)
            {
                if (ResultsList.Count != 0)
                    return GetResultByList(ResultsList.First(), key);
                return null;
            }

            public string GetResultByList(Dictionary<string, string> list, string key)
            {
                if (ResultsList.Count != 0)
                {
                    string val;
                    if (list.TryGetValue(key, out val))
                        return val;
                }
                return null;
            }
        }

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

        public class TextMessage
        {
            public int ScHandlerId { get; set; }
            public TextMessageTargetMode TargetMode { get; set; }
            public string Msg { get; set; }
            public int Target { get; set; }
            public int InvokerId { get; set; }
            public string InvokerName { get; set; }
            public string InvokerUId { get; set; }
            public Result Result { get; set; }

            public override string ToString()
            {
                return Msg;
            }
        }

        public class ClientPoke
        {
            public int ScHandlerId { get; set; }
            public string Msg { get; set; }
            public int InvokerId { get; set; }
            public string InvokerName { get; set; }
            public string InvokerUId { get; set; }
            public Result Result { get; set; }

            public override string ToString()
            {
                return Msg;
            }
        }
    }
}
