using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    class IComparableRealization
    {

    }

    class Point : IComparable
    {
        public int X;
        public int Y;
        public int CompareTo(object obj)
        {
           /*
            * CompareTo принимает два объекта:
            * point из которого был вызван CompareTo
            * и object obj - объект, с которым мы сравниваем
            */
           var point = (Point) obj; //делаем downcast для объекта obj в класс Point
           var thisDistance = Math.Sqrt(X * X + Y * Y); // расстояние этой точки до центра
           var thatDistance = Math.Sqrt(point.X * point.X + point.Y * point.Y); // расстояние сравниваемой точки до центра
           return thisDistance.CompareTo(thatDistance);
           //или
           //if (thisDistance < thatDistance) return -1;
           //else if (thisDistance == thatDistance) return 0;
           //else return 1;
        }
    }
}
