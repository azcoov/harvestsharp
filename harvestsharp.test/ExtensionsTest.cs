using harvestsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;

namespace harvestsharp.test
{
    [TestClass()]
    public class ExtensionsTest
    {

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public class Foo
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        [TestMethod()]
        public void test_WhenPassingValidObjectToXElementTestShouldReturnXElement()
        {
            var test = new Foo { id = 1, name = "test" };
            var xelement = test.ToXElement();
            Assert.IsInstanceOfType(xelement, typeof(XElement));
        }
        
    }
}
