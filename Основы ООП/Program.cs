using System;
using System.Data.Common;

namespace Основы_ООП
{
    public class Student
    {
        //Так объявляется поле класса.
        //Оно не статическое, т.е. не является глобальной переменной. 
        //Разницу между статическими и динамическими полями мы разберем позже.
        //С ключевым словом public мы также разберемся позже
        public int Age;
        public string FirstName;
        public string LastName;
    }

    public class Program
    {
        //мы можем создать массив из Student, потому что Student — это такой же тип, как string или int
        static Student[] students;

        //Этот тип можно использовать в аргументах метода. 
        //Если мы захотим добавить новое поле в Student, не придется переписывать заголовок метода
        static void PrintStudent(Student student)
        {
            Console.WriteLine("{0,-15}{1}", student.FirstName, student.LastName);
        }

        static void Main()
        {
            students = new Student[2]; // Инициализация массива

            //Классы — это ссылочные типы, поэтому их нужно инициализировать.
            //Можно сделать собственный тип-значение, но это мы рассмотрим позже.

            students[0] = new Student(); // Инициализация элемента массива
            students[0].FirstName = "John"; // Получение доступа к полям
            students[0].LastName = "Jones";
            students[0].Age = 19;
            students[1] = new Student(); // Инициализация элемента массива
            students[1].FirstName = "William";
            students[1].LastName = "Williams";
            students[1].Age = 18;

            //Cокращенная инициализация — это то же самое
            students = new Student[2]
            {
                new Student {LastName = "Jones", FirstName = "John"},
                new Student {LastName = "Williams", FirstName = "William"}
            };

            //Ещё больше упрощений инициализации
            students = new[]
            {
                new Student {LastName = "Jones", FirstName = "John"},
                new Student {LastName = "Williams", FirstName = "William"}
            };
        }

        /*
        *  Примеры использования классов.  (Практика)
        */


        //Для каждого пункта меню указывается название, горячая клавиша(далее указана в скобках) и список подменю(null, если подменю нет).
        //На верхнем уровне должно находится два пункта: File(F) и Edit(E).
        //Меню File должно содержать команды New(N), Save(S).
        ////Меню Edit(E) должно содержать команды Copy(C) и Paste(V).
        //Решите задачу в одно выражение с использованием сокращенного синтаксиса создания объектов.
        //Используйте переводы строк и отступы, чтобы сделать код более читаемым.

        public static MenuItem[] GenerateMenu()
        {
            return new[] {
                new MenuItem
                {
                    Caption = "File", HotKey = "F", Items = new[]
                    {
                        new MenuItem {Caption = "New", HotKey = "N"},
                        new MenuItem {Caption = "Save", HotKey = "S"}
                    }
                },
                new MenuItem
                {
                    Caption = "Edit", HotKey = "E", Items = new[]
                    {
                        new MenuItem {Caption = "Copy", HotKey = "C"},
                        new MenuItem {Caption = "Paste", HotKey = "V"}
                    }
                }
            };
        }

    }


    public class GeoLocation
    {
        public double Latitude;
        public double Longitude;
    }

    public class City
    {
        public string Name;
        public GeoLocation Location;
    }
    public class MenuItem
    {
        public string Caption;
        public string HotKey;
        public MenuItem[] Items;
    }

}

