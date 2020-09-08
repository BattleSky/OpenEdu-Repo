using System;
// Получение дескриминанта по входным значениям.
namespace ConsoleApp5
{
    class Program
    {

        static double GetDescriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }

        static double GetFirstRoot(double a, double b, double c)
        {
            var discriminant = GetDescriminant(a,b,c);
            var squareRoot = Math.Sqrt(discriminant);
            return (-b - squareRoot) / (2 * a);
        } 

        static void Main(string[] args)
        {
           var result = GetFirstRoot(1, 1, 1);
           Console.WriteLine(result);
        }
    }
}
