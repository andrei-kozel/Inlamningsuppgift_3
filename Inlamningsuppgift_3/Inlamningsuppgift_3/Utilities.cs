using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift_3
{
    static class Utilities
    {
        public static int Randomise(int max, int min = 0)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static void Continue()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}
