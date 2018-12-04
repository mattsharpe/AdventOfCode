using System;
using System.Linq;
using Advent2016.Solutions;
using Advent2016.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day13Fixture
    {
        private Day13 _day13;

        private const int FavouriteNumber = 1358;

        [TestInitialize]
        public void Setup()
        {
            _day13 = new Day13();
        }

        [DataTestMethod]
        [DataRow(0,0)]
        [DataRow(1,1)]
        [DataRow(2,1)]
        [DataRow(3,2)]
        [DataRow(4,1)]
        [DataRow(5,2)]
        [DataRow(6,2)]
        [DataRow(7,3)]
        [DataRow(8,1)]
        public void HammingWeight(int input, int result)
        {
            Assert.AreEqual(result, _day13.HammingWeight(input));
        }
        
        [TestMethod]
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

        [TestMethod]
        public void Print()
        {
            _day13.FavouriteNumber = 10;
            _day13.BuildMaze();
            _day13.Print();
        }

        [TestMethod]
        public void BuildMaze()
        {
            _day13.FavouriteNumber = 10;
            _day13.BuildMaze();
        }

        [TestMethod]
        public void Sample()
        {
            _day13.FavouriteNumber = 10;
            _day13.BuildMaze();
            var distance = _day13.MinimumDistanceTo(7, 4);
            
            Assert.AreEqual(11, distance);

            _day13.Print();
        }

        [TestMethod]
        public void Part1()
        {
            _day13.FavouriteNumber = 1358;
            _day13.BuildMaze();
            var distance = _day13.MinimumDistanceTo(31, 39);
            _day13.Print();
            Assert.AreEqual(96, distance);
        }

        [TestMethod]
        public void Part2()
        {
            _day13.BuildMaze();
            var result = _day13.ExploreAllPaths();
            Assert.AreEqual(141, result);
        }

        [TestMethod]
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
