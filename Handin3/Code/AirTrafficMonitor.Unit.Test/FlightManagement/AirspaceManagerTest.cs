using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Test.Unit.FlightManagement
{
    class AirspaceManagerTest
    {
        private IAirspaceManager _uut;

        private IFlightTrackManager _datasource;
        private IAirspaceArea _area;

        private IFlightTrack _flight1, _flight2, _flight3;

        private int _flightTracksUpdatedEventCount;
        private int _airspaceUpdatedEventCount;
        private List<IFlightTrack> _airspaceUpdatedEventContent;

        [SetUp]
        public void SetUp()
        {
            //Event Counters
            _flightTracksUpdatedEventCount = 0;
            _airspaceUpdatedEventCount = 0;


            //Dependencies
            _datasource = Substitute.For<IFlightTrackManager>();
            _datasource.FlightTracksUpdated += (sender, args) => _flightTracksUpdatedEventCount++;
            _area = Substitute.For<IAirspaceArea>();
            
            _uut = new AirspaceManager(_datasource, _area);
            _uut.AirspaceContentUpdated += (sender, args) => {
                _airspaceUpdatedEventCount++;
                _airspaceUpdatedEventContent = args.AirspaceContent;
            };

            _flight1 = Substitute.For<IFlightTrack>(); //new Flight(new FTDataPoint("TAG123", 9999, 9999, 5000, DateTime.Now));
            _flight2 = Substitute.For<IFlightTrack>();

            //flightOutside2 = new Flight(new FTDataPoint("", 9500, 9500, 5000, DateTime.Now.AddSeconds(1)));
            //flightInside1 = new Flight(new FTDataPoint("", 10500, 10500, 5000, DateTime.Now));
            //flightInside2 = new Flight(new FTDataPoint("", 11000, 11000, 5000, DateTime.Now.AddSeconds(1)));
        }

        [Test]
        public void OnFlightTracksUpdated_AirspaceUpdatedEventRaised()
        {
            //Arrange
            var args = new FlightTracksUpdatedEventArgs(new List < IFlightTrack > { _flight1 });

            //Act
            _datasource.FlightTracksUpdated += Raise.EventWith(args);

            //Assert
            Assert.That(_airspaceUpdatedEventCount, Is.EqualTo(1));
        }

        [Test]
        public void OnFlightTracksUpdated_OneFlightInAirspace_AirspaceUpdated_OneFlightInAirspace()
        {
            //Arrange
            _area.IsInside(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(true);
            var args = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight2 });

            //Act
            _datasource.FlightTracksUpdated += Raise.EventWith(args);

            Assert.That(_airspaceUpdatedEventCount, Is.EqualTo(1));
            Assert.That(_airspaceUpdatedEventContent.Count, Is.EqualTo(1));
        }

        [Test]
        public void OnFlightTracksUpdated_OneFlightNotInAirspace_AirspaceUpdated_NoFlightsInAirspace()
        {
            //Arrange
            _area.IsInside(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(false);
            var args = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight2 });

            //Act
            _datasource.FlightTracksUpdated += Raise.EventWith(args);

            Assert.That(_airspaceUpdatedEventCount, Is.EqualTo(1));
            Assert.That(_airspaceUpdatedEventContent.Count, Is.EqualTo(0));
        }

        [Test]
        public void OnFlightTracksUpdated_OneFlightInAirspaceOnFlightOutsideAirspace_AirspaceUpdated_OneFlightInAirspace()
        {
            //Arrange
            _flight1.GetCurrentAltitude().Returns(1d);
            _flight2.GetCurrentAltitude().Returns(0d);
            _area.IsInside(Arg.Any<int>(), Arg.Any<int>(), Arg.Is<int>(x => x == 1)).Returns(true);
            _area.IsInside(Arg.Any<int>(), Arg.Any<int>(), Arg.Is<int>(x => x == 0)).Returns(false);
            var args = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1, _flight2 });

            //Act
            _datasource.FlightTracksUpdated += Raise.EventWith(args);

            //Assert
            Assert.That(_airspaceUpdatedEventCount, Is.EqualTo(1));
            Assert.That(_airspaceUpdatedEventContent.Count, Is.EqualTo(1));
        }
    }
}
