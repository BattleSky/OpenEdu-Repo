using System;

namespace ConsoleApp7
{

    class Program
    {
        static string Decode(string a)
        {
            a = a.Replace(".", string.Empty);
            int dividend = Int32.Parse(a);

            int reminder = dividend % 1024;
            return reminder.ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Decode("0"));
            Console.WriteLine(Decode("123"));
            Console.WriteLine(Decode("1.23"));
            Console.WriteLine(Decode("1...2..3"));
            Console.WriteLine(Decode("1010"));
            Console.WriteLine(Decode("1025"));
            Console.WriteLine(Decode("1..02.6"));
            }
    }
}
