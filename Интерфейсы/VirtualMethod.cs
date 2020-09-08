using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    class Point2
    {
        public int X;
        public int Y;

        public override string ToString()
        {
            return String.Format("X={0}, Y={1}", X, Y);
        }
    }

	class VirtualMethod
    {
        static void Main2()
        {
            var point = new Point { X = 1, Y = 3 };
            Console.WriteLine(point);
        }
    }
}
