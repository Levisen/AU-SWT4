using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Threading;
using System.Timers;

namespace AirTrafficMonitor
{
    public class EnterExitEventController : IEnterExitEventController
    {
        IEnterExitEventDetector _detector;
        List<EnterExitEvent> ActiveEvents;
        List<EnterExitEvent> InctiveEvents;

        public int ScheduledDeactivationsCount { get; set; }


        public event EventHandler<EnterExitEventsUpdatedEventArgs> EnterExitEventsUpdated;

        public EnterExitEventController(IEnterExitEventDetector detector)
        {
            _detector = detector;
            _detector.EnterExitEventDetected += OnEnterExitEventDetected;
            ActiveEvents = new List<EnterExitEvent>();
            InctiveEvents = new List<EnterExitEvent>();

            ScheduledDeactivationsCount = 0;
        }

        private void OnEnterExitEventDetected(object sender, EnterExitEventDetectedArgs e)
        {
            var detectedEvent = e.Event;
            ActiveEvents.Add(detectedEvent);
            var timer = new Timer(5000)
            {
                AutoReset = false,
                Enabled = true
            };
            timer.Elapsed += (o, args) =>
            {
                Deactivate(o, args, detectedEvent);
            };
            ScheduledDeactivationsCount++;

            EnterExitEventsUpdated?.Invoke(this, new EnterExitEventsUpdatedEventArgs(ActiveEvents));
        }
        public void Deactivate(object o, ElapsedEventArgs args, EnterExitEvent ae)
        {
            ScheduledDeactivationsCount--;
            ActiveEvents.Remove(ae);
            EnterExitEventsUpdated?.Invoke(this, new EnterExitEventsUpdatedEventArgs(ActiveEvents));
        }
    }
}
