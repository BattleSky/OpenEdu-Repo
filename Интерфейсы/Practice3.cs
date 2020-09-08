using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    public class Practice3
    {
        static void Main()
        {
            var triangle = new Triangle
            {
                A = new Point3 {X = 0, Y = 0},
                B = new Point3 {X = 1, Y = 2},
                C = new Point3 {X = 3, Y = 2}
            };
            Console.WriteLine(triangle.ToString());
        }
    }

    public class Point3
    {
        public double X;
        public double Y;
        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
        }
    }

    public class Triangle
    {
        public Point3 A;
        public Point3 B;
        public Point3 C;

        public override string ToString()
        {
            return string.Format("({0}) ({1}) ({2})", A, B, C);
        }
    }
}
