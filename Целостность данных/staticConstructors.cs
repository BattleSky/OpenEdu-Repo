using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Целостность_данных
{
    class Test8
    {
        public static readonly DateTime Readonly;
        public readonly int Number;
        //Статические конструкторы всегда без параметров
        static Test8()
        {
            Readonly = DateTime.Now;
        }
        //это динамический конструктор
        public Test8()
        {
            Number = 3;
        }
    }

    class Program8
    {
        public static void Main8()
        {
            var test = new Test8();
            //сначала вызовется статический конструктор (настройка типа)
            //и только после этого - динамический
        }
    }
}
