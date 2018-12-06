using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Events
{
    public class EnterExitEventsUpdatedEventArgs : EventArgs
    {
        public List<EnterExitEvent> ActiveEvents { get; }
        public EnterExitEventsUpdatedEventArgs(List<EnterExitEvent> events)
        {
            ActiveEvents = events;
        }
    }
}
