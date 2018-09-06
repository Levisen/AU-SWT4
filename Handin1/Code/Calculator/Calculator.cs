using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Subtract(double a, double b)
        {
            return a - b;
        }
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        public double Divide(double a, double b)
        {
            return a / b;
        }
        public double Power(double x, double exp)
        {
            return Accumulator = Math.Pow(x, exp);
        }
        public double Accumulator { get; private set; }

        public void Clear()
        {
            Accumulator = 0;
        }
        public double Add(double a)
        {
            return a + a;
        }
        public double Subtract(double a)
        {
            return a - a;
        }
        public double Multiply(double a)
        {
            return a * a;
        }
        public double Divide(double a)
        {
            return a / a;
        }
        public double Power(double exp)
        {
            return Accumulator = Math.Pow(exp, exp);
        }
    }
}
