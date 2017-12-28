﻿using System;
using System.Linq;
using Advent2017.Solutions;
using Advent2017.Utilities;
using NUnit.Framework;

namespace Advent2017.Tests
{
    class Day16Fixture
    {
        private Day16 _day16 = new Day16();

        [SetUp]
        public void Setup()
        {
            _day16 = new Day16();
        }

        [Test]
        public void Dance()
        {
            //a -> p
        }

        [Test]
        public void Sample()
        {
            _day16.Dancers = "abcde";
            var input = "s1,x3/4,pe/b";

            _day16.Dance(input);

            Assert.AreEqual("baedc", _day16.Dancers);
        }

        [Test]
        public void Spin()
        {
            _day16.Dancers = "abcde";
            _day16.Spin(3);

            Assert.AreEqual("cdeab", _day16.Dancers);
        }

        [Test]
        public void Exchange()
        {
            _day16.Dancers = "eabcd";
            _day16.Exchange("x3/4");

            Assert.AreEqual("eabdc", _day16.Dancers);
        }

        [Test]
        public void Switch()
        {
            _day16.Dancers = "eabdc";
            _day16.SwapPrograms("e/b");

            Assert.AreEqual("baedc", _day16.Dancers);
        }

        [Test]
        public void Part1()
        {
            _day16.Dance(FileReader.ReadFile("day16.txt")[0]);
            Assert.AreEqual("fnloekigdmpajchb",_day16.Dancers);
        }

        [Test]
        public void Part2()
        {
            var steps = FileReader.ReadFile("day16.txt")[0];
            _day16.Part2(steps);
            
            Console.WriteLine(_day16.Dancers);
        }
    }
}