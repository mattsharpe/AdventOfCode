using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Advent2018.Solutions
{
    public class Day03
    {
        private int[,] _fabric = new int[1000,1000];
        private IEnumerable<Claim> _claims = new List<Claim>();

        public void ProcessInstructions(string[] input)
        {
            var claims = GetClaimsFromFile(input);
            _claims = claims;
            ProcessClaims(claims);
            //Print();
        }

        public void ProcessClaims(IEnumerable<Claim> claims)
        {
            foreach (var claim in claims)
            {
                ProcessClaim(claim, (x,y) => _fabric[x,y]++);
            }
        }

        public void ProcessClaim(Claim claim, Action<int,int> action)
        {
            for(var y = claim.Top; y < claim.Top + claim.Height; y++)
            {
                for (var x = claim.Left; x < claim.Left + claim.Width; x++)
                {
                    action(x, y);
                }
            }
        }

        public bool VerifyClaim(Claim claim)
        {
            var collisions = false;
            ProcessClaim(claim, (x, y) =>
            {
                if (_fabric[x, y] > 1)
                    collisions = true;
            });
            return !collisions;
        }

        public Claim FindClaimThatDoesntOverlap()
        {
            return _claims.Single(VerifyClaim);
        }

        public int CountOverlappingSquares()
        {
            return _fabric.Cast<int>().Count(square => square > 1);
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < _fabric.GetLength(1); y++)
            {
                for (int x = 0; x < _fabric.GetLength(0); x++)
                {
                    sb.Append(_fabric[x, y]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public IEnumerable<Claim> GetClaimsFromFile(string[] input)
        {
            Regex regex = new Regex(@"#(\d*) @ (\d*),(\d*): (\d*)x(\d*)");

            foreach (var line in input)
            {
                var match = regex.Match(line);
                yield return new Claim
                {
                    Id = Convert.ToInt32(match.Groups[1].Value),
                    Left = Convert.ToInt32(match.Groups[2].Value),
                    Top = Convert.ToInt32(match.Groups[3].Value),
                    Width = Convert.ToInt32(match.Groups[4].Value),
                    Height= Convert.ToInt32(match.Groups[5].Value),
                };
            }
        }
    }

    public struct Claim
    {
        public int Id { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
