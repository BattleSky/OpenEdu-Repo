using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp13
{
    class Program
    {
        private static string row1; // нечетная строка
        private static string row2; // четная строка
        private static void MakingLines(int size)
        {
            const string sharp = "#";
            const string dot = ".";
            for (int i = 0; i < size; i++)
            {
                if (i == 0 || i % 2 == 0) //нечетная строка
                {
                    row1 += sharp;
                    row2 += dot;
                }
                else //четная строка
                {
                    row1 += dot;
                    row2 += sharp;
                }
            }
        }

        private static void PrintingLines(int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (i == 0 || i % 2 == 0) //нечетная строка
                {
                    Console.WriteLine(row1);
                }
                else //четная строка
                {
                    Console.WriteLine(row2);
                }
            }
            row1 = row2 = "";
        }
        private static void WriteBoard(int size)
        {
           
            MakingLines(size);
            PrintingLines(size);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            WriteBoard(8);
            WriteBoard(1);
            WriteBoard(2);
            WriteBoard(3);
            WriteBoard(10);
        }
    }
}