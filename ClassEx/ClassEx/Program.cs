using System;

namespace ClassEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Martin", 8, 1600);

            player.ShowInfo();
        }
    }

    class Player
    {
        private string _name { get; }
        private int _level { get; }
        private int _scoreNumber { get; }

        public Player(string name, int level, int scoreNumber)
        {
            _name = name;
            _level = level;
            _scoreNumber = scoreNumber;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Игрок: {_name}\n"
                + $"Уровень игрока: {_level}\n"
                + $"Количество очков: {_scoreNumber}\n");
        }
    }
}
