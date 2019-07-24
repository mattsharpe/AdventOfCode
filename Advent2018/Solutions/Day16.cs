using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Advent2018.Utilities;

namespace Advent2018.Solutions
{
    class Day16
    {
        public List<Operator> Operators { get; set; }

        public int[] Registers { get; set; } = new int[4];

        public Day16()
        {
            Operators = new List<Operator>
            {
                new Operator {Name = "Addr", Action = (a, b, c) => Registers[c] = Registers[a] + Registers[b]},
                new Operator {Name = "Addi", Action = (a, b, c) => Registers[c] = Registers[a] + b},
                new Operator {Name = "Mulr", Action = (a, b, c) => Registers[c] = Registers[a] * Registers[b]},
                new Operator {Name = "Muli", Action = (a, b, c) => Registers[c] = Registers[a] * b},
                new Operator {Name = "Banr", Action = (a, b, c) => Registers[c] = Registers[a] & Registers[b]},
                new Operator {Name = "Bani", Action = (a, b, c) => Registers[c] = Registers[a] & b},
                new Operator {Name = "Borr", Action = (a, b, c) => Registers[c] = Registers[a] | Registers[b]},
                new Operator {Name = "Bori", Action = (a, b, c) => Registers[c] = Registers[a] | b},
                new Operator {Name = "Setr", Action = (a, b, c) => Registers[c] = Registers[a]},
                new Operator {Name = "Seti", Action = (a, b, c) => Registers[c] = a},
                new Operator {Name = "Gtir", Action = (a, b, c) => Registers[c] = a > Registers[b] ? 1 : 0},
                new Operator {Name = "Gtrr", Action = (a, b, c) => Registers[c] = Registers[a] > Registers[b] ? 1 : 0},
                new Operator {Name = "Gtri", Action = (a, b, c) => Registers[c] = Registers[a] > b ? 1 : 0},
                new Operator {Name = "Eqir", Action = (a, b, c) => Registers[c] = a == Registers[b] ? 1 : 0},
                new Operator {Name = "Eqri", Action = (a, b, c) => Registers[c] = Registers[a] == b ? 1 : 0},
                new Operator {Name = "Eqrr", Action = (a, b, c) => Registers[c] = Registers[a] == Registers[b] ? 1 : 0},
            };
        }

        public HashSet<Operator> TestInput((int[] Before, int[] Instruction, int[] After) sample)
        {
            return Operators.Where(x =>
                {
                    sample.Before.CopyTo(Registers, 0);
                    x.Action(sample.Instruction[1], sample.Instruction[2], sample.Instruction[3]);
                    return Registers.SequenceEqual(sample.After);
                }).ToHashSet();
        }

        public IEnumerable<(int[] Before, int[] Instruction, int[] After)> ParseInput(string[] input)
        {
            var regex = new Regex(@"Before: \[(\d, \d, \d, \d)\]");

            for (var i = 0; i < input.Length; i += 4)
            {
                if (!regex.IsMatch(input[i])) continue;

                var before = regex.Match(input[i]).Groups[1].ToString()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

                var instruction = input[i + 1].Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var after = input[i + 2].Substring(9, 10).Split(',')
                    .Select(int.Parse)
                    .ToArray();

                yield return (before, instruction, after);
            }
        }

        public int HowManySamplesMatch3OrMoreOperators(string[] input)
        {
            return ParseInput(input).Select(TestInput).Count(x => x.Count >= 3);
        }

        public void BuildOperators(string[] input)
        {
            var lookup = new Dictionary<int, HashSet<Operator>>();

            foreach (var x in ParseInput(input))
            {
                var opCode = x.Instruction[0];
                if (lookup.ContainsKey(opCode))
                {
                    continue;
                }

                lookup.Add(opCode, TestInput(x));
            }

            while (Operators.Any(x => x.OpCode == null))
            {
                var (key, value) = lookup.First(x => x.Value.Count == 1);
                var toAssign = value.Single();
                toAssign.OpCode = key;
                lookup.Values.ForEach(x =>
                {
                    x.Remove(toAssign);
                });
            }
        }

        public void ProcessOperations(string[] input)
        {
            var operations = Operators.ToDictionary(x => x.OpCode, x => x.Action);
            foreach (var instruction in input)
            {
                var x = instruction.Split(' ').Select(int.Parse).ToArray();
                operations[x[0]](x[1], x[2], x[3]);
                Console.WriteLine(string.Join(' ',Registers));
            }
        }
    }

    class Operator
    {
        public int? OpCode { get; set; } = null;
        public string Name { get; set; }
        public Action<int, int, int> Action { get; set; }
    }
}
