using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Unit.Test
{
    [TestFixture]
    public class CalculatorUnitTest
    {
        // Add(a, b)
        [Test]
        public void Add_2And6Returns8()
        {
            var uut = new Calculator();
            Assert.That(uut.Add(2,6), Is.EqualTo(8));
        }
        [Test]
        public void Add_10And99Returns109()
        {
            var uut = new Calculator();
            Assert.That(uut.Add(10, 99), Is.EqualTo(109));
        }
        [Test]
        public void Add_Minus52And99Returns47()
        {
            var uut = new Calculator();
            Assert.That(uut.Add(-52, 99), Is.EqualTo(47));
        }
        [Test]
        public void Add_Minus999AndMinus99ReturnsMinus1098()
        {
            var uut = new Calculator();
            Assert.That(uut.Add(-999, -99), Is.EqualTo(-1098));
        }

        // Subtract(a, b)
        [Test]
        public void Subtract_40Minus20()
        {
            var uut = new Calculator();
            Assert.That(uut.Subtract(40, 20), Is.EqualTo(20));
        }
        [Test]
        public void Subtract_40SubtractMinus40()
        {
            var uut = new Calculator();
            Assert.That(uut.Subtract(40, -40), Is.EqualTo(80));
        }
        [Test]
        public void Subtract_Minus20SubtractMinus40()
        {
            var uut = new Calculator();
            Assert.That(uut.Subtract(-20, -40), Is.EqualTo(20));
        }

        // Multiply(a, b)
        [Test]
        public void Multiply_40Times2()
        {
            var uut = new Calculator();
            Assert.That(uut.Multiply(40, 2), Is.EqualTo(80));
        }
        [Test]
        public void Multiply_0Times1()
        {
            var uut = new Calculator();
            Assert.That(uut.Multiply(0, 1), Is.EqualTo(0));
        }
        [Test]
        public void Multiply_0TimesRandomNumber()
        {
            var uut = new Calculator();
            Random random = new Random();
            double rnd = random.NextDouble();
            Assert.That(uut.Multiply(rnd, 0), Is.EqualTo(0));
        }
        [Test]
        public void Multiply_Minus22TimesMinus3()
        {
            var uut = new Calculator();
            Assert.That(uut.Multiply(-22, -3), Is.EqualTo(66));
        }

        // Divide(a, b)
        [Test]
        public void Divide_90DividedBy3()
        {
            var uut = new Calculator();
            Assert.That(uut.Divide(90, 3), Is.EqualTo(30));
        }
        [Test]
        public void Divide_90DividedBy1()
        {
            var uut = new Calculator();
            Assert.That(uut.Divide(90, 1), Is.EqualTo(90));
        }
        [Test]
        public void Divide_90DividedByOneHalf()
        {
            var uut = new Calculator();
            Assert.That(uut.Divide(90, 0.5), Is.EqualTo(180));
        }

        [Test]
        // Power(a, b)
        public void Power_3RaisedToTheExpOf2()
        {
            var uut = new Calculator();
            Assert.That(uut.Power(3, 2), Is.EqualTo(9));
        }
        public void Power_3RaisedToTheExpOf1()
        {
            var uut = new Calculator();
            Assert.That(uut.Power(3, 1), Is.EqualTo(3));
        }
        public void Power_3RaisedToTheExpOf0()
        {
            var uut = new Calculator();
            Assert.That(uut.Power(3, 0), Is.EqualTo(1));
        }

        // Accumulator save
        [Test]
        public void Accumulator_EqualToResultAfterAdd()
        {
            var uut = new Calculator();
            var calcResult = uut.Add(3, 2);
            Assert.That(uut.Accumulator, Is.EqualTo(calcResult));
        }
        [Test]
        public void Accumulator_SameAsResultAfterSubtract()
        {
            var uut = new Calculator();
            var calcResult = uut.Subtract(3, 2);
            Assert.That(uut.Accumulator, Is.EqualTo(calcResult));
        }
        [Test]
        public void Accumulator_SameAsResultAfterPower()
        {
            var uut = new Calculator();
            var calcResult = uut.Power(3, 2);
            Assert.That(uut.Accumulator, Is.EqualTo(calcResult));
        }
        [Test]
        public void Accumulator_SameAsResultAfterTwoCalculations()
        {
            var uut = new Calculator();
            var calcResult = uut.Add(3, 2);
            Assert.That(uut.Accumulator, Is.EqualTo(calcResult));
            var calcResult1 = uut.Power(5, 6);
            Assert.That(uut.Accumulator, Is.EqualTo(calcResult1));
        }
        // Accumulator clear
        [Test]
        public void Accumulator_ClearAfterNothing()
        {
            var uut = new Calculator();
            uut.Clear();
            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }
        [Test]
        public void Accumulator_ClearMultipleTimes()
        {
            var uut = new Calculator();
            uut.Power(3, 2);
            uut.Clear();
            uut.Power(7, 2);
            uut.Clear();
            uut.Power(3, 4);
            uut.Clear();
            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }
        [Test]
        public void Accumulator_ClearAfterCalculation()
        {
            var uut = new Calculator();
            uut.Power(3, 2);
            uut.Clear();
            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }

        // Add(a)
        [Test]
        public void Add_2And2()
        {
            var uut = new Calculator();
            Assert.That(uut.Add(2), Is.EqualTo(4));
        }
        [Test]
        public void Add_Minus3PlusMinus3()
        {
            var uut = new Calculator();
            Assert.That(uut.Add(-3), Is.EqualTo(-6));
        }
        [Test]
        public void Add_0Plus0()
        {
            var uut = new Calculator();
            Assert.That(uut.Add(0), Is.EqualTo(0));
        }

        // Subtract(a)
        [Test]
        public void Subtract_3Minus3()
        {
            var uut = new Calculator();
            Assert.That(uut.Subtract(3), Is.EqualTo(0));
        }
        [Test]
        public void Subtract_10Minus10()
        {
            var uut = new Calculator();
            Assert.That(uut.Subtract(10), Is.EqualTo(0));
        }
        [Test]
        public void Subtract_0Minus0()
        {
            var uut = new Calculator();
            Assert.That(uut.Subtract(0), Is.EqualTo(0));
        }

        // Multiply(a)
        [Test]
        public void Multiply_33Times33()
        {
            var uut = new Calculator();
            Assert.That(uut.Multiply(33), Is.EqualTo(1089));
        }
        [Test]
        public void Multiply_1Times1()
        {
            var uut = new Calculator();
            Assert.That(uut.Multiply(1), Is.EqualTo(1));
        }
        [Test]
        public void Multiply_0Times0()
        {
            var uut = new Calculator();
            Assert.That(uut.Multiply(0), Is.EqualTo(0));
        }

        // Divide(a)
        [Test]
        public void Divide_1DividedBy1()
        {
            var uut = new Calculator();
            Assert.That(uut.Divide(1), Is.EqualTo(1));
        }
        [Test]
        public void Divide_3DividedBy3()
        {
            var uut = new Calculator();
            Assert.That(uut.Divide(3), Is.EqualTo(1));
        }
        [Test]
        public void Divide_RndDividedBySelfEquals1()
        {
            var uut = new Calculator();
            Random random = new Random();
            double rnd = random.NextDouble();
            Assert.That(uut.Divide(rnd), Is.EqualTo(1));
        }
        [Test]
        public void Divide_63163766123963DividedBy63163766123963()
        {
            var uut = new Calculator();
            Assert.That(uut.Divide(63163766123963), Is.EqualTo(1));
        }

        // Power(a)
        [Test]
        public void Power_1RaisedToTheExpOf1()
        {
            var uut = new Calculator();
            Assert.That(uut.Power(1), Is.EqualTo(1));
        }
        [Test]
        public void Power_2RaisedToTheExpOf2()
        {
            var uut = new Calculator();
            Assert.That(uut.Power(2), Is.EqualTo(4));
        }
        [Test]
        public void Power_9RaisedToTheExpOf9()
        {
            var uut = new Calculator();
            Assert.That(uut.Power(9), Is.EqualTo(387420489));
        }
    }
}
