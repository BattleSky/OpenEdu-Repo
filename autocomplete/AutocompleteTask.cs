using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using NUnit.Framework;

namespace Autocomplete
{
    internal class AutocompleteTask
    {
        /// <returns>
        /// Возвращает первую фразу словаря, начинающуюся с prefix.
        /// </returns>
        /// <remarks>
        /// Эта функция уже реализована, она заработает, 
        /// как только вы выполните задачу в файле LeftBorderTask
        /// </remarks>
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];
            
            return null;
        }

        /// <returns>
        /// Возвращает первые в лексикографическом порядке count (или меньше, если их меньше count) 
        /// элементов словаря, начинающихся с prefix.
        /// </returns>
        /// <remarks>Эта функция должна работать за O(log(n) + count)</remarks>
        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var i = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);
            // получаем индекс левой границы, откуда считать
            var tempList = new List<string>(); //создаем лист для заполнения его словами из словаря
            for (var arrayIndex = 1; arrayIndex < count + 1; arrayIndex++)
            {
                if (i+arrayIndex < phrases.Count && phrases[i + arrayIndex].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    //если не вылезли за границы словаря и слово начинается с prefix, то добавляем
                    tempList.Add(phrases[i+arrayIndex]); 
            }

            return tempList.ToArray(); //выкидываем в качестве массива
        }

        /// <returns>
        /// Возвращает количество фраз, начинающихся с заданного префикса
        /// </returns>
        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            // тут стоит использовать написанные ранее классы LeftBorderTask и RightBorderTask
            var countOfPhrases = phrases.Count;
            var leftBorder = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, countOfPhrases);
            var rightBorder = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, countOfPhrases);
            
            return rightBorder - leftBorder -1;
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases()
        {
            var phrases = new List<string> { };
            var prefix = "b";
            var expected = new string[] { };
            var actual = AutocompleteTask.GetTopByPrefix(phrases, prefix, 3);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
        {
            var iterations = 3;
            var prefix = "";
            for (var i = 0; i < iterations; i++)
            {
                var phrases = new List<string> { };
                var expected = phrases.Count;
                var actual = AutocompleteTask.GetCountByPrefix(phrases, prefix);
                Assert.AreEqual(expected, actual);
                phrases.Add("a");
                phrases.Add("b");
                phrases.Add("c");
            }
        }

        [Test]
        public void CountTests()
        {
            var phrases = new List<string> { "aa", "ab", "ac", "bc" };
            var prefix = "a";
            var count = 2;
            var expected = new string[] {"aa", "ab"};

            var actual = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);
            Assert.AreEqual(expected,actual);

        }
    }
}
