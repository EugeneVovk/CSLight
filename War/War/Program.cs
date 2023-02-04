using System;
using System.Collections.Generic;
using System.Threading;

namespace War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().StartProgram();
        }

        public void StartProgram()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\n\n\n\tИтак...\n\n"
               + "\tЕсть два взвода. Первый - орки, второй - люди\n\n"
               + "\tКаждый взвод внутри имеет солдат\n\n"
               + "\tКаждый боец - это уникальная единица, котороый имеет\n"
               + "\tуникальные характеристики, такие как повышенная сила\n\n"
               + "\tПобеждает тот взвод, в котором остались выжившие бойц\n\n"
               + "\n\n\t\tБитва начинается!\n\n\n\n\nДля продолжения нажми любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            ShowWar();
        }

        public void ShowWar()
        {
            int xCursorPossition = 35;
            int yCursorPossition = 5;
            int battleCounter;
            int missedAttaks = 15;
            int orcDeath = 0;
            int humanDeath = 0;
            int waiteSeconds = 500;
            char delimiter = '*';

            Orcish orcish = new Orcish();
            Humans humans = new Humans();

            orcish.CreatePlatoon();
            humans.CreatePlatoon();

            while (orcish.Platoon.Count > 0 && humans.Platoon.Count > 0)
            {
                battleCounter = 0;

                if (orcish.Platoon.Count != battleCounter && orcish.Platoon.Count != battleCounter)
                {
                    FrameWord(" W A R ", delimiter);

                    Console.SetCursorPosition(xCursorPossition, yCursorPossition);
                    Console.WriteLine($"Orc_Death: {orcDeath} / Human_Death: {humanDeath}");
                    Console.SetCursorPosition(0, yCursorPossition);

                    while (orcish.Platoon[battleCounter].Health > 0 && humans.Platoon[battleCounter].Health > 0)
                    {
                        humans.Platoon[battleCounter].ShootArrows();

                        orcish.Platoon[battleCounter].GetAttack(humans.Platoon[battleCounter].Damage);
                        humans.Platoon[battleCounter].GetAttack(orcish.Platoon[battleCounter].Damage);
                        orcish.Platoon[battleCounter].ShowCurrentHealth();
                        humans.Platoon[battleCounter].ShowCurrentHealth();

                        if (orcish.Platoon.Count > missedAttaks)
                        {
                            orcish.Platoon[battleCounter].Rage();
                        }
                        else
                        {
                            orcish.Platoon[battleCounter].Escape();
                        }
                    }

                    Console.WriteLine(new string(delimiter, xCursorPossition));
                    ConsoleColor defaultColor = Console.ForegroundColor;

                    if (orcish.Platoon[battleCounter].Health <= 0 && humans.Platoon[battleCounter].Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tОба пали\n");
                        Console.ForegroundColor = defaultColor;

                        orcish.RemoveDeadWarrior(battleCounter);
                        humans.RemoveDeadWarrior(battleCounter);

                        orcDeath++;
                        humanDeath++;
                    }
                    else if (orcish.Platoon[battleCounter].Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\tОрк пал");
                        Console.ForegroundColor = defaultColor;

                        orcish.RemoveDeadWarrior(battleCounter);

                        orcDeath++;
                    }
                    else if (humans.Platoon[battleCounter].Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tЧеловек пал");
                        Console.ForegroundColor = defaultColor;

                        humans.RemoveDeadWarrior(battleCounter);

                        humanDeath++;
                    }

                    battleCounter++;
                }

                Thread.Sleep(waiteSeconds);
                Console.Clear();
            }

            Console.WriteLine('\n' + new string(delimiter, xCursorPossition));
            Console.WriteLine("\n   Итог битвы:\n\n"
                + $" Выжило орков: {orcish.Platoon.Count}\n"
                + $" Выжило людей: {humans.Platoon.Count}\n\n");
        }

        public void FrameWord(string word, char symbol)
        {
            int wordSize = word.Length + 2;
            string indent = "\t";

            Console.WriteLine(indent + new string(symbol, wordSize));
            Console.WriteLine(indent + symbol + word + symbol);
            Console.WriteLine(indent + new string(symbol, wordSize));
        }

        abstract class Warrior
        {
            public string Name { get; }
            public int Health { get; protected set; }
            public int Damage { get; protected set; }
            public int Armor { get; protected set; }

            public Warrior()
            {
                Name = GetType().Name;
                Health = 100;
                Damage = 0;
                Armor = 0;
            }

            public int GetAttack(int damage)
            {
                Health -= Math.Abs(damage - Armor);

                return Health;
            }

            public void ShowStat()
            {
                Console.WriteLine($"\n {Name}\n"
                    + $" Жизни: {Health}\n"
                    + $" Урон: {Damage}\n"
                    + $" Броня: {Armor}\n");
            }

            public void ShowCurrentHealth()
            {
                Console.WriteLine($"{Name} - Осталось жизней: {Health}\n");
            }
        }

        abstract class Platoon
        {
            public int LowerBoundary { get; protected set; }
            public int UpperBoundaryDamage { get; protected set; }
            public int UpperBoundaryArmor { get; protected set; }
            public Random RandomStats { get; protected set; }

            public Platoon()
            {
                RandomStats = new Random();
            }

            abstract public void CreatePlatoon();

            abstract public void RemoveDeadWarrior(int index);

            abstract public void ShowPatoon();
        }

        class Human : Warrior, IShootableArrows, ISpeedImpact
        {
            private int _arrowDamage;
            private int _closeRangeSpeed;

            public Human(int damage, int armor)
            {
                Damage = damage;
                Armor = armor;
                _arrowDamage = 5;
                _closeRangeSpeed = 10;
            }

            public void ShootArrows()
            {
                int arrowDamage = 20;

                if (_arrowDamage > 0)
                {
                    Damage += arrowDamage;
                    _arrowDamage--;
                }
                else if (_closeRangeSpeed > 0)
                {
                    SpeedImpact();
                }
            }

            public void SpeedImpact()
            {
                if (_closeRangeSpeed > 0)
                {
                    Armor += _closeRangeSpeed;
                    _closeRangeSpeed--;
                }
            }
        }

        class Humans : Platoon
        {
            public List<Human> Platoon { get; }

            public Humans()
            {
                Platoon = new List<Human>(50);
                LowerBoundary = 10;
                UpperBoundaryDamage = 30;
                UpperBoundaryArmor = 70;
            }

            public override void CreatePlatoon()
            {
                for (int i = 0; i < Platoon.Capacity; i++)
                {
                    Platoon.Add(new Human(
                        RandomStats.Next(LowerBoundary, UpperBoundaryDamage),
                        RandomStats.Next(LowerBoundary, UpperBoundaryArmor)));
                }
            }

            public override void ShowPatoon()
            {
                foreach (Human human in Platoon)
                {
                    human.ShowStat();
                }
            }

            public override void RemoveDeadWarrior(int index)
            {
                if (Platoon[index].Health <= 0)
                {
                    Platoon.RemoveAt(index);
                }
            }
        }

        class Orc : Warrior, IRagable, IEscapable
        {
            int callCountMethod = 1;

            public Orc(int damage, int armor)
            {
                Damage = damage;
                Armor = armor;
            }

            public void Rage()
            {
                Damage += callCountMethod * 2;
            }

            public void Escape()
            {
                Damage -= callCountMethod;
            }
        }

        class Orcish : Platoon
        {
            public List<Orc> Platoon { get; }

            public Orcish()
            {
                Platoon = new List<Orc>(50);
                LowerBoundary = 30;
                UpperBoundaryDamage = 100;
                UpperBoundaryArmor = 70;
            }

            public override void CreatePlatoon()
            {
                for (int i = 0; i < Platoon.Capacity; i++)
                {
                    Platoon.Add(new Orc(
                        RandomStats.Next(LowerBoundary, UpperBoundaryDamage),
                        RandomStats.Next(LowerBoundary, UpperBoundaryArmor)));
                }
            }

            public override void ShowPatoon()
            {
                foreach (Orc orc in Platoon)
                {
                    orc.ShowStat();
                }
            }

            public override void RemoveDeadWarrior(int index)
            {
                if (Platoon[index].Health <= 0)
                {
                    Platoon.RemoveAt(index);
                }
            }
        }

        interface IRagable
        {
            void Rage();
        }

        interface IEscapable
        {
            void Escape();
        }

        interface ISpeedImpact
        {
            void SpeedImpact();
        }

        interface IShootableArrows
        {
            void ShootArrows();
        }
    }
}
