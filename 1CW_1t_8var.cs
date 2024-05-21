using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct Goods
{
    public string Name { get; }
    public string Description { get; private set; }
    public double Price { get; }
    public string Article { get; }

    public Goods(string name, double price)
    {
        Name = name;
        Description = $"Для товара {name} описание не задано";
        Price = price;
        Article = Guid.NewGuid().ToString(); // уникальный артикул
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

    public void PrintInfo()
    {
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Стоимость: {Price}");
        Console.WriteLine($"Артикул: {Article}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Goods[] goodsArray = new Goods[5];

        goodsArray[0] = new Goods("Телефон", 500);
        goodsArray[1] = new Goods("Наушники", 100);
        goodsArray[2] = new Goods("Ноутбук", 1000);
        goodsArray[3] = new Goods("Клавиатура", 50);
        goodsArray[4] = new Goods("Мышь", 30);

        goodsArray[0].ChangeDescription("Смартфон с хорошей камерой и большим экраном.");
        goodsArray[2].ChangeDescription("Мощный ноутбук для работы и игр.");
        goodsArray[3].ChangeDescription("Игровая клавиатура с подсветкой.");

        //Сортировка массива по возрастанию цены
        for (int i = 0; i < goodsArray.Length - 1; i++)
        {
            for (int j = 0; j < goodsArray.Length - 1 - i; j++)
            {
                if (goodsArray[j].Price > goodsArray[j + 1].Price)
                {
                    Goods temp = goodsArray[j];
                    goodsArray[j] = goodsArray[j + 1];
                    goodsArray[j + 1] = temp;
                }
            }
        }

        //Вывод таблицы
        Console.WriteLine("Название    | Описание                                       | Стоимость | Артикул");
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        foreach (var goods in goodsArray)
        {
            Console.WriteLine($"{goods.Name,-11} | {goods.Description,-45} | {goods.Price,-9} | {goods.Article}");
        }
    }
}
