using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17OOP
{
    using System;

    abstract class Pair
    {
        public abstract Pair Add(Pair p);
        public abstract Pair Subtract(Pair p);
        public abstract Pair Multiply(Pair p);
        public abstract Pair Divide(Pair p);
    }

    class FazzyNumber : Pair
    {
        private double value;
        private double error;

        public FazzyNumber(double value, double error)
        {
            this.value = value;
            this.error = error;
        }

        public override Pair Add(Pair p)
        {
            FazzyNumber num = (FazzyNumber)p;
            return new FazzyNumber(this.value + num.value, this.error + num.error);
        }

        public override Pair Subtract(Pair p)
        {
            FazzyNumber num = (FazzyNumber)p;
            return new FazzyNumber(this.value - num.value, this.error + num.error);
        }

        public override Pair Multiply(Pair p)
        {
            FazzyNumber num = (FazzyNumber)p;
            double newVal = this.value * num.value;
            double newErr = (this.error * num.value) + (num.error * this.value);
            return new FazzyNumber(newVal, newErr);
        }

        public override Pair Divide(Pair p)
        {
            FazzyNumber num = (FazzyNumber)p;
            double newVal = this.value / num.value;
            double newErr = (this.error / num.value) + (num.error * this.value / (num.value * num.value));
            return new FazzyNumber(newVal, newErr);
        }

        public override string ToString()
        {
            return $"({value}±{error})";
        }
    }

    class Fraction : Pair
    {
        private int numerator;
        private uint denominator;

        public Fraction(int numerator, uint denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public override Pair Add(Pair p)
        {
            Fraction frac = (Fraction)p;
            uint lcm = LCM(this.denominator, frac.denominator);
            int newNum = (int)(this.numerator * lcm / this.denominator) + (int)(frac.numerator * lcm / frac.denominator);
            return new Fraction(newNum, lcm);
        }

        public override Pair Subtract(Pair p)
        {
            Fraction frac = (Fraction)p;
            uint lcm = LCM(this.denominator, frac.denominator);
            int newNum = (int)(this.numerator * lcm / this.denominator) - (int)(frac.numerator * lcm / frac.denominator);
            return new Fraction(newNum, lcm);
        }

        public override Pair Multiply(Pair p)
        {
            Fraction frac = (Fraction)p;
            int newNum = this.numerator * frac.numerator;
            uint newDen = this.denominator * frac.denominator;
            return new Fraction(newNum, newDen);
        }

        public override Pair Divide(Pair p)
        {
            Fraction frac = (Fraction)p;
            int newNum = this.numerator * (int)frac.denominator;
            uint newDen = this.denominator * (uint)Math.Abs(frac.numerator);
            if (frac.numerator < 0)
            {
                newNum = -newNum;
            }
            return new Fraction(newNum, newDen);
        }

        private static uint GCD(uint a, uint b)
        {
            while (b != 0)
            {
                uint r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        private static uint LCM(uint a, uint b)
        {
            return (a * b) / GCD(a, b);
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
    }
}
