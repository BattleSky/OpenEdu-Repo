using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Структуры
{
    /*
     * 
     */
    public struct Point3
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Rectangle
    {
        public Point3 Point { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Programm
    {
        public static void Main8()
        {
            Point3 point;
            // point.X = 10; // Так писать нельзя. Сеттер - это метод, а метод
            // можно вызывать, только если структура полностью
            // проинициализирована
            point = new Point3();
            point.X = 10; // Теперь так писать можно

            var rectangle = new Rectangle();
            //rectangle.Point.X = 10; //Так писать нельзя. Rectangle.Point - это сеттер,
            //сеттер - это метод, и как изменить значение, 
            // возвращенное методом и нигде не сохраненное?
            point = rectangle.Point;
            point.X = 10; //так писать можно, но к изменению прямоугольника это не приведет
            //поскольку будет изменена копия, сохраненная в стеке метода Main
            rectangle.Point = new Point3 {X = 10, Y = 10}; //Вот это другое дело.

            //Если бы rectangle.Point было полем, а не свойством, то этой проблемы бы не было

        }
    }
}
