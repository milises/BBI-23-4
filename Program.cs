using System;
using System.IO;
using System.Linq;

abstract class Task
{
    public abstract void Solve(string input);
}

class Task1 : Task
{
    public override void Solve(string input)
    {
        int[] letterFrequency = new int[32];

        foreach (char symbol in input)
        {
            if (char.IsLetter(symbol) && char.IsLower(symbol))
            {
                int index = symbol - 'а';
                letterFrequency[index]++;
            }
        }

        for (int i = 0; i < letterFrequency.Length; i++)
        {
            double frequency = (double)letterFrequency[i] / input.Length;
            char letter = (char)('а' + i);
            Console.WriteLine($"{letter}: {frequency:P2}");
        }
    }
}

class Task3 : Task
{
    public override void Solve(string input)
    {
        int index = 0;
        while (index < input.Length)
        {
            int substringLength = Math.Min(50, input.Length - index);
            string line = input.Substring(index, substringLength);
            int lastSpaceIndex = line.LastIndexOf(' ');

            if (lastSpaceIndex != -1)
            {
                line = line.Substring(0, lastSpaceIndex);
                index += lastSpaceIndex + 1;
            }
            else
            {
                index += substringLength;
            }

            Console.WriteLine(line);
        }
    }
}

class Task5 : Task
{
    public override void Solve(string input)
    {
        string[] words = input.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        var letterFrequency = words
            .Select(word => word.ToLower()[0])
            .GroupBy(letter => letter)
            .OrderByDescending(group => group.Count());

        foreach (var group in letterFrequency)
        {
            Console.WriteLine($"{group.Key}: {group.Count()}");
        }
    }
}

class Task7 : Task
{
    public override void Solve(string input)
    {
        string sequence = "сла";

        string[] words = input.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        var matchingWords = words.Where(word => word.Contains(sequence));

        foreach (var word in matchingWords)
        {
            Console.WriteLine(word);
        }
    }
}

class Task11 : Task
{
    public override void Solve(string input)
    {
        char[] separators = new char[] { ',', ';', ' ', '\n' };

        string[] surnames = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(surnames, (x, y) =>
        {
            int compareResult = Char.ToLower(x.Trim()[0]) - Char.ToLower(y.Trim()[0]);
            if (compareResult == 0)
            {
                compareResult = string.Compare(x.Trim(), y.Trim());
            }

            return compareResult;
        });

        foreach (var surname in surnames)
        {
            Console.WriteLine(surname.Trim());
        }
    }
}

class Task14 : Task
{
    public override void Solve(string input)
    {
        string[] wordsAndNumbers = input.Split(' ');

        int sum = 0;
        foreach (var item in wordsAndNumbers)
        {
            if (int.TryParse(item, out int number))
            {
                sum += number;
            }
        }

        Console.WriteLine($"Сумма чисел: {sum}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] inputs = {
            File.ReadAllText(@"C:\\Users\\New\\source\\repos\\8 лаба\\8 лаба\\input1.txt"),
            File.ReadAllText(@"C:\\Users\\New\\source\\repos\\8 лаба\\8 лаба\\input3.txt"),
            File.ReadAllText(@"C:\\Users\\New\\source\\repos\\8 лаба\\8 лаба\\input5.txt"),
            File.ReadAllText(@"C:\\Users\\New\\source\\repos\\8 лаба\\8 лаба\\input7.txt"),
            File.ReadAllText(@"C:\\Users\\New\\source\\repos\\8 лаба\\8 лаба\\input11.txt"),
            File.ReadAllText(@"C:\\Users\\New\\source\\repos\\8 лаба\\8 лаба\\input14.txt")
        };

        Task[] tasks = {
            new Task1(),
            new Task3(),
            new Task5(),
            new Task7(),
            new Task11(),
            new Task14()
        };

        for (int i = 0; i < tasks.Length; i++)
        {
            Console.WriteLine($"Задача {i + 1}:");
            tasks[i].Solve(inputs[i]);
            Console.WriteLine();
        }
    }
}
