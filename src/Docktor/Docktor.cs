using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using DataModel.Configuration;
using DataModel.Data;
using DockerEngineApiAgent;
using InfluxDBConnector;
using Newtonsoft.Json;

namespace Docktor
{
    public class Docktor
    {
        private Configuration _config;
        private ApiAgent _agent;
        private DbConnector _dbConnector;

        public Docktor(Configuration config)
        {
            this._config = config;
            _agent = new ApiAgent(_config.ConfigurationData.DockerSettings);
            _dbConnector = new DbConnector(_config.ConfigurationData.InfluxDbSettings);
        }

        public void Run()
        {
            try
            {
                Timer timer = new Timer();
                timer.Interval = 1000;
                timer.Elapsed += timer_Tick;

                Console.WriteLine("Started writing data to influxDB");
                timer.Start();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string containerInfo = _agent.GetResponse(UriResourceName.ListContainersResourceName());
            List<ContainerDataModel> containers = JsonConvert.DeserializeObject<List<ContainerDataModel>>(containerInfo);

            foreach (var item in containers)
            {
                SaveStatDataToDb(item.Id);
            }
        }

        private void SaveStatDataToDb(string containerId)
        {
            string response = _agent.GetResponse(UriResourceName.GetContainerStatsResourceName(containerId));

            DockerStatDataModel model = JsonConvert.DeserializeObject<DockerStatDataModel>(response);
            Task.Run(() => _dbConnector.AddDataPoint(model)).Wait();
        }
    }
}
