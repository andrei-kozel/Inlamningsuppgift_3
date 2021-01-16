namespace Inlamningsuppgift_3
{
    public class Weapon : IItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Damage { get; set; }
        public int Price { get; set; }

        public bool CanIBuyIt(int coins)
        {
            if(coins >= Price) { return true; }
            else { return false; }
        }
    }
}