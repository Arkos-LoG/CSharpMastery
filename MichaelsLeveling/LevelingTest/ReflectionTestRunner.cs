using System;
using System.Linq;
using System.Reflection;

namespace LevelingTest
{
    public class SomeClass
    {
        public string Description { get; set; }
    }

    public interface ISupportReflectionTestRunner<out R> where R : SomeClass   // out keyword in generics is used to denote that the type T in the interface is covariant
    {
        R SomeRequiredMethodForReflectionTestRunner();
    }

    /****************************************************************************************
     
        Generics and constraints
        Reflection and BindingFlags
        LINQ
        String Interpolation

     ****************************************************************************************/

    // using reflection, run every test method that has bool for return type
    // with BindingFlags only get the methods declared in the tests https://stackoverflow.com/questions/16609731/reflection-methodinfo-getmethods-include-only-methods-only-added-by-me

    public class ReflectionTestRunner
    {
        // new() constraint https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/new-constraint 

        public static void RunTestsFor<T>() where T  : ISupportReflectionTestRunner<SomeClass>, new() // specifies that any type argument in a generic class declaration must have a public parameterless constructor.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            var testType = typeof(T);
            var testsInstance = new T();  // using this to show off new() constraint above could do following too...
            //var testsInstance = Activator.CreateInstance(testType);

            Console.WriteLine($"Start {testType.Name}");

            var testDescription = testType.GetMethods().First(m => m.ReturnType == typeof(SomeClass)).Invoke(testsInstance, null);

            if (testDescription.GetType() != typeof(SomeClass))
                throw new InvalidOperationException();

            Console.WriteLine($"Description: {(testDescription as SomeClass)?.Description}");

            foreach (var m in testType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.ReturnType == typeof(bool)))
            {
                if (Convert.ToBoolean(m.Invoke(testsInstance, null)) != true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Failed: {m.Name}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Passed: {m.Name}");
                }
            }    
        }
    }
}


/*   -- MORE REFLECTION --
 
    #region Use Reflection to get the current HttpContext

	Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies(); // get list of currently loaded assemblies
	var s = asms.First(a => a.ManifestModule.Name == "SuretyTrust.dll"); // get SuretyTrust

	_httpContextCurrent = (HttpContext)(System.Reflection.Assembly.LoadFrom((s.GetModule("SuretyTrust.dll")).FullyQualifiedName)
							.GetType("SuretyTrust.Code.Utility.ReflectionHelper")
							.InvokeMember("ReturnHttpContext_Current", System.Reflection.BindingFlags.InvokeMethod, System.Type.DefaultBinder, new object(), new object[0]));

	// .GetModule gives access to the FQN of path where SuretyTrust.dll is loaded -> something like ->  FullyQualifiedName: "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\Temporary ASP.NET Files\\root\\b7994435\\e433a6ff\\assembly\\dl3\\fc82467c\\6647d660_d78fcf01\\SuretyTrust.dll"
	// .LoadFrom then uses that FQN to load SuretyTrust.dll 
	// .GetType gets us to static ReflectionHelper class (in SuretyTrust.dll) which we then invoke its method of ReturnHttpContext... to give us the current HttpContext
	// the rest is documented @ http://msdn.microsoft.com/en-us/library/66btctbe.aspx & http://www.codeproject.com/Articles/38870/Examining-an-Assembly-at-Runtime

	#endregion
  
 */



// https://stackoverflow.com/questions/5152346/get-only-methods-with-specific-signature-out-of-type-getmethods 

// covariance stuff:
// https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance 
// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/index
// https://msdn.microsoft.com/en-us/library/dd997386(VS.100).aspx
// https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance#InterfaceCovariantTypeParameters 
// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/creating-variant-generic-interfaces 
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-generic-modifier
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/in-generic-modifier