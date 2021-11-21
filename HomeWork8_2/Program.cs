using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork8_2
{
    //Программно создайте текстовый файл и запишите в него 10 случайных чисел.
    //Затем программно откройте созданный файл, рассчитайте сумму чисел в нем, ответ выведите на консоль.
    class Program
    {
        static void Main(string[] args)
        {
            string path = "MyFiles";
            string fileName = "/File.txt";
            CreateFileInDirectory(path, fileName);
            WriteRandomNumbersFile(path, fileName);
            FileReadAndSummCalculate(path, fileName);
            Console.ReadKey();
        }
        static void CreateFileInDirectory(string path, string fileName)  //метод, создающий файл в указанном каталоге, при отсутствии каталога создает его
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else if (Directory.Exists(path) && !File.Exists(path + fileName))
            {
                File.Create(path + fileName);
            }
        }
        static void WriteRandomNumbersFile(string path, string fileName)    //метод записывающий в файл 10 случайных чисел
        {
            if (File.Exists(path + fileName))
            {
                Random random = new Random();
                using (StreamWriter myFileWrite = new StreamWriter(path + fileName))
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        myFileWrite.Write("{0} ", random.Next(-100, 100));
                    }
                }
            }
        }
        static void FileReadAndSummCalculate(string path, string fileName)      //метод считывающий числа из файла и вычисляющий их сумму с выводом на консоль
        {
            if (File.Exists(path + fileName))
            {
                int summ = 0;
                string numbersString;
                string[] numbersStringArray;                
                using (StreamReader myFileRead = new StreamReader(path + fileName))
                {
                    numbersString = myFileRead.ReadLine();
                }
                numbersStringArray = numbersString.Trim().Split();
                foreach (string number in numbersStringArray)
                {
                    summ += Convert.ToInt32(number);
                }
                Console.WriteLine("Сумма чисел в созданном файле: {0}", summ);
            }
        }
    }
}
