using Advent2017.Solutions;
using Advent2017.Utilities;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    class Day11Fixture
    {
        private Day11 _day11 = new Day11();

        [TestCase("ne,ne,ne",3)]
        [TestCase("ne,ne,sw,sw", 0)]
        [TestCase("ne,ne,s,s", 2)]
        [TestCase("se,sw,se,sw,sw", 3)]
        public void Sample(string directions, int distance)
        {
            Assert.AreEqual(distance, _day11.Distance(directions));
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual(715, _day11.Distance(FileReader.ReadFile("day11.txt")[0]));
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual(1512, _day11.Distance(FileReader.ReadFile("day11.txt")[0], true));
        }
    }
}
