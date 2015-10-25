using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWMS.Solutions.Server.BinServiceProvider.Models
{
    public class GarbagePoint
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Tag { get; set; }

        public string GarbageType { get; set; }

        public DateTime GeneratedDate { get; set; }
    }
}
