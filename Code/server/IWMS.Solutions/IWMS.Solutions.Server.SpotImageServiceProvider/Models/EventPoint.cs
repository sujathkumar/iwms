using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWMS.Solutions.Server.SpotImage.Models
{
    public class EventPoint
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Ward { get; set; }

        public string Address { get; set; }

        public string ImagePath { get; set; }
    }
}
