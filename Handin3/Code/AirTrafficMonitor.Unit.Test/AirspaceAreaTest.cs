using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using NUnit.Framework;
using AirTrafficMonitor;
using AirTrafficMonitor.Test.Unit.TestData;
using AirTrafficMonitor.Unit.Test.TestData;

namespace AirTrafficMonitor.Unit.Test
{
    public class AirspaceAreaTest
    {
        private IAirspaceArea _uut;

        [SetUp]
        public void Setup()
        {
            //Setup for constructor test
            _uut = new AirspaceArea(10000, 15000, 90000, 95000, 500, 20000);
        }

        [Test]
        public void AirspaceArea_Height_PositiveCalculationOutput()
        {
            //Arrange
            float testHeigth = 95000 - 15000;
            //Assert
            Assert.That(_uut.Heigth(), Is.EqualTo(testHeigth));
        }
        [Test]
        public void AirspaceArea_Width_PositiveCalculationOutput()
        {
            //Arrange
            float testWidth = 90000 - 10000;
            //Assert
            Assert.That(_uut.Width(), Is.EqualTo(testWidth));
        }
        [Test]
        public void AirspaceArea_GetSouthWestCorner_AsVector()
        {
            //Arrange
            Vector2 southWest = new Vector2(10000,15000);
            //Assert
            Assert.That(_uut.GetSouthWestCorner(), Is.EqualTo(southWest));
        }
        [Test]
        public void AirspaceArea_GetNorthEastCorner_AsVector()
        {
            //Arrange
            Vector2 northEast = new Vector2(90000, 95000);
            //Assert
            Assert.That(_uut.GetNorthEastCorner(), Is.EqualTo(northEast));
        }

        [TestCaseSource(typeof(AirspaceAreaTestData), "IsInsideTestData")]
        public bool AirspaceArea_IsInside_TestCases(int x, int y, int altitude)
        {
            //Assert
            return _uut.IsInside(x, y, altitude);
        }
    }
}
