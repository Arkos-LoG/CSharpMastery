using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CSharpMastery;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LevelingTest;

namespace LevelingTest
{
    //[TestClass]
    public class Struct_ObjectInit_Tests : ISupportReflectionTestRunner<SomeClass>
    {
        public SomeClass SomeRequiredMethodForReflectionTestRunner()
        {
            return new SomeClass { Description = "Example(s) with Struct"}; // object initialization https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers 
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
