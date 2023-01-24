using System;

namespace PropertyEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(40, 40);
            Renderer renderer = new Renderer();

            renderer.Draw(player.X, player.Y, '@');
        }
    }

    class Player
    {
        private int _x { get; }
        private int _y { get; }

        public Player(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get
            {
                return _x;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
        }
    }

    class Renderer
    {
        public void Draw(int x, int y, char playerSymbol)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(playerSymbol);
        }
    }
}
