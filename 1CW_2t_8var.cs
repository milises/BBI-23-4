using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Goods
{
    public string Name { get; }
    public string Description { get; private set; }
    public double BasePrice { get; }
    public string Article { get; }

    public double Price { get; protected set; }

    protected Goods(string name, double basePrice)
    {
        Name = name;
        BasePrice = basePrice;
        Price = basePrice;
        Description = $"Для товара {name} описание не задано";
        Article = Guid.NewGuid().ToString(); //уникальный артикул
    }

    public void ChangeDescription(string newDescription)
    {
        if (newDescription.Length < 20 || newDescription.Length > 200)
        {
            Console.WriteLine("Ошибка: Описание должно быть не короче 20 и не длиннее 200 символов.");
            return;
        }
        Description = newDescription;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Стоимость: {Price:F2}");
        Console.WriteLine($"Артикул: {Article}");
        Console.WriteLine();
    }
}

class Beverage : Goods
{
    private double sugarConcentration;

    public double SugarConcentration
    {
        get => sugarConcentration;
        set
        {
            sugarConcentration = value;
            UpdatePrice();
        }
    }

    public Beverage(string name, double basePrice, double sugarConcentration)
        : base(name, basePrice)
    {
        SugarConcentration = sugarConcentration;
    }

    private void UpdatePrice()
    {
        if (SugarConcentration > 5)
        {
            Price = BasePrice * 1.10;
        }
        else
        {
            Price = BasePrice;
        }
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Концентрация сахара: {SugarConcentration}%");
    }
}

class Food : Goods
{
    private int shelfLife;

    public int ShelfLife
    {
        get => shelfLife;
        set
        {
            shelfLife = value;
            UpdatePrice();
        }
    }

    public Food(string name, double basePrice, int shelfLife)
        : base(name, basePrice)
    {
        ShelfLife = shelfLife;
    }

    private void UpdatePrice()
    {
        if (ShelfLife < 30)
        {
            Price = BasePrice * 1.05;
        }
        else if (ShelfLife > 365)
        {
            Price = BasePrice * 0.95;
        }
        else
        {
            Price = BasePrice;
        }
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Срок годности: {ShelfLife} дней");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Beverage[] beverages = new Beverage[5]
        {
            new Beverage("Кола", 50, 10),
            new Beverage("Пепси", 45, 8),
            new Beverage("Фанта", 48, 5),
            new Beverage("Спрайт", 47, 6),
            new Beverage("Байкал", 55, 12)
        };

        Food[] foods = new Food[5]
        {
            new Food("Хлеб", 20, 5),
            new Food("Сыр", 100, 400),
            new Food("Яблоки", 15, 10),
            new Food("Мясо", 150, 20),
            new Food("Рис", 80, 365)
        };

        Console.WriteLine("Напитки:");
        foreach (var beverage in beverages)
        {
            beverage.PrintInfo();
        }

        Console.WriteLine("Продукты:");
        foreach (var food in foods)
        {
            food.PrintInfo();
        }
    }
}
