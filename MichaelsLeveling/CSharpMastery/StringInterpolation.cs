using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMastery
{
    public static class StringInterpolation
    {
        public static string Greeting(string firstName, string lastName)
        {
            return $"Hello {firstName} {lastName}"; // note that extra { is used for escaping in a string

            // NOTE: ReflectionTestRunner uses String Interpolation
        }
    }
}
