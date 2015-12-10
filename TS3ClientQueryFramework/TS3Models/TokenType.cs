namespace TS3ClientQueryFramework.TS3Models
{
    public enum TokenType
    {
        TokenServerGroup = 0, // 0: server group token (id1={groupID} id2=0)
        TokenChannelGroup = 1 // 1: channel group token (id1={groupID} id2={channelID})
    };
}
