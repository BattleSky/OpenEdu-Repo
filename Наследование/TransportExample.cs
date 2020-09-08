using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наследование
{
    class Transport
    {
        public double Velocity;
        public double KilometerPrice;
        public int Capacity;
    }

    class CombustionEngineTransport : Transport
            // транспорт с ДВС является частным случаем транспорта
        // это двоеточие обозначает наследование
    {
        public double EngineVolume;
        public double EnginePower;
    }

    enum ControlType //тип привода
    {
        Forward,
        Backward
    }

    class Car : CombustionEngineTransport
    // в этом случае Машина наследует свойства CombustionEngineTransport и Transport
    {
        public ControlType Control;
    }

    class Program
    {
        public static void Main1()
        {
            var c = new Car();
            c.Control = ControlType.Backward; //это собственное поле класса Car
            c.EnginePower = 100; // это поле унаследовано от CombustionEngineTransport
            c.Capacity = 4; // это поле унаследовано от Transport
        }
    }
}
