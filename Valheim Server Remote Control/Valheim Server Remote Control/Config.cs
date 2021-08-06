using Amazon;

namespace Valheim_Server_Remote_Control
{
    public static class Config
    {
        public static string ServerAddress = "<SERVER IP / HOSTNAME>";
        public static RegionEndpoint AWSRegionEndpoint = RegionEndpoint.EUCentral1;
        public static string AWSInstanceId = "<AWS INSTANCE ID>";
        public static string AWSAccessKeyId = "<AWS ACCESS KEY ID>";
        public static string AWSSecretAccessKey = "<AWS SECRET ACCESS KEY>";
    }
}
