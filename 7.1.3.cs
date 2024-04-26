//1 уровень.задание 3
//Радиокомпания провела опрос слушателей по вопросу: «Кого вы считаете человеком года?». 
//Определить пять наиболее часто встречающихся ответов и их долей
//(в процентах от общего количества ответов).Сделать абстрактный класс, и от него создать 2-х наследников:
//человек года и открытие года. Собрать 2 таблицы с ответами и вывести 2 таблицы (независимые).
using System;

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

        int totalPeopleCount = 0;
        foreach (PersonOfYear person in peopleOfYear)
        {
            totalPeopleCount += person.Calls;
        }

        int totalDiscoveryCount = 0;
        foreach (DiscoveryOfYear dscvr in discoveriesOfYear)
        {
            totalDiscoveryCount += dscvr.Calls;
        }

        Sort(peopleOfYear);
        Sort(discoveriesOfYear);

        Console.WriteLine("Человек года:");
        foreach (PersonOfYear person in peopleOfYear)
        {
            Console.WriteLine("{0} был выбран человеком года {1} раз(а)", person.Name, person.Calls);
        }

        Console.WriteLine("\nОткрытие года:");
        foreach (DiscoveryOfYear dscvr in discoveriesOfYear)
        {
            Console.WriteLine("{0} было отмечено событием года {1} раз(а)", dscvr.Name, dscvr.Calls);
        }
    }
}