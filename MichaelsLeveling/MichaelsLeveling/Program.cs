using System;
using LevelingTest;

namespace MichaelsLeveling
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectionTestRunner.RunTestsFor<Struct_ObjectInit_Tests>();
            ReflectionTestRunner.RunTestsFor<StringInterpolation_Tests>();
            ReflectionTestRunner.RunTestsFor<MethodOverloading_Tests>();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("NOW SHOW WHAT default KEYWORD DOES");
            Console.WriteLine($"print default(Int32): {default(Int32)}"); // Prints "0"
            Console.WriteLine($"print default(Boolean): {default(Boolean)}"); // Prints "False"
            Console.WriteLine($"print default(String): {default(String)}");  // Prints nothing (because it is null)
            Console.ReadLine();
        }
    }
}
