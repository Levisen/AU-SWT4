using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using NUnit.Framework;

namespace AirTrafficMonitor.Test.Unit.TestData
{
    public class FlightTrackDataEventTestData
    {
        public static IEnumerable OnTransponderDataReadyCases
        {
            get
            {
                //data compare
                var point = new FTDataPoint() { X = 14000 };  
                
                //argsdata setup
                var argsData = new List<FTDataPoint>();
                argsData.Add(point);

                //compare data setup
                List<IFlightTrack> trackersingle;
                var data = new AirTrafficMonitor.Flight(point);
                trackersingle = NSubstitute.Substitute.For<List<IFlightTrack>>();
                trackersingle.Add(data);
                var CompareReturnData = new FlightTracksUpdatedEventArgs(trackersingle);
                
                //Send testdata
                yield return new TestCaseData(argsData, CompareReturnData, trackersingle);
            }
        }
    }
}
