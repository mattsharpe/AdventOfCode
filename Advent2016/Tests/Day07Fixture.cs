using Advent2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day07Fixture
    {
        private Day07 _day7 = new Day07();

        [TestMethod]
        public void Sample1()
        {
            var input = "abba[mnop]qrst";
            var result = _day7.SupportsTLS(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Sample2()
        {
            var input = "abcd[bddb]xyyx";
            var result = _day7.SupportsTLS(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Sample3()
        {
            var input = "aaaa[qwer]tyui";
            var result = _day7.SupportsTLS(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Sample4()
        {
            var input = "ioxxoj[asdfgh]zxcvbn";
            var result = _day7.SupportsTLS(input);
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void Part1()
        {
            var result = _day7.Part1();
            Assert.AreEqual(105, result);
        }

        [TestMethod]
        public void SSL_Sample1()
        {
            var input = "aba[bab]xyz";
            var result = _day7.SupportsSSL(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SSL_Sample2()
        {
            var input = "xyx[xyx]xyx";
            var result = _day7.SupportsSSL(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SSL_Sample3()
        {
            var input = "aaa[kek]eke";
            var result = _day7.SupportsSSL(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SSL_Sample4()
        {
            var input = "zazbz[bzb]cdb";
            var result = _day7.SupportsSSL(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SSL_Sample5()
        {
            var input = "vjqhodfzrrqjshbhx[lezezbbswydnjnz]ejcflwytgzvyigz[hjdilpgdyzfkloa]mxtkrysovvotkuyekba";
            var result = _day7.SupportsSSL(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SSL_Invalid()
        {
            var input = "rnqfzoisbqxbdlkgfh[lwlybvcsiupwnsyiljz]kmbgyaptjcsvwcltrdx[ntrpwgkrfeljpye]jxjdlgtntpljxaojufe";
            var result = _day7.SupportsSSL(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SSL_Valid()
        {
            var input = "neakzsrjrhvixwp[ydbbvlckobfkgbandud]xdynfcpsooblftf[wzyquuvtwnjjrjbuhj]yxlpiloirianyrkzfqe";
            var result = _day7.SupportsSSL(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = _day7.Part2();
            Assert.AreEqual(258, result);
        }

        [TestMethod]
        public void FindAbas()
        {
            string test = "cgjtaytywwwoclclru";
            var result = _day7.FindAbas(test);
            Assert.IsTrue(result.Contains("yty"));
            Assert.IsTrue(!result.Contains("www"));
            Assert.IsTrue(result.Contains("clc"));
            Assert.IsTrue(result.Contains("lcl"));
        }
    }
}
