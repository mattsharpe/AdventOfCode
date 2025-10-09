
namespace Advent2017.Solutions
{
    internal class Day24
    {
        public record Component(int Port1, int Port2)
        {
            public int Strength => Port1 + Port2;
        }

        private record ComponentCandidate(int ComponentIndex, int OtherPort, int Strength);

        public int Part1(string[] input)
        {
            var components = ParseInput(input);
            var index = BuildComponentIndex(components);
            var visited = new bool[components.Count];

            return FindStrongestBridge(currentPort: 0, index, visited);
        }

        public int Part2(string[] input)
        {
            var components = ParseInput(input);
            var index = BuildComponentIndex(components);
            var visited = new bool[components.Count];

            var (_, strength) = FindLongestBridge(currentPort: 0, index, visited);
            return strength;
        }

        private List<Component> ParseInput(string[] input)
        {
            return input.Select(line =>
            {
                var parts = line.Split('/');
                return new Component(int.Parse(parts[0]), int.Parse(parts[1]));
            }).ToList();
        }

        private Dictionary<int, List<ComponentCandidate>> BuildComponentIndex(List<Component> components)
        {
            var index = new Dictionary<int, List<ComponentCandidate>>();

            for (int i = 0; i < components.Count; i++)
            {
                var component = components[i];

                // Add component under Port1
                AddToIndex(index, component.Port1, new ComponentCandidate(i, component.Port2, component.Strength));

                // Add component under Port2 (if different from Port1)
                if (component.Port1 != component.Port2)
                {
                    AddToIndex(index, component.Port2, new ComponentCandidate(i, component.Port1, component.Strength));
                }
            }

            return index;
        }

        private void AddToIndex(Dictionary<int, List<ComponentCandidate>> index, int port, ComponentCandidate candidate)
        {
            if (!index.ContainsKey(port))
                index[port] = [];

            index[port].Add(candidate);
        }

        private int FindStrongestBridge(int currentPort, Dictionary<int, List<ComponentCandidate>> index, bool[] visited)
        {
            // If no components can connect to this port, this path ends here
            if (!index.TryGetValue(currentPort, out var candidates))
                return 0;

            int maxStrength = 0;

            // Try each component that can connect to the current port
            foreach (var (componentIndex, otherPort, strength) in candidates)
            {
                if (visited[componentIndex]) continue;

                // Use this component and explore further
                visited[componentIndex] = true;
                int remainingStrength = FindStrongestBridge(otherPort, index, visited);
                maxStrength = Math.Max(maxStrength, strength + remainingStrength);
                visited[componentIndex] = false; // Backtrack
            }

            return maxStrength;
        }

        private (int length, int strength) FindLongestBridge(int currentPort, Dictionary<int, List<ComponentCandidate>> index, bool[] visited)
        {
            // If no components can connect to this port, this path ends here
            if (!index.TryGetValue(currentPort, out var candidates))
                return (0, 0);

            int bestLength = 0;
            int bestStrength = 0;

            // Try each component that can connect to the current port
            foreach (var (componentIndex, otherPort, strength) in candidates)
            {
                if (visited[componentIndex]) continue;

                // Use this component and explore further
                visited[componentIndex] = true;
                var (remainingLength, remainingStrength) = FindLongestBridge(otherPort, index, visited);
                visited[componentIndex] = false; // Backtrack

                int totalLength = 1 + remainingLength;
                int totalStrength = strength + remainingStrength;

                // Prefer longer bridges; break ties with stronger bridges
                if (totalLength > bestLength || (totalLength == bestLength && totalStrength > bestStrength))
                {
                    bestLength = totalLength;
                    bestStrength = totalStrength;
                }
            }

            return (bestLength, bestStrength);
        }
    }

}
