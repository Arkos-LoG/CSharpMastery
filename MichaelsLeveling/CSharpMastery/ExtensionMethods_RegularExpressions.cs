using System.Text.RegularExpressions;

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

/*  -- CONFIGURE RESHARPER TODOs --
 
todo high        -> color = Aqua                  -> icon = Warning  -> reg expression:   (?<=\W|^)(?i)(?=TODO)(?i)(?=.*!!!)(\W|$|)(.*)
todo log         -> color = OliveDrab             -> icon = Edit     -> reg expression:   (?<=\W|^)(?i)(?=TODO)(?i)(?=.*LOG )(\W|$|)(.*)  
todo low         -> color = DarkKhaki             -> icon = Normal   -> reg expression:   (?<=\W|^)(?i)(?=TODO)(?i)(?=.*---)(\W|$|)(.*)
todo info        -> color = blue (shows as pink)  -> icon = Question -> reg expression:   (?<=\W|^)(?i)(?=TODO)(?i)(?=.*\?\?\?)(\W|$|)(.*)
todo Medium      -> color = red (shows as orange) -> icon = Normal   -> reg expression:   (?<=\W|^)(?i)(?=TODO)(?i)(?=.*\.\.\.)(\W|$|)(.*)
todo (catch-all) -> color = LightSteelBlue        -> icon = Edit     -> reg expression:   (?<=\W|^)(?i)(?<TAG>TODO)(\W|$)(.*)
Bug              -> color = Gold                  -> icon = Error    -> reg expression:   (?<=\W|^)(?<TAG>BUG)(\W|$)(.*)

(?<=\W|^)(?i)(?=TODO)((?=.*\+{3})|(?=.*!{3}))(\W|$|)(.*)   does both +++ and !!!

http://stackoverflow.com/questions/5421952/how-to-match-multiple-words-in-regex
http://stackoverflow.com/questions/9655164/regex-case-sensitive
http://www.autohotkey.com/docs/misc/RegEx-QuickRef.htm

 */

