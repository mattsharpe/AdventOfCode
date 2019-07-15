
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2018.Solutions
{
    class Day13
    {
        private char[,] _state;
        public List<Cart> Carts { get; set; } = new List<Cart>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < _state.GetLength(1); y++)
            {
                for (int x = 0; x < _state.GetLength(0); x++)
                {
                    var carts = Carts.Where(cart => cart.Location.x == x && cart.Location.y == y).ToList();
                    if (carts.Any())
                    {
                        if (carts.Count == 1)
                        {
                            sb.Append((char)carts.First().Direction);
                        }
                        else
                        {
                            sb.Append('X');
                        }
                        continue;
                    }
                    sb.Append(_state[x, y]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public void ParseInput(string[] input)
        {
            var validCarts = new[] { '^', 'v', '<', '>' };

            _state = new char[input[0].Length, input.Length];
            for (int y = 0; y < input.Length; y++)
            {
                for (var x = 0; x < input[y].Length; x++)
                {
                    var current = input[y][x];
                    _state[x, y] = current;
                    if (validCarts.Contains(current))
                    {
                        Carts.Add(new Cart
                        {
                            Direction = (Direction)current,
                            Location = (x, y)
                        });

                        if (current == '^' || current == 'v')
                            _state[x, y] = '|';
                        if (current == '<' || current == '>')
                            _state[x, y] = '-';
                    }
                }
            }
        }

        public (int x, int y) FindFirstCrash()
        {
            while (!Carts.Any(x => x.Crashed))
            {
                var sequence = Carts.OrderBy(cart => cart.Turn)
                    .ThenBy(cart => cart.Location.y)
                    .ThenBy(cart => cart.Location.x);

                foreach (var cart in sequence)
                {
                    ProcessTurn(cart);
                    Console.WriteLine();
                }
            }

            return Carts.First(x =>x.Crashed).Location; 
        }

        public void ProcessTurn(Cart cart)
        {
            var nextLocation = GetNextLocation(cart.Direction, cart.Location.x, cart.Location.y);
            var nextDirection = GetNextDirection(cart, nextLocation);
            cart.Turn++;
            
            var collision = Carts.SingleOrDefault(x => x.Location == nextLocation);
            if (collision != null)
            {
                cart.Crashed = true;
                collision.Crashed = true;
            }
            cart.Location = nextLocation;
            cart.Direction = nextDirection;
        }

        public (int x, int y) GetNextLocation(Direction direction, int x, int y)
        {
            switch (direction)
            {
                case Direction.North:
                    return (x, y - 1);
                case Direction.South:
                    return (x, y + 1);
                case Direction.East:
                    return (x + 1, y);
                case Direction.West:
                    return (x - 1, y);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        public Direction GetNextDirection(Cart cart, (int x, int y) nextLocation)
        {
            var turns = new Dictionary<(Direction dir, char gridSymbol), Direction>
            {
                { (Direction.North, '/'), Direction.East },
                { (Direction.East, '/'), Direction.North },
                { (Direction.South, '/'), Direction.West },
                { (Direction.West, '/'), Direction.South },

                { (Direction.North, '\\'), Direction.West },
                { (Direction.East, '\\'), Direction.South },
                { (Direction.South, '\\'), Direction.East },
                { (Direction.West, '\\'), Direction.North },
            };

            var nextCell = _state[nextLocation.x, nextLocation.y];
            if (nextCell == '\\' || nextCell == '/')
            {
                return turns[(cart.Direction, nextCell)];
            }

            var intersectionChoices = new Dictionary<(Direction, IntersectionChoice), Direction>
            {
                {(Direction.North, IntersectionChoice.Left), Direction.West},
                {(Direction.North, IntersectionChoice.Straight), Direction.North},
                {(Direction.North, IntersectionChoice.Right), Direction.East},

                {(Direction.East, IntersectionChoice.Left), Direction.North},
                {(Direction.East, IntersectionChoice.Straight), Direction.East},
                {(Direction.East, IntersectionChoice.Right), Direction.South},

                {(Direction.South, IntersectionChoice.Left), Direction.East},
                {(Direction.South, IntersectionChoice.Straight), Direction.South},
                {(Direction.South, IntersectionChoice.Right), Direction.West},

                {(Direction.West, IntersectionChoice.Left), Direction.South},
                {(Direction.West, IntersectionChoice.Straight), Direction.West},
                {(Direction.West, IntersectionChoice.Right), Direction.North},
            };

            if (nextCell == '+')
            {
                var result = intersectionChoices[(cart.Direction, cart.NextIntersectionChoice)];
                cart.NumberOfIntersections++;
                return result;
            }

            return cart.Direction;
        }

        /// <summary>
        /// Run the simulation removing all crashed carts as collisions occur until there is only one left.
        /// </summary>
        public (int,int) BattleRoyale()
        {
            while (Carts.Count > 1)
            {
                var sequence = Carts.OrderBy(cart => cart.Turn)
                    .ThenBy(cart => cart.Location.y)
                    .ThenBy(cart => cart.Location.x);

                foreach (var cart in sequence)
                {
                    ProcessTurn(cart);
                    Console.WriteLine();
                }
                
                Carts.RemoveAll(x => x.Crashed);
            }

            return Carts.Single().Location; 
        }
    }

    class Cart
    {
        public (int x, int y) Location { get; set; }
        public Direction Direction { get; set; }
        public bool Crashed { get; set; }
        public int Turn { get; set; } = 0;
        public int NumberOfIntersections { get; set; } = 0;

        public IntersectionChoice NextIntersectionChoice => 
            (IntersectionChoice) (NumberOfIntersections % 3);
    }

    internal enum Direction
    {
        North = '^',
        East = '>',
        South = 'v',
        West = '<'
    }

    internal enum IntersectionChoice
    {
        Left = 0,
        Straight = 1,
        Right = 2
    }
}
