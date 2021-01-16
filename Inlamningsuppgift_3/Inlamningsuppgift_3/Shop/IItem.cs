using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift_3
{
    interface IItem
    {
        string Name { get; set; }
        int Price { get; set; }

        bool CanIBuyIt(int coins);
    }
}
