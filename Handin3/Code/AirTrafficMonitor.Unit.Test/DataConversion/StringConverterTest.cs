using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TransponderReceiver;
using NSubstitute;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;


namespace AirTrafficMonitor.Test.Unit
{
    class StringConverterTest
    {
        private ITransponderDataConverter _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new DataConverter(Substitute.For<ITransponderReceiver>());
        }


        [TestCase("ATR423;39045;12932;14000;20151006213456789", "ATR423", 39045, 12932, 14000, 2015, 10, 06, 21, 34, 56,
            789)]
        [TestCase("KUN123;18756;26584;12323;20181022070621359", "KUN123", 18756, 26584, 12323, 2018, 10, 22, 07, 06, 21,
            359)]
        public void ConvertTransponderString_StringInput_FTDataPointOut(string raw, string tag, int xC, int yC, int a,
            int y, int mO, int d, int ho, int min, int sec, int mSec)
        {
            // Arrange
            FTDataPoint _testFTDataPoint = new FTDataPoint();

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
    }
}
