using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEdu2
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] a;
            for (int i = 0; i < Int32.MaxValue; i = i + 3)
            {
                var watch = new Stopwatch();
                watch.Start();
                a = new int[i];
                watch.Stop();
                Console.Write(a.Length + " " + GC.GetTotalMemory(false) + " " + watch.Elapsed);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
