using System.Collections.Generic;
using System.Linq;
using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day19Fixture
    {
        private Day19 _day19;

        [TestInitialize]
        public void Initialize() => _day19 = new Day19();

        [TestMethod]
        public void ParseSubstitutionRules()
        {
            string[] rules =
            {
                "H => HO",
                "H => OH",
                "O => HH"
            };
            var input = "HOH";

            _day19.ParseSubstitutionRules(rules);
            var results = _day19.GenerateReplacements(input);
            Assert.AreEqual(4, results.Count);
        }
        [TestMethod]
        public void ParseSubstitutionRulesHoHoHo()
        {
            string[] rules =
            {
                "H => HO",
                "H => OH",
                "O => HH"
            };
            var input = "HOHOHO";

            _day19.ParseSubstitutionRules(rules);
            var results = _day19.GenerateReplacements(input);
            Assert.AreEqual(7, results.Count);
        }


        [TestMethod]
        public void GenerateSubstitutions()
        {
            var puzzleInput = FileReader.ReadFile("day19.txt");
            string[] rules = new List<string>(puzzleInput).Where(x => x.Contains("=>")).ToArray();
            var input = puzzleInput.Last();

            _day19.ParseSubstitutionRules(rules);
            var results = _day19.GenerateReplacements(input);
            Assert.AreEqual(510, results.Count);
        }

    }
}