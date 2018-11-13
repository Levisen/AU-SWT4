using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using TransponderReceiver;

namespace AirTrafficMonitor.Unit.Test
{
    class FlightCourseCalculatorTest
    {
        private IFlightCourseCalculator _uut;

        private Vector2 test1_previous_position1;
        private Vector2 test1_current_position1;
        private float test1_result;


        [SetUp]
        public void SetUp()
        {
            _uut = new FlightCourseCalculator();

            //En test case består af
            test1_previous_position1 = new Vector2(1, 2);
            test1_current_position1 = new Vector2(2, 2);
            test1_result = 90;
        }

        [Test]
        public void FlightCourseCalculatorTest_East()
        {
            Assert.That(_uut.CalculateCurrentCourse(test1_previous_position1, test1_current_position1), Is.EqualTo(test1_result));
        }
    }
}
