using Advent2017.Solutions;
using Advent2017.Utilities;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day19Fixture
    {
        private readonly string[] _sample = [
            "     |          ",
            "     |  +--+    ",
            "     A  |  C    ",
            " F---|----E|--+ ",
            "     |  |  |  D ",
            "     +B-+  +--+ "
        ];


        private string[] _input = FileReader.ReadFile("day19.txt");

        private Day19 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day19();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual("ABCDEF", _day.Part1(_sample));
        }
        
        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual("MOABEUCWQS", _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(38, _day.Part2(_sample));
        }
        
        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(18058, _day.Part2(_input));
        }
    }
}
