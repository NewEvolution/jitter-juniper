using System;
using Jitter.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JotTests
    {
        [TestMethod]
        public void JotEnsureInstanceCreation()
        {
            Jot a_jot = new Jot();
            Assert.IsNotNull(a_jot);
        }

        [TestMethod]
        public void JotEnsureHasAllProperties()
        {
            Jot a_jot = new Jot();
            DateTime expected_time = DateTime.Now;
            a_jot.JotId = 1;
            a_jot.Author = null;
            a_jot.Date = expected_time;
            a_jot.Content = "My Content";
            a_jot.Picture = "http://fish.bulb.net";
            Assert.AreEqual(1, a_jot.JotId);
            Assert.AreEqual(null, a_jot.Author);
            Assert.AreEqual(expected_time, a_jot.Date);
            Assert.AreEqual("My Content", a_jot.Content);
            Assert.AreEqual("http://fish.bulb.net", a_jot.Picture);
        }

        [TestMethod]
        public void JotEnsureObjectInitializationSyntaxWorks()
        {
            DateTime expected_time = DateTime.Now;
            Jot a_jot = new Jot
            {
                JotId = 1,
                Author = null,
                Date = expected_time,
                Content = "My Content",
                Picture = "http://fish.bulb.net"
            };
            Assert.AreEqual(1, a_jot.JotId);
            Assert.AreEqual(null, a_jot.Author);
            Assert.AreEqual(expected_time, a_jot.Date);
            Assert.AreEqual("My Content", a_jot.Content);
            Assert.AreEqual("http://fish.bulb.net", a_jot.Picture);
        }
    }
}
