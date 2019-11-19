using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2015.Solutions
{
    class Day15
    {
        public List<Ingredient> ParseInput(string[] ingredients)
        {
            return ingredients.Select(x =>
            {
                var split = x.Replace(",", "").Split(' ');
                return new Ingredient
                {
                    Name = split[0],
                    Capacity = Convert.ToInt32(split[2]),
                    Durability = Convert.ToInt32(split[4]),
                    Flavour = Convert.ToInt32(split[6]),
                    Texture = Convert.ToInt32(split[8]),
                    Calories = Convert.ToInt32(split[10])
                };
            }).ToList();
        }

        public int BakeBestCookie(string[] input, bool lowCalorie = false)
        {
            var ingredients = ParseInput(input);
            var recipes = GenerateCombinations(ingredients, 100);
            if(lowCalorie){
                recipes = recipes.Where(x=>x.Sum(y=>y.Calories) == 500).ToList();
            }

            var all = recipes.Select(ScoreRecipe);
            var ordered = all.OrderByDescending(x => x);
            return ordered.First();
        }

        public int ScoreRecipe(IEnumerable<Ingredient> ingredients)
        {
            var recipe = ingredients.GroupBy(x => x).Select(x=> new {
                Ingredient = x.First(),
                Count = x.Count()
            });

            var capacity = 0;
            var durability = 0;
            var flavour = 0;
            var texture = 0;

            foreach (var ingredient in recipe)
            {

                capacity += (ingredient.Ingredient.Capacity * ingredient.Count);
                durability += (ingredient.Ingredient.Durability * ingredient.Count);
                flavour += (ingredient.Ingredient.Flavour * ingredient.Count);
                texture += (ingredient.Ingredient.Texture * ingredient.Count);
            }

            return Math.Max(capacity, 0) *
                    Math.Max(durability, 0) *
                    Math.Max(flavour, 0) *
                    Math.Max(texture, 0);
        }
        
        private static List<List<Ingredient>> GenerateCombinations(List<Ingredient> ingredients, int count)
        {
            var combinations = new List<List<Ingredient>>();
 
            if (count == 0)
            {
                var emptyCombination = new List<Ingredient>();
                combinations.Add(emptyCombination);
 
                return combinations;
            }
 
            if (ingredients.Count == 0)
            {
                return combinations;
            }
 
            var head = ingredients[0];
            var copiedCombinationList = new List<Ingredient>(ingredients);
 
            var subCombinations = GenerateCombinations(copiedCombinationList, count - 1);

            foreach (var sub in subCombinations)
            {
                sub.Insert(0, head);
                combinations.Add(sub);
            }

            ingredients.RemoveAt(0);
            combinations.AddRange(GenerateCombinations(ingredients, count));
 
            return combinations;
        }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Durability { get; set; }
        public int Flavour { get; set; }
        public int Texture { get; set; }
        public int Calories { get; set; }
    }
}
