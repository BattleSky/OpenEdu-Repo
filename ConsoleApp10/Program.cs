using System;

namespace ConsoleApp10
{
    class Program
    {
       // для заданного числа n найдите x > n, такой, что x = 2 ^ k для некоторого натурального k.

        private static int GetMinPowerOfTwoLargerThan(int number)
        {
            int result = 1;
            int k = 0;
            if (number < 0)
                result = 1;
            else
            {
                while ((Math.Pow(2, k) <= number))
                    k++;
                result = (int)Math.Pow(2, k);
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetMinPowerOfTwoLargerThan(2)); // => 4
            Console.WriteLine(GetMinPowerOfTwoLargerThan(15)); // => 16
            Console.WriteLine(GetMinPowerOfTwoLargerThan(-2)); // => 1
            Console.WriteLine(GetMinPowerOfTwoLargerThan(-100));
            Console.WriteLine(GetMinPowerOfTwoLargerThan(100));
        }

    }
}