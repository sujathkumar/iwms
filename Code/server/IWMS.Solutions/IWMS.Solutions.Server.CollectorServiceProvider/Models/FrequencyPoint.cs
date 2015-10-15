using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWMS.Solutions.Server.CollectorServiceProvider.Models
{
    public class FrequencyPoint
    {
        public int PickupFrequency { get; set; }

        public int FrequencyType { get; set; }

        public int Capacity { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public DateTime SlotFrom { get; set; }

        public DateTime SlotTo { get; set; }
    }
}
