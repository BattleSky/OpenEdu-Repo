using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEdu1
{
    class Program
    {
        
        private static string GetGreetingMessage(string name, double salary)
        {
            var roundedSalary = (int) Math.Ceiling(salary);
            return $"Hello, {name}, your salary is {roundedSalary}.";
        }

        public static void WriteReversed(char[] items, int startIndex = 0)
        {
            // Выводим в обратном порядке все элементы с индексом больше startIndex
            if (startIndex + 1 < items.Length)
                WriteReversed(items, startIndex + 1);
            // а потом выводим сам элемент startIndex
            
            if (items.Length != 0)
                Console.Write(items[startIndex]);
        }

        public static void Main(string[] args)
        {
            WriteReversed(new char[] {'1', '2', '3'});
            WriteReversed(new char[] {'1', '2'});
            WriteReversed(new char[] { });
            WriteReversed(new char[] {'1', '1', '2', '2', '3', '3'});
            WriteReversed(new char[] {'1', '2', '3', '4'});
            WriteReversed(new char[] {'a', 'b', 'c', 'd'});
            Console.ReadLine();
        }
    }
}
