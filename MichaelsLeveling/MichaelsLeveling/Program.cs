using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMastery;
using LevelingTest;

namespace MichaelsLeveling
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectionTestRunner.RunTestsFor<Struct_ObjectInit_Tests>();
            ReflectionTestRunner.RunTestsFor<StringInterpolationTests>();
            ReflectionTestRunner.RunTestsFor<MethodOverloadingTests>();
            Console.ReadLine();
        }
    }
}
