using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TS3ClientQueryFramework
{
    public class TS3Client
    {
        private TS3Connector ts3Connection = null;
        public TS3Notify Notifier { get; set; } = null;

        public int CurrentHandlerId { get; set; } = 0;

        public TS3Client()
        {
            Console.WriteLine(string.Format("Version: {0}", TS3Helper.GetVersion()));
        }

        /// <summary>
        /// Contains all log messages
        /// </summary>
        public string Log { get; set; }

        private string ReadAll()
        {
            if (IsConnected())
            {
                return ts3Connection.ReadAll();
            }
            return null;
        }

        /// <summary>
        /// Clears the read buffer
        /// </summary>
        public bool ClearReadBuffer()
        {
            return ts3Connection.ClearOutput();
        }

        /// <summary>
        /// Connect to TS3 Client Query
        /// </summary>
        public bool Connect(string hostname = "localhost", int port = 25639)
        {
            if (!IsConnected())
            {
                ts3Connection = new TS3Connector(this, hostname, port);
                if (ts3Connection.IsConnected())
                {
                    Notifier = new TS3Notify(this);
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
                Notifier = null;
                ts3Connection.Close();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check that TS3 Client Query is connected
        /// </summary>
        public bool IsConnected()
        {
            if (ts3Connection != null && ts3Connection.IsConnected())
                return true;
            return false;
        }

        public void AddLog(string text)
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
                ts3Connection.WriteLine("help");
                return ReadAll();
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
                ts3Connection.WriteLine("whoami");
                TS3Models.Result result = TS3Helper.ParseResult(ReadAll(), false);
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
                ts3Connection.WriteLine("clientlist");
                TS3Models.Result result = TS3Helper.ParseResult(ReadAll(), true);
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
                ts3Connection.WriteLine("channellist");
                TS3Models.Result result = TS3Helper.ParseResult(ReadAll(), true);
                List<TS3Models.Channel> channels = new List<TS3Models.Channel>();
                foreach (Dictionary<string, string> res in result.ResultsList)
                {
                    channels.Add(new TS3Models.Channel().FillWithResult(result, res));
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
                ts3Connection.WriteLine(query);
                TS3Models.Result result = TS3Helper.ParseResult(ReadAll(), false);
                if (result != null && result.ErrorId == 0)
                    CurrentHandlerId = Convert.ToInt32(result.GetFirstResult("schandlerid"));
                return result;
            }
            return null;
        }

        /// <summary>
        /// Sends a text message to a client, channel, server
        /// </summary>
        public TS3Models.Result SendTextMessage(TS3Models.TextMessageTargetMode targetmode, int target, string msg, bool withoutResponse = false)
        {
            if (IsConnected())
            {
                ts3Connection.WriteLine(string.Format("sendtextmessage targetmode={0} target={1} msg={2}", (int)targetmode, target, TS3Helper.EscapeString(msg)));
                if(!withoutResponse)
                    return TS3Helper.ParseResult(ReadAll(), false);
                return null;
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
                ts3Connection.WriteLine(string.Format("clientpoke clid={0} msg={1}", clid, TS3Helper.EscapeString(msg)));
                return TS3Helper.ParseResult(ReadAll(), false);
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
                string query = string.Format("clientmove {0} cid={1}", TS3Helper.GetSeperatedParamStringList("clid", clids.Cast<object>().ToList()), cid);
                if(!string.IsNullOrEmpty(cpw))
                    query += string.Format(" cpw={0}", TS3Helper.EscapeString(cpw));
                ts3Connection.WriteLine(query);
                return TS3Helper.ParseResult(ReadAll(), false);
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
                string query = string.Format("clientkick {0} reasonid={1}", TS3Helper.GetSeperatedParamStringList("clid", clids.Cast<object>().ToList()), (int)reasonid);
                if (!string.IsNullOrEmpty(reasonmsg))
                    query += string.Format(" reasonmsg={0}", TS3Helper.EscapeString(reasonmsg));
                ts3Connection.WriteLine(query);
                return TS3Helper.ParseResult(ReadAll(), false);
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
                string query = string.Format("banclient {0}", TS3Helper.GetSeperatedParamStringList("clid", clids.Cast<object>().ToList()));
                if (time != null)
                    query += string.Format(" time={0}", time);
                if (string.IsNullOrEmpty(banreason))
                    query += string.Format(" banreason={0}", TS3Helper.EscapeString(banreason));
                ts3Connection.WriteLine(query);
                return TS3Helper.ParseResult(ReadAll(), false);
            }
            return null;
        }

        /// <summary>
        /// Update client infos
        /// </summary>
        public TS3Models.Result ClientUpdate(Dictionary<TS3Models.ClientProperties, object> clientProperties)
        {
            if (IsConnected())
            {
                string query = "clientupdate";
                foreach (KeyValuePair<TS3Models.ClientProperties, object> prop in clientProperties)
                {
                    query += string.Format(" {0}={1}", prop.Key, TS3Helper.EscapeString(prop.Value.ToString()));
                }
                ts3Connection.WriteLine(query);
                return TS3Helper.ParseResult(ReadAll(), false);
            }
            return null;
        }

        /// <summary>
        /// Create a new channel
        /// </summary>
        public TS3Models.Result ChannelCreate(string channelName, Dictionary<TS3Models.ChannelProperties, object> channelProperties = null)
        {
            if (IsConnected())
            {
                string query = string.Format("channelcreate channel_name={0}", TS3Helper.EscapeString(channelName));
                if (channelProperties != null)
                {
                    foreach (KeyValuePair<TS3Models.ChannelProperties, object> prop in channelProperties)
                    {
                        query += string.Format(" {0}={1}", prop.Key, TS3Helper.EscapeString(prop.Value.ToString()));
                    }
                }
                ts3Connection.WriteLine(query);
                return TS3Helper.ParseResult(ReadAll(), false);
            }
            return null;
        }

        /// <summary>
        /// Delete a channel
        /// </summary>
        public TS3Models.Result ChannelDelete(int cid, bool force = false)
        {
            if (IsConnected())
            {
                string query = string.Format("channeldelete cid={0} force={1}", cid, Convert.ToInt32(force));
                ts3Connection.WriteLine(query);
                return TS3Helper.ParseResult(ReadAll(), false);
            }
            return null;
        }

        /// <summary>
        /// Modify channel properties
        /// </summary>
        public TS3Models.Result ChannelEdit(int cid, Dictionary<TS3Models.ChannelProperties, object> channelProperties)
        {
            if (IsConnected())
            {
                string query = string.Format("channeledit cid={0}", cid);
                foreach (KeyValuePair<TS3Models.ChannelProperties, object> prop in channelProperties)
                {
                    query += string.Format(" {0}={1}", prop.Key, TS3Helper.EscapeString(prop.Value.ToString()));
                }
                ts3Connection.WriteLine(query);
                return TS3Helper.ParseResult(ReadAll(), false);
            }
            return null;
        }

        /// <summary>
        /// Move channel
        /// </summary>
        public TS3Models.Result ChannelMove(int cid, int cpid, int order = 0)
        {
            if (IsConnected())
            {
                string query = string.Format("channelmove cid={0} cpid={1} order={2}", cid, cpid, order);
                ts3Connection.WriteLine(query);
                return TS3Helper.ParseResult(ReadAll(), false);
            }
            return null;
        }

        /// <summary>
        /// Get channel variables
        /// Dictionary<cid, List<TS3Models.ChannelProperties>>
        /// </summary>
        public List<TS3Models.Channel> ChannelVariable(Dictionary<int, List<TS3Models.ChannelProperties>> channelVars)
        {
            if (IsConnected())
            {
                string query = "channelvariable ";
                foreach (KeyValuePair<int, List<TS3Models.ChannelProperties>> cvar in channelVars)
                {
                    query += string.Format("cid={0}", cvar.Key);
                    foreach (TS3Models.ChannelProperties prop in cvar.Value)
                    {
                        query += string.Format(" {0}", prop);
                    }
                    query += "|";
                }
                query = query.Remove(query.Length - 1);
                ts3Connection.WriteLine(query);
                TS3Models.Result result = TS3Helper.ParseResult(ReadAll(), true);
                List<TS3Models.Channel> channels = new List<TS3Models.Channel>();
                foreach (Dictionary<string, string> res in result.ResultsList)
                {
                    channels.Add(new TS3Models.Channel().FillWithResult(result, res));
                }
                return channels;
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
                ts3Connection.WriteLine(string.Format("clientnotifyregister schandlerid={0} event={1}", schandlerid, notification));
                TS3Models.Result result = TS3Helper.ParseResult(ReadAll(), false);
                if (result != null && result.ErrorId == 0)
                    Notifier.RegisterNotification(notification);
                return result;
            }
            return null;
        }

        /// <summary>
        /// Unregister client notification
        /// </summary>
        public TS3Models.Result ClientNotifyUnregister(int schandlerid, TS3Models.Notifications notification)
        {
            if (IsConnected())
            {
                ts3Connection.WriteLine(string.Format("clientnotifyunregister schandlerid={0} event={1}", schandlerid, notification));
                TS3Models.Result result = TS3Helper.ParseResult(ReadAll(), false);
                if (result != null && result.ErrorId == 0)
                    Notifier.UnregisterNotification(notification);
                return result;
            }
            return null;
        }
    }
}
