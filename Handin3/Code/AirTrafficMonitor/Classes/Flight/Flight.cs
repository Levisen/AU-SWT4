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
    public class Flight : IFlightTrack 

    {
        private string _tag;
        private Vector2 _currentPosition;
        private double _currentAltitude;
        private double _currentVelocity;
        private double _currentCourse;
        private DateTime _lastUpdated;

        private LinkedList<FTDataPoint> _trackDataLog;

        private IFlightVelocityCalculator _velocityCalculator;
        private IFlightCourseCalculator _courseCalculator;

        //public event EventHandler<FlightTrackUpdatedEventArgs> FlightTrackUpdated;

        public Flight(FTDataPoint first)
        {
            _tag = first.Tag;
            _currentPosition = new Vector2(first.X, first.Y);
            _currentAltitude = first.Altitude;
            _lastUpdated = first.TimeStamp;

            _trackDataLog = new LinkedList<FTDataPoint>();
            _velocityCalculator = new FlightVelocityCalculator();
            _courseCalculator = new FlightCourseCalculator();
        }
        

        public void AddDataPoint(FTDataPoint new_dp)
        {
            _tag = new_dp.Tag;
            _currentPosition.X = new_dp.X;
            _currentPosition.Y = new_dp.Y;
            _currentAltitude = new_dp.Altitude;
            _lastUpdated = new_dp.TimeStamp;

            FTDataPoint previous_dp = _trackDataLog.Count != 0 ? _trackDataLog.First() : null;
            _trackDataLog.AddFirst(new_dp);

            Vector2 previous_position = (previous_dp != null) ? new Vector2(previous_dp.X, previous_dp.Y) : Vector2.Zero;
            Vector2 current_position = new Vector2(new_dp.X, new_dp.Y);

            _currentVelocity = _velocityCalculator.CalculateCurrentVelocity(
                previous_position, 
                previous_dp?.TimeStamp, 
                current_position, 
                new_dp.TimeStamp
             );
            _currentCourse = _courseCalculator.CalculateCurrentCourse(previous_position, current_position);
        }
        public ICollection<FTDataPoint> GetFullDataLog()
        {
            return _trackDataLog;
        }

        public FTDataPoint GetNewestDataPoint()
        {
            return (_trackDataLog.Count != 0) ? _trackDataLog.First() : null;
        }

        public string GetTag() { return _tag; }

        public double GetCurrentAltitude() { return _currentAltitude; }

        public Vector2 GetCurrentPosition() { return _currentPosition; }

        public double GetCurrentVelocity() { return _currentVelocity; }

        public double GetCurrentCourse() { return _currentCourse; }
    }
}
