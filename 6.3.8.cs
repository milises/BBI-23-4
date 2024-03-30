//3 уровень. 2 задание.
//Соревнования по футболу между командами проводятся в два этапа. Для
//проведения первого этапа участники разбиваются на две группы по 12 команд.
//Для проведения второго этапа выбирается 6 лучших команд каждой группы по
//результатам первого этапа. Составить список команд участников второго этапа.
using System;

class Team
{
    public string Name { get; }
    public int Points { get; }

    public Team(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public void Print()
    {
        Console.WriteLine($"Команда: {Name}, Очки: {Points}");
    }
}

class Program
{
    static void Main()
    {
        // 2 массива
        Team[] groupA = new Team[12];
        Team[] groupB = new Team[12];

        //участники для группы A
        groupA[0] = new Team("Team A1", 15);
        groupA[1] = new Team("Team A2", 25);
        groupA[2] = new Team("Team A3", 30);
        groupA[3] = new Team("Team A4", 10);
        groupA[4] = new Team("Team A5", 20);
        groupA[5] = new Team("Team A6", 18);
        groupA[6] = new Team("Team A7", 5);
        groupA[7] = new Team("Team A8", 8);
        groupA[8] = new Team("Team A9", 12);
        groupA[9] = new Team("Team A10", 28);
        groupA[10] = new Team("Team A11", 22);
        groupA[11] = new Team("Team A12", 17);

        //участники для группы B
        groupB[0] = new Team("Team B1", 16);
        groupB[1] = new Team("Team B2", 22);
        groupB[2] = new Team("Team B3", 28);
        groupB[3] = new Team("Team B4", 12);
        groupB[4] = new Team("Team B5", 19);
        groupB[5] = new Team("Team B6", 21);
        groupB[6] = new Team("Team B7", 7);
        groupB[7] = new Team("Team B8", 9);
        groupB[8] = new Team("Team B9", 13);
        groupB[9] = new Team("Team B10", 25);
        groupB[10] = new Team("Team B11", 18);
        groupB[11] = new Team("Team B12", 14);

        SortTeams(groupA);
        SortTeams(groupB);

        Team[] topPlayers = new Team[12];
        SelectTopPlayers(groupA, groupB, topPlayers);

        Console.WriteLine("Лучшие участники:");
        foreach (Team player in topPlayers)
        {
            player?.Print();
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

    static void SelectTopPlayers(Team[] groupA, Team[] groupB, Team[] topPlayers)
    {
        int aIndex = 0, bIndex = 0;
        for (int i = 0; i < topPlayers.Length; i++)
        {
            if (aIndex < groupA.Length && bIndex < groupB.Length)
            {
                if (groupA[aIndex].Points > groupB[bIndex].Points)
                {
                    topPlayers[i] = groupA[aIndex];
                    aIndex++;
                }
                else
                {
                    topPlayers[i] = groupB[bIndex];
                    bIndex++;
                }
            }
            else if (aIndex < groupA.Length)
            {
                topPlayers[i] = groupA[aIndex];
                aIndex++;
            }
            else if (bIndex < groupB.Length)
            {
                topPlayers[i] = groupB[bIndex];
                bIndex++;
            }
        }
    }
}