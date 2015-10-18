using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using CollectorService = IWMS.Solutions.Server.CollectorServiceProvider;

namespace IWMS.Solutions.Server.HealthService
{
    public partial class HealthService : ServiceBase
    {
        CollectorService.Provider provider = null;

        public HealthService()
        {
            InitializeComponent();

            eventLogHealthService = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("IWMS"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "IWMS", "IWMSLog");
            }
            eventLogHealthService.Source = "IWMS";
            eventLogHealthService.Log = "IWMSLog";            
        }

        protected override void OnStart(string[] args)
        {
            eventLogHealthService.WriteEntry("Starting IWMS Health Service.");

            // Set up a timer to trigger every minute.
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 360000; // 60 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        /// <summary>
        /// OnTimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            eventLogHealthService.WriteEntry("Monitoring the System", EventLogEntryType.Information);

            provider = new CollectorService.Provider();
            provider.UpdateLastCollectionTime();

        }

        protected override void OnStop()
        {
            eventLogHealthService.WriteEntry("Stopping IWMS Health Service.");
        }
    }
}
