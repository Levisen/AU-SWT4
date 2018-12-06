using System;

namespace AirTrafficMonitor
{
    public class FTDataPoint
    {
        public FTDataPoint() { }
        public FTDataPoint(string t,int x, int y, int a, DateTime ti)
        {
            Tag = t;
            X = x;
            Y = y;
            Altitude = a;
            TimeStamp = ti;
        }
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
