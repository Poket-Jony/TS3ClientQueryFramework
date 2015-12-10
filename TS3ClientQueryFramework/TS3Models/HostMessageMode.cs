namespace TS3ClientQueryFramework.TS3Models
{
    public enum HostMessageMode
    {
        HostMessageMode_LOG = 1, // 1: display message in chatlog
        HostMessageMode_MODAL = 2, // 2: display message in modal dialog
        HostMessageMode_MODALQUIT = 3 // 3: display message in modal dialog and close connection
    };
}
