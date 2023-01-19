using System;
using System.Collections.Generic;
/**
* Взаимодействие объектов
* Когда один объект содержит в себе другой - эта связь has-a
* 
* У нас есть некая система распределения задач
* Пользователь может создавать списки этих задач
* а внутри уже распределять эти задачи
* 
* К каждой задаче можно прикрепить описание задачи
* и исполнителя, который ей занят
* 
* Performer - исполнитель
* Board - доска для задач
* Task - сама задача
* 
* Доска имеет список задач, а задачи - исполнителей
* 
*/
namespace Has_A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Performer worker1 = new Performer("Petr");
            Performer worker2 = new Performer("Kate");

            var tasks = new List<Task> {
                new Task(worker1, "Fix bags"),
                new Task(worker2, "Code review")
            };

            Board schedule = new Board(tasks);

            schedule.ShowAllTasks();
        }
    }

    class Performer
    {
        public string Name;

        public Performer(string name)
        {
            Name = name;
        }
    }

    class Board
    {
        public List<Task> Tasks;

        public Board(List<Task> tasks)
        {
            Tasks = tasks;
        }

        public void ShowAllTasks()
        {
            foreach (Task task in Tasks)
            {
                task.ShowInfo();
            }
        }
    }

    class Task
    {
        public Performer Worker;
        public string Description;

        public Task(Performer worker, string description)
        {
            Worker = worker;
            Description = description;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Ответственный: {Worker.Name}\n"
                + $"Описание задачи: {Description}\n");
        }
    }
}
