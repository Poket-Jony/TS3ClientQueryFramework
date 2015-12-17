using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework
{
    public class TS3Notify
    {
        public delegate void OnNotificationHandler(TS3Models.Notifications notification, TS3Models.Result result);
        public delegate void OnTextMessageHandler(TS3Models.TextMessage textMessage);
        public delegate void OnClientPokeHandler(TS3Models.ClientPoke clientPoke);
        public delegate void OnClientEnterViewHandler(TS3Models.ClientEnterView clientEnterView);
        public delegate void OnClientLeftViewHandler(TS3Models.ClientLeftView clientLeftView);

        public event OnNotificationHandler OnNotification;
        public event OnTextMessageHandler OnTextMessage;
        public event OnClientPokeHandler OnClientPoke;
        public event OnClientEnterViewHandler OnClientEnterView;
        public event OnClientLeftViewHandler OnClientLeftView;

        private TS3Client ts3Client = null;
        private List<TS3Models.Notifications> registeredNotifications = new List<TS3Models.Notifications>();

        internal TS3Notify(TS3Client client)
        {
            ts3Client = client;
        }

        internal bool RegisterNotification(TS3Models.Notifications notification)
        {
            if (!registeredNotifications.Contains(notification))
            {
                registeredNotifications.Add(notification);
                return true;
            }
            return false;
        }

        internal bool UnregisterNotification(TS3Models.Notifications notification)
        {
            if (registeredNotifications.Contains(notification))
            {
                registeredNotifications.Remove(notification);
                return true;
            }
            return false;
        }

        internal void ReceiveNotification(string notificationString)
        {
            if (!string.IsNullOrEmpty(notificationString))
            {
                foreach (TS3Models.Notifications noti in registeredNotifications)
                {
                    if (notificationString.Contains(noti.ToString()))
                    {
                        TS3Models.Result result = TS3Helper.ParseResult(notificationString, false);
                        if (OnNotification != null)
                            OnNotification(noti, result);
                        ParseNotification(noti, result);
                    }
                }
            }
        }

        private void ParseNotification(TS3Models.Notifications notification, TS3Models.Result result)
        {
            switch(notification)
            {
                case TS3Models.Notifications.notifytextmessage:
                    if (OnTextMessage != null)
                        OnTextMessage(new TS3Models.TextMessage() {
                            Result = result,
                            ScHandlerId = Convert.ToInt32(result.GetFirstResult("schandlerid")),
                            TargetMode = (TS3Models.TextMessageTargetMode)Convert.ToInt32(result.GetFirstResult("targetmode")),
                            Msg = result.GetFirstResult("msg"),
                            Target = Convert.ToInt32(result.GetFirstResult("target")),
                            InvokerId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                            InvokerName = result.GetFirstResult("invokername"),
                            InvokerUId = result.GetFirstResult("invokeruid")
                        });
                    break;
                case TS3Models.Notifications.notifyclientpoke:
                    if (OnClientPoke != null)
                        OnClientPoke(new TS3Models.ClientPoke() {
                            Result = result,
                            ScHandlerId = Convert.ToInt32(result.GetFirstResult("schandlerid")),
                            Msg = result.GetFirstResult("msg"),
                            InvokerId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                            InvokerName = result.GetFirstResult("invokername"),
                            InvokerUId = result.GetFirstResult("invokeruid")
                        });
                    break;
                case TS3Models.Notifications.notifycliententerview:
                    if (OnClientEnterView != null)
                    {
                        Dictionary<string, string> paramList = TS3Helper.GetSeperatedParamList(result.GetFirstResult("client_badges"));
                        List<TS3Models.BadgeTypes> badges = new List<TS3Models.BadgeTypes>();
                        if(paramList != null && paramList.Count != 0)
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

                        List<TS3Models.ServerGroup> serverGroups = new List<TS3Models.ServerGroup>();
                        List<string> sepList = TS3Helper.GetSeperatedList(result.GetFirstResult("client_servergroups"));
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

                        OnClientEnterView(new TS3Models.ClientEnterView()
                        {
                            Result = result,
                            CfId = Convert.ToInt32(result.GetFirstResult("cfid")),
                            CtId = Convert.ToInt32(result.GetFirstResult("ctid")),
                            ReasonId = Convert.ToInt32(result.GetFirstResult("reasonid")),
                            Client = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("clid")),
                                ClientUniqueIdentifier = result.GetFirstResult("client_unique_identifier"),
                                ClientNickname = result.GetFirstResult("client_nickname"),
                                ClientInputMuted = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_input_muted"))),
                                ClientOutputMuted = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_output_muted"))),
                                ClientOutputOnlyMuted = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_outputonly_muted"))),
                                ClientInputHardware = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_input_hardware"))),
                                ClientOutputHardware = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_output_hardware"))),
                                ClientMetaData = result.GetFirstResult("client_meta_data"),
                                ClientIsRecording = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_is_recording"))),
                                ClientDatabaseId = Convert.ToInt32(result.GetFirstResult("client_database_id")),
                                ClientChannelGroupId = Convert.ToInt32(result.GetFirstResult("client_channel_group_id")),
                                ClientServerGroups = serverGroups,
                                ClientAway = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_away"))),
                                ClientAwayMessage = result.GetFirstResult("client_away_message"),
                                ClientType = Convert.ToInt32(result.GetFirstResult("client_type")),
                                ClientFlagAvatar = result.GetFirstResult("client_flag_avatar"),
                                ClientTalkPower = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_talk_power"))),
                                ClientTalkRequest = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_talk_request"))),
                                ClientTalkRequestMsg = result.GetFirstResult("client_talk_request_msg"),
                                ClientDescription = result.GetFirstResult("client_description"),
                                ClientIsTalker = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_is_talker"))),
                                ClientIsPrioritySpeaker = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_is_priority_speaker"))),
                                ClientUnreadMessages = Convert.ToInt32(result.GetFirstResult("client_unread_messages")),
                                ClientNicknamePhonetic = result.GetFirstResult("client_nickname_phonetic"),
                                ClientNeededServerqueryViewPower = Convert.ToInt32(result.GetFirstResult("client_needed_serverquery_view_power")),
                                ClientIconId = Convert.ToInt32(result.GetFirstResult("client_icon_id")),
                                ClientIsChannelCommander = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("client_is_channel_commander"))),
                                ClientCountry = result.GetFirstResult("client_country"),
                                ClientChannelGroupInheritedChannelId = Convert.ToInt32(result.GetFirstResult("client_channel_group_inherited_channel_id")),
                                ClientBadges = badges
                            }
                        });
                    }
                    break;
                case TS3Models.Notifications.notifyclientleftview:
                    if (OnClientLeftView != null)
                        OnClientLeftView(new TS3Models.ClientLeftView()
                        {
                            Result = result,
                            CfId = Convert.ToInt32(result.GetFirstResult("cfid")),
                            CtId = Convert.ToInt32(result.GetFirstResult("ctid")),
                            ReasonId = Convert.ToInt32(result.GetFirstResult("reasonid")),
                            InvokerId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                            InvokerName = result.GetFirstResult("invokername"),
                            InvokerUId = result.GetFirstResult("invokeruid"),
                            ReasonMsg = result.GetFirstResult("reasonmsg"),
                            BanTime = Convert.ToInt32(result.GetFirstResult("bantime")),
                            ClId = Convert.ToInt32(result.GetFirstResult("clid"))
                        });
                    break;
            }
        }
    }
}
