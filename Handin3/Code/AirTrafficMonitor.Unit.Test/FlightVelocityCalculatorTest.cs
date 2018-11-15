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
            //previous_position1 = new Vector2(1, 2);
            //current_position1 = new Vector2(2, 2);
            //test1_result = 6544;
        }
        [Test]
        
        [TestCase(1,1,2,2)]
        public void CalculateCurrentVelocity_Given2VectorsAndDateTime_(int Vector1x, int Vector1y, int Vector2x, int Vector2y)
        {
            var vector1 = new Vector2(Vector1x,Vector1y);
            var vector2 = new Vector2(Vector2x, Vector2y);

            timestamp_1 = new DateTime(2018, 10, 04, 15, 48, 47, 789);
            timestamp_2 = new DateTime(2018, 10, 04, 15, 48, 57, 789);
            test1_result = 6544;

            Assert.That(_uut.CalculateCurrentVelocity(vector1, timestamp_1, vector2, timestamp_2), Is.EqualTo(test1_result));
        }

        [Test]
        [TestCase(2,2,1,1)]
        public void CalculateCurrentVelocity_Given2VectorsAndDateTime_Test(int Vector1x, int Vector1y, DateTime vector1DateTime, int Vector2x, int Vector2y, DateTime vector2DateTime)
        {
            var vector1 = new Vector2(Vector1x, Vector1y);
            var vector2 = new Vector2(Vector2x, Vector2y);

            timestamp_1 = new DateTime(2018, 10, 04, 8, 15, 37, 789);
            timestamp_2 = new DateTime(2018, 10, 04, 8, 15, 27, 789);
            test1_result = 5848;

            Assert.That(_uut.CalculateCurrentVelocity(previous_position1, timestamp_1, current_position1, timestamp_2), Is.EqualTo(9855));
        }
    }
}
