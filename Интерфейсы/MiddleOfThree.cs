using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    class MiddleOfThreee
    {
        public static void Main1()
        {
            Console.WriteLine(MiddleOfThree(2, 5, 4));
            Console.WriteLine(MiddleOfThree(3, 1, 2));
            Console.WriteLine(MiddleOfThree(3, 5, 9));
            Console.WriteLine(MiddleOfThree("B", "Z", "A"));
            Console.WriteLine(MiddleOfThree(3.45, 2.67, 3.12));
        }

        static object MiddleOfThree(object a, object b, object c)
        {
            var aComparable = (IComparable) a;
            var bComparable = (IComparable) b;
            var cComparable = (IComparable) c;

            if (aComparable.CompareTo(bComparable) + aComparable.CompareTo(cComparable) == 0)
                return aComparable;
            if (bComparable.CompareTo(aComparable) + bComparable.CompareTo(cComparable) == 0)
                return bComparable;
            return cComparable;
        }

    }
}
