using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Advent2019.Solutions
{
    class Day08
    {
        private List<string> _layers = new List<string>();
        
        public void ParseLayers(string input, int width, int height)
        {
            var numberOfLayers = input.Length / (width * height);
            for (var i = 0; i < numberOfLayers; i++)
            {
                _layers.Add(new string(input.Skip(i * width * height).Take(width * height).ToArray()));
            }
        }

        public int Checksum()
        {
            var ordered = _layers.OrderBy(x=>x.Count(y=>y.Equals('0')));
            var layer = ordered.First();
            return layer.Count(x => x.Equals('1')) * layer.Count(x => x.Equals('2'));
        }
        
        public void FlattenLayers()
        {
            var flattenedImage = new StringBuilder();
            for (var i = 0; i < _layers[0].Length; i++)
            {
                flattenedImage.Append(_layers.Select(x=>x[i]).First(x=> x != '2') == '1' ? '#' : '.');
                if(i%25 == 24)
                {
                    flattenedImage.AppendLine("");
                }
            }
            Console.WriteLine(flattenedImage);
        }
    }
}
