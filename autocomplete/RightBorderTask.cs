using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class RightBorderTask
    {
        /// <returns>
        /// Возвращает индекс правой границы. 
        /// То есть индекс минимального элемента, который не начинается с prefix и большего prefix.
        /// Если такого нет, то возвращает items.Length
        /// </returns>
        /// <remarks>
        /// Функция должна быть НЕ рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>

        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            // IReadOnlyList похож на List, но у него нет методов модификации списка.
            // Этот код решает задачу, но слишком неэффективно. Замените его на бинарный поиск!

            /*
             * Данная версия метода Compare принимает две строки и возвращает число.
             * Если первая строка по алфавиту стоит выше второй, то возвращается число меньше нуля.
             * В противном случае возвращается число больше нуля.
             * И третий случай - если строки равны, то возвращается число 0.
             * https://metanit.com/sharp/tutorial/7.2.php
             */

            while (right - left > 1)
            {
                var middle = Convert.ToInt32(((long)left + (long)right) / 2);
                // избегаем достижения Int32 MaxValue при сложении индексов
                // если prefix стоит ниже по алфавиту или равен phrases[middle]
                if (string.Compare(prefix, phrases[middle], StringComparison.OrdinalIgnoreCase) >= 0
                    || phrases[middle].StartsWith(prefix)) //или phrases[middle] начинается с prefix
                    left = middle;
                else right = middle;
            }

            return right;

        }
    }
}