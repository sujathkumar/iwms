using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace IWMS.Solutions.Server.HealthService
{
    public partial class HealthService : ServiceBase
    {
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
            timer.Interval = 60000; //One hour
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

            Consumer consumer = new Consumer();
            consumer.StartActivity();

        }

        protected override void OnStop()
        {
            eventLogHealthService.WriteEntry("Stopping IWMS Health Service.");
        }
    }
}
