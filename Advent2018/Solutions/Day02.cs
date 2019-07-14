using System.Linq;
using System.Text;

namespace Advent2018.Solutions
{
    public class Day02
    {
        public int DoubleLetters{ get; set; }
        public int TripleLetters{ get;set; }

        public void ProcessBox(string boxId)
        {
            var letterCount = boxId.GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            if (letterCount.Values.Any(x => x == 2))
            {
                DoubleLetters++;
            }
            if (letterCount.Values.Any(x => x == 3))
            {
                TripleLetters++;
            }
        }

        public string FindCommonLetters(string[] boxes)
        {
            var result = (from box in boxes
                from comparisonBox in boxes
                where box.ToCharArray()
                          .Zip(comparisonBox.ToCharArray(), (c1, c2) => new {c1, c2})
                          .Count(m => m.c1 != m.c2) == 1
                select new {a = box, b = comparisonBox}).First();

            var answer = new StringBuilder();
            for(int i=0; i < result.a.Length; i++)
            {
                if (result.a[i] == result.b[i])
                {
                    answer.Append(result.a[i]);
                }
            }

            return answer.ToString();
        }
    }
}
