using AirTrafficMonitor.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Unit.Test.TestData;

namespace AirTrafficMonitor.Unit.Test.Class
{
    [TestFixture]
    class FlightVelocityCalculatorTest
    {
        private IFlightVelocityCalculator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new FlightVelocityCalculator();
            
        }

        [Test, TestCaseSource(typeof(FlightCalculatorsTestCaseData), "VelocityTestCases")]
        public double CalculateCurrentVelocity_TestCases(int Vector1x, int Vector1y, int Vector2x, int Vector2y, int seconds, int milliseconds)
        {
            var vector1 = new Vector2(Vector1x, Vector1y);
            var vector2 = new Vector2(Vector2x, Vector2y);
            DateTime timestamp_1 = DateTime.Now;
            DateTime timestamp_2 = timestamp_1.AddSeconds(seconds).AddMilliseconds(milliseconds);

            return _uut.CalculateCurrentVelocity(vector1, timestamp_1, vector2, timestamp_2);
        }
    }
}
