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

            // Set up a timer to trigger every day.
            System.Timers.Timer timerDay = new System.Timers.Timer();
            timerDay.Interval = 1000 * 60; //One hour
            timerDay.Elapsed += new System.Timers.ElapsedEventHandler(this.MinuteTimer);
            timerDay.Start();

            // Set up a timer to trigger every week.
            System.Timers.Timer timerWeek = new System.Timers.Timer();
            timerWeek.Interval = 1000 * 60 * 60 * 24 * 7; //One hour
            timerWeek.Elapsed += new System.Timers.ElapsedEventHandler(this.WeeklyTimer);
            timerWeek.Start();
        }

        /// <summary>
        /// OnDailyTimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void MinuteTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            eventLogHealthService.WriteEntry("Monitoring the Daily System", EventLogEntryType.Information);

            Consumer consumer = new Consumer();
            consumer.StartMinuteActivity();

        }

        /// <summary>
        /// OnTimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void WeeklyTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            eventLogHealthService.WriteEntry("Monitoring the Weekly System", EventLogEntryType.Information);

            Consumer consumer = new Consumer();
            consumer.StartWeeklyActivity();

        }

        protected override void OnStop()
        {
            eventLogHealthService.WriteEntry("Stopping IWMS Health Service.");
        }
    }
}
