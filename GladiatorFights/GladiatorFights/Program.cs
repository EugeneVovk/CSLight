using System;

namespace GladiatorFights
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().StartApp();
        }

        public void StartApp()
        {
            Gladiator userGladiator;
            Gladiator opponentGladiator;
            ConsoleKeyInfo userPressKey;
            bool isFight = true;

            Console.WriteLine("\n\n\tДобро пожаловать в Колизей\n");

            while (isFight)
            {
                ShowGladiatorsList();

                userGladiator = ChooseGladiator();

                opponentGladiator = PickOpponent();

                Console.WriteLine("\n\nНу что ж...\n");
                ShowGladiatorBattleCry();

                Console.ReadKey();
                Console.Clear();

                AttackGladiators(userGladiator, opponentGladiator);

                ShowWinner(userGladiator, opponentGladiator);

                Console.WriteLine("\n\tТы готов выйти на арену?\n\n"
                    + " Если - да, то жми на любую клавишу и в бой!\n"
                    + " Иначе, просто нашми Esc\n");
                userPressKey = Console.ReadKey();

                if (userPressKey.Key == ConsoleKey.Escape)
                {
                    isFight = false;
                }

                Console.Clear();
            }
        }

        public void ShowGladiatorsList()
        {
            Console.WriteLine("\n  Наши гладиаторы:\n\n"
                + " 1 - Velite\n"
                + " 2 - Retiarius\n"
                + " 3 - Scissor\n"
                + " 4 - Thraex\n"
                + " 5 - Murmillon\n"
                + " 6 - Secutor\n"
                + " 7 - Bestiarius\n");
        }

        public Gladiator ChooseGladiator()
        {
            const string Velite = "1";
            const string Retiarius = "2";
            const string Scissor = "3";
            const string Thraex = "4";
            const string Murmillon = "5";
            const string Secutor = "6";
            const string Bestiarius = "7";

            Gladiator userGladiator = null;
            string userSelect;

            Console.Write("  Ты за кого будешь? ");
            userSelect = Console.ReadLine();

            switch (userSelect)
            {
                case Velite:
                    userGladiator = new Velite();
                    break;

                case Retiarius:
                    userGladiator = new Retiarius();
                    break;

                case Scissor:
                    userGladiator = new Scissor();
                    break;

                case Thraex:
                    userGladiator = new Thraex();
                    break;

                case Murmillon:
                    userGladiator = new Murmillon();
                    break;

                case Secutor:
                    userGladiator = new Secutor();
                    break;

                case Bestiarius:
                    userGladiator = new Bestiarius();
                    break;

                default:
                    Console.WriteLine("\n\n\tГладиатор не выбран!\n");
                    Console.ReadKey();
                    break;
            }

            Console.Clear();
            Console.Write("\nТы выбрал гладиатора - ");

            userGladiator.ShowStats();

            return userGladiator;
        }

        public Gladiator PickOpponent()
        {
            Random random = new Random();
            Gladiator oponentGladiator;
            Gladiator[] gladiators =
            {
                new Velite(),
                new Retiarius(),
                new Scissor(),
                new Thraex(),
                new Murmillon(),
                new Secutor(),
                new Bestiarius()
            };

            Console.Write("Твой соперник - ");
            oponentGladiator = gladiators[
                random.Next(0, gladiators.Length)];

            oponentGladiator.ShowStats();

            return oponentGladiator;
        }

        public void ShowGladiatorBattleCry()
        {
            Console.WriteLine("\n\tAVE CAESAR IMPERATOR, MORITURI TE SALUTANT!" +
                    "\n\tДа здравствует император! Идущие на смерть приветствуют тебя!\n");
        }

        public void AttackGladiators(Gladiator userGladiator, Gladiator opponentGladiator)
        {
            int coinHead = 0;
            int coinTail = 3;
            Random random= new Random();

            while (userGladiator.Health > 0 && opponentGladiator.Health > 0)
            {
                userGladiator.TakeDamage(opponentGladiator.Damage);
                opponentGladiator.TakeDamage(userGladiator.Damage);
                userGladiator.ShowCurrentHealth();
                opponentGladiator.ShowCurrentHealth();

                if (coinHead == random.Next(coinHead, coinTail))
                {
                    Console.WriteLine("\tВау, вот это приём!\n");
                    userGladiator.ApplyAbility();
                }

                if (coinHead == random.Next(coinHead, coinTail))
                {
                    Console.WriteLine("\tСоперник появил хитрость\n");
                    opponentGladiator.ApplyAbility();
                }
            }
        }

        public void ShowWinner(Gladiator userGladiator, Gladiator opponentGladiator)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            if (userGladiator.Health <= 0 && opponentGladiator.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\tНичья\n");
                Console.ForegroundColor = defaultColor;
            }
            else if (userGladiator.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\tТы был тяжело ранен в бою,\n" +
                    $"  но император пощадил тебя и дал шанс снова выйти на арену\n");
                Console.ForegroundColor = defaultColor;
            }
            else if (opponentGladiator.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tПоздравляю! "
                    + "Теперь ты рудиарий.\n\tСвобода и популярность у публики теперь твои.\n");
                Console.ForegroundColor = defaultColor;
            }
        }
    }

    abstract class Gladiator
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }
        public IAbility _ability;

        public Gladiator()
        {
            Name = GetType().Name;
            Health = 0;
            Damage = 0;
            Armor = 0;
        }

        abstract public void ApplyAbility();

        public void SetAbility(IAbility ability)
        {
            _ability = ability;
        }

        public void ShowStats()
        {
            Console.WriteLine($"{Name}\n" +
                $" Жизни: {Health}\n" +
                $" Урон: {Damage}\n" +
                $" Броня: {Armor}\n");
        }

        public void ShowCurrentHealth()
        {
            Console.WriteLine($"{Name} - Осталось жизни: {Health}\n");
        }

        public void TakeDamage(int damage)
        {
            Health -= Math.Abs(damage - Armor);
        }
    }

    class Velite : Gladiator
    {
        public Velite()
        {
            Health = 100;
            Damage = 60;
            Armor = 20;
        }

        public override void ApplyAbility()
        {
            Armor = new Shield().UseAbility(Armor);
        }
    }

    class Retiarius : Gladiator
    {
        public Retiarius()
        {
            Health = 100;
            Damage = 30;
            Armor = 10;
        }

        public override void ApplyAbility()
        {
            Damage = new Immobilize().UseAbility(Damage);
        }
    }

    class Scissor : Gladiator
    {
        public Scissor()
        {
            Health = 100;
            Damage = 50;
            Armor = 80;
        }

        public override void ApplyAbility()
        {
            Damage = new Rageable().UseAbility(Damage);
        }
    }

    class Thraex : Gladiator
    {
        public Thraex()
        {
            Health = 100;
            Damage = 50;
            Armor = 30;
        }

        public override void ApplyAbility()
        {
            Armor = new Shield().UseAbility(Armor);
            Damage = new Stun().UseAbility(Damage);
        }
    }

    class Murmillon : Gladiator
    {
        public Murmillon()
        {
            Health = 100;
            Damage = 40;
            Armor = 40;
        }

        public override void ApplyAbility()
        {
            Armor = new Shield().UseAbility(Armor);
        }
    }

    class Secutor : Gladiator
    {
        public Secutor()
        {
            Health = 100;
            Damage = 40;
            Armor = 30;
        }

        public override void ApplyAbility()
        {
            Armor = new Shield().UseAbility(Armor);
        }
    }

    class Bestiarius : Gladiator
    {
        public Bestiarius()
        {
            Health = 100;
            Damage = 60;
            Armor = 0;
        }

        public override void ApplyAbility()
        {
            Health = new EmperatorMedicineKit().UseAbility(Health);
            Damage = new Rageable().UseAbility(Damage);
        }
    }

    interface IAbility
    {
        int UseAbility(int property);
    }

    class Immobilize : IAbility
    {
        public int UseAbility(int damage)
        {
            return damage += damage + damage;
        }
    }

    class Stun : IAbility
    {
        public int UseAbility(int damage)
        {
            return damage += 10;
        }
    }

    class Shield : IAbility
    {
        public int UseAbility(int armor)
        {
            return armor += armor;
        }
    }

    class Rageable : IAbility
    {
        public int UseAbility(int damage)
        {
            return damage += damage;
        }
    }

    class EmperatorMedicineKit : IAbility
    {
        public int UseAbility(int health)
        {
            return health += 50;
        }
    }
}
