using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Целостность_данных
{
    public class Vector1
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Length
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }
        public Vector1(double x, double y)
        {
            X = x;
            Y = y;
        }


        public override string ToString()
        {

            return string.Format("({0}, {1}) with length: {2}", X, Y, Length);
        }
    }

    public class Program561
    {
        public static void Main1()
        {
            Vector1 vector = new Vector1(3, 4);
            Console.WriteLine(vector.ToString());

            vector.X = 0;
            vector.Y = -1;
            Console.WriteLine(vector.ToString());

            vector = new Vector1(9, 40);
            Console.WriteLine(vector.ToString());

            Console.WriteLine(new Vector1(0, 0).ToString());
            Console.ReadLine();
        }
    }
}
