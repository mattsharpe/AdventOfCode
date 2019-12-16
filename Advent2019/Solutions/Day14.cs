using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2019.Solutions
{
    class Day14
    {
        private Dictionary<string, long> _generated;
        private Dictionary<(string chemical, long quantity), List<(string chemical, long quantity)>> _rules;
        
        public void Parse(string[] input)
        {
            (string chemical, long quantity) Parse(string chemical)
            {
                return (chemical.Split(" ")[1], Convert.ToInt64(chemical.Split(" ")[0]));
            }

            var chemicals = input.Select(line =>
            {
                var split = line.Split(" => ");
                var target = Parse(split[1]);
                var required = split[0].Split(", ").Select(Parse).ToList();
                return (target, required);
            }).ToDictionary(x => x.target, x => x.required);

            _generated = chemicals.ToDictionary(x => x.Key.chemical, x => 0L);
            _rules = chemicals;
        }
        public long CalculateAmountOfOreRequired(long target = 1)
        {
            //keep track of what we've generated, we can generate more than we need and then use later.
            var shoppingList = new Queue<(string chemical, long quantity)>();
            shoppingList.Enqueue(("FUEL", target));

            long ore = 0;
            while (shoppingList.Any())
            {
                var (chemical, quantity) = shoppingList.Dequeue();

                if (chemical == "ORE")
                {
                    ore += quantity;
                }
                else
                {
                    var rule = _rules.Single(x => x.Key.chemical == chemical);
                    //do we have any in stock already?
                    if (_generated[chemical] > 0)
                    {
                        var amount = Math.Min(quantity, _generated[chemical]);
                        _generated[chemical] -= amount;
                        quantity -= amount;
                    }

                    if (quantity > 0)
                    {
                        var batchesToCook = (long) Math.Ceiling((decimal) quantity / rule.Key.quantity);
                        _generated[chemical] += (long) Math.Max(0, batchesToCook * rule.Key.quantity - quantity);
                        foreach (var ingredient in rule.Value)
                        {
                            shoppingList.Enqueue((ingredient.chemical, ingredient.quantity * batchesToCook));
                        }
                    }
                }
            }
            return ore;
        }

        public long MaxFuelForOneTrillionOre(string[] input)
        {
            var target = 1000000000000;
            Parse(input);

            var costOfOneUnit = CalculateAmountOfOreRequired();
            
            var min = target / costOfOneUnit;
            var max = Convert.ToInt64(min * 3);
            
            while (min < max)
            {
                Parse(input);
                var mid = (min + max) / 2;
                var next = CalculateAmountOfOreRequired(mid);
                Console.WriteLine($"{mid} : {next}");
                if (next > target)
                { 
                    max = mid;
                }
                else if (next < target)
                {
                    if (mid == min) break;
                    min = mid;
                }
                else
                {
                    min = mid;
                    break;
                }
            }

            return min;
        }
    }
}