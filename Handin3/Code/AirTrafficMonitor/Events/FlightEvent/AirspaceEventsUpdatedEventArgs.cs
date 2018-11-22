using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Events
{
    public class AirspaceEventsUpdatedEventArgs : EventArgs
    {
        public List<AirspaceEvent> ActiveEvents { get; }
        public AirspaceEventsUpdatedEventArgs(List<AirspaceEvent> events)
        {
            ActiveEvents = events;
        }
    }
}
