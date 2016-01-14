using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class VirtualServer
    {
        private string virtualServerUniqueIdentifier = null;
        public string VirtualServerUniqueIdentifier
        {
            get
            {
                return virtualServerUniqueIdentifier;
            }
            set
            {
                virtualServerUniqueIdentifier = TS3Helper.UnescapeString(value);
            }
        }
        private string virtualServerName = null;
        public string VirtualServerName
        {
            get
            {
                return virtualServerName;
            }
            set
            {
                virtualServerName = TS3Helper.UnescapeString(value);
            }
        }
        private string virtualServerWelcomemessage = null;
        public string VirtualServerWelcomemessage
        {
            get
            {
                return virtualServerWelcomemessage;
            }
            set
            {
                virtualServerWelcomemessage = TS3Helper.UnescapeString(value);
            }
        }
        private string virtualServerPlatform = null;
        public string VirtualServerPlatform
        {
            get
            {
                return virtualServerPlatform;
            }
            set
            {
                virtualServerPlatform = TS3Helper.UnescapeString(value);
            }
        }
        private string virtualServerVersion = null;
        public string VirtualServerVersion
        {
            get
            {
                return virtualServerVersion;
            }
            set
            {
                virtualServerVersion = TS3Helper.UnescapeString(value);
            }
        }
        public int VirtualServerMaxclients { get; set; }
        private string virtualServerPassword = null;
        public string VirtualServerPassword
        {
            get
            {
                return virtualServerPassword;
            }
            set
            {
                virtualServerPassword = TS3Helper.UnescapeString(value);
            }
        }
        public int VirtualServerClientsonline { get; set; }
        public int VirtualServerChannelsonline { get; set; }
        public ulong VirtualServerCreated { get; set; }
        public ulong VirtualServerUptime { get; set; }
        public CodecEncryptionMode VirtualServerCodecEncryptionMode { get; set; }
        private string virtualServerHostmessage = null;
        public string VirtualServerHostmessage
        {
            get
            {
                return virtualServerHostmessage;
            }
            set
            {
                virtualServerHostmessage = TS3Helper.UnescapeString(value);
            }
        }
        public HostMessageMode VirtualServerHostmessageMode { get; set; }
        private string virtualServerFilebase = null;
        public string VirtualServerFilebase
        {
            get
            {
                return virtualServerFilebase;
            }
            set
            {
                virtualServerFilebase = TS3Helper.UnescapeString(value);
            }
        }
        public ServerGroup VirtualServerDefaultServerGroup { get; set; }
        public ChannelGroup VirtualServerDefaultChannelGroup { get; set; }
        public bool VirtualServerFlagPassword { get; set; }
        public int VirtualServerDefaultChannelAdminGroup { get; set; }
        public ulong VirtualServerMaxDownloadTotalBandwidth { get; set; }
        public ulong VirtualServerMaxUploadTotalBandwidth { get; set; }
        private string virtualServerHostbannerUrl = null;
        public string VirtualServerHostbannerUrl
        {
            get
            {
                return virtualServerHostbannerUrl;
            }
            set
            {
                virtualServerHostbannerUrl = TS3Helper.UnescapeString(value);
            }
        }
        private string virtualServerHostbannerGfxUrl = null;
        public string VirtualServerHostbannerGfxUrl
        {
            get
            {
                return virtualServerHostbannerGfxUrl;
            }
            set
            {
                virtualServerHostbannerGfxUrl = TS3Helper.UnescapeString(value);
            }
        }
        public int VirtualServerHostbannerGfxInterval { get; set; }
        public int VirtualServerComplainAutobanCount { get; set; }
        public int VirtualServerComplainAutobanTime { get; set; }
        public int VirtualServerComplainRemoveTime { get; set; }
        public int VirtualServerMinClientsInChannelBeforeForcedSilence { get; set; }
        public double VirtualServerPrioritySpeakerDimmModificator { get; set; }
        public int VirtualServerId { get; set; }
        public int VirtualServerAntifloodPointsTickReduce { get; set; }
        public int VirtualServerAntifloodPointsNeededCommandBlock { get; set; }
        public int VirtualServerAntifloodPointsNeededIpBlock { get; set; }
        public int VirtualServerClientConnections { get; set; }
        public int VirtualServerQueryClientConnections { get; set; }
        private string virtualServerHostbuttonTooltip = null;
        public string VirtualServerHostbuttonTooltip
        {
            get
            {
                return virtualServerHostbuttonTooltip;
            }
            set
            {
                virtualServerHostbuttonTooltip = TS3Helper.UnescapeString(value);
            }
        }
        private string virtualServerHostbuttonUrl = null;
        public string VirtualServerHostbuttonUrl
        {
            get
            {
                return virtualServerHostbuttonUrl;
            }
            set
            {
                virtualServerHostbuttonUrl = TS3Helper.UnescapeString(value);
            }
        }
        private string virtualServerHostbuttonGfxUrl = null;
        public string VirtualServerHostbuttonGfxUrl
        {
            get
            {
                return virtualServerHostbuttonGfxUrl;
            }
            set
            {
                virtualServerHostbuttonGfxUrl = TS3Helper.UnescapeString(value);
            }
        }
        public int VirtualServerQueryclientsonline { get; set; }
        public ulong VirtualServerDownloadQuota { get; set; }
        public ulong VirtualServerUploadQuota { get; set; }
        public ulong VirtualServerMonthBytesDownloaded { get; set; }
        public ulong VirtualServerMonthBytesUploaded { get; set; }
        public ulong VirtualServerTotalBytesDownloaded { get; set; }
        public ulong VirtualServerTotalBytesUploaded { get; set; }
        public int VirtualServerPort { get; set; }
        public bool VirtualServerAutostart { get; set; }
        public int VirtualServerMachineId { get; set; }
        public int VirtualServerNeededIdentitySecurityLevel { get; set; }
        public bool VirtualServerLogClient { get; set; }
        public bool VirtualServerLogQuery { get; set; }
        public bool VirtualServerLogChannel { get; set; }
        public bool VirtualServerLogPermissions { get; set; }
        public bool VirtualServerLogServer { get; set; }
        public bool VirtualServerLogFiletransfer { get; set; }
        public ulong VirtualServerMinClientVersion { get; set; }
        private string virtualServerNamePhonetic = null;
        public string VirtualServerNamePhonetic
        {
            get
            {
                return virtualServerNamePhonetic;
            }
            set
            {
                virtualServerNamePhonetic = TS3Helper.UnescapeString(value);
            }
        }
        public ulong VirtualServerIconId { get; set; }
        public int VirtualServerReservedSlots { get; set; }
        public double VirtualServerTotalPacketlossSpeech { get; set; }
        public double VirtualServerTotalPacketlossKeepalive { get; set; }
        public double VirtualServerTotalPacketlossControl { get; set; }
        public double VirtualServerTotalPacketlossTotal { get; set; }
        public double VirtualServerTotalPing { get; set; }
        private string virtualServerIp = null;
        public string VirtualServerIp
        {
            get
            {
                return virtualServerIp;
            }
            set
            {
                virtualServerIp = TS3Helper.UnescapeString(value);
            }
        }
        public bool VirtualServerWeblistEnabled { get; set; }
        public bool VirtualServerAskForPrivilegekey { get; set; }
        public HostBannerMode VirtualServerHostbannerMode { get; set; }
        public int VirtualServerChannelTempDeleteDelayDefault { get; set; }
        private string virtualServerStatus = null;
        public string VirtualServerStatus
        {
            get
            {
                return virtualServerStatus;
            }
            set
            {
                virtualServerStatus = TS3Helper.UnescapeString(value);
            }
        }

        public Result Result { get; set; }

        public override string ToString()
        {
            return VirtualServerName;
        }

        public VirtualServer FillWithResult(Result result)
        {
            return FillWithResult(result, result.ResultsList.First());
        }

        public VirtualServer FillWithResult(Result result, Dictionary<string, string> list)
        {
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_unique_identifier.ToString()) != null)
                this.VirtualServerUniqueIdentifier = result.GetResultByList(list, VirtualServerProperties.virtualserver_unique_identifier.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_name.ToString()) != null)
                this.VirtualServerName = result.GetResultByList(list, VirtualServerProperties.virtualserver_name.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_welcomemessage.ToString()) != null)
                this.VirtualServerWelcomemessage = result.GetResultByList(list, VirtualServerProperties.virtualserver_welcomemessage.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_platform.ToString()) != null)
                this.VirtualServerPlatform = result.GetResultByList(list, VirtualServerProperties.virtualserver_platform.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_version.ToString()) != null)
                this.VirtualServerVersion = result.GetResultByList(list, VirtualServerProperties.virtualserver_version.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_maxclients.ToString()) != null)
                this.VirtualServerMaxclients = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_maxclients.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_password.ToString()) != null)
                this.VirtualServerPassword = result.GetResultByList(list, VirtualServerProperties.virtualserver_password.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_clientsonline.ToString()) != null)
                this.VirtualServerClientsonline = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_clientsonline.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_channelsonline.ToString()) != null)
                this.VirtualServerChannelsonline = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_channelsonline.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_created.ToString()) != null)
                this.VirtualServerCreated = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_created.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_uptime.ToString()) != null)
                this.VirtualServerUptime = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_uptime.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_codec_encryption_mode.ToString()) != null)
                this.VirtualServerCodecEncryptionMode = (CodecEncryptionMode)Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_codec_encryption_mode.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostmessage.ToString()) != null)
                this.VirtualServerHostmessage = result.GetResultByList(list, VirtualServerProperties.virtualserver_hostmessage.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostmessage_mode.ToString()) != null)
                this.VirtualServerHostmessageMode = (HostMessageMode)Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_hostmessage_mode.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_filebase.ToString()) != null)
                this.VirtualServerFilebase = result.GetResultByList(list, VirtualServerProperties.virtualserver_filebase.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_default_server_group.ToString()) != null)
                this.VirtualServerDefaultServerGroup = new TS3Models.ServerGroup()
                {
                    SgId = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_default_server_group.ToString()))
                };
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_default_channel_group.ToString()) != null)
                this.VirtualServerDefaultChannelGroup = new TS3Models.ChannelGroup()
                {
                    CgId = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_default_channel_group.ToString()))
                };
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_flag_password.ToString()) != null)
                this.VirtualServerFlagPassword = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_flag_password.ToString())));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_default_channel_admin_group.ToString()) != null)
                this.VirtualServerDefaultChannelAdminGroup = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_default_channel_admin_group.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_max_download_total_bandwidth.ToString()) != null)
                this.VirtualServerMaxDownloadTotalBandwidth = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_max_download_total_bandwidth.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_max_upload_total_bandwidth.ToString()) != null)
                this.VirtualServerMaxUploadTotalBandwidth = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_max_upload_total_bandwidth.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_url.ToString()) != null)
                this.VirtualServerHostbannerUrl = result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_url.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_gfx_url.ToString()) != null)
                this.VirtualServerHostbannerGfxUrl = result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_gfx_url.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_gfx_interval.ToString()) != null)
                this.VirtualServerHostbannerGfxInterval = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_gfx_interval.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_complain_autoban_count.ToString()) != null)
                this.VirtualServerComplainAutobanCount = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_complain_autoban_count.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_complain_autoban_time.ToString()) != null)
                this.VirtualServerComplainAutobanTime = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_complain_autoban_time.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_complain_remove_time.ToString()) != null)
                this.VirtualServerComplainRemoveTime = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_complain_remove_time.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_min_clients_in_channel_before_forced_silence.ToString()) != null)
                this.VirtualServerMinClientsInChannelBeforeForcedSilence = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_min_clients_in_channel_before_forced_silence.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_priority_speaker_dimm_modificator.ToString()) != null)
                this.VirtualServerPrioritySpeakerDimmModificator = Convert.ToDouble(result.GetResultByList(list, VirtualServerProperties.virtualserver_priority_speaker_dimm_modificator.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_id.ToString()) != null)
                this.VirtualServerId = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_id.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_antiflood_points_tick_reduce.ToString()) != null)
                this.VirtualServerAntifloodPointsTickReduce = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_antiflood_points_tick_reduce.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_antiflood_points_needed_command_block.ToString()) != null)
                this.VirtualServerAntifloodPointsNeededCommandBlock = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_antiflood_points_needed_command_block.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_antiflood_points_needed_ip_block.ToString()) != null)
                this.VirtualServerAntifloodPointsNeededIpBlock = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_antiflood_points_needed_ip_block.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_client_connections.ToString()) != null)
                this.VirtualServerClientConnections = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_client_connections.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_query_client_connections.ToString()) != null)
                this.VirtualServerQueryClientConnections = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_query_client_connections.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_tooltip.ToString()) != null)
                this.VirtualServerHostbuttonTooltip = result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_tooltip.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_url.ToString()) != null)
                this.VirtualServerHostbuttonUrl = result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_url.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_gfx_url.ToString()) != null)
                this.VirtualServerHostbuttonGfxUrl = result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_gfx_url.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_queryclientsonline.ToString()) != null)
                this.VirtualServerQueryclientsonline = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_queryclientsonline.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_download_quota.ToString()) != null)
                this.VirtualServerDownloadQuota = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_download_quota.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_upload_quota.ToString()) != null)
                this.VirtualServerUploadQuota = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_upload_quota.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_month_bytes_downloaded.ToString()) != null)
                this.VirtualServerMonthBytesDownloaded = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_month_bytes_downloaded.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_month_bytes_uploaded.ToString()) != null)
                this.VirtualServerMonthBytesUploaded = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_month_bytes_uploaded.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_total_bytes_downloaded.ToString()) != null)
                this.VirtualServerTotalBytesDownloaded = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_total_bytes_downloaded.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_total_bytes_uploaded.ToString()) != null)
                this.VirtualServerTotalBytesUploaded = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_total_bytes_uploaded.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_port.ToString()) != null)
                this.VirtualServerPort = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_port.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_autostart.ToString()) != null)
                this.VirtualServerAutostart = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_autostart.ToString())));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_machine_id.ToString()) != null)
                this.VirtualServerMachineId = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_machine_id.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_needed_identity_security_level.ToString()) != null)
                this.VirtualServerNeededIdentitySecurityLevel = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_needed_identity_security_level.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_log_client.ToString()) != null)
                this.VirtualServerLogClient = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_log_client.ToString())));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_log_query.ToString()) != null)
                this.VirtualServerLogQuery = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_log_query.ToString())));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_log_channel.ToString()) != null)
                this.VirtualServerLogChannel = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_log_channel.ToString())));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_log_permissions.ToString()) != null)
                this.VirtualServerLogPermissions = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_log_permissions.ToString())));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_log_server.ToString()) != null)
                this.VirtualServerLogServer = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_log_server.ToString())));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_log_filetransfer.ToString()) != null)
                this.VirtualServerLogFiletransfer = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_log_filetransfer.ToString())));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_min_client_version.ToString()) != null)
                this.VirtualServerMinClientVersion = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_min_client_version.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_name_phonetic.ToString()) != null)
                this.VirtualServerNamePhonetic = result.GetResultByList(list, VirtualServerProperties.virtualserver_name_phonetic.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_icon_id.ToString()) != null)
                this.VirtualServerIconId = Convert.ToUInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_icon_id.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_reserved_slots.ToString()) != null)
                this.VirtualServerReservedSlots = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_reserved_slots.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_total_packetloss_speech.ToString()) != null)
                this.VirtualServerTotalPacketlossSpeech = Convert.ToDouble(result.GetResultByList(list, VirtualServerProperties.virtualserver_total_packetloss_speech.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_total_packetloss_keepalive.ToString()) != null)
                this.VirtualServerTotalPacketlossKeepalive = Convert.ToDouble(result.GetResultByList(list, VirtualServerProperties.virtualserver_total_packetloss_keepalive.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_total_packetloss_control.ToString()) != null)
                this.VirtualServerTotalPacketlossControl = Convert.ToDouble(result.GetResultByList(list, VirtualServerProperties.virtualserver_total_packetloss_control.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_total_packetloss_total.ToString()) != null)
                this.VirtualServerTotalPacketlossTotal = Convert.ToDouble(result.GetResultByList(list, VirtualServerProperties.virtualserver_total_packetloss_total.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_total_ping.ToString()) != null)
                this.VirtualServerTotalPing = Convert.ToDouble(result.GetResultByList(list, VirtualServerProperties.virtualserver_total_ping.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_ip.ToString()) != null)
                this.VirtualServerIp = result.GetResultByList(list, VirtualServerProperties.virtualserver_ip.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_weblist_enabled.ToString()) != null)
                this.VirtualServerWeblistEnabled = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_weblist_enabled.ToString())));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_ask_for_privilegekey.ToString()) != null)
                this.VirtualServerAskForPrivilegekey = Convert.ToBoolean(Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_ask_for_privilegekey.ToString())));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_mode.ToString()) != null)
                this.VirtualServerHostbannerMode = (TS3Models.HostBannerMode)Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_mode.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_channel_temp_delete_delay_default.ToString()) != null)
                this.VirtualServerChannelTempDeleteDelayDefault = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_channel_temp_delete_delay_default.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_status.ToString()) != null)
                this.VirtualServerStatus = result.GetResultByList(list, VirtualServerProperties.virtualserver_status.ToString());
            return this;
        }
    }
}
