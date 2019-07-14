using System.Collections.Generic;
using System.Linq;

namespace Advent2018.Solutions
{
    class Day08
    {
        public TreeNode ParseTree(string input)
        {
            var nodes = input.Split(" ").Select(int.Parse).ToList();
            return BuildTree(nodes);

        }

        private TreeNode BuildTree(List<int> nodes)
        {
            var enumerator = nodes.GetEnumerator();

            int Next()
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }

            TreeNode BuildNode()
            {
                var node = new TreeNode()
                {
                    Nodes = new List<TreeNode>(Next()),
                    MetaData = new List<int>(Next())
                };

                for (var i = 0; i < node.Nodes.Capacity; i++)
                {
                    node.Nodes.Add(BuildNode());
                }
                for (var i = 0; i < node.MetaData.Capacity; i++)
                {
                    node.MetaData.Add(Next());
                }
                return node;
            }
            
            return BuildNode();
        }
        

        public int SumMetaData(TreeNode rootNode)
        {
            return rootNode.MetaData.Sum() +
                   rootNode.Nodes.Sum(SumMetaData);
        }

        public int ValueOfRootNode(TreeNode node)
        {
            if (!node.Nodes.Any())
            {
                return node.MetaData.Sum();
            }

            var res = 0;
            foreach (var i in node.MetaData)
            {
                if (i >= 1 && i <= node.Nodes.Count)
                {
                    res += ValueOfRootNode(node.Nodes[i - 1]);
                }
            }
            return res;
        }
    }

    public class TreeNode
    {
        public List<TreeNode> Nodes { get; set; } = new List<TreeNode>();
        public List<int> MetaData { get; set; } = new List<int>();
    }

}
