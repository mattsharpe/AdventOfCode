using System;
using System.Collections.Generic;
using System.Linq;
using Advent2018.Utilities;

namespace Advent2018.Solutions
{
    public class Day06
    {

        public List<Location> Parse(string[] input)
        {
            return input.Select(x =>
            {
                var line = x.Split(",").Select(int.Parse).ToArray();
                return new Location {X = line[0], Y = line[1]};
            }).ToList();
        }

        public int CalculateLargestNonInfiniteArea(string[] input)
        {
            var coordinates = Parse(input);

            var minX = coordinates.Min(coords => coords.X);
            var maxX = coordinates.Max(coords => coords.X);

            var minY = coordinates.Min(coords => coords.Y);
            var maxY = coordinates.Max(coords => coords.Y);
            
            var area = new int[coordinates.Count];

            foreach (var x in Enumerable.Range(minX, maxX - minX + 1))
            {
                foreach (var y in Enumerable.Range(minY, maxY - minY + 1))
                {
                    var distance = coordinates.Min(coordinate => ManhattanDistance(x, coordinate.X, y, coordinate.Y));
                    var closestIds = Enumerable.Range(0, coordinates.Count).Where(i => ManhattanDistance(x, coordinates[i].X, y, coordinates[i].Y) == distance).ToArray();

                    if (closestIds.Length != 1)
                    {
                        continue;
                    }

                    if (x == minX || x == maxX || y == minY || y == maxY)
                    {
                        closestIds.ForEach(id => area[id] = -1);
                    }
                    else
                    {
                        closestIds.ForEach(id => area[id]++);
                    }

                }
            }

            return area.Max();
            
        }

        public int Part2(string[] input)
        {
            var coordinates = Parse(input);

            var minX = coordinates.Min(coords => coords.X);
            var maxX = coordinates.Max(coords => coords.X);

            var minY = coordinates.Min(coords => coords.Y);
            var maxY = coordinates.Max(coords => coords.Y);

            var result = Enumerable.Range(minX, maxX - minX + 1).Sum(x => 
                Enumerable.Range(minY, maxY - minX + 1).Select(y => 
                    coordinates.Select(coord => 
                        ManhattanDistance(x, coord.X, y, coord.Y)).Sum()).Count(d => d < 10000));

            return result;
        }


        public int ManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

    }

    public struct Location
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
