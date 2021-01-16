using Inlamningsuppgift_3;

namespace Inlamningsuppgift_3
{
    public class Armor : IItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int BlockDmg { get; set; }
        public int Price { get; set; }

        public bool CanIBuyIt(int coins)
        {
            if (coins >= Price) { return true; }
            else { return false; }
        }
    }
}