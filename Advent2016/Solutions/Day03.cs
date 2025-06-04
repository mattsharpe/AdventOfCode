using System;
using System.Collections.Generic;
using System.Linq;
using Advent2016.Utilities;

namespace Advent2016.Solutions
{
/*
--- Day 3: Squares With Three Sides ---

Now that you can think clearly, you move deeper into the labyrinth of hallways and office furniture that makes up this part of Easter Bunny HQ. This must be a graphic design department; the walls are covered in specifications for triangles.

Or are they?

The design document gives the side lengths of each triangle it describes, but... 5 10 25? Some of these aren't triangles. You can't help but mark the impossible ones.

In a valid triangle, the sum of any two sides must be larger than the remaining side. For example, the "triangle" given above is impossible, because 5 + 10 is not larger than 25.

In your puzzle input, how many of the listed triangles are possible?

Your puzzle answer was 917.

--- Part Two ---

Now that you've helpfully marked up their design documents, it occurs to you that triangles are specified in groups of three vertically. Each set of three numbers in a column specifies a triangle. Rows are unrelated.

For example, given the following specification, numbers with the same hundreds digit would be part of the same triangle:

101 301 501
102 302 502
103 303 503
201 401 601
202 402 602
203 403 603
In your puzzle input, and instead reading by columns, how many of the listed triangles are possible?

Your puzzle answer was 1649.
*/

    public class Day03
    {
        public IEnumerable<Triangle> BuildTriangles()
        {
            var data = FileReader.ReadFile("day03 triangles.txt");
            foreach (var line in data)
            {
                yield return new Triangle(line);
            }
        }

        public int FindInvalidTriangles()
        {
            var data = BuildTriangles();
            return data.Count(x => x.IsValid());
        }

        public int BuildTrianglesVertically()
        {
            var data = FileReader.ReadFile("day03 triangles.txt");
            var triangles =  ParseDataForVerticalTriangles(data);
            return triangles.Count(x => x.IsValid());
        }

        //Assumes the number of lines is a multiple of 3
        public IEnumerable<Triangle> ParseDataForVerticalTriangles(string[] data)
        {
            if(data.Length % 3 != 0 ) throw new Exception("Number of rows of data is not a multiple of 3");

            List<Triangle> results = new List<Triangle>();

            for (var i = 0; i < data.Length; i = i + 3)
            {
                var row1 = data[i];
                var row2 = data[i+1];
                var row3 = data[i+2];
                
                results.Add(new Triangle
                {
                    A = Convert.ToInt32(row1.Substring(0, 5)),
                    B = Convert.ToInt32(row2.Substring(0, 5)),
                    C = Convert.ToInt32(row3.Substring(0, 5))
                });

                results.Add(new Triangle
                {
                    A = Convert.ToInt32(row1.Substring(5, 5)),
                    B = Convert.ToInt32(row2.Substring(5, 5)),
                    C = Convert.ToInt32(row3.Substring(5, 5))
                });

                results.Add(new Triangle
                {
                    A = Convert.ToInt32(row1.Substring(10, 5)),
                    B = Convert.ToInt32(row2.Substring(10, 5)),
                    C = Convert.ToInt32(row3.Substring(10, 5))
                });
            }

            return results;
        }
    }
}
