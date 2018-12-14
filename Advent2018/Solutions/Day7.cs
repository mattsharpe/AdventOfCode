using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advent2018.Utilities;

namespace Advent2018.Solutions
{
    class Day7
    {
        private readonly Dictionary<char, Node> _graph = new Dictionary<char, Node>();

        public string CalculatePath(string[] input)
        {
            BuildGraph(input);

            var sb = new StringBuilder();
            
            while (_graph.Any())
            {
                var nextTask = _graph.Values.Where(x => x.Dependencies.Count == 0).OrderBy(x => x.Id).First();
                _graph.Values.ForEach(x => x.Dependencies.Remove(nextTask));
                _graph.Remove(nextTask.Id);
                sb.Append(nextTask.Id);
            }

            return sb.ToString();
        }

        public int CalculateTimeTaken(string[] input, int numberOfWorkers = 5, bool waitFor60 = true)
        {
            BuildGraph(input);
            
            var elapsed = 0;

            var workers = new int[numberOfWorkers];
            var items = new Node[workers.Length];

            while (_graph.Any() || workers.Any(x=> x > 0)) //if there's any work to do
            {
                //if there are any free workers assign them a job
                for (var i = 0; i < workers.Length && _graph.Values.Any(x => x.Dependencies.Count == 0); i++)
                {
                    if (workers[i] != 0) continue;
                    var nextTask = _graph.Values.Where(x => x.Dependencies.Count == 0).OrderBy(x => x.Id).First();
                    workers[i] = nextTask.Id - 'A' + 1;

                    //sample data and actual data have different parameters
                    if (waitFor60)
                        workers[i] += 60;

                    items[i] = nextTask;
                    _graph.Remove(items[i].Id);
                }
                
                elapsed++;
                
                for (var i = 0; i < workers.Length; i++)
                {
                    if (workers[i] == 1)
                    {
                        _graph.Values.ForEach(x => x.Dependencies.Remove(items[i]));
                    }
                    if (workers[i] >= 1)
                    {
                        workers[i]--;
                    }
                }
            }

            return elapsed;
        }

        private void BuildGraph(string[] input)
        {
            foreach (var instruction in input)
            {
                var split = instruction.Split(" ");
                GetOrCreateNode(Convert.ToChar(split[7])).Dependencies.Add(GetOrCreateNode(Convert.ToChar(split[1])));
            }
        }


        private Node GetOrCreateNode(char id)
        {
            if (_graph.ContainsKey(id)) return _graph[id];
            var node = new Node{Id = id};
            _graph[id] = node;

            return _graph[id];
        }

    }

    public class Node   
    {
        public char Id { get; set; }
        public List<Node> Dependencies { get; set; } = new List<Node>();
    }
}
