using System;
using System.Linq;
using System.Reflection;

namespace LevelingTest
{
    public class SomeType
    {
        public string Description { get; set; }
    }

    public interface ISupportReflectionTestRunner<R> where R : SomeType 
    {
        R SomeRequiredMethodForReflectionTestRunner();
    }

    /****************************************************************************************
     
        Generics and constraints
        Reflection and BindingFlags
        LINQ
        String Interpolation

        An example of GetAssemblies() is at the bottom (code I wrote in 2014 for AmTrust)

     ****************************************************************************************/

    // using reflection, run every test method that has bool for return type

    public class ReflectionTestRunner
    {
        // new() constraint specifies that any type argument in a generic class declaration must have a public parameterless constructor.
        // resource: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/new-constraint  

        public static void RunTestsFor<T>() where T  : ISupportReflectionTestRunner<SomeType>, new() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            var testType = typeof(T);
            var testsInstance = new T();  // using this to show off new() constraint above could do following too...
            //var testsInstance = Activator.CreateInstance(testType);

            Console.WriteLine($"Start {testType.Name}");

            // the method with return type 'SomeType' will have the test description
            var testDescription = testType.GetMethods().First(m => m.ReturnType == typeof(SomeType)).Invoke(testsInstance, null);

            if (testDescription == null || testDescription.GetType() != typeof(SomeType))
                throw new InvalidOperationException();

            Console.WriteLine($"Description: {(testDescription as SomeType).Description}");

            /*
             *  BINDING FLAGS
             *  
                FROM: https://msdn.microsoft.com/en-us/library/system.reflection.bindingflags(v=vs.110).aspx 
                DeclaredOnly: Specifies that only members declared at the level of the supplied type's hierarchy should be considered. Inherited members are not considered.
                Public: Specifies that public members are to be included in the search.
                Instance: Specifies that instance members are to be included in the search.
            */
            foreach (var testMethod in testType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.ReturnType == typeof(bool))) // <- only get test methods that return bool
            {
                if (Convert.ToBoolean(testMethod.Invoke(testsInstance, null)) != true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Failed: {testMethod.Name}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Passed: {testMethod.Name}");
                }
            }    
        }
    }
}
  
/*   -------------------------------------------------------------
 *   -- MORE REFLECTION  I WROTE THIS IN 2014 OR SO FOR AMTRUST --
 *   -------------------------------------------------------------
 
    #region Use Reflection to get the current HttpContext

	Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies(); // get list of currently loaded assemblies
	var s = asms.First(a => a.ManifestModule.Name == "SuretyTrust.dll"); // get SuretyTrust

	_httpContextCurrent = (HttpContext)(System.Reflection.Assembly.LoadFrom((s.GetModule("SuretyTrust.dll")).FullyQualifiedName)
							.GetType("SuretyTrust.Code.Utility.ReflectionHelper")
							.InvokeMember("ReturnHttpContext_Current", System.Reflection.BindingFlags.InvokeMethod, System.Type.DefaultBinder, new object(), new object[0]));

    .GetModule gives access to the FQN of path where SuretyTrust.dll is loaded -> something like ->  FullyQualifiedName: "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\Temporary ASP.NET Files\\root\\b7994435\\e433a6ff\\assembly\\dl3\\fc82467c\\6647d660_d78fcf01\\SuretyTrust.dll"
	.LoadFrom then uses that FQN to load SuretyTrust.dll 
	.GetType gets us to static ReflectionHelper class (in SuretyTrust.dll) which we then invoke its method of ReturnHttpContext... to give us the current HttpContext
	
    the rest is documented @ http://msdn.microsoft.com/en-us/library/66btctbe.aspx & http://www.codeproject.com/Articles/38870/Examining-an-Assembly-at-Runtime

	#endregion
  
 */


// RESOURCE:
// https://stackoverflow.com/questions/5152346/get-only-methods-with-specific-signature-out-of-type-getmethods 