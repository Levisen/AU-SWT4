using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor
{
    public class Flight : IFlightTrackerSingle
    {
        string Tag;
        Vector2 CurrentPosition;
        float CurrentAltitude;
        
        float CurrentVelocity;
        float CurrentCourse;
        DateTime LastUpdated;

        //SortedList<DateTime, FTDataPoint> TrackDataLog;
        LinkedList<FTDataPoint> TrackDataLog;
        public IFlightVelocityCalculator VelocityCalculator;
        public IFlightCourseCalculator CourseCalculator;

        public event EventHandler<FlightTrackUpdatedEventArgs> FlightTrackUpdated;

        public Flight(FTDataPoint first)
        {
            Tag = first.Tag;
            CurrentPosition = new Vector2(first.X, first.Y);
            CurrentAltitude = first.Altitude;
            LastUpdated = first.TimeStamp;
            //TrackDataLog = new SortedList<DateTime, FTDataPoint>();
            TrackDataLog = new LinkedList<FTDataPoint>();
            VelocityCalculator = new FlightVelocityCalculator(this);
            CourseCalculator = new FlightCourseCalculator(this);
        }
        
        public string GetTag()
        {
            return Tag;
        }
        public void AddDataPoint(FTDataPoint dp)
        {
            Tag = dp.Tag;
            CurrentPosition.X = dp.X;
            CurrentPosition.Y = dp.Y;
            CurrentAltitude = dp.Altitude;
            LastUpdated = dp.TimeStamp;

            //TrackDataLog.Add(dp.TimeStamp, dp);
            TrackDataLog.AddFirst(dp);
            CurrentVelocity = VelocityCalculator.GetCurrentVelocity(TrackDataLog);
            CurrentCourse = CourseCalculator.GetCurrentCourse(TrackDataLog);
=======
            TrackDataLog.Add(dp);
            CurrentVelocity = VelocityCalculator.GetCurrentVelocity();
            CurrentCourse = CourseCalculator.GetCurrentCourse();
>>>>>>> a8cc0c8728d10a7da3258e64ef96684cc7b31eac

        }
        public ICollection<FTDataPoint> GetFullDataLog()
        {
            return TrackDataLog;//.Values;
        }

        public FTDataPoint GetNewestDataPoint()
        {
            FTDataPoint newest = TrackDataLog.First();//.Value;
            return newest;
        }

        public float GetCurrentAltitude()
        {
            return CurrentAltitude;
        }

        public Vector2 GetCurrentPosition()
        {
            return CurrentPosition;
        }
    }
}
