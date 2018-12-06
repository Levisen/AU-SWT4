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


namespace AirTrafficMonitor.Unit.Test.FlightManagement
{
    [TestFixture]
    class SensorAreaManagerTest
    {
        int _eventCounter = 0;

        private IFlightTrackManager _uut;

        private IFlightTrackDataSource _testFlightTrackDataSource;

        [SetUp]
        public void SetUp()
        {
            _testFlightTrackDataSource = Substitute.For<IFlightTrackDataSource>();
            _uut = new SensorAreaManager(_testFlightTrackDataSource);
        }


        [Test]
        public void OnFlightTrackDataReady_FlightTrackDataToFlightTrackMultiple_NoneEvent()
        {
            _eventCounter = 0;
            // Arrange

            // Expression to set test data when event is occuring for testing data aswell as counting events.
            _uut.FlightTracksUpdated += (o, args) =>
            {
                _eventCounter++;
            };
            // Act

            // Assert
            Assert.That(_eventCounter, Is.EqualTo(0));
        }

        [Test, TestCaseSource(typeof(FlightTrackDataEventTestData), "OnTransponderDataReadyCases")]
        public void OnFlightTrackDataReady_FlightTrackDataSourceToSensorAreaManager_OneEventOneEntry(List<FTDataPoint> argsData, FlightTracksUpdatedEventArgs multipleData, List<IFlightTrack> tracker)
        {
            _eventCounter = 0;
            // Arrange
            var _testFlightTrackDataArgs = new FlightTrackDataEventArgs(argsData);
            var _testDataAfterEvent = new FlightTracksUpdatedEventArgs(new List<IFlightTrack>());

            // Expression to set test data when event is occuring for testing data aswell as counting events.
            _uut.FlightTracksUpdated += (o, args) =>
            {
                _testDataAfterEvent.UpdatedFlights = args.UpdatedFlights;
                _eventCounter++;
            };
            // Act
            _testFlightTrackDataSource.FlightTrackDataReady += Raise.EventWith(this,_testFlightTrackDataArgs);

            // Assert
            Assert.That(_eventCounter, Is.EqualTo(1));
            Assert.That(_testDataAfterEvent.UpdatedFlights.Count, Is.EqualTo(multipleData.UpdatedFlights.Count));
        }

        [Test, TestCaseSource(typeof(FlightTrackDataEventTestData), "OnTransponderDataReadyCases")]
        public void OnFlightTrackDataReady_FlightTrackDataSourceToFlightTrackMultiple_FiveEventOneEntry(List<FTDataPoint> argsData, FlightTracksUpdatedEventArgs multipleData, List<IFlightTrack> tracker)
        {
            _eventCounter = 0;
            // Arrange
            var _testFlightTrackDataArgs = new FlightTrackDataEventArgs(argsData);
            var _testDataAfterEvent = new FlightTracksUpdatedEventArgs(new List<IFlightTrack>());

            // Expression to set test data when event is occuring for testing data aswell as counting events.
            _uut.FlightTracksUpdated += (o, args) =>
            {
                _testDataAfterEvent.UpdatedFlights = args.UpdatedFlights;
                _eventCounter++;
            };
            // Act
            for(int i = 0; i < 5; i++)
            {
                _testFlightTrackDataSource.FlightTrackDataReady += Raise.EventWith(this, _testFlightTrackDataArgs);
            }

            // Assert
            Assert.That(_eventCounter, Is.EqualTo(5));
            Assert.That(_testDataAfterEvent.UpdatedFlights.Count, Is.EqualTo(multipleData.UpdatedFlights.Count));
        }
    }
}
