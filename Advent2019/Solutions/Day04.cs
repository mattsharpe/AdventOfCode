using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2019.Solutions
{
    class Day04
    {
        public bool IsValid(int password)
        {
            return HasRepeatedDigit(password) &&
                   DigitsDontDecrease(password);
        }

        //(\d) - capturing group, \1 repeats the first captured group
        private readonly Regex _repeatingDigit = new Regex(@"(\d)\1");

        //two capturing groups, the inner digit (\d)followed by one or more.
        private readonly Regex _adjacentDigits = new Regex(@"((\d)\2+)");

        public bool HasRepeatedDigit(int password)
        {
            return _repeatingDigit.IsMatch(password.ToString());
        }

        public bool DigitsDontDecrease(int password)
        {
            var ordered = password.ToString().OrderBy(x => x);
            return Convert.ToInt32(string.Join("",ordered)) == password;
        }

        public bool TwoAdjacentDigitsNotPartOfLargerGroup(int password)
        {
            var matches = _adjacentDigits.Matches(password.ToString());
            return matches.ToArray().Any(x => x.Value.Length == 2);
        }

        public int PasswordsInRange(int min, int max, bool advancedFilter = false)
        {
            var result =  Enumerable.Range(min, max - min)
                .Where(HasRepeatedDigit)
                .Where(DigitsDontDecrease);

                if(advancedFilter)
                    result = result.Where(TwoAdjacentDigitsNotPartOfLargerGroup);
                
                return result.Count();
        }
    }
}
