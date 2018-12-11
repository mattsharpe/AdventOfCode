using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day6Tests
    {
        private Day6 _day6;

        [TestInitialize]
        public void Setup()
        {
            _day6 = new Day6();
        }

        [TestMethod]
        public void SampleData()
        {
            var input = new []{
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9",
            };

            Assert.AreEqual(17, _day6.CalculateLargestNonInfiniteArea(input));
        }

        [TestMethod]
        public void LargestAreaPart1()
        {
            var input = FileReader.ReadFile("day6.txt");
            Assert.AreEqual(4060,  _day6.CalculateLargestNonInfiniteArea(input));
        }

        [TestMethod]
        public void SizeOfRegionWithAllLocations()
        {
            var input = FileReader.ReadFile("day6.txt");
            Assert.AreEqual(36136, _day6.Part2(input));
        }
    }
}
