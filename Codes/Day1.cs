using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Codes
{
    public class Day1
    {
        
        public static int Distance(string input)
        {            
            var instructions = input.Split(',')
                .Select(x =>
                {
                    var instruction = x.Trim();
                    return new Vector
                    {
                        Direction = instruction.Substring(0, 1) == "R" ? 90 : -90,
                        Magnitude = Convert.ToInt32(instruction.Substring(1))
                    };
                });

            Direction currentDirection = Direction.North;
            Location currentLocation = new Location(0, 0);
            
            foreach (var vector in instructions)
            {
                currentDirection = GetNewDirection(currentDirection, vector.Direction);
                currentLocation = UpdateLocation(currentDirection, currentLocation, vector.Magnitude);
            }

            return Math.Abs(currentLocation.X) + Math.Abs(currentLocation.Y);
        }

        public static Location UpdateLocation(Direction currentDirection, Location currentLocation, int distance)
        {
            var modifier = LocationModifiers[currentDirection];

            var distanceTravelled = modifier * distance;
            return currentLocation + distanceTravelled;
        }

        private static readonly Dictionary<Direction, Location> LocationModifiers = new Dictionary<Direction, Location>
        {
            {Direction.North, new Location(0,1) },
            {Direction.East, new Location(1,0) },
            {Direction.South, new Location(0,-1) },
            {Direction.West, new Location(-1,0) }
        };

        public static Direction GetNewDirection(Direction currentDirection, int turn)
        {
            var newBearing = (Convert.ToInt32(currentDirection) + turn);
            if (newBearing < 0) newBearing += 360;
            return (Direction)(newBearing % 360);
        }
    }
    
    public enum Direction
    {
        North = 0,
        East = 90,
        South = 180,
        West = 270
    }

    public struct Vector
    {
        public int Direction;
        public int Magnitude;
    }

    public struct Location
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public static Location operator +(Location a, Location b)
        {
            return new Location(a.X + b.X, a.Y + b.Y);
        }
        public static Location operator *(Location loc, int magnitude)
        {
            return new Location(loc.X * magnitude, loc.Y * magnitude);
        }
    }
}
