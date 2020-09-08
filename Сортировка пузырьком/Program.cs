using System;

namespace Сортировка_пузырьком
{
    /*
     * Подразумеватся "всплывание" самого большого "пузыря" на поверхность (по старшему индексу)
     * Сортировка по возрастанию.
     * https://ulearn.me/Courses/BasicProgramming/L100_Sorting/bubblesort.gif
     */
    class Program
    {
        private static readonly Random random = new Random();

        private static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++) // список надо пробежать n раз, где n - количество элементов в массиве
            for (int j = 0; j < array.Length - 1; j++) // пробегая, надо сравнивать n-1 пар и двигать, если требуется
                    if (array[j] > array[j + 1])
                    {
                        int t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;
                    }
        }

        public static void Main()
        {
            int[] array = GenerateArray(50);
            int[] arrayWithRange = GenerateArray(10);
            BubbleSort(array);
            int[] array1 = new[] {1, 3, 2, 4};
            BubbleSortRange(arrayWithRange, 2, 3);
            BubbleSortRange(array1, 1, 2);
            foreach (int e in array)
                Console.Write(e + " ");
            Console.WriteLine(); 
            foreach (var e in array1)
                Console.Write(e + " ");
            Console.WriteLine();

        }

        private static int[] GenerateArray(int length)
        {
            var array = new int[length];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(0, 100);
            return array;
        }

        /*
         *  Сортировка пузырьком в определенном диапазоне. 
         */
        public static void BubbleSortRange(int[] array, int left, int right)
        {
            for (int i = 0; i < right-left; i++) // список надо пробежать n раз, где n - количество элементов в массиве
            for (int j = left; j <= right - 1; j++) // пробегая, надо сравнивать n-1 пар и двигать, если требуется (от left до right - n)
                if (array[j] > array[j + 1])
                {
                    var t = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = t;
                }
        }
    }
}
