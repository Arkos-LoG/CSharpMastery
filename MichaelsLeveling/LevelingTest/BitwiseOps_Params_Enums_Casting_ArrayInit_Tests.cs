using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMastery;

namespace LevelingTest
{
    [TestClass]
    public class BitwiseOps_Params_Enums_Casting_ArrayInit_Tests
    {
        [TestMethod]
        public void AssignSomeDaysOfWeekUsingFlags()
        {

            // single pipe, "|", in C# is a logic operator, not conditional. 
            // This means at a binary level, we OR each position of the binary values. 
            // Boolean logic tells us in an OR situation the result is true when at least one condition is true; 
            // otherwise the result is false.         

            /*
               EXAMPLE:
                
               daysOfTheWeek = DaysOfTheWeek.Monday | DaysOfTheWeek.Wednesday | DaysOfTheWeek.Friday; 

                Monday	0	0	0	0	0	1	0
	                    |	|	|	|	|	|	|
              Wednesday	0	0	0	1	0	0	0
	                    |	|	|	|	|	|	|
                Friday	0	1	0	0	0	0	0
                ________________________________________
                Result	0	1	0	1	0	1	0

               To test to see if our result value has a specific flag set. use the logical AND operator, "&", to test for the value. 

               if((daysOfTheWeek & DaysOfTheWeek.Monday) == DaysOfTheWeek.Monday)
                {
                    // Contains Monday!
                }
                else
                {
                    // DOES NOT Contain Monday!
                }

                daysOfTheWeek	0	1	0	1	0	1	0
	                            &	&	&	&	&	&	&
                        Monday	0	0	0	0	0	1	0
                  ________________________________________
                      Result	0	0	0	0	0	1	0   --> which is Monday!

             */

            //
            // Array Initializers
            // 
            var expectedAppointments = new[] {DaysOfTheWeek.Monday, DaysOfTheWeek.Wednesday, DaysOfTheWeek.Friday};
            // another way... DaysOfTheWeek[] = {DaysOfTheWeek.Monday, DaysOfTheWeek.Wednesday, DaysOfTheWeek.Friday};
            var actualAppointments = new DaysOfTheWeek[3]; // create array length 3

            MySchedule.SetSchedule(expectedAppointments); // using params here!

            var daysOfTheWeek = Enum.GetValues(typeof(DaysOfTheWeek)).Cast<Enum>();// cast to Enum in order to do the Where...below

            var index = 0;
            foreach (var appointment in daysOfTheWeek.Where(MySchedule.Schedule.HasFlag))
            {
                actualAppointments[index] = (DaysOfTheWeek)appointment;
                index++;
            }

            Assert.IsTrue(actualAppointments.SequenceEqual(expectedAppointments)); // https://www.dotnetperls.com/sequenceequal 
        }
    }
}

// resource
// https://stackoverflow.com/questions/8055206/enum-bitwise-flags-instance-enumeration-iteration-foreach 