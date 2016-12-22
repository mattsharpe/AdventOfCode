using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Utilities;

namespace AdventOfCode.Solutions
{
    public class Day3
    {
        public IEnumerable<Triangle> BuildTriangles()
        {
            var data = FileReader.ReadFile("day3.txt");
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
            var data = FileReader.ReadFile("day3.txt");
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
