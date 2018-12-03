using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day3Fixture
    {
        private Day3 _day3 = new Day3();

        [TestInitialize]
        public void Setup()
        {
            _day3 = new Day3();
        }

        [TestMethod]
        public void SampleData()
        {
            string input = ">";
            _day3.ProcessInstructions(input);
            var visited = _day3.Visited.Count;
            Assert.AreEqual(2, visited);
        }

        [TestMethod]
        public void SampleData_Square()
        {
            string input = "^>v<";
            _day3.ProcessInstructions(input);
            var visited = _day3.Visited.Count;
            Assert.AreEqual(4, visited);
        }

        [TestMethod]
        public void SampleData_Bouncing()
        {
            string input = "^v^v^v^v^v";
            _day3.ProcessInstructions(input);
            var visited = _day3.Visited.Count;
            Assert.AreEqual(2, visited);
        }

        [TestMethod]
        public void Part1()
        {
            var input = FileReader.ReadFile("day3.txt")[0];
            _day3.ProcessInstructions(input);

            var visited = _day3.Visited.Count;
            Assert.AreEqual(2572, visited);
        }

        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day3.txt")[0];
            _day3.ProcessInstructions(input, true);

            var visited = _day3.Visited.Count;
            Assert.AreEqual(2631, visited);
        }


        [TestMethod]
        public void SampleData_Part2()
        {
            string input = "^v";
            _day3.ProcessInstructions(input, true);
            var visited = _day3.Visited.Count;
            Assert.AreEqual(3, visited);
        }

        [TestMethod]
        public void SampleData_Square_Part2()
        {
            string input = "^>v<";
            _day3.ProcessInstructions(input, true);
            var visited = _day3.Visited.Count;
            Assert.AreEqual(3, visited);
        }

        [TestMethod]
        public void SampleData_Bouncing_Part2()
        {
            string input = "^v^v^v^v^v";
            _day3.ProcessInstructions(input, true);
            var visited = _day3.Visited.Count;
            Assert.AreEqual(11, visited);
        }
    }
}
