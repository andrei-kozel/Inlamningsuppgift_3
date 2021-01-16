using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift_3
{
    class Shop
    {
        List<Armor> listOfArmors = new List<Armor>();
        List<Weapon> listOfWeapons = new List<Weapon>();

        /// <summary>
        /// Generate shop with few "products"
        /// </summary>
        public Shop()
        {
            listOfWeapons.Add(new Weapon { Name = "Keyblade", Damage = 40, Type = "Sword", Price = 100 });
            listOfWeapons.Add(new Weapon { Name = "Lightsaber ", Damage = 100, Type = "Sword", Price = 120 });
            listOfWeapons.Add(new Weapon { Name = "Scorpion's Spear", Damage = 200, Type = "Spear", Price = 600 });
            listOfWeapons.Add(new Weapon { Name = "Deagle", Damage = 5000, Type = "Gun", Price = 10000 });

            listOfArmors.Add(new Armor { Name = "Tanooki", BlockDmg = 20, Type = "Light", Price = 30 });
            listOfArmors.Add(new Armor { Name = "OctoCamo", BlockDmg = 50, Type = "Light", Price = 70 });
            listOfArmors.Add(new Armor { Name = "Nanosuit", BlockDmg = 1000, Type = "Light", Price = 600 });
            listOfArmors.Add(new Armor { Name = "BioShock Big Daddy set", BlockDmg = 5000, Type = "Heavy", Price = 1000 });
        }

        /// <summary>
        /// Show available armor sets in the store
        /// </summary>
        public void ShowArmor()
        {
            Console.Clear();
            // print out all items
            for(int i = 1; i < listOfArmors.Count; i++)
            {
                Console.WriteLine($"{i}. [{listOfArmors[i].Type}] {listOfArmors[i].Name} / Blocks {listOfArmors[i].BlockDmg} dmg / {listOfArmors[i].Price} coins  ");
            }
        }
        /// <summary>
        /// Show available weapons in the store
        /// </summary>
        public void ShowWeapon()
        {
            Console.Clear();
            // print out all items
            for (int i = 1; i < listOfWeapons.Count; i++)
            {
                Console.WriteLine($"{i}. [{listOfWeapons[i].Type}] {listOfWeapons[i].Name} / {listOfWeapons[i].Damage} dmg / {listOfWeapons[i].Price} coins  ");
            }
        }

        /// <summary>
        /// Get armor set object
        /// </summary>
        /// <param name="index">Used to indicate item position in the List</param>
        /// <returns>Armor object</returns>
        public Armor GetArmor(int index)
        {
            return listOfArmors[index];
        }

        /// <summary>
        /// Get weapon object
        /// </summary>
        /// <param name="index">>Used to indicate item position in the List</param>
        /// <returns>Weapon object</returns>
        public Weapon GetWeapon(int index)
        {
            return listOfWeapons[index];
        }

    }
}
