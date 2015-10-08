using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Auth = IWMS.Solutions.Server.AuthProvider;

namespace ManagementService.Controllers
{
    public class LocationController : ApiController
    {
        public IList<Auth.CityPoint> GetLocation()
        {
            Auth.Provider provider = new Auth.Provider();
            return provider.RetrieveCityDetails().Select(@s=>@s).ToList();            
        }
    }
}
