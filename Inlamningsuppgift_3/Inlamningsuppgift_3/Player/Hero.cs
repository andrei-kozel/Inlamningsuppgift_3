using Inlamningsuppgift_3.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift_3
{
    class Hero : IPlayer
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public int Coins { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }


        /// <summary>
        /// Calculate player's armor 
        /// </summary>
        /// <returns>int: amount of armor</returns>
        public int CalculateArmor()
        {
            if (Armor != null)
            {
                return Armor.BlockDmg + 2 * Strength;
            }
            else
            {
                int armor = 20 + 2 * Strength;
                return armor;
            }
        }

        /// <summary>
        /// Calculate player's level. Every 100xp = 1lvl
        /// </summary>
        public int CalculateLevel()
        {
            return Experience / 100;
        }

        /// <summary>
        /// Calculate player's damage 
        /// </summary>
        /// <returns>Damage [int]</returns>
        public int CalculateDamage()
        {
            if (Weapon != null)
            {
                int randomWeaponDamage = Utilities.Randomise(min: Weapon.Damage - 10, max: Weapon.Damage + 10);
                return randomWeaponDamage + 5 * Strength;
            }
            else
            {
                int randomBaseDamage = Utilities.Randomise(min: Damage - 10, max: Damage + 10);
                return randomBaseDamage + 5 * Strength;
            }
        }

        /// <summary>
        /// Calculate players health
        /// </summary>
        /// <returns>int: healh amount</returns>
        public int CalculateHealth()
        {
            return Convert.ToInt32(Health + (Health * Strength / 100 * Level));
        }

        /// <summary>
        /// Recalculate players stats based on new items etc.
        /// </summary>
        public void RecalculateStats()
        {
            Level = CalculateLevel();
            Health = CalculateHealth();
            MaxHealth = Health;
        }


        /// <summary>
        /// Completely heal the player. Health = 100%
        /// </summary>
        public void Heal()
        {
            Health = MaxHealth;
        }


        /// <summary>
        /// Print out player stats
        /// </summary>
        public void Describe()
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
        public void TakeDamage(int enemyDmg)
        {
            int finalDamage = enemyDmg;
            if (Armor != null)
            {
                finalDamage = enemyDmg / (enemyDmg + Armor.BlockDmg);
            }
            Health -= finalDamage;
        }

        /// <summary>
        /// Pay for an item in the shop
        /// </summary>
        /// <param name="price">int: item price. Used to withdraw coins from player wallet</param>
        internal void MakePayment(int price)
        {
            Coins -= price;
        }

        /// <summary>
        /// Put on armor on the player
        /// </summary>
        /// <param name="armor">Armor: used to specify Armor object.</param>
        internal void PutOnArmor(Armor armor)
        {
            Armor = armor;
        }

        /// <summary>
        /// Take the weapon
        /// </summary>
        /// <param name="weapon">Weapon: used to specify Weapon object.</param>
        internal void TakeWeapon(Weapon weapon)
        {
            Weapon = weapon;
            Damage = weapon.Damage;
        }

        public int Attack()
        {
            return CalculateDamage();
        }

        /// <summary>
        /// Increase strength by 1.
        /// </summary>
        internal void IncreaceStrength()
        {
            Strength += 1;
        }
    }
}