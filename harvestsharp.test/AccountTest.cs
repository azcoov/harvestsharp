using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace harvestsharp.test
{
    [TestClass()]
    public class AccountTest : BaseTest
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

        [TestMethod()]
        public void test_AccountConstructorTest()
        {
            Assert.IsTrue(account != null);
        }

        [TestMethod()]
        public void test_AccountUserNameAndPasswordIsBase64Encoded()
        {
            var auth = Convert.ToBase64String(new ASCIIEncoding().GetBytes("test:test"));
            Assert.AreEqual(auth, account.GetEncodedCredentials());
        }

        [TestMethod()]
        public void test_RequestWithNullPathShouldRaiseArguementException()
        {
            try
            {
                account.request(null, "test");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(System.ArgumentException));
                Assert.IsTrue(ex.Message.Contains("Invalid path parameter"));
            }
        }

        [TestMethod()]
        public void test_RequestWithNullMethodShouldRaiseArguementException()
        {
            try
            {
                account.request("test", null);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(System.ArgumentException));
                Assert.IsTrue(ex.Message.Contains("Invalid method parameter"));
            }
        }

        [TestMethod()]
        public void test_RequestShouldReturnString()
        {
            var response = account.request("Projects", "GET");
            Assert.IsTrue(response != String.Empty);
        }

        [TestMethod()]
        public void test_ProjectsRequestShouldReturnProjectsList()
        {
            var request =  account.request("projects", "GET");
            Assert.IsTrue(request.Contains("project"));
        }
    }
}
