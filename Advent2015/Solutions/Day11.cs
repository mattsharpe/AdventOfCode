using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2015.Solutions
{
    internal class Day11
    {
        private readonly Regex _invalidCharacters = new Regex("i|o|l");
        private readonly Regex _pairs = new Regex(@"(.)\1");

        public bool IsValid(string password)
        {
            if (_invalidCharacters.IsMatch(password)) 
                return false;

            var pairMatches = _pairs.Matches(password);
            
            if (pairMatches.Count != 2 || pairMatches.First().Value == pairMatches.Last().Value) 
                return false;

            var foundStraight = false;

            //increasing straight
            for (var i = 0; i < password.Length - 2; ++i)
                if ((password[i + 2] == password[i + 1] + 1) && (password[i + 1] == password[i] + 1))
                    foundStraight = true;

            return foundStraight;
        }

        public string NextPassword(string password)
        {
            var valid = IsValid(password);

            while (!IsValid(password))
            {
                password = GenerateNextPassword(password);
            }

            return password;
        }

        public string GenerateNextPassword(string password)
        {
            var working = password.Reverse().ToArray();
            var current = working[0];
            var invalidPrecursor = new[] {'h', 'n', 'k'};
            if (current < 'z' )
            {
                if (invalidPrecursor.Contains(current))
                {
                    working[0]++;
                }
                working[0]++;
            } 
            else if (current == 'z')
            {
                return GenerateNextPassword(new string(working.Skip(1).Reverse().ToArray())) + "a";
            }

            return new string(working.Reverse().ToArray());
        }
    }
}