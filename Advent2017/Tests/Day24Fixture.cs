using Advent2017.Solutions;
using Advent2017.Utilities;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day24Fixture
    {
        private readonly string[] _sample = [
            "0/2",
            "2/2",
            "2/3",
            "3/4",
            "3/5",
            "0/1",
            "10/1",
            "9/10"
        ];

        private string[] _input = FileReader.ReadFile("day24.txt");

        private Day24 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day24();
        }

        [TestMethod]
        public void Part1Sample()
        {
            // Strongest bridge: 0/1--10/1--9/10 = 31
            Assert.AreEqual(31, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(1656, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(19, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(1642, _day.Part2(_input));
        }
    }
}
