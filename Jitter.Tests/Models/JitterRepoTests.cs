using Moq;
using System;
using System.Linq;
using Jitter.Models;
using System.Data.Entity;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JitterRepoTests
    {
        private Mock<DbSet<JitterUser>> mock_set;
        private Mock<JitterContext> mock_context;
        private JitterRepo repo;

        private void ConnnectMocksToDataStore(IEnumerable<object> data_store)
        {
            var data_source = (data_store as IEnumerable<JitterUser>).AsQueryable();
            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(jc => jc.JitterUsers).Returns(mock_set.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_set = new Mock<DbSet<JitterUser>>();
            mock_context = new Mock<JitterContext>();
            repo = new JitterRepo(mock_context.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_set = null;
            mock_context = null;
            repo = null;
        }

        [TestMethod]
        public void JitterContextEnsureInstanceCreation()
        {
            JitterContext context = mock_context.Object;
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void JitterRepoEnsureInstanceCreation()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void JitterRepoEnsureContextExists()
        {
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
            mock_set.Object.AddRange(expected);
            ConnnectMocksToDataStore(expected);
            var actual = repo.GetAllUsers();
            CollectionAssert.AreEqual(expected, actual);
            Assert.AreEqual("foo", actual.First().Handle);
        }

        [TestMethod]
        public void JitterRepoEnsureUserAccessViaHandle()
        {
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "foo" },
                new JitterUser { Handle = "bar" },
                new JitterUser { Handle = "grille" }
            };
            mock_set.Object.AddRange(expected);
            ConnnectMocksToDataStore(expected);
            string handle = "bar";
            JitterUser actual = repo.GetUserByHandle(handle);
            Assert.AreEqual(handle, actual.Handle);
        }

        [TestMethod]
        public void JitterRepoNonExistantUserAccessViaHandle()
        {
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "foo" },
                new JitterUser { Handle = "bar" },
                new JitterUser { Handle = "grille" }
            };
            mock_set.Object.AddRange(expected);
            ConnnectMocksToDataStore(expected);
            string handle = "potato";
            JitterUser actual = repo.GetUserByHandle(handle);
            Assert.IsNull(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void JitterRepoErroneousMultiUserAccessViaHandle()
        {
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "foo" },
                new JitterUser { Handle = "bar" },
                new JitterUser { Handle = "bar" }
            };
            mock_set.Object.AddRange(expected);
            ConnnectMocksToDataStore(expected);
            string handle = "bar";
            JitterUser actual = repo.GetUserByHandle(handle);
        }

        [TestMethod]
        public void JitterRepoEnsureHandleIsAvailable()
        {
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "foo" },
                new JitterUser { Handle = "bar" },
                new JitterUser { Handle = "grille" }
            };
            mock_set.Object.AddRange(expected);
            ConnnectMocksToDataStore(expected);
            string handle = "potato";
            bool actual = repo.IsHandleAvailable(handle);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void JitterRepoEnsureHandleIsUnavailable()
        {
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "foo" },
                new JitterUser { Handle = "bar" },
                new JitterUser { Handle = "grille" }
            };
            mock_set.Object.AddRange(expected);
            ConnnectMocksToDataStore(expected);
            string handle = "bar";
            bool actual = repo.IsHandleAvailable(handle);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void JitterRepoEnsureHandleIsUnavailableMultipleHits()
        {
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "foo" },
                new JitterUser { Handle = "bar" },
                new JitterUser { Handle = "bar" }
            };
            mock_set.Object.AddRange(expected);
            ConnnectMocksToDataStore(expected);
            string handle = "bar";
            bool actual = repo.IsHandleAvailable(handle);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void JitterRepoEnsureSearchByHandle()
        {
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "foo" },
                new JitterUser { Handle = "barfly" },
                new JitterUser { Handle = "barman" },
                new JitterUser { Handle = "foobajoob" }
            };
            mock_set.Object.AddRange(expected);
            ConnnectMocksToDataStore(expected);
            string handle = "bar";
            List<JitterUser> actualList = repo.SearchByHandle(handle);
            List<JitterUser> expectedList = new List<JitterUser>
            {
                new JitterUser { Handle = "barfly" },
                new JitterUser { Handle = "barman" }
            };
            Assert.AreEqual(expectedList[0].Handle, actualList[0].Handle);
            Assert.AreEqual(expectedList[1].Handle, actualList[1].Handle);
            //CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
