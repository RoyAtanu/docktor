using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataModel.Data;
using Newtonsoft.Json;

namespace DataModel.Configuration
{
    public class Configuration
    {
        private ConfigurationDataModel _config;
        private string _defaultPath = @"\Configuration\configuration.json";

        public ConfigurationDataModel ConfigurationData => _config;

        public Configuration()
        {
            Load(_defaultPath);
        }

        public Configuration(string filePath)
        {
            Load(filePath);
        }

        public void Load(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            _config = JsonConvert.DeserializeObject<ConfigurationDataModel>(jsonData);
        }
    }
}
