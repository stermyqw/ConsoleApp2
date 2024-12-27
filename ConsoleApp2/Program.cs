using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Delivery
{
    protected Dictionary<string, double> menu;

    public Delivery()
    {
        menu = new Dictionary<string, double>();
    }

    public abstract void DisplayMenu();
    public abstract double CalculateDeliveryCost(List<string> orders);
}

class PizzaDelivery : Delivery
{
    public PizzaDelivery()
    {
        menu.Add("Маргарита", 500);
        menu.Add("Пепперони", 600);
        menu.Add("Гавайская", 700);
    }

    public override void DisplayMenu()
    {
        Console.WriteLine("Меню Пиццы:");
        foreach (var item in menu)
        {
            Console.WriteLine($"{item.Key}: {item.Value} руб.");
        }
    }

    public override double CalculateDeliveryCost(List<string> orders)
    {
        double total = 0;
        foreach (var order in orders)
        {
            if (menu.ContainsKey(order))
            {
                total += menu[order];
            }
        }
        return total + 100; // Стоимость доставки
    }
}

class SushiDelivery : Delivery
{
    public SushiDelivery()
    {
        menu.Add("Калифорния", 800);
        menu.Add("Филадельфия", 900);
        menu.Add("Запеченные", 700);
    }

    public override void DisplayMenu()
    {
        Console.WriteLine("Меню Суши:");
        foreach (var item in menu)
        {
            Console.WriteLine($"{item.Key}: {item.Value} руб.");
        }
    }

    public override double CalculateDeliveryCost(List<string> orders)
    {
        double total = 0;
        foreach (var order in orders)
        {
            if (menu.ContainsKey(order))
            {
                total += menu[order];
            }
        }
        return total + 150; // Стоимость доставки
    }
}

class BurgerDelivery : Delivery
{
    public BurgerDelivery()
    {
        menu.Add("Чизбургер", 300);
        menu.Add("Биг Тести", 400);
        menu.Add("Вегетарианский бургер", 350);
    }

    public override void DisplayMenu()
    {
        Console.WriteLine("Меню Бургеров:");
        foreach (var item in menu)
        {
            Console.WriteLine($"{item.Key}: {item.Value} руб.");
        }
    }

    public override double CalculateDeliveryCost(List<string> orders)
    {
        double total = 0;
        foreach (var order in orders)
        {
            if (menu.ContainsKey(order))
            {
                total += menu[order];
            }
        }
        return total + 120; // Стоимость доставки
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите тип доставки: 1 - Пицца, 2 - Суши, 3 - Бургеры");
        int choice = int.Parse(Console.ReadLine());

        Delivery deliveryService = null;

        switch (choice)
        {
            case 1:
                deliveryService = new PizzaDelivery();
                break;
            case 2:
                deliveryService = new SushiDelivery();
                break;
            case 3:
                deliveryService = new BurgerDelivery();
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        deliveryService.DisplayMenu();

        Console.WriteLine("Введите заказы (через запятую):");
        string input = Console.ReadLine();
        List<string> orders = new List<string>(input.Split(','));

        double totalCost = deliveryService.CalculateDeliveryCost(orders);
        Console.WriteLine($"Итоговый счет: {totalCost} руб.");
    }
}