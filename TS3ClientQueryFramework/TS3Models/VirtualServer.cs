using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class VirtualServer
    {
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
        public CodecEncryptionMode VirtualServerCodecEncryptionMode { get; set; }
        public ServerGroup VirtualServerDefaultServerGroup { get; set; }
        public ChannelGroup VirtualServerDefaultChannelGroup { get; set; }
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
        public double VirtualServerPrioritySpeakerDimmModificator { get; set; }
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
        public long VirtualServerIconId { get; set; }
        public HostBannerMode VirtualServerHostbannerMode { get; set; }
        public int VirtualServerChannelTempDeleteDelayDefault { get; set; }

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
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_name.ToString()) != null)
                this.VirtualServerName = result.GetResultByList(list, VirtualServerProperties.virtualserver_name.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_codec_encryption_mode.ToString()) != null)
                this.VirtualServerCodecEncryptionMode = (TS3Models.CodecEncryptionMode)Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_codec_encryption_mode.ToString()));
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
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_url.ToString()) != null)
                this.VirtualServerHostbannerUrl = result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_url.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_gfx_url.ToString()) != null)
                this.VirtualServerHostbannerGfxUrl = result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_gfx_url.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_gfx_interval.ToString()) != null)
                this.VirtualServerHostbannerGfxInterval = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_gfx_interval.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_priority_speaker_dimm_modificator.ToString()) != null)
                this.VirtualServerPrioritySpeakerDimmModificator = Convert.ToDouble(result.GetResultByList(list, VirtualServerProperties.virtualserver_priority_speaker_dimm_modificator.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_tooltip.ToString()) != null)
                this.VirtualServerHostbuttonTooltip = result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_tooltip.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_url.ToString()) != null)
                this.VirtualServerHostbuttonUrl = result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_url.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_gfx_url.ToString()) != null)
                this.VirtualServerHostbuttonGfxUrl = result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbutton_gfx_url.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_name_phonetic.ToString()) != null)
                this.VirtualServerNamePhonetic = result.GetResultByList(list, VirtualServerProperties.virtualserver_name_phonetic.ToString());
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_icon_id.ToString()) != null)
                this.VirtualServerIconId = Convert.ToInt64(result.GetResultByList(list, VirtualServerProperties.virtualserver_icon_id.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_mode.ToString()) != null)
                this.VirtualServerHostbannerMode = (TS3Models.HostBannerMode)Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_hostbanner_mode.ToString()));
            if (result.GetResultByList(list, VirtualServerProperties.virtualserver_channel_temp_delete_delay_default.ToString()) != null)
                this.VirtualServerChannelTempDeleteDelayDefault = Convert.ToInt32(result.GetResultByList(list, VirtualServerProperties.virtualserver_channel_temp_delete_delay_default.ToString()));
            return this;
        }
    }
}
