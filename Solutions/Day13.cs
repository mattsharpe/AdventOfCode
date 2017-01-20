
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace AdventOfCode.Solutions
{
    /*
    --- Day 13: A Maze of Twisty Little Cubicles ---

    You arrive at the first floor of this new building to discover a much less welcoming environment than the shiny atrium of the last one. Instead, you are in a maze of twisty little cubicles, all alike.

    Every location in this area is addressed by a pair of non-negative integers (x,y). Each such coordinate is either a wall or an open space. You can't move diagonally. 
    The cube maze starts at 0,0 and seems to extend infinitely toward positive x and y; negative values are invalid, as they represent a location outside the building. You are in a small waiting area at 1,1.

    While it seems chaotic, a nearby morale-boosting poster explains, the layout is actually quite logical. You can determine whether a given x,y coordinate will be a wall or an open space using a simple system:

    Find x*x + 3*x + 2*x*y + y + y*y.
    Add the office designer's favorite number (your puzzle input).
    Find the binary representation of that sum; count the number of bits that are 1.
    If the number of bits that are 1 is even, it's an open space.
    If the number of bits that are 1 is odd, it's a wall.
    For example, if the office designer's favorite number were 10, drawing walls as # and open spaces as ., 
    the corner of the building containing 0,0 would look like this:

      0123456789
    0 .#.####.##
    1 ..#..#...#
    2 #....##...
    3 ###.#.###.
    4 .##..#..#.
    5 ..##....#.
    6 #...##.###
    Now, suppose you wanted to reach 7,4. The shortest route you could take is marked as O:

      0123456789
    0 .#.####.##
    1 .O#..#...#
    2 #OOO.##...
    3 ###O#.###.
    4 .##OO#OO#.
    5 ..##OOO.#.
    6 #...##.###
    Thus, reaching 7,4 would take a minimum of 11 steps (starting from your current location, 1,1).

    What is the fewest number of steps required for you to reach 31,39?

    Your puzzle input is 1358.

*/
    class Day13
    {
        private const int MaxSize = 50;
        public int FavouriteNumber { get; set; } = 1358;
        public bool CellIsOpen(int x, int y)
        {
            var code = x * x + 3 * x + 2 * x * y + y + y * y;
            code += FavouriteNumber;
            var bits = HammingWeight(code);
            var result =  bits % 2 == 0;
            //Console.WriteLine($"{x},{y} : {result}");
            return result;
        }

        //Absolutely no clue how this particular piece of black magic does its thing.
        public int HammingWeight(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }

        public void Print()
        {
            //Console.WriteLine("   " + string.Join(" ", Enumerable.Range(0, size)));

            for (var y = 0; y < MaxSize; y++)
            {
                //Console.Write(y + " ");
                for (var x = 0; x < MaxSize; x++)
                {
                    switch (Maze[x,y])
                    {
                        case MazeSquare.BestPath:
                            Console.Write("0 ");
                            break;
                        case MazeSquare.Open:
                            Console.Write(". ");
                            break;
                        case MazeSquare.Wall:
                            Console.Write("# ");
                            break;
                        case MazeSquare.Visited:
                            Console.Write("X ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public MazeSquare[,] Maze = new MazeSquare[MaxSize, MaxSize];

        public void BuildMaze()
        {
            
            for (int y = 0; y < MaxSize; y++)
            {
                for (int x = 0; x < MaxSize; x++)
                {
                    Maze[x, y] = CellIsOpen(x, y) ? MazeSquare.Open : MazeSquare.Wall;
                }
            }
        }

        public int MinimumDistanceTo(int destX, int destY)
        {
            var start = new MazeState(1,1,null);

            var toExplore = new HashSet<MazeState> {start};

            while(!toExplore.Any(square => square.X == destX && square.Y == destY))
            {
                toExplore = new HashSet<MazeState>(toExplore.SelectMany(GetNextStates));
                if (toExplore.Any(square => square.X == destX && square.Y == destY))
                {
                    var finalState = toExplore.Where(square => square.X == destX && square.Y == destY)
                            .OrderBy(x => x.Depth)
                            .First();

                    MazeState startState = finalState;
                    while(startState != null)
                    {
                        Maze[startState.X,startState.Y] = MazeSquare.BestPath;
                        startState = startState.PreviousStep;
                    }
                    return finalState.Depth;
                }
            }
            return 1;
        }

        public int ExploreAllPaths()
        {
            var start = new MazeState(1, 1, null);
            var toExplore = new HashSet<MazeState> { start };
            
            for (int i = 0; i < 51; i++) //51
            {
                toExplore = new HashSet<MazeState>(toExplore.SelectMany(GetNextStates));
            }

            foreach (var location in _visited)
            {
                Maze[location.X, location.Y] = MazeSquare.Visited;
            }
            Print();
            return _visited.Count;

        }

        private HashSet<MazeState> _visited = new HashSet<MazeState>();

        public List<MazeState> GetNextStates(MazeState currentSquare)
        {
            _visited.Add(currentSquare);
            var results = new []
            {
                new {X = 0, Y = -1},
                new {X = 1, Y = 0},
                new {X = 0, Y = 1},
                new {X = -1, Y = 0}
            };
        
            //0,1 & 1,2 should be open
            var states = new List<MazeState>();
            //North - if I'm greater than y - x is irrelevant
            if (currentSquare.Y > 0 && Maze[currentSquare.X, currentSquare.Y - 1] != MazeSquare.Wall)
            {
                states.Add(new MazeState(currentSquare.X, currentSquare.Y - 1, currentSquare));
            }
            if (currentSquare.X < MaxSize && Maze[currentSquare.X + 1, currentSquare.Y] != MazeSquare.Wall)
            {
                //east
                states.Add(new MazeState(currentSquare.X + 1, currentSquare.Y, currentSquare));
            }
            if (currentSquare.Y < MaxSize && Maze[currentSquare.X, currentSquare.Y + 1] != MazeSquare.Wall)
            {
                //south
                states.Add(new MazeState(currentSquare.X, currentSquare.Y + 1, currentSquare));
            }
            if (currentSquare.X > 0 && Maze[currentSquare.X - 1, currentSquare.Y] != MazeSquare.Wall)
            {
                //west
                states.Add(new MazeState(currentSquare.X - 1, currentSquare.Y, currentSquare));
            }
            return states;
        }
    
    }

    public enum MazeSquare
    {
        Wall,
        Open,
        Visited,
        BestPath
    }

    public class MazeState
    {
        public MazeState PreviousStep { get; set; }
        public MazeState(int x, int y, MazeState previous)
        {
            X = x;
            Y = y;
            Depth = previous?.Depth +1 ?? 0;
            PreviousStep = previous;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Depth { get; set; }

        protected bool Equals(MazeState other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MazeState) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString()
        {
            return X + "," + Y;
        }
    }
}
