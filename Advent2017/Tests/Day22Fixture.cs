using Advent2017.Solutions;
using Advent2017.Utilities;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day22Fixture
    {
        private readonly string[] _sample = [
            "..#",
            "#..",
            "..."
        ];

        private string[] _input = FileReader.ReadFile("day22.txt");

        private Day22 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day22();
        }

        [TestMethod]
        public void Part1Sample70()
        {
            Assert.AreEqual(41, _day.Part1(_sample, 70));
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(5587, _day.Part1(_sample, 10000));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(5256, _day.Part1(_input, 10000));
        }

        [TestMethod]
        public void Part2Sample100()
        {
            Assert.AreEqual(26, _day.Part2(_sample, 100));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(2511944, _day.Part2(_sample, 10000000));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(2511345, _day.Part2(_input, 10000000));
        }
    }
}
