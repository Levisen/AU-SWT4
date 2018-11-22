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
    public class AirspaceEventController : IAirspaceEventController
    {
        IAirspaceEventDetector _detector;
        List<AirspaceEvent> ActiveEvents;
        List<AirspaceEvent> InctiveEvents;

        public event EventHandler<AirspaceEventsUpdatedEventArgs> AirspaceEventsUpdated;

        public AirspaceEventController(IAirspaceEventDetector detector)
        {
            _detector = detector;
            _detector.AirspaceEventDetected += OnAirspaceEventDetected;
            ActiveEvents = new List<AirspaceEvent>();
            InctiveEvents = new List<AirspaceEvent>();
            SetDeavtivationCheckTimer();
        }

        private void OnAirspaceEventDetected(object sender, AirspaceEventDetectedArgs e)
        {
            var detected_event = e.Event;
            ActiveEvents.Add(detected_event);
            //SetDeavtivationTimer(detected_event.Flight.GetTag());
            AirspaceEventsUpdated?.Invoke(this, new AirspaceEventsUpdatedEventArgs(ActiveEvents));
        }

        private void SetDeavtivationCheckTimer()
        {
            var timer = new System.Timers.Timer(250);
            timer.Elapsed += CheckDeactivate;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void CheckDeactivate(Object source, ElapsedEventArgs e)
        {
            bool anythingchanged = false;
            foreach (var ev in ActiveEvents.ToList())
            {
                if (ev.ActivationTime.AddSeconds(5) > DateTime.Now)
                {
                    ActiveEvents.Remove(ev);
                    anythingchanged = true;
                }
            }
            if (anythingchanged) AirspaceEventsUpdated?.Invoke(this, new AirspaceEventsUpdatedEventArgs(ActiveEvents));
        }
    }
}
