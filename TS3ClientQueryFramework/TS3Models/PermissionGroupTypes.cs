namespace TS3ClientQueryFramework.TS3Models
{
    public enum PermissionGroupTypes
    {
        PermGroupTypeServerGroup = 0, // 0: server group permission
        PermGroupTypeGlobalClient = 1, // 1: client specific permission
        PermGroupTypeChannel = 2, // 2: channel specific permission
        PermGroupTypeChannelGroup = 3, // 3: channel group permission
        PermGroupTypeChannelClient = 4 // 4: channel-client specific permission
    };
}
