using System;

namespace Основы_ООП___Методы
{
    /*
     * Речь о методах расширения.
     */
    public class Extension
    {
        static double MyNextDouble(Random rnd, double min, double max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }

        static void Main1()
        {
            var rnd = new Random();
            Console.WriteLine(MyNextDouble(rnd, 10, 20));
            Console.WriteLine(rnd.NextDouble(10, 20)); // теперь такой метод принимает два аргумента
            var array = new int[] { 1, 2, 3, 4, 5 };
            array.Swap(0, 1);
        }

        public static void Main2()
        {
            var arg1 = "100500";
            Console.Write(arg1.ToInt() + "42".ToInt()); // 100542
        }
    }

    public static class RandomExtensions
    // объявление метода-расширения
    // он обязательно должен быть статическим
    {
        /*
         * Ключевое слово this говорит о том, что это не обычный метод,
         * а метод расширения. При подключении слова this комплилятор может интерпретировать
         * этот статическй метод как динамический метод класса Random
         * Потому что этот класс стоит первым аргументом и указан ключевым словом
         * Поэтому понятно, что я хочу прикрепить NextDouble к классу Random и он будет
         * принимать 2 аргумента min и max.
         */
        public static double NextDouble(this Random rnd, double min, double max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }
    }

    public static class ArrayExtensions
    {
        public static void Swap(this int[] array, int i, int j)
        {
            var t = array[i];
            array[i] = array[j];
            array[j] = t;
        }
    }

    public static class ConvertStringToInt
    {
        public static int ToInt(this string arg)
        {
            return Convert.ToInt32(arg);
        }
    }
}
