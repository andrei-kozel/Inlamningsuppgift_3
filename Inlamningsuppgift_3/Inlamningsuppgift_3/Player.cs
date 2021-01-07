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
        public int Damage { get; set; }
        public double Coins { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }

        public void Heal()
        {
            Health = MaxHealth;
        }

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
            if (Armor != null) { Console.WriteLine($"Armor: {Armor.BlockDmg}"); };
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