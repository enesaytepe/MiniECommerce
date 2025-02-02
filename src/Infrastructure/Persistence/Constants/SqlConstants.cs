namespace Persistence.Constants;

public static class SqlConstants
{
    public const string CurrentUserDefault = "CURRENT_USER"; /* SqlServer, PostGres */

    //public const string CurrentUTCTimeStamp = "GETUTCDATE()"; /* SqlServer */

    public const string CurrentUTCTimeStamp = "timezone('utc', now())"; /* PostGres */
}