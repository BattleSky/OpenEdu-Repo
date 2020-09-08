using System;
using System.ComponentModel;

namespace ConsoleApp3
{
    class Program
    {
        static string a;
        static string b;
        
        static int Years()
        {
            int firstyear = Int32.Parse(a);
            int secondyear = Int32.Parse(b);

            int upperyear = 0;
            int loweryear = 0;
            int result = 0;

            if (firstyear > secondyear)
            {
                upperyear = firstyear;
                loweryear = secondyear;
            }
            else if (firstyear < secondyear)
            {
                upperyear = secondyear;
                loweryear = firstyear;
            }
            // Сужаем отрезки:


            //Если нижний год делится на 4 с остатком,то есть сам не високосный,
            //то сдвигаем его в сторону високосного года вверх
            //
            switch (loweryear % 4)
            {
                case 1: loweryear += 3;
                    break;
                case 2: loweryear += 2;
                    break;
                case 3: loweryear += 1;
                    break;
                    default: break;
            }

            //Если верхний год делится на 4 с остатком, то есть сам не високосный,
            //то сдвигаем его в сторону високосного года вниз
            //
            

            switch (upperyear % 4)
            {
                case 1:
                    upperyear -= 1;
                    break;
                case 2:
                    upperyear -= 2;
                    break;
                case 3:
                    upperyear -= 3;
                    break;
                default: break;
            }

            // Если a и b - одинаковые и високосные, то они високосные :3

            if (firstyear == secondyear && firstyear % 4 == 0)
            {
                result = 1;
            }

            // Если a и b одинаковые високосные, то они не високосные :3

            else if (firstyear == secondyear && firstyear % 4 != 0)
            {
                result = 0;
            }
            else
            {
                result = ((upperyear - loweryear) / 4) + 1;
            }

            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Программа считает количество високосных годов в промежутке между a и b");
            Console.WriteLine("Введи число a:");
            a = Console.ReadLine();
            Console.WriteLine("Введи число b:");
            b = Console.ReadLine();
            Console.WriteLine("Количество високосных годов в указанном промежутке: " + Years());
        }
    }
}

/*
            int result = Math.Abs(firstyear - secondyear)  / 4;

            Console.WriteLine("Остаток от первого:" + (firstyear % 4));
            Console.WriteLine("Остаток от второго:" + (secondyear % 4));

            // Условие: чтобы сумма остатков деления на 4 первого и второга года была больше 3 
            // + чтобы остаток деления разницы годов был больше 0
            // + чтобы целочисленное деление разницы годов на 4 было больше 0.

            if (firstyear % 4 + secondyear % 4 >= 4 && Math.Abs(firstyear - secondyear) % 4 != 0 && result > 0)
            {
                result++;
                Console.WriteLine("Сумма остатков:" + (firstyear % 4 + secondyear % 4));
            }
            // Если год делится на 4 без остатка - то он високосный сам по себе
            if (firstyear % 4 == 0 || secondyear % 4 == 0)
            {
                result++;
            }
            
            return result; */
