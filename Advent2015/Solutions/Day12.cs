using System;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Advent2015.Solutions
{
    class Day12
    {
        public int SumNumbers(string json)
        {
            var regex = new Regex(@"-?\d+");
            return regex.Matches(json).Sum(x=> int.Parse(x.Value));
        }

        public int SumNumbersWithoutRed(string json)
        {
            dynamic account = JsonConvert.DeserializeObject(json);

            return GetSum(account);
        }

        private int GetSum(JObject o)
        {
            var anyRed = o.Properties().Any(x => x.Value.ToString() == "red");

            return anyRed ? 0 : o.Properties().Sum((dynamic a) => GetSum(a.Value));
        }

        private int GetSum(JArray array)
        {
            return array.Sum((dynamic x) => GetSum(x));
        }

        private int GetSum(JValue val)
        {
            return val.Type == JTokenType.Integer ? Convert.ToInt32(val.Value) : 0;
        }
    }
}
