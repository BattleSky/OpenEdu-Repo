using System;

namespace Основы_ООП___Методы
{
    /*
     * Отличия динамического метода от статического в том, что
     * динамический метод вызывается из какого-то объекта
     * и он может обращаться к динамическим полям этого объекта
     * во время своей работы
     */
    class Program
    {
        public static void Main()
        {
            var point = new Point { X = 1, Y = 2 };
            point.Print(); // вызов динамического метода Print у объекта типа Point
                // значения X и Y берутся из того объекта, с которым мы работаем
            Point.PrintPoint(point); // вызов статического метода
        }
    }

    class Point
    {
        public int X;
        public int Y;

        //в динамическом методе можно обращаться и к стат и к динамич полям
        // динамический метод - это синтаксический сахар
        public void Print()
        {
            Console.WriteLine("{0} {1}", X, Y);
        }
        // в статическом методе можно обращаться только к статическим полям
        public static void PrintPoint(Point point)
        {
            Console.WriteLine("{0} {1}", point.X, point.Y);
        }
    }


}
