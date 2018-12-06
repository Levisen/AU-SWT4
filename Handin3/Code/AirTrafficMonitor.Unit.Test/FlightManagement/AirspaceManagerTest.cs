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
        //Unit under test
        private IAirspaceManager _uut;

        //Dependecies
        private IFlightTrackManager _datasource;
        private IAirspaceArea _area;

        private IFlightTrack _flight1, _flight2;

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

            _flight1 = Substitute.For<IFlightTrack>();
            _flight2 = Substitute.For<IFlightTrack>();
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
