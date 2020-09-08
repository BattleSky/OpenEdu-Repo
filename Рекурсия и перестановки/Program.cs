using System;

namespace Рекурсия_и_перестановки
{
    /*
     * Как выглядит перестановка местами в подмножестве. (множестве)
     */
    class Program
    {
        static int[,] prices =
        {
            { 0, 2, 4, 7 },
            { 2, 0, 3, 1 },
            { 4, 2, 0, 1 },
            { 3, 5, 2, 0 }
        };

        static void Evaluate(int[] permutation)
        {
            int price = 0;
            for (int i = 0; i < permutation.Length; i++)
                price += prices[permutation[i], permutation[(i + 1) % permutation.Length]];
            /*
             * Нужно посчитать i-го переезда (из i в i+1) за исключением последнего переезда. Когда i - 1 - один
             * раз до permutation.lenght, то i+1 = permutation.lenght , то при делении i+1 на permutation.lenght не будет остатка.
             * Способ закольцевания
             */
            foreach (var e in permutation)
                Console.Write(e + " ");
            Console.Write(price);
            Console.WriteLine();
        }

        static void MakePermutations(int[] permutation, int position)
        { //перебор возможных позиций
            if (position == permutation.Length)
            {
                Evaluate(permutation);
                return;
            }

            for (int i = 0; i < permutation.Length; i++)
            {
                var index = Array.IndexOf(permutation, i, 0, position);
                //если i не встречается среди первых position элементов массива permutation, то index == -1
                //иначе index — это номер позиции элемента i в массиве.
                if (index == -1) // если число i ещё не было использовано, то...
                    continue;
                permutation[position] = i;
                MakePermutations(permutation, position + 1);
            }
        }

        public static void Main()
        {
            MakePermutations(new int[4], 0);
        }
    }
}
