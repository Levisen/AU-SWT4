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
            List<AirspaceEvent> events = e.ActiveEvents;
            string flighteventstring = GenerateFlightEventList(events);
            _monitor.UpdateDisplaySection("AirspaceEventList", flighteventstring);
        }

        private string GenerateFlightEventList(List<AirspaceEvent> events)
        {
            string eventliststring = "";
            if (events.Count == 0)
            {
                eventliststring += "    (no active events)\n";
            }
            else
            {
                foreach (var e in events)
                {
                    eventliststring += "[" + e.Description + "\n";
                }
            }
            
            return eventliststring;
        }
    }
}
