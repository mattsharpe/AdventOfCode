using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day07Fixture
    {
        private Day07 _day7 = new Day07();

        [TestInitialize]
        public void Setup()
        {
            _day7 = new Day07();
        }

        public string[] _sample =
        {
            "pbga (66)",
            "xhth (57)",
            "ebii (61)",
            "havc (66)",
            "ktlj (57)",
            "fwft (72) -> ktlj, cntj, xhth",
            "qoyq (66)",
            "padx (45) -> pbga, havc, qoyq",
            "tknk (41) -> ugml, padx, fwft",
            "jptl (61)",
            "ugml (68) -> gyxo, ebii, jptl",
            "gyxo (61)",
            "cntj (57)"
        };

        [TestMethod]
        public void Sample()
        {
            Assert.AreEqual("tknk", _day7.FindBottomProgram(_sample));
        }
         
        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual("hlhomy", _day7.FindBottomProgram(FileReader.ReadFile("day07.txt")));
        }

        [TestMethod]
        public void Sample2()
        {
            Assert.AreEqual(60, _day7.FindCorrectedWeight(_sample));
        }
        
        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(1505, _day7.FindCorrectedWeight(FileReader.ReadFile("day07.txt")));
        }
    }
}
