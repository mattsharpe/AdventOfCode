using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day06Fixture
    {
        private Day06 _day6 = new Day06();

        [TestInitialize]
        public void Setup()
        {
            _day6 = new Day06();
        }

        [TestMethod]
        public void CountLit()
        {
            var lit = _day6.CountLit();
            Assert.AreEqual(0, lit);
        }

        [TestMethod]
        public void TurnOnAll()
        {
            _day6.ProcessInstructions(new []{"turn on 0,0 through 999,999"});
            Assert.AreEqual(1000000, _day6.CountLit());
        }

        [TestMethod]
        public void Toggle()
        {
            _day6.ProcessInstructions(new []{ "toggle 0,0 through 999,0" });
            Assert.AreEqual(1000, _day6.CountLit());

            _day6.ProcessInstructions(new[] { "toggle 0,0 through 999,0" });
            Assert.AreEqual(0, _day6.CountLit());
        }

        [TestMethod]
        public void TurnOff()
        {
            _day6.ProcessInstructions(new []{ "turn on 0,0 through 999,999" });
            Assert.AreEqual(1000000, _day6.CountLit());

            _day6.ProcessInstructions(new[] { "turn off 499,499 through 500,500" });
            Assert.AreEqual(999996, _day6.CountLit());
        }

        [TestMethod]
        public void Process()
        {
            _day6.ProcessInstructions(new []{ "turn off 994,939 through 998,988" });
            var lit = _day6.CountLit();
            Assert.AreEqual(0, lit);
        }

        [TestMethod]
        public void Part1()
        {
            _day6.ProcessInstructions(FileReader.ReadFile("day06.txt"));
            Assert.AreEqual(543903, _day6.CountLit());
        }

        [TestMethod]
        public void Part2()
        {
            _day6.ProcessInstructions(FileReader.ReadFile("day06.txt"), true);
            Assert.AreEqual(14687245, _day6.SumLights());
        }

        [TestMethod]
        public void TurnOnPart2()
        {
            _day6.ProcessInstructions(new []{ "turn on 0,0 through 0,0" }, true);
            Assert.AreEqual(1,_day6.SumLights());
        }

        [TestMethod]
        public void TogglePart2()
        {
            _day6.ProcessInstructions(new []{ "toggle 0,0 through 999,999" }, true);
            Assert.AreEqual(2000000,_day6.SumLights());
        }
        
    }
}
