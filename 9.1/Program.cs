using System;
using System.IO;
using static JsonSerializeFormat;

abstract class Task
{
    public string Name { get; set; }
    public int Calls { get; set; }

    public Task(string name, int calls)
    {
        Name = name;
        Calls = calls;
    }
}

class PersonOfYear : Task
{
    public PersonOfYear(string name, int calls) : base(name, calls)
    {
    }
}

class DiscoveryOfYear : Task
{
    public DiscoveryOfYear(string name, int calls) : base(name, calls)
    {
    }
}

class Program
{
    static void Sort(Task[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            Task k = array[i];
            int j = i - 1;

            while (j >= 0 && array[j].Calls > k.Calls)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = k;
        }
    }

    static void Main()
    {
        string projectDirectory = Environment.CurrentDirectory;
        string jsonDirectory = Path.Combine(projectDirectory, "json");
        string peopleFilePath = Path.Combine(jsonDirectory, "people.json");
        string discoveriesFilePath = Path.Combine(jsonDirectory, "discoveries.json");

        if (!Directory.Exists(jsonDirectory))
        {
            Directory.CreateDirectory(jsonDirectory);
        }

        PersonOfYear[] peopleOfYear = new PersonOfYear[]
        {
            new PersonOfYear("Дмитрий Шеповалов", 100),
            new PersonOfYear("Василий Андреев", 80),
            new PersonOfYear("Артур Золотов", 70),
            new PersonOfYear("Ника Смирнова", 60),
            new PersonOfYear("Владислав Верховенко", 50)
        };

        DiscoveryOfYear[] discoveriesOfYear = new DiscoveryOfYear[]
        {
            new DiscoveryOfYear("Открытие в медицине", 200),
            new DiscoveryOfYear("Открытие в физике", 150),
            new DiscoveryOfYear("Открытие в математике", 120),
            new DiscoveryOfYear("Открытие в ИИ", 80),
            new DiscoveryOfYear("Открытие в химии", 70)
        };

        Sort(peopleOfYear);
        Sort(discoveriesOfYear);

        MySerializeFormat jsonSerializer = new JsonSerializeFormat();
        jsonSerializer.Serialize(peopleOfYear, peopleFilePath);
        jsonSerializer.Serialize(discoveriesOfYear, discoveriesFilePath);

        var deserializedPeople = jsonSerializer.Deserialize<PersonOfYear[]>(peopleFilePath);
        var deserializedDiscoveries = jsonSerializer.Deserialize<DiscoveryOfYear[]>(discoveriesFilePath);

        Console.WriteLine("Человек года:");
        foreach (PersonOfYear person in deserializedPeople)
        {
            Console.WriteLine("{0} был выбран человеком года {1} раз(а)", person.Name, person.Calls);
        }

        Console.WriteLine("\nОткрытие года:");
        foreach (DiscoveryOfYear dscvr in deserializedDiscoveries)
        {
            Console.WriteLine("{0} было отмечено событием года {1} раз(а)", dscvr.Name, dscvr.Calls);
        }
    }
}
