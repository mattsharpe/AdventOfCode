
namespace Advent2017.Solutions
{
    internal class Day24
    {
        public record Component(int Port1, int Port2);
        private record Bridge(int Length, int Strength);

        public int Part1(string[] input)
        {
            var components = ParseInput(input);
            var bridges = FindAllBridges(0, components, [], 0, 0);
            return bridges.Max(b => b.Strength);
        }

        public int Part2(string[] input)
        {
            var components = ParseInput(input);
            return FindAllBridges(0, components, [], 0, 0)
                .OrderByDescending(x=>x.Length)
                .ThenByDescending(x=>x.Strength)
                .First().Strength;
        }

        public List<Component> ParseInput(string[] input) => [.. input.Select(line =>
        {
            var parts = line.Split('/');
            return new Component(int.Parse(parts[0]), int.Parse(parts[1]));
        })];

        private List<Bridge> FindAllBridges(int port, List<Component> components,
                                                HashSet<Component> visited,
                                                int currentLength,
                                                int currentStrength)
        {
            var bridges = new List<Bridge>
            {
                new(currentLength, currentStrength)
            };

            foreach (var component in components)
            {
                if (!visited.Contains(component) && (component.Port1 == port || component.Port2 == port))
                {
                    visited.Add(component);
                    int nextPort = component.Port1 == port ? component.Port2 : component.Port1;
                    int componentStrength = component.Port1 + component.Port2;
                    bridges.AddRange(FindAllBridges(nextPort, components, visited,
                                                   currentLength + 1,
                                                   currentStrength + componentStrength));
                    visited.Remove(component);
                }
            }

            return bridges;
        }
    }

}
