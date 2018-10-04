using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    class Monitor
    {
        public void OutputFTDataPoint(FTDataPoint dp)
        {
            Console.WriteLine(
                  "Transponderdata: " + dp.Tag
                + "   Position: " + dp.X + "," + dp.Y
                + "   Altitude: " + dp.Altitude
                + "   Time: " + dp.TimeStamp
                );
        }
    }
}
