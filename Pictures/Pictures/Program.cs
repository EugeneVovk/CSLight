using System;

namespace Pictures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pictureInRow = 3;
            int pictures = 52;
            int fullRows;
            int offRowPicture;

            fullRows = pictures / pictureInRow;
            offRowPicture = pictures % pictureInRow;

            Console.WriteLine($" Количество полностью заполненных рядов: {fullRows}");
            Console.WriteLine($" Картинок будет сверх меры: {offRowPicture}");
        }
    }
}
