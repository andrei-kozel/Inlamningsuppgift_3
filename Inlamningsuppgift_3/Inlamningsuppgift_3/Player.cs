using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift_3
{
    class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public int Damage { get; set; }
        public double Coins { get; set; }
        public int Experience { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public Inventory Invenory { get; set; }

        internal void Heal()
        {
            Health = MaxHealth;
        }
    }
}