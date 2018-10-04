using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class FTDataPoint : IComparable<FTDataPoint>
    {
        public string Tag { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Altitude { get; set; }
        public DateTime TimeStamp { get; set; }

        public int CompareTo(FTDataPoint other)
        {
            if (this.TimeStamp > other.TimeStamp) return 1;
            else if (this.TimeStamp < other.TimeStamp) return -1;
            else return 0;
        }
    }
}
