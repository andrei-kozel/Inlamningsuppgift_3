﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift_3
{
    class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public double Coins { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }

        /// <summary>
        /// Completely heal the player. Health = 100%
        /// </summary>
        public void Heal()
        {
            Health = MaxHealth;
        }

        /// <summary>
        /// Calculate player's damage 
        /// </summary>
        /// <returns>Damage [int]</returns>
        public int CalculateDamage()
        {
            if (Weapon != null)
            {
                return Weapon.Damage + 5 * Strength;
            }
            else
            {
                int dmg = 100 + 5 * Strength;
                return dmg;
            }
        }

        /// <summary>
        /// Calculate player's armor 
        /// </summary>
        /// <returns>Amount of armor [int]</returns>
        public int CalculateArmor()
        {
            if (Armor != null)
            {
                return Armor.BlockDmg + 2 * Strength; 
            }else
            {
                int armor = 20 + 2 * Strength;
                return armor;
            }
        }

        /// <summary>
        /// Calculate player's level. Every 100xp = 1lvl
        /// </summary>
        /// <returns></returns>
        public int CalculateLevel()
        {
            return Experience / 100;
        }

        /// <summary>
        /// Recalculate players stats based on new items etc.
        /// </summary>
        public void RecalculateStats()
        {
            Damage = CalculateDamage();
            Level = CalculateLevel();
        }

        /// <summary>
        /// Print out player stats
        /// </summary>
        internal void Describe()
        {
            Console.Clear();
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Damage: {Damage}");
            if (Armor != null) { Console.WriteLine($"Armor: {Armor.BlockDmg}"); };
            Console.WriteLine($"Coins: {Coins}");
            Console.WriteLine($"Experience: {Experience}");
            Console.WriteLine($"Level: {Level}");
            
        }

        /// <summary>
        /// Calculate health after taking damage
        /// </summary>
        /// <param name="enemyDmg">Used to specify taken damage</param>
        internal void TakeDamage(int enemyDmg)
        {
            Health = Health - enemyDmg;
        }
    }
}