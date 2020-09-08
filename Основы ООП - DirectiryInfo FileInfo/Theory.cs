using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Основы_ООП___DirectiryInfo_FileInfo
{
    class Theory
    {
        static void Main1()
        {
            foreach (var file in Directory.GetFiles("."))
                Console.WriteLine(file);

            Console.WriteLine(Directory.GetParent("."));

            var directoryInfo = new DirectoryInfo("."); // создается новый объект класса DirectoryInfo

            foreach (var file in directoryInfo.GetFiles())
                Console.WriteLine(file.Name);
            directoryInfo = directoryInfo.Parent; // всё это нужно для упрощения написания кода, 
            // получения ошибок на этапе компиляции, а не в рантайме
            Console.WriteLine(directoryInfo.FullName);
        }
    }

}
