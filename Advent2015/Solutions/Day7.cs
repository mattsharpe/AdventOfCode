using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Advent2015.Solutions
{
    class Day7
    {
        public void Part1()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, ushort> _cache = default;
        private Dictionary<string, string> _wires = default;

        public ushort And(string a, string b)
        {
            return (ushort)(GetValue(a) & GetValue(b));
        }

        public ushort Or(string a, string b)
        {
            return (ushort)(GetValue(a) | GetValue(b));
        }

        public ushort Not(string a)
        {
            return (ushort)~GetValue(a);
        }

        public ushort LShift(string s, string shift)
        {
            GetValue(s);
            GetValue(shift);
            return  unchecked ((ushort)(GetValue(s) << GetValue(shift)));

        }

        private ushort GetValue(string value)
        {
            ushort temp;
            if (UInt16.TryParse(value, out temp))
            {
                return temp;
            }
            else
            {
                return _cache[value];
            }

        }

        public void Solver()
        {
            AssemblyName assemblyName = new AssemblyName("MyDynamicAssembly");
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName,AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder= assemblyBuilder.DefineDynamicModule("MyDynamicModule");
            TypeBuilder typeBuilder = moduleBuilder.DefineType(
                    "InternalType",
                    TypeAttributes.Public
                    | TypeAttributes.Class
                    | TypeAttributes.AutoClass
                    | TypeAttributes.AnsiClass
                    | TypeAttributes.ExplicitLayout);

            var fieldBuilder_a = typeBuilder.DefineField("a", typeof(UInt32), FieldAttributes.Public);
            fieldBuilder_a.SetOffset(sizeof(UInt16));

            var fieldBuilder_b = typeBuilder.DefineField("b", typeof(UInt32), FieldAttributes.Public);
            fieldBuilder_b.SetOffset(0);

            
            Type logic = typeBuilder.CreateType();

            dynamic thing = Activator.CreateInstance(logic);
            Console.WriteLine(thing.a);
            Console.WriteLine(thing.b);
            var variable = "aa";
            
            //Console.WriteLine(thing.variable);

        }

        public void Solve(string[] instructions)
        {
            _wires = instructions.ToList().ToDictionary(k => k.Split(' ').Last());
            foreach (var instruction in instructions)
            {
                var split = instruction.Split(' ');
                Console.WriteLine(instruction);
                var gate = new LogicGate();
                switch (split.Length)
                {
                    //123 -> a
                    case 3:
                        gate.Left = split[0];
                        gate.Right = split[2];
                        break;
                    
                }
            }
        }
    }

    public class LogicGate
    {
        public string Left { get; set; }
        public string Right { get; set; }
        public ushort Value { get; set; }
    }

    public enum LogicOperator
    {
        And,
        Or,
        LShift,
        RShift,
        Not
    }
}
