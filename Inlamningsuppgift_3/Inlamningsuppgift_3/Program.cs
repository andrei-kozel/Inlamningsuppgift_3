using System;
using System.Threading;

namespace Inlamningsuppgift_3
{
    static class Program
    {
        private static Hero player;
        private static Shop shop = new Shop();
        static void Main(string[] args)
        {
            Console.WriteLine("***********************");
            Console.WriteLine("* Welcom to The Game! *");
            Console.WriteLine("***********************");
            Console.Write("Enter your name: ");

            // ask user to name his hero
            string name = Console.ReadLine();

            CreateHero(name);
            StartGame();
        }

        /// <summary>
        /// Start the game.
        /// </summary>
        private static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("1. Go adventuring");
            Console.WriteLine("2. Show details about your character");
            Console.WriteLine("3. Visit shop");
            Console.WriteLine("4. Exit game");

            // if player riches lvl 10 the game is ended
            if (player.Level >= 10) { TheEnd(); }

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    GoAdventuring();
                    break;
                case 2:
                    ShowDetails();
                    break;
                case 3:
                    VisitShop();
                    break;
                case 4:
                    Exit();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Show The End screen
        /// </summary>
        private static void TheEnd()
        {
            Console.Clear();
            Console.WriteLine("Congratulations, you have reached level 10! Wow!");
            Console.WriteLine("You beat the game!");
            Utilities.Continue();
            Exit();
        }

        /// <summary>
        /// Visit shop. Print all available sections 
        /// </summary>
        private static void VisitShop()
        {
            Console.Clear();
            Console.WriteLine($"You have {player.Coins} coins.");
            Console.WriteLine();
            Console.WriteLine("1. Armor");
            Console.WriteLine("2. Weapon");
            Console.WriteLine("----------------");
            Console.WriteLine("3. Back To Start");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    shop.ShowArmor();
                    Console.Write("Chose item: ");
                    int armorIndex = Convert.ToInt32(Console.ReadLine());
                    BuyArmor(armorIndex);
                    break;
                case 2:
                    shop.ShowWeapon();
                    Console.Write("Chose item: ");
                    int weaponIndex = Convert.ToInt32(Console.ReadLine());
                    BuyWeapon(weaponIndex);
                    break;
                default:
                    StartGame();
                    break;
            }
        }

        /// <summary>
        /// Buy armor
        /// </summary>
        /// <param name="index">Used to specify which armor set player wants to buy</param>
        private static void BuyArmor(int index)
        {
            Armor armor = shop.GetArmor(index);

            if (player.Armor != null && armor.Name == player.Armor.Name)
            {
                Console.WriteLine("Sorry, but you already have this item");
                Utilities.Continue();
                VisitShop();
            }
            else if (armor.CanIBuyIt(player.Coins))
            {
                player.MakePayment(armor.Price);
                Console.WriteLine($"You bought : {armor.Name}");
                player.PutOnArmor(armor);
                player.RecalculateStats();
                Utilities.Continue();
                VisitShop();
            }
            else
            {
                Console.WriteLine("You don't have enough coins");
                Utilities.Continue();
                Console.Clear();
                VisitShop();
            }
        }

        /// <summary>
        /// Buy weapon
        /// </summary>
        /// <param name="index">Used to specify which weapon player wants to buy</param>
        private static void BuyWeapon(int index)
        {
            Weapon weapon = shop.GetWeapon(index);

            if (player.Weapon != null && weapon.Name == player.Weapon.Name)
            {
                Console.WriteLine("Sorry, but you already have this item");
                Utilities.Continue();
                VisitShop();
            }
            else if (weapon.CanIBuyIt(player.Coins))
            {
                player.MakePayment(weapon.Price);
                Console.WriteLine($"You bought : {weapon.Name}");
                player.TakeWeapon(weapon);
                player.RecalculateStats();
                Utilities.Continue();
                VisitShop();
            }
            else
            {
                Console.WriteLine("You don't have enough coins");
                Utilities.Continue();
                Console.Clear();
                VisitShop();
            }
        }

