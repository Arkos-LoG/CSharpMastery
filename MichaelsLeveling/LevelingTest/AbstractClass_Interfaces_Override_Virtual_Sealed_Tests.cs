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
                new Cat(), new Dog()
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
                new Cat(), new Dog()
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

            cat.Name = "Miss Kitty";

            Assert.IsTrue(called);
        }
    }
}
