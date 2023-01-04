using System;
/**
 * Магазин, в котором будем продавать еду
 * Дано: деньги, еда, еда за единицу еды
 * Магазин не может давать вдолг =>
 * Без лишних проверок получить результат невозможности ухода в отрицательный баланс
 */
namespace Shop1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int money;
            int food;
            int foodUnitPrice = 10;
            bool isAbleToPay;

            Console.WriteLine($"Добро пожаловать в пекарню!"
                + $" Сегодня еда по {foodUnitPrice} монет");
            Console.WriteLine($"Сколько у тебя золота?");
            money = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Сколько тебе нужно еды?");
            food = Convert.ToInt32(Console.ReadLine());

            isAbleToPay = money >= food * foodUnitPrice;
            food *= Convert.ToInt32(isAbleToPay);
            money -= food * foodUnitPrice;
            Console.WriteLine($"У тебя в сумке {food} единиц еды и {money} монет");
        }
    }
}
