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

        public event EventHandler<EnterExitEventsUpdatedEventArgs> EnterExitEventsUpdated;

        public EnterExitEventController(IEnterExitEventDetector detector)
        {
            _detector = detector;
            _detector.EnterExitEventDetected += OnEnterExitEventDetected;
            ActiveEvents = new List<EnterExitEvent>();
            InctiveEvents = new List<EnterExitEvent>();
            //SetDeavtivationCheckTimer();
        }

        private void OnEnterExitEventDetected(object sender, EnterExitEventDetectedArgs e)
        {
            var detected_event = e.Event;
            ActiveEvents.Add(detected_event);
            var timer = new System.Timers.Timer(5000);
            timer.AutoReset = false;
            timer.Enabled = true;
            timer.Elapsed += (o, args) => Deactivate(o, args, detected_event);
            
            EnterExitEventsUpdated?.Invoke(this, new EnterExitEventsUpdatedEventArgs(ActiveEvents));
        }
        private void Deactivate(object o, ElapsedEventArgs args, EnterExitEvent ae)
        {
            ActiveEvents.Remove(ae);
            EnterExitEventsUpdated?.Invoke(this, new EnterExitEventsUpdatedEventArgs(ActiveEvents));
        }

        //private void SetDeavtivationCheckTimer()
        //{
        //    var timer = new System.Timers.Timer(250);
        //    timer.Elapsed += CheckDeactivate;
        //    timer.AutoReset = true;
        //    timer.Enabled = true;
        //}

        //private void CheckDeactivate(Object source, ElapsedEventArgs e)
        //{
        //    bool anythingchanged = false;
        //    foreach (var ev in ActiveEvents.ToList())
        //    {
        //        if ((DateTime.Now - ev.ActivationTime).TotalSeconds > 5)
        //        {
        //            ActiveEvents.Remove(ev);
        //            anythingchanged = true;
        //        }
        //    }
        //    if (anythingchanged) EnterExitEventsUpdated?.Invoke(this, new EnterExitEventsUpdatedEventArgs(ActiveEvents));
        //}
    }
}
