using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Структуры
{
    class Class1
    {
        struct Point
        {
            public int X;
            public int Y;
        }

        static void ProcessStruct(ref Point point)
        {
            point.X = 10;
        }

        static void ProcessInt(ref int n)
        {
            n = 10;
        }

        static void ProcessArray(ref int[] array)
        {
            array = new int[2];
        }

        public static void Main()
        {
            Point point = new Point();
            ProcessStruct(ref point);
            Console.WriteLine(point.X);

            int n = 0;
            ProcessInt(ref n);
            Console.WriteLine(n);

            var array = new int[3];
            ProcessArray(ref array);
            Console.WriteLine(array.Length);
        }

        /*
         *  практика
         */

        public static string ReadNumber(string text, ref int pos)
        {
            var start = pos;
            while (pos < text.Length && char.IsDigit(text[pos]))
                pos++;
            return text.Substring(start, pos - start);
        }

        public static void SkipSpaces(string text, ref int pos)
        {
            while (pos < text.Length && char.IsWhiteSpace(text[pos]))
                pos++;
        }

        public static void WriteAllNumbersFromText(string text)
        {
            var position = 0;
            while (true)
            {
                // skip spaces
                SkipSpaces(text, ref position);
                var num = ReadNumber(text, ref position);
                if (num == "") break;
                Console.Write(num + " ");
            }
            Console.WriteLine();

        }

    }


}
