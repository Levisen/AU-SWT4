using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class SeperationEventDisplayer
    {
        private ISeperationEventController _seperationeventcontroller;
        private IMonitor _monitor;

        public SeperationEventDisplayer(IMonitor monitor, ISeperationEventController seperationeventcontroller)
        {
            _seperationeventcontroller = seperationeventcontroller;
            _monitor = monitor;

            _seperationeventcontroller.SeperationEventsUpdated += OnSeperationEventsUpdated;
        }

        private void OnSeperationEventsUpdated(object sender, SeperationEventsUpdatedEventArgs e)
        {
            List<SeperationEvent> events = e.ActiveSeperations;
            
            string flighteventstring = GenerateFlightEventList(events);
            _monitor.UpdateDisplaySection("SeperationEventList", flighteventstring);
        }

        private string GenerateFlightEventList(List<SeperationEvent> events)
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
