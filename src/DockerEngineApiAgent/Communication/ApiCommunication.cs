using System.IO;
using System.Net;

namespace DockerEngineApiAgent.Communication
{
    public static class ApiCommunication
    {
        public static string GetResponse(string resourceName)
        {
            HttpWebRequest request = WebRequest.Create(Configuration.ApiEndpoint + resourceName) as HttpWebRequest;
            request.Method = "GET";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }
    }
}
