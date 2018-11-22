using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private void OnAirspaceEventDetected(object sender, AirspaceEventDetectedArgs e)
        {
            var detected_event = e.Event;
            if (detected_event.Entered)
            {
                ActiveEvents.Add(detected_event);
            }
            else
            {
                InctiveEvents.Add(detected_event);
                ActiveEvents.RemoveAll(x => x.Flight.GetTag() == detected_event.Flight.GetTag());
            }
            AirspaceEventsUpdated?.Invoke(this, new AirspaceEventsUpdatedEventArgs(ActiveEvents));
        }
    }
}
