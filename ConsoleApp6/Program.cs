using System;

    // Перечислители 

namespace ConsoleApp6
{
    enum DayOfTheWeek // Объявление перечисления
    {
        Monday, // Это перечислитель. По умолчанию DayOfTheWeek.Monday = 0;
        Tuesday, // И это перечислитель. DayOfTheWeek.Tuesday = 1;
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    enum DayOfTheWeek_v2
    {
        Monday, // По умолчанию DayOfTheWeek.Monday = 0;
        Tuesday, // DayOfTheWeek.Tuesday = 1;
        Wednesday = 10, // DayOfTheWeek.Wednesday теперь равен 10, а не 2,
        Thursday, // а значение DayOfTheWeek.Thursday будет равно 11;
        Friday,
        Saturday,
        Sunday
    }
    // Типы перечислений По умолчанию - int, но также можно использовать типы
    // byte, sbyte, short, ushort, int, uint, long и ulong.
    // Пример объявления перечисления типа short
    enum DayOfTheWeek_v3 : short
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    enum Suits
    {
        Wands,
        Coins,
        Cups,
        Swords
    }

    class Program
    {
        private static string GetSuit(Suits suit)
        {
            string[] array = new[] {"жезлов", "монет", "кубков", "мечей"};
            return array[(int) suit];
        }

        static void Main(string[] args)
        {
        Console.WriteLine("Без каста int: " + DayOfTheWeek.Thursday);
        Console.WriteLine("С кастом int: " + (int)DayOfTheWeek.Thursday);

            Console.WriteLine(GetSuit(Suits.Wands));
            Console.WriteLine(GetSuit(Suits.Coins));
            Console.WriteLine(GetSuit(Suits.Cups));
            Console.WriteLine(GetSuit(Suits.Swords));
        }
    }
}
