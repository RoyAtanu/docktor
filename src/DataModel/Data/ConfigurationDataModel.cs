using System;
using Newtonsoft.Json;

namespace DataModel.Data
{
    public partial class ConfigurationDataModel
    {
        [JsonProperty("DockerSettings")]
        public DockerSettings DockerSettings { get; set; }

        [JsonProperty("InfluxDBSettings")]
        public InfluxDbSettings InfluxDbSettings { get; set; }
    }

    public partial class DockerSettings
    {
        [JsonProperty("ApiEndpoint")]
        public Uri ApiEndpoint { get; set; }
    }

    public partial class InfluxDbSettings
    {
        [JsonProperty("InfluxURL")]
        public Uri InfluxUrl { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("DBName")]
        public string DbName { get; set; }

        [JsonProperty("MeasurementName")]
        public string MeasurementName { get; set; }
    }
}
