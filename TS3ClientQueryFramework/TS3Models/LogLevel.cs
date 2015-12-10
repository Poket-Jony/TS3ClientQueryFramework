namespace TS3ClientQueryFramework.TS3Models
{
    public enum LogLevel
    {
        LogLevel_ERROR = 1, // 1: everything that is really bad
        LogLevel_WARNING = 2, // 2: everything that might be bad
        LogLevel_DEBUG = 3, // 3: output that might help find a problem
        LogLevel_INFO = 4 // 4: informational output
    };
}
