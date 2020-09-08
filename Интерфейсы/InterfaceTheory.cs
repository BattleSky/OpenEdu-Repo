using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    /*
     * Интерфейс - это контракт.
     * Обязательство для класса содержать определенные методы
     * Когда класс реализует интерфейс, он как бы говорит:
     * "Я согласен, я буду реализовывать эти методы"
     */
    class InterfaceTheory
    {
        public static void Sort(Array array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            for (int j = 1; j <= i; j++)
            {
                object element1 = array.GetValue(j - 1);
                object element2 = array.GetValue(j);
                var comparableElement1 = (IComparable)element1;
                    /* Эта операция очень похожа на downcast. Мы берем object и кастуем его в IComparable
                     * Если эта лоперация удачна, мы получим comparableElement1 иначе - Exception
                     * Это нормально, ведь мы не можем отсортировать массив, если его элементы не сравнимы между собой
                     * 
                     * comparableElement1 может указывать только на тот ОБЪЕКТ, КЛАСС которого реализует ИНТЕРФЕЙС IComparable
                     * Если comparableElement1 указывает на объект, класс которого реализует ИНТЕРЙЕС IComparable, значит этот
                     * объект ТОЧНО содержит метод CompareTo.
                     * Потому что КЛАСС РЕАЛИЗУЕТ ИНТЕРФЕЙС и это ОБЯЗАТЕЛЬСТВО, т.е. в классе дожен быть метод
                     * CompareTo
                     * Идеалогия контракта: Класс подписал контракт "Я содержу метод CompareTo",
                     * соответственно все объекты получают метод CompareTo
                     */
                    if (comparableElement1.CompareTo(element2) < 0)
                {
                    object temporary = array.GetValue(j);
                    array.SetValue(array.GetValue(j - 1), j);
                    array.SetValue(temporary, j - 1);
                }
            }
        }

        /* Как сделать собственный класс, объекты которого сравнимы между собой?
         */

        static void Main5()
        {
            var pointArray = new Point[]
            {
                new Point {X = 1, Y = 1},
                new Point {X = 2, Y = 2},
                new Point {X = 3, Y = 3}
            };
            Sort(pointArray); 
            Sort(new int[] { 1, 2, 3 });
            Sort(new string[] { "A", "B", "C" });
        }
	}


}
