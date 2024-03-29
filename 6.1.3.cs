// Уровень 1. Номер 3
// Радиокомпания провела опрос слушателей по вопросу: «Кого вы считаете
// человеком года?». Определить пять наиболее часто встречающихся ответов и их
// долей (в процентах от общего количества ответов).
struct Person
{
    private string Name;
    public int Calls { get; private set; }
    public double prop { get; private set; }
    public Person(string name, int calls)
    {
        Name = name;
        Calls = calls;
    }
    public void Proportion(int count)
    {
        prop = (double)Calls * 100 / count;
    }
    public void Print()
    {
        Console.WriteLine("{0:f0} был выбран {1:f0} раз(а), доля от всех выбранных: {2:f3}%", Name, Calls, prop);
    }
}
class Program
{
    static void Sort(Person[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            Person k = array[i];
            int j = i - 1;

            while (j >= 0 && array[j].prop > k.prop)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = k;
        }
    }
    static void Main()
    {
        Person[] people = new Person[]
        {
            new Person("Дмитрий Шеповалов", 100),
            new Person("Василий Андреев", 80),
            new Person("Артур Золотов", 70),
            new Person("Ника Смирнова", 60),
            new Person("Владислав Верховенко", 50),
            new Person("Алексей Терракотов", 40),
            new Person("Марина Глазнева", 30),
            new Person("Василиса Валерьева", 20),
            new Person("Мира Голарьева", 10),
        };
        int count = 0;
        for (int i = 0; i < people.Length; i++) count += people[i].Calls;
        for (int i = 0; i < people.Length; i++) people[i].Proportion(count);

        Sort(people);

        for (int i = people.Length - 1; i > people.Length - 6; i--)
        {
            people[i].Print();
        }
    }
}



