using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IWMS.Solutions.Server.RecyclerServiceProvider.Models;
using RecyclerService = IWMS.Solutions.Server.RecyclerServiceProvider;

namespace ManagementService.Controllers
{
    public class RecyclerController : ApiController
    {
        public string GetRecycler(string key)
        {
            var values = key.Split('|');

            if (values.Length > 0)
            {
                RecyclerService.Provider provider = new RecyclerService.Provider();

                string method = values[0].ToLower();

                if (method == "authenticate")
                {
                    string mobile = values[1];
                    string password = values[2];
                    return provider.RetrieveRecycler(mobile, password).ToString();
                }
                else if (method == "si")
                {
                    string recyclerId = values[1];
                    string scanInfo = values[2];
                    return provider.InserRecyclerScan(recyclerId, scanInfo).ToString();
                }
                else if (method == "su")
                {
                    string data = values[1];
                    string usersCount = values[2];
                    return provider.InsertUsersCount(data, usersCount).ToString();
                }
            }

            return "Error, Not Found!";
        }
    }
}
