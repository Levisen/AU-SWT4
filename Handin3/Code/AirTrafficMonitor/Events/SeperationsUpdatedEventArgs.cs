using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Events
{
    public class SeperationsUpdatedEventArgs : EventArgs
    {
        public List<SeperationEventArgs> ActiveSeperations;

        public SeperationsUpdatedEventArgs(List<SeperationEventArgs> activeSeperations)
        {
            ActiveSeperations = activeSeperations;
        }
    }
}
