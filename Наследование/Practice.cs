using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Наследование
{
    class Practice
    {
        public static void Main5()
        {
            Print(1, 2);
            Print("a", 'b');
            Print(1, "a");
            Print(true, "a", 1);
        }
        public static void Print(params object[] element)
        {
            for (var i = 0; i < element.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(element[i]);
            }
            Console.WriteLine();
        }
    }

}
