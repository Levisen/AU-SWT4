﻿using System;
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

        SortedList<DateTime, FTDataPoint> TrackDataLog;

        public IFlightVelocityCalculator VelocityCalculator;
        public IFlightCourseCalculator CourseCalculator;

        public event EventHandler<FlightTrackUpdatedEventArgs> FlightTrackUpdated;

        public Flight(string tag)
        {
            Tag = tag;
            TrackDataLog = new SortedList<DateTime, FTDataPoint>();
            VelocityCalculator = new FlightVelocityCalculator(this);
            CourseCalculator = new FlightCourseCalculator(this);
        }
        
        public string GetTag()
        {
            return Tag;
        }
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
