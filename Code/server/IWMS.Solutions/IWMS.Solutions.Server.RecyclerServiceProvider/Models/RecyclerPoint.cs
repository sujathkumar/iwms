using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWMS.Solutions.Server.RecyclerServiceProvider
{
    public class RecyclerPoint
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public string Ward { get; set; }
    }
}
