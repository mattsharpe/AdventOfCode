using System.Linq;

namespace Advent2015.Solutions
{
    class Day1
    {
        public int ParseInput(string input)
        {
            int start = 0;
            start += input.Count(x => x == '(');
            start -= input.Count(x => x == ')');
            return start;
        }

        public int FindBasement(string input)
        {
            var floor = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var instruction = input[i];
                switch (instruction)
                {
                    case '(':
                        floor++;
                        break;
                    case ')':
                        floor--;
                        break;
                }

                if (floor == -1) return i+1;
            }

            return 0;
        }
    }
}
