using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    // Внимание!
    // Есть одна распространенная ловушка при сравнении строк: строки можно сравнивать по-разному:
    // с учетом регистра, без учета, зависеть от кодировки и т.п.
    // В файле словаря все слова отсортированы методом StringComparison.OrdinalIgnoreCase.
    // Во всех функциях сравнения строк в C# можно передать способ сравнения.
    public class LeftBorderTask
    {
        /// <returns>
        /// Возвращает индекс левой границы.
        /// То есть индекс максимальной фразы, которая не начинается с prefix и меньшая prefix.
        /// Если такой нет, то возвращает -1
        /// </returns>
        /// <remarks>
        /// Функция должна быть рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>


        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            // IReadOnlyList похож на List, но у него нет методов модификации списка.
            // Этот код решает задачу, но слишком неэффективно. Замените его на бинарный поиск!

            if (right - left == 1)
                return left;
            
            var m = Convert.ToInt32(((long)left + (long)right) / 2);
            // избегаем достижения Int32 MaxValue при сложении индексов
            /*
             * Данная версия метода Compare принимает две строки и возвращает число.
             * Если первая строка по алфавиту стоит выше второй, то возвращается число меньше нуля.
             * В противном случае возвращается число больше нуля.
             * И третий случай - если строки равны, то возвращается число 0.
             * https://metanit.com/sharp/tutorial/7.2.php
             */

            if (string.Compare(prefix, phrases[m], StringComparison.OrdinalIgnoreCase) > 0) 
                // если prefix меньше по алфавиту phrases[m]
                return GetLeftBorderIndex(phrases, prefix, m, right); //сдвигаем левую границу
            return GetLeftBorderIndex(phrases, prefix, left, m);// иначе сдвигаем правую
        }
    }
}
