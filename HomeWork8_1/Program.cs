using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork8_1
{
    //Выберите любую папку на своем компьютере, имеющую вложенные директории.
    //Выведите на консоль ее содержимое и содержимое всех подкаталогов.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите пожалуйста путь до каталога, сведения о содержимом которого хотите получить.");
            string path = Console.ReadLine();
            Console.Clear();
            GetPathInfo(path);
            Console.ReadKey();
        }
        static void GetPathInfo(string path)
        {
            DirectoryInfo directories = new DirectoryInfo(path);
            if (directories.GetDirectories().Length > 0)        // код для каталога содержащего вложенные подкаталоги и файлы
            {
                Console.WriteLine();
                Console.WriteLine("Содержимое папки {0}", path);
                Console.WriteLine();
                Console.WriteLine("-------каталоги-------");
                Console.WriteLine();
                foreach (DirectoryInfo directory in directories.GetDirectories())
                {
                    Console.WriteLine(directory.Name);                    
                }
                if (directories.GetFiles().Length > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("-------Файлы-------");
                    Console.WriteLine();
                    foreach (FileInfo file in directories.GetFiles())
                    {
                        Console.WriteLine(file.Name);
                    }
                }                
            }
            else if (directories.GetDirectories().Length == 0)      //код для каталога не содержащего подкаталогов
            {
                Console.WriteLine();                
                Console.WriteLine("Содержимое папки {0}", path);
                Console.WriteLine();
                Console.WriteLine("-------Файлы-------");
                Console.WriteLine();
                foreach (FileInfo file in directories.GetFiles())
                {
                     Console.WriteLine(file.Name);
                }                
            }
            foreach (DirectoryInfo directory in directories.GetDirectories())
            {
                GetPathInfo(path + "/" + directory.Name);  //метод вызывает рекрсию
            }
        }

    }
}
