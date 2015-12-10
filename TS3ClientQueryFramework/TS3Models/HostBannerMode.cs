namespace TS3ClientQueryFramework.TS3Models
{
    public enum HostBannerMode
    {
        HostMessageMode_NOADJUST = 0, // 0: do not adjust
        HostMessageMode_IGNOREASPECT = 1, // 1: adjust but ignore aspect ratio (like TeamSpeak 2)
        HostMessageMode_KEEPASPECT = 2 // 2: adjust and keep aspect ratio
    };
}
