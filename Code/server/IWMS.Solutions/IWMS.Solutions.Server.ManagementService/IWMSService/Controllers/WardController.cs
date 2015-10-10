using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WardData = IWMS.Solutions.Server.WardDataProvider;

namespace ManagementService.Controllers
{
    public class WardController : ApiController
    {
        public string GetWard(string latitude, string longitude)
        {
            WardData.Provider rdr = new WardData.Provider();
            string ward = rdr.RetrieveWard(latitude.Replace('_', '.'), longitude.Replace('_', '.'));

            if (string.IsNullOrEmpty(ward))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return ward;
        }

        public string GetWard(string key)
        {
            WardData.Provider rdr = new WardData.Provider();
            string ward = rdr.RetrieveWard(key);

            if (string.IsNullOrEmpty(ward))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return ward;
        }
    }
}
