using AdventOfCode.Codes;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day1Fixture
    {
        [Test]
        public void R2_L3()
        {
            var result = Day1.Distance("R2, L3");
            Assert.AreEqual(5, result);
        }

        [Test]
        public void R2_R2_R2()
        {
            var result = Day1.Distance("R2, R2, R2");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void R5_L5_R5_R3()
        {
            var result = Day1.Distance("R5, L5, R5, R3");
            Assert.AreEqual(12, result);
        }
    }
}
