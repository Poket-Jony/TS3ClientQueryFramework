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
        public event OnNotificationHandler OnNotification;
        public event OnTextMessageHandler OnTextMessage;
        public event OnClientPokeHandler OnClientPoke;

        private TS3Client ts3Client = null;
        private Thread notificationListener = null;
        private List<TS3Models.Notifications> registeredNotifications = new List<TS3Models.Notifications>();

        public TS3Notify(TS3Client client)
        {
            ts3Client = client;
        }

        public bool RegisterNotification(TS3Models.Notifications notification)
        {
            if (!registeredNotifications.Contains(notification))
            {
                registeredNotifications.Add(notification);
                if (!IsNotificationListenerRunning())
                    StartNotificationListener();
                return true;
            }
            return false;
        }

        public bool UnregisterNotification(TS3Models.Notifications notification)
        {
            if (registeredNotifications.Contains(notification))
            {
                registeredNotifications.Remove(notification);
                if (IsNotificationListenerRunning() && registeredNotifications.Count == 0)
                    StopNotificationListener();
                return true;
            }
            return false;
        }

        public bool IsNotificationListenerRunning()
        {
            return notificationListener != null && notificationListener.IsAlive ? true : false;
        }

        public bool StartNotificationListener()
        {
            if (!IsNotificationListenerRunning())
            {
                notificationListener = new Thread(new ThreadStart(WorkNotificationThread));
                notificationListener.Start();
                return true;
            }
            return false;
        }

        public bool StopNotificationListener()
        {
            if (IsNotificationListenerRunning())
            {
                notificationListener.Abort();
                notificationListener = null;
                return true;
            }
            return false;
        }

        private void WorkNotificationThread()
        {
            if(ts3Client != null && ts3Client.IsConnected())
            {
                while(true)
                {
                    string output = ts3Client.ReadTelnet(true);
                    if(!string.IsNullOrEmpty(output))
                    {
                        foreach (TS3Models.Notifications noti in registeredNotifications)
                        {
                            if(output.Contains(noti.ToString()))
                            {
                                TS3Models.Result result = TS3Helper.ParseResult(output, false);
                                if (OnNotification != null)
                                    OnNotification(noti, result);
                                ParseNotification(noti, result);
                            }
                        }
                    }
                    Thread.Sleep(1000);
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
            }
        }
    }
}
