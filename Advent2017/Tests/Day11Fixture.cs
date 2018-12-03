using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day11Fixture
    {
        private Day11 _day11 = new Day11();

        [DataRow("ne,ne,ne",3)]
        [DataRow("ne,ne,sw,sw", 0)]
        [DataRow("ne,ne,s,s", 2)]
        [DataRow("se,sw,se,sw,sw", 3)]
        [DataTestMethod]
        public void Sample(string directions, int distance)
        {
            Assert.AreEqual(distance, _day11.Distance(directions));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(715, _day11.Distance(FileReader.ReadFile("day11.txt")[0]));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(1512, _day11.Distance(FileReader.ReadFile("day11.txt")[0], true));
        }
    }
}
