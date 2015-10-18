using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWMS.Solutions.Server.Dashboard
{
    public class CollectorModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public string Ward { get; set; }

        public int PickupFrequency { get; set; }

        public int FrequencyType { get; set; }

        public string SlotFrom1 { get; set; }

        public string SlotTo1 { get; set; }

        public string SlotFrom2 { get; set; }

        public string SlotTo2 { get; set; }

        public string SlotFrom3 { get; set; }

        public string SlotTo3 { get; set; }

        public int Capacity { get; set; }
        
        public DateTime LastUpdateDate { get; set; }
    }
}
