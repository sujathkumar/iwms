using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWMS.Solutions.Server.CollectorServiceProvider.Models
{
    public class RequestPoint
    {
        public string RequestNumber { get; set; }

        public string GarbageType { get; set; }

        public DateTime RequestTime { get; set; }

        public DateTime ScheduleTime { get; set; }

        public string Tag { get; set; }

        public string UserName { get; set; }

        public string UserAddress { get; set; }
    }
}
