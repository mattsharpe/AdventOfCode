using Advent2016.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class TriangleFixture
    {
        [TestMethod]
        public void BuildMeATriangle()
        {
            var input = "  330  143  338";
            var triangle = new Triangle(input);

            Assert.AreEqual(330, triangle.A);
            Assert.AreEqual(143, triangle.B);
            Assert.AreEqual(338, triangle.C);
        }

        [TestMethod]
        public void ValidTriangle()
        {
            var triangle = new Triangle {A = 5, B = 10, C = 7};
            Assert.IsTrue(triangle.IsValid());
        }

        [TestMethod]
        public void InvalidTriangle()
        {
            var triangle = new Triangle {A = 5, B = 10, C = 25};
            Assert.IsFalse(triangle.IsValid());
        }
    }
}
