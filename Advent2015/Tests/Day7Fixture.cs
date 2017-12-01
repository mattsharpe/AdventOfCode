using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advent2015.Solutions;
using Advent2015.Utilities;
using NUnit.Framework;

namespace Advent2015.Tests
{
    [TestFixture]
    class Day7Fixture
    {
        private Day7 _day7 = new Day7();

        private string[] _sample = {
            "123 -> x",
            "456 -> y",
            "x AND y -> d",
            "x OR y -> e",
            "x LSHIFT 2 -> f",
            "y RSHIFT 2 -> g",
            "NOT x -> h",
            "NOT y -> i"
        };

        [Test]
        public void Part1()
        {
            _day7.Part1();
        }

        [Test]
        public void And()
        {
            Assert.AreEqual(72, _day7.And("123","456"));    
        }
        
        [Test]
        public void Or()
        {
            Assert.AreEqual(507, _day7.Or("123","456"));    
        }

        [Test]
        public void Not()
        {
            Assert.AreEqual(65412, _day7.Not("123"));    
        }

        [Test]
        public void LShift()
        {
            Assert.AreEqual(492, _day7.LShift("123", "2"));    
        }

        [Test]
        public void SampleData()
        {
            _day7.Solve(_sample);
        }

        [Test]
        public void Solver()
        {
            _day7.Solver();
        }
    }
}
