using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift_3.Player
{
    interface IPlayer
    {
        string Name { get; set; }
        int Health { get; set; }
        int Strength { get; set; }
        int MaxHealth { get; set; }
        int Damage { get; set; }
        double Coins { get; set; }
        int Experience { get; set; }
        int Level { get; set; }
        Weapon Weapon { get; set; }
        Armor Armor { get; set; }

        /// <summary>
        /// Calculate player's armor 
        /// </summary>
        /// <returns>Amount of armor [int]</returns>
        public int CalculateArmor();

        /// <summary>
        /// Calculate player's level. Every 100xp = 1lvl
        /// </summary>
        public int CalculateLevel();

        /// <summary>
        /// Calculate player's damage 
        /// </summary>
        /// <returns>Damage [int]</returns>
        public int CalculateDamage();

        /// <summary>
        /// Recalculate players stats based on new items etc.
        /// </summary>
        public void RecalculateStats();

        /// <summary>
        /// Completely heal the player. Health = 100%
        /// </summary>
        public void Heal();

        /// <summary>
        /// Print out player stats
        /// </summary>
        public void Describe();

        /// <summary>
        /// Calculate health after taking damage
        /// </summary>
        /// <param name="enemyDmg">Used to specify taken damage</param>
        public void TakeDamage(int enemyDmg);
    }
}

