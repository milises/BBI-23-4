using System;
using System.IO;

class Program
{
    static void Main()
    {
        string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

        string folderPath = Path.Combine(downloadsPath, "Fourth Task");

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Console.WriteLine($"Папка {folderPath} создана.");
        }
        else
        {
            Console.WriteLine($"Папка {folderPath} уже существует.");
        }

        string filePath1 = Path.Combine(folderPath, "string_1.json");
        string filePath2 = Path.Combine(folderPath, "string_2.json");

        if (!File.Exists(filePath1))
        {
            File.Create(filePath1).Close();
            Console.WriteLine($"Файл {filePath1} создан.");
        }
        else
        {
            Console.WriteLine($"Файл {filePath1} уже существует.");
        }

        if (!File.Exists(filePath2))
        {
            File.Create(filePath2).Close();
            Console.WriteLine($"Файл {filePath2} создан.");
        }
        else
        {
            Console.WriteLine($"Файл {filePath2} уже существует.");
        }
    }
}