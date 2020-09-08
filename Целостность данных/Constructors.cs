using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Целостность_данных
{
    public class TournirInfo0
    {
        public int TeamsCount { get; set; }
        public string[] TeamsNames { get; set; }
        public double[,] Scores { get; set; }

        //Все эти три поля связаны друг с другом, и нужно обеспечивать их целостность.
    }

    public class TournirInfo1
    {
        public int TeamsCount { get; private set; }
        public string[] TeamsNames { get; private set; }
        public double[,] Scores { get; private set; }

        public void Initialize(int teamsCount)
        {
            TeamsCount = teamsCount;
            TeamsNames = new string[teamsCount];
            Scores = new double[teamsCount, teamsCount];
        }

        //Теперь эти поля будут согласованы.
        //Но не очень хорошо, что между созданием класса var info=new TournirInfo1();
        //и его инициализацией info.Initialize(5); 
        //можно ошибочно использовать объект, к которому он не готов.
    }

    public class TournirInfo
    {
        public int TeamsCount { get; private set; }
        public string[] TeamsNames { get; private set; }
        public double[,] Scores { get; private set; }

        //Это конструктор - дополнительные действия по инициализации объекта
        // Он не возвращает ничего (даже не надо использовать void)
        // и обязательно имеет имя такое же как и у класса
        public TournirInfo(int teamsCount)
        {
            TeamsCount = teamsCount;
            TeamsNames = new string[teamsCount];
            Scores = new double[teamsCount, teamsCount];
        }

        //может быть несколько конструкторов, по аналогии с перегруженными методами
        public TournirInfo(params string[] teamNames)
        {
            TeamsCount = teamNames.Length;
            TeamsNames = teamNames;
            Scores = new double[TeamsCount, TeamsCount];
        }


        //public TournirInfo()
        //{
        //    TeamsCount = 4;
        //    TeamsNames = new string[TeamsCount];
        //    Scores = new double[TeamsCount, TeamsCount];
        //}
        //Так делать плохо: dont repeat yourself 
        // по сути он похож на инициализацию метода с intами

        // Лучше делать так: конструктор вызывает другой конструктор через ключевое слово this. 
        public TournirInfo()
            : this(4)
        { }
    }

    class Program34
    {
        public static void Main34()
        {
            var info = new TournirInfo(5);
            //теперь объект сразу будет инициализирован
            //не может возникнуть ситуация, при которой он может быть создан,
            //но не готов к использованию

        }
    }
}
