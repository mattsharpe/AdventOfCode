using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Utilities;

namespace AdventOfCode.Solutions
{
    public class Day1
    {
        public Location CurrentLocation { get; set; }
        public CompassBearing CurrentCompassBearing { get; set; }

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

            CurrentCompassBearing = CompassBearing.North;
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
            var modifier = LocationModifiers[CurrentCompassBearing];

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
            var modifier = LocationModifiers[CurrentCompassBearing];

            var distanceTravelled = modifier * distance;
            CurrentLocation = CurrentLocation + distanceTravelled;
        }

        private static readonly Dictionary<CompassBearing, Location> LocationModifiers = new Dictionary<CompassBearing, Location>
        {
            {CompassBearing.North, new Location(0,1) },
            {CompassBearing.East, new Location(1,0) },
            {CompassBearing.South, new Location(0,-1) },
            {CompassBearing.West, new Location(-1,0) }
        };

        public void SetNewDirection(int turn)
        {
            var newBearing = (Convert.ToInt32(CurrentCompassBearing) + turn);
            if (newBearing < 0) newBearing += 360;
            CurrentCompassBearing = (CompassBearing)(newBearing % 360);
        }
    }

}
