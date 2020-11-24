using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Advent2015.Solutions
{
    class Day07
    {

        public string Transpile(string instruction)
        {
            var template = "public const ushort {0} = unchecked((ushort)({1}));";
            instruction = instruction.Replace("NOT ", "~").Replace("OR", "|").Replace("AND", "&")
                .Replace("LSHIFT", "<<").Replace("RSHIFT", ">>").Replace("->","=")
                .Replace("as","@as").Replace("if","@if").Replace("do", "@do").Replace("is", "@is").Replace("in", "@in");

            var parts = instruction.Split('=');
            return string.Format(template, parts[1].Trim(), parts[0].Trim());
        }

        public ushort BuildSolver(string[] instructions, string register)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class Logic{register} {{");
            
            foreach (var instruction in instructions)
            {
                sb.AppendLine(Transpile(instruction));
            }
             
            sb.AppendLine("public ushort GetValue(){");
            sb.AppendLine($"return {register};");
            sb.AppendLine(" }");
            sb.AppendLine("}");
            
            var compilation = CSharpCompilation.Create(
                $"Advent{register}.dll",
                new[] { CSharpSyntaxTree.ParseText(sb.ToString()) },
                new[]{ MetadataReference.CreateFromFile(typeof(object).Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            
            using (var ms = new MemoryStream())
            {
                compilation.Emit(ms);
                var assembly = Assembly.Load(ms.ToArray());
                var type = assembly.GetType($"Logic{register}");
                dynamic logic = Activator.CreateInstance(type);
                return logic.GetValue();
            }
        }
    }
    
}
