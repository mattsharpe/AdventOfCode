using System.Collections.Generic;
using System.Linq;

namespace Advent2019.Solutions
{
    class Day06
    {
        private Dictionary<string, string> _graph;
        
        public void BuildGraph(string[] input)
        {
            _graph = input
                .Select(relationship => relationship.Split(")"))
                .ToDictionary(split => split[1], split => split[0]);
        }

        public int Orbits()
        {
            return _graph.Keys.Sum(x => GetParents(x).Count());
        }

        public IEnumerable<string> GetParents(string node)
        {
            while (node != null)
            {
                node = _graph.GetValueOrDefault(node, null);
                if (node != null)
                {
                    yield return node;
                }
            }
        }
    }
}
