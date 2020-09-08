using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    class IComparerRealization
    {
        /*
         * IComparer - класс сравнитель, который умеет сравнивать другие объекты между собой
         * Comparable - это объекты, которые умеют сравниваться друг с другом сами
         *
         * Comparer определен в стандартных библиотеках
         */
    }

    class DistanceToZeroComparer : IComparer
    {//сравнитель точек по расстоянию от начала координат
        public int Compare(object x, object y)
        {
            var point1 = (Point)x;
            var point2 = (Point)y;
            return
                Math.Sqrt(point1.X * point1.X + point1.Y * point1.Y).CompareTo(
                    Math.Sqrt(point2.X * point2.X + point2.Y * point2.Y));
        }
    }

    class XDecreasingComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var point1 = x as Point;
            var point2 = (Point)y;
            return -point1.X.CompareTo(point2.X);
        }
    }

    public class Program
    {
        public static void Sort(Array array, IComparer comparer)
        { // сравнитель надо передавать
            for (int i = array.Length - 1; i > 0; i--)
            for (int j = 1; j <= i; j++)
            {
                object element1 = array.GetValue(j - 1);
                object element2 = array.GetValue(j);
                if (comparer.Compare(element1, element2) < 0)
                {// запуск сравнителя, чтобы он сравнил два элемента
                    object temporary = array.GetValue(j);
                    array.SetValue(array.GetValue(j - 1), j);
                    array.SetValue(temporary, j - 1);
                }
            }
        }

        public static void Main3()
        {
            var array = new[]
            {
                new Point { X=1, Y=1},
                new Point { X=2, Y=2}
            };

            Sort(array, new DistanceToZeroComparer());
            Sort(array, new XDecreasingComparer());
        }
    }
}
