using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наследование
{
    public static class ArrayExtensions
    {
        //здесь Swap является расширением класса Array
        // и принимает первым аргументом массив как объект
        // то есть совершает апкаст из интов, стрингов и т.д. в класс массива
        public static void Swap(this Array array, int i, int j)
        {
            object temporary = array.GetValue(i);
            array.SetValue(array.GetValue(i), j);
            array.SetValue(temporary, j);
        }
    }
    class ProblemSOLUTION
    {
        static void Main3()
        {
            var strings = new string[] { "B", "A", "C" };
            strings.Swap(0, 1);

            var ints = new int[] { 1, 3, 2 };
            ints.Swap(1, 2);
        }
    }
}
