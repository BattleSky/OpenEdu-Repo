using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    public class Point1
    {
        public double X;
        public double Y;
    }
    public class Practice2
    {
        private static void Main6()
        {
            var array = new[]
            {
                new Point1 { X = 1, Y = 0 },
                new Point1 { X = -1, Y = 0 },
                new Point1 { X = 0, Y = 1 },
                new Point1 { X = 0, Y = -1 },
                new Point1 { X = 0.01, Y = 1 }
            };
            Array.Sort(array, new ClockwiseComparer());
            foreach (Point1 e in array)
                Console.WriteLine("{0} {1}", e.X, e.Y);
            Console.ReadLine();
        }
	}

    public class ClockwiseComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var basePoint = new Point
            {
                X = 0,
                Y = 0
            };
            var baseAngle = Math.Atan2(basePoint.Y, basePoint.X);
            var pointX = (Point1) x;
            var pointY = (Point1) y;

            var getAngleX = GetAngleFromBasePoint(pointX, baseAngle);
            var getAngleY = GetAngleFromBasePoint(pointY, baseAngle);
            return getAngleX.CompareTo(getAngleY);
        }

        public static double GetAngleFromBasePoint(Point1 point, double baseAngle)
        {
            var getAngle = Math.Atan2(point.Y, point.X);
            if (getAngle < baseAngle)
                getAngle += Math.PI * 2;

            return getAngle;
        }
    }

}
