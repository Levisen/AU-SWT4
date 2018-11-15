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
        double CurrentAltitude;
        
        double CurrentVelocity;
        double CurrentCourse;
        DateTime LastUpdated;

        //SortedList<DateTime, FTDataPoint> TrackDataLog; //in case of non-chronological input?
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
            VelocityCalculator = new FlightVelocityCalculator();
            CourseCalculator = new FlightCourseCalculator();
        }
        
        public string GetTag()
        {
            return Tag;
        }
        public void AddDataPoint(FTDataPoint new_dp)
        {
            Tag = new_dp.Tag;
            CurrentPosition.X = new_dp.X;
            CurrentPosition.Y = new_dp.Y;
            CurrentAltitude = new_dp.Altitude;
            LastUpdated = new_dp.TimeStamp;

            //TrackDataLog.Add(dp.TimeStamp, dp);
            FTDataPoint previous_dp = TrackDataLog.Count != 0 ? TrackDataLog.First() : null;
            TrackDataLog.AddFirst(new_dp);

            Vector2 previous_position = previous_dp != null ? new Vector2(previous_dp.X, previous_dp.Y) : Vector2.Zero;
            Vector2 current_position = new Vector2(new_dp.X, new_dp.Y);

            CurrentVelocity = VelocityCalculator.CalculateCurrentVelocity(
                previous_position, 
                previous_dp?.TimeStamp, 
                current_position, 
                new_dp.TimeStamp
             );
            CurrentCourse = CourseCalculator.CalculateCurrentCourse(previous_position, current_position);
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

        public double GetCurrentAltitude()
        {
            return CurrentAltitude;
        }

        public Vector2 GetCurrentPosition()
        {
            return CurrentPosition;
        }

        public double GetCurrentVelocity()
        {
            return CurrentVelocity;
        }

        public double GetCurrentCourse()
        {
            return CurrentCourse;
        }
    }
}
