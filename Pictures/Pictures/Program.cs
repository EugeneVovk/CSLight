using System;
namespace Pictures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pictureInRow = 3;
            int userAlbum = 52;
            int fullFillRow;
            int offRowPicture;

            fullFillRow = userAlbum / pictureInRow;
            offRowPicture = userAlbum % pictureInRow;

            Console.WriteLine($" Количество полностью заполненных рядов: {fullFillRow}");
            Console.WriteLine($" Картинок будет сверх меры: {offRowPicture}");
        }
    }
}
