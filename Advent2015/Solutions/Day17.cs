
namespace Advent2015.Solutions
{
    class Day17
    {
        public int FillContainers(int[] containers, int amount)
        {
            return Count(amount, containers.Length, null, containers);
        }

        public int Count(int total, int n, int? i, int[] containers)
        {
            i = i ?? 0;

            if (n < 0) {
                return 0;
            } if (total == 0) {
                return 1;
            } if (i == containers.Length || total < 0) {
                return 0;
            }

            var head = Count(total, n, i + 1, containers);
            var tail = Count(total - containers[i.Value], n - 1, i + 1, containers);
            
            return head + tail; 
        }

        public int MinimumNumberOfContainers(int[] containers, int amount)
        {
            var i = 1;
            var result = 0;
            while (result==0) {
                result = Count(amount, i++, null, containers);
            }

            return result;
        }

    }
}
