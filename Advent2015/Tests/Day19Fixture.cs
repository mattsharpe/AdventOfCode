using Advent2015.Solutions;
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
        public void HoHoho()
        {
            string[] rules =
            {
                "H => HO",
                "H => OH",
                "O => HH"
            };
            var input = "HOH";

            _day19.ParseSubstitutionRules(rules);
            _day19.GenerateReplacements(input);
        }

    }
}