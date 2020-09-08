using System;

// Лекция 1: https://www.youtube.com/watch?v=OMxsc6Csj4k
// Лекция 2: https://www.youtube.com/watch?v=UW8A9_r3XCQ

namespace ConsoleApp16
{
    class Program
    {
        public static int[] GetPoweredArray(int[] arr, int power)
        {
            var newArr = new int[arr.Length];

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = arr[i];
                newArr[i] = (int)Math.Pow(newArr[i], power);
            }
            return newArr;
        }

        public static void PrintArray(int[] arr)
        {
            foreach (var e in arr) 
                Console.WriteLine(e);

        }

        static void Main(string[] args)
        {
            var arrayToPower = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                // Метод PrintArray уже написан за вас
                PrintArray(GetPoweredArray(arrayToPower, 1));

                // если вы будете менять исходный массив, то следующие два теста сработают неверно:
                PrintArray(GetPoweredArray(arrayToPower, 2));
                PrintArray(GetPoweredArray(arrayToPower, 3));

                // не забывайте про частные случаи:
                PrintArray(GetPoweredArray(new int[0], 1));
                PrintArray(GetPoweredArray(new[] { 42 }, 0));
            
        }
    }
}
