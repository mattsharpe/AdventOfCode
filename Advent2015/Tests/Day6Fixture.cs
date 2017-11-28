using Advent2015.Solutions;
using Advent2015.Utilities;
using NUnit.Framework;

namespace Advent2015.Tests
{
    [TestFixture]
    class Day6Fixture
    {
        private Day6 _day6 = new Day6();

        [Test]
        public void Print()
        {
           // _day6.PrintLights();   
        }

        [Test]
        public void CountLit()
        {
            var lit = _day6.CountLit();
            Assert.AreEqual(0, lit);
        }

        [Test]
        public void TurnOnAll()
        {
            _day6.ProcessInstructions(new []{"turn on 0,0 through 999,999"});
            Assert.AreEqual(1000000, _day6.CountLit());
        }

        [Test]
        public void Toggle()
        {
            _day6.ProcessInstructions(new []{ "toggle 0,0 through 999,0" });
            Assert.AreEqual(1000, _day6.CountLit());

            _day6.ProcessInstructions(new[] { "toggle 0,0 through 999,0" });
            Assert.AreEqual(0, _day6.CountLit());
        }

        [Test]
        public void TurnOff()
        {
            _day6.ProcessInstructions(new []{ "turn on 0,0 through 999,999" });
            Assert.AreEqual(1000000, _day6.CountLit());

            _day6.ProcessInstructions(new[] { "turn off 499,499 through 500,500" });
            Assert.AreEqual(999996, _day6.CountLit());
        }

        [Test]
        public void Process()
        {
            _day6.ProcessInstructions(new []{ "turn off 994,939 through 998,988" });
            var lit = _day6.CountLit();
            Assert.AreEqual(0, lit);
        }

        [Test]
        public void Part1()
        {
            _day6.ProcessInstructions(FileReader.ReadFile("day6.txt"));
            Assert.AreEqual(543903, _day6.CountLit());
        }
        
    }
}
