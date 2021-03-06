﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift_3
{
    class Enemy : IEnemy
    {
        string[] names = new string[] { "Stenchurion", "Armos", "Chaser", "Gibo", "Kargaroc", "Mad Bomber" };
        private string _name;
        private int _damage;
        private int _health;

        /// <summary>
        /// Generate enemy with random damage, name, health
        /// </summary>
        public Enemy()
        {
            _name = names[Utilities.Randomise(names.Length)];
            _damage = Utilities.Randomise(min: 10, max: 50);
            _health = Utilities.Randomise(min: 50, max: 250);
            MaxHealth = _health;
        }

        public string Name { get => _name; set => _name = value; }
        public int Damage { get => _damage; set => _damage = value; }
        public int Health { get => _health; set => _health = value; }
        public int MaxHealth { get; set; }

        // calculate health after taking damage
        public void TakeDamage(int playerDmg)
        {
            Health = Health - playerDmg;
        }

        public int Attack()
        {
            return Damage;
        }


        public int GiveExp(Hero player)
        {
            int expMultiplier = 4;
            int exp = Convert.ToInt32( MaxHealth * 0.6 / (1 + player.Level) * expMultiplier);
            return exp;
        }
    } 
}
