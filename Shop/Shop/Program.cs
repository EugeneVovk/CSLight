using System;
using System.Collections.Generic;

namespace Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Seller seller = new Seller();
            Player player = new Player();
            new Program().StartShop(player, seller);
        }

        public void StartShop(Player player, Seller seller)
        {
            const string One = "1";
            const string Two = "2";
            const string Three = "3";
            string menuSelection;
            bool isWork = true;

            Console.WriteLine("\n\tДобро пожаловать в наш Магазин Эликсиров!\n\n"
                + " Продавец чувствует нужду показать тебе свой ассортимент:\n");
            seller.ShowPriceList();

            while (isWork)
            {
                ShowMenu();

                Console.Write(" Твой выбор: ");
                menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case One:
                        WantToBuy(player, seller);
                        break;

                    case Two:
                        player.ShowBag();
                        break;

                    case Three:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неверная опереция");
                        break;
                }
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine(" Можно:\n" +
                   "1 - хочу купить\n" +
                   "2 - посмотреть сумку игрока\n" +
                   "3 - выход\n");
        }

        public void WantToBuy(Player player, Seller seller)
        {

            string playerChoiseElixir;
            int playerQuantityDesire;

            Console.Write("\n\n Что ты хочешь купить? ");
            playerChoiseElixir = Console.ReadLine();

            foreach (var elixir in seller.PriceList.Keys)
            {
                if (elixir.ToString() == playerChoiseElixir)
                {
                    Console.Write($"\n\tУ меня в сундуке есть {seller.SellerChest[elixir]} таких склянок\n"
                        + $"\n Сколько ты хочешь купить? ");
                    playerQuantityDesire = Convert.ToInt32(Console.ReadLine());


                    if (player.BuyElixir(elixir, seller.PriceList[elixir], playerQuantityDesire))
                    {
                        seller.SellElixir(elixir, seller.PriceList[elixir], playerQuantityDesire);
                    }
                }
            }
        }
    }

    class Player
    {
        private int _playerCoins;
        private Dictionary<ElixirTypes, int> _playerBag;

        public Player()
        {
            _playerCoins = 350;
            _playerBag = new Dictionary<ElixirTypes, int>();
        }

        public bool BuyElixir(ElixirTypes elixir, int coins, int elixirQuantity)
        {
            bool isDealHappen = false;
            coins *= elixirQuantity;

            if (_playerCoins >= coins)
            {
                _playerCoins -= coins;
                _playerBag.Add(elixir, elixirQuantity);
                isDealHappen = true;
            }
            else
            {
                Console.WriteLine("\n\tУ тебя недостаточно монет\n");
            }

            return isDealHappen;
        }

        public void AddElixirToBag(ElixirTypes elixir, int elixirQuantity)
        {
            if (_playerBag.ContainsKey(elixir))
            {
                _playerBag[elixir] += elixirQuantity;
            }
            else
            {
                _playerBag.Add(elixir, elixirQuantity);
            }
        }

        public void ShowBag()
        {
            Console.WriteLine("Сумка игрока: ");

            if (_playerBag.Count > 0)
            {
                foreach (var elixir in _playerBag)
                {
                    Console.WriteLine($"\n Название: {elixir.Key}\n"
                        + $" Количество склянок: {elixir.Value}\n");
                }
            }
            else
            {
                Console.WriteLine("\n\tПусто\n");
            }

            ShowWallet();
        }

        public void ShowWallet()
        {
            Console.WriteLine($" Монеты: {_playerCoins}\n");
        }
    }

    class Seller
    {
        private int _sellerCoins;
        public Dictionary<ElixirTypes, int> PriceList { get; }
        public Dictionary<ElixirTypes, int> SellerChest { get; }

        public Seller()
        {
            _sellerCoins = 0;
            PriceList = new Dictionary<ElixirTypes, int>()
            {
                [ElixirTypes.Пурга] = 100,
                [ElixirTypes.Лес_Марибора] = 100,
                [ElixirTypes.Косатка] = 100,
                [ElixirTypes.Белый_Мёд] = 150,
                [ElixirTypes.Неясыть] = 150,
                [ElixirTypes.Филин] = 150,
                [ElixirTypes.Кошка] = 150,
                [ElixirTypes.Зелье_Петри] = 300,
                [ElixirTypes.Гром] = 100,
                [ElixirTypes.Ласточка] = 150,
                [ElixirTypes.Зелье_Раффара_Белого] = 100
            };
            SellerChest = new Dictionary<ElixirTypes, int>()
            {
                [ElixirTypes.Пурга] = 10,
                [ElixirTypes.Лес_Марибора] = 10,
                [ElixirTypes.Косатка] = 10,
                [ElixirTypes.Белый_Мёд] = 10,
                [ElixirTypes.Неясыть] = 10,
                [ElixirTypes.Филин] = 10,
                [ElixirTypes.Кошка] = 10,
                [ElixirTypes.Зелье_Петри] = 10,
                [ElixirTypes.Гром] = 10,
                [ElixirTypes.Ласточка] = 10,
                [ElixirTypes.Зелье_Раффара_Белого] = 10
            };
        }

        public void ShowPriceList()
        {
            foreach (var elixir in PriceList)
            {
                Console.WriteLine($" '{elixir.Key}' - {elixir.Value} монет");
                Console.WriteLine(new string('-', 40));
            }
        }

        public bool SellElixir(ElixirTypes elixir, int coins, int elixirQuantity)
        {
            bool isDealHappen = false;
            coins *= elixirQuantity;

            if (SellerChest[elixir] >= elixirQuantity)
            {
                SellerChest[elixir] -= elixirQuantity;
                _sellerCoins += coins;
                isDealHappen = true;
            }

            if (SellerChest[elixir] <= 0)
            {
                DeleteElixir(elixir);
            }

            return isDealHappen;
        }

        public void DeleteElixir(ElixirTypes elixir)
        {
            SellerChest.Remove(elixir);
        }

        public void ShowChest()
        {
            Console.WriteLine("Сундук продавца:");

            if (SellerChest.Count > 0)
            {
                foreach (var elixir in SellerChest)
                {
                    Console.WriteLine($"\n Название: {elixir.Key}\n"
                        + $" Количество склянок: {elixir.Value}\n");
                }
            }
            else
            {
                Console.WriteLine("\n\tПусто");
            }

            ShowWallet();
        }

        public void ShowWallet()
        {
            Console.WriteLine($"\n Монеты: {_sellerCoins}\n");
        }
    }

    enum ElixirTypes
    {
        Пурга,
        Лес_Марибора,
        Косатка,
        Белый_Мёд,
        Неясыть,
        Филин,
        Кошка,
        Зелье_Петри,
        Гром,
        Ласточка,
        Зелье_Раффара_Белого
    }
}
