using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using Advent2015.Solutions;
using NUnit.Framework;

namespace Advent2015.Tests
{
    [TestFixture]
    class Day7Fixture
    {
        private Day7 _day7 = new Day7();

        private string[] _sample = {
            "123 -> x",
            "456 -> y",
            "x AND y -> d",
            "x OR y -> e",
            "x LSHIFT 2 -> f",
            "y RSHIFT 2 -> g",
            "NOT x -> h",
            "NOT y -> i"
        };

        [Test]
        public void Part1()
        {
            _day7.Part1();
        }

        [Test]
        public void And()
        {
            Assert.AreEqual(72, _day7.And("123","456"));    
        }
        
        [Test]
        public void Or()
        {
            Assert.AreEqual(507, _day7.Or("123","456"));    
        }

        [Test]
        public void Not()
        {
            Assert.AreEqual(65412, _day7.Not("123"));    
        }

        [Test]
        public void LShift()
        {
            Assert.AreEqual(492, _day7.LShift("123", "2"));    
        }

        [Test]
        public void SampleData()
        {
            _day7.Solve(_sample);
        }

        [Test]
        public void Solver()
        {
            _day7.Solver();
        }

        [Test]
        public void Compile()
        {
            AppDomain myDomain = Thread.GetDomain();
            AssemblyName myAsmName = new AssemblyName();
            myAsmName.Name = "LogicCompiler";

            // To generate a persistable assembly, specify AssemblyBuilderAccess.RunAndSave.
            AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.RunAndSave);
            // Generate a persistable single-module assembly.
            ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule(myAsmName.Name, myAsmName.Name + ".dll");

            TypeBuilder myTypeBuilder = myModBuilder.DefineType("CustomerData",
                                                            TypeAttributes.Public);

            FieldBuilder customerNameBldr = myTypeBuilder.DefineField("customerName", typeof(ushort), FieldAttributes.Private);
            var fieldABuilder = myTypeBuilder.DefineField("a", typeof(ushort), FieldAttributes.Public);
            var fieldB = myTypeBuilder.DefineField("b", typeof(ushort), FieldAttributes.Public);
            

            // The last argument of DefineProperty is null, because the
            // property has no parameters. (If you don't specify null, you must
            // specify an array of Type objects. For a parameterless property,
            // use an array with no elements: new Type[] {})
            PropertyBuilder custNamePropBldr = myTypeBuilder.DefineProperty("CustomerName",
                                                             PropertyAttributes.HasDefault,
                                                             typeof(ushort),
                                                             null);

            // The property set and property get methods require a special
            // set of attributes.
            MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;

            // Define the "get" accessor method for CustomerName.
            MethodBuilder custNameGetPropMthdBldr =
                myTypeBuilder.DefineMethod("get_CustomerName",
                                           getSetAttr,
                                           typeof(ushort),
                                           Type.EmptyTypes);

            ILGenerator custNameGetIL = custNameGetPropMthdBldr.GetILGenerator();

            custNameGetIL.Emit(OpCodes.Ldfld, fieldABuilder);
            custNameGetIL.Emit(OpCodes.Ldfld, fieldB);
            custNameGetIL.Emit(OpCodes.Add_Ovf);
            custNameGetIL.Emit(OpCodes.Conv_Ovf_U2_Un);

            custNameGetIL.Emit(OpCodes.Ret);

            //// Define the "set" accessor method for CustomerName.
            //MethodBuilder custNameSetPropMthdBldr =
            //    myTypeBuilder.DefineMethod("set_CustomerName",
            //                               getSetAttr,
            //                               null,
            //                               new Type[] { typeof(ushort) });

            //ILGenerator custNameSetIL = custNameSetPropMthdBldr.GetILGenerator();

            //custNameSetIL.Emit(OpCodes.Ldarg_0);
            //custNameSetIL.Emit(OpCodes.Ldarg_1);
            //custNameSetIL.Emit(OpCodes.Stfld, customerNameBldr);
            //custNameSetIL.Emit(OpCodes.Ret);

            // Last, we must map the two methods created above to our PropertyBuilder to 
            // their corresponding behaviors, "get" and "set" respectively. 
            custNamePropBldr.SetGetMethod(custNameGetPropMthdBldr);
            //custNamePropBldr.SetSetMethod(custNameSetPropMthdBldr);


            Type logic = myTypeBuilder.CreateType();

            // Save the assembly so it can be examined with Ildasm.exe,
            // or referenced by a test program.
            myAsmBuilder.Save(myAsmName.Name + ".dll");

            dynamic thing = Activator.CreateInstance(logic);
            Console.WriteLine(thing.a);
            Console.WriteLine(thing.b);
            Console.WriteLine(thing.CustomerName);
            //Console.WriteLine(thing.c);
            //return retval;

        }

        public class Temp
        {
            public const ushort a = 123;
            public const ushort b = a & 1;

            public ushort C => a & b;
        }
    }
}
