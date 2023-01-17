using System;

namespace BraveNewWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int userX = 6;
            int userY = 6;
            char[] bag = new char[0];
            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
                {'#','x','#',' ',' ',' ','x',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','x','#',' ','#','#','#',' ','#','#','#','#','#','#' },
                {'#',' ','#',' ','#','x','#','#',' ',' ',' ','x','#','#' },
                {'#',' ','#',' ','#',' ','#',' ',' ','#','#','#','#','#' },
                {'#',' ','#',' ','#',' ','#',' ',' ',' ',' ',' ','x','#' },
                {'#',' ','x',' ',' ',' ',' ',' ','#',' ','#','#',' ','#' },
                {'#',' ','#',' ','#','#','#','#','#',' ','#','x',' ','#' },
                {'#',' ','#',' ','#','#','#','#','#','#','#','#',' ','#' },
                {'#',' ','#',' ',' ',' ',' ','x',' ',' ','#','x',' ','#' },
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#' },
                {'#','x','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','x','#' },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#' }
            };

            while (true)
            {
                DisplayMap(map);

                CreatePlayer(userX, userY);

                CreateBag(bag);

                ActionOfPlayer(map, ref userX, ref userY);

                DigUpTreasure(map, ref bag, userX, userY);

                Console.Clear();
            }
        }

        private static void DisplayMap(char[,] map)
        {
            Console.SetCursorPosition(0, 0);

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }

        private static void CreateBag(char[] bag)
        {
            Console.SetCursorPosition(0, 20);
            Console.Write("Сумка: ");

            int counter = 0;

            foreach (char treasures in bag)
            {
                Console.Write(treasures + " ");
                counter++;
            }

            Console.WriteLine($"\n\nСобрано сокровищ: {counter}");
        }

        private static char[] IncreaseBag(char[] bag)
        {
            char[] tempArray = new char[bag.Length + 1];

            for (int i = 0; i < bag.Length; i++)
            {
                tempArray[i] = bag[i];
            }

            return tempArray;
        }

        private static void CreatePlayer(int userX, int userY)
        {
            Console.SetCursorPosition(userY, userX);
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine('\u263B');
            Console.ForegroundColor = defaultColor;
        }

        private static void DigUpTreasure(char[,] map, ref char[] bag, int userX, int userY)
        {
            if (map[userX, userY] == 'x')
            {
                map[userX, userY] = 'o';
                bag = IncreaseBag(bag);
                bag[bag.Length - 1] = 'x';
            }
        }

        private static void ActionOfPlayer(char[,] map, ref int userX, ref int userY, char wall = '#')
        {
            ConsoleKeyInfo userPressedKey = Console.ReadKey();

            switch (userPressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[userX - 1, userY] != wall)
                    {
                        userX--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (map[userX + 1, userY] != wall)
                    {
                        userX++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (map[userX, userY - 1] != wall)
                    {
                        userY--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (map[userX, userY + 1] != wall)
                    {
                        userY++;
                    }
                    break;
            }
        }
    }
}

