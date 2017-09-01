using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianFraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Test(2, 3);
            Test(6, 14);
            Test(12, 13);
            Console.ReadKey();
        }

        private static void Test(int numerator, int denominator)
        {
            EgyptianFraction ef = new EgyptianFraction(numerator, denominator);
            Console.WriteLine(ef.GetFraction + " = " + string.Join(" + ", ef.GetUnitFractions()));
        }

        public class Fraction
        {
            public int Numerator { get; set; }
            public int Denominator { get; set; }

            public static Fraction operator -(Fraction f1, Fraction f2)
            {
                return new Fraction
                {
                    Numerator = f1.Numerator * f2.Denominator - f1.Denominator * f2.Numerator,
                    Denominator = f1.Denominator * f2.Denominator
                };
            }

            public override string ToString()
            {
                return string.Format("{0}/{1}", Numerator, Denominator);
            }
        }

        public class EgyptianFraction
        {
            private readonly int _numerator;
            private readonly int _denominator;

            public Fraction GetFraction
            {
                get
                {
                    return new Fraction
                    {
                        Numerator = _numerator,
                        Denominator = _denominator
                    };
                }
            }

            public EgyptianFraction(int numerator, int denominator)
            {
                _numerator = numerator;
                _denominator = denominator;
            }

            public ICollection<Fraction> GetUnitFractions()
            {
                var result = new List<Fraction>();
                var origin = new Fraction
                {
                    Numerator = _numerator,
                    Denominator = _denominator
                };
                while (origin.Numerator != 0)
                {
                    var unit = new Fraction
                    {
                        Numerator = 1,
                        Denominator = (int) Math.Ceiling(origin.Denominator / (double) origin.Numerator)
                    };
                    result.Add(unit);
                    origin -= unit;
                }
                return result;
            }
        }
    }
}
