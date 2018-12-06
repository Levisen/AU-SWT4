using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AirTrafficMonitor.Test.Integration
{
    public class IT_1b_TransponderReceiverToFlightDataSource
    {
        private IFlightTrackDataSource _uut;
        private ITransponderReceiver _transponderReceiver;


        private int _inputEventCounter;
        private int _outputEventCounter;
        private List<FTDataPoint> _lastFlightTrackDataPoints;

        [SetUp]
        public void SetUp()
        {
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _transponderReceiver.TransponderDataReady += (o, args) => _inputEventCounter++;
            _uut  = new DataConverter(_transponderReceiver);
            _uut.FlightTrackDataReady += (o, args) =>
            {
                _lastFlightTrackDataPoints = args.FTDataPoints;
                _outputEventCounter++;
            };
        }

        [Test]
        public void OnTransponderDataReady_FlightTrackDataReadyEventTriggered()
        {
            //Arrange
            var inputData = new List<string>() { "ATR423;39045;12932;14000;20151006213456789", "KUN123;18756;26584;12323;20181022070621359" };

            //Act
            _transponderReceiver.TransponderDataReady += Raise.EventWith(this, new RawTransponderDataEventArgs(inputData));

            // Assert
            Assert.That(_inputEventCounter, Is.EqualTo(1));
            Assert.That(_outputEventCounter, Is.EqualTo(1));
        }

        [Test]
        public void OnTransponderDataReady_TwoStringsReceived_TwoDataPointsAvailable()
        {
            //Arrange
            var inputData = new List<string>() { "ATR423;39045;12932;14000;20151006213456789", "KUN123;18756;26584;12323;20181022070621359" };

            //Act
            _transponderReceiver.TransponderDataReady += Raise.EventWith(this, new RawTransponderDataEventArgs(inputData));

            // Assert
            Assert.That(inputData.Count, Is.EqualTo(2));
            Assert.That(_lastFlightTrackDataPoints.Count, Is.EqualTo(2));
        }

        [Test]
        public void OnTransponderDataReady_OneStringReceived_DataPointPropertiesCorrect()
        {
            //Arrange
            var inputData = new List<string>() { "ATR423;39045;12932;14000;20151006213456789" };
            var expectedTag = "ATR423";
            var expectedX = 39045;
            var expectedY = 12932;
            var expectedAlt = 14000;
            var expectedYear = 2015;
            var expectedMonth = 10;
            var expectedDay = 06;
            var expectedHour = 21;
            var expectedMinute = 34;
            var expectedSecond = 56;
            var expectedMillisecond = 789;
            var expectedTimeStamp =
                new DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond);

            //Act
            _transponderReceiver.TransponderDataReady += Raise.EventWith(this, new RawTransponderDataEventArgs(inputData));

            // Assert
            Assert.That(_lastFlightTrackDataPoints.Exists(dp => 
                dp.Tag == expectedTag 
                && dp.X == expectedX 
                && dp.Y == expectedY
                && dp.Altitude == expectedAlt
                && dp.TimeStamp  == expectedTimeStamp));
        }
    }
}
