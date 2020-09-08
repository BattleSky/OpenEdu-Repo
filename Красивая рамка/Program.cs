using System;

namespace ConsoleApp12
{
    class Program
    {
        private static void WriteTextWithBorder(string text)
        {
            int numberOfLines = text.Length + 2;
            string lines = "";
            string plus = "+";
            string verticalLine = "|";
            string space = " ";
            for (int i=0; i < numberOfLines; i++)
                lines += "-";
            string borderLine = plus + lines + plus;
            string centerLine = verticalLine + space + text + space + verticalLine;
            Console.WriteLine(borderLine);
            Console.WriteLine(centerLine);
            Console.WriteLine(borderLine);
        }
        static void Main(string[] args)
        {
           
                WriteTextWithBorder("Menu:");
                WriteTextWithBorder("");
                WriteTextWithBorder(" ");
                WriteTextWithBorder("Game Over!");
                WriteTextWithBorder("Select level:");
        }
    }
}
