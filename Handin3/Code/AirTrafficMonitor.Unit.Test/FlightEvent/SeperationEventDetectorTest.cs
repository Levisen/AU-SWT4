using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitor.Unit.Test.FlightEvent
{
    [TestFixture]
    class SeperationEventDetectorTest
    {
        private ISeperationEventDetector _uut;
        private IFlightTrackManager _datasource;
        private IFlightTrack _flight1a, _flight1b, _flight1c, _flight2a, _flight2b, _flight2c;
        private int _flightTracksUpdatedCounter;
        private int _SeperationEventCount;

        private SeperationEvent _lastDetectedSeperationEvent;

  

        [SetUp]
        public void SetUp()
        {
            _flightTracksUpdatedCounter = 0;

            _flight1a = Substitute.For<IFlightTrack>();
            _flight1b = Substitute.For<IFlightTrack>();
            _flight1c = Substitute.For<IFlightTrack>();
            _flight2a = Substitute.For<IFlightTrack>();
            _flight2b = Substitute.For<IFlightTrack>();
            _flight2c = Substitute.For<IFlightTrack>();

            _datasource = Substitute.For<IFlightTrackManager>();
            _datasource.FlightTracksUpdated += (sender, args) => _flightTracksUpdatedCounter++;

            _uut = new SeperationEventDetector(_datasource);
            _uut.SeperationEventDetected += (sender, args) =>
            {
                _lastDetectedSeperationEvent = args.DetectedEvent;
                _SeperationEventCount++;
            };
        }

        [Test]
        public void OnFlightUpdatedSeperationEventDetect_TwoFlightsSeperate_TwoEnterOneEvent()
        {
            _flight1a.GetCurrentPosition().Returns(new Vector2(5000, 7050));
            _flight1b.GetCurrentPosition().Returns(new Vector2(5000, 6960));
            _flight1c.GetCurrentPosition().Returns(new Vector2(5000, 6850));

            _flight2a.GetCurrentPosition().Returns(new Vector2(5000, 2000));
            _flight2b.GetCurrentPosition().Returns(new Vector2(5000, 2100));
            _flight2c.GetCurrentPosition().Returns(new Vector2(5000, 2200));

            _flight1a.GetCurrentAltitude().Returns(700);
            _flight1b.GetCurrentAltitude().Returns(700);
            _flight1c.GetCurrentAltitude().Returns(700);
            _flight2a.GetCurrentAltitude().Returns(600);
            _flight2b.GetCurrentAltitude().Returns(600);
            _flight2c.GetCurrentAltitude().Returns(600);

            var args1 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1a, _flight2a }); //Far enough
            var args2 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1b, _flight2b }); //too close
            //var args3 = new FlightTracksUpdatedEventArgs(new List<IFlightTrack> { _flight1c, _flight2c }); //still too close

            //Act
            _datasource.FlightTracksUpdated += Raise.EventWith(args1);
            _datasource.FlightTracksUpdated += Raise.EventWith(args2);
            //_datasource.FlightTracksUpdated += Raise.EventWith(args3);



            Assert.That(_SeperationEventCount, Is.EqualTo(1));
            Assert.That(_flightTracksUpdatedCounter,Is.EqualTo(2));
        }

        [Test]
        public void SeperationEventDectector_Tracksconflicting_InRangeSameAltitude()
        {
            //Arrange
            _flight1a.GetCurrentAltitude().Returns(800);
            _flight2a.GetCurrentAltitude().Returns(800);
            _flight1a.GetCurrentPosition().Returns(new Vector2(3000, 3000));
            _flight2a.GetCurrentPosition().Returns(new Vector2(4000, 4000));

            //Assert
            Assert.That(_uut.TracksConflicting(_flight1a, _flight2a), Is.True);
        }
        [Test]
        public void SeperationEventDectector_Tracksconflicting_InRangeSameRegion()
        {
            //Arrange
            _flight1a.GetCurrentAltitude().Returns(800);
            _flight2a.GetCurrentAltitude().Returns(1099);
            _flight1a.GetCurrentPosition().Returns(new Vector2(3500, 3500));
            _flight2a.GetCurrentPosition().Returns(new Vector2(3500, 3500));

            //Assert
            Assert.That(_uut.TracksConflicting(_flight1a, _flight2a), Is.True);
        }
        [Test]
        public void SeperationEventDectector_Tracksconflicting_OutOfRangeSameRegion()
        {
            //Arrange
            _flight1a.GetCurrentAltitude().Returns(1200);
            _flight2a.GetCurrentAltitude().Returns(800);
            _flight1a.GetCurrentPosition().Returns(new Vector2(3500, 3500));
            _flight2a.GetCurrentPosition().Returns(new Vector2(3500, 3500));


            //Assert
            Assert.That(_uut.TracksConflicting(_flight1a, _flight2a), Is.False);
        }
        [Test]
        public void SeperationEventDectector_Tracksconflicting_OutOfRangeSameAltitude()
        {
            //Arrange
            _flight1a.GetCurrentAltitude().Returns(800);
            _flight2a.GetCurrentAltitude().Returns(800);
            _flight1a.GetCurrentPosition().Returns(new Vector2(2000, 2000));
            _flight2a.GetCurrentPosition().Returns(new Vector2(7000, 7000));


            //Assert
            Assert.That(_uut.TracksConflicting(_flight1a, _flight2a), Is.False);
        }
    }
}
