using System;

namespace CSharpMastery
{
    /*
        Enum lists are constants numerical values that may represent days of the week or another list of related items. 
        The enum keyword is used to declare an enumeration.

        The first enumerator has the value 0, and the value of each successive enumerator is increased by 1
     */

    //public enum Meals { Breakfast, Lunch, Snack, Dinner, LateNight };

    /*
        Flags allows an instance of our enumeration variable to hold multiple values.  

        Implement an enumeration as a flag by having the values increase by a power of two.

        -- binary values --

        Day of the Week	Decimal Value	Binary Value
        Breakfast	        1	            0000001
        Lunch	            2	            0000010 // bits are shifting to the left
        Snack	            4	            0000100
        Dinner	            8	            0001000
        LateNight	       16	            0010000


        Instead of doing powers of two, you can use of bit shifting to move 1 bit sequentially.
        Use the left-shift operator (<<) 
    */

    [Flags]
    public enum Meals
    {
        Breakfast = 1,
        Lunch = 1 << 1, // move the bit left 1 spot
        Snack = 1 << 2, // move left two spots etc...
        Dinner = 1 << 3,
        LateNight = 1 << 4
    }

    public class EatingOut
    {
        public static Meals MealsToEatOut { get; set; }

        public static void SetMealsToEatOut(params Meals[] meals)
        {
            foreach (var m in meals)
            {
                MealsToEatOut |= m;  // similar to doing this  MealsToEatOut = Meals.Breakfast | Meals.Snack | Meals.Dinner; 
            }            
        }
    }
}

// GOOG: or bitwise flags enums foreach assignment





 