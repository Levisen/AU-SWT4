using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor
{
    public class Flight : IFlightTrackerSingle
    {
        public Flight(string tag)
        {
            Tag = tag;
            TrackDataLog = new SortedList<DateTime, FTDataPoint>();
            VelocityCalculator = new FlightVelocityCalculator(this);
            CourseCalculator = new FlightCourseCalculator(this);
        }

        public string Tag { get; set; }
        public Vector2 CurrentPosition { get; set; }
        public float CurrentAltitude { get; set; }
        public DateTime LastUpdated { get; set; }
        public float CurrentVelocity { get; set; }
        public float CurrentCourse { get; set; }
        public SortedList<DateTime, FTDataPoint> TrackDataLog { get; set; }
        public int CurrentDataEntryTracks { get; set; }

        public IFlightVelocityCalculator VelocityCalculator;
        public IFlightCourseCalculator CourseCalculator;

        public void AddDataPoint(FTDataPoint dp)
        {
            TrackDataLog.Add(dp.TimeStamp, dp);
            CurrentVelocity = VelocityCalculator.GetCurrentVelocity();
            CurrentCourse = CourseCalculator.GetCurrentCourse();

        }
        public ICollection<FTDataPoint> GetFullDataLog()
        {
            return TrackDataLog.Values;
        }

        public FTDataPoint GetNewestDataPoint()
        {
            FTDataPoint newest = TrackDataLog.Max().Value;
            return newest;
        }
        public float GetCurrentCourse()
        {
            //Check if ehough entries exist in log to calculate
            //Get required instances from log

            throw new NotImplementedException();
        }

        public float GetCurrentVelocity()
        {
            throw new NotImplementedException();
        }
    }
}
