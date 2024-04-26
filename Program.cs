//2.Создать класс «Футбольная команда» с 2 классами-наследниками: 
//«Женская футбольная команда» и «Мужская футбольная команда».
//Провести среди них отдельные соревнования, но вывести в общей таблице
//по 6 лучших женских и мужских команд, отсортированных по общему
//количеству баллов с указанием пола (т.е.: 1.ЦСКА женская команда 13 баллов; 
//2 Динамо мужская команда 12 баллов; 3 Спартак мужская команда 10 баллов…).
//Использовать динамическую связку: преобразование классов.
//Должно быть 2 массива команд: мужские и женские.
//Потом объединяете и сортируете, и выводите.
using System;

class Team
{
    public string Name { get; }
    public int Points { get; }
    public string Gender { get; }

    public Team(string name, int points, string gender)
    {
        Name = name;
        Points = points;
        Gender = gender;
    }
}

class WomenFootballTeam : Team
{
    public WomenFootballTeam(string name, int points) : base(name, points, "Женская")
    {
    }
}

class MenFootballTeam : Team
{
    public MenFootballTeam(string name, int points) : base(name, points, "Мужская")
    {
    }
}

class Program
{
    static void Main()
    {
        WomenFootballTeam[] womenTeams = new WomenFootballTeam[]
        {
            new WomenFootballTeam("ЦСКА", 15),
            new WomenFootballTeam("Зенит", 25),
            new WomenFootballTeam("КАМАЗ", 30),
            new WomenFootballTeam("Локомотив", 10),
            new WomenFootballTeam("Чертаново", 20),
            new WomenFootballTeam("Химки", 18),
            new WomenFootballTeam("Штурм", 5),
            new WomenFootballTeam("Спартак", 8),
            new WomenFootballTeam("Динамо", 12),
            new WomenFootballTeam("Енисей", 28),
            new WomenFootballTeam("Звезда", 22),
            new WomenFootballTeam("Рубин", 17)
        };

        MenFootballTeam[] menTeams = new MenFootballTeam[]
        {
            new MenFootballTeam("Балтика", 16),
            new MenFootballTeam("Динамо", 22),
            new MenFootballTeam("Локомотив", 28),
            new MenFootballTeam("Авангард", 12),
            new MenFootballTeam("Акрон", 19),
            new MenFootballTeam("Енисей", 21),
            new MenFootballTeam("Калуга", 7),
            new MenFootballTeam("Оренбург", 9),
            new MenFootballTeam("Салют", 13),
            new MenFootballTeam("Факел", 25),
            new MenFootballTeam("Шинник", 18),
            new MenFootballTeam("Арсенал", 14)
        };

        SortTeams(womenTeams);
        SortTeams(menTeams);

        Team[] topTeams = MergeAndSortTeams(womenTeams, menTeams);

        Console.WriteLine("Лучшие команды:");
        PrintTopTeams(topTeams);
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

    static Team[] MergeAndSortTeams(WomenFootballTeam[] womenTeams, MenFootballTeam[] menTeams)
    {
        Team[] mergedTeams = new Team[womenTeams.Length + menTeams.Length];
        Array.Copy(womenTeams, mergedTeams, womenTeams.Length);
        Array.Copy(menTeams, 0, mergedTeams, womenTeams.Length, menTeams.Length);

        Array.Sort(mergedTeams, (x, y) => String.Compare(x.Gender, y.Gender));

        Array.Sort(mergedTeams, (x, y) =>
        {
            if (x.Gender == y.Gender)
            {
                return y.Points.CompareTo(x.Points);
            }
            return 0;
        });

        return mergedTeams;
    }

    static void PrintTopTeams(Team[] teams)
    {
        int womenCount = 0;
        int menCount = 0;

        foreach (Team team in teams)
        {
            if (team.Gender == "Женская" && womenCount < 6)
            {
                Console.WriteLine($"{team.Gender} команда {team.Name}, {team.Points} баллов");
                womenCount++;
            }
            else if (team.Gender == "Мужская" && menCount < 6)
            {
                Console.WriteLine($"{team.Gender} команда {team.Name}, {team.Points} баллов");
                menCount++;
            }

            if (womenCount == 6 && menCount == 6)
            {
                break;
            }
        }
    }
}
