using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework
{
    public class TS3Client
    {
        private TelnetConnection telnetConnection = null;
        public TS3Notify Notifier = null;

        public int CurrentHandlerId { get; set; }

        /// <summary>
        /// Contains all log messages
        /// </summary>
        public string Log { get; set; }

        private string telnetString = null;
        public string ReadTelnet(bool isNotify = false)
        {
            if (!isNotify && telnetString != null)
            {
                string t = telnetString;
                telnetString = null;
                return t;
            }
            string output = telnetConnection.Read();
            if (isNotify && !string.IsNullOrEmpty(output) && !output.Contains("notify"))
            {
                telnetString = output;
                return null;
            }
            return output;
        }

        /// <summary>
        /// Connect to TS3 Client Query
        /// </summary>
        public bool Connect(string ip = "localhost", int port = 25639)
        {
            if (!IsConnected())
            {
                telnetConnection = new TelnetConnection(ip, port);
                string output = ReadTelnet();
                AddLog(output);
                if (output.Contains("TS3 Client"))
                {
                    Notifier = new TS3Notify(this);
                    Use();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Disconnect from TS3 Client Query
        /// </summary>
        public bool Disconnect()
        {
            if (IsConnected())
            {
                if (Notifier != null)
                    Notifier.StopNotificationListener();
                Notifier = null;
                telnetConnection.Close();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check that TS3 Client Query is connected
        /// </summary>
        public bool IsConnected()
        {
            if (telnetConnection != null && telnetConnection.IsConnected)
                return true;
            return false;
        }

        private void AddLog(string text)
        {
            Log += "[" + DateTime.Now.ToString() + "] " + text + Environment.NewLine;
        }

        /// <summary>
        /// Returns an command help text
        /// </summary>
        public string GetHelp()
        {
            if(IsConnected())
            {
                telnetConnection.WriteLine("help");
                string output = ReadTelnet();
                AddLog(output);
                return output;
            }
            return null;
        }

        /// <summary>
        /// Returns local client
        /// </summary>
        public TS3Models.Client GetWhoami()
        {
            if(IsConnected())
            {
                telnetConnection.WriteLine("whoami");
                string output = ReadTelnet();
                AddLog(output);
                TS3Models.Result result = TS3Helper.ParseResult(output, false);
                return new TS3Models.Client() {
                    Result = result,
                    Channel = new TS3Models.Channel() {
                        CId =  Convert.ToInt32(result.GetFirstResult("cid"))
                    },
                    ClId = Convert.ToInt32(result.GetFirstResult("clid"))
                };
            }
            return null;
        }

        /// <summary>
        /// Returns all clients which are connected to the server
        /// </summary>
        public List<TS3Models.Client> GetClientList()
        {
            if (IsConnected())
            {
                telnetConnection.WriteLine("clientlist");
                string output = ReadTelnet();
                AddLog(output);
                TS3Models.Result result = TS3Helper.ParseResult(output, true);
                List<TS3Models.Client> clients = new List<TS3Models.Client>();
                foreach(Dictionary<string, string> res in result.ResultsList)
                {
                    clients.Add(new TS3Models.Client() {
                        Result = result,
                        Channel = new TS3Models.Channel() {
                            CId = Convert.ToInt32(result.GetResultByList(res, "cid"))
                        },
                        ClId = Convert.ToInt32(result.GetResultByList(res, "clid")),
                        ClientDatabaseId = Convert.ToInt32(result.GetResultByList(res, "client_database_id")),
                        ClientNickname = result.GetResultByList(res, "client_nickname"),
                        ClientType = Convert.ToInt32(result.GetResultByList(res, "client_type"))
                    });
                }
                return clients;
            }
            return null;
        }

        /// <summary>
        /// Returns all channels on the server
        /// </summary>
        public List<TS3Models.Channel> GetChannelList()
        {
            if (IsConnected())
            {
                telnetConnection.WriteLine("channellist");
                string output = ReadTelnet();
                AddLog(output);
                TS3Models.Result result = TS3Helper.ParseResult(output, true);
                List<TS3Models.Channel> channels = new List<TS3Models.Channel>();
                foreach (Dictionary<string, string> res in result.ResultsList)
                {
                    channels.Add(new TS3Models.Channel()
                    {
                        Result = result,
                        CId = Convert.ToInt32(result.GetResultByList(res, "cid")),
                        PId = Convert.ToInt32(result.GetResultByList(res, "pid")),
                        ChannelOrder = Convert.ToInt32(result.GetResultByList(res, "channel_order")),
                        ChannelName = result.GetResultByList(res, "channel_name"),
                        ChannelFlagAreSubscribed = Convert.ToInt32(result.GetResultByList(res, "channel_flag_are_subscribed")),
                        TotalClients = Convert.ToInt32(result.GetResultByList(res, "total_clients")),
                    });
                }
                return channels;
            }
            return null;
        }

        /// <summary>
        /// Selects the client tab
        /// </summary>
        public TS3Models.Result Use(int? schandlerid = null)
        {
            if (IsConnected())
            {
                string query = "use";
                if (schandlerid != null)
                    query += string.Format(" schandlerid={0}", schandlerid);
                telnetConnection.WriteLine(query);
                string output = ReadTelnet();
                AddLog(output);
                TS3Models.Result result = TS3Helper.ParseResult(output, false);
                if (result != null && result.ErrorId == 0)
                    CurrentHandlerId = Convert.ToInt32(result.GetFirstResult("schandlerid"));
                return result;
            }
            return null;
        }

        /// <summary>
        /// Sends a text message to a client, channel, server
        /// </summary>
        public TS3Models.Result SendTextMessage(TS3Models.TextMessageTargetMode targetmode, int target, string msg)
        {
            if (IsConnected())
            {
                telnetConnection.WriteLine(string.Format("sendtextmessage targetmode={0} target={1} msg={2}", (int)targetmode, target, TS3Helper.EscapeString(msg)));
                string output = ReadTelnet();
                AddLog(output);
                return TS3Helper.ParseResult(output, false);
            }
            return null;
        }

        /// <summary>
        /// Sends a poke message to a client
        /// </summary>
        public TS3Models.Result ClientPoke(int clid, string msg)
        {
            if (IsConnected())
            {
                telnetConnection.WriteLine(string.Format("clientpoke clid={0} msg={1}", clid, TS3Helper.EscapeString(msg)));
                string output = ReadTelnet();
                AddLog(output);
                return TS3Helper.ParseResult(output, false);
            }
            return null;
        }

        /// <summary>
        /// Move a client to an other channel
        /// </summary>
        public TS3Models.Result ClientMove(int clid, int cid, string cpw = null)
        {
            return ClientMove(new List<int>() { clid }, cid, cpw);
        }

        /// <summary>
        /// Move a client to an other channel
        /// </summary>
        public TS3Models.Result ClientMove(List<int> clids, int cid, string cpw = null)
        {
            if (IsConnected())
            {
                string query = string.Format("clientmove {0} cid={1}", TS3Helper.StringSeperatedList("clid", clids.Cast<object>().ToList()), cid);
                if(!string.IsNullOrEmpty(cpw))
                    query += string.Format(" cpw={2}", TS3Helper.EscapeString(cpw));
                telnetConnection.WriteLine(query);
                string output = ReadTelnet();
                AddLog(output);
                return TS3Helper.ParseResult(output, false);
            }
            return null;
        }

        /// <summary>
        /// Kick a client from server
        /// </summary>
        public TS3Models.Result ClientKick(int clid, TS3Models.ReasonIdentifier reasonid, string reasonmsg = null)
        {
            return ClientKick(new List<int>() { clid }, reasonid, reasonmsg);
        }

        /// <summary>
        /// Kick a client from server
        /// </summary>
        public TS3Models.Result ClientKick(List<int> clids, TS3Models.ReasonIdentifier reasonid, string reasonmsg = null)
        {
            if (IsConnected())
            {
                string query = string.Format("clientkick {0} reasonid={1}", TS3Helper.StringSeperatedList("clid", clids.Cast<object>().ToList()), (int)reasonid);
                if (!string.IsNullOrEmpty(reasonmsg))
                    query += string.Format(" reasonmsg={2}", TS3Helper.EscapeString(reasonmsg));
                telnetConnection.WriteLine(query);
                string output = ReadTelnet();
                AddLog(output);
                return TS3Helper.ParseResult(output, false);
            }
            return null;
        }

        /// <summary>
        /// Ban a client from server
        /// </summary>
        public TS3Models.Result BanClient(int clid, int? time = null, string banreason = null)
        {
            return BanClient(new List<int>() { clid }, time, banreason);
        }

        /// <summary>
        /// Ban a client from server
        /// </summary>
        public TS3Models.Result BanClient(List<int> clids, int? time = null, string banreason = null)
        {
            if (IsConnected())
            {
                string query = string.Format("banclient {0}", TS3Helper.StringSeperatedList("clid", clids.Cast<object>().ToList()));
                if (time != null)
                    query += string.Format(" time={1}", time);
                if (string.IsNullOrEmpty(banreason))
                    query += string.Format(" banreason={2}", TS3Helper.EscapeString(banreason));
                telnetConnection.WriteLine(query);
                string output = ReadTelnet();
                AddLog(output);
                return TS3Helper.ParseResult(output, false);
            }
            return null;
        }

        /// <summary>
        /// Register client notification
        /// </summary>
        public TS3Models.Result ClientNotifyRegister(int schandlerid, TS3Models.Notifications notification)
        {
            if (IsConnected())
            {
                telnetConnection.WriteLine(string.Format("clientnotifyregister schandlerid={0} event={1}", schandlerid, notification));
                string output = ReadTelnet();
                AddLog(output);
                TS3Models.Result result = TS3Helper.ParseResult(output, false);
                if (result != null && result.ErrorId == 0)
                    Notifier.RegisterNotification(notification);
                return result;
            }
            return null;
        }

        public TS3Models.Result ClientNotifyUnregister(int schandlerid, TS3Models.Notifications notification)
        {
            if (IsConnected())
            {
                telnetConnection.WriteLine(string.Format("clientnotifyunregister schandlerid={0} event={1}", schandlerid, notification));
                string output = ReadTelnet();
                AddLog(output);
                TS3Models.Result result = TS3Helper.ParseResult(output, false);
                if (result != null && result.ErrorId == 0)
                    Notifier.UnregisterNotification(notification);
                return result;
            }
            return null;
        }
    }
}
