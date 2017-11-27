using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2016.Utilities;

namespace AdventOfCode2016.Solutions
{
    class Day24
    {
        private char[,] _maze;
        private int _maxX;
        private int _maxY;

        public MazeState StartState { get; set; }
        public SortedDictionary<int, MazeState> Goals { get; set; } = new SortedDictionary<int, MazeState>();

        public void BuildMap(string[] input)
        {
            _maxY = input.Length;
            _maxX = input[0].Length;
            _maze = new char[_maxX,_maxY];

            for (int y = 0; y < _maxY; y++)
            {
                for( int x = 0; x < _maxX; x++)
                {
                    _maze[x, y] = input[y][x];

                    if (Int32.TryParse(_maze[x, y].ToString(), out int parsed))
                    {
                        Goals.Add(parsed, new MazeState(x, y, null));
                    }
                }
            }
            
        }

        public void PrintMap()
        {
            for (var y = 0; y <= _maze.GetUpperBound(1); y++)
            {
                for (var x = 0; x <= _maze.GetUpperBound(0); x++)
                {
                    Console.Write(_maze[x,y]);
                }
                Console.WriteLine();
            }
        }


        private HashSet<MazeState> _visited = new HashSet<MazeState>();

        public List<MazeState> GetNextStates(MazeState currentSquare)
        {
            _visited.Add(currentSquare);

            var states = new List<MazeState>();
            if (currentSquare.Y > 0 && _maze[currentSquare.X, currentSquare.Y - 1] != '#')
            {
                states.Add(new MazeState(currentSquare.X, currentSquare.Y - 1, currentSquare));
            }
            if (currentSquare.X < _maxX && _maze[currentSquare.X + 1, currentSquare.Y] != '#')
            {
                states.Add(new MazeState(currentSquare.X + 1, currentSquare.Y, currentSquare));
            }
            if (currentSquare.Y < _maxY && _maze[currentSquare.X, currentSquare.Y + 1] != '#')
            {
                states.Add(new MazeState(currentSquare.X, currentSquare.Y + 1, currentSquare));
            }
            if (currentSquare.X > 0 && _maze[currentSquare.X - 1, currentSquare.Y] != '#')
            {
                states.Add(new MazeState(currentSquare.X - 1, currentSquare.Y, currentSquare));
            }
            return states;
        }

        public int MinimumDistanceBetween(int startX, int startY, int destX, int destY)
        {
            if(startX == destX && startY == destY) return 0;
            var start = new MazeState(startX, startY, null);

            var toExplore = new HashSet<MazeState> { start };

            while (!toExplore.Any(square => square.X == destX && square.Y == destY))
            {
                toExplore = new HashSet<MazeState>(toExplore.SelectMany(GetNextStates));
                if (toExplore.Any(square => square.X == destX && square.Y == destY))
                {
                    var finalState = toExplore.Where(square => square.X == destX && square.Y == destY)
                        .OrderBy(x => x.Depth)
                        .First();

                    MazeState startState = finalState;
                    while (startState != null)
                    {
                        _maze[startState.X, startState.Y] = 'B';
                        startState = startState.PreviousStep;
                    }
                    return finalState.Depth;
                }
            }
            return 1;
        }

        private int[,] _shortestPaths;
        
        public void GetAllDistances(string[] input)
        {
            BuildMap(input);
            
            _shortestPaths = new int[Goals.Count, Goals.Count];

            foreach (var node in Goals)
            {
                foreach (var targetNode in Goals)
                {
                    if (_shortestPaths[node.Key, targetNode.Key] != 0) continue;
                    
                    var distance = MinimumDistanceBetween(node.Value.X, node.Value.Y, targetNode.Value.X, targetNode.Value.Y);
                    _shortestPaths[node.Key, targetNode.Key] = distance;
                    _shortestPaths[targetNode.Key, node.Key] = distance;
                }
            }
        }

        public void PrintShortest()
        {
            Console.WriteLine("\t" + string.Join("\t", Goals.Keys));
            var line = 0;
            for (var y = 0; y <= _shortestPaths.GetUpperBound(1); y++)
            {
                Console.Write(line++ + "\t");
                for (var x = 0; x <= _shortestPaths.GetUpperBound(0); x++)
                {
                    Console.Write(_shortestPaths[x, y] + "\t");
                }
                Console.WriteLine();
            }
        }

        public IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public int SolveForShortestPath(string[] input, int start, bool returnHome = false)
        {
            GetAllDistances(input);
            var nodes = Goals.Keys.ToList();

            var result = GetPermutations(nodes, nodes.Count).Where(x => x.First() == start).ToList();
            
            //Console.WriteLine($"Got {result.Count} paths");
            //result.ForEach(x =>
            //{
            //    Console.WriteLine(string.Join(",", x) + " = " + CalculatePathLength(x.ToList()));
            //});

            var shortestPath = result.Select(x =>
            {
                var list = x.ToList();
                if (returnHome)
                {
                    list.Add(start);
                }
                return CalculatePathLength(list);
            }).Min();

            return shortestPath;
        }

        public int CalculatePathLength(List<int> path)
        {
            int distance = 0;

            for (int i = 0; i != path.Count-1; i++)
            {
                distance += _shortestPaths[path[i], path[i + 1]];
                //Console.WriteLine($"calculating path from {path[i]} to {path[i+1]} = {_shortestPaths[path[i],path[i+1]]}" );
            }
            //Console.WriteLine("distance = " + distance);
            return distance;
        }
    }


}
