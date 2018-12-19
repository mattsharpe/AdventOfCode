using System;
using System.Linq;
using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day10Tests
    {
        private Day10 _day10;

        [TestInitialize]
        public void Setup()
        {
            _day10 = new Day10();
        }

        private string[] _sample = new[]
        {
            "position=< 9,  1> velocity=< 0,  2>",
            "position=< 7,  0> velocity=<-1,  0>",
            "position=< 3, -2> velocity=<-1,  1>",
            "position=< 6, 10> velocity=<-2, -1>",
            "position=< 2, -4> velocity=< 2,  2>",
            "position=<-6, 10> velocity=< 2, -2>",
            "position=< 1,  8> velocity=< 1, -1>",
            "position=< 1,  7> velocity=< 1,  0>",
            "position=<-3, 11> velocity=< 1, -2>",
            "position=< 7,  6> velocity=<-1, -1>",
            "position=<-2,  3> velocity=< 1,  0>",
            "position=<-4,  3> velocity=< 2,  0>",
            "position=<10, -3> velocity=<-1,  1>",
            "position=< 5, 11> velocity=< 1, -2>",
            "position=< 4,  7> velocity=< 0, -1>",
            "position=< 8, -2> velocity=< 0,  1>",
            "position=<15,  0> velocity=<-2,  0>",
            "position=< 1,  6> velocity=< 1,  0>",
            "position=< 8,  9> velocity=< 0, -1>",
            "position=< 3,  3> velocity=<-1,  1>",
            "position=< 0,  5> velocity=< 0, -1>",
            "position=<-2,  2> velocity=< 2,  0>",
            "position=< 5, -2> velocity=< 1,  2>",
            "position=< 1,  4> velocity=< 2,  1>",
            "position=<-2,  7> velocity=< 2, -2>",
            "position=< 3,  6> velocity=<-1, -1>",
            "position=< 5,  0> velocity=< 1,  0>",
            "position=<-6,  0> velocity=< 2,  0>",
            "position=< 5,  9> velocity=< 1, -2>",
            "position=<14,  7> velocity=<-2,  0>",
            "position=<-3,  6> velocity=< 2, -1>"
        };



        [TestMethod]
        public void ParseInput()
        {
            _day10.Parse(new[] {"position=<-3,  6> velocity=< 2, -1>"});
            var result = _day10.Lights.First();
            Assert.AreEqual(-3, result.PositionX);
            Assert.AreEqual(6, result.PositionY);
            Assert.AreEqual(2, result.VelocityX);
            Assert.AreEqual(-1, result.VelocityY);

            _day10.Update();

            var updated = _day10.Lights.First();

            Assert.AreEqual(-1, updated.PositionX);
            Assert.AreEqual(5, updated.PositionY);
            Assert.AreEqual(2, updated.VelocityX);
            Assert.AreEqual(-1, updated.VelocityY);
        }
        
        [TestMethod]
        public void HasResolved()
        {
            _day10.Parse(_sample);

            Assert.IsFalse(_day10.HasResolved());

            Enumerable.Range(0,3).ForEach(x=> _day10.Update());
            _day10.Draw();

            Assert.IsTrue(_day10.HasResolved());
        }

        [TestMethod]
        public void Part1()
        {
            _day10.Parse(FileReader.ReadFile("day10.txt"));
        }

        [TestMethod]
        public void SolveSample()
        {
            _day10.Parse(_sample);
            _day10.Solve();
            _day10.Draw();
        }

        [TestMethod]
        public void SolvePart1()
        {
            _day10.Parse(FileReader.ReadFile("day10.txt"));
            _day10.Solve();
            _day10.Draw();
        }

        [TestMethod]
        public void CountStepsSample()
        {
            _day10.Parse(_sample);
            Assert.AreEqual(3,_day10.Solve());
        }

        [TestMethod]
        public void CountSteps()
        {
            _day10.Parse(FileReader.ReadFile("day10.txt"));
            Assert.AreEqual(10009,_day10.Solve());
        }

        [TestMethod]
        public void HasResolved10009()
        {
            _day10.Parse(FileReader.ReadFile("day10.txt"));

            Assert.IsFalse(_day10.HasResolved());

            Enumerable.Range(0, 10009).ForEach(x => _day10.Update());
            _day10.Draw();

            Assert.IsTrue(_day10.HasResolved());
        }
    }
}
