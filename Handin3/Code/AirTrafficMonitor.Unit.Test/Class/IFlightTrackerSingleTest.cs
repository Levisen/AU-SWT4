using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TransponderReceiver;
using NSubstitute;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
using System.Numerics;

namespace AirTrafficMonitor.Unit.Test.Class
{
    class IFlightTrackerSingleTest
    {
        private IFlightTrackerSingle _uut;
        private FTDataPoint _testDataPoint;
        private DateTime _testTime = DateTime.Now;
        private FTDataPoint _nullFtDataPoint;
        private LinkedList<FTDataPoint> _testFullDataLog;
        [SetUp]
        public void SetUp()
        {


            _nullFtDataPoint = new FTDataPoint("ASH000",2000,2000,22000,_testTime);
            _uut = new Flight(_nullFtDataPoint){};
            // Arrange
            _uut.AddDataPoint(_nullFtDataPoint); //needed for check if velocity and course is correct set
            _testDataPoint = new FTDataPoint("KKK123", 1844, 2000, 22000, _testTime.AddSeconds(1.00));
            // Act
            _uut.AddDataPoint(_testDataPoint);
            _testFullDataLog = new LinkedList<FTDataPoint>();
            _testFullDataLog.AddFirst(_nullFtDataPoint);
            _testFullDataLog.AddFirst(_testDataPoint);
        }
        [Test]
        public void AddDataPoint_GetTag_CorrectTag()
        {

            // Act
            _uut.AddDataPoint(_testDataPoint);
            // Assert
            Assert.That(_uut.GetTag(), Is.EqualTo(_testDataPoint.Tag));
        }
        [Test]
        public void AddDataPoint_GetCurrentAltitute_CorrectAltitude()
        {
            // Assert
            Assert.That(_uut.GetCurrentAltitude(), Is.EqualTo(_testDataPoint.Altitude));
        }
        [Test]
        public void AddDataPoint_GetCurrentVelocity_CorrectVelocity()
        {
            // Assert
            Assert.That(_uut.GetCurrentVelocity(), Is.EqualTo(156));
        }
        [Test]
        public void AddDataPoint_GetCurrentCourse_CorrectCourse()
        {
            // Assert
            Assert.That(_uut.GetCurrentCourse(), Is.EqualTo(156));
        }

        [Test]
        public void AddDataPoint_GetCurrentPosition_CorrectPosition()
        {
            // Assert
            Assert.That(_uut.GetCurrentPosition(), Is.EqualTo(new Vector2(1844,2000)));
        }
        [Test]
        public void AddDataPoint_GetNewestDataPoint_CorrectNewestDataPoint()
        {
            // Assert
            Assert.That(_uut.GetNewestDataPoint(), Is.EqualTo(_testDataPoint));
        }
        [Test]
        public void AddDataPoint_GetFullDataLog_CorrectFullDataLog()
        {
            // Assert
            Assert.That(_uut.GetFullDataLog(), Is.EqualTo(_testFullDataLog));
        }
    }
}
