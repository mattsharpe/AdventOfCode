using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2018.Solutions
{
    class Day10
    {
        private bool[,] _output;
        public List<PointOfLight> Lights { get; set; }

        public void Parse(string[] sample)
        {
            var regex = new Regex(@"(-\d+|\d+)");
            //"position=<-3,  6> velocity=< 2, -1>"

            Lights = sample.Select(line =>
            {
                var matches = regex.Matches(line).Select(x=> Convert.ToInt32(x.Value)).ToArray();
                return new PointOfLight
                {
                    PositionX = matches[0],
                    PositionY = matches[1],
                    VelocityX = matches[2],
                    VelocityY = matches[3], 
                };
            }).ToList();
        }

        public int MinX => Lights.Min(x => x.PositionX);
        public int MaxX => Lights.Max(x => x.PositionX);

        public int MinY => Lights.Min(x => x.PositionY);
        public int MaxY => Lights.Max(x => x.PositionY);

        public int RangeOfX => MaxX + Math.Abs(MinX);
        public int RangeOfY => MaxY + Math.Abs(MinY);

        //draw the lights current positions
        public void Draw()
        {
            _output = new bool[RangeOfX + 2, RangeOfY + 2];

            foreach (var pointOfLight in Lights)
            {
                _output[pointOfLight.PositionX + Math.Abs(MinX), pointOfLight.PositionY + Math.Abs(MinY)] = true;
            }

            for (var y = 0; y < _output.GetUpperBound(1); y++)
            {
                for (var x = 0; x < _output.GetUpperBound(0); x++)
                {
                    Console.Write(_output[x, y] ? "#" : ".");
                }

                Console.WriteLine();
            }
        }

        public void Update()
        {
            foreach (var pointOfLight in Lights)
            {
                pointOfLight.PositionX += pointOfLight.VelocityX;
                pointOfLight.PositionY += pointOfLight.VelocityY;
            }
        }

        public bool HasResolved()
        {      
            //check that every point of light is adjacent to at least one other
            return Lights.All(x=> Lights.Any(y=> y.IsAdjacent(x)));
        }

        public int Solve()
        {
            int count = 0;
            while (!HasResolved())
            {
                Update();
                count++;
            }

            return count;
        }
    }

    public class PointOfLight
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int VelocityX { get; set; }
        public int VelocityY { get; set; }

        public bool IsAdjacent(PointOfLight other)
        {
            if (PositionX == other.PositionX - 1 && PositionY == other.PositionY + 1)
                return true;
            if (PositionX == other.PositionX && PositionY == other.PositionY + 1)
                return true;
            if (PositionX == other.PositionX + 1 && PositionY == other.PositionY + 1)
                return true;
            if (PositionX == other.PositionX + 1 && PositionY == other.PositionY)
                return true;
            if (PositionX == other.PositionX + 1 && PositionY == other.PositionY - 1)
                return true;
            if (PositionX == other.PositionX && PositionY == other.PositionY - 1)
                return true;
            if (PositionX == other.PositionX - 1 && PositionY == other.PositionY - 1)
                return true;
            if (PositionX == other.PositionX - 1 && PositionY == other.PositionY)
                return true;

            return false;
        }
    }
}
