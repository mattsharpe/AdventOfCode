using System;
using System.Collections.Generic;

namespace Advent2015.Solutions
{
    class Day3
    {
        public Day3()
        {
            X = 0;
            Y = 0;
            Visited = new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int>(X, Y)
            };
        }

        public int X { get; set; }
        public int Y { get; set; }

        public HashSet<Tuple<int, int>> Visited;

        public void ProcessInstructions(string input)
        {
            foreach (var instruction in input)
            {
                switch (instruction)
                {
                    case '<':
                        X--;
                        break;
                    case '>':
                        X++;
                        break;
                    case '^':
                        Y--;
                        break;
                    case 'v':
                        Y++;
                        break;
                    default:
                        throw new Exception("Uknown instruction");
                }

                Visited.Add(new Tuple<int,int>(X, Y));
            }
        }
    }
}
