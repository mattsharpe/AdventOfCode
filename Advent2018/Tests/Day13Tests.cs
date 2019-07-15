using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day13Tests
    {
        private Day13 _day13;

        private string[] _sample =
        {
            @"/->-\        ",
            @"|   |  /----\",
            @"| /-+--+-\  |",
            @"| | |  | v  |",
            @"\-+-/  \-+--/",
            @"  \------/   "
        };

        private string[] _sample2 =
        {
            @"/>-<\  ",
            @"|   |  ",
            @"| /<+-\",
            @"| | | v",
            @"\>+</ |",
            @"  |   ^",
            @"  \<->/"
        };

        [TestInitialize]
        public void Setup()
        {
            _day13 = new Day13();
        }

        [TestMethod]
        public void Parse()
        {
            _day13.ParseInput(_sample);
            Assert.AreEqual(2, _day13.Carts.Count);
        }

        [TestMethod]
        public void Part1()
        {
            _day13.ParseInput(FileReader.ReadFile("day13.txt"));
            Assert.AreEqual(17, _day13.Carts.Count);
            Assert.AreEqual((48, 20), _day13.FindFirstCrash());
        }

        [TestMethod]
        public void FindFirstCrashSample()
        {
            _day13.ParseInput(_sample);
            Assert.AreEqual(2, _day13.Carts.Count);
            Assert.AreEqual((7, 3), _day13.FindFirstCrash());
        }

        [TestMethod]
        public void ProcessSample()
        {
            _day13.ParseInput(_sample);
            _day13.FindFirstCrash();
        }

        [TestMethod]
        public void ParseEnum()
        {
            Assert.AreEqual(Direction.North, (Direction) '^'); 
            Assert.AreEqual(Direction.East, (Direction) '>'); 
            Assert.AreEqual(Direction.South, (Direction) 'v'); 
            Assert.AreEqual(Direction.West, (Direction) '<'); 
        }

        [TestMethod]
        public void Part2Sample()
        {
            _day13.ParseInput(_sample2);
            Assert.AreEqual((6, 4), _day13.BattleRoyale());
        }

        [TestMethod]
        public void Part2()
        {
            _day13.ParseInput(FileReader.ReadFile("day13.txt"));
            Assert.AreEqual((59, 64), _day13.BattleRoyale());
        }
    }
}