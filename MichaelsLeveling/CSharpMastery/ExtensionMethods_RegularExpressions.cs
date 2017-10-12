using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpMastery
{
    public static class ExtensionMethods_RegularExpressions
    {
        public static string DeleteSpaces(this string source)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(source))
            {
                return Regex.Replace(source, @"\s", ""); // \s (match any white-space)
            }

            return result;
        }
    }
}

/*
Allows you to add methods to any existing type.

-Has to be inside of static class
-Method has to be static
-Needs ‘this’ keyword if front of parameter of the static method
    The first parameter represents the type being extended
-Can be called like a static method or on the extended class
*/

// Regular Expression resource
// https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference 
// test regular expression https://regex101.com/ 
