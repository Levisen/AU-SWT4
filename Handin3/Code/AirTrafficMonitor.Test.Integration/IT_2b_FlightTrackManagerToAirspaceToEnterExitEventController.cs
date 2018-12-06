using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AirTrafficMonitor.Test.Integration
{
    class IT_2b_FlightTrackManagerToAirspaceToEnterExitEventController
    {
        private IFlightTrackManager _dataSource;
        private IFlightTrackManager _airspaceManager;
        private IAirspaceArea _area;
        private IEnterExitEventDetector _enterExitEventDetector;
        private IEnterExitEventController _uut;

        private int _inputEventCounter;
        private int _outputEventCounter;
        private List<EnterExitEvent> _lastReceivedEnterExitEvents;

        private IFlightTrack _flight1, _flight2;

        [SetUp]
        public void SetUp()
        {
            _dataSource = Substitute.For<IFlightTrackManager>();
            _area = Substitute.For<IAirspaceArea>();
            _airspaceManager = new AirspaceManager(_dataSource, _area);
            _enterExitEventDetector = new EnterExitEventDetector(_airspaceManager);
            _uut = new EnterExitEventController(_enterExitEventDetector);

            _dataSource.FlightTracksUpdated += (o, args) => _inputEventCounter++;
            _uut.EnterExitEventsUpdated += (o, args) =>
            {
                _lastReceivedEnterExitEvents = args.ActiveEvents;
                _outputEventCounter++;
            };

            _flight1 = Substitute.For<IFlightTrack>();
            _flight2 = Substitute.For<IFlightTrack>();
            _flight1.GetTag().Returns("TAG123");
            _flight1.GetLastUpdatedAt().Returns(DateTime.Now);
            _flight2.GetTag().Returns("TAG456");
            _flight2.GetLastUpdatedAt().Returns(DateTime.Now);

            //Use IAirspaceArea substitute to manually emulate flight airspace filtering (alt = 1 inside, alt = 0 outside)
            _area.IsInside(Arg.Any<int>(), Arg.Any<int>(), Arg.Is<int>(x => x == 1)).Returns(true);
            _area.IsInside(Arg.Any<int>(), Arg.Any<int>(), Arg.Is<int>(x => x == 0)).Returns(false);
        }

        [Test]
        public void OnFlightTracksUpdated_FlightEnterAirspaceThenOtherFlightEnterNotInAirspace_OneEnterEvents()
        {
            //Arrange
            _flight1.GetCurrentAltitude().Returns(1d); //inside
            _flight2.GetCurrentAltitude().Returns(0d); //outside

            var args1 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { });
            var args2 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });
            var args3 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });
            var args4 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1, _flight2 });
            var args5 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1, _flight2 });
            
            //Act
            _dataSource.FlightTracksUpdated += Raise.EventWith(args1);
            _dataSource.FlightTracksUpdated += Raise.EventWith(args2);
            _dataSource.FlightTracksUpdated += Raise.EventWith(args3);
            _dataSource.FlightTracksUpdated += Raise.EventWith(args4);
            _dataSource.FlightTracksUpdated += Raise.EventWith(args5);

            //Assert
            Assert.That(_lastReceivedEnterExitEvents.Count, Is.EqualTo(1));
            Assert.That(_lastReceivedEnterExitEvents.Where(e => e.Entered).Count, Is.EqualTo(1));
            Assert.That(_lastReceivedEnterExitEvents.Where(e => !e.Entered).Count, Is.EqualTo(0));
        }

    }
}
