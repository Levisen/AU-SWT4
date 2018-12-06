using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class EnterExitEventDisplayer
    {
        private IEnterExitEventController _EnterExitEventcontroller;
        private IMonitor _monitor;

        public EnterExitEventDisplayer(IMonitor monitor, IEnterExitEventController EnterExitEventcontroller)
        {
            _EnterExitEventcontroller = EnterExitEventcontroller;
            _monitor = monitor;

            _EnterExitEventcontroller.EnterExitEventsUpdated += OnEnterExitEventsUpdated;
        }

        private void OnEnterExitEventsUpdated(object sender, EnterExitEventsUpdatedEventArgs e)
        {
            List<EnterExitEvent> events = e.ActiveEvents;
            string flighteventstring = GenerateFlightEventList(events);
            _monitor.UpdateDisplaySection("EnterExitEventList", flighteventstring);
        }

        private string GenerateFlightEventList(List<EnterExitEvent> events)
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
                    eventliststring += " " + e.Description + "\n";
                }
            }
            
            return eventliststring;
        }
    }
}
