using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using DataModel.Data;

namespace DockerEngineApiAgent
{
    public class ApiAgent
    {
        private DockerSettings _settings;
        public ApiAgent(DockerSettings settings)
        {
            this._settings = settings;
        }

        public string GetResponse(string resourceName)
        {
            HttpWebRequest request = WebRequest.Create(_settings.ApiEndpoint + resourceName) as HttpWebRequest;
            request.Method = "GET";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }
    }
}
