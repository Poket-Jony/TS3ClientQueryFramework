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
        #region Events
        public delegate void OnNotificationHandler(TS3Models.Notifications notification, TS3Models.Result result);
        #region Client
        public delegate void OnTextMessageHandler(TS3Models.TextMessage textMessage);
        public delegate void OnClientPokeHandler(TS3Models.ClientPoke clientPoke);
        public delegate void OnClientEnterViewHandler(TS3Models.ClientEnterView clientEnterView);
        public delegate void OnClientLeftViewHandler(TS3Models.ClientLeftView clientLeftView);
        public delegate void OnClientMovedHandler(TS3Models.ClientMoved clientMoved);
        #endregion
        #region Channel
        public delegate void OnChannelMovedHandler(TS3Models.ChannelMoved channelMoved);
        public delegate void OnChannelEditedHandler(TS3Models.ChannelEdited channelEdited);
        public delegate void OnChannelCreatedHandler(TS3Models.ChannelCreated channelCreated);
        public delegate void OnChannelDeletedHandler(TS3Models.ChannelDeleted channelDeleted);
        #endregion
        #region Server
        public delegate void OnServerEditedHandler(TS3Models.ServerEdited serverEdited);
        #endregion
        #endregion

        #region Events
        public event OnNotificationHandler OnNotification;
        #region Client
        public event OnTextMessageHandler OnTextMessage;
        public event OnClientPokeHandler OnClientPoke;
        public event OnClientEnterViewHandler OnClientEnterView;
        public event OnClientLeftViewHandler OnClientLeftView;
        public event OnClientMovedHandler OnClientMoved;
        #endregion
        #region Channel
        public event OnChannelMovedHandler OnChannelMoved;
        public event OnChannelEditedHandler OnChannelEdited;
        public event OnChannelCreatedHandler OnChannelCreated;
        public event OnChannelDeletedHandler OnChannelDeleted;
        #endregion
        #region Server
        public event OnServerEditedHandler OnServerEdited;
        #endregion
        #endregion

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
                        TS3Models.Result result = TS3Helper.ParseResult(notificationString, true);
                        if (OnNotification != null)
                            OnNotification(noti, result);
                        ParseNotification(noti, result);
                    }
                }
            }
        }

        private void ParseNotification(TS3Models.Notifications notification, TS3Models.Result result)
        {
            switch (notification)
            {
                #region Client
                case TS3Models.Notifications.notifytextmessage:
                    if (OnTextMessage != null)
                        OnTextMessage(new TS3Models.TextMessage()
                        {
                            Result = result,
                            ScHandlerId = Convert.ToInt32(result.GetFirstResult("schandlerid")),
                            TargetMode = (TS3Models.TextMessageTargetMode)Convert.ToInt32(result.GetFirstResult("targetmode")),
                            Msg = result.GetFirstResult("msg"),
                            Target = Convert.ToInt32(result.GetFirstResult("target")),
                            Invoker = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                                ClientNickname = result.GetFirstResult("invokername"),
                                ClientUniqueIdentifier = result.GetFirstResult("invokeruid"),
                            }
                        });
                    break;
                case TS3Models.Notifications.notifyclientpoke:
                    if (OnClientPoke != null)
                        OnClientPoke(new TS3Models.ClientPoke()
                        {
                            Result = result,
                            ScHandlerId = Convert.ToInt32(result.GetFirstResult("schandlerid")),
                            Msg = result.GetFirstResult("msg"),
                            Invoker = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                                ClientNickname = result.GetFirstResult("invokername"),
                                ClientUniqueIdentifier = result.GetFirstResult("invokeruid"),
                            }
                        });
                    break;
                case TS3Models.Notifications.notifycliententerview:
                    if (OnClientEnterView != null)
                    {
                        Dictionary<string, string> paramList = TS3Helper.GetSeperatedParamList(result.GetFirstResult("client_badges"));
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
                                ClientChannelGroup = new TS3Models.ChannelGroup()
                                {
                                    CgId = Convert.ToInt32(result.GetFirstResult("client_channel_group_id"))
                                },
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
                            Invoker = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                                ClientNickname = result.GetFirstResult("invokername"),
                                ClientUniqueIdentifier = result.GetFirstResult("invokeruid"),
                            },
                            ReasonMsg = result.GetFirstResult("reasonmsg"),
                            BanTime = Convert.ToInt32(result.GetFirstResult("bantime")),
                            ClId = Convert.ToInt32(result.GetFirstResult("clid"))
                        });
                    break;
                case TS3Models.Notifications.notifyclientmoved:
                    if (OnClientMoved != null)
                    {
                        List<TS3Models.Client> clients = new List<TS3Models.Client>();
                        foreach(Dictionary<string, string> list in result.ResultsList)
                        {
                            string id = result.GetResultByList(list, "clid");
                            if (!string.IsNullOrEmpty(id))
                                clients.Add(new TS3Models.Client()
                                {
                                    ClId = Convert.ToInt32(id)
                                });
                        }

                        OnClientMoved(new TS3Models.ClientMoved()
                        {
                            Result = result,
                            Channel = new TS3Models.Channel()
                            {
                                CId = Convert.ToInt32(result.GetFirstResult("ctid"))
                            },
                            ReasonId = Convert.ToInt32(result.GetFirstResult("reasonid")),
                            Invoker = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                                ClientNickname = result.GetFirstResult("invokername"),
                                ClientUniqueIdentifier = result.GetFirstResult("invokeruid"),
                            },
                            Clients = clients
                        });
                    }
                    break;
                #endregion
                #region Channel
                case TS3Models.Notifications.notifychannelmoved:
                    if (OnChannelMoved != null)
                        OnChannelMoved(new TS3Models.ChannelMoved()
                        {
                            Result = result,
                            ReasonId = Convert.ToInt32(result.GetFirstResult("reasonid")),
                            Invoker = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                                ClientNickname = result.GetFirstResult("invokername"),
                                ClientUniqueIdentifier = result.GetFirstResult("invokeruid"),
                            },
                            Channel = new TS3Models.Channel()
                            {
                                CId = Convert.ToInt32(result.GetFirstResult("cid")),
                                PId = Convert.ToInt32(result.GetFirstResult("cpid")),
                                ChannelOrder = Convert.ToInt32(result.GetFirstResult("order"))
                            }
                        });
                    break;
                case TS3Models.Notifications.notifychanneledited:
                    if (OnChannelEdited != null)
                        OnChannelEdited(new TS3Models.ChannelEdited()
                        {
                            Result = result,
                            ReasonId = Convert.ToInt32(result.GetFirstResult("reasonid")),
                            Invoker = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                                ClientNickname = result.GetFirstResult("invokername"),
                                ClientUniqueIdentifier = result.GetFirstResult("invokeruid"),
                            },
                            Channel = new TS3Models.Channel()
                            {
                                CId = Convert.ToInt32(result.GetFirstResult("cid")),
                                ChannelName = result.GetFirstResult("channel_name"),
                                ChannelTopic = result.GetFirstResult("channel_topic"),
                                ChannelCodec = (TS3Models.Codec)Convert.ToInt32(result.GetFirstResult("channel_codec")),
                                ChannelCodecQuality = Convert.ToInt32(result.GetFirstResult("channel_codec_quality")),
                                ChannelMaxClients = Convert.ToInt32(result.GetFirstResult("channel_maxclients")),
                                ChannelMaxFamilyClients = Convert.ToInt32(result.GetFirstResult("channel_maxfamilyclients")),
                                ChannelOrder = Convert.ToInt32(result.GetFirstResult("channel_order")),
                                ChannelFlagPermanent = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_permanent"))),
                                ChannelFlagSemiPermanent = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_semi_permanent"))),
                                ChannelFlagDefault = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_default"))),
                                ChannelFlagPassword = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_password"))),
                                ChannelCodecLatencyFactor = Convert.ToInt32(result.GetFirstResult("channel_codec_latency_factor")),
                                ChannelCodecIsUnencrypted = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_codec_is_unencrypted"))),
                                ChannelDeleteDelay = Convert.ToInt32(result.GetFirstResult("channel_delete_delay")),
                                ChannelFlagMaxClientsUnlimited = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_maxclients_unlimited"))),
                                ChannelFlagMaxFamilyClientsUnlimited = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_maxfamilyclients_unlimited"))),
                                ChannelFlagMaxFamilyClientsInherited = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_maxfamilyclients_inherited"))),
                                ChannelNeededTalkPower = Convert.ToInt32(result.GetFirstResult("channel_needed_talk_power")),
                                ChannelNamePhonetic = result.GetFirstResult("channel_name_phonetic"),
                                ChannelIconId = Convert.ToInt32(result.GetFirstResult("channel_icon_id"))
                            }
                        });
                    break;
                case TS3Models.Notifications.notifychannelcreated:
                    if (OnChannelCreated != null)
                        OnChannelCreated(new TS3Models.ChannelCreated()
                        {
                            Result = result,
                            Invoker = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                                ClientNickname = result.GetFirstResult("invokername"),
                                ClientUniqueIdentifier = result.GetFirstResult("invokeruid"),
                            },
                            Channel = new TS3Models.Channel()
                            {
                                CId = Convert.ToInt32(result.GetFirstResult("cid")),
                                PId = Convert.ToInt32(result.GetFirstResult("cpid")),
                                ChannelName = result.GetFirstResult("channel_name"),
                                ChannelTopic = result.GetFirstResult("channel_topic"),
                                ChannelCodec = (TS3Models.Codec)Convert.ToInt32(result.GetFirstResult("channel_codec")),
                                ChannelCodecQuality = Convert.ToInt32(result.GetFirstResult("channel_codec_quality")),
                                ChannelMaxClients = Convert.ToInt32(result.GetFirstResult("channel_maxclients")),
                                ChannelMaxFamilyClients = Convert.ToInt32(result.GetFirstResult("channel_maxfamilyclients")),
                                ChannelOrder = Convert.ToInt32(result.GetFirstResult("channel_order")),
                                ChannelFlagPermanent = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_permanent"))),
                                ChannelFlagSemiPermanent = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_semi_permanent"))),
                                ChannelFlagDefault = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_default"))),
                                ChannelFlagPassword = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_password"))),
                                ChannelCodecLatencyFactor = Convert.ToInt32(result.GetFirstResult("channel_codec_latency_factor")),
                                ChannelCodecIsUnencrypted = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_codec_is_unencrypted"))),
                                ChannelDeleteDelay = Convert.ToInt32(result.GetFirstResult("channel_delete_delay")),
                                ChannelFlagMaxClientsUnlimited = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_maxclients_unlimited"))),
                                ChannelFlagMaxFamilyClientsUnlimited = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_maxfamilyclients_unlimited"))),
                                ChannelFlagMaxFamilyClientsInherited = Convert.ToBoolean(Convert.ToInt32(result.GetFirstResult("channel_flag_maxfamilyclients_inherited"))),
                                ChannelNeededTalkPower = Convert.ToInt32(result.GetFirstResult("channel_needed_talk_power")),
                                ChannelNamePhonetic = result.GetFirstResult("channel_name_phonetic"),
                                ChannelIconId = Convert.ToInt32(result.GetFirstResult("channel_icon_id"))
                            }
                        });
                    break;
                case TS3Models.Notifications.notifychanneldeleted:
                    if (OnChannelDeleted != null)
                        OnChannelDeleted(new TS3Models.ChannelDeleted()
                        {
                            Result = result,
                            Invoker = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                                ClientNickname = result.GetFirstResult("invokername"),
                                ClientUniqueIdentifier = result.GetFirstResult("invokeruid"),
                            },
                            Channel = new TS3Models.Channel()
                            {
                                CId = Convert.ToInt32(result.GetFirstResult("cid"))
                            }
                        });
                    break;
                #endregion
                #region Server
                case TS3Models.Notifications.notifyserveredited:
                    if (OnServerEdited != null)
                        OnServerEdited(new TS3Models.ServerEdited()
                        {
                            Result = result,
                            ReasonId = Convert.ToInt32(result.GetFirstResult("reasonid")),
                            Invoker = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                                ClientNickname = result.GetFirstResult("invokername"),
                                ClientUniqueIdentifier = result.GetFirstResult("invokeruid"),
                            },
                            VirtualServer = new TS3Models.VirtualServer()
                            {
                                VirtualServerName = result.GetFirstResult("virtualserver_name"),
                                VirtualServerCodecEncryptionMode = (TS3Models.CodecEncryptionMode)Convert.ToInt32(result.GetFirstResult("virtualserver_codec_encryption_mode")),
                                VirtualServerDefaultServerGroup = new TS3Models.ServerGroup()
                                {
                                    SgId = Convert.ToInt32(result.GetFirstResult("virtualserver_default_server_group"))
                                },
                                VirtualServerDefaultChannelGroup = new TS3Models.ChannelGroup()
                                {
                                    CgId = Convert.ToInt32(result.GetFirstResult("virtualserver_default_channel_group"))
                                },
                                VirtualServerHostbannerUrl = result.GetFirstResult("virtualserver_hostbanner_url"),
                                VirtualServerHostbannerGfxUrl = result.GetFirstResult("virtualserver_hostbanner_gfx_url"),
                                VirtualServerHostbannerGfxInterval = Convert.ToInt32(result.GetFirstResult("virtualserver_hostbanner_gfx_interval")),
                                VirtualServerPrioritySpeakerDimmModificator = Convert.ToInt32(result.GetFirstResult("virtualserver_priority_speaker_dimm_modificator")),
                                VirtualServerHostbuttonTooltip = result.GetFirstResult("virtualserver_hostbutton_tooltip"),
                                VirtualServerHostbuttonUrl = result.GetFirstResult("virtualserver_hostbutton_url"),
                                VirtualServerHostbuttonGfxUrl = result.GetFirstResult("virtualserver_hostbutton_gfx_url"),
                                VirtualServerNamePhonetic = result.GetFirstResult("virtualserver_name_phonetic"),
                                VirtualServerIconId = Convert.ToInt32(result.GetFirstResult("virtualserver_icon_id")),
                                VirtualServerHostbannerMode = (TS3Models.HostBannerMode)Convert.ToInt32(result.GetFirstResult("virtualserver_hostbanner_mode")),
                                VirtualServerChannelTempDeleteDelayDefault = Convert.ToInt32(result.GetFirstResult("virtualserver_channel_temp_delete_delay_default"))
                            }
                        });
                    break;
                #endregion
            }
        }
    }
}
