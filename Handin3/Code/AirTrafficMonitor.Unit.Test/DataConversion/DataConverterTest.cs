using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TransponderReceiver;
using NSubstitute;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;

namespace AirTrafficMonitor.Test.Unit
{
    class DataConverterTest
    {
        private ITransponderDataConverter _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new DataConverter(Substitute.For<ITransponderReceiver>());
        }

        [TestCase("ATR423", "ATR423;39045;12932;14000;20151006213456789")]
        public void ConvertTransponderData_RawTransponderDataArgsEventTest_(string tag, string raw)
        {
            // Arrange
            // - Test
            FTDataPoint _testFTDataPoint = new FTDataPoint() { Tag = tag };
            List<FTDataPoint> _testListFTDataPoint = new List<FTDataPoint>() { _testFTDataPoint };
            FlightTrackDataEventArgs _testArgs = new FlightTrackDataEventArgs(_testListFTDataPoint);

            // - Setup Stringlist as raw transponder argument
            var _listStringTest = new List<string>();
            _listStringTest.Add(raw);


            // Act
            _testArgs = _uut.ConvertTransponderData(new RawTransponderDataEventArgs(_listStringTest));
            // Assert
            Assert.That(_testListFTDataPoint.First().Tag, Is.EqualTo(_testFTDataPoint.Tag));
        }
    }
}
