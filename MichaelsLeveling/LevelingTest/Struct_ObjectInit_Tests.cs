﻿using CSharpMastery;

namespace LevelingTest
{
    //[TestClass]
    public class Struct_ObjectInit_Tests : ISupportReflectionTestRunner<SomeType>
    {
        public SomeType SomeRequiredMethodForReflectionTestRunner()
        {
            return new SomeType { Description = "Example(s) with Struct"}; // object initialization https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers 
        }

        //[TestMethod]
        public bool CoOrdsParameterizedConstructorInitializesXandY()
        {
            const int x = 10;
            const int y = 15;

            // Declare a struct object without "new"
            CoOrds coords;
            coords.x = x;
            coords.y = y;

            var result = new CoOrds(x, y);

            return result.x == coords.x && result.y == coords.y;
            //Assert.AreEqual(result.x, coords.x);
            //Assert.AreEqual(result.y, coords.y);
        }
    }
}
