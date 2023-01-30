using System;
using System.Collections.Generic;

namespace BookRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            repository.AddBook(new Book("Игра престолов", "Джордж Мартин", "Фэнтези", 2021));
            repository.AddBook(new Book("Дюна", "Фрэнк Герберт", "Фэнтези", 2022));
            repository.AddBook(new Book("Ведьмак", "Анджей Сапковский", "Фэнтези", 2022));
            repository.AddBook(new Book("1984", "Джордж Оруэлл", "Фэнтези", 2021));
            repository.AddBook(new Book("Оно", "Стивен Кинг", "Ужасы", 2021));
            repository.AddBook(new Book("Мифы Ктулху", "Говард Лавкрафт", "Ужасы", 2021));
            repository.AddBook(new Book("Восставший из ада", "Клайв Баркер", "Ужасы", 2022));
            repository.AddBook(new Book("Библия C#", "Михаил Флёнов", "Нехудожественная литература", 2022));
            repository.AddBook(new Book("Грокаем алгоритмы", "Адитья Бхаргава", "Нехудожественная литература", 2022));
            repository.AddBook(new Book("Теория Всего", "Стивен Хокинг", "Нехудожественная литература", 2022));
            repository.AddBook(new Book("Сказки", "Александр Пушкин", "Детская литература", 2020));
            repository.AddBook(new Book("Мифы Древней Греции", "Николай Кун", "Детская литература", 2021));

            new Program().StartApp(repository);

        }
        public void StartApp(Repository repository)
        {
            bool isWork = true;
            string userChoise;

            Console.WriteLine("\n\tПривет! Ты в хранилище книг =)\n");

            while (isWork)
            {
                ShowMenu();
                Console.Write("Твой выбор: ");
                userChoise = Console.ReadLine();

                switch (userChoise)
                {
                    case "1":
                        AddBook(repository);
                        break;
                    case "2":
                        DeleteBook(repository);
                        break;
                    case "3":
                        ShowAllBooks(repository);
                        break;
                    case "4":
                        ShowBookByName(repository);
                        break;
                    case "5":
                        ShowBookByAuthor(repository);
                        break;
                    case "6":
                        ShowBookByGenre(repository);
                        break;
                    case "7":
                        ShowBookByProductionYear(repository);
                        break;
                    case "8":
                        isWork = false;
                        Console.WriteLine("\n\tПока...\n");
                        break;
                    default:
                        Console.WriteLine("\n\tВыбрана неизвестная опереция\n");
                        break;
                }

                Console.WriteLine("\n\tДавай продолжим, нажми любую клавишу ;)");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("  Тут ты можешь:\n\n"
                    + " 1 - добавить книгу\n"
                    + " 2 - убрать книгу\n"
                    + " 3 - посмотреть все имеющиеся книги\n"
                    + " 4 - найти книгу по названию\n"
                    + " 5 - найти книгу по автору\n"
                    + " 6 - найти книгу по жанру\n"
                    + " 7 - найти книгу по году выпуска\n"
                    + " 8 - выйти из приложения\n");
        }

        public void AddBook(Repository repository)
        {
            string name;
            string author;
            string genre;
            int productionYear;

            Console.Write("Введи название книги, которую хочешь добавить: ");
            name = Console.ReadLine();
            Console.Write("Введи Имя и Фалилию автора: ");
            author = Console.ReadLine();
            Console.Write("Введи жанр книги: ");
            genre = Console.ReadLine();
            Console.Write("Введи год выпуска книги: ");
            productionYear = Convert.ToInt32(Console.ReadLine());

            repository.AddBook(new Book(name, author, genre, productionYear));

            Console.WriteLine("\n\tКнига добавлена в хранилище\n");
        }

        public void DeleteBook(Repository repository)
        {
            string name;

            Console.Write("Введи название книги, которую ты хочешь удалить: ");
            name = Console.ReadLine();

            repository.DeleteBookByName(name);
        }

        public void ShowAllBooks(Repository repository)
        {
            repository.ShowAllBooks();
        }

        public void ShowBookByName(Repository repository)
        {
            string name;

            Console.Write("Введи название книги, которую ты хочешь посмотреть: ");
            name = Console.ReadLine();

            repository.ShowBookByName(name);
        }

        public void ShowBookByAuthor(Repository repository)
        {
            string name;

            Console.Write("Введи автора книги, которую ты хочешь посмотреть: ");
            name = Console.ReadLine();

            repository.ShowBookByAuthor(name);
        }

        public void ShowBookByGenre(Repository repository)
        {
            string genre;

            Console.Write("Введи жанр книги, которую ты хочешь посмотреть: ");
            genre = Console.ReadLine();

            repository.ShowBookByGenre(genre);
        }

        public void ShowBookByProductionYear(Repository repository)
        {
            int yaer;

            Console.Write("Введи год выпуска книги, которую ты хочешь посмотреть: ");
            yaer = Convert.ToInt32(Console.ReadLine());

            repository.ShowBookByProductionYear(yaer);
        }
    }

    class Book
    {
        private int _id;
        private string _name;
        private string _author;
        private string _genre;
        private int _productionYear;

        public Book(string name, string author, string genre, int productionYear)
        {
            _name = name;
            _author = author;
            _genre = genre;
            _productionYear = productionYear;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Author
        {
            get
            {
                return _author;
            }
        }
        public string Genre
        {

            get
            {
                return _genre;
            }
        }
        public int ProductionYear
        {
            get
            {
                return _productionYear;
            }

        }

        public void ShowBook()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($" ID: {_id}\n"
                + $" Название: {_name}\n"
                + $" Автор: {_author}\n"
                + $" Жанр: {_genre}\n"
                + $" Год выпуска: {_productionYear}\n");
        }
    }

    class Repository
    {
        private int _bookId;
        private List<Book> _books;

        public Repository()
        {
            _bookId = 1;
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            book.Id = _bookId++;
        }

        public void DeleteBookByName(string nameBook)
        {
            foreach (Book book in _books)
            {
                string[] wordSearch = nameBook.Split(' ');
                string[] words = book.Name.Split(' ');

                foreach (string word1 in words)
                {
                    foreach (string word2 in wordSearch)
                    {
                        if (word1.ToLower() == word2.ToLower())
                        {
                            _books.Remove(book);

                            Console.WriteLine($"\n\tКнига '{nameBook}' удалена из хранилища\n");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine($"\n\tКниги '{nameBook}' не найдено\n");
        }

        public void ShowBookByName(string nameBook)
        {
            bool isBookExist = false;

            foreach (Book book in _books)
            {
                string[] wordSearch = nameBook.Split(' ');
                string[] words = book.Name.Split(' ');

                foreach (string word1 in words)
                {
                    foreach (string word2 in wordSearch)
                    {
                        if (word1.ToLower() == word2.ToLower())
                        {
                            book.ShowBook();
                            isBookExist = true;
                        }
                    }
                }
            }
            if (!isBookExist)
            {
                Console.WriteLine($"\n\tКниги '{nameBook}' не найдено\n");
            }
        }

        public void ShowBookByProductionYear(int year)
        {
            bool isBookExist = false;

            Console.WriteLine($"\n\tКниги {year} года:\n");

            foreach (Book book in _books)
            {
                if (book.ProductionYear == year)
                {
                    book.ShowBook();
                    isBookExist = true;
                }
            }

            if (!isBookExist)
            {
                Console.WriteLine($"\n\t...Увы, не найдено\n");
            }
        }

        public void ShowBookByAuthor(string nameAuthor)
        {
            bool isBookExist = false;

            foreach (Book book in _books)
            {
                string[] wordSearch = nameAuthor.Split(' ');
                string[] words = book.Author.Split(' ');
                foreach (string word1 in words)
                {
                    foreach (string word2 in wordSearch)
                    {
                        if (word1.ToLower() == word2.ToLower())
                        {
                            book.ShowBook();
                            isBookExist = true;
                        }
                    }
                }
            }

            if (!isBookExist)
            {
                Console.WriteLine($"\n\tКниги автора '{nameAuthor}' не найдено\n");
            }
        }

        public void ShowBookByGenre(string nameGenre)
        {
            bool isBookExist = false;

            foreach (Book book in _books)
            {
                string[] wordSearch = nameGenre.Split(' ');
                string[] words = book.Genre.Split(' ');

                foreach (string word1 in words)
                {
                    foreach (string word2 in wordSearch)
                    {
                        if (word1.ToLower() == word2.ToLower())
                        {
                            book.ShowBook();
                            isBookExist = true;
                        }
                    }
                }
            }

            if (!isBookExist)
            {
                Console.WriteLine($"\n\tКниги жанра '{nameGenre}' не найдено\n");
            }
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("\n\tСписок книг в хранилище:\n");

            foreach (Book book in _books)
            {
                book.ShowBook();
            }
        }
    }
}
