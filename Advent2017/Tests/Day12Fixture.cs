using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day12Fixture
    {
        private Day12 _day12 = new Day12();

        private string[] _sample =
        {
            "0 <-> 2",
            "1 <-> 1",
            "2 <-> 0, 3, 4",
            "3 <-> 2, 4",
            "4 <-> 2, 3, 6",
            "5 <-> 6",
            "6 <-> 4, 5"
        };

        [TestMethod]
        public void Sample()
        {
            _day12.Process(_sample);
           Assert.AreEqual(6, _day12.Paths[0].Count);
        }

        [TestMethod]
        public void Part1()
        {
            _day12.Process(FileReader.ReadFile("day12.txt"));
            Assert.AreEqual(128, _day12.Paths[0].Count);
        }

        [TestMethod]
        public void Part2_Sample()
        {
            _day12.Process(_sample); 
            Assert.AreEqual(2, _day12.CountGroups());
        }

        [TestMethod]
        public void Part2()
        {
            _day12.Process(FileReader.ReadFile("day12.txt")); 
            Assert.AreEqual(209, _day12.CountGroups());
        }
    }
}
