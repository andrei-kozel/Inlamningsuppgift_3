using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift_3
{
    class Shop
    {
        List<Armor> listOfArmors = new List<Armor>();
        List<Weapon> listOfWeapons = new List<Weapon>();

        public Shop()
        {
            listOfWeapons.Add(new Weapon { Name = "Keyblade", Damage = 120, Type = "Sword", Price = 150 });
            listOfWeapons.Add(new Weapon { Name = "Lightsaber ", Damage = 140, Type = "Sword", Price = 160 });
            listOfWeapons.Add(new Weapon { Name = "Scorpion's Spear", Damage = 1000, Type = "Spear", Price = 500 });

            listOfArmors.Add(new Armor { Name = "Tanooki", BlockDmg = 20, Type = "Light", Price = 30 });
            listOfArmors.Add(new Armor { Name = "OctoCamo", BlockDmg = 50, Type = "Light", Price = 70 });
            listOfArmors.Add(new Armor { Name = "Nanosuit", BlockDmg = 1000, Type = "Light", Price = 200 });
            listOfArmors.Add(new Armor { Name = "BioShock Big Daddy set", BlockDmg = 5000, Type = "Heavy", Price = 500 });
        }

        public void ShowArmor()
        {
            Console.Clear();
            for(int i = 1; i < listOfArmors.Count; i++)
            {
                Console.WriteLine($"{i}. [{listOfArmors[i].Type}] {listOfArmors[i].Name} / Blocks {listOfArmors[i].BlockDmg} dmg / {listOfArmors[i].Price} coins  ");
            }
        }
        public void ShowWeapon()
        {
            Console.Clear();
            for (int i = 1; i < listOfWeapons.Count; i++)
            {
                Console.WriteLine($"{i}. [{listOfWeapons[i].Type}] {listOfWeapons[i].Name} / {listOfWeapons[i].Damage} dmg / {listOfWeapons[i].Price} coins  ");
            }
        }

        public Armor GetArmor(int index)
        {
            return listOfArmors[index];
        }

        public Weapon GetWeapon(int index)
        {
            return listOfWeapons[index];
        }
    }
}
