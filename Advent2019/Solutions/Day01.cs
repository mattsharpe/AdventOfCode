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

        public int CalculateFuelWithExtra(int mass)
        {
            var result = 0;
            while (CalculateFuel(mass) > 0)
            {
                var next = CalculateFuel(mass);
                result += next;
                mass = next;
            }

            return result;
        }

        
        public int TotalFuelRequirementWithExtra(string[] input)
        {
            return input.Sum(x => CalculateFuelWithExtra(Convert.ToInt32(x)));
        }
    }
}
