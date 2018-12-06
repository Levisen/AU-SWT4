using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Events
{
    public class SeperationDetectedEventArgs : EventArgs
    {
        public SeperationEvent DetectedEvent { get; }
        public SeperationDetectedEventArgs(SeperationEvent detectedevent)
        {
            DetectedEvent = detectedevent;
        }
    }
}
