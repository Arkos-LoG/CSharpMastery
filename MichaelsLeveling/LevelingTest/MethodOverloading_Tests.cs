using System;
using CSharpMastery;

namespace LevelingTest
{
    //[TestClass]
    public class MethodOverloading_Tests : ISupportReflectionTestRunner<SomeType>
    {
        public SomeType SomeRequiredMethodForReflectionTestRunner()
        {
            return new SomeType { Description = "Example(s) for method overloading" }; // object initialization
        }

        //[TestMethod]
        // This shows that the compiler will choose the best argument conversion since return type of a method 
        // is not considered to be part of a method's signature.
        //
        // Note: that compiler chooses an overload before it checks whether return type will cause an error
        //
        public bool ShouldCallFooWithReturnTypeString()
        {           
            var actual = MethodOverloading.Foo(10);

            return actual is string;
            //Assert.IsInstanceOfType(actual, typeof(string));
        }

        //[TestMethod]
        public bool ShouldCallFooWithReturnTypeGuid()
        {
            var actual = MethodOverloading.Foo(10D);

            return actual is Guid;
            //Assert.IsInstanceOfType(actual, typeof(Guid));
        }

        //[TestMethod]
        public bool ShouldCallOverloadWithoutDefaultParam()
        {
            var actual = MethodOverloading.DefaultParamExample(10);

            return actual == "Foo(int x)";
            //Assert.AreEqual(actual, "Foo(int x)");
        }

        //[TestMethod]
        public bool ShouldAddNumbersPassingTwoNamedArguments()
        {
            var expected = 5 + 6;
            var actual = MethodOverloading.NamedArgumentExample(y: 6, x: 5);

            return actual == expected;
            //Assert.AreEqual(actual, expected);
        }

        //[TestMethod]
        public bool ShouldAddNumbersPassingThreeNamedArguments()
        {
            var expected = 5 + 6 + 1;
            var actual = MethodOverloading.NamedArgumentExample(z: 1, y: 6, x: 5);

            return actual == expected;
            //Assert.AreEqual(actual, expected);
        }

        // compiler will first look at the target class for a suitable method.
        // Below c.Foo(10) will actually use the Foo(double y) method because the compiler ignores overriding methods 
        // and it won’t consider the base class if a “suitable” one was found to  reduce the risk of the brittle base class problem, 
        // where the introduction of a new method to a base class could cause problems for consumers of classes derived from it
        //[TestMethod]
        public bool ShouldCallFooWithDoubleParamEvenWhenPassedInt()
        {
            int myInt = 10;
            var c = new Child();

            var actual = c.Foo(myInt);

            return actual == "Child.Foo(double y)";
            //Assert.AreEqual(actual, "Child.Foo(double y)");
        }
    }
}
/*
If you find yourself going to the spec to see which of your methods will be called and the methods are under your control then it is strongly 
advised to consider renaming some of the methods to reduce the degree of overloading. This advice goes double when it's across an inheritance hierarchy, for reasons outlined earlier. 
*/
