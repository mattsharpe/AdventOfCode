using System;
using AdventOfCode.Solutions;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day14Fixture
    {
        private Day14 _day14;

        [SetUp]
        public void Setup()
        {
            _day14 = new Day14();
        }

        [Test]
        public void Unthreaded()
        {
            _day14.PopulateHashes();
        }

        [Test]
        public void ThreeLetterMatch()
        {
            Assert.That(_day14.IsThreeLetterMatch("0034e0923cc38887a57bd7b1d4f953df"));
        }

        [Test]
        public void IsNotThreeLetterMatch()
        {
            Assert.IsFalse(_day14.IsThreeLetterMatch("BadgerBadgerBadger"));
        }
        
        [Test]
        public void Part1()
        {
            var result = _day14.Part1();
            Assert.AreEqual(15035, result);
        }

        [Test]
        public void Part2()
        {
            var result = _day14.Part2();
            Assert.AreEqual(19968, result);
        }

        [Test]
        public void GetStretchedHash()
        {
            _day14.Salt = "abc";
            var hash = _day14.GetStretchedHash(0);
            Assert.AreEqual("a107ff634856bb300138cac6568c0f24", hash);
        }
    }
}
