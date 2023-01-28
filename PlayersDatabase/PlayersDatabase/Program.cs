using System;
using System.Collections.Generic;

namespace PlayersDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            Database database = new Database(players);

            database.AddPlayer(new Player("Skipper", 20));
            database.AddPlayer(new Player("Kowalski", 24));
            database.AddPlayer(new Player("newPlayer3", 0));
            database.AddPlayer(new Player("Rico", 5));
            database.AddPlayer(new Player("Private", 2));
            database.AddPlayer(new Player("King Julien", 17));

            database.ShowAllPlayers();
            Console.WriteLine('\b');

            database.RemovePlayer(database.GetPlayers(), 5);

            database.BannedPlayer(database.GetPlayers(), 6);
            database.BannedPlayer(database.GetPlayers(), 2);

            database.UnbannedPlayer(database.GetPlayers(), 2);

            database.ShowAllPlayers();
        }
    }

    class Player
    {
        private int _id;
        private string _nickname;
        private int _level;
        public bool IsBanned;

        public Player(string nickname, int level)
        {
            _nickname = nickname;
            _level = level;
            IsBanned = false;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int newId)
        {
            _id = newId;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Уникальный номер: {_id}\n"
                + $"Ник: {_nickname}\n"
                + $"Уровень: {_level}\n"
                + $"Забанен? {IsBanned}");
            Console.WriteLine(new string('-', 40));
        }
    }

    class Database
    {
        private int _id;
        private List<Player> _players;

        public Database(List<Player> players)
        {
            _players = players;
        }

        public List<Player> GetPlayers()
        {
            return _players;
        }

        public void AddPlayer(Player player)
        {
            player.SetId(++_id);
            _players.Add(player);
        }

        public void RemovePlayer(List<Player> _players, int playerId)
        {
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].GetId() == playerId)
                {
                    _players.RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine("Игрок не найден!");
        }

        public void BannedPlayer(List<Player> _players, int playerId)
        {
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].GetId() == playerId)
                {
                    _players[i].IsBanned = true;
                    return;
                }
            }

            Console.WriteLine("Игрок не найден!");
        }

        public void UnbannedPlayer(List<Player> _players, int playerId)
        {
            foreach (var player in _players)
            {
                if (player.GetId() == playerId)
                {
                    player.IsBanned = false;
                    return;
                }
            }

            Console.WriteLine("Игрок не найден!");
        }

        public void ShowAllPlayers()
        {
            _players.ForEach(player => player.ShowInfo());
        }
    }
}
