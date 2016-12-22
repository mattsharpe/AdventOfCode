using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AdventOfCode.Utilities
{
    public class FileReader
    {
        public static string[] ReadFile(string filename)
        {
            var asm = Assembly.GetExecutingAssembly();
            var stream = asm.GetManifestResourceStream($"AdventOfCode.TestData.{filename}");

            if (stream == null)
                throw new Exception($"Could not load file {filename}");

            var results = new List<string>();
            using (var reader = new StreamReader(stream))
            {
                
                string line;
                while ((line = reader.ReadLine()) != null)
                    results.Add(line);
            }
            return results.ToArray();
        }
    }
}