using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class AirspaceEventDetectedArgs
    {
        public AirspaceEvent Event { get; }
        public AirspaceEventDetectedArgs(AirspaceEvent e)
        {
            Event = e;
        }
    }
}
