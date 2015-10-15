using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWMS.Solutions.Server.CollectorServiceProvider.Interfaces
{
    public interface IEntity
    {
        string DisplayName { get; set; }

        string Tag { get; set; }
    }
}
