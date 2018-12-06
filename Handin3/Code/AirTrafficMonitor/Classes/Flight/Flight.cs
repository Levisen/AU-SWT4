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
        string _tag;
        Vector2 _currentPosition;
        double _currentAltitude;
        double _currentVelocity;
        double _currentCourse;
        DateTime _lastUpdated;

        LinkedList<FTDataPoint> TrackDataLog;

        public IFlightVelocityCalculator VelocityCalculator;
        public IFlightCourseCalculator CourseCalculator;

        //public event EventHandler<FlightTrackUpdatedEventArgs> FlightTrackUpdated;

        public Flight(FTDataPoint first)
        {
            _tag = first.Tag;
            _currentPosition = new Vector2(first.X, first.Y);
            _currentAltitude = first.Altitude;
            _lastUpdated = first.TimeStamp;

            TrackDataLog = new LinkedList<FTDataPoint>();
            VelocityCalculator = new FlightVelocityCalculator();
            CourseCalculator = new FlightCourseCalculator();
        }
        

        public void AddDataPoint(FTDataPoint new_dp)
        {
            _tag = new_dp.Tag;
            _currentPosition.X = new_dp.X;
            _currentPosition.Y = new_dp.Y;
            _currentAltitude = new_dp.Altitude;
            _lastUpdated = new_dp.TimeStamp;

            FTDataPoint previous_dp = TrackDataLog.Count != 0 ? TrackDataLog.First() : null;
            TrackDataLog.AddFirst(new_dp);

            Vector2 previous_position = (previous_dp != null) ? new Vector2(previous_dp.X, previous_dp.Y) : Vector2.Zero;
            Vector2 current_position = new Vector2(new_dp.X, new_dp.Y);

            _currentVelocity = VelocityCalculator.CalculateCurrentVelocity(
                previous_position, 
                previous_dp?.TimeStamp, 
                current_position, 
                new_dp.TimeStamp
             );
            _currentCourse = CourseCalculator.CalculateCurrentCourse(previous_position, current_position);
        }
        public ICollection<FTDataPoint> GetFullDataLog()
        {
            return TrackDataLog;
        }

        public FTDataPoint GetNewestDataPoint()
        {
            return (TrackDataLog.Count != 0) ? TrackDataLog.First() : null;
        }

        public string GetTag() { return _tag; }

        public double GetCurrentAltitude() { return _currentAltitude; }

        public Vector2 GetCurrentPosition() { return _currentPosition; }

        public double GetCurrentVelocity() { return _currentVelocity; }

        public double GetCurrentCourse() { return _currentCourse; }
    }
}
