using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMastery;

namespace LevelingTest
{
    [TestClass]
    public class BitwiseOps_Params_Enums_Casting_ArrayInit_Tests
    {
        [TestMethod]
        public void AssignMealsToEatOutUsingFlags()
        {

            // single pipe, "|", in C# is a logic operator, not conditional. 
            // used at binary level to OR each position of the binary values. 
            // with an OR, the result is true when at least one condition is true; 
            // otherwise the result is false.         

            /*
               EXAMPLE:
                
               MealsToEatOut  = Meals.Breakfast | Meals.Snack | Meals.Dinner; 

             Breakfast 	0	0	0	0	0	0	1
	                    |	|	|	|	|	|	|
              Snack  	0	0	0	0	1	0	0
	                    |	|	|	|	|	|	|
              Dinner	0	0	0	1	0	0	0
                ________________________________________
                Result	0	0	0	1	1	0	1

               Use the logical AND operator "&" to see if the result has a flag set. 

               if((MealsToEatOut & Meals.Breakfast) == Meals.Breakfast)
                {
                    // has Breakfast
                }
                else
                {
                    // DOES NOT have Breakfast
                }

                MealsToEatOut	0	0	0	1	1	0	1
	                            &	&	&	&	&	&	&
                    Breakfast	0	0	0	0	0	0	1
                  ________________________________________
                      Result	0	0	0	0	0	0	1   --> has breakfast

             */

            //
            // Array Initializers
            // 
            var exepectedMealsToEatOut = new[] {Meals.Breakfast, Meals.Lunch, Meals.LateNight};
            // another way... exepectedMealsToEatOut[] = {Meals.Breakfast, Meals.Lunch, Meals.LateNight};
            var actualMealsToEatOut = new Meals[3]; // creates an array for three elements

            EatingOut.SetMealsToEatOut(exepectedMealsToEatOut); // using params here!

            var meals = Enum.GetValues(typeof(Meals)).Cast<Enum>();// cast to Enum in order to do the Where...below

            var index = 0;
            foreach (var appointment in meals.Where(EatingOut.MealsToEatOut.HasFlag))
            {
                actualMealsToEatOut[index] = (Meals)appointment;
                index++;
            }

            Assert.IsTrue(actualMealsToEatOut.SequenceEqual(exepectedMealsToEatOut)); // https://www.dotnetperls.com/sequenceequal 
        }
    }
}

// resource
// https://stackoverflow.com/questions/8055206/enum-bitwise-flags-instance-enumeration-iteration-foreach 