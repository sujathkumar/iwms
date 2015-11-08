using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectorService = IWMS.Solutions.Server.CollectorServiceProvider;
using SpotImageService = IWMS.Solutions.Server.SpotImageServiceProvider;
using RecyclerService = IWMS.Solutions.Server.RecyclerServiceProvider;

namespace IWMS.Solutions.Server.HealthService
{
    public class Consumer
    {
        CollectorService.Provider collectorProvider = null;
        SpotImageService.Provider spotImageProvider = null;
        RecyclerService.Provider recyclerProvider = null;

        public void StartMinuteActivity()
        {
            collectorProvider = new CollectorService.Provider();
            collectorProvider.UpdateLastCollectionTime();

            spotImageProvider = new SpotImageService.Provider();
            spotImageProvider.PostSpotImageProcess();

            recyclerProvider = new RecyclerService.Provider();
            recyclerProvider.ProcessNonComplaintUsers();            
        }

        public void StartWeeklyActivity()
        {
            recyclerProvider = new RecyclerService.Provider();
            recyclerProvider.SendNonComplaintUserNotification();      
        }
    }
}
