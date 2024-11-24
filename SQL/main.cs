using System;
using System.IO;

namespace Program
{
    public class Program
    {
        private static string Path = "D:\\Desktop\\User.sql";

        public static void Main(string[] args)
        {
            Show(Path);
        }

        public static void Show(string path)
        {
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Файл не найден: " + path);
            }
        }
    }
}
