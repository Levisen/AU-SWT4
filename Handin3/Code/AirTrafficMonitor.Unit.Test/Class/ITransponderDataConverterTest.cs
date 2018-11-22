using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TransponderReceiver;
using NSubstitute;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor.Unit.Test.ClassTests
{
    class ITransponderDataConverterTest
    {
        private ITransponderDataConverter _uut;
        private FTDataPoint _testFTDataPoint;
        private List<FTDataPoint> _testListFTDataPoint;

        [SetUp]
        public void SetUp()
        {
            _uut = new DataConverter(Substitute.For<ITransponderReceiver>());
        }

        [TestCase("ATR423;39045;12932;14000;20151006213456789","ATR423",39045,12932,14000,2015,10,06,21,34,56,789)]
        [TestCase("KUN123;18756;26584;12323;20181022070621359","KUN123",18756,26584,12323,2018,10,22,07,06,21,359)]
        public void ConvertTransponderString_StringInput_FTDataPointOut(string raw, string tag, int xC, int yC, int a, int y, int mO, int d, int ho, int min, int sec, int mSec)
        {
            // Arrange
            _testFTDataPoint = new FTDataPoint();

            // Act
            _testFTDataPoint = _uut.ConvertTransponderString(raw);

            // Assert
            Assert.That(_testFTDataPoint.Tag, Is.EqualTo(tag));
            Assert.That(_testFTDataPoint.X, Is.EqualTo(xC));
            Assert.That(_testFTDataPoint.Y, Is.EqualTo(yC));
            Assert.That(_testFTDataPoint.Altitude, Is.EqualTo(a));
            Assert.That(_testFTDataPoint.TimeStamp.Year, Is.EqualTo(y));
            Assert.That(_testFTDataPoint.TimeStamp.Month, Is.EqualTo(mO));
            Assert.That(_testFTDataPoint.TimeStamp.Day, Is.EqualTo(d));
            Assert.That(_testFTDataPoint.TimeStamp.Minute, Is.EqualTo(min));
            Assert.That(_testFTDataPoint.TimeStamp.Second, Is.EqualTo(sec));
            Assert.That(_testFTDataPoint.TimeStamp.Millisecond, Is.EqualTo(mSec));
        }


        [TestCase("ATR423", "ATR423;39045;12932;14000;20151006213456789")]
        public void ConvertTransponderData_RawTransponderDataArgsEventTest_(string tag, string raw)
        {
            // Arrange
            // - Test
            _testFTDataPoint = new FTDataPoint() { Tag = tag };
            _testListFTDataPoint = new List<FTDataPoint>();

            // - Setup Stringlist as raw transponder argument
            var _listStringTest = new List<string>();
            _listStringTest.Add(raw);


            // Act
            _testListFTDataPoint = _uut.ConvertTransponderData(new RawTransponderDataEventArgs(_listStringTest));
            // Assert
            Assert.That(_testListFTDataPoint.First().Tag, Is.EqualTo(_testFTDataPoint.Tag));
        }
    }
}
