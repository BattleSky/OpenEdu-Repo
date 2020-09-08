using System;
using System.Collections.Generic;

namespace Перестановки__практика_
{
    class Program
    {
        static void MakePermutations(int[] permutation, int position, List<int[]> result)
        {
            if (position == permutation.Length)
            {
                foreach (var e in result)
                    Console.Write(e + " ");
                Console.WriteLine();
                return;
            }
            else
            {
                for (int i = 0; i < permutation.Length; i++)
                {
                    var index = Array.IndexOf(permutation, i, 0, position);
                    //если i не встречается среди первых position элементов массива permutation, то index == -1
                    //иначе index — это номер позиции элемента i в массиве.
                    if (index == -1)
                        continue;
                    //если число i ещё не было использовано, то...
                    permutation[position] = i;

                }
            }
        }
        

        public static void Main()
        {
            TestOnSize(1);
            TestOnSize(2);
            TestOnSize(0);
            TestOnSize(3);
            TestOnSize(4);
        }

        static void TestOnSize(int size)
        {
            var result = new List<int[]>();
            MakePermutations(new int[size], 0, result);
                //       foreach (var permutation in result)
           //     WritePermutation(permutation);
        }

    }
}