        /// <summary>
        /// Describe player stats
        /// </summary>
        private static void ShowDetails()
        {
            player.Describe();
            Utilities.Continue();
            StartGame();
        }

        /// <summary>
        /// Go adventuring. 10% chance to see nothing ... 
        /// </summary>
        private static void GoAdventuring()
        {
            Console.Clear();
            Enemy enemy = new Enemy();
            int chance = Utilities.Randomise(min: 0, max: 101);
            if (chance <= 10)
            {
                Console.WriteLine("You see nothing ...");
                Utilities.Continue();
                StartGame();
            }
            else
            {
                Console.WriteLine($"Un no! A wild {enemy.Name} appeared. He has {enemy.Damage}dmg and {enemy.Health}hp");
                Console.WriteLine("");
                StartAFight(enemy);
                Utilities.Continue();
                StartGame();
            }
        }

        /// <summary>
        /// Start a fight.
        /// </summary>
        /// <param name="enemy">Used to specify player's enemy.</param>
        public static void StartAFight(Enemy enemy)
        {
            // whose turn to attack. 0 - player, 1 - enemy
            int turnToFight = 0;
            // fight while health > 0
            while (player.Health > 0 && enemy.Health > 0)
            {
                // players turn
                if (turnToFight == 0)
                {
                    // calculate player damage
                    int playerDmg = player.Attack();
                    // enemy takes damage
                    enemy.TakeDamage(playerDmg);
                    Console.WriteLine($"You hit the monster, dealing {playerDmg}dmg. ");
                    if (enemy.Health <= 0) { enemy.Health = 0; break; };
                    // pass the turn to the enemy
                    turnToFight = 1;
                }
                // enemy turn
                if (turnToFight == 1)
                {
                    // calculate damage
                    int enemyDmg = enemy.Attack();
                    Console.WriteLine($"The monster hit you, dealing {enemyDmg}dmg");
                    // player takes damage
                    player.TakeDamage(enemyDmg);
                    if (player.Health <= 0) { player.Health = 0; break; };
                    // pass the turn to the player
                    turnToFight = 0;
                }
                // print results
                Console.WriteLine("---");
                Console.WriteLine($"Monster: [{enemy.Health}/{enemy.MaxHealth}]");
                Console.WriteLine($"You: [{player.Health}/{player.MaxHealth}]");
                Console.WriteLine("---");
                // simulate fight with little delay
                Thread.Sleep(500);
            }
            // check if the player is a winner
            if (player.Health > 0)
            {
                Console.WriteLine("You won!");
                Utilities.Continue();
                GetReward(enemy);
            }
            else if (enemy.Health > 0)
            {
                Console.WriteLine($"You were killed by a {enemy.Name}");
                Exit();
            }
        }

        /// <summary>
        /// Give random amount of Experience and Coins to the player. Exp: [30, 70], Coins [50, 150]
        /// </summary>
        private static void GetReward(Enemy enemy)
        {
            Console.Clear();
            player.Heal();
            // give random experience and coins after winning the battle
            int exp = enemy.GiveExp(player);
            player.Experience += exp;
            int coins = Utilities.Randomise(min: 50, max: 150);
            player.Coins += coins;

            player.RecalculateStats();

            Console.WriteLine("You gained a reward:");
            Console.WriteLine($"Experience: {exp}. Now you have: {player.Experience} exp");
            Console.WriteLine($"Coins: {coins}. Now you have: {player.Coins} coins");

            Utilities.Continue();
            StartGame();
        }

        /// <summary>
        /// Create a hero with a given name
        /// </summary>
        /// <param name="name">name: used to specify hero name</param>
        private static void CreateHero(string name)
        {
            player = new Hero { Name = name, Coins = 1000, Health = 100, MaxHealth = 100, Strength = 20 };
            player.RecalculateStats();
        }

        /// <summary>
        /// Close the applecation
        /// </summary>
        private static void Exit()
        {
            Console.Clear();
            Console.WriteLine("See you soon my hero!");
            Environment.Exit(0);
        }

    }
}
