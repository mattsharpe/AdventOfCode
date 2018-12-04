using Advent2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day6Fixture
    {
        private Day6 _day6;

        [TestInitialize]
        public void Setup()
        {
            _day6 = new Day6();
        }

        [TestMethod]
        public void SampleData1()
        {
            var input = new []
            {
                "eedadn",
                "drvtee",
                "eandsr",
                "raavrd",
                "atevrs",
                "tsrnev",
                "sdttsa",
                "rasrtv",
                "nssdts",
                "ntnada",
                "svetve",
                "tesnvt",
                "vntsnd",
                "vrdear",
                "dvrsen",
                "enarar"
            };

            var result = _day6.ErrorCorrect(input);
            Assert.AreEqual("easter", result);
        }

        [TestMethod]
        public void Task1()
        {
            var result  = _day6.Challenge1();
            Assert.AreEqual("ursvoerv", result);
        }

        [TestMethod]
        public void Task2()
        {
            var result  = _day6.Challenge2();
            Assert.AreEqual("vomaypnn", result);
        }
    }
}
