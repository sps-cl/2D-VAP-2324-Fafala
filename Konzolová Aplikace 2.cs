using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ComplexNumber
    {
        public double Real { get; set; } //Getter je metoda používaná k získání hodnoty privátního atributu objektu.
        public double Imaginary { get; set; } //Setter je metoda používaná k nastavení hodnoty privátního atributu objektu.

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public ComplexNumber Add(ComplexNumber other)
        {
            double realResult = Real + other.Real;
            double imaginaryResult = Imaginary + other.Imaginary;
            return new ComplexNumber(realResult, imaginaryResult);
        }

        public ComplexNumber Subtract(ComplexNumber other)
        {
            double realResult = Real - other.Real;
            double imaginaryResult = Imaginary - other.Imaginary;
            return new ComplexNumber(realResult, imaginaryResult);
        }

        public ComplexNumber Multiply(ComplexNumber other)
        {
            double realResult = Real * other.Real - Imaginary * other.Imaginary;
            double imaginaryResult = Imaginary * other.Real + Real * other.Imaginary;
            return new ComplexNumber(realResult, imaginaryResult);
        }

        public ComplexNumber Divide(ComplexNumber other)
        {
            double denominator = Math.Pow(other.Real, 2) + Math.Pow(other.Imaginary, 2);
            double realResult = (Real * other.Real + Imaginary * other.Imaginary) / denominator;
            double imaginaryResult = (Imaginary * other.Real - Real * other.Imaginary) / denominator;
            return new ComplexNumber(realResult, imaginaryResult);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte reálnou část prvního čísla:");
            double real1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Zadejte imaginární část prvního čísla:");
            double imaginary1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Zadejte reálnou část druhého čísla:");
            double real2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Zadejte imaginární část druhého čísla:");
            double imaginary2 = Convert.ToDouble(Console.ReadLine());

            ComplexNumber complex1 = new ComplexNumber(real1, imaginary1);
            ComplexNumber complex2 = new ComplexNumber(real2, imaginary2);

            ComplexNumber sum = complex1.Add(complex2);
            ComplexNumber difference = complex1.Subtract(complex2);
            ComplexNumber product = complex1.Multiply(complex2);
            ComplexNumber quotient = complex1.Divide(complex2);

            Console.WriteLine($"Součet: {sum.Real} + {sum.Imaginary}i");
            Console.WriteLine($"Rozdíl: {difference.Real} + {difference.Imaginary}i");
            Console.WriteLine($"Součin: {product.Real} + {product.Imaginary}i");
            Console.WriteLine($"Podíl: {quotient.Real} + {quotient.Imaginary}i");
            Console.ReadLine();
        }
    }
}