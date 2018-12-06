using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Test.Unit.FlightEvents
{
    [TestFixture]
    class EnterExitEventDetectionTest
    {
        private IEnterExitEventDetector _uut;

        private IFlightTrackManager _datasource;

        
        private IFlightTrack _flight1, _flight2, _flight3;

        private int _flightTracksUpdatedCounter;
        private int _enterExitEventDetectedCounter;
        private int _entederCounter;
        private int _exitedCounter;
        private List<EnterExitEvent> _enterExitEventsDetected;
        private EnterExitEvent _lastEnterExitEventDetected;

        [SetUp]
        public void SetUp()
        {
            _flightTracksUpdatedCounter = 0;
            _enterExitEventDetectedCounter = 0;
            _entederCounter = 0;
            _exitedCounter = 0;
            _enterExitEventsDetected = new List<EnterExitEvent>();

            _datasource = Substitute.For<IFlightTrackManager>();
            _datasource.FlightTracksUpdated += (sender, args) => _flightTracksUpdatedCounter++;

            _uut = new EnterExitEventDetector(_datasource);
            _uut.EnterExitEventDetected += (sender, args) => {
                _enterExitEventsDetected.Add(args.Event);
                _lastEnterExitEventDetected = args.Event;
                _enterExitEventDetectedCounter++;
                if (args.Event.Entered) _entederCounter++;
                else _exitedCounter++;
            };

            _flight1 = Substitute.For<IFlightTrack>();
            _flight2 = Substitute.For<IFlightTrack>();
            _flight1.GetTag().Returns("TAG123");
            _flight1.GetLastUpdatedAt().Returns(DateTime.Now);
            _flight2.GetTag().Returns("TAG456");
            _flight2.GetLastUpdatedAt().Returns(DateTime.Now);

        }

        [Test]
        public void OnDataSourceFlightTracksUpdated_FlightEnter_OneEnterEvent()
        {
            //Arrange
            var args1 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { });
            var args2 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });
            var args3 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });

            //Act
            _datasource.FlightTracksUpdated += Raise.EventWith(args1);
            _datasource.FlightTracksUpdated += Raise.EventWith(args2);
            _datasource.FlightTracksUpdated += Raise.EventWith(args3);

            //Assert
            Assert.That(_flightTracksUpdatedCounter, Is.EqualTo(3));
            Assert.That(_enterExitEventDetectedCounter, Is.EqualTo(1));
            Assert.That(_enterExitEventsDetected.Count, Is.EqualTo(1));
            Assert.That(_entederCounter, Is.EqualTo(1));
            Assert.That(_exitedCounter, Is.EqualTo(0));
            Assert.That(_lastEnterExitEventDetected.Entered, Is.EqualTo(true));
            Assert.That(_lastEnterExitEventDetected.Flight.GetTag(), Is.EqualTo(_flight1.GetTag()));
        }

        [Test]
        public void OnDataSourceFlightTracksUpdated_FlightEnterThenExit_OneEnterEventOneExitEvent()
        {
            //Arrange
            var args1 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { });
            var args2 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });
            var args3 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });
            var args4 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });
            var args5 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { });

            //Act
            _datasource.FlightTracksUpdated += Raise.EventWith(args1);
            _datasource.FlightTracksUpdated += Raise.EventWith(args2);
            _datasource.FlightTracksUpdated += Raise.EventWith(args3);
            _datasource.FlightTracksUpdated += Raise.EventWith(args4);
            _datasource.FlightTracksUpdated += Raise.EventWith(args5);

            //Assert
            Assert.That(_flightTracksUpdatedCounter, Is.EqualTo(5));
            Assert.That(_enterExitEventDetectedCounter, Is.EqualTo(2));
            Assert.That(_enterExitEventsDetected.Count, Is.EqualTo(2));
            Assert.That(_entederCounter, Is.EqualTo(1));
            Assert.That(_exitedCounter, Is.EqualTo(1));
            Assert.That(_lastEnterExitEventDetected.Entered, Is.EqualTo(false));
            Assert.That(_lastEnterExitEventDetected.Flight.GetTag(), Is.EqualTo("TAG123"));
        }

        [Test]
        public void OnDataSourceFlightTracksUpdated_FlightEnterThenOtherFlightEnter_TwoEnterEvents()
        {
            //Arrange
            var args1 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { });
            var args2 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });
            var args3 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });
            var args4 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1, _flight2 });
            var args5 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1, _flight2 });

            //Act
            _datasource.FlightTracksUpdated += Raise.EventWith(args1);
            _datasource.FlightTracksUpdated += Raise.EventWith(args2);
            _datasource.FlightTracksUpdated += Raise.EventWith(args3);
            _datasource.FlightTracksUpdated += Raise.EventWith(args4);
            _datasource.FlightTracksUpdated += Raise.EventWith(args5);

            //Assert
            Assert.That(_flightTracksUpdatedCounter, Is.EqualTo(5));
            Assert.That(_enterExitEventDetectedCounter, Is.EqualTo(2));
            Assert.That(_enterExitEventsDetected.Count, Is.EqualTo(2));
            Assert.That(_entederCounter, Is.EqualTo(2));
            Assert.That(_exitedCounter, Is.EqualTo(0));
            Assert.That(_lastEnterExitEventDetected.Entered, Is.EqualTo(true));
            Assert.That(_lastEnterExitEventDetected.Flight.GetTag(), Is.EqualTo("TAG456"));
        }

        

        public void OnDataSourceFlightTracksUpdated_FlightEnterThenOtherFlightEnterThenFirstFlightExit_TwoEnterEventsOneExitEvent()
        {
            //Arrange
            var args1 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { });
            var args2 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });
            var args3 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1 });
            var args4 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1, _flight2 });
            var args5 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1, _flight2 });
            var args6 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight2 });
            var args7 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight2 });

            //Act
            _datasource.FlightTracksUpdated += Raise.EventWith(args1);
            _datasource.FlightTracksUpdated += Raise.EventWith(args2);
            _datasource.FlightTracksUpdated += Raise.EventWith(args3);
            _datasource.FlightTracksUpdated += Raise.EventWith(args4);
            _datasource.FlightTracksUpdated += Raise.EventWith(args5);
            _datasource.FlightTracksUpdated += Raise.EventWith(args6);
            _datasource.FlightTracksUpdated += Raise.EventWith(args7);

            //Assert
            Assert.That(_flightTracksUpdatedCounter, Is.EqualTo(7));
            Assert.That(_enterExitEventDetectedCounter, Is.EqualTo(3));
            Assert.That(_enterExitEventsDetected.Count, Is.EqualTo(3));
            Assert.That(_lastEnterExitEventDetected.Entered, Is.EqualTo(false));
            Assert.That(_entederCounter, Is.EqualTo(2));
            Assert.That(_exitedCounter, Is.EqualTo(1));
            Assert.That(_lastEnterExitEventDetected.Flight.GetTag(), Is.EqualTo("TAG123"));
        }

    }
}
