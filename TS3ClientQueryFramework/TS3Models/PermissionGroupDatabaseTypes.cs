namespace TS3ClientQueryFramework.TS3Models
{
    public enum PermissionGroupDatabaseTypes
    {
        PermGroupDBTypeTemplate = 0, // 0: template group (used for new virtual servers)
        PermGroupDBTypeRegular = 1, // 1: regular group (used for regular clients)
        PermGroupDBTypeQuery = 2 // 2: global query group (used for ServerQuery clients)
    };
}
