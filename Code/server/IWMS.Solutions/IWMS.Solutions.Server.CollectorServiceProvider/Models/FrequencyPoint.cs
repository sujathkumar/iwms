﻿using System;
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

        public string SlotFrom1 { get; set; }

        public string SlotTo1 { get; set; }

        public string SlotFrom2 { get; set; }

        public string SlotTo2 { get; set; }

        public string SlotFrom3 { get; set; }

        public string SlotTo3 { get; set; }
    }
}
