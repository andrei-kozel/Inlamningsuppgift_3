using System;
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
        public int Damage { get; set;  }
        public double Coins { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public Inventory Invenory { get; set; }

        public void Heal()
        {
            Health = MaxHealth;
        }

        public int CalculateDamage()
        {
            int dmg = 100 + 5 * Strength;
            return dmg;
        }

        public int CalculateLevel()
        {
            return Experience / 100;
        }

        public void RecalculateStats()
        {
            Damage = CalculateDamage();
            Level = CalculateLevel();
        }

        internal void Describe()
        {
            Console.Clear();
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Damage: {Damage}");
            Console.WriteLine($"Coins: {Coins}");
            Console.WriteLine($"Experience: {Experience}");
            Console.WriteLine($"Level: {Level}");
        }

        internal void TakeDamage(int enemyDmg)
        {
            Health = Health - enemyDmg;
        }
    }
}