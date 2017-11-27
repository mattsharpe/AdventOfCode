using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2016.Solutions;
using AdventOfCode2016.Utilities;
using NUnit.Framework;

namespace AdventOfCode2016.Tests
{
    [TestFixture]
    class Day13Fixture
    {
        private Day13 _day13;

        private const int FavouriteNumber = 1358;

        [SetUp]
        public void Setup()
        {
            _day13 = new Day13();
        }

        [Test, TestCaseSource(nameof(HammingWeights))]
        public void HammingWeight(int input, int result)
        {
            Assert.AreEqual(result, _day13.HammingWeight(input));
        }

        public static IEnumerable<TestCaseData> HammingWeights()
        {
            yield return new TestCaseData(0,0);
            yield return new TestCaseData(1,1);
            yield return new TestCaseData(2,1);
            yield return new TestCaseData(3,2);
            yield return new TestCaseData(4,1);
            yield return new TestCaseData(5,2);
            yield return new TestCaseData(6,2);
            yield return new TestCaseData(7,3);
            yield return new TestCaseData(8,1);
        }

        [Test]
        public void WallOrOpen()
        {
            _day13.FavouriteNumber = 10;
            Assert.IsTrue(_day13.CellIsOpen(0,0));
            Assert.IsFalse(_day13.CellIsOpen(1,0));
            Assert.IsTrue(_day13.CellIsOpen(2, 0));
            Assert.IsFalse(_day13.CellIsOpen(3, 0));
            Assert.IsFalse(_day13.CellIsOpen(4, 0));
            Assert.IsFalse(_day13.CellIsOpen(5, 0));
            Assert.IsFalse(_day13.CellIsOpen(6, 0));
            Assert.IsTrue(_day13.CellIsOpen(7, 0));
            Assert.IsFalse(_day13.CellIsOpen(8, 0));
            Assert.IsFalse(_day13.CellIsOpen(9, 0));
            
        }

        [Test]
        public void Print()
        {
            _day13.FavouriteNumber = 10;
            _day13.BuildMaze();
            _day13.Print();
        }

        [Test]
        public void BuildMaze()
        {
            _day13.FavouriteNumber = 10;
            _day13.BuildMaze();
        }

        [Test]
        public void Sample()
        {
            _day13.FavouriteNumber = 10;
            _day13.BuildMaze();
            var distance = _day13.MinimumDistanceTo(7, 4);
            
            Assert.AreEqual(11, distance);

            _day13.Print();
        }

        [Test]
        public void Part1()
        {
            _day13.FavouriteNumber = 1358;
            _day13.BuildMaze();
            var distance = _day13.MinimumDistanceTo(31, 39);
            _day13.Print();
            Assert.AreEqual(96, distance);
        }

        [Test]
        public void Part2()
        {
            _day13.BuildMaze();
            var result = _day13.ExploreAllPaths();
            Assert.AreEqual(141, result);
        }

        [Test]
        public void NextStates()
        {
            _day13.FavouriteNumber = 10;
            _day13.BuildMaze();
            var states = _day13.GetNextStates(new MazeState(1, 1, null));

            foreach(var state in states)
            {
                Console.WriteLine(state.X + " " + state.Y);
            }
            Assert.AreEqual(2,states.Count());

        }
    }
}
