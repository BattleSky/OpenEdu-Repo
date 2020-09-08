using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наследование
{
    class TheProblem
    {
        /*
         * Для решения проблем, связанных с выполнением операций,
         * с различными классами (например)
         * В качестве примера взяты два массива (стринг и инт)
         * Для реализации сортировки необходимо применять перегрузку метода и писать метод дважды
         * что противоречит правилам Don't repeat yourself. 
         */
        static void Main5()
        {
            Sort(new int[] { 1, 2, 3 });
            Sort(new string[] { "A", "B", "C" });
        }

        static void Sort(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            for (int j = 1; j <= i; j++)
                if (array[j] < array[j - 1])
                {
                    var temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }
        }

        static void Sort(string[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            for (int j = 1; j <= i; j++)
                if (array[j].CompareTo(array[j - 1]) < 0)
                {
                    var temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }
        }
	}
}
