﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;

namespace AirTrafficMonitor.Interfaces
{
    public interface ITransponderDataConverter
    {
        List<FTDataPoint> ConvertTransponderData(RawTransponderDataEventArgs args);
        ITransponderStringConverter GetStringConverter();
        IFlightTrackDataSource GetFlightTrackDataSource();
        ITransponderReceiver GetTransponderReceiver(); //Some comment

    }
}
