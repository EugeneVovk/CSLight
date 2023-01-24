using System;
/**
 * Связь 'has-a' - это это когда один объект содержит другой
 * Один объект может ссылаться, а может и делегировать ряд задач другому объекту
 * 
 * Создадим систему задач.
 * Пользователь может создавать списки задач,
 * а внутри списков размещать сами задачи.
 * 
 * К каждой задаче можно прикрепить текст задачи и пользователя, который ей занят
 */
namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Bob");
            User user2 = new User("Alex");
            List list = new List(new Task[]
            {
                new Task(user, "wash the windows"),
                new Task(user2, "clean the stove")
            });

            list.ShowAllTasks();
        }
    }

    class User
    {
        private string _name;

        public User(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }

    class List
    {
        private Task[] _tasks;

        public List(Task[] tasks)
        {
            _tasks = tasks;
        }

        public void ShowAllTasks()
        {
            foreach (var task in _tasks)
            {
                task.ShowInfo();
            }
        }
    }

    class Task
    {
        private User _worker;
        private string _description;

        public Task(User worker, string description)
        {
            _worker = worker;
            _description = description;
        }

        public void ShowInfo()
        {
            Console.WriteLine(new string('*', 40) + '\n');
            Console.WriteLine($"Ответственный: {_worker.GetName()}\n"
                + $"Описание задачи: {_description}\n");
        }
    }
}
