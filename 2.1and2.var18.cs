using System;

abstract class Task
{
    protected string text;

    public Task(string text)
    {
        this.text = text;
    }

    public abstract string Execute();
}

class Task1 : Task
{
    public Task1(string text) : base(text) { }

    public override string Execute()
    {
        string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string longestSentence = "";
        foreach (string sentence in sentences)
        {
            if (sentence.Length > longestSentence.Length)
            {
                longestSentence = sentence.Trim();
            }
        }
        return longestSentence;
    }
}

class Task2 : Task
{
    public Task2(string text) : base(text) { }

    public override string Execute()
    {
        string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string result = "";
        foreach (string sentence in sentences)
        {
            string[] words = sentence.Split(new char[] { ' ', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length > 0)
            {
                int middleIndex = words.Length / 2;
                result += words[middleIndex] + "\n";
            }
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string text = "Я напишу тут пару предложений. Это первое. А вот это второе предложение";
        Task[] tasks = { new Task1(text), new Task2(text) };
        Console.WriteLine(tasks[0].Execute());
        Console.WriteLine(tasks[1].Execute());
    }
}