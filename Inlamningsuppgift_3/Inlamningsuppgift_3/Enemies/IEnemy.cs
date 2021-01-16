using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift_3.Enemies
{
    interface IEnemy
    {
        string Name { set; get; }
        int Damage { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }

        int Attack();
        void TakeDamage(int damage) { Health -= damage; }
        int GiveExp();
    }
}
