using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Data
{
    public static class UriResourceName
    {
        public static string GetContainerStatsResourceName(string containerName)
        {
            return "/containers/" + containerName + "/stats?stream=0";
        }

        public static string ListContainersResourceName()
        {
            return "/containers/json";
        }
    }
}
