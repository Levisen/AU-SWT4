using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TransponderReceiver;
using NSubstitute;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
using System.Numerics;

namespace AirTrafficMonitor.Test.Unit.Flight
{
    class FlightTrackTest
    {
        private IFlightTrack _uut;

        private FTDataPoint _firstDataPoint;
        private FTDataPoint _secondDataPoint;

        private DateTime _testTime = DateTime.Now;
        private LinkedList<FTDataPoint> _testFullDataLog;

        [SetUp]
        public void SetUp()
        {
            _firstDataPoint = new FTDataPoint("ASH000", 2000, 2000, 22000, _testTime);
            _secondDataPoint = new FTDataPoint("ASH000", 1850, 2000, 22000, _testTime.AddSeconds(1.00));

            _uut = new AirTrafficMonitor.Flight(_firstDataPoint);

            //_uut.AddDataPoint(_firstDataPoint); //needed for check if velocity and course is correct set
            //_uut.AddDataPoint(_secondDataPoint);

            _testFullDataLog = new LinkedList<FTDataPoint>();
            _testFullDataLog.AddFirst(_firstDataPoint);
            _testFullDataLog.AddFirst(_secondDataPoint);
        }

        [Test]
        public void AddDataPoint_GetTag_CorrectTag()
        {
            // Act
            _uut.AddDataPoint(_firstDataPoint);
            // Assert
            Assert.That(_uut.GetTag(), Is.EqualTo(_firstDataPoint.Tag));
        }

        [Test]
        public void AddDataPoint_GetCurrentAltitute_CorrectAltitude()
        {
            // Act
            _uut.AddDataPoint(_firstDataPoint);
            // Assert
            Assert.That(_uut.GetCurrentAltitude(), Is.EqualTo(_firstDataPoint.Altitude));
        }
        [Test]
        public void AddDataPoint_GetCurrentPosition_CorrectPosition()
        {
            // Act
            _uut.AddDataPoint(_firstDataPoint);
            // Assert
            Assert.That(_uut.GetCurrentPosition(), Is.EqualTo(new Vector2(2000, 2000)));
        }


        //[Test]
        //public void AddDataPoint_GetCurrentVelocity_CorrectVelocity()
        //{
        //    // Act
        //    _uut.AddDataPoint(_firstDataPoint);
        //    // Assert
        //    Assert.That(_uut.GetCurrentVelocity(), Is.EqualTo(156));
        //}

        //[Test]
        //public void AddDataPoint_GetCurrentCourse_CorrectCourse()
        //{
        //    // Act
        //    _uut.AddDataPoint(_firstDataPoint);
        //    // Assert
        //    Assert.That(_uut.GetCurrentCourse(), Is.EqualTo(156));
        //}

        [Test]
        public void AddDataPoint_GetNewestDataPoint_CorrectNewestDataPoint()
        {
            // Act
            _uut.AddDataPoint(_firstDataPoint);
            _uut.AddDataPoint(_secondDataPoint);
            // Assert
            Assert.That(_uut.GetNewestDataPoint(), Is.EqualTo(_secondDataPoint));
        }

        [Test]
        public void AddDataPoint_GetFullDataLog_CorrectFullDataLog()
        {
            // Act
            _uut.AddDataPoint(_firstDataPoint);
            _uut.AddDataPoint(_secondDataPoint);
            // Assert
            Assert.That(_uut.GetFullDataLog(), Is.EqualTo(_testFullDataLog));
        }
    }
}
