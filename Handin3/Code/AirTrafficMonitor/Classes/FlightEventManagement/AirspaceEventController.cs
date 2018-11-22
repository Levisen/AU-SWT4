using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class AirspaceEventController : IAirspaceEventController
    {
        public event EventHandler<AirspaceEventsUpdatedEventArgs> AirspaceEventsUpdated;
    }
}
