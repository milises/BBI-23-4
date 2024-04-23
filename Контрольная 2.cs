using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_ana_Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText = "Любой текст для проверки заданий. Это второе предложение. Третье предложение для проверки самого длинного предложения.";
            Task[] tasks = { new LongSenTask(inputText), new UniqueWordsTask(inputText) };
            foreach (Task task in tasks)
            {
                Console.WriteLine(task.Solve());
            }
        }
    }
}

public abstract class Task
{
    protected string text;

    public Task(string text)
    {
        this.text = text;
    }

    public abstract string Solve();
}

// 1. Класс для поиска самого длинного предложения
public class LongSenTask : Task
{
    public LongSenTask(string text) : base(text) { }

    public override string Solve()
    {
        string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string longestSentence = "";
        int maxLength = 0;

        foreach (string sentence in sentences)
        {
            string trimmedSentence = sentence.Trim();
            if (trimmedSentence.Length > maxLength)
            {
                maxLength = trimmedSentence.Length;
                longestSentence = trimmedSentence;
            }
        }

        return longestSentence;
    }
}

// 2. Класс для подсчета количества уникальных слов
public class UniqueWordsTask : Task
{
    public UniqueWordsTask(string text) : base(text) { }

    public override string Solve()
    {
        string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '-', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        HashSet<string> uniqueWords = new HashSet<string>(words, StringComparer.OrdinalIgnoreCase);

        return uniqueWords.Count.ToString();
    }
}
