using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Test.Unit.Event
{
    [TestFixture]
    class AirspaceEventDetectionTest
    {
        private IAirspaceEventDetector _uut;
        private IAirspace _airspace;

        private List<AirspaceEvent> _airspaceEventsDetected;
        
        private IFlightTrackerSingle flight1, flight2, flight3;

        private int _eventCounterAirspaceUpdated;
        private int _eventCounterAirspaceEventDetected;

        [SetUp]
        public void SetUp()
        {
            _eventCounterAirspaceUpdated = 0;
            _eventCounterAirspaceEventDetected = 0;

            _airspace = Substitute.For<IAirspace>();

            _uut = new AirspaceEventDetector(_airspace);
            _airspaceEventsDetected = new List<AirspaceEvent>();

            _airspace.AirspaceContentUpdated += (sender, args) => _eventCounterAirspaceUpdated++;

            _uut.AirspaceEventDetected += (sender, args) => _eventCounterAirspaceEventDetected++;




            //flightOutside1 = new Flight(new FTDataPoint("", 9999, 9999, 5000, DateTime.Now));
            //flightOutside2 = new Flight(new FTDataPoint("", 9500, 9500, 5000, DateTime.Now.AddSeconds(1)));
            //flightInside1 = new Flight(new FTDataPoint("", 10500, 10500, 5000, DateTime.Now));
            //flightInside2 = new Flight(new FTDataPoint("", 11000, 11000, 5000, DateTime.Now.AddSeconds(1)));
        }

        [Test]
        public void OnAirspaceEventDetected_FlightStayOutside_NoEvents()
        {
            //flight1 = Substitute.For<IFlightTrackerSingle>();
            flight1 = new Flight(new FTDataPoint("TAG123", 9999, 9999, 5000, DateTime.Now));
            //flight1.GetTag().Returns("TAG123");

            List<IFlightTrackerSingle> flightList1 = new List<IFlightTrackerSingle> { flight1 };


            
            //flightOutside1.GetCurrentPosition().Returns(new System.Numerics.Vector2(9999, 9999));
            //flightList1.Add(flightOutside1);
            //var argFirst = new AirspaceContentEventArgs(flightList1);
            //var argSecond = new AirspaceContentEventArgs(new List<IFlightTrackerSingle> { flightOutside2 });
            //_uut.AirspaceEventDetected += (sender, args) => _eventCounter++;
            //_airspace.AirspaceContentUpdated += Raise.EventWith(argFirst);
            //_airspace.AirspaceContentUpdated += Raise.EventWith(argSecond);


            //_airspace.AirspaceContentUpdated += Raise.EventWith(new AirspaceContentEventArgs(flightList1));


            //Assert.That(_eventCounter, Is.EqualTo(0));
        }

        [Test]
        public void OnAirspaceEventDetected_FlightMoveInside_OneEvent()
        {

        }

        [Test]
        public void OnAirspaceEventDetected_FlightMoveOutside_OneEvent()
        {

        }

        [Test]
        public void OnAirspaceEventDetected_FlightStayInside_NoEvents()
        {

        }

    }
}
