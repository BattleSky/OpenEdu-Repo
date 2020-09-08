using System;
using System.Collections.Generic;
using System.IO;

namespace Основы_ООП___DirectiryInfo_FileInfo
{
    class Program
    {
        /*
        * Поиск файлов .mp3 и .wav в листе директорий с файлами
        */
        public static void Main()
        {
            var list1 = new List<FileInfo>();

            FileInfo file1 = new FileInfo("\\A\\1.mp3");
            FileInfo file2 = new FileInfo("\\A\\2.wav");

            list1.Add(file1);
            list1.Add(file2);

            GetAlbums(list1);
        }

        public static bool IsListContainsThatPath(List<DirectoryInfo> fileList, DirectoryInfo filePath)
        {
            foreach (var e in fileList)
            {
                if (e.Name == filePath.Name)
                    return true;
            }
            return false;
        }

        public static List<DirectoryInfo> GetAlbums(List<FileInfo> files)
        {
            var fileList = new List<DirectoryInfo>();

            foreach (var e in files)
            {
                var dir = new DirectoryInfo(e.DirectoryName);
                var filePath = e.Directory;
                if (IsListContainsThatPath(fileList, filePath)) continue;
                if (e.Extension == ".mp3" || e.Extension == ".wav")
                    fileList.Add(dir);
            }

            return fileList;
        }

    }
}
