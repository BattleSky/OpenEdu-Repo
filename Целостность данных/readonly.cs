using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Целостность_данных
{
    public class TournirInfo2
    {
        //readonly поле - это еще более сильное ограничение целостности
        //такие поля можно присваивать только в конструкторе
        public readonly int TeamsCount;
        public readonly string[] TeamsNames;
        public readonly double[,] Scores;
        public TournirInfo2(int teamsCount)
        {
            TeamsCount = teamsCount;
            TeamsNames = new string[teamsCount];
            Scores = new double[teamsCount, teamsCount];
        }

        public void SomeMethod()
        {
            // TeamsCount = 4; //так писать нельзя, хотя мы внутри класса
        }
    }

    public class Program2
    {
        public static void Main2()
        {
            var info = new TournirInfo2(4);
            // info.TeamsCount = 5; //так тоже нельзя, хотя поле public
        }
    }

    class Test
    {
        public readonly DateTime Time = DateTime.Now;
        //Вызов Now произойдет при создании объекта
        //в неявно созданном конструкторе
    }

    public class Ratio
    {

        public readonly int Numerator; //числитель
        public readonly int Denominator; //знаменатель
        public readonly double Value; //значение дроби Numerator / Denominator

        public Ratio(int num, int den)
        {
            Numerator = num;
            Denominator = den;
            if (Denominator <= 0)
                throw new ArgumentException();
            Value = (double)Numerator / Denominator;
        }
    }



    public class Program4
    {
        public static void Check(int num, int den)
        {
            var ratio = new Ratio(num, den);
            Console.WriteLine("{0}/{1} = {2}",
                ratio.Numerator, ratio.Denominator,
                ratio.Value.ToString(CultureInfo.InvariantCulture));
        }
    }


}
