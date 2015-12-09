using System;
using System.Web.Mvc;
using Jitter.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jitter.Tests.Controllers
{
    [TestClass]
    public class TestControllerTests
    {
        [TestMethod]
        public void TestControllerEnsureGetAction()
        {
            TestController myController = new TestController();
            string expected_output = "Hello World!";
            string actual_output = myController.Get();
            Assert.AreEqual(expected_output, actual_output);
        }
    }
}
