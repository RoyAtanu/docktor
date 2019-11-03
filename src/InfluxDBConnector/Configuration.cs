namespace InfluxDBConnector
{
    static class Configuration
    {
        internal static string influxUrl => "http://localhost:8086";

        internal static string dbUsername => "admin";

        internal static string dbPassword => "";

        internal static string dbName => "dockerdata";

        internal static string measurementName => "ContainerStats";

    }
}
