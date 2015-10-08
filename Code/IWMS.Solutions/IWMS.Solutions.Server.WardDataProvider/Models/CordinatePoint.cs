using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWMS.Solutions.Server.WardDataProvider.Interfaces;

namespace IWMS.Solutions.Server.WardDataProvider
{
    public class CordinatePoint : IEntity
    {
        private const string ZeroCordinate = "0";
        public CordinatePoint()
        {
            Latitude = ZeroCordinate;
            Longitude = ZeroCordinate;
        }

        public int Rank { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string DisplayName
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
