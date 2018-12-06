﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;

namespace AirTrafficMonitor.Interfaces
{
    public interface IFlightTrackManager
    {
        event EventHandler<FlightTracksUpdatedEventArgs> FlightTracksUpdated;
        //IFlightTrackDataSource GetDataSource();
        List<IFlightTrack> GetFlights();
    }
}
