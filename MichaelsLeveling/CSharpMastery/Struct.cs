namespace CSharpMastery
{
    public struct CoOrds
    {
        public int x, y;

        public CoOrds(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
}

/*
 https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct 
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-structs 

A struct type is a value type (class is reference type) that is typically used to encapsulate small groups of related variables, 
such as the coordinates of a rectangle or the characteristics of an item in an inventory.

The first difference between reference types and value types we will consider is that reference types are allocated on the heap and garbage-collected, 
whereas value types are allocated either on the stack or inline in containing types and deallocated when the stack unwinds or when their 
containing type gets deallocated. Therefore, allocations and deallocations of value types are in general cheaper than allocations and 
deallocations of reference types.

The next difference is related to memory usage. Value types get boxed when cast to a reference type or one of the interfaces they implement. 
They get unboxed when cast back to the value type. Because boxes are objects that are allocated on the heap and are garbage-collected, 
too much boxing and unboxing can have a negative impact on the heap, the garbage collector, and ultimately the performance of the application. 
In contrast, no such boxing occurs as reference types are cast.

Next, reference type assignments copy the reference, whereas value type assignments copy the entire value. 
Therefore, assignments of large reference types are cheaper than assignments of large value types.

Structs can also contain constructors, constants, fields, methods, properties, indexers, operators, events, and nested types,

Structs can implement an interface but they cannot inherit from another struct or class. 

Structures provide better performance when you have small collections of value-types that you want to group together. 
This happens all the time in game programming, for example, a vertex in a 3D model will have a position, 
texture coordinate and a normal, it is also generally going to be immutable. A single model may have a couple thousand vertices, 
or it may have a dozen, but structs provide less overhead overall in this usage scenario.

Consider defining a structure instead of a class if instances of the type are small and commonly short-lived or are commonly embedded in other objects.

Do not define a structure unless the type has all of the following characteristics:
1.	It logically represents a single value, similar to primitive types (integer, double, and so on).
2.	It has an instance size smaller than 16 bytes.
3.	It is immutable.
4.	It will not have to be boxed frequently.

When you create a struct object using the new operator, it gets created and the appropriate constructor is called. 
Unlike classes, structs can be instantiated without using the new operator. In such a case, there is no constructor call, 
which makes the allocation more efficient. However, the fields will remain unassigned and the object cannot be used until 
all of the fields are initialized.

When a struct contains a reference type as a member, the default constructor of the member must be invoked explicitly, 
otherwise the member remains unassigned and the struct cannot be used. (This results in compiler error CS0171.)

There is no inheritance for structs as there is for classes. A struct cannot inherit from another struct or class, 
and it cannot be the base of a class. Structs, however, inherit from the base class Object. A struct can implement interfaces, 
and it does that exactly as classes do.

*/
