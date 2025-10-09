using Advent2017.Solutions;
using Advent2017.Utilities;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day23Fixture
    {
        private string[] _input = FileReader.ReadFile("day23.txt");

        private Day23 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day23();
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(9409, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(913, _day.Part2(_input));
        }
    }
}
