using Advent2017.Solutions;
using Advent2017.Utilities;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day21Fixture
    {
        private readonly string[] _sample = [
            "../.# => ##./#../...",
            ".#./..#/### => #..#/..../..../#..#"
        ];

        private string[] _input = FileReader.ReadFile("day21.txt");

        private Day21 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new();
        }

        [TestMethod]
        public void Part1Sample()
        {
            // After 2 iterations, should have 12 pixels on
            Assert.AreEqual(12, _day.Part1(_sample, 2));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(171, _day.Part1(_input, 5));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(2498142, _day.Part2(_input, 18));
        }
    }
}
