using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2019.Solutions
{
    class Day03
    {
        
        private readonly Dictionary<string, (int x, int y)> _directions = new Dictionary<string, (int x, int y)>
        {
            {"U", (0, 1) },
            {"D", (0, -1) },
            {"L", (-1, 0) },
            {"R", (1, 0) }
        };

        public int FindMostCentralIntersection(string first, string second)
        {
            var path = GetVisited(first.Split(",")).Keys.Intersect(GetVisited(second.Split(",")).Keys)
                    .ToHashSet();
            path.Remove((0, 0));
            return path.Min(loc => ManhattanDistance(0, loc.x, 0, loc.y));
        }

        public int ManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        public Dictionary<(int x, int y),int> GetVisited(string[] instructions)
        {
            var result = new Dictionary<(int x, int y), int>();
            (int x, int y) currentLocation = (0, 0);
            int steps = 1;
            result.Add(currentLocation, 0);

            foreach (var instruction in instructions)
            {
                var direction = instruction.Substring(0, 1);
                var distance = Convert.ToInt32(instruction.Substring(1, instruction.Length-1));
                var (x, y) = _directions[direction];
                
                for (var i = 0; i < distance; i++)
                {
                    currentLocation.x += x;
                    currentLocation.y += y;
                    result.TryAdd(currentLocation, steps++);
                }
            }
            return result;
        }

        public int CollisionDistance(string first, string second)
        {
            var firstPath = GetVisited(first.Split(","));
            var secondPath = GetVisited(second.Split(","));
            var intersections = firstPath.Keys.Intersect(secondPath.Keys).ToHashSet();
            return intersections
                .Where(x=> x!= (0,0))
                .Min(x => firstPath[x] + secondPath[x]); 
        }
    }
}
