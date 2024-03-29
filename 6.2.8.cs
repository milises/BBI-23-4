//2 уровень. номер 8
//Для формирования сборной по хоккею предварительно отобрано 30 игроков. 
// На основании протоколов игр составлена таблица, в которой содержится 
//штрафное время каждого игрока по каждой игре (2, 5 или 10 мин).
//Написать программу, которая составляет список кандидатов в сборную 
//в порядке возрастания суммарного штрафного времени.
//Игрок, оштрафованный на 10 мин, из списка кандидатов исключается.
using System;

class Player
{
    public string Name { get; set; }
    public int[] PenaltyTimes { get; set; }
    public int TotalPenalty => CalculateTotalPenalty();

    private int CalculateTotalPenalty()
    {
        int total = 0;
        foreach (int time in PenaltyTimes)
        {
            if (time == 10) return int.MaxValue;
            total += time;
        }
        return total;
    }
}

class Program
{
    static void Main()
    {
        Player[] players = new Player[]
        {
            new Player { Name = "Player 1", PenaltyTimes = new int[] {2, 5, 2} },
            new Player { Name = "Player 2", PenaltyTimes = new int[] {5, 5, 5} },
            new Player { Name = "Player 3", PenaltyTimes = new int[] {10} },
            new Player { Name = "Player 4", PenaltyTimes = new int[] {10, 2, 2}},

        };

        for (int i = 1; i < players.Length; i++)
        {
            Player key = players[i];
            int j = i - 1;

            while (j >= 0 && players[j].TotalPenalty > key.TotalPenalty)
            {
                players[j + 1] = players[j];
                j = j - 1;
            }
            players[j + 1] = key;
        }

        Console.WriteLine("Список кандидатов в сборную:");
        foreach (var player in players)
        {
            if (player.TotalPenalty != int.MaxValue)
            {
                Console.WriteLine($"{player.Name} - {player.TotalPenalty} мин");
            }
        }
    }
}
