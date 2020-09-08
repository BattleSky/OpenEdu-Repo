using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    class Practice1
    {

    }

    class Book : IComparable
    {
        public string Title;
        public int Theme;
        public int CompareTo(object obj)
        {
            var otherBook = (Book) obj;
            if (Theme.CompareTo(otherBook.Theme) < 0) // если номер-тема меньше
                return -1;
            if (Theme.CompareTo(otherBook.Theme) > 0) // если номер-тема больше
                return 1;
            if (Title.CompareTo(otherBook.Title) < 0) // если наименование меньше
                return -1;
            if (Title.CompareTo(otherBook.Title) > 0) // если наименование больше
                return 1;
            return 0; // иначе совпали
        }
    }
}
