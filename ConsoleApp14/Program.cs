﻿using System;
using System.Linq;

namespace ConsoleApp14
{
    class Program
    {
        public static int[] GetFirstEvenNumbers(int count)
        {
            var array = new int[count];
            for (int i = 0; i < count; i++)
                array[i] = (i+1) * 2;
            return array;
        }

        public static int MaxIndex(double[] array)
        {
            double maxValue = 0;
            if (array.Length == 0)
                return -1;
            foreach (var item in array)
            {
                if (item > maxValue)
                    maxValue = item;
            }
            var minIndex = Array.FindIndex(array, x => x == maxValue);

            return minIndex;
        }

        public static int GetElementCount(int[] items, int itemToCount)
        {
            int counter = 0;
            foreach (var item in items)
            {
                if (item == itemToCount)
                    counter++;
            }

            return counter;
        }

        public static bool ContainsAtIndex(int[] array, int[] subArray, int index)
        {
            bool result = true;

            for (int i = 0; i < subArray.Length; i++)
            {
                if (array[index + i] != subArray[i])
                {
                    result = false;
                    break;
                }
                    
            }
            return result;
        }

        public static int FindSubarrayStartIndex(int[] array, int[] subArray)
        {
            for (var i = 0; i < array.Length - subArray.Length + 1; i++)
                if (ContainsAtIndex(array, subArray, i))
                    return i;
            return -1;
        }


        static void Main(string[] args)
        {
            //Как и с другими типами, можно использовать var и совместить объявление и инициализацию
            var array1 = new int[3];
            array1[0] = 1;
            array1[1] = 2;
            array1[2] = 3;

            //Можно записать так. Это тоже самое, что предыдущие 4 строки. 
            var array2 = new int[] { 1, 2, 3 };

            //Или даже так. Компилятор автоматически восстановит тип данных из типов констант 1, 2, 3.
            var array3 = new[] { 1, 2, 3 };

            //Это касается, конечно, всех типов, не только числовых.
            var array4 = new[] { "a", "b", "c" };

            //Здесь компилятор выдаст ошибку, поскольку он не может определить тип массива.
           // var array5 = new[] { 1, "2", 3 };

            //Но это можно исправить, если указать тип явно. object - это прародитель всех типов. 
            //Все есть object.
            var array6 = new object[] { 1, "2", 3 };




            var newArray = new [] {0, 100, 1, 2, 100}; // Это тоже самое, что и снизу 
                    newArray[0] = 0;
                      newArray[1] = 100;
                      newArray[2] = 1;
                      newArray[3] = 2;
                      newArray[4] = 100;

            Console.WriteLine(GetElementCount(newArray, 100));
        }
    }
}
