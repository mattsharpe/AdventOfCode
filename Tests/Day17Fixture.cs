using System;
using System.Linq;
using AdventOfCode.Solutions;
using AdventOfCode.Utilities;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day17Fixture
    {
        private Day17 _day17;

        [SetUp]
        public void Setup()
        {
            _day17 = new Day17();
        }

        [Test]
        public void CharTest()
        {
            Assert.IsFalse(_day17.IsOpen('a'));
            Assert.IsTrue(_day17.IsOpen('b'));
            Assert.IsTrue(_day17.IsOpen('c'));
            Assert.IsTrue(_day17.IsOpen('d'));
            Assert.IsTrue(_day17.IsOpen('e'));
            Assert.IsTrue(_day17.IsOpen('f'));
            Assert.IsFalse(_day17.IsOpen('g'));
        }

        [Test]
        public void Sample1()
        {
            string result = _day17.Solve("ihgpwlah");
            Assert.AreEqual("DDRRRD", result);
        }

        [Test]
        public void Sample2()
        {
            string result = _day17.Solve("kglvqrro");
            Assert.AreEqual("DDUDRLRRUDRD", result);
        }

        [Test]
        public void Sample3()
        {
            string result = _day17.Solve("ulqzkmiv");
            Assert.AreEqual("DRURDRUDDLLDLUURRDULRLDUUDDDRR", result);
        }

        [Test]
        public void Part1()
        {
            string result = _day17.Solve("pxxbnzuo");
            Assert.AreEqual("RDULRDDRRD", result);
        }

        [Test]
        public void GetNextState()
        {
            var startState = new Day17MazeState {Location = new Location(0, 0), Path = "hijkl"};
            var states = _day17.GetNextStates(startState).ToArray();
            Assert.AreEqual(1, states.Length);
            var state = states.First();
            Assert.AreEqual("hijklD", state.Path);
            Assert.AreEqual(new Location(0,1), state.Location);
        }

        [Test]
        public void Part2()
        {
            int longestPath = _day17.SolvePart2("pxxbnzuo");
            Assert.AreEqual(752, longestPath);    
        }

        [Test]
        public void Part2_Sample1()
        {
            int longestPath = _day17.SolvePart2("ihgpwlah");
            Assert.AreEqual(370, longestPath);    
        }

        [Test]
        public void Part2_Sample2()
        {
            int longestPath = _day17.SolvePart2("kglvqrro");
            Assert.AreEqual(492, longestPath);    
        }

        [Test]
        public void Part2_Sample3()
        {
            int longestPath = _day17.SolvePart2("ulqzkmiv");
            Assert.AreEqual(830, longestPath);    
        }
        
    }
}
