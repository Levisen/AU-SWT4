﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;

namespace AirTrafficMonitor.Interfaces
{
    public interface IFlightTrackerSingle
    {
        //Flightevent EventHandler<FlightTrackUpdatedEventArgs> FlightTrackUpdated;
        string GetTag();
        double GetCurrentAltitude();
        double GetCurrentVelocity();
        double GetCurrentCourse();
        Vector2 GetCurrentPosition();
        void AddDataPoint(FTDataPoint dp);
        FTDataPoint GetNewestDataPoint();
        ICollection<FTDataPoint> GetFullDataLog();
    }
}
