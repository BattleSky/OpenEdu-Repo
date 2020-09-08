using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Целостность_данных
{
    public class Statistics
    {
        public int SuccessCount;
        public int TotalCount;
        public void Print()
        {
            Console.WriteLine("{0}%", (SuccessCount * 100) / TotalCount);
        }
    }

    public class Theory
    {
        public static void Main5()
        {
            var rnd = new Random();
            var stat = new Statistics();
            for (int i = 0; i < 1000; i++)
            {
                if (rnd.Next(3) > 1) stat.SuccessCount++;
                stat.TotalCount++;
            }
            stat.Print();

            //проблема в том, что никто нам не помешает написать вот так:
            stat.TotalCount = 100;
            stat.SuccessCount = 146;
            stat.Print();
        }
    }
}
