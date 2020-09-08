using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Целостность_данных
{
    public class Statistics2
    {
        private int _totalCount;
        private int _successCount;
        // private - дает доступ изнутри класса Statistics, а не извне
        public void AccountCase(bool isSuccess)
        {
            if (isSuccess) _successCount++;
            _totalCount++;
        }
        public void Print()
        {
            Console.WriteLine("{0}%", (_successCount * 100) / _totalCount);
        }
    }

    public class Program1
    {
        public static void Main1()
        {
            var rnd = new Random();
            var stat = new Statistics2();
            for (int i = 0; i < 1000; i++)
                stat.AccountCase(rnd.Next(3) > 1);
            stat.Print();

            //Теперь так сделать нельзя: доступ к приватным полям возможен только изнутри класса
            //stat.totalCount = 100;
            //stat.successCount = 146;
        }
    }
}
