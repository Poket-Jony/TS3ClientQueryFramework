namespace TS3ClientQueryFramework.TS3Models
{
    public enum ReasonIdentifier
    {
        REASON_SWITCH_CHANNEL_OR_JOIN_SERVER = 0,
        REASON_USER_OR_CHANNEL_MOVED = 1,
        REASON_TIMEOUT = 3,
        REASON_KICK_CHANNEL = 4, // 4: kick client from channel
        REASON_KICK_SERVER = 5, // 5: kick client from server
        REASON_BAN = 6,
        REASON_LEAVE_SERVER = 8,
        REASON_EDIT_CHANNEL_OR_SERVER = 10,
        REASON_SERVER_SHUTDOWN = 11
    };
}
