using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2018.Solutions
{
    class Day14
    {
        private int _elf1 = 0;
        private int _elf2 = 1;
        private List<int> _recipes = new List<int>{3, 7};
        
        public string GetNext10(int input)
        {
            //loop until we generate enough recipes to get 10 more than our input
            while (_recipes.Count() < input + 10)
            {
                var sum = _recipes[_elf1] + _recipes[_elf2];
                var newScores = sum.ToString().Select(x => int.Parse(x + "")).ToArray();
                _recipes.AddRange(newScores);

                // To do this, the Elf steps forward through the scoreboard a number of recipes equal to 1 plus the score of their
                // current recipe.
                // So, after the first round, the first Elf moves forward 1 + 3 = 4 times,
                // while the second Elf moves forward 1 + 7 = 8 times.
                // If they run out of recipes, they loop back around to the beginning.
                _elf1 = (_elf1 + _recipes[_elf1] + 1) % _recipes.Count;
                _elf2 = (_elf2 + _recipes[_elf2] + 1) % _recipes.Count;
                
            }

            return string.Join("", _recipes.Skip(input).Take(10));
        }
    }
}
