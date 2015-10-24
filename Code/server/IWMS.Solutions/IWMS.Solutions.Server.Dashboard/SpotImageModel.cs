using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWMS.Solutions.Server.Dashboard
{
    public class SpotImageModel
    {
        public string Ward { get; set; }

        public string ImagePath { get; set; }

        public DateTime UploadedTime { get; set; }

        public bool Verified { get; set; }
    }
}
