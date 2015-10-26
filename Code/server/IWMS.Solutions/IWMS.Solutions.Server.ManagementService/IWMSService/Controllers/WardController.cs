using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using IWMS.Solutions.Server.WardDataProvider;
using IWMS.Solutions.Server.WardDataProvider.Models;
using WardData = IWMS.Solutions.Server.WardDataProvider;

namespace ManagementService.Controllers
{
    public class WardController : ApiController
    {
        /// <summary>
        /// GetWard based on latitude and longitude
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public string GetWard(string key1, string key2)
        {
            WardData.Provider rdr = new WardData.Provider();
            string ward = rdr.RetrieveWard(key1.Replace('_', '.'), key2.Replace('_', '.'));

            if (string.IsNullOrEmpty(ward))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return ward;
        }

        /// <summary>
        /// GetWard based on locality
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetWard(string key)
        {
            var values = key.Split('|');

            if (values.Length > 0)
            {
                WardData.Provider rdr = new WardData.Provider();
                string method = values[0].ToLower();

                if (method == "zones")
                {
                    string zones = rdr.RetrieveZones();

                    if (string.IsNullOrEmpty(zones))
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }

                    return zones;
                }
                else if (method == "wards")
                {
                    string data = values[1];
                    string wards = rdr.RetrieveWards(data);

                    if (string.IsNullOrEmpty(wards))
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }

                    return wards;
                }
                else if (method == "ward")
                {
                    string data = values[1];
                    string ward = rdr.RetrieveWard(data);

                    if (string.IsNullOrEmpty(ward))
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }

                    return ward;
                }
                else if(method == "locality")
                {
                    string data = values[1];
                    var localities = rdr.RetrieveLocalities(data);
                    StringBuilder localityList = new StringBuilder();

                    foreach (var locality in localities)
                    {
                        localityList.Append(locality.Name + ",");
                    }

                    if (localities == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }

                    return localityList.ToString();
                }                
            }

            return "100";
        }
    }
}
