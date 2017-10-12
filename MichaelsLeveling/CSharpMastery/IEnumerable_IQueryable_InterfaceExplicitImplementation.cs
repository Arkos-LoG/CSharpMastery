using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            private List<AbstractClass_Interfaces_Override_Virtual_Sealed> _fourLeggedAnimals = new List<AbstractClass_Interfaces_Override_Virtual_Sealed>();

            public AbstractClass_Interfaces_Override_Virtual_Sealed this[int index]
            {
                get { return _fourLeggedAnimals[index]; }
                set { _fourLeggedAnimals.Insert(index, value); }
            }

            public IEnumerator<AbstractClass_Interfaces_Override_Virtual_Sealed> GetEnumerator()
            {
                return _fourLeggedAnimals.GetEnumerator();
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
}
