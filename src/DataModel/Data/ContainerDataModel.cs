using Newtonsoft.Json;

namespace DataModel.Data
{
    public partial class ContainerDataModel
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Names")]
        public string[] Names { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("ImageID")]
        public string ImageId { get; set; }

        [JsonProperty("Command")]
        public string Command { get; set; }

        [JsonProperty("Created")]
        public long Created { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Ports")]
        public Port[] Ports { get; set; }

        [JsonProperty("Labels")]
        public Labels Labels { get; set; }

        [JsonProperty("SizeRw")]
        public long SizeRw { get; set; }

        [JsonProperty("SizeRootFs")]
        public long SizeRootFs { get; set; }

        [JsonProperty("HostConfig")]
        public HostConfig HostConfig { get; set; }

        [JsonProperty("NetworkSettings")]
        public NetworkSettings NetworkSettings { get; set; }

        [JsonProperty("Mounts")]
        public Mount[] Mounts { get; set; }
    }

    public partial class HostConfig
    {
        [JsonProperty("NetworkMode")]
        public string NetworkMode { get; set; }
    }

    public partial class Labels
    {
        [JsonProperty("com.example.vendor", NullValueHandling = NullValueHandling.Ignore)]
        public string ComExampleVendor { get; set; }

        [JsonProperty("com.example.license", NullValueHandling = NullValueHandling.Ignore)]
        public string ComExampleLicense { get; set; }

        [JsonProperty("com.example.version", NullValueHandling = NullValueHandling.Ignore)]
        public string ComExampleVersion { get; set; }
    }

    public partial class Mount
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Destination")]
        public string Destination { get; set; }

        [JsonProperty("Driver")]
        public string Driver { get; set; }

        [JsonProperty("Mode")]
        public string Mode { get; set; }

        [JsonProperty("RW")]
        public bool Rw { get; set; }

        [JsonProperty("Propagation")]
        public string Propagation { get; set; }
    }

    public partial class NetworkSettings
    {
        [JsonProperty("Networks")]
        public Networks Networks { get; set; }
    }

    public partial class Networks
    {
        [JsonProperty("bridge")]
        public Bridge Bridge { get; set; }
    }

    public partial class Bridge
    {
        [JsonProperty("IPAMConfig")]
        public object IpamConfig { get; set; }

        [JsonProperty("Links")]
        public object Links { get; set; }

        [JsonProperty("Aliases")]
        public object Aliases { get; set; }

        [JsonProperty("NetworkID")]
        public string NetworkId { get; set; }

        [JsonProperty("EndpointID")]
        public string EndpointId { get; set; }

        [JsonProperty("Gateway")]
        public string Gateway { get; set; }

        [JsonProperty("IPAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("IPPrefixLen")]
        public long IpPrefixLen { get; set; }

        [JsonProperty("IPv6Gateway")]
        public string IPv6Gateway { get; set; }

        [JsonProperty("GlobalIPv6Address")]
        public string GlobalIPv6Address { get; set; }

        [JsonProperty("GlobalIPv6PrefixLen")]
        public long GlobalIPv6PrefixLen { get; set; }

        [JsonProperty("MacAddress")]
        public string MacAddress { get; set; }
    }

    public partial class Port
    {
        [JsonProperty("PrivatePort")]
        public long PrivatePort { get; set; }

        [JsonProperty("PublicPort")]
        public long PublicPort { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }
    }
}
