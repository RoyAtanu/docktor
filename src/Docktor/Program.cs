using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using DataModel.Data;
using DockerEngineApiAgent.Communication;
using InfluxDBConnector;
using Newtonsoft.Json;

namespace Docktor
{
    class Program
    {
        static void Main(string[] args)
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

        private static void timer_Tick(object sender, EventArgs e)
        {
            string containerInfo = ApiCommunication.GetResponse(UriResourceName.ListContainersResourceName());
            List<ContainerDataModel> containers = JsonConvert.DeserializeObject<List<ContainerDataModel>>(containerInfo);

            foreach (var item in containers)
            {
                SaveStatDataToDb(item.Id);
            }
        }

        private static void SaveStatDataToDb(string containerId)
        {
            DbConnector connector = new DbConnector();
            string response = ApiCommunication.GetResponse(UriResourceName.GetContainerStatsResourceName(containerId));

            DockerStatDataModel model = JsonConvert.DeserializeObject<DockerStatDataModel>(response);
            Task.Run(() => connector.AddDataPoint(model)).Wait();
        }
    }
}
