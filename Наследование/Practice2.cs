using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наследование
{
    class Practice2
    {
        public static void Main()
        {
            var ints = new[] { 1, 2 };
            var strings = new[] { "A", "B" };

            Print(Combine(ints, ints));
            Print(Combine(ints, ints, ints));
            Print(Combine(ints));
            Print(Combine());
            Print(Combine(strings, strings));
            Print(Combine(ints, strings));
            Console.ReadLine();
        }

        static void Print(Array array)
        {
            if (array == null)
            {
                Console.WriteLine("null");
                return;
            }
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array.GetValue(i));
            Console.WriteLine();
        }

        static int FullLengthOfArray(Array[] arrays)
        {
            var count = 0;
            foreach (var array in arrays)
            {
                count += array.Length;
            }
            return count;
        }

        static Array Combine(params Array[] arrays)
        {
            if (arrays.GetLength(0) == 0) return null;
            var arrayType = arrays[0].GetType().GetElementType();
            var newArrayLength = FullLengthOfArray(arrays);
            var newArray = Array.CreateInstance(arrayType, newArrayLength);
            for (int i = 0; i < arrays.GetLength(0); i++)
            {
                if (arrays[i].GetType().GetElementType() != arrayType) return null;
                arrays[i].CopyTo(newArray, i*arrays[i].Length);
            }
            
            return newArray;
        }
	}
}
