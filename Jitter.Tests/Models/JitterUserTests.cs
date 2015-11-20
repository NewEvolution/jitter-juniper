using System;
using Jitter.Models;
using System.Collections.Generic;
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

        [TestMethod]
        public void JitterUserEnsureUserHasJots()
        {
            List<Jot> listOfJots = new List<Jot>
            {
                new Jot
                {
                    JotId = 1,
                    Author = null,
                    Date = DateTime.Now,
                    Content = "My Content",
                    Picture = "http://fish.bulb.net"
                },
                new Jot
                {
                    JotId = 2,
                    Author = null,
                    Date = DateTime.Now,
                    Content = "My Content Extended!",
                    Picture = "http://fish.bulb.net"
                }
            };
            JitterUser a_user = new JitterUser { Handle = "newevolution",  Jots = listOfJots };
            List<Jot> actualJots = a_user.Jots;
            CollectionAssert.AreEqual(listOfJots, actualJots);
        }

        [TestMethod]
        public void JitterUserEnsureUserFollowsOthers()
        {
            List<JitterUser> followingUsers = new List<JitterUser>
            {
                new JitterUser { Handle = "woboabl" },
                new JitterUser { Handle = "wibblebibble" }
            };
            JitterUser a_user = new JitterUser { Handle = "newevolution", Following = followingUsers };
            List<JitterUser> actualUsers = a_user.Following;
            CollectionAssert.AreEqual(followingUsers, actualUsers);
        }
    }
}
