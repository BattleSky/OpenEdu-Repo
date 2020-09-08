using System;
using System.Globalization;

namespace Основы_ООП___Статические_методы
{
    class Program
    {
        /*
         * Статические классы используются в том случае, если не требуется более одного экземпляра класса
         * ОТКАЗЫВАЙСЯ ОТ СТАТИКИ, ПЕРЕХОДИ НА СТОРОНУ ДИНАМИКИ!
         */
        static class StaticAlgorithm
        {
            static int temporalValue;
            static public int Run(int value)
            {
                var result = 0;
                for (temporalValue = 0; temporalValue <= value; temporalValue++)
                    result += temporalValue;
                return result;
            }
        }

        class Algorithm
        {
            int temporalValue;

            public int Run(int value)
            {
                var result = 0;
                for (temporalValue = 0; temporalValue <= value; temporalValue++)
                    result += temporalValue;
                return result;
            }
        }
        /*
         *  Сравнение вызова статического алгоритма и алгоритма, оформленного в виде класса.
         */
        public static void Main1()
        {
            StaticAlgorithm.Run(10);

            var algorithm = new Algorithm();
            algorithm.Run(10);
        }

        public static void Main()
        {
            var filter = new SuperBeautyImageFilter();
            filter.ImageName = "Paris.jpg";
            filter.GaussianParameter = 0.4;
            filter.Run();
        }

        public class SuperBeautyImageFilter
        {
            public string ImageName;
            public double GaussianParameter;
            public void Run()
            {
                Console.WriteLine("Processing {0} with parameter {1}",
                    ImageName,
                    GaussianParameter.ToString(CultureInfo.InvariantCulture));
                //do something useful
            }
        }
    }
}
