using System;

namespace Advent2016.Utilities
{
    public class Triangle
    {
        public Triangle()
        {
        }

        public Triangle(string lengths)
        {
            A = Convert.ToInt32(lengths.Substring(0, 5));
            B = Convert.ToInt32(lengths.Substring(5, 5));
            C = Convert.ToInt32(lengths.Substring(10, 5));
        }

        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public bool IsValid()
        {
            return (A + B > C) &&
                   (A + C > B) &&
                   (C + B > A);
        }
    }
}