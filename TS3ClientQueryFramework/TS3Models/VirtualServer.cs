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
        public int VirtualServerPrioritySpeakerDimmModificator { get; set; }
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
        public int VirtualServerIconId { get; set; }
        public HostBannerMode VirtualServerHostbannerMode { get; set; }
        public int VirtualServerChannelTempDeleteDelayDefault { get; set; }
    }
}
