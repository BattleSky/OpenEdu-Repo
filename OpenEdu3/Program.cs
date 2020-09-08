using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEdu3
{
    class Program
    {
        static string GetLastHalf (string text)
        {
            int gethalf = (int)text.Length / 2;
            string removedoutput = text.Remove(0, gethalf);
            string output = removedoutput.Replace(" ", "");
            return output;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetLastHalf("I love CSharp!"));
            Console.WriteLine(GetLastHalf("1234567890"));
            Console.WriteLine(GetLastHalf("до ре ми фа соль ля си"));
        }
    }
}
