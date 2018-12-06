using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class EnterExitEventDetectedArgs
    {
        public EnterExitEvent Event { get; }
        public EnterExitEventDetectedArgs(EnterExitEvent e)
        {
            Event = e;
        }
    }
}
