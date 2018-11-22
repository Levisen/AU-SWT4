using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class AirspaceEventDisplayer
    {
        private IAirspaceEventController _airspaceeventcontroller;
        private IMonitor _monitor;

        public AirspaceEventDisplayer(IMonitor monitor, IAirspaceEventController airspaceeventcontroller)
        {
            _airspaceeventcontroller = airspaceeventcontroller;
            _monitor = monitor;

            _airspaceeventcontroller.AirspaceEventsUpdated += OnAirspaceEventsUpdated;
        }

        private void OnAirspaceEventsUpdated(object sender, AirspaceEventsUpdatedEventArgs e)
        {
            List<IAirspaceEvent> events = e.ActiveEvents;

            string flighteventstring = GenerateFlightEventList(events);
            _monitor.UpdateDisplaySection("AirspaceEventList", flighteventstring);
        }

        private string GenerateFlightEventList(List<IAirspaceEvent> events)
        {
            string eventliststring = "-ACTIVE-AIRSPACE-EVENTS-";
            foreach (var e in events)
            {
                eventliststring += " " + e.GetActivationTime().ToShortTimeString() + " SOME INFO";
            }
            return eventliststring;
        }
    }
}
