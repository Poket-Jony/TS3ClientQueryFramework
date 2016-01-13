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
                        OnClientEnterView(new TS3Models.ClientEnterView()
                        {
                            Result = result,
                            CfId = Convert.ToInt32(result.GetFirstResult("cfid")),
                            CtId = Convert.ToInt32(result.GetFirstResult("ctid")),
                            Reason = (TS3Models.ReasonIdentifier)Convert.ToInt32(result.GetFirstResult("reasonid")),
                            Client = new TS3Models.Client().FillWithResult(result)
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
                            Reason = (TS3Models.ReasonIdentifier)Convert.ToInt32(result.GetFirstResult("reasonid")),
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
                            Reason = (TS3Models.ReasonIdentifier)Convert.ToInt32(result.GetFirstResult("reasonid")),
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
                            Reason = (TS3Models.ReasonIdentifier)Convert.ToInt32(result.GetFirstResult("reasonid")),
                            Invoker = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                                ClientNickname = result.GetFirstResult("invokername"),
                                ClientUniqueIdentifier = result.GetFirstResult("invokeruid"),
                            },
                            Channel = new TS3Models.Channel().FillWithResult(result)
                        });
                    break;
                case TS3Models.Notifications.notifychanneledited:
                    if (OnChannelEdited != null)
                        OnChannelEdited(new TS3Models.ChannelEdited()
                        {
                            Result = result,
                            Reason = (TS3Models.ReasonIdentifier)Convert.ToInt32(result.GetFirstResult("reasonid")),
                            Invoker = new TS3Models.Client()
                            {
                                ClId = Convert.ToInt32(result.GetFirstResult("invokerid")),
                                ClientNickname = result.GetFirstResult("invokername"),
                                ClientUniqueIdentifier = result.GetFirstResult("invokeruid"),
                            },
                            Channel = new TS3Models.Channel().FillWithResult(result)
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
                            Channel = new TS3Models.Channel().FillWithResult(result)
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
                            Channel = new TS3Models.Channel().FillWithResult(result)
                        });
                    break;
                #endregion
                #region Server
                case TS3Models.Notifications.notifyserveredited:
                    if (OnServerEdited != null)
                        OnServerEdited(new TS3Models.ServerEdited()
                        {
                            Result = result,
                            Reason = (TS3Models.ReasonIdentifier)Convert.ToInt32(result.GetFirstResult("reasonid")),
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
