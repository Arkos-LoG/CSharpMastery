using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpMastery
{
    public class IEnumerable_IQueryable_InterfaceExplicitImplementation
    {
        // IEnumerable is the base interface for all non-generic collections that can be enumerated (foreach'd)
        // Also,
        // While querying data from database, IEnumerable executes select query on server side, 
        // load data in-memory on client side and then filter data. Hence does more work and becomes slow.

        // best for When querying data from in-memory collections like List, Array, etc.
        // 	In-memory traversal ; for IQueryable see the unit tests
        public class FourLeggedAnimals : IEnumerable<AbstractClass_Interfaces_Override_Virtual_Sealed>  // this inherits IEnumerable, so both have to be implemented
        {                                                               // one has to be done with explicit implementation...

            private readonly IList<AbstractClass_Interfaces_Override_Virtual_Sealed> _fourLeggedAnimals = new List<AbstractClass_Interfaces_Override_Virtual_Sealed>();


            public AbstractClass_Interfaces_Override_Virtual_Sealed this[int index]
            {
                get { return _fourLeggedAnimals[index]; }
                set { _fourLeggedAnimals.Insert(index, value); }
            }

            public void Add(AbstractClass_Interfaces_Override_Virtual_Sealed item)
            {
                _fourLeggedAnimals.Add(item);
            }

            public IEnumerator<AbstractClass_Interfaces_Override_Virtual_Sealed> GetEnumerator()
            {
                //NOTE: could do this -> return _fourLeggedAnimals.GetEnumerator();
                // but this is more fun using yield

                foreach (var o in _fourLeggedAnimals)
                {
                    // Lets check for end of list (its bad code since we used arrays)
                    if (o == null)
                    {
                        break;
                    }

                    // Return the current element and then on next function call 
                    // resume from next element rather than starting all over again;
                    yield return o;
                    // yield is capable of saving its state while returning the value. i.e. when the function is called second time, 
                    // it will continue the processing from where is has returned in the previous call.
                }

                // NOTE: using the yield return statement is that the function should return an IEnumerable 
                // and should be called from an iteration block i.e. foreach statement.
                // for more info: https://www.codeproject.com/Articles/474678/A-Beginners-Tutorial-on-Implementing-IEnumerable-I 
            }

            //
            // Explicit Implementation is required because IEnumerable<T> also has GetEnumerator() method that has to be implemented
            //
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }

    public interface IFoo : IBar
    {
        string SayHello();
    }

    public interface IBar
    {
        string SayHello();
    }

    public class Person : IFoo
    {

        // not allowed to put public on this!
        string IFoo.SayHello()
        {
            return "IFoo.SayHello";
        }

        // not allowed to put public on this!
        string IBar.SayHello()
        {
            return "IBar.SayHello";
        }

        // https://stackoverflow.com/questions/2520727/why-cant-i-call-methods-within-a-class-that-explicitly-implements-an-interface
        // When you explicitly implement the interface, 
        // you first have to cast the object to the interface, 
        // then you can call the method. In other words, 
        // the method is only available when the method is invoked 
        // on the object as the interface type, not as the concrete type. 
        //

        public string SayHello(string whichOne = "")
        {
            switch (whichOne)
            {
                case "IFoo":
                    return ((IFoo)this).SayHello();
                case "IBar":
                    return ((IBar)this).SayHello();
                default:
                    return "SayHello";
            }
        }
    }

}
