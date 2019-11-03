using System;
using Newtonsoft.Json;

namespace DataModel.Data
{
    public partial class DockerStatDataModel
    {
        [JsonProperty("read")]
        public DateTimeOffset Read { get; set; }

        [JsonProperty("preread")]
        public DateTimeOffset Preread { get; set; }

        [JsonProperty("pids_stats")]
        public PidsStats PidsStats { get; set; }

        [JsonProperty("blkio_stats")]
        public BlkioStats BlkioStats { get; set; }

        [JsonProperty("num_procs")]
        public long NumProcs { get; set; }

        [JsonProperty("storage_stats")]
        public StorageStats StorageStats { get; set; }

        [JsonProperty("cpu_stats")]
        public CpuStats CpuStats { get; set; }

        [JsonProperty("precpu_stats")]
        public CpuStats PrecpuStats { get; set; }

        [JsonProperty("memory_stats")]
        public MemoryStats MemoryStats { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("networks")]
        public Networks Networks { get; set; }
    }

    public partial class BlkioStats
    {
        [JsonProperty("io_service_bytes_recursive")]
        public object IoServiceBytesRecursive { get; set; }

        [JsonProperty("io_serviced_recursive")]
        public object IoServicedRecursive { get; set; }

        [JsonProperty("io_queue_recursive")]
        public object IoQueueRecursive { get; set; }

        [JsonProperty("io_service_time_recursive")]
        public object IoServiceTimeRecursive { get; set; }

        [JsonProperty("io_wait_time_recursive")]
        public object IoWaitTimeRecursive { get; set; }

        [JsonProperty("io_merged_recursive")]
        public object IoMergedRecursive { get; set; }

        [JsonProperty("io_time_recursive")]
        public object IoTimeRecursive { get; set; }

        [JsonProperty("sectors_recursive")]
        public object SectorsRecursive { get; set; }
    }

    public partial class CpuStats
    {
        [JsonProperty("cpu_usage")]
        public CpuUsage CpuUsage { get; set; }

        [JsonProperty("throttling_data")]
        public ThrottlingData ThrottlingData { get; set; }
    }

    public partial class CpuUsage
    {
        [JsonProperty("total_usage")]
        public long TotalUsage { get; set; }

        [JsonProperty("usage_in_kernelmode")]
        public long UsageInKernelmode { get; set; }

        [JsonProperty("usage_in_usermode")]
        public long UsageInUsermode { get; set; }
    }

    public partial class ThrottlingData
    {
        [JsonProperty("periods")]
        public long Periods { get; set; }

        [JsonProperty("throttled_periods")]
        public long ThrottledPeriods { get; set; }

        [JsonProperty("throttled_time")]
        public long ThrottledTime { get; set; }
    }

    public partial class MemoryStats
    {
        [JsonProperty("commitbytes")]
        public long Commitbytes { get; set; }

        [JsonProperty("commitpeakbytes")]
        public long Commitpeakbytes { get; set; }

        [JsonProperty("privateworkingset")]
        public long Privateworkingset { get; set; }
    }

    public partial class Networks
    {
        [JsonProperty("bdc870fe-8ad4-49c8-9dca-52b48b1df875")]
        public Bdc870Fe8Ad449C89Dca52B48B1Df875 Bdc870Fe8Ad449C89Dca52B48B1Df875 { get; set; }
    }

    public partial class Bdc870Fe8Ad449C89Dca52B48B1Df875
    {
        [JsonProperty("rx_bytes")]
        public long RxBytes { get; set; }

        [JsonProperty("rx_packets")]
        public long RxPackets { get; set; }

        [JsonProperty("rx_errors")]
        public long RxErrors { get; set; }

        [JsonProperty("rx_dropped")]
        public long RxDropped { get; set; }

        [JsonProperty("tx_bytes")]
        public long TxBytes { get; set; }

        [JsonProperty("tx_packets")]
        public long TxPackets { get; set; }

        [JsonProperty("tx_errors")]
        public long TxErrors { get; set; }

        [JsonProperty("tx_dropped")]
        public long TxDropped { get; set; }
    }

    public partial class PidsStats
    {
    }

    public partial class StorageStats
    {
        [JsonProperty("read_count_normalized")]
        public long ReadCountNormalized { get; set; }

        [JsonProperty("read_size_bytes")]
        public long ReadSizeBytes { get; set; }

        [JsonProperty("write_count_normalized")]
        public long WriteCountNormalized { get; set; }

        [JsonProperty("write_size_bytes")]
        public long WriteSizeBytes { get; set; }
    }
}
