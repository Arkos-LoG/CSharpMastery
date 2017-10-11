using CSharpMastery;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelingTest
{
    [TestClass]
    public class ExtensionMethodsTest
    {
        [TestMethod]
        public void DeleteSpacesTestValid()
        {
            var source = "have a nice day";
            var expected = "haveaniceday";

            var actual = source.DeleteSpaces();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteManySpacesTestValid()
        {
            var source = "have    a  nice      day";
            var expected = "haveaniceday";

            var actual = source.DeleteSpaces();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteSpacesTestWithNoSpaces()
        {
            var source = "haveaniceday";
            var expected = "haveaniceday";

            var actual = source.DeleteSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}
