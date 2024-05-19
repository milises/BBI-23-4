using System;
using System.IO;

abstract class Task
{
    public string[] Players { get; set; }
    public int[] Penalties { get; set; }
    public Task(string[] players, int[] penalties)
    {
        Players = players;
        Penalties = penalties;
    }

    public abstract void AddPenalty(int index, int penalty); // Базовый метод добавления штрафа

    public abstract void PrintPlayers();
}

class Hockey : Task
{
    public Hockey(string[] players, int[] penalties) : base(players, penalties)
    {
    }

    public override void AddPenalty(int index, int penalty)
    {
        Penalties[index] = penalty; // Изменяется штраф для хоккея
    }

    public override void PrintPlayers()
    {
        if (Players != null)
        {
            Console.WriteLine("Список кандидатов в сборную по хоккею:");
            for (int i = 0; i < Players.Length; i++)
            {
                if (Penalties[i] != 10 && Penalties[i] != 0)
                {
                    Console.WriteLine($"{Players[i]} - {Penalties[i]} мин");
                }
            }
        }
    }
}

class Basketball : Task
{
    public Basketball(string[] players, int[] penalties) : base(players, penalties)
    {
    }

    public override void AddPenalty(int index, int penalty)
    {
        if (penalty >= 4)
        {
            Penalties[index] = 0; // Исключение игрока
        }
        else
        {
            Penalties[index] = penalty;
        }
    }

    public override void PrintPlayers()
    {
        if (Players != null)
        {
            Console.WriteLine("\nСписок кандидатов в сборную по баскетболу:");
            for (int i = 0; i < Players.Length; i++)
            {
                if (Penalties[i] != 0 && Penalties[i] != 4 && Penalties[i] != 5)
                {
                    Console.WriteLine($"{Players[i]} - {Penalties[i]} фолов");
                }
                else if (Penalties[i] == 4 || Penalties[i] == 5)
                {
                    Console.WriteLine($"{Players[i]} - Исключен из-за {Penalties[i]} фолов");
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string projectDirectory = Environment.CurrentDirectory;
        string jsonDirectory = Path.Combine(projectDirectory, "json");
        string hockeyFilePath = Path.Combine(jsonDirectory, "hockey.json");
        string basketballFilePath = Path.Combine(jsonDirectory, "basketball.json");

        if (!Directory.Exists(jsonDirectory))
        {
            Directory.CreateDirectory(jsonDirectory);
        }

        Task hockey = new Hockey(new string[] { "Player 1", "Player 2", "Player 3", "Player 4", "Player 5" },
                                 new int[] { 2, 5, 6, 8, 3 });

        Task basketball = new Basketball(new string[] { "Player 1", "Player 2", "Player 3", "Player 4", "Player 5" },
                                          new int[] { 1, 3, 4, 2, 5 });

        MySerializeFormat jsonSerializer = new JsonSerializeFormat();
        jsonSerializer.Serialize(hockey, hockeyFilePath);
        jsonSerializer.Serialize(basketball, basketballFilePath);

        var deserializedHockey = jsonSerializer.Deserialize<Hockey>(hockeyFilePath);
        var deserializedBasketball = jsonSerializer.Deserialize<Basketball>(basketballFilePath);

        Console.WriteLine("Хоккей:");
        deserializedHockey.PrintPlayers();

        Console.WriteLine("\nБаскетбол:");
        deserializedBasketball.PrintPlayers();
    }
}
