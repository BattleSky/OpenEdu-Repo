using System;
using System.Runtime.InteropServices;

// Программа считает количество градусов от минутной стрелки, если часы равны


namespace ConsoleApp2
{
    class Program
    {
        static string readnumber;
        static int Angle()
        {
            int getangle;
            getangle = 360 / 12;
            int angleresult = Int32.Parse(readnumber) * getangle;

            return angleresult;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Программа считает количество градусов от минутной стрелки, если часы равны");
            Console.WriteLine("Напиши количество часов от 0 до 12:");
            readnumber = Console.ReadLine();
            Console.WriteLine("Полученный угол от минутной стрелки: " + Angle());
        }
    }
}
