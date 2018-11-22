using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class AirspaceEventDetector : IAirspaceEventDetector
    {
        public event EventHandler<EventArgs> AirspaceEventDetected;

        IAirspace _datasource;
        public AirspaceEventDetector(IAirspace airspace)
        {
            _datasource = airspace;
        }

        
    }
}
