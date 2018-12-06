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
    class EnterExitEventDetectionTest
    {
        private IEnterExitEventDetector _uut;
        private IFlightTrackManager _airspace;

        private List<EnterExitEvent> _enterExitEventsDetected;
        
        private IFlightTrack _flight1, _flight2, _flight3;

        private int _eventCounterAirspaceUpdated;
        private int _eventCounterEnterExitEventDetected;

        [SetUp]
        public void SetUp()
        {
            _eventCounterAirspaceUpdated = 0;
            _eventCounterEnterExitEventDetected = 0;

            _airspace = Substitute.For<IFlightTrackManager>();

            _uut = new EnterExitEventDetector(_airspace);
            _enterExitEventsDetected = new List<EnterExitEvent>();

            _airspace.FlightTracksUpdated += (sender, args) => _eventCounterAirspaceUpdated++;

            _uut.EnterExitEventDetected += (sender, args) => _eventCounterEnterExitEventDetected++;




            //flightOutside1 = new Flight(new FTDataPoint("", 9999, 9999, 5000, DateTime.Now));
            //flightOutside2 = new Flight(new FTDataPoint("", 9500, 9500, 5000, DateTime.Now.AddSeconds(1)));
            //flightInside1 = new Flight(new FTDataPoint("", 10500, 10500, 5000, DateTime.Now));
            //flightInside2 = new Flight(new FTDataPoint("", 11000, 11000, 5000, DateTime.Now.AddSeconds(1)));
        }

        [Test]
        public void OnEnterExitEventDetected_FlightStayOutside_NoEvents()
        {
            //flight1 = Substitute.For<IFlightTrack>();
            _flight1 = new AirTrafficMonitor.Flight(new FTDataPoint("TAG123", 9999, 9999, 5000, DateTime.Now));
            //flight1.GetTag().Returns("TAG123");

            List<IFlightTrack> flightList1 = new List<IFlightTrack> { _flight1 };


            
            //flightOutside1.GetCurrentPosition().Returns(new System.Numerics.Vector2(9999, 9999));
            //flightList1.Add(flightOutside1);
            //var argFirst = new AirspaceContentEventArgs(flightList1);
            //var argSecond = new AirspaceContentEventArgs(new List<IFlightTrack> { flightOutside2 });
            //_uut.EnterExitEventDetected += (sender, args) => _eventCounter++;
            //_airspace.AirspaceContentUpdated += Raise.EventWith(argFirst);
            //_airspace.AirspaceContentUpdated += Raise.EventWith(argSecond);


            //_airspace.AirspaceContentUpdated += Raise.EventWith(new AirspaceContentEventArgs(flightList1));


            //Assert.That(_eventCounter, Is.EqualTo(0));
        }

        [Test]
        public void OnEnterExitEventDetected_FlightMoveInside_OneEvent()
        {

        }

        [Test]
        public void OnEnterExitEventDetected_FlightMoveOutside_OneEvent()
        {

        }

        [Test]
        public void OnEnterExitEventDetected_FlightStayInside_NoEvents()
        {

        }

    }
}
