using System;

namespace ConsoleApp8
{

    class Program
    {
        public static double Calculate(string userInput)
        {
            string[] splitInput = userInput.Split(' ');

            double rubles = Convert.ToDouble(splitInput[0]);
            double annualRate = Convert.ToDouble(splitInput[1]);
            double duration = Convert.ToDouble(splitInput[2]);
            // магическая формула - сложные проценты в вики
            double result = rubles * Math.Pow(1 + annualRate /(12* 100), duration);

            return result;
        }
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
           
            Console.WriteLine(Calculate(userInput));
        }
    }
}
