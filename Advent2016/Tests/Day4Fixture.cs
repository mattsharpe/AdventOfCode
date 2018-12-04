using Advent2016.Solutions;
using Advent2016.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{

    [TestClass]
    public class Day4Fixture
    {
        private Day4 _day4;

        [TestInitialize]
        public void Setup()
        {
            _day4 = new Day4();
        }

        [TestMethod]
        public void TestRoom_abxyz()
        {
            Assert.IsTrue(_day4.VerifyRoom(new Room("aaaaa-bbb-z-y-x-123[abxyz]")));
        }

        [TestMethod]
        public void TestRoom_abcde()
        {
            Assert.IsTrue(_day4.VerifyRoom(new Room("a-b-c-d-e-f-g-h-987[abcde]")));
        }

        [TestMethod]
        public void TestRoom_oarel()
        {
            Assert.IsTrue(_day4.VerifyRoom(new Room("not-a-real-room-404[oarel]")));
        }

        [TestMethod]
        public void TestRoom_decoy()
        {
            Assert.IsFalse(_day4.VerifyRoom(new Room("totally-real-room-200[decoy]")));
        }

        [TestMethod]
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

        [TestMethod]
        public void Part1()
        {
            var result = _day4.Part1();
            Assert.AreEqual(137896, result);
        }

        [TestMethod]
        public void ShiftCipher()
        {
            string input = "qzmt-zixmtkozy-ivhz";
            int shift = 343;
            string result = _day4.ShiftCipher(input, shift);

            Assert.AreEqual("very encrypted name", result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = _day4.Part2();
            Assert.AreEqual(501,result);
        }
    }
}
