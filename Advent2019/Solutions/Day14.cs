using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2019.Solutions
{
    class Day14
    {

        public Dictionary<(string chemical, int quantity), List<(string chemical, int quantity)>> Parse(string[] input)
        {
            (string chemical, int quantity) Parse(string chemical)
            {
                return (chemical.Split(" ")[1], Convert.ToInt32(chemical.Split(" ")[0]));
            }

            return input.Select(line =>
            {
                var split = line.Split(" => ");
                var target = Parse(split[1]);
                var required = split[0].Split(", ").Select(Parse).ToList();
                return (target, required);
            }).ToDictionary(x => x.target, x => x.required);

        }
        public int CalculateAmountOfOreRequired(string[] input)
        {
            var rules = Parse(input);

            //keep track of what we've generated, we can generate more than we need and then use later.
            var generated = rules.ToDictionary(x => x.Key.chemical, x => 0);
            var shoppingList = new Queue<(string chemical, int quantity)>();
            shoppingList.Enqueue(("FUEL", 1));

            int ore = 0;
            while (shoppingList.Any())
            {
                var (chemical, quantity) = shoppingList.Dequeue();

                if (chemical == "ORE")
                {
                    ore += quantity;
                }
                else
                {
                    Console.WriteLine($"Need to get {quantity} {chemical}");
                    var rule = rules.Single(x => x.Key.chemical == chemical);
                    //do we have any in stock already?
                    if (generated[chemical] > 0)
                    {
                        Console.WriteLine(
                            $"I've got {generated[chemical]} {chemical} in stock so can supply the {quantity} needed");
                        var amount = Math.Min(quantity, generated[chemical]);
                        generated[chemical] -= amount;
                        quantity -= amount;
                    }

                    if (quantity > 0)
                    {
                        //how many times do we need to make the recipe to fulfill the ask here?
                        Console.WriteLine($"I need {quantity} {chemical}, recipe will make {rule.Key.quantity}");
                        var batchesToCook = (int) Math.Ceiling((decimal) quantity / rule.Key.quantity);
                        Console.WriteLine($"Going to cook {batchesToCook} batches");

                        generated[chemical] += (int) Math.Max(0, batchesToCook * rule.Key.quantity - quantity);
                        foreach (var ingredient in rule.Value)
                        {
                            shoppingList.Enqueue((ingredient.chemical, ingredient.quantity * batchesToCook));
                        }
                    }
                }
            }
            return ore;
        }
    }
}