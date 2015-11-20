using Moq;
using System;
using Jitter.Models;
using System.Data.Entity;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JitterRepoTests
    {
        [TestMethod]
        public void JitterContextEnsureInstanceCreation()
        {
            JitterContext context = new JitterContext();
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void JitterRepoEnsureInstanceCreation()
        {
            JitterRepo repo = new JitterRepo();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void JitterRepoEnsureContextExists()
        {
            JitterRepo repo = new JitterRepo();
            var actual = repo.Context;
            Assert.IsInstanceOfType(actual, typeof(JitterContext));
        }

        [TestMethod]
        public void JitterRepoEnsureAllUserRetrieval()
        {
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "foo" },
                new JitterUser { Handle = "bar" }
            };
            Mock<DbSet<JitterUser>> mock_set = new Mock<DbSet<JitterUser>>();
            mock_set.Object.AddRange(expected);
            Mock<JitterContext> mock_context = new Mock<JitterContext>();
            mock_context.Setup(jc => jc.JitterUsers).Returns(mock_set.Object);
            JitterRepo repo = new JitterRepo(mock_context.Object);
            var actual = repo.GetAllUsers();
            CollectionAssert.AreEqual(expected, actual);
            //Assert.AreEqual("foo", actual.First().Handle);
        }
    }
}
