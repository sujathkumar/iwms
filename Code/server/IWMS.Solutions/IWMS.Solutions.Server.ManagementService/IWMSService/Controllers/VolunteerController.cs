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
        public string GetSpotImage(string key)
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
            }

            return "Error, Not Found!";
        }
    }
}
