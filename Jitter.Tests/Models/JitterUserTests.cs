using System;
using Jitter.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JitterUserTests
    {
        [TestMethod]
        public void JitterUserEnsureInstanceCreation()
        {
            JitterUser a_user = new JitterUser();
            Assert.IsNotNull(a_user);
        }

        [TestMethod]
        public void JitterUserEnsureHasAllProperties()
        {
            JitterUser a_user = new JitterUser();
            a_user.Handle = "newevolution";
            a_user.FirstName = "Ryan";
            a_user.LastName = "Tanay";
            a_user.Picture = "http://fish.bulb.net/pic.png";
            a_user.Description = "Actually a robot.";
            Assert.AreEqual("newevolution", a_user.Handle);
            Assert.AreEqual("Ryan", a_user.FirstName);
            Assert.AreEqual("Tanay", a_user.LastName);
            Assert.AreEqual("http://fish.bulb.net/pic.png", a_user.Picture);
            Assert.AreEqual("Actually a robot.", a_user.Description);
        }
    }
}
