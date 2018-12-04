using Advent2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day14Fixture
    {
        private Day14 _day14;

        [TestInitialize]
        public void Setup()
        {
            _day14 = new Day14();
        }

        [TestMethod]
        public void Unthreaded()
        {
            _day14.PopulateHashes();
        }

        [TestMethod]
        public void ThreeLetterMatch()
        {
            Assert.IsTrue(_day14.IsThreeLetterMatch("0034e0923cc38887a57bd7b1d4f953df"));
        }

        [TestMethod]
        public void IsNotThreeLetterMatch()
        {
            Assert.IsFalse(_day14.IsThreeLetterMatch("BadgerBadgerBadger"));
        }
        
        [TestMethod]
        public void Part1()
        {
            var result = _day14.Part1();
            Assert.AreEqual(15035, result);
        }

        [TestMethod, Ignore]
        public void Part2()
        {
            var result = _day14.Part2();
            Assert.AreEqual(19968, result);
        }

        [TestMethod]
        public void GetStretchedHash()
        {
            _day14.Salt = "abc";
            var hash = _day14.GetStretchedHash(0);
            Assert.AreEqual("a107ff634856bb300138cac6568c0f24", hash);
        }
    }
}
