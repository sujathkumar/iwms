using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ManagementService.Models;
using SpotImageService = IWMS.Solutions.Server.SpotImageServiceProvider;

namespace ManagementService.Controllers
{
    public class SpotImageController : ApiController
    {
        public string GetSpotImage(string key)
        {
            var values = key.Split('|');

            if (values.Length > 0)
            {
                SpotImageService.Provider provider = new SpotImageService.Provider();

                string method = values[0].ToLower();

                if (method == "is")
                {
                    string data = values[1];
                    string latitude = values[2].Replace("_",".");
                    string longitude = values[3].Replace("_", ".");
                    string imageData = values[4].Replace("c_olon", ":").Replace("s_la", "\\").Replace("_",".");
                    return provider.InsertSpotImage(data, latitude, longitude, imageData).ToString();
                }
                else if (method == "pi")
                {
                    provider.PostSpotImageProcess();
                    return "Updated Successfully!";
                }
            }

            return "Error, Not Found!";
        }

        public string Post([FromBody]Image data)
        {
            string image = data.ImagePath;
            string byteArray = data.ImageData;
            SpotImageService.Provider provider = new SpotImageService.Provider();
            return provider.PostImage(image, byteArray).ToString();
        }
    }
}
