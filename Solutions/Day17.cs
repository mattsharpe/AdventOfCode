using System;
using System.Collections.Generic;
using System.Linq;
using Advent2016.Utilities;

namespace Advent2016.Solutions
{
    /*
    --- Day 17: Two Steps Forward ---

You're trying to access a secure vault protected by a 4x4 grid of small rooms connected by doors. 
You start in the top-left room (marked S), and you can access the vault (marked V) once you reach the bottom-right room:

#########
#S| | | #
#-#-#-#-#
# | | | #
#-#-#-#-#
# | | | #
#-#-#-#-#
# | | |  
####### V
Fixed walls are marked with #, and doors are marked with - or |.

The doors in your current room are either open or closed (and locked) based on the hexadecimal MD5 hash of a passcode (your puzzle input) 
followed by a sequence of uppercase characters representing the path you have taken so far (U for up, D for down, L for left, and R for right).

Only the first four characters of the hash are used; they represent, respectively, the doors up, down, left, and right from your current position. 
Any b, c, d, e, or f means that the corresponding door is open; any other character (any number or a) means that the corresponding door is closed and locked.

To access the vault, all you need to do is reach the bottom-right room; reaching this room opens the vault and all doors in the maze.

For example, suppose the passcode is . Initially, you have taken no steps, and so your path is empty: you simply find the MD5 hash of hijkl alone. 
The first four characters of this hash are ced9, 
which indicate that up is open (c), 
down is open (e), 
left is open (d), 
and right is closed and locked (9). 
Because you start in the top-left corner, there are no "up" or "left" doors to be open, so your only choice is down.

Next, having gone only one step (down, or D), you find the hash of hijklD. This produces f2bc, which indicates that you can go back up, left (but that's a wall), or right. 
Going right means hashing hijklDR to get 5745 - all doors closed and locked. 
However, going up instead is worthwhile: even though it returns you to the room you started in, your path would then be DU, opening a different set of doors.

After going DU (and then hashing hijklDU to get 528e), only the right door is open; after going DUR, all doors lock. (Fortunately, your actual passcode is not hijkl).

Passcodes actually used by Easter Bunny Vault Security do allow access to the vault if you know the right path. For example:

If your passcode were ihgpwlah, the shortest path would be DDRRRD.
With kglvqrro, the shortest path would be DDUDRLRRUDRD.
With ulqzkmiv, the shortest would be DRURDRUDDLLDLUURRDULRLDUUDDDRR.
Given your vault's passcode, what is the shortest path (the actual path, not just the length) to reach the vault?

Your puzzle input is pxxbnzuo.


    */
    public class Day17
    {

        private Md5Hasher _hasher = new Md5Hasher();

        public IEnumerable<Day17MazeState> GetNextStates(Day17MazeState state)
        {
            if(state.Location.X == 3 && state.Location.Y == 3) yield break;
            //Console.WriteLine(state.Path);
            var hash = _hasher.Md5Hash(state.Path).ToLower();
            if (IsOpen(hash[0]) && state.Location.Y > 0) //Up
            {
                yield return new Day17MazeState(state, CompassBearing.North);
            }
            if (IsOpen(hash[1]) && state.Location.Y < 3) //Down
            {
                yield return new Day17MazeState(state, CompassBearing.South);
            }
            if (IsOpen(hash[2]) && state.Location.X > 0) //Left
            {
                yield return new Day17MazeState(state, CompassBearing.West);
            }
            if (IsOpen(hash[3]) && state.Location.X < 3) //Left
            {
                yield return new Day17MazeState(state, CompassBearing.East);
            }
            
        }

        public bool IsOpen(char x)
        {
            return x < 103 && x > 97;
        }

        public string Solve(string passcode)
        {
            var startState = new Day17MazeState {Location = new Location(0,0), Path = passcode };

            HashSet<Day17MazeState> toExplore = new HashSet<Day17MazeState> {startState};
            List<string> validRoutes = new List<string>();
            while (toExplore.Any())
            {
                toExplore =  new HashSet<Day17MazeState>(toExplore.SelectMany(GetNextStates));

                var success = toExplore.Where(x => x.Location.X == 3 && x.Location.Y == 3);
                if (success.Any())
                {
                    return success.OrderBy(x => x.Path.Length).First().Path.Remove(0, passcode.Length);
                }

            }
            return validRoutes.OrderBy(x => x.Length).First().Remove(0,passcode.Length);
        }

        public int SolvePart2(string passcode)
        {
            var startState = new Day17MazeState {Location = new Location(0,0), Path = passcode };

            HashSet<Day17MazeState> toExplore = new HashSet<Day17MazeState> {startState};
            List<string> validRoutes = new List<string>();
            
            while (toExplore.Any())
            {
               toExplore =  new HashSet<Day17MazeState>(toExplore.SelectMany(GetNextStates));

                var success = toExplore.Where(x => x.Location.X == 3 && x.Location.Y == 3);
                if (success.Any())
                {
                    validRoutes.AddRange(success.Where(x => x.Location.X == 3 && x.Location.Y == 3).Select(x=>x.Path));
                }

            }

            return validRoutes.OrderByDescending(x => x.Length).First().Remove(0,passcode.Length).Length;
        }
    }

    public class Day17MazeState
    {

        public Day17MazeState()
        {

        }

        protected bool Equals(Day17MazeState other)
        {
            return string.Equals(Path, other.Path) && Equals(Location, other.Location);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Day17MazeState) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Path != null ? Path.GetHashCode() : 0) * 397) ^ (Location != null ? Location.GetHashCode() : 0);
            }
        }

        public Day17MazeState(Day17MazeState state, CompassBearing direction)
        {
            Path = state.Path;
            Location = new Location(state.Location.X, state.Location.Y);

            Path = state.Path + GetNextPath(direction);

            if (direction == CompassBearing.North)
                Location.Y--;
            else if (direction == CompassBearing.East)
                Location.X++;
            else if (direction == CompassBearing.South)
                Location.Y++;
            else if (direction == CompassBearing.West)
                Location.X--;
        }

        private string GetNextPath(CompassBearing bearing)
        {
            switch (bearing)
            {
                    case CompassBearing.North:return "U";
                    case CompassBearing.East: return "R";
                    case CompassBearing.South: return "D";
                    case CompassBearing.West: return "L";
            }
            throw new Exception("Invalid enum passed in");
        }


        public string Path { get; set; }
        public Location Location { get; set; } = new Location(0,0);
    }
}
