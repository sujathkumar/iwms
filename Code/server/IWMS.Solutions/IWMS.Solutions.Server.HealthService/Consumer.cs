using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectorService = IWMS.Solutions.Server.CollectorServiceProvider;
using SpotImageService = IWMS.Solutions.Server.SpotImageServiceProvider;

namespace IWMS.Solutions.Server.HealthService
{
    public class Consumer
    {
        CollectorService.Provider collectorProvider = null;
        SpotImageService.Provider spotImageProvider = null;

        public void StartActivity()
        {
            collectorProvider = new CollectorService.Provider();
            collectorProvider.UpdateLastCollectionTime();

            spotImageProvider = new SpotImageService.Provider();
            spotImageProvider.PostSpotImageProcess();
        }
    }
}
