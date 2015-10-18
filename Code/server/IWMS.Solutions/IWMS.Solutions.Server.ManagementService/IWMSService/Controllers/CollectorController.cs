using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IWMS.Solutions.Server.CollectorServiceProvider.Models;
using CollectorService = IWMS.Solutions.Server.CollectorServiceProvider;

namespace ManagementService.Controllers
{
    public class CollectorController : ApiController
    {
        public string GetCollector(string key)
        {
            var values = key.Split('|');

            if (values.Length > 0)
            {
                CollectorService.Provider provider = new CollectorService.Provider();

                string method = values[0].ToLower();

                if (method == "authenticate")
                {
                    string mobile = values[1];
                    string password = values[2];
                    return provider.RetrieveCollector(mobile, password).ToString();
                }

            }

            return "Error, Not Found!";
        }

        public IList<RequestPoint> GetCollector(string key1, string key2)
        {
            CollectorService.Provider provider = new CollectorService.Provider();
            Guid collectorId = Guid.Parse(key1);
            string mobile = key2;

            return provider.RetrieveRequest(collectorId);
        }
    }
}
