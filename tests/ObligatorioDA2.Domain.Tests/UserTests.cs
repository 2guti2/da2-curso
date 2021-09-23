using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDA2.Domain.Roles;

namespace ObligatorioDA2.Domain.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void IsPasswordValid_Successful()
        {
            var user = new User
            {
                Username = "john_doe",
                Password = "123456"
            };

            Assert.IsTrue(user.IsPasswordValid("123456"));
        }

        [TestMethod]
        public void IsPasswordValid_Failed()
        {
            var user = new User
            {
                Username = "john_doe",
                Password = "123456"
            };

            Assert.IsFalse(user.IsPasswordValid("1234"));
        }

        [TestMethod]
        public void CanPerform_Successful()
        {
            var user = new User
            {
                Username = "john_doe",
                Password = "123456",
                Roles = new List<Role> { new MemberRole() }
            };

            Assert.IsTrue(user.CanPerform("CreateForecasts"));
        }

        [TestMethod]
        public void CanPerform_Failed()
        {
            var user = new User
            {
                Username = "john_doe",
                Password = "123456",
                Roles = new List<Role> { new MemberRole() }
            };

            Assert.IsFalse(user.CanPerform("DeleteForecasts"));
        }
    }
}
