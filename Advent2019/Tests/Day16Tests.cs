using System;
using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day16Tests
    {
        private Day16 _day16;

        [TestInitialize]
        public void Initialize() => _day16 = new Day16();

        [DataTestMethod]
        [DataRow("12345678", 1, "48226158")]
        [DataRow("12345678", 2, "34040438")]
        [DataRow("12345678", 3, "03415518")]
        [DataRow("12345678", 4, "01029498")]
        public void Samples(string input, int phases, string expected)
        {
            Assert.AreEqual(expected, _day16.RunPhases(input, phases));
        }

        [TestMethod]
        [DataRow("80871224585914546619083218645595","24176176")]
        [DataRow("19617804207202209144916044189917","73745418")]
        [DataRow("69317163492948606335995924319873","52432133")]
        public void LargerExamples(string input, string expected)
        {
            Assert.AreEqual(expected, _day16.RunPhases(input, 100));
        }

        [TestMethod]
        public void DotProduct()
        {
            var input = new[] {9, 8, 7, 6, 5};
            var pattern = new[] {1,2,3,1,2};

            var result = input.Zip(pattern, (x1, x2) => x1 * x2).Sum();
            Assert.AreEqual(62, result);
            Assert.AreEqual(2, result % 10);
        }

        [TestMethod]
        public void FlawedFrequencyTransmission()
        {
            var input = FileReader.ReadFile("day16.txt").First();
            Assert.AreEqual("96136976",_day16.RunPhases(input,100));
        }

        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day16.txt").First();
            Assert.AreEqual("85600369",_day16.Part2(input));
        }
    }
}