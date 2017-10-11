using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMastery
{
    /*
        An Enum is a list of possible values for a variable—a numerical list that may represent days of the week or another list of related items. 
        The enum keyword is used to declare an enumeration, a distinct type that consists of a set of named constants called the enumerator list.

        By default, the first enumerator has the value 0, and the value of each successive enumerator is increased by 1
     */
    public enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };

    /*
        Flags allows an enumeration variable and allow it hold multiple values.  
        Without them if our days of the week were used for storing when a meeting was scheduled we would need 
        seven DayOfTheWeek variables defined or create a list of DayOfTheWeek in order to store the days a meeting could be scheduled.

        To avoid all these variables, we can use flags.  
        To properly implement an enumeration as a flag, you need to have the values increasing by a power of two.

        -- Binary level behind the scenes (notice the left shift of bits) --

        Day of the Week	Decimal Value	Binary Value
        Sunday	        1	            0000001
        Monday	        2	            0000010
        Tuesday	        4	            0000100
        Wednesday	    8	            0001000
        Thursday	    16	            0010000
        Friday	        32	            0100000
        Saturday	    64	            1000000

        To properly implement an enumeration as a flag, you need to have the values increasing by a power of two.

        [Flags]
        public enum DaysOfTheWeek
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 4,
            Wednesday = 8,
            Thursday = 16,
            Friday = 32,
            Saturday = 64
        }


        Through the use of bit shifting, we can move the 1 bit sequentially without having to worry about the actual integer value.
        Think of flags as a series of bit switches.  
        The left-shift operator (<<) shifts its first operand left by the number of bits specified by its second operand.
    */

    [Flags]
    public enum DaysOfTheWeek
    {
        Sunday = 1,
        Monday = 1 << 1,
        Tuesday = 1 << 2,
        Wednesday = 1 << 3,
        Thursday = 1 << 4,
        Friday = 1 << 5,
        Saturday = 1 << 6,
    }

    public class MySchedule
    {
        public static DaysOfTheWeek Schedule { get; set; }

        public static void SetSchedule(params DaysOfTheWeek[] days)
        {
            foreach (var d in days)
            {
                Schedule |= d;  // similar to doing this  daysOfTheWeek = DaysOfTheWeek.Monday | DaysOfTheWeek.Wednesday | DaysOfTheWeek.Friday; 
            }            
        }
    }
}

// GOOG: or bitwise flags enums foreach assignment





 