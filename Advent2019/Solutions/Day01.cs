using System;
using System.Linq;

namespace Advent2019.Solutions
{
    class Day01
    {
        public int CalculateFuel(int mass)
        {
            return mass / 3 - 2;
        }

        public int TotalFuelRequirement(string[] input)
        {
            return input.Sum(x => CalculateFuel(Convert.ToInt32(x)));
        }
    }
}
