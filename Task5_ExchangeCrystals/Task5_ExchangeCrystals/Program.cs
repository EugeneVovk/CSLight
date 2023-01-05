using System;

namespace Task5_ExchangeCrystals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goldCoins;
            int crystals;
            int goldToCrystal = 10;

            Console.WriteLine("\n\tДобро пожаловать в магазин!\n"
                + " Здесь ты можешь купить за своё золото кристаллы\n");
            Console.Write("Сколько у тебя золота? ");
            goldCoins = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nЗа один кристалл я прошу 10 монет\n"
                + "Сколько кристаллов ты хочешь купить? ");
            crystals = Convert.ToInt32(Console.ReadLine());

            goldCoins = goldCoins - goldToCrystal * crystals;
            Console.WriteLine($"\nУ тебя {goldCoins} золотых монет "
                + $"и {crystals} кристаллов\n");
        }
    }
}
