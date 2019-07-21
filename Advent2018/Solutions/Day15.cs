using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2018.Solutions
{
    class Day15
    {
        private char[,] _map;
        private Dictionary<(int,int),Unit> _units = new Dictionary<(int,int),Unit>();
        public int Rounds { get; set; } = 0;

        public int TotalHitPoints
        {
            get { return _units.Sum(x => x.Value.HitPoints); }
        }

        public int Outcome => Rounds * TotalHitPoints;
        public bool GameOver { get; set; } = false;

        private readonly List<(int x, int y)> _potentialMoves = new List<(int x, int y)>
        {
            (0, -1), (-1, 0), (+1, 0), (0, +1)
        };

        public bool AreInRange(Unit a, Unit b)
        {
            //if there is only once square delta in any direction they're adjacent and in range
            return Math.Abs(a.Location.x - b.Location.x) + Math.Abs(a.Location.y - b.Location.y) == 1;
        }

        public void ParseInput(string[] input)
        {
            _map = new char[input[0].Length, input.Length];
            for (var y = 0; y < input.Length; y++)
            {
                var line = input[y];
                for (var x = 0; x < line.Length; x++)
                {
                    _map[x, y] = line[x];
                    if (line[x] == 'E' || line[x] == 'G')
                    {
                        _units.Add((x,y),new Unit
                        {
                            Location = (x, y),
                            Type = line[x] == 'E' ? UnitType.Elf : UnitType.Goblin
                        });
                        _map[x, y] = '.';
                    }
                }
            }
        }

        public void RunGameTurn()
        {
            var playOrder = _units.Values.Where(x => x.HitPoints > 0)
                .OrderBy(x => x.Location.y)
                .ThenBy(x => x.Location.x);

            foreach (var unit in playOrder.ToList())
            {
                ProcessTurnForUnit(unit);
            }
        }

        private void ProcessTurnForUnit(Unit unit)
        {
            //Console.WriteLine($"Processing turn for {unit} at {unit.Location.x},{unit.Location.y}");
            if (unit.HitPoints < 1) return;
            var enemies = _units.Values.Where(x => x.Type != unit.Type && x.HitPoints > 0).ToList();
            
            if (!enemies.Any())
            {
                GameOver = true;
            }
            //are there any enemies in range?
            var inRange = enemies.Where(enemy => AreInRange(enemy, unit)).ToList();

            if (inRange.Any())
                ProcessAttack(unit, inRange);
            else
            {
                //Console.WriteLine("Nothing in range - moving to target");
                var destinations = enemies.SelectMany(x => AdjacentOpenSquares(x.Location)).ToList();

                var moves = destinations.Select(x => ShortestPath(unit.Location, x))
                    .Where(x=>x.Any())
                    .OrderBy(x => x.Count)
                    .ThenBy(x=>x.First().y)
                    .ThenBy(x=>x.First().x)
                    .ToList();
                if (!moves.Any()) return;

                _units.Remove(unit.Location);
                unit.Location = moves.First().First();
                _units.Add(unit.Location, unit);

                inRange = enemies.Where(enemy => AreInRange(enemy, unit)).ToList();

                if (inRange.Any())
                    ProcessAttack(unit, inRange);
            }
        }

        public List<(int x,int y)> ShortestPath((int x, int y) start, (int x, int y) end)
        {
            var path = new Dictionary<(int currentX, int currentY), (int previousX, int previousY)>();

            var toExplore = new Queue<(int,int)>();
            toExplore.Enqueue(start);
            path.Add(start, (0,0));

            while (toExplore.Any())
            {
                var current = toExplore.Dequeue();
                foreach (var next in AdjacentOpenSquares(current).Where(x => !path.ContainsKey(x)))
                {
                    toExplore.Enqueue(next);
                    path.Add(next, current);
                }
            }

            var stack = new Stack<(int,int)>();
            (int, int) pathStep = end;
            
            //if we're blocked and can't reach the target
            if(!path.ContainsKey(end)) return new List<(int, int)>();

            while (pathStep != start)
            {
                stack.Push(pathStep);
                pathStep = path[pathStep];
            }

            return stack.ToList();
        }

        private void ProcessAttack(Unit attacker, List<Unit> enemies)
        {
            //Console.WriteLine($"found someone in range of {attacker}");
            var target = enemies.OrderBy(x => x.HitPoints)
                .ThenBy(x => x.Location.y)
                .ThenBy(x => x.Location.x)
                .First();

            target.HitPoints -= attacker.Power;
            if (target.HitPoints < 1)
                _units.Remove(target.Location);
        }

        /// <summary>
        /// Returns the coordinates of open squares around this location.
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        private List<(int x, int y)> AdjacentOpenSquares((int x, int y) start)
        {
            var result = new List<(int x, int y)>();
            void CheckSquare((int x, int y) location)
            {
                if (_map[location.x, location.y] == '.' && !_units.ContainsKey(location))
                {
                    result.Add(location);
                }
            }

            _potentialMoves.ForEach(transform => CheckSquare((start.x + transform.x, start.y + transform.y)));

            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"After {Rounds} rounds");
            for (var y = 0; y < _map.GetLength(1); y++)
            {
                for (var x = 0; x < _map.GetLength(0); x++)
                {
                    
                    if (_units.ContainsKey((x,y)))
                    {
                        sb.Append(_units[(x,y)].Type == UnitType.Goblin ? 'G' : 'E');
                    }
                    else
                    {
                        sb.Append(_map[x, y]);
                    }
                }

                sb.AppendLine("   " + string.Join(", ",_units.Values.Where(unit => unit.Location.y == y)
                    .OrderBy(unit => unit.Location.x)));
            }
            return sb.ToString();
        }

        public void RunGameToCompletion()
        {
            while (!GameOver)
            {
                RunGameTurn();
                if(!GameOver)
                    Rounds++;
            }
        }
    }

    class Unit
    {
        public int HitPoints { get; set; } = 200;
        public int Power { get; set; } = 3;
        public (int x, int y) Location { get; set; }
        public UnitType Type { get; set; }

        public override string ToString()
        {
            return $"{(Type == UnitType.Elf ? "E": "G")}({HitPoints})";
        }
    }

    public enum UnitType
    {
        Elf,
        Goblin
    }
}