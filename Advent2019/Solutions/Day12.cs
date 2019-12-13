using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2019.Solutions
{
    class Day12
    {
        public List<Moon> Moons { get; set; } = new List<Moon>();

        public void ParseInput(string[] input)
        {
            Moons = input.Select(moon => Regex.Match(moon, @"x=(-?\d+), y=(-?\d+), z=(-?\d+)"))
                .Select(match => new Moon
                {
                    Position = (
                    Convert.ToInt32(match.Groups[1].Value),
                    Convert.ToInt32(match.Groups[2].Value),
                    Convert.ToInt32(match.Groups[3].Value)
                )
                }).ToList();
        }

        public void Step()
        {
            // Apply gravity
            foreach (var moon in Moons)
            {
                var toCompare = Moons.Where(x => x != moon).ToArray();

                var velocityX = moon.Velocity.x +
                                toCompare.Count(a => a.Position.x > moon.Position.x) -
                                toCompare.Count(a => a.Position.x < moon.Position.x);

                var velocityY = moon.Velocity.y +
                                toCompare.Count(a => a.Position.y > moon.Position.y) -
                                toCompare.Count(a => a.Position.y < moon.Position.y);

                var velocityZ = moon.Velocity.z + 
                                toCompare.Count(a => a.Position.z > moon.Position.z) -
                                toCompare.Count(a => a.Position.z < moon.Position.z);

                moon.Velocity = (velocityX, velocityY, velocityZ);

            }

            foreach (var moon in Moons)
            {
                moon.Position = (moon.Position.x + moon.Velocity.x,
                                moon.Position.y + moon.Velocity.y,
                                moon.Position.z + moon.Velocity.z);
            }

        }

        public int CalculateTotalEnergy()
        {
            return Moons.Sum(moon =>
                (Math.Abs(moon.Velocity.x) + Math.Abs(moon.Velocity.y) + Math.Abs(moon.Velocity.z)) *
                (Math.Abs(moon.Position.x) + Math.Abs(moon.Position.y) + Math.Abs(moon.Position.z))
            );
        }

        public long NumberOfStepsUntilRepeatedState()
        {
            var xPeriod = -1;
            var yPeriod = -1;
            var zPeriod = -1;

            int count =0;
            while (xPeriod == -1 || yPeriod == -1 || zPeriod == -1)
            {
                Step();
                count++;

                if (xPeriod == -1 && Moons.All(moon => moon.Velocity.x == 0))
                    xPeriod = count;
                
                if (yPeriod == -1 && Moons.All(moon => moon.Velocity.y == 0))
                    yPeriod = count;
                
                if (zPeriod == -1 && Moons.All(moon => moon.Velocity.z == 0))
                    zPeriod = count;

            }

            return LowestCommonMultiple(xPeriod, LowestCommonMultiple(yPeriod, zPeriod)) *2;
        }

        private long GreatestCommonDivisor(long a, long b)
        {
            if (a % b == 0) return b;
            return GreatestCommonDivisor(b, a % b);
        }

        private long LowestCommonMultiple(long a, long b)
        {
            return a * b / GreatestCommonDivisor(a, b);
        }

    }

    public class Moon
    {
        public (int x, int y, int z) Position { get; set; }
        public (int x, int y, int z) Velocity { get; set; }
    }
}
