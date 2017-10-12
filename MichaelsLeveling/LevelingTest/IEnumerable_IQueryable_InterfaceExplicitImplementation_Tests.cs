using System.Linq;
using CSharpMastery;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelingTest
{
    [TestClass]
    public class IEnumerable_IQueryable_InterfaceExplicitImplementation_Tests
    {
        [TestMethod]
        public void FourLeggedAnimalsGetEnumeratorValid()
        {
            var animals = new IEnumerable_IQueryable_InterfaceExplicitImplementation.FourLeggedAnimals();

            animals[0] = new Cat();

            var animal = animals.Take(1).First();

            Assert.IsInstanceOfType(animal, typeof(Cat));
        }

        // the query variable itself never holds the query results and only stores the query commands.Execution of the query is 
        // deferred until the query variable is iterated over in a foreach or For Each loop.This is known as deferred execution;
        [TestMethod]
        public void FourLeggedAnimalsAsQueryable()
        {
            var animals = new IEnumerable_IQueryable_InterfaceExplicitImplementation.FourLeggedAnimals();

            animals[0] = new Cat();
            animals[1] = new Dog();
            animals[2] = new Cat();

            // deffered execution
            // While querying data from database, IQueryable executes select query on server side with all filters. 
            // Hence does less work and becomes fast.

            // Best for querying data from out-memory(like remote database, service) collections.
            IQueryable<AbstractClass_Interfaces_Override_Virtual_Sealed> query =
                 from p in animals.AsQueryable()
                 select p;

            IQueryable<AbstractClass_Interfaces_Override_Virtual_Sealed> dogs = query.Where(p => p is Dog);

            var dog = dogs.Take(1).FirstOrDefault();
            Assert.IsNotNull(dog);

            // This means that you can execute a query as frequently as you want to. 
            // This is useful when, for example, you have a database that is being updated by other applications.
            // In your application, you can create a query to retrieve the latest information and repeatedly execute the query, 
            // returning the updated information every time.

            /*
              The difference is that IQueryable<T> is the interface that allows LINQ-to-SQL (LINQ.-to-anything really) to work. 
              So if you further refine your query on an IQueryable<T>, that query will be executed in the database, if possible.

            For the IEnumerable<T> case, it will be LINQ-to-object, meaning that all objects matching the original query will have 
            to be loaded into memory from the database.

            In code:

            IQueryable<Customer> custs = ...;
            // Later on...
            var goldCustomers = custs.Where(c => c.IsGold);
            That code will execute SQL to only select gold customers. The following code, on the other hand, 
            will execute the original query in the database, then filtering out the non-gold customers in the memory:

            IEnumerable<Customer> custs = ...;
            // Later on...
            var goldCustomers = custs.Where(c => c.IsGold);
            This is quite an important difference, and working on IQueryable<T> can in many cases save you from returning 
            too many rows from the database. Another prime example is doing paging: If you use Take and Skip on IQueryable, 
            you will only get the number of rows requested; doing that on an IEnumerable<T> will cause all of your rows to be loaded in memory.
                            */
        }
    }
}
