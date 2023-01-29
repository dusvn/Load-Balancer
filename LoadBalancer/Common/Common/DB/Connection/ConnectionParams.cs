using System.Diagnostics.CodeAnalysis;

namespace LoadBalancer.DB.Connection
{
    [ExcludeFromCodeCoverage]
    public class ConnectionParams
    {
        public static readonly string LOCAL_DATA_SOURCE = "//localhost:1521/xe";
        public static readonly string USER_ID = "ludja";
        public static readonly string PASSWORD = "ftn";
    }
}
