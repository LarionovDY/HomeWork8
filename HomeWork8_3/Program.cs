using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork8_3
{
    class Program
    {
        //Вручную подготовьте текстовый файл с фрагментом текста.
        //Напишите программу, которая выводит статистику по файлу - количество символов, строк и слов в тексте.
        static void Main(string[] args)
        {
            string path = "MyFiles";
            string fileName = "/File.txt";
            TextStatistics(path, fileName);
            Console.ReadKey();
        }
        static void TextStatistics(string path, string fileName) //метод подсчитывающий кол-во элементов текста, путем его разделения на массивы по различным разделителям
        {
            if (File.Exists(path + fileName))
            {
                string textString;
                string[] stringArray;
                string[] wordArray;
                char[] charArray;
                using (StreamReader myFileRead = new StreamReader(path + fileName))
                {
                    textString = myFileRead.ReadToEnd();
                }
                stringArray = textString.Split('\n');
                wordArray = textString.Split(' ', '\n');
                charArray = textString.ToCharArray();                
                Console.WriteLine("Количество строк в тексте: {0}, слов: {1}, символов: {2}", stringArray.Length, wordArray.Length, charArray.Length);                
            }
        }
    }
}
