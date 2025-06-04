using System;
using System.Collections.Generic;
using System.Linq;
using Advent2016.Utilities;

namespace Advent2016.Solutions
{
    /*
    --- Day 1: No Time for a Taxicab ---


    Santa's sleigh uses a very high-precision clock to guide its movements, and the clock's oscillator is regulated by stars. Unfortunately, the stars have been stolen... by the Easter Bunny. To save Christmas, Santa needs you to retrieve all fifty stars by December 25th.

    Collect stars by solving puzzles. Two puzzles will be made available on each day in the advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!

    You're airdropped near Easter Bunny Headquarters in a city somewhere. "Near", unfortunately, is as close as you can get - the instructions on the Easter Bunny Recruiting Document the Elves intercepted start here, and nobody had time to work them out further.

    The Document indicates that you should start at the given coordinates (where you just landed) and face North. Then, follow the provided sequence: either turn left (L) or right (R) 90 degrees, then walk forward the given number of blocks, ending at a new intersection.

    There's no time to follow such ridiculous instructions on foot, though, so you take a moment and work out the destination. Given that you can only walk on the street grid of the city, how far is the shortest path to the destination?

    For example:

    Following R2, L3 leaves you 2 blocks East and 3 blocks North, or 5 blocks away.
    R2, R2, R2 leaves you 2 blocks due South of your starting position, which is 2 blocks away.
    R5, L5, R5, R3 leaves you 12 blocks away.
    How many blocks away is Easter Bunny HQ?

    Your puzzle answer was 243.
      
--- Part Two ---

Then, you notice the instructions continue on the back of the Recruiting Document. Easter Bunny HQ is actually at the first location you visit twice.

For example, if your instructions are R8, R4, R4, R8, the first location you visit twice is 4 blocks away, due East.

How many blocks away is the first location you visit twice?

Your puzzle answer was 142.

        
          
    */
    public class Day01
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
