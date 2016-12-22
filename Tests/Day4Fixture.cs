﻿using AdventOfCode.Solutions;
using AdventOfCode.Utilities;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    [TestFixture]
    public class Day4Fixture
    {
        private Day4 _day4;

        [SetUp]
        public void Setup()
        {
            _day4 = new Day4();
        }

        [Test]
        public void TestRoom_abxyz()
        {
            Assert.IsTrue(_day4.VerifyRoom(new Room("aaaaa-bbb-z-y-x-123[abxyz]")));
        }

        [Test]
        public void TestRoom_abcde()
        {
            Assert.IsTrue(_day4.VerifyRoom(new Room("a-b-c-d-e-f-g-h-987[abcde]")));
        }

        [Test]
        public void TestRoom_oarel()
        {
            Assert.IsTrue(_day4.VerifyRoom(new Room("not-a-real-room-404[oarel]")));
        }

        [Test]
        public void TestRoom_decoy()
        {
            Assert.IsFalse(_day4.VerifyRoom(new Room("totally-real-room-200[decoy]")));
        }

        [Test]
        public void SampleData()
        {
            var input = new [] {
                "aaaaa-bbb-z-y-x-123[abxyz]",
                "a-b-c-d-e-f-g-h-987[abcde]",
                "not-a-real-room-404[oarel]",
                "totally-real-room-200[decoy]"
            };

            int result = _day4.CalculateTotal(input);

            Assert.AreEqual(1514, result);
        }

        [Test]
        public void Part1()
        {
            var result = _day4.Part1();
            Assert.AreEqual(137896, result);
        }
    }
}
