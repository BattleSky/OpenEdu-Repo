using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Структуры
{
    class Class2
    {
        struct MyStruct
        {
            public int field;
        }

        public static void Mainx()
        {
            MyStruct original;
            original.field = 10;
            // При апкасте к типу object, original копируется в стек как boxed и теперь на него ссылается original
            object boxed = (object)original;
            MyStruct unboxed = (MyStruct)boxed;

            unboxed.field = 20;

            Console.WriteLine(original.field);
            Console.WriteLine(unboxed.field);
        }
    }

    class Class3
    {

        public struct S { int A; }

        static void Mainx()
        {
            object[] s = new object[2];
            s[0] = new S();
            s[1] = s[0];
            Console.WriteLine(s[0] == s[1]);
        }
    }
}
