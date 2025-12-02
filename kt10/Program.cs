using System;

namespace kt10
{
    public interface IComparable<T>
    {
        int CompareTo(T other);
    }

    public struct ComplexNumber : IComparable<ComplexNumber>
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public int CompareTo(ComplexNumber other)
        {
            double magnitude1 = Math.Sqrt(Real * Real + Imaginary * Imaginary);
            double magnitude2 = Math.Sqrt(other.Real * other.Real + other.Imaginary * other.Imaginary);

            if (magnitude1 < magnitude2) return -1;
            if (magnitude1 > magnitude2) return 1;
            return 0;
        }

        public string GetInfo()
        {
            return $"{Real} + {Imaginary}i";
        }
    }

    public struct RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public RationalNumber(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public int CompareTo(RationalNumber other)
        {
            double value1 = (double)Numerator / Denominator;
            double value2 = (double)other.Numerator / other.Denominator;

            if (value1 < value2) return -1;
            if (value1 > value2) return 1;
            return 0;
        }

        public string GetInfo()
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    class Program
    {
        static void Main()
        {
            ComplexNumber complex1 = new ComplexNumber(3, 4);
            ComplexNumber complex2 = new ComplexNumber(1, 2);

            Console.WriteLine("complex Numbers");
            Console.WriteLine("number 1 " + complex1.GetInfo());
            Console.WriteLine("number 2 " + complex2.GetInfo());
            Console.WriteLine("compare result " + complex1.CompareTo(complex2));

            Console.WriteLine();

            RationalNumber rational1 = new RationalNumber(3, 4);
            RationalNumber rational2 = new RationalNumber(1, 2);

            Console.WriteLine("rational Numbers:");
            Console.WriteLine("number 1 " + rational1.GetInfo());
            Console.WriteLine("number 2 " + rational2.GetInfo());
            Console.WriteLine("compare " + rational1.CompareTo(rational2));

            Console.ReadLine();
        }
    }
}