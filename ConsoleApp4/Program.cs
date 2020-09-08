using System;

// программа ищет минимум квадратичной функции с учетом неотрицательного значения а
// Метод должен принимать неотрицательный коэффициент a, а также произвольные коэффициенты b и c,
//и, если решение существует, возвращать строковое представление искомого x, а иначе — строку Impossible.
namespace ConsoleApp4
{
    
    class Program
    {
        
        // x0 = -b/2a
        private static string GetMinX(int a, int b, int c)
        {
            double x = 0;
            if (a <= 0 && b != 0)
            {
                return x.ToString("Impossible");
            }
            else if (a == 0 && b == 0)
            {
                x = c;
            }
            else
            {
                double doubleA = Convert.ToDouble(a);
                double doubleB = Convert.ToDouble(b);
                x = -(doubleB / (2* doubleA));

            }
            
            return x.ToString(); // так можно вернуть строковое представление числа
        }


        public static void Main()
        {
            Console.WriteLine(GetMinX(1, 2, 3));
            Console.WriteLine(GetMinX(0, 3, 2));
            Console.WriteLine(GetMinX(1, -2, -3));
            Console.WriteLine(GetMinX(5, 2, 1));
            Console.WriteLine(GetMinX(4, 3, 2));
            Console.WriteLine(GetMinX(0, 4, 5));

            // А в этих случаях решение существует:
            Console.WriteLine(GetMinX(0, 0, 2) != "Impossible");
            Console.WriteLine(GetMinX(0, 0, 0) != "Impossible");
        }
    }
    }
