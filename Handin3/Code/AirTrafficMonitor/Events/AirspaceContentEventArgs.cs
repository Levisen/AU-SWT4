using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor.Events
{
    public class AirspaceContentEventArgs : EventArgs
    {
        public List<IFlightTrackerSingle> AirspaceContent { get; set; }
        public AirspaceContentEventArgs(List<IFlightTrackerSingle> flights)
        {
            AirspaceContent = flights;
        }
    }
}
