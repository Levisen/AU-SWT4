using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
using AirTrafficMonitor.Test.Unit.TestData;
using Castle.Core.Smtp;


namespace AirTrafficMonitor.Test.Unit.FlightManagement
{
    [TestFixture]
    class SensorAreaManagerTest
    {
        int _inputEventCounter;
        int _outputEventCounter;

        private IFlightTrackManager _uut;

        private IFlightTrackDataSource _testFlightTrackDataSource;
        private List<IFlightTrack> _lastFlightTracksUpdated;

        [SetUp]
        public void SetUp()
        {
            _inputEventCounter = 0;
            _outputEventCounter = 0;

            _testFlightTrackDataSource = Substitute.For<IFlightTrackDataSource>();
            _testFlightTrackDataSource.FlightTrackDataReady += (sender, args) => _inputEventCounter++;
            _uut = new SensorAreaManager(_testFlightTrackDataSource);
            _uut.FlightTracksUpdated += (sender, args) =>
            {
                _outputEventCounter++;
                _lastFlightTracksUpdated = args.UpdatedFlights;
            };
        }


        [Test]
        public void OnFlightTrackDataReady_FlightTracksUpdatedEventTriggered()
        {
            // Arrange
            var dp = new FTDataPoint("TAG123", 4000, 4000, 2000, DateTime.Now);
            var args = new FlightTrackDataEventArgs(new List<FTDataPoint>{dp,dp});

            // Act
            _testFlightTrackDataSource.FlightTrackDataReady += Raise.EventWith(args);

            // Assert
            Assert.That(_outputEventCounter, Is.EqualTo(1));
        }

        [Test, TestCaseSource(typeof(FlightTrackDataEventTestData), "OnTransponderDataReadyCases")]
        public void OnFlightTrackDataReady_FlightTrackDataSourceToSensorAreaManager_OneEventOneEntry(List<FTDataPoint> argsData, FlightTracksUpdatedEventArgs multipleData, List<IFlightTrack> tracker)
        {
            // Arrange
            var testFlightTrackDataArgs = new FlightTrackDataEventArgs(argsData);
            var testDataAfterEvent = new FlightTracksUpdatedEventArgs(new List<IFlightTrack>());
            _uut.FlightTracksUpdated +=
                (sender, args) => testDataAfterEvent.UpdatedFlights = args.UpdatedFlights;

            // Act
            _testFlightTrackDataSource.FlightTrackDataReady += Raise.EventWith(this, testFlightTrackDataArgs);

            // Assert
            Assert.That(_outputEventCounter, Is.EqualTo(1));
            Assert.That(testDataAfterEvent.UpdatedFlights.Count, Is.EqualTo(multipleData.UpdatedFlights.Count));
        }

        [Test, TestCaseSource(typeof(FlightTrackDataEventTestData), "OnTransponderDataReadyCases")]
        public void OnFlightTrackDataReady_FlightTrackDataSourceToFlightTrackMultiple_FiveEventOneEntry(List<FTDataPoint> argsData, FlightTracksUpdatedEventArgs multipleData, List<IFlightTrack> tracker)
        {
            // Arrange
            var testFlightTrackDataArgs = new FlightTrackDataEventArgs(argsData);
            var testDataAfterEvent = new FlightTracksUpdatedEventArgs(new List<IFlightTrack>());

            _uut.FlightTracksUpdated +=
                (sender, args) => testDataAfterEvent.UpdatedFlights = args.UpdatedFlights;

            // Act
            for (int i = 0; i < 5; i++)
            {
                _testFlightTrackDataSource.FlightTrackDataReady += Raise.EventWith(this, testFlightTrackDataArgs);
            }

            // Assert
            Assert.That(_outputEventCounter, Is.EqualTo(5));
            Assert.That(testDataAfterEvent.UpdatedFlights.Count, Is.EqualTo(multipleData.UpdatedFlights.Count));
        }
    }
}
