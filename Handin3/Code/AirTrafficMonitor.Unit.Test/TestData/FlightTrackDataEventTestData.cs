using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using NUnit.Framework;

namespace AirTrafficMonitor.Unit.Test.TestData
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
                List<IFlightTrackerSingle> trackersingle;
                var data = new Flight(point);
                trackersingle = NSubstitute.Substitute.For<List<IFlightTrackerSingle>>();
                trackersingle.Add(data);
                var CompareReturnData = new FlightTracksUpdatedEventArgs(trackersingle);
                
                //Send testdata
                yield return new TestCaseData(argsData, CompareReturnData, trackersingle);
            }
        }
    }
}
