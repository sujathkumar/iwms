using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BinService = IWMS.Solutions.Server.BinServiceProvider;

namespace ManagementService.Controllers
{
    public class HouseholdController : ApiController
    {
        public string GetHousehold(string key)
        {
            var values = key.Split('|');

            if (values.Length > 0)
            {
                BinService.Provider provider = new BinService.Provider();

                string method = values[0].ToLower();

                if (method == "authenticate")
                {
                    string data = values[1];
                    return provider.RetrieveHHUserInfo(data).ToString();
                }
                else if (method == "ia")
                {
                    string data = values[1];
                    string address = values[2].Replace("s_pace"," ").Replace("c_omma",",");
                    string[] seperator = new string[] { "___" };
                    return provider.InsertAddress(data, address.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[0].ToString(),
                        address.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[1].ToString(),
                        address.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[2].ToString(),
                        address.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[3].ToString(),
                        address.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[4].ToString(),
                        address.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[5].ToString(),
                        Convert.ToBoolean(address.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[6]),
                        Convert.ToInt32(address.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[7])).ToString();
                }
                else if (method == "ib")
                {
                    string data = values[1];
                    string status = values[2];
                    return provider.InsertBin(data, status).ToString();
                }
                else if (method == "rgt")
                {
                    string data = values[1];
                    return provider.RetrieveGarbageTag(data).ToString();
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }

            return "Error, Not Found!";
        }
    }
}
