﻿using System;
using System.Threading;

namespace Inlamningsuppgift_3
{
    class Program
    {
        private static Player player;
        static void Main(string[] args)
        {
            Console.WriteLine("***********************");
            Console.WriteLine("* Welcom to The Game! *");
            Console.WriteLine("***********************");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            CreateHero(name);
            StartGame();
        }

        private static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("1. Go adventuring");
            Console.WriteLine("2. Show details about your character");
            Console.WriteLine("3. Visit shop");
            Console.WriteLine("4. Exit game");

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

        private static void VisitShop()
        {
            Shop shop = new Shop();
            shop.GenerateShop();

            Console.Clear();
            Console.WriteLine("1. Armor");
            Console.WriteLine("2. Weapon");
            Console.WriteLine("3. Amulets");
            Console.WriteLine("4. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    shop.ShowArmor();
                    break;
                case 2:
                    shop.ShowWeapon();
                    break;
                case 3:
                    break;
                case 4:
                    Exit();
                    break;
                default:
                    break;
            }
            StartGame();
        }

        private static void BuyArmor()
        {
            throw new NotImplementedException();
        }

        private static void ShowDetails()
        {
            player.Describe();
            Utilities.Continue();
            StartGame();
        }

        private static void GoAdventuring()
        {
            Console.Clear();
            Enemy enemy = new Enemy();
            int chance = Utilities.Randomise(min: 0, max: 101);
            if(chance <= 10)
            {
                Console.WriteLine("You see nothing ...");
                Utilities.Continue();
                StartGame();
            } else
            {
                Console.WriteLine($"Un no! A wild {enemy.Name} appeared. He has {enemy.Damage}dmg and {enemy.Health}hp");
                Console.WriteLine("");
                StartAFight(enemy);
                Utilities.Continue();
                StartGame();
            }
            
        }

        public static void StartAFight(Enemy enemy)
        {
            int turnToFight = 0;
            while (player.Health > 0 && enemy.Health > 0)
            {
                if (turnToFight == 0)
                {
                    int playerDmg = Utilities.Randomise(min: 10, max: player.Damage);
                    enemy.TakeDamage(playerDmg);
                    Console.WriteLine($"You hit the monster, dealing {playerDmg}dmg. ");
                    if (enemy.Health <= 0 ) { enemy.Health = 0; break; };
                    turnToFight = 1;
                }
                if (turnToFight == 1)
                {
                    int enemyDmg = Utilities.Randomise(min: 10, max: enemy.Damage);
                    Console.WriteLine($"The monster hit you, dealing {enemyDmg}dmg");
                    player.TakeDamage(enemyDmg);
                    if (player.Health <= 0) { player.Health = 0; break; };
                    turnToFight = 0;
                }
                Console.WriteLine("---");
                Console.WriteLine($"Monster: [{enemy.Health}/{enemy.MaxHealth}]");
                Console.WriteLine($"You: [{player.Health}/{player.MaxHealth}]");
                Console.WriteLine("---");

                Thread.Sleep(500);
            }
            if (player.Health > 0)
            {
                Console.WriteLine("You won!");
                Utilities.Continue();
                GetReward();
                
            }
            else if (enemy.Health > 0)
            {
                Console.WriteLine($"You were killed by a {enemy.Name}");
                Exit();
            }
        }

        private static void GetReward()
        {
            Console.Clear();
            player.Heal();
            int exp = Utilities.Randomise(min: 30, max: 70);
            player.Experience += exp;
            int coins = Utilities.Randomise(min: 50, max: 150);
            player.Coins += coins;

            player.RecalculateStats();

            Console.WriteLine("You gained a reward:");
            Console.WriteLine($"Experience: {exp}. Now you have: {player.Experience}");
            Console.WriteLine($"Coins: {coins}. Now you have: {player.Coins}");

            Utilities.Continue();
            StartGame();
        }

        private static void CreateHero(string name)
        {
            player = new Player { Name = name, Coins = 0, Health = 100, MaxHealth = 100, Strength = 20 };
            player.RecalculateStats();
        }

        private static void Exit()
        {
            Console.Clear();
            Console.WriteLine("See you soon my hero!");
            Environment.Exit(0);
        }

    }
}
