using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class Flight
    {
        public Flight(string tag)
        {
            Tag = tag;
        }

        public string Tag { get; set; }
        public Vector2 CurrentPosition { get; set; }
        public float CurrentAltitude { get; set; }
        public DateTime LastUpdated { get; set; }
        public float CurrentVelocity { get; set; }
        public float CurrentCourse { get; set; }
        public List<FTDataPoint> TrackDataLog { get; set; }
        public int CurrentDataEntryTracks { get; set; }

        public void AddDataPoint(FTDataPoint dp)
        {
        //TrackDataLog.Ad

            TrackDataLog.Sort();
        }


    }
}
