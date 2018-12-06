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

namespace AirTrafficMonitor.Test.Unit.DataConversion
{
    [TestFixture]
    class DataConversionTest
    {
        private IFlightTrackDataSource _uut;
        private ITransponderReceiver _testTransponderReceiver;

        private int _eventCounter;

        [SetUp]
        public void SetUp()
        {
            _eventCounter = 0;

            _testTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _uut = new DataConverter(_testTransponderReceiver);
            _uut.FlightTrackDataReady += (o, args) =>
            {
                _eventCounter++;
            };
        }
        
        [Test]
        public void OnTransponderDataReady_FlightTrackDataReadyEventTriggered()
        {
            //Arrange
            var _testRawData = new List<string>() { "ATR423;39045;12932;14000;20151006213456789" };

            //Act
            _testTransponderReceiver.TransponderDataReady += Raise.EventWith(this, new RawTransponderDataEventArgs(_testRawData));

            // Assert
            Assert.That(_eventCounter, Is.EqualTo(1));
        }

        [Test]
        public void OnTransponderDataReady10Times_FlightTrackDataReadyEventTriggered10Times()
        {
            //Arrange
            var _testRawData = new List<string>() { "ATR423;39045;12932;14000;20151006213456789" };

            //Act
            for (int i = 0; i < 10; i++)
            {
                _testTransponderReceiver.TransponderDataReady += Raise.EventWith(this, new RawTransponderDataEventArgs(_testRawData)); 
            }

            // Assert
            Assert.That(_eventCounter, Is.EqualTo(10));
        }

        [TestCase("ATR423;39045;12932;14000;20151006213456789", "ATR423")]
        public void OnTransponderDataReady_TransponderdataToTrackDataSource_OneEventOneEntry(string rawdata, string testTag)
        {
            _eventCounter = 0;
            // Arrange
            var testRawData = new List<string>() { rawdata };
            var rawDataArgs = new RawTransponderDataEventArgs(testRawData);
            var testFlightTrackData = new FlightTrackDataEventArgs(new List<FTDataPoint>());

            // Expression to set test data when event is occuring for testing data aswell as counting events.
            _uut.FlightTrackDataReady += (o, args) => testFlightTrackData.FTDataPoints = args.FTDataPoints;
            // Act
            _testTransponderReceiver.TransponderDataReady += Raise.EventWith(this, rawDataArgs);

            // Assert
            Assert.That(_eventCounter, Is.EqualTo(1));
            Assert.That(testTag, Is.EqualTo(testFlightTrackData.FTDataPoints.First().Tag));
        }
        [TestCase("ATR423;39045;12932;14000;20151006213456789", "ATR423")]
        public void OnTransponderDataReady_TransponderdataToTrackDataSource_TwoEventTwoEntry(string rawdata, string testTag)
        {
            _eventCounter = 0;
            // Arrange
            var testRawData = new List<string>() { rawdata };
            var rawDataArgs = new RawTransponderDataEventArgs(testRawData);
            var testFlightTrackData = new FlightTrackDataEventArgs(new List<FTDataPoint>());

            // Expression to set test data when event is occuring for testing data aswell as counting events.
            _uut.FlightTrackDataReady += (o, args) => testFlightTrackData.FTDataPoints = args.FTDataPoints;
            
            // Act
            _testTransponderReceiver.TransponderDataReady += Raise.EventWith(this, rawDataArgs);
            _testTransponderReceiver.TransponderDataReady += Raise.EventWith(this, rawDataArgs);

            // Assert
            Assert.That(_eventCounter, Is.EqualTo(2));
            Assert.That(testTag, Is.EqualTo(testFlightTrackData.FTDataPoints.First().Tag));

        }
    }
}
