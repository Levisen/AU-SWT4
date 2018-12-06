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
using System.Collections;
using AirTrafficMonitor.Test.Unit.Calculators.TestData;

namespace AirTrafficMonitor.Test.Unit.Calculators
{
    [TestFixture]
    public class FlightCourseCalculatorTest
    {
        private IFlightCourseCalculator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new FlightCourseCalculator();
        }

        [Test, TestCaseSource(typeof(FlightCalculatorsTestCaseData), "CourseTestCases")]
        public double CalculateCurrentCourse_TestCases(int Vector1x, int Vector1y, int Vector2x, int Vector2y)
        {
            var vector1 = new Vector2(Vector1x, Vector1y);
            var vector2 = new Vector2(Vector2x, Vector2y);
            
            return Math.Round(_uut.CalculateCurrentCourse(vector1, vector2), 3);
        }
    }


}
