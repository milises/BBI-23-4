using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        // путь к папке Загрузки
        string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

        // путь к папке Fourth Task
        string folderPath = Path.Combine(downloadsPath, "Fourth Task");

        // проверка, существует ли папка "Fourth Task". если что, создаем ее.
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Console.WriteLine($"Папка {folderPath} создана.");
        }
        else
        {
            Console.WriteLine($"Папка {folderPath} уже существует.");
        }

        // пути к файлам
        string filePath1 = Path.Combine(folderPath, "string_1.json");
        string filePath2 = Path.Combine(folderPath, "string_2.json");

        // JsonIO для работы с файлами
        JsonIO jsonIO = new JsonIO();

        // проверка "string_1.json"
        if (File.Exists(filePath1))
        {
            string data = jsonIO.ReadFromFile(filePath1);
            Console.WriteLine($"Данные из файла {filePath1}: {data}");
        }
        else
        {
            var inputData1 = new { Task = 1, Input = "Example input 1", Output = "Example output 1" };
            jsonIO.SaveToFile(filePath1, inputData1);
            Console.WriteLine($"Файл {filePath1} создан с данными.");
        }

        // проверка "string_2.json"
        if (File.Exists(filePath2))
        {
            string data = jsonIO.ReadFromFile(filePath2);
            Console.WriteLine($"Данные из файла {filePath2}: {data}");
        }
        else
        {
            var inputData2 = new { Task = 2, Input = "Example input 2", Output = "Example output 2" };
            jsonIO.SaveToFile(filePath2, inputData2);
            Console.WriteLine($"Файл {filePath2} создан с данными.");
        }
    }
}

class JsonIO
{
    // сохранение данных в файл в формате JSON
    public void SaveToFile(string filePath, object data)
    {
        string jsonData = SerializeToJson(data);
        File.WriteAllText(filePath, jsonData);
    }

    // чтение данных из файла в формате JSON
    public string ReadFromFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    // сериализация объекта в JSON строку
    private string SerializeToJson(object obj)
    {
        var jsonString = new StringBuilder();
        jsonString.Append("{");

        var properties = obj.GetType().GetProperties();
        for (int i = 0; i < properties.Length; i++)
        {
            var prop = properties[i];
            jsonString.AppendFormat("\"{0}\":\"{1}\"", prop.Name, prop.GetValue(obj));
            if (i < properties.Length - 1)
            {
                jsonString.Append(",");
            }
        }

        jsonString.Append("}");
        return jsonString.ToString();
    }
}
