using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AirTrafficMonitor.Test.Integration
{
    class IT_2a_FlightTrackManagerToEnterExitEventController
    {
        private IFlightTrackManager _dataSource;
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
            _dataSource.FlightTracksUpdated += (o, args) => _inputEventCounter++;
            _enterExitEventDetector = new EnterExitEventDetector(_dataSource);
            _uut = new EnterExitEventController(_enterExitEventDetector);
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
        }

        [Test]
        public void OnFlightTracksUpdated_FlightEnterThenOtherFlightEnter_TwoEnterEvents()
        {
            //Arrange
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
            Assert.That(_lastReceivedEnterExitEvents.Count, Is.EqualTo(2));
            Assert.That(_lastReceivedEnterExitEvents.Where(e => e.Entered).Count, Is.EqualTo(2));
            Assert.That(_lastReceivedEnterExitEvents.Where(e => !e.Entered).Count, Is.EqualTo(0));
        }

        [Test]
        public void OnFlightTracksUpdated_FlightEnter_DeactivationScheduled()
        {
            //Arrange
            var args1 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { });
            var args2 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });
            var args3 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });

            var args4 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });

            //Act
            _dataSource.FlightTracksUpdated += Raise.EventWith(args1);
            _dataSource.FlightTracksUpdated += Raise.EventWith(args2);
            _dataSource.FlightTracksUpdated += Raise.EventWith(args3);
            //Thread.Sleep(5500); // sleep 5.5 seconds
            _dataSource.FlightTracksUpdated += Raise.EventWith(args4);

            //Assert
            Assert.That(_lastReceivedEnterExitEvents.Count, Is.EqualTo(1));
            Assert.That(_lastReceivedEnterExitEvents.Where(e => e.Entered).Count, Is.EqualTo(1));
            Assert.That(_lastReceivedEnterExitEvents.Where(e => !e.Entered).Count, Is.EqualTo(0));
            Assert.That(_uut.ScheduledDeactivationsCount, Is.EqualTo(1));
        }


    }
}
