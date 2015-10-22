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
                else if (method == "sp")
                {
                    string data = values[1];
                    string garbageType = values[2];
                    int quantity = Convert.ToInt32(values[3]);
                    bool donateGarbage = Convert.ToBoolean(values[4]);

                    string scheduleTime = "";
                    if (values.Length > 5 && values[5] != null)
                    {
                        scheduleTime = values[5];
                    }

                    return provider.SchedulePickup(data, garbageType, quantity, donateGarbage, scheduleTime);
                }
                else if (method == "rcd")
                {
                    string data = values[1];
                    return provider.RetrieveCollectorDates(data);
                }
                else if (method == "rct")
                {
                    string data = values[1];
                    return provider.RetrieveCollectorTimes(data);
                }
                else if (method == "rr")
                {
                    string requestNumber = values[1];
                    return provider.RetrieveRequest(requestNumber);
                }
            }

            return "Error, Not Found!";
        }

        public IList<string> GetCollector(string key1, string key2)
        {
            CollectorService.Provider provider = new CollectorService.Provider();
            Guid collectorId = Guid.Parse(key1);
            string mobile = key2;

            return provider.RetrieveRequest(collectorId);
        }
    }
}
