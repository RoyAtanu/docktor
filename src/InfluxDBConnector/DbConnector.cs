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
        private InfluxDbSettings _settings;

        public DbConnector(InfluxDbSettings settings)
        {
            this._settings = settings;
            this._dbClient = new InfluxDBClient(settings.InfluxUrl.ToString(),
                settings.UserName,
                settings.Password);
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

            valMixed.MeasurementName = _settings.MeasurementName;
            valMixed.Precision = TimePrecision.Seconds;

            var r = await _dbClient.PostPointAsync(_settings.DbName, valMixed);
        }
    }
}
