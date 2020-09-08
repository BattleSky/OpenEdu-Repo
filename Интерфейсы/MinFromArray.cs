using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    class MinFromArray
    {
        public static void Main4()
        {
            Console.WriteLine(Min(new[] { 3, 6, 2, 4 }));
            Console.WriteLine(Min(new[] { "B", "A", "C", "D" }));
            Console.WriteLine(Min(new[] { '4', '2', '7' }));
            Console.ReadLine();
        }

        public static object Min (params Array[] array)
        {
            IComparable min = 0;
            var counter = 0;
            foreach (var e in array[0])
            {
                var element1 = (IComparable) e;
                if (counter == 0 || element1.CompareTo(min) < 0)
                    min = element1;
                counter++;
            }
            return min;
        }
    }

}
