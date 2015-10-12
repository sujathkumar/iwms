using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWMS.Solutions.Server.WardDataProvider.Interfaces;

namespace IWMS.Solutions.Server.WardDataProvider
{
    public class LocalityPoint : IEntity
    {
        public int WardNumber { get; set; }
        public int SubWardNumber { get; set; }

        public string DisplayName { get; set; }

        public string Tag
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
