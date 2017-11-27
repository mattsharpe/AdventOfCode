using Advent2015.Solutions;
using Advent2015.Utilities;
using NUnit.Framework;

namespace Advent2015.Tests
{
    [TestFixture]
    class Day3Fixture
    {
        private Day3 _day3 = new Day3();

        [SetUp]
        public void Setup()
        {
            _day3 = new Day3();
        }

        [Test]
        public void SampleData()
        {
            string input = ">";
            _day3.ProcessInstructions(input);
            var visited = _day3.Visited.Count;
            Assert.AreEqual(2, visited);
        }

        [Test]
        public void SampleData_Square()
        {
            string input = "^>v<";
            _day3.ProcessInstructions(input);
            var visited = _day3.Visited.Count;
            Assert.AreEqual(4, visited);
        }

        [Test]
        public void SampleData_Bouncing()
        {
            string input = "^v^v^v^v^v";
            _day3.ProcessInstructions(input);
            var visited = _day3.Visited.Count;
            Assert.AreEqual(2, visited);
        }

        [Test]
        public void Part1()
        {
            var input = FileReader.ReadFile("day3.txt")[0];
            _day3.ProcessInstructions(input);

            var visited = _day3.Visited.Count;
            Assert.AreEqual(2572, visited);
        }
    }
}
