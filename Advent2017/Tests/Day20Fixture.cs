using Advent2017.Solutions;
using Advent2017.Utilities;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day20Fixture
    {
        private readonly string[] _sample = [
            "p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>",
            "p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>",
        ];

        private readonly string[] _sample2 = [
            "p=<-6,0,0>, v=< 3,0,0>, a=< 0,0,0>",
            "p=<-4,0,0>, v=< 2,0,0>, a=< 0,0,0>",
            "p=<-2,0,0>, v=< 1,0,0>, a=< 0,0,0>",
            "p=< 3,0,0>, v=<-1,0,0>, a=< 0,0,0>",
        ];

        private string[] _input = FileReader.ReadFile("day20.txt");

        private Day20 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day20();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(0, _day.Part1(_sample));
        }
        
        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(91, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(1, _day.Part2(_sample2));
        }
        
        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(567, _day.Part2(_input));
        }
    }
}
