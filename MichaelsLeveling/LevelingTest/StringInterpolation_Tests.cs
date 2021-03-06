﻿using CSharpMastery;

namespace LevelingTest
{
    //[TestClass]
    public class StringInterpolation_Tests : ISupportReflectionTestRunner<SomeType>
    {
        public SomeType SomeRequiredMethodForReflectionTestRunner()
        {
            return new SomeType { Description = "Example(s) with String Interpolation" }; // object initialization
        }

        //[TestMethod]
        public bool StringInterpolationGreetingValid()
        {
            var source = "have a nice day";

            var firstName = "yo";
            var lastName = "dude";

            var expected = $"Hello {firstName} {lastName}";

            var actual = StringInterpolation.Greeting(firstName, lastName);

            return expected == actual;
            //Assert.AreEqual(expected, actual);
        }
    }
}