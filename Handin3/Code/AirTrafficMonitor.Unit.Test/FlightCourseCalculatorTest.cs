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

        //private Vector2 test1_previous_position1;
        //private Vector2 test1_current_position1;
        //private float test1_result;

        [SetUp]
        public void SetUp()
        {
            _uut = new FlightCourseCalculator();
        }

        [Test]
        //[TestCase(Vector1 X, Vector1 Y, Vector2 X, Vector2 Y, Vinkel)]

        [TestCase(1,2,2,2,90)]
        
        [TestCase(2 ,2, 4, 4, 225)]

        //[TestCase(x,x,x,x,xxx)]

        //[TestCase(x,x,x,x,xxx)]

        //[TestCase(x,x,x,x,xxx)]

        //[TestCase(x,x,x,x,xxx)]

        //[TestCase(x,x,x,x,xxx)]

        //[TestCase(x,x,x,x,xxx)]

        //[TestCase(x,x,x,x,xxx)]

        //[TestCase(x,x,x,x,xxx)]

        //[TestCase(x,x,x,x,xxx)]

        //[TestCase(x,x,x,x,xxx)]

        public void FlightCourseCalculatorTest_East(int Vector1x, int Vector1y, int Vector2x, int Vector2y, decimal angleCourse)
        {
            var vector1 = new Vector2(Vector1x,Vector1y);
            var vector2 = new Vector2(Vector2x, Vector2y);
            var result = _uut.CalculateCurrentCourse(vector1, vector2);

            Assert.That(result, Is.EqualTo(angleCourse));
        }
    }
}
