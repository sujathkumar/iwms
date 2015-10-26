using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PointService = IWMS.Solutions.Server.PointServiceProvider;

namespace ManagementService.Controllers
{
    public class PointController : ApiController
    {
        public string GetPoint(string key)
        {
            var values = key.Split('|');

            if (values.Length > 0)
            {
                PointService.Provider provider = new PointService.Provider();

                string method = values[0].ToLower();

                if (method == "rp")
                {
                    string data = values[1];
                    return provider.RetrievePoints(data).ToString();
                }
            }

            return "Error, Not Found!";
        }
    }
}
