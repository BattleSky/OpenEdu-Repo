using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Целостность_данных
{
    public class Transaction5
    {
        public int DepartmentId;
        public double Profit;
    }

    // СВОЙСТВО ЭТО НЕ ПОЛЕ

    public class ReportData5
    {
        private int departmentsCount;

        //Свойство - это синтаксический сахар для пары методов
        //GetDepartmentsCount и SetDepartmentsCount,
        //которые были приведены на прошлом слайде
        public int DepartmentsCount
        {
            get { return departmentsCount; }
            set
            {
                if (value < 0) throw new ArgumentException();
                departmentsCount = value;
            }
        }

        /*Это аналог того, что написано
         *
        public int GetDepartmentsCount() { return departmentsCount; }
        public void SetDepartmentsCount(int value)
        {
            if (value < 0) throw new ArgumentException();
            departmentsCount = value;
        }
         */


        //Чтобы упростить эту практику, придумали автосвойства
        //Следующая строка делает то же самое, что и предыдущие 5, автоматически
        public string FirstName { get; set; }

        //Возможен различные модификаторы доступа у свойств
        public string Id { get; private set; }

        public class Purchase
        {
            public double Price { get; set; }
            public double Count { get; set; }

            //В этом случае никакого поля не создается, и вообще это свойство не связано с хранением данных
            //Это просто удобный синтаксический сахар, можно было бы использовать метод GetSalary() { return Price*Count; }
            //Но в шарпе принято писать так
            public double Summary
            {
                get { return Price * Count; }
            }
        }








        public List<Transaction> Transactions = new List<Transaction>();
        public void PrintProfits()
        {
            var profits = new double[departmentsCount];
            foreach (var e in Transactions)
                profits[e.DepartmentId] += e.Profit;
            for (int i = 0; i < departmentsCount; i++)
                Console.WriteLine("{0,-10}{1}", i, profits[i]);
        }
    }

    public class Program
    {
        public static void Main8()
        {
            var report = new ReportData5
            {
                DepartmentsCount = 2, //теперь снова можно писать так
                Transactions = {
                    new Transaction { DepartmentId=0, Profit=10000 },
                    new Transaction { DepartmentId=1, Profit=20000 },
                    new Transaction { DepartmentId=1, Profit=10000 }
                }
            };
            // report.SetDepartmentsCount(2); -- так, разумеется, писать нельзя, никаких методов больше нет, есть свойства
            report.PrintProfits();

            report.DepartmentsCount++; //а так писать можно.

            //report.departmentsCount = -1; - так по-прежнему писать нельзя
            report.DepartmentsCount = -1; // Так можно, и мы поймаем исключение
        }

    }

    public class Student
    {

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value ?? throw new ArgumentException(); }
        }
    }

}
