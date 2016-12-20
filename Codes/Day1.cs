using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Codes
{
    public class Day1
    {
        public Location CurrentLocation { get; set; }
        public Direction CurrentDirection { get; set; }

        public int FirstVisitedDistance(string input)
        {
            HashSet<Location> visits = new HashSet<Location>();

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

            CurrentDirection = Direction.North;
            CurrentLocation = new Location(0, 0);

            foreach (var vector in instructions)
            {
                SetNewDirection(vector.Direction);
                var found = UpdateLocationWithTracking(visits, vector.Magnitude);
                if (found) break;
            }

            return Math.Abs(CurrentLocation.X) + Math.Abs(CurrentLocation.Y);
        }

        private bool UpdateLocationWithTracking(HashSet<Location> visits, int distanceTravelled)
        {
            var modifier = LocationModifiers[CurrentDirection];

            while (distanceTravelled > 0)
            {
                CurrentLocation = CurrentLocation + modifier;
                distanceTravelled--;
                if (visits.Contains(CurrentLocation))
                {
                    return true;
                }
                visits.Add(CurrentLocation);
            }
            return false;
        }

        public int Distance(string input)
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

            foreach (var vector in instructions)
            {
                SetNewDirection(vector.Direction);
                UpdateLocation(vector.Magnitude);
            }

            return Math.Abs(CurrentLocation.X) + Math.Abs(CurrentLocation.Y);
        }

        public void UpdateLocation(int distance)
        {
            var modifier = LocationModifiers[CurrentDirection];

            var distanceTravelled = modifier * distance;
            CurrentLocation = CurrentLocation + distanceTravelled;
        }

        private static readonly Dictionary<Direction, Location> LocationModifiers = new Dictionary<Direction, Location>
        {
            {Direction.North, new Location(0,1) },
            {Direction.East, new Location(1,0) },
            {Direction.South, new Location(0,-1) },
            {Direction.West, new Location(-1,0) }
        };

        public void SetNewDirection(int turn)
        {
            var newBearing = (Convert.ToInt32(CurrentDirection) + turn);
            if (newBearing < 0) newBearing += 360;
            CurrentDirection = (Direction)(newBearing % 360);
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

    public class Location
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
        protected bool Equals(Location other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Location) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }
    }
}
