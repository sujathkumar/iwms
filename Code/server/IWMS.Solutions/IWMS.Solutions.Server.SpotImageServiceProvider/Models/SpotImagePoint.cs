using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWMS.Solutions.Server.SpotImage.Models
{
    public class SpotImagePoint
    {
        public Guid Id { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string UserName { get; set; }

        public string WardName { get; set; }

        public string UserAddress { get; set; }

        public bool Verified { get; set; }

        public string ImagePath { get; set; }

        public DateTime UploadedTime { get; set; }       
    }
}
