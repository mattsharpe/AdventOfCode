using Advent2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day18Fixture
    {
        private Day18 _day18;
        //.^^^.^.^^^.^.......^^.^^^^.^^^^..^^^^^.^.^^^..^^.^.^^..^.^..^^...^.^^.^^^...^^.^.^^^..^^^^.....^....

        [TestInitialize]
        public void Setup()
        {
            _day18 = new Day18();
        }

        [TestMethod]
        public void IsTrap()
        {
            //Its left and center tiles are traps, but its right tile is not.
            Assert.IsTrue(_day18.IsTrap("^", "^", "."));

            //Its center and right tiles are traps, but its left tile is not.
            Assert.IsTrue(_day18.IsTrap(".", "^", "^"));

            // Only its left tile is a trap.
            Assert.IsTrue(_day18.IsTrap("^", ".", "."));

            // Only its left tile is a trap.
            Assert.IsTrue(_day18.IsTrap(".", ".", "^"));

            
            Assert.IsFalse(_day18.IsTrap(".", ".", "."));
            Assert.IsFalse(_day18.IsTrap(".", "^", "."));
            Assert.IsFalse(_day18.IsTrap("^", "^", "^"));
        }

        [TestMethod]
        public void Sample1()
        {
            _day18.Process("..^^.", 3);
            _day18.Print();
            var result = _day18.CountSafe();

            Assert.AreEqual(6,result);
        }

        [TestMethod]
        public void Sample2()
        {
            _day18.Process(".^^.^.^^^^", 10);
            _day18.Print();
            var result = _day18.CountSafe();

            Assert.AreEqual(38,result);
        }

        [TestMethod]
        public void Part1()
        {
            _day18.Process(".^^^.^.^^^.^.......^^.^^^^.^^^^..^^^^^.^.^^^..^^.^.^^..^.^..^^...^.^^.^^^...^^.^.^^^..^^^^.....^....", 40);
            var result = _day18.CountSafe();

            Assert.AreEqual(2013, result); //too low
        }

        [TestMethod]
        public void Part2()
        {
            _day18.Process(".^^^.^.^^^.^.......^^.^^^^.^^^^..^^^^^.^.^^^..^^.^.^^..^.^..^^...^.^^.^^^...^^.^.^^^..^^^^.....^....", 400000);
            //_day18.Print();
            long result = _day18.CountSafe();

            Assert.AreEqual(20006289, result); //too low
        }
    }
}
