using System.Threading.Tasks;
using AdysTech.InfluxDB.Client.Net;
using DataModel.Converter;
using DataModel.Data;
using BinaryConverter = DataModel.Converter.BinaryConverter;

namespace InfluxDBConnector
{
    // The code snippets in this class were taken from here -
    // https://github.com/AdysTech/InfluxDB.Client.Net
    public class DbConnector
    {
        private readonly InfluxDBClient _dbClient;

        public DbConnector()
        {
            this._dbClient = new InfluxDBClient(Configuration.influxUrl,
                Configuration.dbUsername,
                Configuration.dbPassword);
        }

        public async Task AddDataPoint(DockerStatDataModel model)
        {
            var valMixed = new InfluxDatapoint<InfluxValueField>();
            valMixed.UtcTimestamp = model.Read.UtcDateTime;
            valMixed.Tags.Add("ContainerId", model.Id);
            valMixed.Tags.Add("ContainerName", model.Name);
            valMixed.Fields.Add("CpuPercent", new InfluxValueField(CpuCycleConverter.CalculateCPUPercentWindows(model)));
            valMixed.Fields.Add("MemoryUsage", new InfluxValueField(BinaryConverter.ConvertBytesToMegabytes(model.MemoryStats.Privateworkingset)));
            valMixed.Fields.Add("DiskInput", new InfluxValueField(BinaryConverter.ConvertBytesToMegabytes(model.StorageStats.WriteSizeBytes)));
            valMixed.Fields.Add("DiskOutput", new InfluxValueField(BinaryConverter.ConvertBytesToMegabytes(model.StorageStats.ReadSizeBytes)));

            valMixed.MeasurementName = Configuration.measurementName;
            valMixed.Precision = TimePrecision.Seconds;

            var r = await _dbClient.PostPointAsync(Configuration.dbName, valMixed);
        }
    }
}
