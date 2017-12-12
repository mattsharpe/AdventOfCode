using System.Linq;
using Advent2017.Solutions;
using Advent2017.Utilities;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    class Day8Fixture
    {
        private Day8 _day8 = new Day8();

        private string[] _sample =
        {
            "b inc 5 if a > 1",
            "a inc 1 if b < 5",
            "c dec -10 if a >= 1",
            "c inc -20 if c == 10"
        };

        [SetUp]
        public void Setup()
        {
            _day8 = new Day8();
        }

        [Test]
        public void Sample()
        {
            _day8.ProcessInstructions(_sample);
            Assert.AreEqual(1,_day8.Registers.Max(x=>x.Value));
        }
        
        [Test]
        public void Part1()
        {
            _day8.ProcessInstructions(FileReader.ReadFile("day8.txt"));
            Assert.AreEqual(7787, _day8.Registers.Max(x => x.Value));
        }
        
        [Test]
        public void Part2_Sample()
        {
            _day8.ProcessInstructions(_sample);
            Assert.AreEqual(10, _day8.HighWaterMark);
        }
        
        [Test]
        public void Part2()
        {
            _day8.ProcessInstructions(FileReader.ReadFile("day8.txt"));
            Assert.AreEqual(8997, _day8.HighWaterMark);
        }
    }
}