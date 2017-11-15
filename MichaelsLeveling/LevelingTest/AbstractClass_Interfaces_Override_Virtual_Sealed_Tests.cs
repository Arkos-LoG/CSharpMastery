using System.Collections.Generic;
using CSharpMastery;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelingTest
{
    [TestClass]
    public class AbstractClass_Interfaces_Override_Virtual_Sealed_Tests
    {        
        [TestMethod]
        public void DescribeValidWithAbstractClass()
        {
            List<AbstractClass_Interfaces_Override_Virtual_Sealed> animals = new List<AbstractClass_Interfaces_Override_Virtual_Sealed>
            {
                new Cat(), new Dog() // cat and dog are AbstractClass_Interfaces_Override_Virtual_Sealed
            };

            var expectedDog = "I'm a dog!";
            var expectedCat = "I'm a cat!";

            string actualDog = null;
            string actualCat = null;

            foreach (AbstractClass_Interfaces_Override_Virtual_Sealed animal in animals)
            {
                if (animal is Dog)
                {
                    actualDog = animal.Describe();
                }
                else
                {
                    actualCat = animal.Describe();
                }
            }

            Assert.AreEqual(expectedDog, actualDog);
            Assert.AreEqual(expectedCat, actualCat);
        }

        [TestMethod]
        public void DescribeValidWithICreature()
        {
            List<ICreature> creatures = new List<ICreature>
            {
                new Cat(), new Dog() // cat and dog are ICreatures
            };

            var expectedDog = "I'm a dog!";
            var expectedCat = "I'm a cat!";

            string actualDog = null;
            string actualCat = null;

            foreach (ICreature creature in creatures)
            {
                if (creature is Dog)
                {
                    actualDog = creature.Describe();
                }
                else
                {
                    actualCat = creature.Describe();
                }
            }

            Assert.AreEqual(expectedDog, actualDog);
            Assert.AreEqual(expectedCat, actualCat);

            // person has a FirstName and LastName property
           
        }

        [TestMethod]
        public void PropertyNameChanged()
        {
            bool called = false;
            var cat = new Cat();

            cat.PropertyChanged += (sender, eventArgs) =>
            {
                Assert.AreEqual(nameof(cat.Name), eventArgs.PropertyName);
                called = true;
            };

            // 1. change property Name which will call... 
            // 2. Setter for Name in abstract will invoke the function set above
            // 3. that function will do an assert on the Name and set a flag that it's been called
            cat.Name = "Miss Kitty";

            Assert.IsTrue(called);
        }

        //---------------------------------------------------------------------------------------
        // READ ONLY AND CONST
        //--------------------------------------------------------------------------------------- 

        private readonly Cat _cat = new Cat();
        private Dog _dog = new Dog();

        public const int _myConst = 2; // const has to be assigned here where as readonly have to be assigned before constructor exits
        public readonly int _myReadOnly;

        // great resource for differences between readonly and const
        // http://www.arungudelli.com/tutorial/c-sharp/10-differences-between-constant-vs-readonly-static-readonly-fields/

        /*
        From resource above:

            const:
            No Memory Allocated Because constant value embedded in IL code itself after compilation	
            
            readonly:
            dynamic memory allocated for readonly fields and we can get the value at run time.

            const:
            Constants in C# are by default static.Can be accessed only through class name	
            
            readonly:
            Readonly belongs to the object created so accessed through only through instance of class. 
            To make it class member we need to add static keyword before readonly.
                         
        */

        public AbstractClass_Interfaces_Override_Virtual_Sealed_Tests()
        {
            someFunction();
        }

        private void someFunction()
        {
            // every instance of the member marked as const will be replaced with its value during compilation, 
            // the value 2 for _myConst is 'baked into' IL 
            // while readonly members will be resolved at run-time.

            // can't do this. _myReadOnly has to be assigned before the constructor exits
            // _myReadOnly = 4;

            // _cat = null; // can't set it null
            _dog = null;

            // constants are static you can access them like you would a static variable
            var hi = AbstractClass_Interfaces_Override_Virtual_Sealed_Tests._myConst;

            // doesn't exist
            // AbstractClass_Interfaces_Override_Virtual_Sealed_Tests._myReadOnly;
        }
    }
}
