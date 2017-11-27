using Advent2016.Solutions;
using NUnit.Framework;

namespace Advent2016.Tests
{
    [TestFixture]
    public class Day7Fixture
    {
        private Day7 _day7 = new Day7();

        [Test]
        public void Sample1()
        {
            var input = "abba[mnop]qrst";
            var result = _day7.SupportsTLS(input);
            Assert.IsTrue(result);
        }

        [Test]
        public void Sample2()
        {
            var input = "abcd[bddb]xyyx";
            var result = _day7.SupportsTLS(input);
            Assert.IsFalse(result);
        }

        [Test]
        public void Sample3()
        {
            var input = "aaaa[qwer]tyui";
            var result = _day7.SupportsTLS(input);
            Assert.IsFalse(result);
        }

        [Test]
        public void Sample4()
        {
            var input = "ioxxoj[asdfgh]zxcvbn";
            var result = _day7.SupportsTLS(input);
            Assert.IsTrue(result);
        }
        
        [Test]
        public void Part1()
        {
            var result = _day7.Part1();
            Assert.AreEqual(105, result);
        }

        [Test]
        public void SSL_Sample1()
        {
            var input = "aba[bab]xyz";
            var result = _day7.SupportsSSL(input);
            Assert.IsTrue(result);
        }

        [Test]
        public void SSL_Sample2()
        {
            var input = "xyx[xyx]xyx";
            var result = _day7.SupportsSSL(input);
            Assert.False(result);
        }

        [Test]
        public void SSL_Sample3()
        {
            var input = "aaa[kek]eke";
            var result = _day7.SupportsSSL(input);
            Assert.True(result);
        }

        [Test]
        public void SSL_Sample4()
        {
            var input = "zazbz[bzb]cdb";
            var result = _day7.SupportsSSL(input);
            Assert.True(result);
        }

        [Test]
        public void SSL_Sample5()
        {
            var input = "vjqhodfzrrqjshbhx[lezezbbswydnjnz]ejcflwytgzvyigz[hjdilpgdyzfkloa]mxtkrysovvotkuyekba";
            var result = _day7.SupportsSSL(input);
            Assert.False(result);
        }

        [Test]
        public void SSL_Invalid()
        {
            var input = "rnqfzoisbqxbdlkgfh[lwlybvcsiupwnsyiljz]kmbgyaptjcsvwcltrdx[ntrpwgkrfeljpye]jxjdlgtntpljxaojufe";
            var result = _day7.SupportsSSL(input);
            Assert.False(result);
        }

        [Test]
        public void SSL_Valid()
        {
            var input = "neakzsrjrhvixwp[ydbbvlckobfkgbandud]xdynfcpsooblftf[wzyquuvtwnjjrjbuhj]yxlpiloirianyrkzfqe";
            var result = _day7.SupportsSSL(input);
            Assert.True(result);
        }

        [Test]
        public void Part2()
        {
            var result = _day7.Part2();
            Assert.AreEqual(258, result);
        }

        [Test]
        public void FindAbas()
        {
            string test = "cgjtaytywwwoclclru";
            var result = _day7.FindAbas(test);
            Assert.That(result.Contains("yty"));
            Assert.That(!result.Contains("www"));
            Assert.That(result.Contains("clc"));
            Assert.That(result.Contains("lcl"));
        }
    }
}
