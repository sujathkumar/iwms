using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VolunteerService = IWMS.Solutions.Server.VolunteerServiceProvider;

namespace ManagementService.Controllers
{
    public class VolunteerController : ApiController
    {
        public string GetVolunteer(string key)
        {
            var values = key.Split('|');

            if (values.Length > 0)
            {
                VolunteerService.Provider provider = new VolunteerService.Provider();

                string method = values[0].ToLower();

                if (method == "iv")
                {
                    string data = values[1];
                    string ward = values[2];
                    return provider.InsertVolunteer(data, ward).ToString();
                }
                else if(method == "rgcmtoken")
                {
                    string data = values[1];
                    return provider.RetrieveGCMToken(data).ToString();
                }
                else if (method == "it")
                {
                    provider.InsertTopics();
                    return "success";
                }
                else if(method == "rvs")
                {
                    string data = values[1];
                    return provider.RetrieveVolunteerSubscription(data);
                }
                else if (method == "ie")
                {
                    string data = values[1];
                    string eventId = values[2];
                    return provider.InsertEventVolunteerMap(data, eventId).ToString();
                }
                else if (method == "rve")
                {
                    string data = values[1];
                    return provider.RetrieveVolunteerEvents(data);
                }
                else if (method == "rvu")
                {
                    string data = values[1];
                    return provider.RetrieveVolunteerUsersList(data);
                }
            }

            return "Error, Not Found!";
        }
    }
}
