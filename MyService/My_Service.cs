using System;
using System.IO;
using System.Xml.Linq;

namespace WCFMyServiceLibrary
{
    public class MyService : IMyService
    {

        private const string FilePath1 = @"C:\Users\Grisha\Desktop\text.txt";
        private const string FilePath2 = @"C:\Users\Grisha\Desktop\text2.txt";
        private const string FilePath3 = @"C:\Users\Grisha\Desktop\text3.txt";

        // Запись
        public void WriteToFile(string text, string fileName = "text.txt")
        {
            string filePath = fileName.ToLower() == "text2.txt" ? FilePath2 : FilePath1;
            File.WriteAllText(filePath, text);
        }

        // Чтение
        public string ReadFromFile(string fileName = "text.txt")
        {
            string filePath = fileName.ToLower() == "text2.txt" ? FilePath2 : FilePath1;
            return File.Exists(filePath) ? File.ReadAllText(filePath) : "Файл не найден.";
        }



        // Чтение выбор
        public string ReadFromFileChoice(string fileName2 = "text3.txt")
        {
            switch (fileName2.ToLower()) // Приводим ввод к нижнему регистру для унификации
            {
                case "a": // Выбор первого файла
                    string filePath2 = FilePath2; // Присваиваем путь к первому файлу
                    if (File.Exists(filePath2)) // Проверяем существование файла
                    {
                        return File.ReadAllText(filePath2); // Читаем и возвращаем содержимое файла
                    }
                    else
                    {
                        return "Файл не найден."; // Файл не найден, возвращаем сообщение
                    }
                case "b": // Выбор второго файла
                    string filePath3 = FilePath3; // Присваиваем путь ко второму файлу
                    if (File.Exists(filePath3))
                    {
                        return File.ReadAllText(filePath3); // Читаем и возвращаем содержимое файла
                    }
                    else
                    {
                        return "Файл не найден."; // Файл не найден, возвращаем сообщение
                    }
                default: // Неправильный ввод
                    return "Неизвестный выбор файла."; // Сообщение о неверном выборе
            }
        }

    }
}