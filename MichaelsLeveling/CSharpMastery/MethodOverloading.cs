using System;

namespace CSharpMastery
{
//  It allows the programmer do define several methods with the same name, as long as they take a different set of parameters.
//  At compile time, the compiler works out which one it's going to call, based on the compile time types of the arguments and the target of the method call. 

    public static class MethodOverloading
    {
        public static string Foo(int x)
        {
            return string.Empty;
        }

        public static Guid Foo(double x)
        {
            return Guid.Empty;
        }

        public static string DefaultParamExample(int x, int y = 5)
        {
            return "Foo(int x, int y = 5)";
        }

        public static string DefaultParamExample(int x)
        {
            return "Foo(int x)";
        }

        public static int NamedArgumentExample(int x, int y)
        {
            return x + y;
        }

        public static int NamedArgumentExample(int x, int y, int z = 2)
        {
            return x + y + z;
        }
    }

    // Below is for showing why to avoid overloading across inheritance boundaries... 
    // at least with methods where more than one method could be applicable for a given call if you flattened the hierarchy
    public class Parent
    {
        public virtual string Foo(int x)
        {
           return "Parent.Foo(int x)";
        }
    }

    public class Child : Parent
    {
        public override string Foo(int x)
        {
            return "Child.Foo(int x)";
        }

        public string Foo(double y)
        {
            return "Child.Foo(double y)";
        }
    }

}
