using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TS3ClientQueryFramework;
using TS3ClientQueryFramework.TS3Models;

namespace TS3ClientQueryDemo
{
    public partial class Main : Form
    {
        TS3Client ts3Client = new TS3Client();

        public Main()
        {
            InitializeComponent();
            
            if(ts3Client.Connect())
            {
                if(ts3Client.CurrentHandlerId != 1)
                    ts3Client.Use(1);
                pnlPoke.Enabled = comboBoxClients.Enabled = txtBoxMessage.Enabled = txtBoxLog.Enabled = btnSendPoke.Enabled = true;
                comboBoxClients.DataSource = ts3Client.GetClientList();

                ts3Client.ClientNotifyRegister(ts3Client.CurrentHandlerId, Notifications.notifyclientpoke);
                ts3Client.Notifier.OnClientPoke += Notifier_OnClientPoke;

                Client myClient = ts3Client.GetMyClient();
                lblNicknameText.Text = myClient.ClientNickname;
                lblChannelNameText.Text = myClient.Channel.ChannelName;

                txtBoxLog.Text = ts3Client.Log;
            }
        }

        public void Notifier_OnClientPoke(ClientPoke clientPoke)
        {
            this.Invoke((MethodInvoker)delegate {
                txtBoxLog.Text = ts3Client.Log;
            });
            MessageBox.Show(string.Format("You receive a poke message from: {0}\n\n{1}", clientPoke.Invoker.ClientNickname, clientPoke.Msg));
        }

        private void btnSendPoke_Click(object sender, EventArgs e)
        {
            if (ts3Client.IsConnected() && txtBoxMessage.Text != "")
            {
                Result result = ts3Client.ClientPoke(((Client)comboBoxClients.SelectedItem).ClId, txtBoxMessage.Text);
                if (result != null)
                    MessageBox.Show(result.ResultString);
                txtBoxLog.Text = ts3Client.Log;
            }
            else
                MessageBox.Show("Error");
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
