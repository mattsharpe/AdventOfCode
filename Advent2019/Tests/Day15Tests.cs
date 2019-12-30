using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass, TestCategory("IntCode")]
    public class Day15Tests
    {
        private Day15 _day15;

        [TestInitialize]
        public void Initialize() => _day15 = new Day15();

        [TestMethod]
        public void BuildMaze()
        {
            var input = FileReader.ReadFile("day15.txt").First();
            //475 is too high
            _day15.BuildMaze(input);
        }

        [TestMethod]
        public void ShortestPath()
        {
            var input = FileReader.ReadFile("day15.txt").First();
            _day15.BuildMaze(input);
            Assert.AreEqual(1, _day15.FindPathToOxygen());
        }
    }
}
