using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Events
{
    public class SeperationEventsUpdatedEventArgs : EventArgs
    {
        public List<SeperationEvent> ActiveSeperations;

        public SeperationEventsUpdatedEventArgs(List<SeperationEvent> activeSeperations)
        {
            ActiveSeperations = activeSeperations;
        }
    }
}
