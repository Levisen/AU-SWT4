using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;
using AirTrafficMonitor.Events;
using AirTrafficMonitor;

namespace AirTrafficMonitor.Unit.Test.Event
{
    [TestFixture]
    class TransponderDataEvent
    {
        private IFlightTrackDataSource _uut;
        private int _eventCounter;
        private ITransponderReceiver _testTransponderReceiver;

        [SetUp]
        public void SetUp()
        {
            _testTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _uut = new DataConverter(_testTransponderReceiver);
        }
        [Test]
        public void OnTransponderDataReady_TransponderdataToTrackDataSource_NoneEvent()
        {
            _eventCounter = 0;
            // Arrange

            // Expression to set test data when event is occuring for testing data aswell as counting events.
            _uut.FlightTrackDataReady += (o, args) =>
            {
                _eventCounter++;
            };
            // Act

            // Assert
            Assert.That(_eventCounter, Is.EqualTo(0));

        }

        [TestCase("ATR423;39045;12932;14000;20151006213456789", "ATR423")]
        public void OnTransponderDataReady_TransponderdataToTrackDataSource_OneEventOneEntry(string rawdata, string testTag)
        {
            _eventCounter = 0;
            // Arrange
            var _testRawData = new List<string>() { rawdata };
            var _rawDataArgs = new RawTransponderDataEventArgs(_testRawData);
            var _testFlightTrackData = new FlightTrackDataEventArgs(new List<FTDataPoint>());

            // Expression to set test data when event is occuring for testing data aswell as counting events.
            _uut.FlightTrackDataReady += (o, args) =>
            {
                _testFlightTrackData.FTDataPoints = args.FTDataPoints;
                _eventCounter++;
            };
            // Act
            _testTransponderReceiver.TransponderDataReady += Raise.EventWith(this, _rawDataArgs);

            // Assert
            Assert.That(_eventCounter, Is.EqualTo(1));
            Assert.That(testTag, Is.EqualTo(_testFlightTrackData.FTDataPoints.First().Tag));

        }
        [TestCase("ATR423;39045;12932;14000;20151006213456789", "ATR423")]
        public void OnTransponderDataReady_TransponderdataToTrackDataSource_TwoEventTwoEntry(string rawdata, string testTag)
        {
            _eventCounter = 0;
            // Arrange
            var _testRawData = new List<string>() { rawdata };
            var _rawDataArgs = new RawTransponderDataEventArgs(_testRawData);
            var _testFlightTrackData = new FlightTrackDataEventArgs(new List<FTDataPoint>());

            // Expression to set test data when event is occuring for testing data aswell as counting events.
            _uut.FlightTrackDataReady += (o, args) =>
            {
                _testFlightTrackData.FTDataPoints = args.FTDataPoints;
                _eventCounter++;
            };
            // Act
            _testTransponderReceiver.TransponderDataReady += Raise.EventWith(this, _rawDataArgs);
            _testTransponderReceiver.TransponderDataReady += Raise.EventWith(this, _rawDataArgs);

            // Assert
            Assert.That(_eventCounter, Is.EqualTo(2));
            Assert.That(testTag, Is.EqualTo(_testFlightTrackData.FTDataPoints.First().Tag));

        }
    }
}
