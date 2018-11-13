using AirTrafficMonitor.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Unit.Test
{
    class FlightVelocityCalculatorTest
    {
        private IFlightVelocityCalculator _uut;

        private Vector2 previous_position1;
        private Vector2 current_position1;
        private DateTime timestamp_1;
        private DateTime timestamp_2;
        private float test1_result;

        [SetUp]
        public void SetUp()
        {
            _uut = new FlightVelocityCalculator();
            
            //1 test case består af
            previous_position1 = new Vector2(1, 2);
            current_position1 = new Vector2(2, 2);
            timestamp_1 = new DateTime(2018, 11, 04, 8, 15, 29, 254);
            timestamp_2 = new DateTime(2018, 11, 04, 8, 15, 30, 788);
            test1_result = 6544;

        }

        [Test]
        public void FlightCourseCalculatorTest_East()
        {
            Assert.That(_uut.CalculateCurrentVelocity(previous_position1, timestamp_1, current_position1, timestamp_2), Is.EqualTo(9855));
        }
    }
}
