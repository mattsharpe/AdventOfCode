using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

    }

    public class Moon
    {
        public (int x, int y, int z) Position { get; set; }
        public (int x, int y, int z) Velocity { get; set; }
    }

    public class Point3D
    {
        public Point3D()
        {

        }
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }

    }
}
