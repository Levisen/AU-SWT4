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

        [Test]
        public void Subtract_40Minus20()
        {
            var uut = new Calculator();
            Assert.That(uut.Subtract(40, 20), Is.EqualTo(20));
        }
        [Test]
        public void Subtract_Minus20SubtractMinus40()
        {
            var uut = new Calculator();
            Assert.That(uut.Subtract(-20, -40), Is.EqualTo(20));
        }
        [Test]
        public void Multiply_40Times2()
        {
            var uut = new Calculator();
            Assert.That(uut.Multiply(40, 2), Is.EqualTo(80));
        }
        [Test]
        public void Multiply_Minus22TimesMinus3()
        {
            var uut = new Calculator();
            Assert.That(uut.Multiply(-22, -3), Is.EqualTo(66));
        }
        [Test]
        public void Divide_40DividedBy3()
        {
            var uut = new Calculator();
            Assert.That(uut.Divide(90, 3), Is.EqualTo(30));
        }
        [Test]
        public void Power_3RaisedToTheExpOf2()
        {
            var uut = new Calculator();
            Assert.That(uut.Power(3, 2), Is.EqualTo(9));
        }
        [Test]
        public void AccumulatorEqual_Power_3RaisedToTheExpOf2()
        {
            var uut = new Calculator();
            var testResult = uut.Power(3, 2);
            Assert.That(uut.Accumulator, Is.EqualTo(testResult));
            var testResult1 = uut.Power(3, 2);
            Assert.That(uut.Accumulator, Is.EqualTo(testResult1));
        }
        [Test]
        public void AccumulatorClear()
        {
            var uut = new Calculator();
            uut.Power(3, 2);
            uut.Clear();
            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }
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
        public void Divide_3DividedBy3()
        {
            var uut = new Calculator();
            Assert.That(uut.Divide(3), Is.EqualTo(1));
        }
        [Test]
        public void Divide_63163766123963DividedBy63163766123963()
        {
            var uut = new Calculator();
            Assert.That(uut.Divide(63163766123963), Is.EqualTo(1));
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
