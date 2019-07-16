using System;
using System.Collections.Generic;
using System.Linq;
using Advent2018.Utilities;

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

        public int HowManyRecipes(string target)
        {
            var found = false;
            var targetNumbers = target.Select(x=>Convert.ToInt32(x +"")).ToArray();
            int positionInRecipes = 0; //most recently checked start of string (persists across loops)
            int searchIndex = 0; //where in the string to compare digits (reset each loop)
            while (!found)
            {
                var sum = _recipes[_elf1] + _recipes[_elf2];
                if (sum > 9)
                {
                    _recipes.Add(1);
                }
                _recipes.Add(sum % 10);
                
                _elf1 = (_elf1 + _recipes[_elf1] + 1) % _recipes.Count;
                _elf2 = (_elf2 + _recipes[_elf2] + 1) % _recipes.Count;
                
                while (positionInRecipes + searchIndex < _recipes.Count)
                {
                    if (targetNumbers[searchIndex] != _recipes[positionInRecipes + searchIndex])
                    {
                        //start checking the next character
                        searchIndex = 0;
                        positionInRecipes++;
                    }
                    else
                    {
                        if (searchIndex == targetNumbers.Length - 1)
                        {
                            found = true;
                            break;
                        }
                        searchIndex++;
                    }
                }
            }
            return string.Join("", _recipes).IndexOf(target, StringComparison.Ordinal);
        }
    }
}
