using System.Linq;
using Advent2019.Solutions;

namespace Advent2019.Utilities
{
    public class AdventConsoleRunner
    {
        public static void Main(string[] args)
        {
            var runner = new Day15 { InteractiveMode = true };
            runner.BuildMaze(FileReader.ReadFile("day15.txt").First());
        }
    }
}
