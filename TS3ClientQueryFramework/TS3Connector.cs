﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace TS3ClientQueryFramework
{
    internal class TS3Connector
    {
        private const int SLEEP_READ_TO_END = 500; //Warte auf gesamten Content
        private TcpClient tcpClient = null;
        private StreamReader streamReader = null;
        private StreamWriter streamWriter = null;
        private NetworkStream networkStream = null;
        private Thread responseThread = null;
        private TS3Client ts3Client = null;
        private string outputString = string.Empty;
        private bool cancelLoop = false;

        internal TS3Connector(TS3Client ts3Client, string hostname = "localhost", int port = 25639)
        {
            this.ts3Client = ts3Client;

            Connect(hostname, port);
        }

        internal bool IsConnected()
        {
            return tcpClient != null && tcpClient.Connected ? true : false;
        }

        internal bool Connect(string hostname = "localhost", int port = 25639)
        {
            if (!IsConnected())
            {
                try
                {
                    tcpClient = new TcpClient(hostname, port);
                    if (!IsConnected())
                        throw new Exception("Could not connect.");
                }
                catch
                {
                    return false;
                }

                networkStream = tcpClient.GetStream();
                streamReader = new StreamReader(networkStream);
                streamWriter = new StreamWriter(networkStream) { NewLine = "\n" };

                // Ignore welcome message
                streamReader.ReadLine();
                streamReader.ReadLine();
                streamReader.ReadLine();
                streamReader.ReadLine();

                StartResponseLoop();
                TS3Models.Result result = TS3Helper.ParseResult(ReadAll(), false);
                if(result != null && result.ErrorId == 0)
                    ts3Client.CurrentHandlerId = Convert.ToInt32(result.GetFirstResult("schandlerid"));
                return true;
            }
            return false;
        }

        internal bool Close()
        {
            if(IsConnected())
            {
                StopResponseLoop();
                tcpClient.Close();
                tcpClient = null;
                networkStream.Close();
                networkStream = null;
                streamReader.Close();
                streamReader = null;
                streamWriter.Close();
                streamWriter = null;
                outputString = null;
            }
            return false;
        }

        internal bool WriteLine(string text)
        {
            if (IsConnected())
            {
                ts3Client.AddLog(text);
                streamWriter.WriteLine(text);
                streamWriter.Flush();
                return true;
            }
            return false;
        }

        internal string ReadAll()
        {
            if (IsConnected())
            {
                Thread.Sleep(SLEEP_READ_TO_END); //Read to end
                if (!string.IsNullOrEmpty(outputString))
                {
                    string t = outputString;
                    outputString = string.Empty;
                    return t;
                }
            }
            return null;
        }

        internal bool ClearOutput()
        {
            if(IsConnected())
            {
                outputString = string.Empty;
                return true;
            }
            return false;
        }

        internal bool IsResponseThreadRunning()
        {
            return responseThread != null && responseThread.IsAlive ? true : false;
        }

        public bool StopResponseLoop()
        {
            if (!cancelLoop)
            {
                cancelLoop = true;
                return true;
            }
            return false;
        }

        internal void StartResponseLoop()
        {
            Task.Run(async () =>
            {
                while (!cancelLoop)
                {
                    string line = await streamReader.ReadLineAsync();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    line = line.Trim();
                    ts3Client.AddLog(line);
                    if (line.StartsWith("notify", StringComparison.InvariantCultureIgnoreCase))
                    {
                        new Thread(delegate () {
                            ts3Client.Notifier.ReceiveNotification(line);
                        }).Start();
                    }
                    else
                    {
                        outputString += line;
                    }
                }
            });
        }
    }
}
