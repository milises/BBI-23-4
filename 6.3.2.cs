//3 уровень. 2 задание
// Соревнования по футболу между командами проводятся в два этапа. Для
//проведения первого этапа участники разбиваются на две группы по 12 команд.
//Для проведения второго этапа выбирается 6 лучших команд каждой группы по
//результатам первого этапа. Составить список команд участников второго этапа.
using System;

class Team
{
    public string Name { get; set; }
    public int Points { get; set; }
}

class Program
{
    static void Main()
    {
        Team[] groupA = new Team[]
        {
            new Team { Name = "Team A1", Points = 15 },
            new Team { Name = "Team A2", Points = 25 },
            new Team { Name = "Team A3", Points = 30 },
            new Team { Name = "Team A4", Points = 10 },
            new Team { Name = "Team A5", Points = 20 },
            new Team { Name = "Team A6", Points = 18 },
            new Team { Name = "Team A7", Points = 5 },
            new Team { Name = "Team A8", Points = 8 },
            new Team { Name = "Team A9", Points = 12 },
            new Team { Name = "Team A10", Points = 28 },
            new Team { Name = "Team A11", Points = 22 },
            new Team { Name = "Team A12", Points = 17 },
        };

        SortTeams(groupA);

        Team[] groupB = new Team[6];
        for (int i = 0; i < 6; i++)
        {
            groupB[i] = groupA[i];
        }

        Console.WriteLine("Команды, отобранные в группу Б:");
        foreach (Team team in groupB)
        {
            Console.WriteLine($"Команда: {team.Name}, Очки: {team.Points}");
        }
    }

    static void SortTeams(Team[] teams)
    {
        for (int i = 0; i < teams.Length - 1; i++)
        {
            int maxIndex = i;
            for (int j = i + 1; j < teams.Length; j++)
            {
                if (teams[j].Points > teams[maxIndex].Points)
                {
                    maxIndex = j;
                }
            }
            if (maxIndex != i)
            {
                Team temp = teams[i];
                teams[i] = teams[maxIndex];
                teams[maxIndex] = temp;
            }
        }
    }
}
